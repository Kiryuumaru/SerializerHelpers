using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;
using SerializerHelpers.Types.Generics;
using SerializerHelpers.Types.Primitives;
using SerializerHelpers.Types.Additionals;
using SerializerHelpers.Exceptions;

namespace SerializerHelpers;

/// <summary>
/// Provides implementation for value serializer and deserializer.
/// </summary>
public abstract class Serializer
{
    private static readonly ConcurrentDictionary<Type, SerializerHolder> serializers = new();
    private static readonly ConcurrentDictionary<Type, GenericSerializerHolder> genericSerializers = new();
    private static readonly ConcurrentDictionary<Type, SerializerProxy> serializersCache = new();

    static Serializer()
    {
        // Primitives
        Register(new BoolSerializer());
        Register(new ByteSerializer());
        Register(new CharSerializer());
        Register(new DecimalSerializer());
        Register(new DoubleSerializer());
        Register(new FloatSerializer());
        Register(new IntSerializer());
        Register(new LongSerializer());
        Register(new SByteSerializer());
        Register(new ShortSerializer());
        Register(new Types.Primitives.StringSerializer());
        Register(new UIntSerializer());
        Register(new ULongSerializer());
        Register(new UShortSerializer());

        // Additionals
        Register(new DateTimeSerializer());
        Register(new TimeSpanSerializer());

        // Generics
        Register(new DictionarySerializer());
        Register(new KeyValuePairSerializer());
        Register(new ListSerializer());
    }

    /// <summary>
    /// Gets the serializer for the provided type <paramref name="type"/>.
    /// </summary>
    /// <param name="type">
    /// The type of the serializer to get.
    /// </param>
    /// <returns>
    /// The serializer proxy of the provided type <paramref name="type"/>.
    /// </returns>
    /// <exception cref="SerializerNotSupportedException">
    /// Throws if serializer is not supported.
    /// </exception>
    public static SerializerProxy GetSerializer(Type type)
    {
        return GetSerializerInternal(type);
    }

    /// <summary>
    /// Gets the serializer for the provided type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    /// Underlying type of the serializer.
    /// </typeparam>
    /// <returns>
    /// The serializer proxy of the provided type <typeparamref name="T"/>.
    /// </returns>
    /// <exception cref="SerializerNotSupportedException">
    /// Throws if serializer is not supported.
    /// </exception>
    public static SerializerProxy2<T> GetSerializer<T>()
    {
        return GetSerializerInternal<T>();
    }

    /// <summary>
    /// Serialize the provided <paramref name="value"/> with the specified type <paramref name="type"/>.
    /// </summary>
    /// <param name="value">
    /// The value to serialize.
    /// </param>
    /// <param name="type">
    /// The type of the value to serialize.
    /// </param>
    /// <returns>
    /// The serialized data.
    /// </returns>
    /// <exception cref="SerializerNotSupportedException">
    /// Throws if serializer is not supported.
    /// </exception>
    public static string? Serialize(object? value, Type type)
    {
        return GetSerializer(type).Serialize(value);
    }

    /// <summary>
    /// Serialize the provided <paramref name="value"/> with the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value to serialize.
    /// </typeparam>
    /// <param name="value">
    /// The value to serialize.
    /// </param>
    /// <returns>
    /// The serialized data.
    /// </returns>
    /// <exception cref="SerializerNotSupportedException">
    /// Throws if serializer is not supported.
    /// </exception>
    public static string? Serialize<T>(T? value)
    {
        return GetSerializer<T>().Serialize(value);
    }

    /// <summary>
    /// Deserialize the provided <paramref name="data"/> with the specified type <paramref name="type"/>.
    /// </summary>
    /// <param name="data">
    /// The data to deserialize.
    /// </param>
    /// <param name="type">
    /// The type of the value to deserialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value return if the serializer throws an exception.
    /// </param>
    /// <returns>
    /// The deserialized value.
    /// </returns>
    /// <exception cref="SerializerNotSupportedException">
    /// Throws if serializer is not supported.
    /// </exception>
    public static object? Deserialize(string? data, Type type, object? defaultValue = default)
    {
        return GetSerializer(type).Deserialize(data, defaultValue);
    }

    /// <summary>
    /// Deserialize the provided <paramref name="data"/> with the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value to deserialize.
    /// </typeparam>
    /// <param name="data">
    /// The data to deserialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value return if the serializer throws an exception.
    /// </param>
    /// <returns>
    /// The deserialized value.
    /// </returns>
    /// <exception cref="SerializerNotSupportedException">
    /// Throws if serializer is not supported.
    /// </exception>
    public static T? Deserialize<T>(string? data, T? defaultValue = default)
    {
        return GetSerializer<T>().Deserialize(data, defaultValue);
    }

    /// <summary>
    /// Check if the type can be serialize.
    /// </summary>
    /// <param name="type">
    /// The type to check.
    /// </param>
    /// <returns>
    /// <c>true</c> if the <paramref name="type"/> can be serialize; otherwise, <c>false</c>.
    /// </returns>
    public static bool CanSerialize(Type type)
    {
        try
        {
            _ = GetSerializer(type);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Check if the value can be serialize.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value to check.
    /// </typeparam>
    /// <returns>
    /// <c>true</c> if the <typeparamref name="T"/> can be serialize; otherwise, <c>false</c>.
    /// </returns>
    public static bool CanSerialize<T>()
    {
        try
        {
            GetSerializer<T>();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Globally register a <see cref="ISerializer{T}"/>.
    /// </summary>
    /// <param name="serializer">
    /// The <see cref="ISerializer{T}"/> to register.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="serializer"/> is a null reference.
    /// </exception>
    public static void Register<T>(ISerializer<T> serializer)
    {
        if (serializer == null)
        {
            throw new ArgumentNullException(nameof(serializer));
        }

        serializersCache.Clear();

        SerializerHolder<T> extendedSerializer = new(serializer);

        serializers.AddOrUpdate(typeof(T), extendedSerializer, (type, onlValue) => extendedSerializer);
    }

    /// <summary>
    /// Globally register a <see cref="IGenericSerializer"/>.
    /// </summary>
    /// <param name="serializer">
    /// The <see cref="IGenericSerializer"/> to register.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="serializer"/> is a null reference.
    /// </exception>
    public static void Register(IGenericSerializer serializer)
    {
        if (serializer == null)
        {
            throw new ArgumentNullException(nameof(serializer));
        }

        serializersCache.Clear();

        GenericSerializerHolder extendedSerializer = new(serializer);

        genericSerializers.AddOrUpdate(serializer.GenericTypeDefinition, extendedSerializer, (type, onlValue) => extendedSerializer);
    }

    internal static SerializerProxy2<T> GetSerializerInternal<T>()
    {
        Type type = typeof(T);

        SerializerProxy underlyingSerializer = GetSerializerInternal(type);

        if (underlyingSerializer is SerializerProxy2<T> derivedProxy)
        {
            return derivedProxy;
        }
        else
        {
            SerializerProxy2<T> proxy = new(underlyingSerializer.Serializer, underlyingSerializer.Serialize, underlyingSerializer.Deserialize);
            serializersCache.AddOrUpdate(type, proxy, (type, onlValue) => proxy);
            return proxy;
        }
    }

    internal static SerializerProxy GetSerializerInternal(Type type)
    {
        // From cache
        if (serializersCache.TryGetValue(type, out SerializerProxy? serializerProxy))
        {
            return serializerProxy;
        }

        // From register
        if (serializers.TryGetValue(type, out SerializerHolder? serializer))
        {
            SerializerProxy proxy = new(serializer,
                (value, defaultValue) => serializer.SerializeObject(type, value, defaultValue),
                (data, defaultValue) => serializer.DeserializeObject(type, data, defaultValue));
            serializersCache.AddOrUpdate(type, proxy, (type, onlValue) => proxy);
            return proxy;
        }

        // From nullable
        var nullableType = Nullable.GetUnderlyingType(type);
        if (nullableType != null)
        {
            SerializerProxy underlyingSerializer = GetSerializerInternal(nullableType);
            SerializerProxy proxy = new(
                underlyingSerializer.Serializer,
                (value, defaultValue) =>
                {
                    return value == null ? null : underlyingSerializer.Serialize(value, defaultValue);
                },
                (data, defaultValue) =>
                {
                    return data == null ? null : underlyingSerializer.Deserialize(data, defaultValue);
                });
            serializersCache.AddOrUpdate(type, proxy, (type, onlValue) => proxy);
            return proxy;
        }

        // From generic register
        if (type.IsGenericType)
        {
            var genericTypeDefinition = type.GetGenericTypeDefinition();
            if (genericSerializers.TryGetValue(genericTypeDefinition, out GenericSerializerHolder? genericSerializer))
            {
                SerializerProxy proxy = new(genericSerializer,
                    (value, defaultValue) => genericSerializer.SerializeObject(type, value, defaultValue),
                    (data, defaultValue) => genericSerializer.DeserializeObject(type, data, defaultValue));
                serializersCache.AddOrUpdate(type, proxy, (type, onlValue) => proxy);
                return proxy;
            }
        }

        // From IEnumerable
        if (typeof(IEnumerable).IsAssignableFrom(type))
        {
            // From array
            if (type.IsArray)
            {
                Type? underlyingType = type.GetElementType();
                if (underlyingType != null)
                {
                    SerializerProxy underlyingSerializer = GetSerializerInternal(underlyingType);
                    SerializerProxy proxy = new(
                        underlyingSerializer.Serializer,
                        (value, defaultValue) =>
                        {
                            if (value == null)
                            {
                                return defaultValue;
                            }

                            if (value is not IEnumerable enumerable)
                            {
                                return defaultValue;
                            }
                            int rank = type.GetArrayRank();
                            List<string?> list = new()
                            {
                                rank.ToString()
                            };
                            MethodInfo? getLengthMethod = type.GetMethod("GetLength", new Type[] { typeof(int) });
                            if (getLengthMethod == null)
                            {
                                return defaultValue;
                            }
                            for (int i = 0; i < rank; i++)
                            {
                                list.Add(getLengthMethod.Invoke(value, new object[] { i })?.ToString());
                            }
                            foreach (var item in enumerable)
                            {
                                list.Add(underlyingSerializer.Serialize(item));
                            }

                            return StringSerializer.Serialize(list.ToArray());
                        },
                        (data, defaultValue) =>
                        {
                            string?[]? encoded;
                            try
                            {
                                encoded = StringSerializer.Deserialize(data);
                            }
                            catch
                            {
                                return defaultValue;
                            }
                            if (encoded == null || encoded.Length < 2)
                            {
                                return defaultValue;
                            }
                            if (!int.TryParse(encoded[0], out int rank))
                            {
                                return defaultValue;
                            }
                            if (encoded.Length < rank + 1)
                            {
                                return defaultValue;
                            }
                            int[] lengths = new int[rank];
                            int[] currentIndex = new int[rank];
                            for (int i = 1; i < rank + 1; i++)
                            {
                                if (!int.TryParse(encoded[i], out int length))
                                {
                                    return defaultValue;
                                }
                                lengths[i - 1] = length;
                            }
                            var decoded = Array.CreateInstance(underlyingType, lengths);
                            for (int i = 0; i < encoded.Length - rank - 1; i++)
                            {
                                var value = underlyingSerializer.Deserialize(encoded[i + rank + 1]);
                                decoded.SetValue(value, currentIndex);
                                for (int j = rank - 1; j >= 0; j--)
                                {
                                    if (currentIndex[j] < lengths[j] - 1)
                                    {
                                        currentIndex[j]++;
                                        break;
                                    }
                                    else
                                    {
                                        currentIndex[j] = 0;
                                    }
                                }
                            }
                            return decoded;
                        });
                    serializersCache.AddOrUpdate(type, proxy, (type, onlValue) => proxy);
                    return proxy;
                }
            }
        }

        throw new SerializerNotSupportedException(type);
    }
}

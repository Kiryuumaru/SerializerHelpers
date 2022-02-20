using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;
using SerializerHelpers.Types.Primitives;
using SerializerHelpers.Types.Additionals;
using SerializerHelpers.Exceptions;

namespace SerializerHelpers;

internal abstract class SerializerHolder
{
    #region Members

    /// <summary>
    /// Serialize the provided <paramref name="value"/> with the specified type <see cref="Type"/>.
    /// </summary>
    /// <param name="value">
    /// The value to serialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value if the serialization fail.
    /// </param>
    /// <returns>
    /// The serialized data.
    /// </returns>
    public abstract string? SerializeObject(object? value, string? defaultValue = default);

    /// <summary>
    /// Deserialize the provided <paramref name="data"/> with the specified type <see cref="Type"/>.
    /// </summary>
    /// <param name="data">
    /// The data to deserialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value return if operation failed.
    /// </param>
    /// <returns>
    /// The deserialized value.
    /// </returns>
    public abstract object? DeserializeObject(string? data, object? defaultValue = default);

    /// <summary>
    /// Serialize the provided <paramref name="value"/> with the specified type <see cref="Type"/>.
    /// </summary>
    /// <param name="value">
    /// The value to serialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value if the serialization fail.
    /// </param>
    /// <returns>
    /// The serialized data
    /// </returns>
    public abstract string? SerializeEnumerableObject(object? value, string? defaultValue = default);

    /// <summary>
    /// Deserialize the provided <paramref name="data"/> with the specified type <see cref="Type"/>.
    /// </summary>
    /// <param name="data">
    /// The data to deserialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value return if operation failed.
    /// </param>
    /// <returns>
    /// The deserialized value.
    /// </returns>
    public abstract object? DeserializeEnumerableObject(string? data, object? defaultValue = default);

    #endregion
}

internal class SerializerHolder<T> : SerializerHolder
{
    #region Properties

    private readonly ISerializer<T> serializer;

    #endregion

    #region Initializers

    public SerializerHolder(ISerializer<T> serializer)
    {
        this.serializer = serializer;
    }

    #endregion

    #region Methods

    public string? Serialize(T? value, string? defaultValue = default)
    {
        return serializer.Serialize(value, defaultValue);
    }

    public T? Deserialize(string? data, T? defaultValue = default)
    {
        return serializer.Deserialize(data, defaultValue);
    }

    public string? SerializeEnumerable(IEnumerable<T?>? values, string? defaultValue = default)
    {
        if (values == null)
        {
            return defaultValue;
        }
        var count = values.Count();
        var encodedValues = new string?[count];
        for (int i = 0; i < count; i++)
        {
            encodedValues[i] = Serialize(values.ElementAt(i));
        }
        return StringSerializer.Serialize(encodedValues);
    }

    public IEnumerable<T?>? DeserializeEnumerable(string? data, IEnumerable<T?>? defaultValue = default)
    {
        string?[]? encodedValues;
        try
        {
            encodedValues = StringSerializer.Deserialize(data);
        }
        catch
        {
            return defaultValue;
        }
        if (encodedValues == null)
        {
            return defaultValue;
        }
        var decodedValues = new T?[encodedValues.Length];
        for (int i = 0; i < encodedValues.Length; i++)
        {
            decodedValues[i] = Deserialize(encodedValues[i]);
        }
        return decodedValues;
    }

    public override string? SerializeObject(object? value, string? defaultValue = default)
    {
        return Serialize((T?)value, defaultValue);
    }

    public override object? DeserializeObject(string? data, object? defaultValue = default)
    {
        if (defaultValue is T value)
        {
            return Deserialize(data, value);
        }
        else
        {
            return Deserialize(data);
        }
    }

    public override string? SerializeEnumerableObject(object? value, string? defaultValue = default)
    {
        return SerializeEnumerable((IEnumerable<T?>?)value, defaultValue);
    }

    public override object? DeserializeEnumerableObject(string? data, object? defaultValue = default)
    {
        if (defaultValue is IEnumerable<T?> value)
        {
            return DeserializeEnumerable(data, value);
        }
        else
        {
            return DeserializeEnumerable(data);
        }
    }

    #endregion
}


internal class GenericSerializerHolder : SerializerHolder
{
    #region Properties

    private readonly IGenericSerializer serializer;

    #endregion

    #region Initializers

    public GenericSerializerHolder(IGenericSerializer serializer)
    {
        this.serializer = serializer;
    }

    #endregion

    #region Methods

    public override string? SerializeObject(object? value, string? defaultValue = default)
    {
        return serializer.Serialize(value, defaultValue);
    }

    public override object? DeserializeObject(string? data, object? defaultValue = default)
    {
        return serializer.Deserialize(data, defaultValue);
    }

    public override string? SerializeEnumerableObject(object? value, string? defaultValue = null)
    {
        if (value is not IEnumerable values)
        {
            return defaultValue;
        }

        if (values == null)
        {
            return null;
        }

        List<string?> list = new();
        foreach (var item in values)
        {
            list.Add(serializer.Serialize(item));
        }

        return StringSerializer.Serialize(list.ToArray());
    }

    public override object? DeserializeEnumerableObject(string? data, object? defaultValue = null)
    {
        string?[]? encodedValues;
        try
        {
            encodedValues = StringSerializer.Deserialize(data);
        }
        catch
        {
            return defaultValue;
        }
        if (encodedValues == null)
        {
            return defaultValue;
        }
        var decodedValues = new object?[encodedValues.Length];
        for (int i = 0; i < encodedValues.Length; i++)
        {
            decodedValues[i] = serializer.Deserialize(encodedValues[i]);
        }
        return decodedValues;
    }

    #endregion
}

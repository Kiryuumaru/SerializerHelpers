using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SerializerHelpers.Types.Generics;

/// <inheritdoc/>
public class KeyValuePairSerializer : IGenericSerializer
{
    /// <inheritdoc/>
    public Type GenericTypeDefinition => typeof(KeyValuePair<,>);

    /// <inheritdoc/>
    public object? Deserialize(Type type, string? data, object? defaultValue = null)
    {
        Type[] genericTypes = type.GetGenericArguments();
        if (genericTypes.Length != 2)
        {
            return defaultValue;
        }

        Type keyType = genericTypes[0];
        Type valueType = genericTypes[1];
        SerializerProxy keySerializer = Serializer.GetSerializer(keyType);
        SerializerProxy valueSerializer = Serializer.GetSerializer(valueType);

        string?[]? encoded;
        try
        {
            encoded = StringSerializer.Deserialize(data);
        }
        catch
        {
            return defaultValue;
        }
        if (encoded == null || encoded.Length != 2)
        {
            return defaultValue;
        }
        return Activator.CreateInstance(type, keySerializer.Deserialize(encoded[0]), valueSerializer.Deserialize(encoded[1]));
    }

    /// <inheritdoc/>
    public string? Serialize(Type type, object? value, string? defaultValue = null)
    {
        if (value == null)
        {
            return defaultValue;
        }

        Type[] genericTypes = type.GetGenericArguments();
        if (genericTypes.Length != 2)
        {
            return defaultValue;
        }

        Type keyType = genericTypes[0];
        Type valueType = genericTypes[1];
        SerializerProxy keySerializer = Serializer.GetSerializer(keyType);
        SerializerProxy valueSerializer = Serializer.GetSerializer(valueType);

        PropertyInfo? keyMethod = type.GetProperty("Key");
        PropertyInfo? valueMethod = type.GetProperty("Value");

        if (keyMethod == null || valueMethod == null)
        {
            return defaultValue;
        }

        var itemKey = keyMethod.GetValue(value, null);
        var itemValue = valueMethod.GetValue(value, null);

        return StringSerializer.Serialize(
            keySerializer.Serialize(itemKey),
            valueSerializer.Serialize(itemValue));
    }
}

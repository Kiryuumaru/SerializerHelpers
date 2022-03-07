using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SerializerHelpers.Types.Generics;

/// <inheritdoc/>
public class ListSerializer : IGenericSerializer
{
    /// <inheritdoc/>
    public Type GenericTypeDefinition => typeof(List<>);

    /// <inheritdoc/>
    public object? Deserialize(Type type, string? data, object? defaultValue = null)
    {
        Type[] genericTypes = type.GetGenericArguments();
        if (genericTypes.Length != 1)
        {
            return defaultValue;
        }

        Type itemType = genericTypes[0];
        SerializerProxy itemSerializer = Serializer.GetSerializer(itemType);

        string?[]? encoded;
        try
        {
            encoded = StringSerializer.Deserialize(data);
        }
        catch
        {
            return defaultValue;
        }
        if (encoded == null)
        {
            return defaultValue;
        }
        var decoded = Activator.CreateInstance(type);
        MethodInfo? addMethod = type.GetMethod("Add");
        if (addMethod == null)
        {
            return defaultValue;
        }
        for (int i = 0; i < encoded.Length; i++)
        {
            addMethod.Invoke(decoded, new object?[] { itemSerializer.Deserialize(encoded[i]) });
        }
        return decoded;
    }

    /// <inheritdoc/>
    public string? Serialize(Type type, object? value, string? defaultValue = null)
    {
        if (value == null)
        {
            return defaultValue;
        }

        if (value is not IEnumerable enumerable)
        {
            return defaultValue;
        }

        Type[] genericTypes = enumerable.GetType().GetGenericArguments();
        if (genericTypes.Length != 1)
        {
            return defaultValue;
        }

        Type itemType = genericTypes[0];
        SerializerProxy itemSerializer = Serializer.GetSerializer(itemType);

        List<string?> encoded = new();
        foreach (var item in enumerable)
        {
            encoded.Add(itemSerializer.Serialize(item));
        }

        return StringSerializer.Serialize(encoded.ToArray());
    }
}

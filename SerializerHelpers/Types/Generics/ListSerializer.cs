using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SerializerHelpers.Types.Generics;

/// <inheritdoc/>
public class ListSerializer : IGenericSerializer
{
    /// <inheritdoc/>
    public Type GenericTypeDefinition => typeof(List<>);

    /// <inheritdoc/>
    public object? Deserialize(string? data, object? defaultValue = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public string? Serialize(object? value, string? defaultValue = null)
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

        List<string?> list = new();
        foreach (var item in enumerable)
        {
            list.Add(itemSerializer.Serialize(item));
        }

        return StringSerializer.Serialize(list.ToArray());
    }
}

﻿namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class UIntSerializer : ISerializer<uint>
{
    /// <inheritdoc/>
    public string? Serialize(uint value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public uint Deserialize(string? data, uint defaultValue = default)
    {
        if (uint.TryParse(data, out uint value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

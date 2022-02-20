namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class SByteSerializer : ISerializer<sbyte>
{
    /// <inheritdoc/>
    public string? Serialize(sbyte value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public sbyte Deserialize(string? data, sbyte defaultValue = default)
    {
        if (sbyte.TryParse(data, out sbyte value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

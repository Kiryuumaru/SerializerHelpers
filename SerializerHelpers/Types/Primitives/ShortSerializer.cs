namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class ShortSerializer : ISerializer<short>
{
    /// <inheritdoc/>
    public string? Serialize(short value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public short Deserialize(string? data, short defaultValue = default)
    {
        if (short.TryParse(data, out short value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

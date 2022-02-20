namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class ULongSerializer : ISerializer<ulong>
{
    /// <inheritdoc/>
    public string? Serialize(ulong value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public ulong Deserialize(string? data, ulong defaultValue = default)
    {
        if (ulong.TryParse(data, out ulong value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

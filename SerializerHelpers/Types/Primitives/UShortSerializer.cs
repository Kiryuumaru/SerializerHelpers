namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class UShortSerializer : ISerializer<ushort>
{
    /// <inheritdoc/>
    public string? Serialize(ushort value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public ushort Deserialize(string? data, ushort defaultValue = default)
    {
        if (ushort.TryParse(data, out ushort value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

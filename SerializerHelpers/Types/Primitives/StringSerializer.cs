namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class StringSerializer : ISerializer<string>
{
    /// <inheritdoc/>
    public string? Serialize(string? value, string? defaultValue = default)
    {
        return value;
    }

    /// <inheritdoc/>
    public string? Deserialize(string? data, string? defaultValue = default)
    {
        return data;
    }
}

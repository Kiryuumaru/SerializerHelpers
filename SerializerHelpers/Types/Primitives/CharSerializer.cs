namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class CharSerializer : ISerializer<char>
{
    /// <inheritdoc/>
    public string? Serialize(char value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public char Deserialize(string? data, char defaultValue = default)
    {
        if (char.TryParse(data, out char value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

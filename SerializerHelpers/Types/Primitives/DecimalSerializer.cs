namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class DecimalSerializer : ISerializer<decimal>
{
    /// <inheritdoc/>
    public string? Serialize(decimal value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public decimal Deserialize(string? data, decimal defaultValue = default)
    {
        if (decimal.TryParse(data, out decimal value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

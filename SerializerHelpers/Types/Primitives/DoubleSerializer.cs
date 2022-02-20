namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class DoubleSerializer : ISerializer<double>
{
    /// <inheritdoc/>
    public string? Serialize(double value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public double Deserialize(string? data, double defaultValue = default)
    {
        if (double.TryParse(data, out double value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

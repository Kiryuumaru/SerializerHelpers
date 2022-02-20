namespace SerializerHelpers.Types.Primitives;

/// <inheritdoc/>
public class FloatSerializer : ISerializer<float>
{
    /// <inheritdoc/>
    public string? Serialize(float value, string? defaultValue = default)
    {
        return value.ToString();
    }

    /// <inheritdoc/>
    public float Deserialize(string? data, float defaultValue = default)
    {
        if (float.TryParse(data, out float value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}

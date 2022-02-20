using System;
using System.Collections.Generic;

namespace SerializerHelpers.Types.Additionals;

/// <inheritdoc/>
public class DateTimeSerializer : ISerializer<DateTime>
{
    /// <inheritdoc/>
    public string? Serialize(DateTime value, string? defaultValue = default)
    {
        return StringSerializer.CompressNumber(value.Ticks);
    }

    /// <inheritdoc/>
    public DateTime Deserialize(string? data, DateTime defaultValue = default)
    {
        if (data == null || string.IsNullOrEmpty(data))
        {
            return defaultValue;
        }

        try
        {
            return new DateTime(StringSerializer.ExtractNumber(data));
        }
        catch
        {
            return defaultValue;
        }
    }
}

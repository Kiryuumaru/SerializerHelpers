using System;

namespace SerializerHelpers;

/// <summary>
/// Provides implementation holder for serializer and deserializer.
/// </summary>
public class SerializerProxy
{
    internal SerializerHolder Serializer { get; }

    private readonly Func<object?, string?, string?> serialize;
    private readonly Func<string?, object?, object?> deserialize;

    internal SerializerProxy(
        SerializerHolder serializer,
        Func<object?, string?, string?> serialize,
        Func<string?, object?, object?> deserialize)
    {
        Serializer = serializer;
        this.serialize = serialize;
        this.deserialize = deserialize;
    }

    /// <summary>
    /// Object serializer implementation proxy.
    /// </summary>
    /// <param name="value">
    /// The value to serialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value if the serialization fail.
    /// </param>
    /// <returns>
    /// The serialized data.
    /// </returns>
    public string? Serialize(object? value, string? defaultValue = default) => serialize(value, defaultValue);

    /// <summary>
    /// Data deserializer implementation proxy.
    /// </summary>
    /// <param name="data">
    /// Data to deserialized
    /// </param>
    /// <param name="defaultValue">
    /// The default value returned if deserialize throws an exception.
    /// </param>
    /// <returns>
    /// The deserialized value.
    /// </returns>
    public object? Deserialize(string? data, object? defaultValue = default) => deserialize(data, defaultValue);
}

/// <summary>
/// Provides implementation holder for serializer and deserializer.
/// </summary>
/// <typeparam name="T">
/// The underlying type of the value to serialize and deserialize.
/// </typeparam>
public class SerializerProxy2<T> : SerializerProxy
{
    internal SerializerProxy2(
        SerializerHolder serializer,
        Func<object?, string?, string?> serialize,
        Func<string?, object?, object?> deserialize)
        : base(serializer, serialize, deserialize)
    {
    }

    /// <summary>
    /// Object serializer implementation proxy.
    /// </summary>
    /// <param name="value">
    /// The value to serialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value if the serialization fail.
    /// </param>
    /// <returns>
    /// The serialized data.
    /// </returns>
    public string? Serialize(T? value, string? defaultValue = default) => base.Serialize(value, defaultValue);

    /// <summary>
    /// Data deserializer implementation proxy.
    /// </summary>
    /// <param name="data">
    /// Data to deserialized
    /// </param>
    /// <param name="defaultValue">
    /// The default value returned if deserialize throws an exception.
    /// </param>
    /// <returns>
    /// The deserialized value.
    /// </returns>
    public T? Deserialize(string? data, T? defaultValue = default) => (T?)base.Deserialize(data, defaultValue);
}

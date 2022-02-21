using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SerializerHelpers;

/// <summary>
/// Provides declaration for enumerable type serialization methods.
/// </summary>
public interface IGenericSerializer
{
    /// <summary>
    /// Gets the generic type definition of the serializer.
    /// </summary>
    Type GenericTypeDefinition { get; }

    /// <summary>
    /// Serializes object to its corresponding value.
    /// </summary>
    /// <param name="type">
    /// The type of the data to serialize.
    /// </param>
    /// <param name="value">
    /// The value to serialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value if the serialization fail.
    /// </param>
    /// <returns>
    /// The serialized value.
    /// </returns>
    string? Serialize(Type type, object? value, string? defaultValue = default);

    /// <summary>
    /// Deserialize <see cref="string"/> to its corresponding object.
    /// </summary>
    /// <param name="type">
    /// The type of the data to deserialize.
    /// </param>
    /// <param name="data">
    /// The serialized data to deserialize.
    /// </param>
    /// <param name="defaultValue">
    /// The default value if the deserialization fail.
    /// </param>
    /// <returns>
    /// The deserialized value.
    /// </returns>
    object? Deserialize(Type type, string? data, object? defaultValue = default);
}

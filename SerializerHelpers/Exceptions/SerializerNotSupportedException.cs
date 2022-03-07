using System;

namespace SerializerHelpers.Exceptions;

/// <summary>
/// Occurs when the specified serializer is not supported.
/// </summary>
public class SerializerNotSupportedException : SerializerException
{
    /// <summary>
    /// Creates an instance of <see cref="SerializerNotSupportedException"/> with provided <paramref name="type"/>.
    /// </summary>
    public SerializerNotSupportedException(Type type)
        : base("There is no supported serializer for \'" + type.Name + "\'. Register a serializer for the specified type first.")
    {

    }

    /// <summary>
    /// Creates an instance of <see cref="SerializerNotSupportedException"/> with provided <paramref name="fullname"/>.
    /// </summary>
    public SerializerNotSupportedException(string fullname)
        : base("There is no supported serializer for \'" + fullname + "\'. Register a serializer for the specified type first.")
    {

    }
}

using System;

namespace SerializerHelpers.Exceptions;

/// <summary>
/// Occurs when there`s an error in serialization.
/// </summary>
public class SerializerException : Exception
{
    /// <summary>
    /// Creates an instance of <see cref="SerializerException"/>.
    /// </summary>
    public SerializerException()
    {

    }

    /// <summary>
    /// Creates an instance of <see cref="SerializerException"/> with provided <paramref name="innerException"/>.
    /// </summary>
    public SerializerException(Exception innerException)
        : base("An serializer error occured.", innerException)
    {

    }

    /// <summary>
    /// Creates an instance of <see cref="SerializerException"/> with provided <paramref name="message"/>.
    /// </summary>
    public SerializerException(string message)
        : base(message)
    {

    }

    /// <summary>
    /// Creates an instance of <see cref="SerializerException"/> with provided <paramref name="message"/> and <paramref name="innerException"/>.
    /// </summary>
    public SerializerException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}

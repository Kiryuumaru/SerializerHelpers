using System;

namespace SerializerHelpers.Exceptions;

/// <summary>
/// Occurs when there`s an error in serialization.
/// </summary>
public class SerializerException : Exception
{
    private const string ExceptionMessage =
        "A serializer error occured.";

    /// <summary>
    /// Creates an instance of <see cref="SerializerException"/>.
    /// </summary>
    public SerializerException()
        : base(ExceptionMessage)
    {

    }

    /// <summary>
    /// Creates an instance of <see cref="SerializerException"/> with provided <paramref name="innerException"/>.
    /// </summary>
    /// <param name="innerException">
    /// The inner exception occured.
    /// </param>
    public SerializerException(Exception innerException)
        : base(ExceptionMessage, innerException)
    {

    }

    /// <summary>
    /// Creates an instance of <see cref="SerializerException"/> with provided <paramref name="message"/>.
    /// </summary>
    /// <param name="message">
    /// The message of the exception.
    /// </param>
    public SerializerException(string message)
        : base(message)
    {

    }

    /// <summary>
    /// Creates an instance of <see cref="SerializerException"/> with provided <paramref name="message"/> and <paramref name="innerException"/>.
    /// </summary>
    /// <param name="message">
    /// The message of the exception.
    /// </param>
    /// <param name="innerException">
    /// The inner exception occured.
    /// </param>
    public SerializerException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}

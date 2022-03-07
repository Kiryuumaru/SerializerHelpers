namespace SerializerHelpers.Exceptions;

/// <summary>
/// Occurs when the specified serializer is not supported.
/// </summary>
public class SerializerInvalidValueProvided : SerializerException
{
    /// <summary>
    /// Creates an instance of <see cref="SerializerInvalidValueProvided"/>.
    /// </summary>
    public SerializerInvalidValueProvided()
        : base("The provided value is invalid serialized data.")
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;
using SerializerHelpers.Types.Primitives;
using SerializerHelpers.Types.Additionals;
using SerializerHelpers.Exceptions;

namespace SerializerHelpers;

internal abstract class SerializerHolder
{
    public abstract string? SerializeObject(Type type, object? value, string? defaultValue = default);

    public abstract object? DeserializeObject(Type type, string? data, object? defaultValue = default);
}

internal class SerializerHolder<T> : SerializerHolder
{
    #region Properties

    private readonly ISerializer<T> serializer;

    #endregion

    #region Initializers

    public SerializerHolder(ISerializer<T> serializer)
    {
        this.serializer = serializer;
    }

    #endregion

    #region Methods

    public override string? SerializeObject(Type type, object? value, string? defaultValue = default)
    {
        return serializer.Serialize((T?)value, defaultValue);
    }

    public override object? DeserializeObject(Type type, string? data, object? defaultValue = default)
    {
        if (defaultValue is T value)
        {
            return serializer.Deserialize(data, value);
        }
        else
        {
            return serializer.Deserialize(data);
        }
    }

    #endregion
}


internal class GenericSerializerHolder : SerializerHolder
{
    #region Properties

    private readonly IGenericSerializer serializer;

    #endregion

    #region Initializers

    public GenericSerializerHolder(IGenericSerializer serializer)
    {
        this.serializer = serializer;
    }

    #endregion

    #region Methods

    public override string? SerializeObject(Type type, object? value, string? defaultValue = default)
    {
        return serializer.Serialize(type, value, defaultValue);
    }

    public override object? DeserializeObject(Type type, string? data, object? defaultValue = default)
    {
        return serializer.Deserialize(type, data, defaultValue);
    }

    #endregion
}

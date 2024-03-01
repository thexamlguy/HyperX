using System;
using System.Reflection;

namespace HyperX;

public static class ObjectExtensions
{
    public static object? GetPropertyValue(this object obj, Func<object> selector)
    {
        Type type = obj.GetType();

        if (type.GetProperty($"{selector()}") is PropertyInfo property
            && property.GetValue(obj) is { } value)
        {
            return value;
        }

        return null;
    }

    public static TAttribute? GetAttribute<TAttribute>(this object obj) 
        where TAttribute : Attribute
    {
        Type type = obj.GetType();
        if (type.GetCustomAttribute<TAttribute>() is TAttribute attribute)
        {
            return attribute;
        }

        return null;
    }
}

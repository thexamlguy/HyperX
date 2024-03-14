using System.Reflection;

namespace HyperX;

public static class TypeExtensions
{
    public static TAttribute? GetAttribute<TAttribute>(this Type type)
        where TAttribute : Attribute
    {
        if (type.GetCustomAttribute<TAttribute>() is TAttribute attribute)
        {
            return attribute;
        }

        return null;
    }
}

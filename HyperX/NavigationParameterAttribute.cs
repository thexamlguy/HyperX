namespace HyperX;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class NavigationParameterAttribute : Attribute
{
    public NavigationParameterAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

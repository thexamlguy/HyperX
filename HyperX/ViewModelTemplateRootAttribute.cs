namespace HyperX;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ViewModelTemplateRootAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}

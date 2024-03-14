namespace HyperX;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class SetupRequiredAttribute(object name) : Attribute
{
    public object Name => name;
}

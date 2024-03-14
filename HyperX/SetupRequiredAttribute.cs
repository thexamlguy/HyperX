namespace HyperX;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class NavigationRouteAttribute(string route) : Attribute
{
    public string Route => route;
}

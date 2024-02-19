namespace HyperX;

public interface INavigationProvider
{
    INavigation? Get(Type type);
}

namespace HyperX;

public interface INavigationScopeProvider
{
    INavigationScope? Get(string name);
}


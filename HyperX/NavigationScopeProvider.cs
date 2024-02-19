namespace HyperX;

public class NavigationScopeProvider(INavigationScopeCollection scopes) :
    INavigationScopeProvider
{
    public INavigationScope? Get(string name)
    {
        return scopes.TryGetValue(name, 
            out INavigationScope? scope) ? scope : default;
    }
}


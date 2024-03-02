namespace HyperX;

public interface IComponentScopeProvider
{
    IServiceProvider? Get(string name);
}


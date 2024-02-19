namespace HyperX;

public interface IProxyService<TService>
{
    TService Proxy { get; }
}

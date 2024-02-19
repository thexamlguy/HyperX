using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public interface IProxyServiceCollection<T>
{
    IServiceCollection Services { get; }
}
using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public interface IServiceScopeProvider<TService>
{
    bool TryGet(TService service, out IServiceScope? serviceScope);
}

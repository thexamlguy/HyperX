using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public interface IComponentBuilder
{
    IComponentBuilder ConfigureServices(Action<IServiceCollection> configureDelegate);

    IComponentHost Build();
}
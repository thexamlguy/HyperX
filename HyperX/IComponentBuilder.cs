using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public interface IComponentBuilder
{
    IComponentBuilder AddConfiguration<TConfiguration>(Action<TConfiguration>? configurationDelegate = null)
        where TConfiguration : class, new();

    IComponentHost Build();

    IComponentBuilder ConfigureServices(Action<IServiceCollection> configureDelegate);
}
using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public interface IComponentBuilder
{
    IComponentBuilder AddConfiguration<TConfiguration>(Action<TConfiguration> configurationDelegate)
        where TConfiguration : ComponentConfiguration, new();

    IComponentHost Build();

    IComponentBuilder ConfigureServices(Action<IServiceCollection> configureDelegate);
}
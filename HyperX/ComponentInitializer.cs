using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public class ComponentInitializer(IEnumerable<IComponent> components,
    IProxyServiceCollection<IComponentBuilder> typedServices,
    INavigationScopeCollection scopes,
    IServiceProvider provider) :
    IInitializer
{
    public async Task InitializeAsync()
    {
        foreach (IComponent component in components)
        {
            IComponentBuilder builder = component.Create();
            builder.ConfigureServices(services =>
            {
                services.AddTransient(_ => provider.GetRequiredService<IProxyService<IPublisher>>());

                services.AddScoped(_ => provider.GetRequiredService<INavigationContextCollection>());
                services.AddScoped(_ => provider.GetRequiredService<INavigationContextProvider>());

                services.AddScoped(_ => provider.GetRequiredService<INavigationScopeCollection>());
                services.AddTransient(_ => provider.GetRequiredService<INavigationScopeProvider>());

                services.AddRange(typedServices.Services);
            });

            IComponentHost host = builder.Build();

            scopes.Add(component.GetType().Name, host.Services.GetRequiredService<INavigationScope>());
            await host.StartAsync();
        }
    }
}

﻿using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;

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

                services.AddSingleton(_ => provider.GetRequiredService<INavigationContextCollection>());
                services.AddTransient(_ => provider.GetRequiredService<INavigationContextProvider>());

                services.AddSingleton(_ => provider.GetRequiredService<INavigationScopeCollection>());
                services.AddTransient(_ => provider.GetRequiredService<INavigationScopeProvider>());

                services.AddRange(typedServices.Services);
            });

            IComponentHost host = builder.Build();

            scopes.Add(component.GetType().Name, host.Services.GetRequiredService<INavigationScope>());
            await host.StartAsync();
        }
    }
}

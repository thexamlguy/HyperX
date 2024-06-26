﻿using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public class ComponentInitializer(IEnumerable<IComponent> components,
    IProxyServiceCollection<IComponentBuilder> typedServices,
    IComponentHostCollection hosts,
    IComponentScopeCollection scopes,
    IServiceProvider provider) :
    IInitializer
{
    public async Task Initialize()
    {
        foreach (IComponent component in components)
        {
            IComponentBuilder builder = component.Create();
            builder.AddServices(services =>
            {
                services.AddTransient(_ => 
                    provider.GetRequiredService<IProxyService<IPublisher>>());

                services.AddTransient(_ =>
                    provider.GetRequiredService<IProxyService<IComponentHostCollection>>());

                services.AddScoped(_ => 
                    provider.GetRequiredService<INavigationContextCollection>());
                
                services.AddScoped(_ => 
                    provider.GetRequiredService<INavigationContextProvider>());

                services.AddScoped(_ => 
                    provider.GetRequiredService<IComponentScopeCollection>());

                services.AddTransient(_ => 
                    provider.GetRequiredService<IComponentScopeProvider>());

                services.AddRange(typedServices.Services);
            });

            IComponentHost host = builder.Build();

            scopes.Add(component.GetType().Name,
                host.Services.GetRequiredService<IServiceProvider>());

            hosts.Add(host);
            await host.StartAsync();
        }
    }
}

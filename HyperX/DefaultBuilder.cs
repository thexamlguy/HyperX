using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HyperX;

public class DefaultBuilder : 
    HostBuilder
{
    public static IHostBuilder Create()
    {
        return new HostBuilder()
            .UseContentRoot("Test", true)
            .ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("Settings.json", true, true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddScoped<IServiceFactory>(provider =>
                    new ServiceFactory((type, parameters) => ActivatorUtilities.CreateInstance(provider, type, parameters!)));

                services.AddScoped<SubscriptionCollection>();
                services.AddScoped<ISubscriptionManager, SubscriptionManager>();
                services.AddTransient<ISubscriber, Subscriber>();
                services.AddTransient<IPublisher, Publisher>();

                services.AddScoped<IMediator, Mediator>();

                services.AddScoped<IProxyService<IPublisher>>(provider =>
                    new ProxyService<IPublisher>(provider.GetRequiredService<IPublisher>()));

                services.AddScoped<IProxyService<INavigationContextProvider>>(provider =>
                    new ProxyService<INavigationContextProvider>(provider.GetRequiredService<INavigationContextProvider>()));

                services.AddScoped<IDisposer, Disposer>();

                services.AddTransient<IViewModelTemplateProvider, ViewModelTemplateProvider>();

                services.AddTransient<INavigationProvider, NavigationProvider>();

                services.AddScoped<INavigationContextCollection, NavigationContextCollection>();
                services.AddTransient<INavigationContextProvider, NavigationContextProvider>();

                services.AddScoped<INavigationScope, NavigationScope>();
         
                services.AddScoped<IComponentScopeCollection, ComponentScopeCollection>(provider => new ComponentScopeCollection
                {
                    { "Default", provider.GetRequiredService<IServiceProvider>() }
                });

                services.AddTransient<IComponentScopeProvider, ComponentScopeProvider>();

                services.AddHandler<NavigateHandler>();
                services.AddHandler<NavigateBackHandler>();

                services.AddInitializer<ComponentInitializer>();
                services.AddHostedService<AppService>();
            });
    }
}

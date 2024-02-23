using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace HyperX;

public class DefaultBuilder : HostBuilder
{
    public static IHostBuilder Create()
    {
        return new HostBuilder()
            .UseContentRoot(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                Assembly.GetEntryAssembly()?.GetName().Name!), true)
                        .ConfigureAppConfiguration(config =>
                        {
                            config.AddJsonFile("Settings.json", true, true);
                        })
                        .ConfigureServices((context, services) =>
                        {
                            services.AddSingleton<IServiceFactory>(provider =>
                                new ServiceFactory((type, parameters) => ActivatorUtilities.CreateInstance(provider, type, parameters!)));

                            services.AddSingleton<SubscriptionCollection>();
                            services.AddSingleton<ISubscriptionManager, SubscriptionManager>();
                            services.AddTransient<ISubscriber, Subscriber>();
                            services.AddTransient<IPublisher, Publisher>();

                            services.AddSingleton<IMediator, Mediator>();

                            services.AddSingleton<IProxyService<IPublisher>>(provider =>
                                new ProxyService<IPublisher>(provider.GetRequiredService<IPublisher>()));

                            services.AddSingleton<IProxyService<INavigationContextProvider>>(provider =>
                                new ProxyService<INavigationContextProvider>(provider.GetRequiredService<INavigationContextProvider>()));

                            services.AddSingleton<IDisposer, Disposer>();

                            services.AddTransient<IViewModelTemplateProvider, ViewModelTemplateProvider>();

                            services.AddTransient<INavigationProvider, NavigationProvider>();

                            services.AddSingleton<INavigationContextCollection, NavigationContextCollection>();
                            services.AddTransient<INavigationContextProvider, NavigationContextProvider>();

                            services.AddSingleton<INavigationScope, NavigationScope>();
         
                            services.AddSingleton<INavigationScopeCollection, NavigationScopeCollection>(provider => new NavigationScopeCollection
                            {
                                { "Default", provider.GetRequiredService<INavigationScope>() }
                            });

                            services.AddTransient<INavigationScopeProvider, NavigationScopeProvider>();

                            services.AddHandler<NavigateHandler>();
                            services.AddHandler<NavigateBackHandler>();

                            services.AddInitializer<ComponentInitializer>();
                            services.AddHostedService<AppService>();
                        });
    }
}

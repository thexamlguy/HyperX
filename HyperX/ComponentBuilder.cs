using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HyperX;

public class ComponentBuilder : 
    IComponentBuilder
{
    private readonly IHostBuilder hostBuilder;

    private bool configurationRegistered;

    private ComponentBuilder()
    {
        hostBuilder = new HostBuilder()
            .UseContentRoot("Test", true)
            .ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("Settings.json", true, true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IComponentHost, ComponentHost>();

                services.AddScoped<IServiceFactory>(provider =>
                    new ServiceFactory((type, parameters) =>
                        ActivatorUtilities.CreateInstance(provider, type, parameters!)));

                services.AddSingleton<SubscriptionCollection>();
                services.AddSingleton<ISubscriptionManager, SubscriptionManager>();

                services.AddTransient<ISubscriber, Subscriber>();
                services.AddTransient<IPublisher, Publisher>();

                services.AddTransient<IMediator, Mediator>();
                services.AddSingleton<IDisposer, Disposer>();

                services.AddSingleton<INavigationScope, NavigationScope>();

                services.AddTransient<INavigationProvider, NavigationProvider>();
                services.AddSingleton<NavigationContextCollection>();
                services.AddTransient<INavigationContextProvider, NavigationContextProvider>();

                services.AddHandler<NavigateHandler>();
                services.AddHandler<NavigateBackHandler>();
            });
    }

    public static IComponentBuilder Create() =>
        new ComponentBuilder();

    public IComponentBuilder AddConfiguration<TConfiguration>(Action<TConfiguration>? configurationDelegate = null)
        where TConfiguration : class, new()
    {
        if (configurationRegistered)
        {
            return this;
        }

        configurationRegistered = true;
        TConfiguration configuration = new();

        if (configurationDelegate is not null)
        {
            configurationDelegate(configuration);
        }

        hostBuilder.ConfigureServices(services =>
        {
            services.AddConfiguration(configuration);
        });

        return this;
    }

    public IComponentHost Build()
    {
        IHost host = hostBuilder.Build();
        return host.Services.GetRequiredService<IComponentHost>();
    }

    public IComponentBuilder ConfigureServices(Action<IServiceCollection> configureDelegate)
    {
        hostBuilder.ConfigureServices(configureDelegate);
        return this;
    }
}
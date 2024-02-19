using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Extensions.DependencyInjection;

namespace HyperX.Avalonia;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAvalonia(this IServiceCollection services)
    {
        services.AddTransient<IDispatcher, AvaloniaDispatcher>();

        services.AddTransient<IViewModelTemplate, ViewModelTemplate>();
        services.AddTransient<IViewModelContentBinder, ViewModelContentBinder>();

        services.AddNavigationHandler<ClassicDesktopStyleApplicationHandler>();
        services.AddNavigationHandler<SingleViewApplicationHandler>();
        services.AddNavigationHandler<ContentControlHandler>();

        services.AddSingleton<INavigationContextCollection, NavigationContextCollection>(provider => new NavigationContextCollection
        {
            { typeof(IClassicDesktopStyleApplicationLifetime), typeof(IClassicDesktopStyleApplicationLifetime) },
            { typeof(ISingleViewApplicationLifetime), typeof(ISingleViewApplicationLifetime) }
        });

        services.AddTransient((Func<IServiceProvider, IProxyServiceCollection<IComponentBuilder>>)(provider =>
            new ProxyServiceCollection<IComponentBuilder>(services =>
            {
                services.AddSingleton(provider.GetRequiredService<IDispatcher>());

                services.AddTransient<IViewModelTemplateProvider, ViewModelTemplateProvider>();
                services.AddTransient<IViewModelTemplate, ViewModelTemplate>();

                services.AddTransient<IViewModelContentBinder, ViewModelContentBinder>();

                services.AddNavigationHandler<ContentControlHandler>();
            })));

        return services;
    }
}
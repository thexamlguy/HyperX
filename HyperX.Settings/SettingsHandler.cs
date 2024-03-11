using Microsoft.Extensions.DependencyInjection;

namespace HyperX.Settings;

public class SettingsHandler(IPublisher publisher,
    IServiceFactory factory,
    IComponentScopeCollection scopes) :
    INotificationHandler<Enumerate<INavigationViewModel>>
{
    public async Task Handle(Enumerate<INavigationViewModel> args,
        CancellationToken cancellationToken = default)
    {
        foreach (KeyValuePair<string, IServiceProvider> scope in scopes)
        {
            if (scope.Value is IServiceProvider serviceProvider)
            {
                if (serviceProvider.GetService<ComponentConfiguration>() is
                    ComponentConfiguration configuration)
                {
                    await publisher.Publish(new Create<INavigationViewModel>(factory
                        .Create<ComponentNavigationViewModel>(configuration.Name, scope.Key)),
                            nameof(SettingsViewModel), cancellationToken);
                }
            }
        }
    }
}

namespace HyperX.Settings;

public class SettingsHandler(IPublisher publisher,
    IServiceFactory factory,
    IProxyService<IComponentHostCollection> proxyHosts) : 
    INotificationHandler<Enumerate<INavigationViewModel>>
{
    public async Task Handle(Enumerate<INavigationViewModel> args,
        CancellationToken cancellationToken = default)
    {
        if (proxyHosts.Proxy is IComponentHostCollection hosts)
        {
            foreach (IComponentHost host in hosts)
            {
                if (host.Configuration is ComponentConfiguration configuration)
                {
                    await publisher.PublishAsync(new Create<INavigationViewModel>(factory
                        .Create<ComponentNavigationViewModel>(configuration.Name)),
                            nameof(SettingsViewModel), cancellationToken);
                }
            }
        }
    }
}

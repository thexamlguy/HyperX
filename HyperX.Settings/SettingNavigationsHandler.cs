namespace HyperX.Settings;

public class SettingNavigationsHandler(IPublisher publisher,
    IServiceFactory factory,
    IProxyService<IComponentHostCollection> proxyHosts) : 
    INotificationHandler<Enumerate<NavigationViewModel>>
{
    public async Task Handle(Enumerate<NavigationViewModel> args,
        CancellationToken cancellationToken = default)
    {
        if (proxyHosts.Proxy is IComponentHostCollection hosts)
        {
            foreach (IComponentHost host in hosts)
            {
                if (host.Configuration is ComponentConfiguration configuration)
                {
                    await publisher.PublishAsync(new Create<NavigationViewModel>(factory
                        .Create<NavigationViewModel>(configuration.Name)),
                            nameof(SettingsViewModel), cancellationToken);
                }
            }
        }
    }
}

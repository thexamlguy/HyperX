namespace HyperX.Spotify;

public partial class RemoveConnectionViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) : ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer),
    IPrimaryConfirmation
{
    public async Task<bool> Confirm()
    {
        await Publisher.Publish(Authentication.Create<AccessRevoked>());
        return true;
    }
}

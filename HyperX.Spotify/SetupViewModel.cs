
namespace HyperX.Spotify;

public class SetupViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    public override async Task Activated()
    {
        await Task.Delay(500000);
    }
}
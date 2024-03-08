namespace HyperX.Spotify;

public class AddConnectionViewModel :
    ObservableViewModel
{
    public AddConnectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

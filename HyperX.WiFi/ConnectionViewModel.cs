namespace HyperX.WiFi;

public class ConnectionViewModel :
    ObservableViewModel
{
    public ConnectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}

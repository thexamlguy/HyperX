namespace HyperX.WiFi;

public class ConnectedConnectionViewModel :
    ConnectionViewModel
{
    public ConnectedConnectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}

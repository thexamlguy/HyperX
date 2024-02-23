namespace HyperX.WiFi;

public class OpenConnectionViewModel :
    ConnectionViewModel
{
    public OpenConnectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}
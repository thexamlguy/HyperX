namespace HyperX.WiFi;
public class SecuredConnectionViewModel :
    ConnectionViewModel
{
    public SecuredConnectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

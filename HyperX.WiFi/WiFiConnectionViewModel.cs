namespace HyperX.WiFi;

public class WiFiConnectionViewModel :
    ObservableViewModel
{
    public WiFiConnectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}

namespace HyperX.WiFi;

public class WiFiConnectionInformationViewModel :
    ObservableViewModel
{
    public WiFiConnectionInformationViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}

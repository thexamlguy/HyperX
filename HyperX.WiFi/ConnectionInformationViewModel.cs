namespace HyperX.WiFi;

public class ConnectionInformationViewModel :
    ObservableViewModel
{
    public ConnectionInformationViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}

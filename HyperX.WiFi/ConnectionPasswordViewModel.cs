namespace HyperX.WiFi;

public class ConnectionPasswordViewModel :
    ObservableViewModel
{
    public ConnectionPasswordViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

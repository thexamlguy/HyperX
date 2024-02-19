namespace HyperX.Keyboard;

public class KeyboardLayoutNavigationViewModel :
    ObservableViewModel
{
    public KeyboardLayoutNavigationViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

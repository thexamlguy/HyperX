namespace HyperX.Keyboard;

public class KeyboardLayoutViewModel :
    ObservableCollectionViewModel<KeyboardButtonViewModel>
{
    public KeyboardLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

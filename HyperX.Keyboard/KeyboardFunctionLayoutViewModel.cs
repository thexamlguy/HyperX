namespace HyperX.Keyboard;

public partial class KeyboardFunctionLayoutViewModel :
    KeyboardLayoutViewModel
{
    public KeyboardFunctionLayoutViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

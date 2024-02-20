namespace HyperX.Keyboard;

public class NumericalKeyboardLayoutNavigationViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    KeyboardButtonViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer);
namespace HyperX.Keyboard;

public class LowerAlphabeticalKeyboardLayoutNavigationViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    KeyboardLayoutNavigationViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer);
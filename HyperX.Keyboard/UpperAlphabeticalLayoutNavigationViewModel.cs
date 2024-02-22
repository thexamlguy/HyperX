namespace HyperX.Keyboard;

public class UpperAlphabeticalLayoutNavigationViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    KeyboardButtonViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer);
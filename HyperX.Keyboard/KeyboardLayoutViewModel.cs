namespace HyperX.Keyboard;

public class KeyboardLayoutViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ObservableCollectionViewModel<KeyboardButtonViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer);

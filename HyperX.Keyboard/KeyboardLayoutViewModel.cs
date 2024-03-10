namespace HyperX.Keyboard;

public class KeyboardLayoutViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ObservableCollectionViewModel<CommandViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer);

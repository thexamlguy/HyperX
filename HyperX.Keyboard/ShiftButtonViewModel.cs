namespace HyperX.Keyboard;

public partial class ShiftButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    int index) :
    FunctionButtonViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer, index);

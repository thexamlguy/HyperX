
namespace HyperX.Keyboard;

public partial class KeyboardPreviousButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    int index,
    Func<Task> function) :
    KeyboardFunctionButtonViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer, index, function);

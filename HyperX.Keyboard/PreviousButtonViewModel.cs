
namespace HyperX.Keyboard;

public partial class PreviousButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    int index,
    Func<Task> function) :
    FunctionButtonViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer, index, function);

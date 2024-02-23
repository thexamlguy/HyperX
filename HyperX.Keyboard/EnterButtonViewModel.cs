
namespace HyperX.Keyboard;

public partial class EnterButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    int index) :
    FunctionButtonViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer, index);

namespace HyperX.WiFi;

public class ConnectedConnectionViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    string name) :
    ConnectionViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer, name);
namespace HyperX.WiFi;

public class ConnectionPasswordViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ValueViewModel<string>(serviceProvider, serviceFactory, publisher, subscriber, disposer),
    INavigatingFrom<string?>
{
    public Task<string?> NavigatingFromAsync() => 
        Task.FromResult(Value);
}

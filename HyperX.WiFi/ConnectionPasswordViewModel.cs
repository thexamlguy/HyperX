
namespace HyperX.WiFi;

public class ConnectionPasswordViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ValueViewModel<string>(serviceProvider, serviceFactory, publisher, subscriber, disposer),
    INavigated<string>
{
    [NavigationContext("Input")]
    public Task NavigatedAsync(string result) =>
        Task.FromResult(Value = result);
}

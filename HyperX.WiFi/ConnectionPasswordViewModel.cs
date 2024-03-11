
namespace HyperX.WiFi;

public class ConnectionPasswordViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ValueViewModel<string>(serviceProvider, serviceFactory, publisher, subscriber, disposer),
    IActivated<string>
{
    [NavigationContext("Input")]
    public Task Activated(string result) =>
        Task.FromResult(Value = result);
}

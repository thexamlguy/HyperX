
namespace HyperX.WiFi;

public class ConnectionPasswordViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ValueViewModel<string>(serviceProvider, serviceFactory, publisher, subscriber, disposer),
    INavigatedTo<string>
{
    [NavigationParameter("Input")]
    public Task NavigatedToAsync(string result) =>
        Task.FromResult(Value = result);
}

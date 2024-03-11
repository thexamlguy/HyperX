
namespace HyperX.WiFi;

public class ConnectionAuthenticationViewModel :
    ObservableCollectionViewModel<IDisposable>
{
    public ConnectionAuthenticationViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IContentTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<ConnectionPasswordViewModel>();
        Add<ConnectViewModel>();
    }

    public IContentTemplate Template { get; }
}

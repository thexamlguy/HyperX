namespace HyperX.WiFi;

public class ConnectionAuthenticationViewModel :
    ObservableCollectionViewModel<IDisposable>
{
    public ConnectionAuthenticationViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<ConnectionPasswordViewModel>();
    }

    public IViewModelTemplate Template { get; }
}

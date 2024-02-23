namespace HyperX.WiFi;

public class WiFiViewModel : 
    ObservableCollectionViewModel<ConnectionViewModel>
{
    public WiFiViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber, 
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<ConnectedConnectionViewModel>();
        Add<SecuredConnectionViewModel>();
        Add<SecuredConnectionViewModel>();
        Add<OpenConnectionViewModel>();
        Add<OpenConnectionViewModel>();
        Add<OpenConnectionViewModel>();
    }

    public IViewModelTemplate Template { get; }
}

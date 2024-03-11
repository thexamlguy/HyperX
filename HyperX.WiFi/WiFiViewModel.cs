namespace HyperX.WiFi;

public class WiFiViewModel : 
    ObservableCollectionViewModel<ConnectionViewModel>
{
    public WiFiViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber, 
        IDisposer disposer,
        IContentTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<ConnectedConnectionViewModel>($"{Guid.NewGuid()}");
        Add<SecuredConnectionViewModel>($"{Guid.NewGuid()}");
        Add<SecuredConnectionViewModel>($"{Guid.NewGuid()}");
        Add<OpenConnectionViewModel>($"{Guid.NewGuid()}");
        Add<OpenConnectionViewModel>($"{Guid.NewGuid()}");
        Add<OpenConnectionViewModel>($"{Guid.NewGuid()}");
    }

    public IContentTemplate Template { get; }
}

namespace HyperX.WiFi;

public class WiFiViewModel : 
    ObservableCollectionViewModel<WiFiConnectionViewModel>
{
    public WiFiViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber, 
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<WiFiConnectionViewModel>();
        Add<WiFiConnectionViewModel>();
        Add<WiFiConnectionViewModel>();
        Add<WiFiConnectionViewModel>();
        Add<WiFiConnectionViewModel>();
        Add<WiFiConnectionViewModel>();
    }

    public IViewModelTemplate Template { get; }
}

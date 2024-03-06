namespace HyperX.Settings;

public class ComponentViewModel :
    ObservableCollectionViewModel<IComponentConfigurationViewModel>
{
    public ComponentViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}

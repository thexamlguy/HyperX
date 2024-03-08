namespace HyperX;

public interface IComponentConfigurationViewModel
{

}


public partial class ComponentConfigurationViewModel<TConfiguration, TValue, THeader, TDescription, TAction> :
    ValueViewModel<TValue>,
    IComponentConfigurationViewModel
    where TConfiguration : class
{
    public ComponentConfigurationViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher,
        ISubscriber subscriber, 
        IDisposer disposer,
        THeader header,
        TDescription description,
        TAction action) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

public partial class ComponentConfigurationViewModel<TConfiguration, TValue, TAction> :
    ValueViewModel<TValue>,
    IComponentConfigurationViewModel
    where TConfiguration : class
{
    public ComponentConfigurationViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer,
        Func<TConfiguration, TValue> valueDelegate,
        object header,
        object description) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}
namespace HyperX;

public interface IComponentConfigurationViewModel
{

}

public partial class ButtonActionConfigurationViewModel<TConfiguration, TValue> :
    ComponentConfigurationViewModel<TConfiguration, TValue>
    where TConfiguration : class
{
    public ButtonActionConfigurationViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer, 
        string title, 
        string description,
        Action<ButtonActionConfigurationViewModel<TConfiguration, TValue>> action) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer, title, description)
    {

    }
}

public partial class ComponentConfigurationViewModel<TConfiguration, TValue> :
    ValueViewModel<TValue>,
    IComponentConfigurationViewModel
    where TConfiguration : class
{
    public ComponentConfigurationViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher,
        ISubscriber subscriber, 
        IDisposer disposer,
        string title,
        string description) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}
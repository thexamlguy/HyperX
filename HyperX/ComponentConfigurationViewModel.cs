using CommunityToolkit.Mvvm.ComponentModel;

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

public partial class ComponentConfigurationViewModel<TConfiguration, TValue, TAction>(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    TAction action,
    Func<TConfiguration, TValue> valueDelegate,
    object header,
    object description) :
    ValueViewModel<TValue>(serviceProvider, serviceFactory, publisher, subscriber, disposer),
    IComponentConfigurationViewModel
    where TConfiguration : class
{
    [ObservableProperty]
    private TAction action = action;

    [ObservableProperty]
    private object header = header;

    [ObservableProperty]
    private object description = description;
}
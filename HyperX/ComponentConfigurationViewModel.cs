

namespace HyperX;

public interface IComponentConfigurationViewModel
{

}
public partial class ComponentConfigurationViewModel<TConfiguration, TValue> :
    ValueViewModel<TValue>,
    IComponentConfigurationViewModel,
    INotificationHandler<Changed<TConfiguration>>
    where TConfiguration :
    class
{
    public ComponentConfigurationViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher,
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }

    public Task Handle(Changed<TConfiguration> args, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
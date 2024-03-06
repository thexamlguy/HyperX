namespace HyperX.Settings;

public class ComponentHandler(IEnumerable<IComponentConfigurationViewModel> viewModels) :
    INotificationHandler<Enumerate<IComponentConfigurationViewModel>>
{
    public Task Handle(Enumerate<IComponentConfigurationViewModel> args, 
        CancellationToken cancellationToken = default)
    {
        var d = viewModels;
        throw new NotImplementedException();
    }
}

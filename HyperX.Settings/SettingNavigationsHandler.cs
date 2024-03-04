namespace HyperX.Settings;

public class SettingNavigationsHandler : 
    INotificationHandler<Enumerate<INavigationViewModel>>
{
    public Task Handle(Enumerate<INavigationViewModel> args,
        CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}

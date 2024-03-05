namespace HyperX.Settings.Avalonia;

public class SettingsComponent :
    IComponent
{
    public IComponentBuilder Create()
    {
        return ComponentBuilder.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<SettingsViewModel,
                    SettingsView>("Settings");

                services.AddViewModelTemplate<SettingHeaderViewModel,
                    SettingHeaderView>("Header");

                services.AddHandler<SettingNavigationsHandler>();
            });
    }
}
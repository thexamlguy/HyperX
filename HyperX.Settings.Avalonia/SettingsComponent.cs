namespace HyperX.Settings.Avalonia;

public class SettingsComponent :
    IComponent
{
    public IComponentBuilder Create()
    {
        return ComponentBuilder.Create()
            .AddServices(services =>
            {
                services.AddViewModelTemplate<SettingsViewModel,
                    SettingsView>("Settings");

                services.AddViewModelTemplate<SettingHeaderViewModel,
                    SettingHeaderView>("Header");

                services.AddViewModelTemplate<NavigationViewModel,
                    SettingsNavigationView>();

                services.AddHandler<SettingNavigationsHandler>();
            });
    }
}
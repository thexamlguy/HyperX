namespace HyperX.Settings.Avalonia;

public class SettingsComponent :
    IComponent
{
    public IComponentBuilder Create()
    {
        return ComponentBuilder.Create()
            .AddServices(services =>
            {
                services.AddTemplate<ComponentNavigationViewModel,
                    ComponentNavigationView>();

                services.AddTemplate<HeaderViewModel,
                    HeaderView>("Header");

                services.AddTemplate<SettingsViewModel,
                    SettingsView>("Settings");

                services.AddTemplate<ComponentViewModel,
                    ComponentView>("Component");

                services.AddHandler<SettingNavigationsHandler>();
            });
    }
}
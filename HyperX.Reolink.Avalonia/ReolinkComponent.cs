namespace HyperX.Reolink.Avalonia;

public class ReolinkComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .AddServices(services =>
            {
                services.AddViewModelTemplate<LiveViewModel,
                    LiveView>("Live");
            });
}
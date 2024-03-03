namespace HyperX.Reolink.Avalonia;

public class ReolinkComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<LiveViewModel,
                    LiveView>("Live");
            });
}
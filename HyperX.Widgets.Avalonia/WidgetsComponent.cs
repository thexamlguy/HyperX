namespace HyperX.Widgets.Avalonia;

[ViewModelTemplateRoot("Widgets")]
public class WidgetsComponent :
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<WidgetsViewModel,
                    WidgetsView>("Widgets");
            });
}
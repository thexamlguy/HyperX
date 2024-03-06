namespace HyperX.DateTime.Avalonia;

public class DateTimeComponent :
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .AddServices(services =>
            {
                services.AddViewModelTemplate<DateTimeViewModel,
                    DateTimeView>("DateTime");
            });
}
namespace HyperX.DateTime.Avalonia;

public class DateTimeComponent :
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .AddServices(services =>
            {
                services.AddTemplate<DateTimeViewModel,
                    DateTimeView>("DateTime");
            });
}
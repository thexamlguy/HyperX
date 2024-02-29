namespace HyperX.DateTime.Avalonia;

[ViewModelTemplateRoot("DateTime")]
public class DateTimeComponent :
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<DateTimeViewModel,
                    DateTimeView>("DateTime");
            });
}
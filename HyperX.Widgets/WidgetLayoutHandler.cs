namespace HyperX.Widgets;

public class WidgetLayoutHandler(IPublisher publisher,
    IServiceFactory factory,
    WidgetsConfiguration configuration) :
    INotificationHandler<Enumerate<WidgetLayoutViewModel>>
{
    public async Task Handle(Enumerate<WidgetLayoutViewModel> args,
        CancellationToken cancellationToken)
    {
        for (int index = 0; index < configuration.Layouts.Count; index++)
        {
            if (factory.Create<WidgetLayoutViewModel>($"WidgetLayoutViewModel:{index}")
                is WidgetLayoutViewModel item)
            {
                await publisher.PublishUI(new Create<WidgetLayoutViewModel>(item), cancellationToken);
            }
        }
    }
}

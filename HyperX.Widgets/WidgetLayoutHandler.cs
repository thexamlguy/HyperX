namespace HyperX.Widgets;

public class WidgetLayoutHandler(IPublisher publisher,
    IServiceFactory factory,
    WidgetsConfiguration configuration) :
    INotificationHandler<Enumerate<WidgetLayoutViewModel>>
{
    public async Task Handle(Enumerate<WidgetLayoutViewModel> args,
        CancellationToken cancellationToken)
    {
        foreach (WidgetLayout widgetLayout in configuration)
        {
            await publisher.PublishUIAsync(new Create<WidgetLayoutViewModel>(factory.Create<WidgetLayoutViewModel>()), 
                cancellationToken);
        }
    }
}
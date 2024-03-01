namespace HyperX.Widgets;

public class WidgetLayoutHandler(IPublisher publisher,
    IServiceFactory factory,
    WidgetsConfiguration configuration) :
    INotificationHandler<Enumerate<WidgetLayoutViewModel>>
{
    public async Task Handle(Enumerate<WidgetLayoutViewModel> args,
        CancellationToken cancellationToken)
    {
        for (int index = 0; index < configuration.Count; index++)
        {
            await publisher.PublishUIAsync(new Create<WidgetLayoutViewModel>(
                    factory.Create<WidgetLayoutViewModel>($"WidgetLayoutViewModel:{index}")), cancellationToken);
        }
    }
}

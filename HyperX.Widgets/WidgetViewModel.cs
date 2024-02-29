namespace HyperX.Widgets;

public class WidgetViewModel :
    ObservableViewModel
{
    public WidgetViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}
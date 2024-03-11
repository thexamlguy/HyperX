namespace HyperX.Widgets;

public class WidgetsViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    IContentTemplate template) : 
    ObservableCollectionViewModel<WidgetLayoutViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    public IContentTemplate Template => template;
}
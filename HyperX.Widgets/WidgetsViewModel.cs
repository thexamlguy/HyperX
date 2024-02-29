namespace HyperX.Widgets;

public class WidgetsViewModel : 
    ObservableCollectionViewModel<WidgetViewModel>
{
    public WidgetsViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<WidgetViewModel>();
        Add<WidgetViewModel>();
        Add<WidgetViewModel>();
        Add<WidgetViewModel>();
        Add<WidgetViewModel>();
    }

    public IViewModelTemplate Template { get; }
}
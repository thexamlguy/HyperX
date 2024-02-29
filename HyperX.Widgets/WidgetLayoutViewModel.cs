namespace HyperX.Widgets;

public class WidgetLayoutViewModel : 
    ObservableCollectionViewModel<WidgetContainerViewModel>
{
    public WidgetLayoutViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer,
        IViewModelTemplate template) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Template = template;

        Add<WidgetContainerViewModel>("Spotify", "SpotifyComponent", 0, 0, 1, 1);
    }

    public IViewModelTemplate Template { get; }
}
using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Widgets;

[NotificationHandler(nameof(Id))]
public partial class WidgetLayoutViewModel : 
    ObservableCollectionViewModel<WidgetContainerViewModel>
{
    [ObservableProperty]
    private string id;

    public WidgetLayoutViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher, 
        ISubscriber subscriber, 
        IDisposer disposer,
        IViewModelTemplate template,
        string id) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Id = id;
        Template = template;

        Add<WidgetContainerViewModel>("Spotify", "SpotifyComponent", 0, 0, 1, 1);
    }

    public IViewModelTemplate Template { get; }
}
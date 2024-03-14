using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Widgets;

[Notification(nameof(Id))]
public partial class WidgetLayoutViewModel(IServiceProvider serviceProvider, 
    IServiceFactory serviceFactory, 
    IPublisher publisher,
    ISubscriber subscriber, 
    IDisposer disposer,
    IContentTemplate template,
    string id) : 
    ObservableCollectionViewModel<WidgetContainerViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    [ObservableProperty]
    private string id = id;

    public IContentTemplate Template => template;
}
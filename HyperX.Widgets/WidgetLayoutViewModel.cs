using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Widgets;

[NotificationHandler(nameof(Id))]
public partial class WidgetLayoutViewModel(IServiceProvider serviceProvider, 
    IServiceFactory serviceFactory, 
    IPublisher publisher,
    ISubscriber subscriber, 
    IDisposer disposer,
    IViewModelTemplate template,
    string id) : 
    ObservableCollectionViewModel<WidgetContainerViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    [ObservableProperty]
    private string id = id;

    public IViewModelTemplate Template => template;
}
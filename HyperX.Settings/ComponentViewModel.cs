using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Settings;

[NotificationHandler(nameof(Component))]
public partial class ComponentViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    IViewModelTemplate template,
    string component) :
    ObservableCollectionViewModel<IComponentConfigurationViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    [ObservableProperty]
    private string component = component;

    public IViewModelTemplate Template => template;
}

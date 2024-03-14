using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Settings;

[Notification(nameof(Component))]
public partial class ComponentViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    IContentTemplate template,
    string component) :
    ObservableCollectionViewModel<IComponentConfigurationViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    [ObservableProperty]
    private string component = component;

    public IContentTemplate Template => template;
}

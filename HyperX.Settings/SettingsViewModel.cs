namespace HyperX.Settings;

[NotificationHandler(nameof(SettingsViewModel))]
public partial class SettingsViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer,
    IViewModelTemplate template) :
    ObservableCollectionViewModel<INavigationViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    public IViewModelTemplate Template => template;
}
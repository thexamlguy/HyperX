namespace HyperX.Settings;

public partial class SettingsViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ObservableCollectionViewModel<INavigationViewModel>(serviceProvider, serviceFactory, publisher, subscriber, disposer);
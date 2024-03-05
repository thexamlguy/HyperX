namespace HyperX.Settings;

public partial class SettingHeaderViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) : ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer);

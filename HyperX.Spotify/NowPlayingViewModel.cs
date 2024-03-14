namespace HyperX.Spotify;

[NavigationRoute("Setup")]
public class NowPlayingViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) : 
    ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer);
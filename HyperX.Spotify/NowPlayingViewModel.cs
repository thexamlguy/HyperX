namespace HyperX.Spotify;

public class NowPlayingViewModel : 
    ObservableViewModel
{
    public NowPlayingViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

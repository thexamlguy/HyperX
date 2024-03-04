namespace HyperX.Spotify;

public class NowPlaying : ObservableViewModel
{
    public NowPlaying(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber, 
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {

    }
}

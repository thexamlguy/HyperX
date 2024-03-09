namespace HyperX.Spotify;

public partial class NowPlayingTrackViewModel :
    ValueViewModel<string>
{
    public NowPlayingTrackViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Value = "This is a test track";
    }
}

namespace HyperX.Spotify;

public partial class NowPlayingArtistViewModel :
    ValueViewModel<string>
{
    public NowPlayingArtistViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Value = "Artist";
    }
}

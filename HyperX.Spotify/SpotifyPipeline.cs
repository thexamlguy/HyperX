namespace HyperX.Spotify;

public class SpotifyPipeline<TNotification> : 
    IPipelineBehavior<TNotification> where TNotification : ISpotify
{
    public Task Handle(TNotification notification, 
        NotificationHandlerDelegate<TNotification> next, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

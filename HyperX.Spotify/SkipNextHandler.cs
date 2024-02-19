namespace HyperX.Spotify;

public class SkipNextHandler :
    INotificationHandler<SkipNext>
{
    public Task Handle(SkipNext args,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
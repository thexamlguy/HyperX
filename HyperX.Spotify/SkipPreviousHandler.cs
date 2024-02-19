namespace HyperX.Spotify;

public class SkipPreviousHandler :
    INotificationHandler<SkipPrevious>
{
    public Task Handle(SkipPrevious args,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

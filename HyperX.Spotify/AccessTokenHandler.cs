namespace HyperX.Spotify;

public class AccessTokenHandler :
    INotificationHandler<Authentication<AccessToken>>
{
    public Task Handle(Authentication<AccessToken> args,
        CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}

namespace HyperX.Spotify;

public class AccessTokenHandler(IWritableConfiguration<SpotifyConfiguration> configuration) :
    INotificationHandler<Authentication<AccessToken>>
{
    public Task Handle(Authentication<AccessToken> args,
        CancellationToken cancellationToken = default)
    {
        configuration.Write(args => args.IsConnected = true);
        return Task.CompletedTask;
    }
}

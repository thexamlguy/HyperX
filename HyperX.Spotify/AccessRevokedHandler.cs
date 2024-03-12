namespace HyperX.Spotify;

public class AccessRevokedHandler(IWritableConfiguration<SpotifyConfiguration> configuration) :
    INotificationHandler<Authentication<AccessRevoked>>
{
    public Task Handle(Authentication<AccessRevoked> args,
        CancellationToken cancellationToken = default)
    {
        configuration.Write(config =>
        {
            config.IsConnected = false;
            config.Token = "";
            config.RefreshToken = "";
        });

        return Task.CompletedTask;
    }
}


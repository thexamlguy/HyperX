namespace HyperX.Spotify;

public class AccessGrantedHandler(IWritableConfiguration<SpotifyConfiguration> configuration) :
    INotificationHandler<Authentication<AccessGranted>>
{
    public Task Handle(Authentication<AccessGranted> args,
        CancellationToken cancellationToken = default)
    {
        configuration.Write(config => 
        {
            config.IsConnected = true;
            config.Token = args.Value.Token;
            config.RefreshToken = args.Value.RefreshToken;
        });

        return Task.CompletedTask;
    }
}
namespace HyperX.Spotify.Avalonia;

public class SpotifyComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .AddConfiguration<SpotifyConfiguration>(args => 
            {
                args.Name = "Spotify";
                args.Description = "Spotify remote player";
            })
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<NowPlaying,
                    NowPlayingView>("NowPlaying");
            });
}
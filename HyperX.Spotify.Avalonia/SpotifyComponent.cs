using HyperX.Avalonia;

namespace HyperX.Spotify.Avalonia;

public class SpotifyComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .AddConfiguration<SpotifyConfiguration>(args => 
            {
                args.Name = "Spotify";
                args.Description = "Spotify remote";
            })
            .AddServices(services =>
            {
                services.AddTemplate<NowPlaying,
                    NowPlayingView>("NowPlaying");

                services.AddConfigurationTemplate<ComponentConfigurationViewModel<SpotifyConfiguration, bool>,
                    ToggleConfigurationView>("Account", "Spotify Account", "Connect to your Spotify account");
            });
}
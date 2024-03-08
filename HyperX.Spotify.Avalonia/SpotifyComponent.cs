using Avalonia.Controls;
using Avalonia.Controls.Primitives;
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

                services.AddComponentConfigurationTemplate<SpotifyConfiguration, bool, ConnectionButtonView>(args => args.IsConnected, 
                    "Spotify Account",  "Connect to your Spotify account");
            });
}
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

                services.AddComponentConfigurationTemplate<SpotifyConfiguration, bool, ToggleSwitch>(args => args.IsConnected, 
                    "Spotify Account",  "Connect to your Spotify account");

                services.AddComponentConfigurationTemplate<SpotifyConfiguration, bool, TextBox>(args => args.IsConnected,
                    "Test test", "Something here");

                services.AddComponentConfigurationTemplate<SpotifyConfiguration, bool, ComboBox>(args => args.IsConnected,
                    "Test test2", "Something here2");

                services.AddComponentConfigurationTemplate<SpotifyConfiguration, bool, CalendarButton>(args => args.IsConnected,
                    "Test test2", "Something here2");
            });
}
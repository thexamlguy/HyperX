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
                services.AddTemplate<NowPlayingViewModel,
                    NowPlayingView>("NowPlaying");

                services.AddTemplate<AddConnectionViewModel,
                    AddConnectionView>("AddConnection");
            });

}
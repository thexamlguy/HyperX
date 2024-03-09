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

                services.AddTemplate<NowPlayingTrackViewModel,
                    NowPlayingTrackView>("NowPlayingTrack");

                services.AddTemplate<NowPlayingArtistViewModel,
                    NowPlayingArtistView>("NowPlayingArtist");

                services.AddTemplate<SkipPreviousButtonViewModel,
                    SkipPreviousButtonView>("SkipPreviousButton");

                services.AddTemplate<PlayPauseButtonViewModel,
                    PlayPauseButtonView>("PlayPauseButton");

                services.AddTemplate<SkipNextButtonViewModel,
                    SkipNextButtonView>("SkipNextButton");

                services.AddTemplate<AddConnectionViewModel,
                    AddConnectionView>("AddConnection");

                services.AddComponentConfigurationTemplate<SpotifyConfiguration, bool, ConnectionButtonView>(args => args.IsConnected, 
                    "Spotify Account",  "Connect to your Spotify account");
            });

}
using HyperX.Avalonia;
using Microsoft.Extensions.DependencyInjection;

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
                args.AuthenticationUrl = "https://accounts.spotify.com/authorize";
                args.AccountUrl = "https://accounts.spotify.com/api/";
                args.CallbackUrl = "http://localhost:5543/callback";
                args.ClientId = "f944e321fb164a2ba7f64d742e73dc6d";
                args.ClientSecret = "229e8651f62a4dec8487367a7cdf20c8";
                args.Port = 5543;
            })
            .AddServices(services =>
            {
                services.AddTransient<IChallengeFactory, ChallengeFactory>();
                services.AddTransient<IVerifierFactory, VerifierFactory>();

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
                    "Spotify Account", "Connect to your Spotify account");

                services.AddSpotify();
            });

}
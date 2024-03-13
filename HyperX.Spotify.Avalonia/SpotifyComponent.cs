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
                args.AccountUrl = "https://accounts.spotify.com";
                args.SpotifyUrl = "https://api.spotify.com/v1";
                args.CallbackUrl = "http://localhost:5543/callback";
                args.ClientId = "862fa42da60a46a680ebae98760b7025";
                args.ClientSecret = "f76db5cc126b43429bd6dd1306879d3f";
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

                services.AddTemplate<RemoveConnectionViewModel,
                    RemoveConnectionView>("RemoveConnection");

                services.AddComponentConfigurationTemplate<SpotifyConfiguration, bool, ConnectDescriptionView, 
                    ConnectView>(args => args.IsConnected, "Spotify Account");

                services.AddSpotify();
            });

}
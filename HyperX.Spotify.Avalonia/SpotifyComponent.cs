namespace HyperX.Spotify.Avalonia;

[ViewModelTemplateRoot("Spotify")]
public class SpotifyComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<SpotifyViewModel,
                    SpotifyView>("Spotify");
            });
}
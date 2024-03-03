﻿namespace HyperX.Spotify.Avalonia;

public class SpotifyComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        DictionaryStringObjectJsonConverter.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<SpotifyViewModel,
                    SpotifyView>("Spotify");
            });
}
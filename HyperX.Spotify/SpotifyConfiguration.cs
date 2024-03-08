namespace HyperX.Spotify;

public record SpotifyConfiguration : 
    ComponentConfiguration
{
    public bool IsConnected { get; set; }
}

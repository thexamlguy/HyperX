namespace HyperX.Spotify;

public record SpotifyConfiguration
{
    public int Port { get; set; }

    public string CallbackUrl { get; set; }
}

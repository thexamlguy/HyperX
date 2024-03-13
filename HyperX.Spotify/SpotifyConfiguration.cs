namespace HyperX.Spotify;

public record SpotifyConfiguration : 
    ComponentConfiguration
{
    public bool IsConnected { get; set; }

    public string ClientId { get; set; } = string.Empty;

    public string ClientSecret { get; set; } = string.Empty;

    public string CallbackUrl { get; set; } = string.Empty;

    public DateTimeOffset TokenExpiry { get; set; }

    public string Token { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public string AccountUrl { get; set; } = string.Empty;

    public string SpotifyUrl { get; set; } = string.Empty;

    public int Port { get; set; }
}
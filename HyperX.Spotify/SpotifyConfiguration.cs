using System.Diagnostics.CodeAnalysis;

namespace HyperX.Spotify;

public record SpotifyConfiguration : 
    ComponentConfiguration
{
    public bool IsConnected { get; set; }

    public string ClientId { get; set; } = string.Empty;

    public string ClientSecret { get; set; } = string.Empty;

    public string CallbackUrl { get; set; } = string.Empty;

    public string AuthenticationUrl { get; set; } = string.Empty;

    public string AccountUrl { get; set; } = string.Empty;

    public string SpotifyUrl { get; set; } = string.Empty;

    public int Port { get; set; }
}
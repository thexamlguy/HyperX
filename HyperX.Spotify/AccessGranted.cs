namespace HyperX.Spotify;

public record AccessGranted(string Token, string RefreshToken, DateTimeOffset TokenExpiry);

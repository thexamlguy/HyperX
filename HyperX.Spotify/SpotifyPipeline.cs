using EmbedIO.Authentication;
using System.Net.Http.Json;

namespace HyperX.Spotify;

public class SpotifyPipeline<TNotification>(IPublisher publisher,
    IHttpClientFactory httpClientFactory,
    SpotifyConfiguration configuration) :
    IPipelineBehavior<TNotification> where TNotification : ISpotify
{
    public async Task Handle(TNotification notification,
        NotificationHandlerDelegate<TNotification> next,
        CancellationToken cancellationToken = default)
    {
        if (DateTimeOffset.UtcNow >= configuration.TokenExpiry)
        {
            string refreshToken = configuration.RefreshToken;
            string clientId = configuration.ClientId;

            using HttpClient client = httpClientFactory.CreateClient("Account");
            HttpResponseMessage response = await client.PostAsync("/api/token", new FormUrlEncodedContent([
                new("grant_type", "refresh_token"),
                new("refresh_token", refreshToken),
                new("client_id", refreshToken)]),
                cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                if (await response.Content.ReadFromJsonAsync<AuthorizationCodeToken>(cancellationToken)
                    is AuthorizationCodeToken result)
                {
                    string accessToken = result.AccessToken;

                    DateTimeOffset expiry = DateTimeOffset.UtcNow.Add(TimeSpan.FromSeconds(result.ExpiresIn));
                    await publisher.Publish(Authentication.Create(new AccessGranted(accessToken, refreshToken, expiry)),
                        cancellationToken);
                }
            }
            else
            {
                await publisher.Publish(Authentication.Create<AccessRevoked>(), cancellationToken);
            }
        }
    }
}
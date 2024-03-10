using EmbedIO;
using EmbedIO.Actions;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace HyperX.Spotify;

public class AuthenticationHandler(IPublisher publisher,
    IVerifierFactory verifierFactory,
    IChallengeFactory challengeFactory,
    IHttpClientFactory httpClientFactory,
    SpotifyConfiguration configuration) :
    INotificationHandler<Authentication>
{
    public async Task Handle(Authentication args,
        CancellationToken cancellationToken = default)
    {
        TaskCompletionSource taskCompletionSource = new(cancellationToken);

        string scope = "user-read-private user-read-email";

        string verifier = verifierFactory.Create();
        string challenge = challengeFactory.Create(verifier);

        string hostName = Dns.GetHostName();
        IPAddress? host = Dns.GetHostAddresses(hostName).FirstOrDefault(x => x.AddressFamily is AddressFamily.InterNetwork);

        string callbackUrl = configuration.CallbackUrl;
        int port = configuration.Port;

        string callbackPath = Uri.TryCreate(configuration.CallbackUrl, UriKind.Absolute, out Uri? uri) && uri is not null ?
            uri.PathAndQuery : callbackUrl.StartsWith('/') ? configuration.CallbackUrl : $"/{callbackUrl}";

        callbackUrl = $"http://{host}:{port}{callbackPath}";

        string url = $"{configuration.AuthenticationUrl}?response_type=code&client_id={configuration.ClientId}&scope={scope}" +
            $"&redirect_uri={callbackUrl}&state={challenge}";

        await publisher.PublishAsync(Authentication.Create(url), 
            cancellationToken);

        using WebServer? server = new WebServer(configuration.Port)
            .WithModule(new ActionModule(callbackPath, HttpVerbs.Post, async args =>
        {
            NameValueCollection query = args.Request.QueryString;
            if (query["error"] is string error)
            {
                await publisher.PublishAsync(Authentication.Create(false),
                  cancellationToken);
            }
           
            if (query["request_type"] is string requestType)
            {
                if (requestType == "code")
                {
                    string state = query["state"]!;
                    string code = query["code"]!;

                    List<KeyValuePair<string?, string?>> post =
                    [
                        new("grant_type", "authorization_code"),
                        new("code", code),
                        new("redirect_uri", callbackUrl)
                    ];

                    using HttpClient client = httpClientFactory.CreateClient("Account");
                    HttpResponseMessage response = await client.PostAsync("token", new FormUrlEncodedContent([
                        new("grant_type", "authorization_code"),
                        new("code", code),
                        new("redirect_uri", callbackUrl)]));

                    if (response.IsSuccessStatusCode)
                    {
                        if (await response.Content.ReadFromJsonAsync<AuthorizationCodeToken>()
                            is AuthorizationCodeToken result)
                        {
                            await publisher.PublishAsync(Authentication.Create(true), 
                                cancellationToken);

                            await publisher.PublishAsync(Authentication.Create(new AccessToken(result.AccessToken, 
                                result.RefreshToken)), cancellationToken);
                        }
                    }
                }
            }
            
            taskCompletionSource.SetResult();
            await args.SendStringAsync("OK", "text/plain", Encoding.UTF8);

        })).WithEmbeddedResources(callbackPath, Assembly.GetExecutingAssembly(), "HyperX.Spotify.Assets.Authorization");

        server.Start(cancellationToken: cancellationToken);
        await taskCompletionSource.Task;
    }

    private class AuthorizationCodeToken
    {
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }
    }

}

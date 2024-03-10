using EmbedIO;
using EmbedIO.Actions;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace HyperX.Spotify;

public class AuthorizationHandler(IPublisher publisher,
    IVerifierFactory verifierFactory,
    IChallengeFactory challengeFactory,
    IHttpClientFactory httpClientFactory,
    SpotifyConfiguration configuration) :
    INotificationHandler<Request<Authorization>>
{
    public async Task Handle(Request<Authorization> args,
        CancellationToken cancellationToken = default)
    {
        TaskCompletionSource taskCompletionSource = new(cancellationToken);

        string scope = "user-read-private user-read-email";

        string verifier = verifierFactory.Create();
        string challenge = challengeFactory.Create(verifier);
        string? callback = configuration.CallbackUrl;

        string url = $"{configuration.AuthenticationUrl}?response_type=code&client_id={configuration.ClientId}&scope={scope}" +
            $"&redirect_uri={callback}&state={challenge}";

        Debug.WriteLine(url);

        await publisher.PublishAsync(new Response<Authorization>(new Authorization(url)), 
            cancellationToken);

        using WebServer? server = new WebServer(configuration.Port)
            .WithModule(new ActionModule("/callback", HttpVerbs.Post, async args =>
        {
            NameValueCollection query = args.Request.QueryString;
            if (query["error"] is string error)
            {

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
                        new("redirect_uri", callback)
                    ];

                    using HttpClient client = httpClientFactory.CreateClient("Account");
                    HttpResponseMessage response = await client.PostAsync("token", new FormUrlEncodedContent([
                        new("grant_type", "authorization_code"),
                        new("code", code),
                        new("redirect_uri", callback)]));

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        taskCompletionSource.SetResult();
                    }
                }
            }

            await args.SendStringAsync("OK", "text/plain", Encoding.UTF8);
        })).WithEmbeddedResources("/callback", Assembly.GetExecutingAssembly(), "HyperX.Spotify.Assets.Authorization");

        server.Start(cancellationToken: cancellationToken);
        await taskCompletionSource.Task;
    }
}
                  
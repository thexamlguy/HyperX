namespace HyperX.Spotify;

public class PauseHandler(IHttpClientFactory factory) :
    INotificationHandler<Request<Play>>
{
    public async Task Handle(Request<Play> args,
        CancellationToken cancellationToken = default)
    {
        if (factory.CreateClient("Spotify") is HttpClient client)
        {
            await client.PutAsync("/me/player/play", null, cancellationToken);
        }
    }
}
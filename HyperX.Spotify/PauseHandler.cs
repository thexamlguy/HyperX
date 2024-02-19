namespace HyperX.Spotify;

public class PauseHandler(IHttpClientFactory factory) :
    INotificationHandler<Spotify<Play>>
{
    public async Task Handle(Spotify<Play> args,
        CancellationToken cancellationToken = default)
    {
        if (factory.CreateClient("Spotify") is HttpClient client)
        {
            await client.PutAsync("/me/player/play", null, cancellationToken);
        }
    }
}
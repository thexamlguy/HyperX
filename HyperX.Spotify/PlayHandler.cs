namespace HyperX.Spotify;

public class PlayHandler(IHttpClientFactory factory, 
    IPublisher publisher) :
    INotificationHandler<Request<Play>>
{
    public async Task Handle(Request<Play> args,
        CancellationToken cancellationToken = default)
    {
        if (factory.CreateClient("Spotify") is HttpClient client)
        {
            HttpResponseMessage response = await client.PutAsync("/me/player/play", null, 
                cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                await publisher.PublishUIAsync(new Request<Playing>(), 
                    cancellationToken);
            }
        }
    }
}

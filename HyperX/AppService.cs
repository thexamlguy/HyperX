using Microsoft.Extensions.Hosting;

namespace HyperX;

public class AppService(IEnumerable<IInitializer> initializers,
    IPublisher publisher) :
    IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        foreach (IInitializer initializer in initializers)
        {
            await initializer.InitializeAsync();
        }

        await publisher.PublishAsync<Started>(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
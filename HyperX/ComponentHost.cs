using Microsoft.Extensions.Hosting;

namespace HyperX;

public sealed class ComponentHost(IServiceProvider services,
    IEnumerable<IInitializer> initializers,
    IEnumerable<IHostedService> hostedServices) :
    IComponentHost
{
    public IServiceProvider Services => services;

    public void Dispose()
    {

    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        foreach (IInitializer initializer in initializers)
        {
            await initializer.InitializeAsync();
        }

        foreach (IHostedService service in hostedServices)
        {
            await service.StartAsync(cancellationToken);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        foreach (IHostedService service in hostedServices)
        {
            await service.StopAsync(cancellationToken);
        }
    }
}

using EmbedIO;
using EmbedIO.Actions;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace HyperX.Spotify;

public class AuthenticationService(SpotifyConfiguration configuration) : 
    IHostedService
{
    private WebServer? server;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        server = new WebServer(configuration.Port)
              .WithModule(new ActionModule("/", HttpVerbs.Get, args =>
              {
                  return args.SendStringAsync("OK", "text/plain", Encoding.UTF8);
              }));

        await server.RunAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        server?.Dispose();
        return Task.CompletedTask;
    }
}

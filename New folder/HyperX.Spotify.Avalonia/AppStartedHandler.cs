using Avalonia;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using System.Threading;

namespace HyperX.Spotify.Avalonia;

public class AppStartedHandler(IPublisher publisher) : 
    INotificationHandler<Started>
{
    public async Task Handle(Started args, CancellationToken cancellationToken = default)
    {
        if (Application.Current is Application application)
        {
            if (application.ApplicationLifetime is IApplicationLifetime lifetime)
            {
                await publisher.PublishAsync(new Navigate(lifetime is IClassicDesktopStyleApplicationLifetime ? "Shell" : "Main", 
                    lifetime is IClassicDesktopStyleApplicationLifetime ? typeof(IClassicDesktopStyleApplicationLifetime) :
                    typeof(ISingleViewApplicationLifetime)), cancellationToken);
            }
        }
    }
}

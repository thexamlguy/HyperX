using System;
using System.Threading;
using System.Threading.Tasks;

namespace HyperX.Launcher.Avalonia;

public class TitleViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) : 
    ValueViewModel<string>(serviceProvider, serviceFactory, publisher, subscriber, disposer), 
    INotificationHandler<NavigationChanged<string>>
{
    public Task Handle(NavigationChanged<string> args,
        CancellationToken cancellationToken = default) => 
        Task.FromResult(Value = args.Value);
}

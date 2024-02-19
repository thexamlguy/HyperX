using System;
using System.Threading.Tasks;

namespace HyperX.Spotify.Avalonia;

public class ConnectViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    public override async Task InitializeAsync() => 
        await Publisher.PublishAsync<Spotify<Connect>>();
}
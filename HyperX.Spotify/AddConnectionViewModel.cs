using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Spotify;

public partial class AddConnectionViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) : ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer),
    INotificationHandler<Response<Authorization>>
{
    public override async Task InitializeAsync() => 
        await Publisher.PublishAsync(Request.Create<Authorization>());

    public Task Handle(Response<Authorization> args,
        CancellationToken cancellationToken = default) => 
            Task.FromResult(Code = args.Value?.Code);

    [ObservableProperty]
    private string? code;
}

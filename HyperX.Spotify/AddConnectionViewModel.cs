using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Spotify;

public partial class AddConnectionViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) : ObservableViewModel(serviceProvider, serviceFactory, publisher, subscriber, disposer),
    INotificationHandler<Authentication<string>>,
    INotificationHandler<Authentication<bool>>
{
    public override async Task Initialize() => 
        await Publisher.Publish(new Authentication());

    public Task Handle(Authentication<string> args,
        CancellationToken cancellationToken = default) => 
            Task.FromResult(Code = args.Value);

    public Task Handle(Authentication<bool> args, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [ObservableProperty]
    private string? code;
}

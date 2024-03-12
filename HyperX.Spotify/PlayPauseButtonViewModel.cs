namespace HyperX.Spotify;

public partial class PlayPauseButtonViewModel(IServiceProvider serviceProvider,
    IServiceFactory serviceFactory,
    IPublisher publisher,
    ISubscriber subscriber,
    IDisposer disposer) :
    CommandValueViewModel<bool>(serviceProvider, serviceFactory, publisher, subscriber, disposer)
{
    protected override async Task InvokeAsync() =>
        await Publisher.PublishUI(Spotify.Create<Play>());
}

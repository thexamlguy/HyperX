namespace HyperX.Spotify;

public partial class PlayPauseButtonViewModel :
    ObservableViewModel
{
    public PlayPauseButtonViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory, 
        IPublisher publisher, 
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
    }
}

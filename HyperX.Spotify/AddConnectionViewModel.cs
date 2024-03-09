using CommunityToolkit.Mvvm.ComponentModel;

namespace HyperX.Spotify;

public partial class AddConnectionViewModel :
    ObservableViewModel
{
    public AddConnectionViewModel(IServiceProvider serviceProvider,
        IServiceFactory serviceFactory,
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Code = "https://accounts.spotify.com/authorize?client_id=f944e321fb164a2ba7f64d742e73dc6d&response_type=code&redirect_uri=http%3a%2f%2flocalhost%3a5543%2fcallback&scope=user-read-email+user-read-private+user-read-playback-state+user-modify-playback-state+user-modify-playback-state+user-library-modify";
    }

    [ObservableProperty]
    private string code;
}

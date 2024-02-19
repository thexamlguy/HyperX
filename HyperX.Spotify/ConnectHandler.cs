namespace HyperX.Spotify;

public class ConnectHandler :
    INotificationHandler<Spotify<Connect>>
{
    public Task Handle(Spotify<Connect> args, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

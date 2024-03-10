namespace HyperX.Spotify;

public class ConnectHandler :
    INotificationHandler<Request<Connect>>
{
    public Task Handle(Request<Connect> args, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

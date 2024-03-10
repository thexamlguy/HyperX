namespace HyperX;

public record Request<TValue> : 
    INotification
{

}

public class Request
{
    public static Request<TValue> Create<TValue>() => new();
}
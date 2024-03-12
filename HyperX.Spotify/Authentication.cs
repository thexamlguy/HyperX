namespace HyperX.Spotify;

public record Authentication<TValue>(TValue Value) :
    INotification;

public record Authentication : 
    INotification
{
    public static Authentication<TValue> Create<TValue>(TValue value) => 
        new(value);

    public static Authentication<TValue> Create<TValue>() where TValue : new() =>
        new(new TValue());
}


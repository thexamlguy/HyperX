namespace HyperX.Spotify;

public record Spotify :
    INotification
{
    public static Spotify<TMessage> Create<TMessage>(TMessage message) =>
        new(message);

    public static Spotify<TMessage> Create<TMessage>() where TMessage : new() =>
        new(new TMessage());
}

public record Spotify<TMessage>(TMessage Message) :
    ISpotify<TMessage>;

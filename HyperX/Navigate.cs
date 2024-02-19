namespace HyperX;

public record Navigate(object Key, object? Context = null, string? Scope = null) :
    INotification;

public record Navigate<TNavigation>(object Context, object View, object ViewModel) :
    INotification;

namespace HyperX;

public record Navigate(object Name, 
    object? Context = null, 
    string? Scope = null, 
    object? Sender = null,
    object[]? Parameters = null) :
    INotification;

public record Navigate<TNavigation>(object Context, 
    object Template, 
    object Content,
    object? Sender = null,
    object[]? Parameters = null) :
    INotification;
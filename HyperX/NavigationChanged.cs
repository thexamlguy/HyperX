namespace HyperX;

public record NavigationChanged<TValue>(TValue? Value) : 
    INotification;
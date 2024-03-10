namespace HyperX;

public record Response<TValue>(TValue Value) :
    INotification;
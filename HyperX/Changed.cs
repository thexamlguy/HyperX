namespace HyperX;

public record Changed<TValue>(TValue? Value = default) : INotification;
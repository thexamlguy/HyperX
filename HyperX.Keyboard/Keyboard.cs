namespace HyperX.Keyboard;

public record Keyboard<TValue>(TValue Value) : INotification;

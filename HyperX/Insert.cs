namespace HyperX;

public record Insert<TValue>(int Index, TValue Value) : INotification;

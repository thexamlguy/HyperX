namespace HyperX;

public record Move<TValue>(int Index, TValue Value) : INotification;
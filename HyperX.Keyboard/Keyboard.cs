namespace HyperX.Keyboard;

public record Keyboard<TValue>(TValue? Value = default) : INotification;
public record Space;
public record Delete;

public record Previous;

public record Next;

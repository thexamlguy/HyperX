
namespace HyperX;

public record Create<TValue>(TValue Value, object? Target = null) :
    INotification;
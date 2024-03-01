
namespace HyperX;

public record Create<TValue>(TValue Value) :
    INotification;
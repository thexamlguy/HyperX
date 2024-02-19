
namespace HyperX;

public record Remove<TValue>(TValue Value) : 
    INotification;
namespace HyperX;

public interface IDispatcher
{
    Task InvokeAsync(Action action);
}

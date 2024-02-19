using Avalonia.Threading;

namespace HyperX.Avalonia;

public class AvaloniaDispatcher :
    IDispatcher
{
    public async Task InvokeAsync(Action action)
    {
        await Dispatcher.UIThread.InvokeAsync(action);
    }
}

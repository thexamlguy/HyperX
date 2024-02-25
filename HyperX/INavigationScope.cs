namespace HyperX;

public interface INavigationScope
{
    Task NavigateAsync(object name, object? sender, object? context,
        string? title = null, CancellationToken cancellationToken = default);

    Task NavigateBackAsync(object? context,
        CancellationToken cancellationToken = default);
}


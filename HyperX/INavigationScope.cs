namespace HyperX;

public interface INavigationScope
{
    Task NavigateAsync(string Route, object? sender, object? context,
        object[]? parameters = null, CancellationToken cancellationToken = default);

    Task NavigateBackAsync(object? context, CancellationToken cancellationToken = default);
}


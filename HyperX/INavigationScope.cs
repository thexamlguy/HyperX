namespace HyperX;

public interface INavigationScope
{
    Task NavigateAsync(object key, object? context,
        CancellationToken cancellationToken = default);
}


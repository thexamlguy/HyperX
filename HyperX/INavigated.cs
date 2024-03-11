namespace HyperX;

public interface INavigated
{
    Task NavigatedAsync();
}

public interface INavigated<TResult>
{
    Task NavigatedAsync(TResult result);
}
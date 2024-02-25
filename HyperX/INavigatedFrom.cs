namespace HyperX;

public interface INavigatedFrom
{
    Task NavigatedFromAsync();
}

public interface INavigatedFrom<TResult>
{
    Task NavigatedFromAsync(TResult result);
}

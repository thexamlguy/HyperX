namespace HyperX;

public interface INavigatedTo
{
    Task NavigatedToAsync();
}

public interface INavigatedTo<TResult>
{
    Task NavigatedToAsync(TResult result);
}
namespace HyperX;

public interface INavigatingFrom
{
    Task NavigatingFromAsync();
}

public interface INavigatingFrom<TResult> 
{
    Task<TResult> NavigatingFromAsync();
}
namespace HyperX;

public interface INavigatedFrom
{
    Task NavigatedFromAsync(INavigationParameters parameters);
}
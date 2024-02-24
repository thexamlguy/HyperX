namespace HyperX;

public interface INavigatedTo
{
    Task NavigatedToAsync(INavigationParameters parameters);
}

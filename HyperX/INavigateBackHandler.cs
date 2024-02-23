namespace HyperX;

public interface INavigateBackHandler<TNavigation> :
    INotificationHandler<NavigateBack<TNavigation>>,
    INavigateHandler;
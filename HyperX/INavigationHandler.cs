namespace HyperX;

public interface INavigationHandler;

public interface INavigationHandler<TNavigation> :
    INotificationHandler<Navigate<TNavigation>>,
    INavigationHandler;
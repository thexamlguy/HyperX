namespace HyperX;

public delegate Task NotificationHandlerDelegate<TNotification>(TNotification notification,
    CancellationToken cancellationToken)
    where TNotification : INotification;

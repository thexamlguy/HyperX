using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HyperX;

public class Publisher(ISubscriptionManager subscriptionManager,
    IServiceProvider provider,
    IDispatcher dispatcher) : 
    IPublisher
{
    public Task PublishAsync<TNotification>(object key,
        CancellationToken cancellationToken = default)
        where TNotification :
        INotification,
        new() => PublishAsync(new TNotification(), async args => await args(),
                key, cancellationToken);

    public Task PublishAsync<TNotification>(TNotification notification,
        CancellationToken cancellationToken = default)
        where TNotification :
        INotification => PublishAsync(notification, async args => await args(),
                null, cancellationToken);

    public Task PublishAsync<TNotification>(TNotification notification,
        object key,
        CancellationToken cancellationToken = default)
        where TNotification :
        INotification => PublishAsync(notification, 
            async args => await args(), key, cancellationToken);

    public Task PublishAsync(object notification,
        Func<Func<Task>, Task> marshal,
        object? key = null,
        CancellationToken cancellationToken = default)
    {
        Type notificationType = notification.GetType();
        List<object?> handlers = provider.GetServices(typeof(INotificationHandler<>)
            .MakeGenericType(notificationType)).ToList();

        foreach (object? handler in subscriptionManager
            .GetHandlers(notificationType, key!))
        {
            handlers.Add(handler);
        }

        foreach (object? handler in handlers)
        {
            if (handler is not null)
            {
                Type? handlerType = handler.GetType();
                MethodInfo? handleMethod = handlerType.GetMethod("Handle",
                    [notificationType, typeof(CancellationToken)]);

                if (handleMethod is not null)
                {
                    marshal(() => (Task)handleMethod.Invoke(handler, new object[]
                        { notification, cancellationToken })!);
                }
            }
        }

        return Task.CompletedTask;
    }

    public Task PublishAsync(object notification,
        CancellationToken cancellationToken = default) => PublishAsync(notification,
            async args => await args(),
                null, cancellationToken);

    public Task PublishAsync<TNotification>(CancellationToken cancellationToken = default) 
        where TNotification : 
        INotification, new() => PublishAsync(new TNotification(),
            async args => await args(),
                null, cancellationToken);

    public Task PublishUIAsync<TNotification>(object key,
        CancellationToken cancellationToken = default)
        where TNotification :
        INotification, new() => PublishAsync(new TNotification(), 
            args =>  dispatcher.InvokeAsync(async () => await args()),
                key, cancellationToken);

    public Task PublishUIAsync<TNotification>(TNotification notification,
        CancellationToken cancellationToken = default)
        where TNotification :
        INotification => PublishAsync(notification, 
            args => dispatcher.InvokeAsync(async () => await args()),
                null, cancellationToken);

    public Task PublishUIAsync<TNotification>(TNotification notification,
        object key,
        CancellationToken cancellationToken = default)
        where TNotification :
        INotification => PublishAsync(notification, 
            args => dispatcher.InvokeAsync(async () => await args()),
                key, cancellationToken);
    public Task PublishUIAsync<TNotification>(CancellationToken cancellationToken = default)
        where TNotification :
        INotification, new() => PublishAsync(new TNotification(), 
            args => dispatcher.InvokeAsync(async () => await args()),
                null, cancellationToken);

    public Task PublishUIAsync(object notification,
        CancellationToken cancellationToken = default) => PublishAsync(notification, args =>
            dispatcher.InvokeAsync(async () => await args()),
                null, cancellationToken);
}

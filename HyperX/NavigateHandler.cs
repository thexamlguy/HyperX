namespace HyperX;

public class NavigateHandler(INavigationScopeProvider provider) :
    INotificationHandler<Navigate>
{
    public async Task Handle(Navigate args, 
        CancellationToken cancellationToken)
    {
        if (provider.Get(args.Scope ?? "Default") 
            is INavigationScope scope)
        {
            await scope.NavigateAsync(args.Name, args.Sender,
                args.Context, cancellationToken);
        }
    }
}

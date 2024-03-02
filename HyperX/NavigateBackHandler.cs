namespace HyperX;

public class NavigateBackHandler(IComponentScopeProvider provider) :
    INotificationHandler<NavigateBack>
{
    public async Task Handle(NavigateBack args,
        CancellationToken cancellationToken)
    {
        if (provider.Get(args.Scope ?? "Default") is INavigationScope scope)
        {
            await scope.NavigateBackAsync(args.Context, cancellationToken);
        }
    }
}



using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public class NavigateHandler(IComponentScopeProvider provider) :
    INotificationHandler<Navigate>
{
    public async Task Handle(Navigate args, 
        CancellationToken cancellationToken)
    {
        if (provider.Get(args.Scope ?? "Default") 
            is IServiceProvider scope)
        {
            if (scope.GetService<INavigationScope>() is INavigationScope navigationScope)
            {
                await navigationScope.NavigateAsync(args.Name, args.Sender,
                    args.Context, args.Parameters, cancellationToken);
            }
        }
    }
}

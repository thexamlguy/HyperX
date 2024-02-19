using Avalonia.Controls.ApplicationLifetimes;

namespace HyperX.Avalonia;

public class SingleViewApplicationHandler :
    INavigationHandler<ISingleViewApplicationLifetime>
{
    public Task Handle(Navigate<ISingleViewApplicationLifetime> args,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
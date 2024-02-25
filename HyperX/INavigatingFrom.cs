
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace HyperX;

public interface INavigatingFrom
{
    Task NavigatingFromAsync();
}

public interface INavigatingFrom<TParameter>
{
    Task<TParameter> NavigatingFromAsync();
}

public record NavigatingFrom(object Content) :
    IRequest<object[]?>;

public class NavigatingFromHandler :
    IHandler<NavigatingFrom, object[]?>
{
    public Task<object[]?> Handle(NavigatingFrom args, 
        CancellationToken cancellationToken)
    {
        if (args.Content.GetType().GetInterfaces() is Type[] contracts)
        {
            foreach (Type contract in contracts)
            {
                if (contract.Name == typeof(INavigatingFrom<>).Name &&
                    contract.GetGenericArguments() is { Length: 1 })
                {
                    if (contract.GetMethod("NavigatingFromAsync") is MethodInfo handleMethod)
                    {

                    }
                }
            }
        }

        return Task.FromResult(default(object[]?));
    }
}
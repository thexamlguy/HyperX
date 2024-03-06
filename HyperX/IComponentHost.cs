using Microsoft.Extensions.Hosting;

namespace HyperX;

public interface IComponentHost : 
    IHost
{
    ComponentConfiguration? Configuration { get; }
}
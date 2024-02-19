
using Microsoft.Extensions.Hosting;

namespace HyperX;

public interface IConfigurationMonitor<TConfiguration> : 
    IHostedService
    where TConfiguration :
    class;
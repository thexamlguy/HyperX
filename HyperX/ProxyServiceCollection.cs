﻿using Microsoft.Extensions.DependencyInjection;

namespace HyperX;

public class ProxyServiceCollection<T> :
    IProxyServiceCollection<T>
{
    public ProxyServiceCollection(Action<IServiceCollection> configureDelegate)
    {
        Services = new ServiceCollection();
        configureDelegate.Invoke(Services);
    }

    public IServiceCollection Services { get; private set; }
}
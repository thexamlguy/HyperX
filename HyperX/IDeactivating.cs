﻿namespace HyperX;

public interface IDeactivating
{
    Task Deactivating();
}

public interface IDeactivating<TResult> 
{
    Task<TResult> Deactivating();
}
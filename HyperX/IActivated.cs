﻿namespace HyperX;

public interface IActivated
{
    Task Activated();
}

public interface IActivated<TResult>
{
    Task Activated(TResult result);
}
﻿namespace HyperX;

public interface INavigationContextProvider
{
    object? Get(object key);

    bool TryGet(object key, 
        out object? value);
}
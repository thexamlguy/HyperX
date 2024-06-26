﻿namespace HyperX;

public interface IComponentHostCollection :
    IEnumerable<IComponentHost>
{
    void Add(IComponentHost host);
}
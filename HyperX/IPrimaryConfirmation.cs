﻿namespace HyperX;

public interface IPrimaryConfirmation
{
    Task<bool> Confirm();
}

public interface IConfirmation
{
    Task<bool> Confirm();
}


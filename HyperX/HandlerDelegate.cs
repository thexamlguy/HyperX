﻿namespace HyperX;

public delegate Task<TResponse> HandlerDelegate<TMessage, TResponse>(TMessage message,
    CancellationToken cancellationToken)
    where TMessage : IMessage;
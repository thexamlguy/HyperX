namespace HyperX;

public interface IRequest<out TResponse> : 
    IMessage;

public interface IRequest : IRequest<Unit>;
namespace HyperX;

public record KeyAccelerator(VirtualKey Key,
    VirtualKey[]? Modifiers = null) :
    IRequest;

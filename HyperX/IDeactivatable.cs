namespace HyperX;

public interface IDeactivatable
{
    public event EventHandler? DeactivateHandler;

    public Task Deactivate();
}
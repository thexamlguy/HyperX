namespace HyperX;

public interface ISecondaryConfirmation
{
    Task<bool> Confirm();
}
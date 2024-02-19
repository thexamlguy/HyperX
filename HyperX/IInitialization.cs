using System.Windows.Input;

namespace HyperX;

public interface IInitialization
{
    ICommand InitializeCommand { get; }

    Task InitializeAsync();
}

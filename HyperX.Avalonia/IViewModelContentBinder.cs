using Avalonia.Controls.Primitives;

namespace HyperX.Avalonia;

public interface IViewModelContentBinder
{
    void Bind(TemplatedControl view);
}
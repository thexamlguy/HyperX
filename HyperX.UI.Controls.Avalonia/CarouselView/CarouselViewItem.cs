using Avalonia.Controls;

namespace HyperX.UI.Controls.Avalonia;

public class CarouselViewItem :
    ContentControl
{
    internal void SetSelected(bool selected)
    {
        PseudoClasses.Set(":selected", selected);
    }
}

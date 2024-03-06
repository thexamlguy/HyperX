using Avalonia.Xaml.Interactivity;

namespace HyperX.UI.Avalonia;

public class AttachedBehavior : Trigger
{
    protected override void OnAttachedToVisualTree()
    {
        Interaction.ExecuteActions(AssociatedObject, Actions, null);
        base.OnAttachedToVisualTree();
    }
}

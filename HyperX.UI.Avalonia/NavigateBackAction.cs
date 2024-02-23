using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Xaml.Interactivity;

namespace HyperX.UI.Avalonia;

public class NavigateBackAction :
    AvaloniaObject,
    IAction
{
    public static readonly StyledProperty<string> ContextProperty =
        AvaloniaProperty.Register<NavigateBackAction, string>(nameof(Context));

    public static readonly StyledProperty<string> ScopeProperty =
        AvaloniaProperty.Register<NavigateBackAction, string>(nameof(Scope));

    public string Context
    {
        get => GetValue(ContextProperty);
        set => SetValue(ContextProperty, value);
    }

    public string Scope
    {
        get => GetValue(ScopeProperty);
        set => SetValue(ScopeProperty, value);
    }

    public object Execute(object? sender,
        object? parameter)
    {
        if (sender is TemplatedControl control)
        {
            if (control.DataContext is IObservableViewModel observableViewModel)
            {
                observableViewModel.Publisher.PublishAsync(new NavigateBack(Context
                    ?? null, Scope ?? null)).GetAwaiter().GetResult();
            }
        }

        return true;
    }
}

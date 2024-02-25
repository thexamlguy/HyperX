using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Xaml.Interactivity;

namespace HyperX.UI.Avalonia;

public class NavigateAction :
    AvaloniaObject,
    IAction
{
    public static readonly StyledProperty<string> ContextProperty =
        AvaloniaProperty.Register<NavigateAction, string>(nameof(Context));

    public static readonly StyledProperty<string> NameProperty =
        AvaloniaProperty.Register<NavigateAction, string>(nameof(Name));

    public static readonly StyledProperty<string> ScopeProperty =
        AvaloniaProperty.Register<NavigateAction, string>(nameof(Scope));

    public string Context
    {
        get => GetValue(ContextProperty);
        set => SetValue(ContextProperty, value);
    }

    public string Name
    {
        get => GetValue(NameProperty);
        set => SetValue(NameProperty, value);
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
                observableViewModel.Publisher.PublishAsync(new Navigate(Name, Context 
                    ?? null, Scope ?? null, control.DataContext)).GetAwaiter().GetResult();
            }
        }

        return true;
    }
}

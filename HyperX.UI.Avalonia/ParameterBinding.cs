using Avalonia;

namespace HyperX.UI.Avalonia;

public class ParameterBinding :
    AvaloniaObject
{
    public static readonly StyledProperty<object> ContextProperty =
        AvaloniaProperty.Register<ParameterBinding, object>(nameof(Key));

    public static readonly StyledProperty<object> ValueProperty =
        AvaloniaProperty.Register<ParameterBinding, object>(nameof(Value));

    public object Key
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public object Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}

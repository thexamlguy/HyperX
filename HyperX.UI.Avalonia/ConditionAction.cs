using Avalonia;
using Avalonia.Metadata;
using Avalonia.Xaml.Interactivity;

namespace HyperX.UI.Avalonia;

public class ConditionAction : 
    AvaloniaObject,
    IAction
{
    public static readonly StyledProperty<ICondition> ConditionProperty =
        AvaloniaProperty.Register<ConditionAction, ICondition>(nameof(Condition));

    public static readonly StyledProperty<ActionCollection> ActionsProperty =
        AvaloniaProperty.Register<ConditionAction, ActionCollection>(nameof(Actions));

    private ActionCollection? _actions;

    [Content]
    public ActionCollection Actions
    {
        get => GetValue(ActionsProperty);
        set => SetValue(ActionsProperty, value);
    }

    public ICondition Condition
    {
        get => GetValue(ConditionProperty);
        set => SetValue(ConditionProperty, value);
    }

    public object? Execute(object? sender, object? parameter)
    {
        Condition?.Evaluate();

        throw new NotImplementedException();
    }
}
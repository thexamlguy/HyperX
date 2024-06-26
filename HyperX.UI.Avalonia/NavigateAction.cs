﻿using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Metadata;
using Avalonia.Xaml.Interactivity;

namespace HyperX.UI.Avalonia;

public class NavigateAction :
    AvaloniaObject,
    IAction
{
    public static readonly StyledProperty<object> ContextProperty =
        AvaloniaProperty.Register<NavigateAction, object>(nameof(Context));

    public static readonly StyledProperty<string> RouteProperty =
        AvaloniaProperty.Register<NavigateAction, string>(nameof(Route));

    public static readonly DirectProperty<NavigateAction, ParameterBindingCollection> ParameterBindingsProperty =
        AvaloniaProperty.RegisterDirect<NavigateAction, ParameterBindingCollection>(nameof(ParameterBindings),
            x => x.ParameterBindings);

    public static readonly StyledProperty<object[]?> ParametersProperty =
        AvaloniaProperty.Register<NavigateAction, object[]?>(nameof(Parameters));

    public static readonly StyledProperty<string> ScopeProperty =
        AvaloniaProperty.Register<NavigateAction, string>(nameof(Scope));

    private ParameterBindingCollection parameterCollection = [];

    public event EventHandler? Navigated;

    public object Context
    {
        get => GetValue(ContextProperty);
        set => SetValue(ContextProperty, value);
    }

    public string Route
    {
        get => GetValue(RouteProperty);
        set => SetValue(RouteProperty, value);
    }

    [Content]
    public ParameterBindingCollection ParameterBindings => 
        parameterCollection ??= [];

    public object[]? Parameters
    {
        get => GetValue(ParametersProperty);
        set => SetValue(ParametersProperty, value);
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
            Dictionary<string, object> arguments = 
                new(StringComparer.InvariantCultureIgnoreCase);

            if (control.DataContext is IObservableViewModel observableViewModel)
            {
                object[] parameters = [.. Parameters ?? Enumerable.Empty<object?>(), ..
                    ParameterBindings is { Count: > 0 } ?
                    ParameterBindings.Select(binding => new KeyValuePair<string, object>(binding.Key, binding.Value)).ToArray() :
                    Enumerable.Empty<KeyValuePair<string, object>>()];

                observableViewModel.Publisher.Publish(new Navigate(Route, Context
                    ?? null, Scope ?? null, control.DataContext, Navigated, parameters));
            }
        }

        return true;
    }
}

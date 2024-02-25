﻿namespace HyperX;

public record Navigate(object Name, 
    object? Context = null, 
    string? Scope = null, 
    object? Sender = null) :
    INotification;

public record Navigate<TNavigation>(object Context, 
    object View, 
    object ViewModel,
    object? Sender = null) :
    INotification;

public record NavigationChanged<TValue>(string Value) : INotification;
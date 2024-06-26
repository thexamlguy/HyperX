﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace HyperX.Avalonia;

public class ClassicDesktopStyleApplicationHandler(INavigationContext navigationContext) :
    INavigateHandler<IClassicDesktopStyleApplicationLifetime>
{
    public Task Handle(Navigate<IClassicDesktopStyleApplicationLifetime> args,
        CancellationToken cancellationToken = default)
    {
        if (Application.Current?.ApplicationLifetime is 
            IClassicDesktopStyleApplicationLifetime lifeTime)
        {
            if (args.Template is Window window)
            {
                lifeTime.MainWindow = window;
                window.DataContext = args.Content;

                navigationContext.Set(window);
            }
        }

        return Task.CompletedTask;
    }
}
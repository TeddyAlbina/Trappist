﻿using System.Diagnostics.CodeAnalysis;
using System.Windows;

using InGroupe.Innovation.Wpf.Bedrock.Abstractions;
using InGroupe.Innovation.Wpf.Bedrock.Navigation;

namespace InGroupe.Innovation.Wpf.Bedrock;

internal static class ModalViewModelBinder
{
    internal static void Bind([DisallowNull] object view, [AllowNull] object? viewModel)
    {
        if (view is FrameworkElement element)
        {
            CurrentModalNavigationState.Update(view, viewModel);

            if (viewModel is not null)
            {
                element.DataContext = viewModel;
            }

            if (view is IDataContextAware dataContextAware)
            {
                _ = Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    dataContextAware.DataContextWireUp();
                }, System.Windows.Threading.DispatcherPriority.Render);
            }

            if (element.DataContext is INavigationAware navigationAware)
            {
                navigationAware.NavigateTo(NavigationParameters.Instance);
            }
        }
    }

    internal static void NavigateFromPreviousView()
    {
        if (CurrentModalNavigationState.CurrentView is FrameworkElement element && element.DataContext is INavigationAware navigationAware)
        {
            navigationAware.NavigateFrom(NavigationParameters.Instance);
        }

        CurrentModalNavigationState.Update(null, null);
    }
}
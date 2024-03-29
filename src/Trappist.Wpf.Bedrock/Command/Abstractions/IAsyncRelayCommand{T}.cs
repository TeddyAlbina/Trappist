﻿using System.Threading.Tasks;

namespace Trappist.Wpf.Bedrock.Command.Abstractions;

/// <summary>
/// A generic interface representing a more specific version of <see cref="IAsyncRelayCommand"/>.
/// </summary>
/// <typeparam name="T">The type used as argument for the interface methods.</typeparam>
/// <remarks>This interface is needed to solve the diamond problem with base classes.</remarks>
public interface IAsyncRelayCommand<in T> : IAsyncRelayCommand, IRelayCommand<T>
{
    /// <summary>
    /// Provides a strongly-typed variant of <see cref="IAsyncRelayCommand.ExecuteAsync"/>.
    /// </summary>
    /// <param name="parameter">The input parameter.</param>
    /// <returns>The <see cref="Task"/> representing the async operation being executed.</returns>
    Task ExecuteAsync(T? parameter);
}

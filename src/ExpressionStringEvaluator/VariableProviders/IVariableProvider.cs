namespace ExpressionStringEvaluator.VariableProviders;

using System.Collections.Generic;

public interface IVariableProvider
{
    /// <summary>
    /// CanProvide.
    /// </summary>
    /// <param name="key">key.</param>
    /// <returns>bool.</returns>
    bool CanProvide(string key);

    /// <summary>
    /// Provide.
    /// </summary>
    /// <param name="key">key.</param>
    /// <param name="arg">arguments.</param>
    /// <returns>variable value.</returns>
    string? Provide(string key, string? arg);

    /// <summary>
    /// Get description.
    /// </summary>
    /// <returns>descriptions.</returns>
    IEnumerable<VariableDescription> Get();
}

/// <summary>
/// IVariableProvider.
/// </summary>
public interface IVariableProvider<T> : IVariableProvider
{
    /// <summary>
    /// Provide.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="key">key.</param>
    /// <param name="arg">arguments.</param>
    /// <returns>variable value.</returns>
    string? Provide(T context, string key, string? arg);
}
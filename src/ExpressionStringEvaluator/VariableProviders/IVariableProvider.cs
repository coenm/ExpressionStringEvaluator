namespace ExpressionStringEvaluator.VariableProviders;

/// <summary>
/// IVariableProvider.
/// </summary>
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
    object? Provide(string key, string? arg);
}

/// <summary>
/// Typed IVariableProvider.
/// </summary>
/// <typeparam name="T">Context type.</typeparam>
public interface IVariableProvider<in T> : IVariableProvider
{
    /// <summary>
    /// Provide.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="key">key.</param>
    /// <param name="arg">arguments.</param>
    /// <returns>variable value.</returns>
    object? Provide(T context, string key, string? arg);
}
namespace ExpressionStringEvaluator.VariableProviders;

using System;
using ExpressionStringEvaluator.Methods;

/// <inheritdoc cref="IVariableProvider"/>
public class BackslashVariableProvider : IVariableProvider
{
    private const string KEY = "backslash";

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public CombinedTypeContainer? Provide(string key, string? arg)
    {
        return new CombinedTypeContainer("\\");
    }
}
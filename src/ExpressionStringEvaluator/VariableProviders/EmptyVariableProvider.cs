namespace ExpressionStringEvaluator.VariableProviders;

using System;
using System.Collections.Generic;
using ExpressionStringEvaluator.Methods;

/// <inheritdoc cref="IVariableProvider"/>
public class EmptyVariableProvider : IVariableProvider
{
    private const string KEY = "empty";

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public CombinedTypeContainer? Provide(string key, string? arg)
    {
        return new CombinedTypeContainer(string.Empty);
    }
}
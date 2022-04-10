namespace ExpressionStringEvaluator.VariableProviders;

using System;
using System.Collections.Generic;

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
    public string? Provide(string key, string? arg)
    {
        return string.Empty;
    }
}
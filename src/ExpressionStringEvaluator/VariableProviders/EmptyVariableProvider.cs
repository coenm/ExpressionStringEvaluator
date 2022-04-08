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
    public string? Provide(Context context, string key, string? arg)
    {
        return string.Empty;
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, "Empty string.");
    }
}
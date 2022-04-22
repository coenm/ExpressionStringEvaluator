namespace ExpressionStringEvaluator.VariableProviders;

using System;

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
    public string? Provide(string key, string? arg)
    {
        return "\\";
    }
}
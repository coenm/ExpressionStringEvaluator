namespace ExpressionStringEvaluator.VariableProviders;

using System;
using System.IO;

/// <inheritdoc cref="IVariableProvider"/>
public class PathSeparatorVariableProvider : IVariableProvider
{
    private const string KEY = "PathSeparator";
    private static readonly string? _pathSeparator = new (Path.DirectorySeparatorChar, 1);

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public object? Provide(string key, string? arg)
    {
        return _pathSeparator;
    }
}
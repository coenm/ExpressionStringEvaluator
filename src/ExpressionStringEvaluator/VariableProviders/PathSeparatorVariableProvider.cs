namespace ExpressionStringEvaluator.VariableProviders;

using System;
using System.Collections.Generic;
using System.IO;

/// <inheritdoc cref="IVariableProvider"/>
public class PathSeparatorVariableProvider : IVariableProvider
{
    private const string KEY = "PathSeparator";
    private static readonly string _pathSeparator = new string(Path.DirectorySeparatorChar, 1);

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public string? Provide(Context context, string key, string? arg)
    {
        return _pathSeparator;
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, $"Path separator. Current value is '{_pathSeparator}'.");
    }
}
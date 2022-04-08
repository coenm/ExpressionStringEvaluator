namespace ExpressionStringEvaluator.VariableProviders.FileInfo;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="IVariableProvider"/>
public class FilenameVariableProvider : IVariableProvider
{
    private const string KEY = "Filename";

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public string? Provide(Context context, string key, string? arg)
    {
        return context.FileInfo.Name;
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, "Filename of the input file (without the path).");
    }
}
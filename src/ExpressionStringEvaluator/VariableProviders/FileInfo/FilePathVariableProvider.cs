namespace ExpressionStringEvaluator.VariableProviders.FileInfo;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="IVariableProvider"/>
public class FilePathVariableProvider : IVariableProvider
{
    private const string KEY = "FilePath";

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public string? Provide(Context context, string key, string? arg)
    {
        return context.FileInfo.DirectoryName;
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, "File path of the input file.");
    }
}
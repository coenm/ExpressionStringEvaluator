namespace ExpressionStringEvaluator.VariableProviders.FileInfo;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="IVariableProvider"/>
public class FileExtensionVariableProvider : IVariableProvider
{
    private const string KEY = "FileExtension";

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public string? Provide(Context context, string key, string? arg)
    {
        return context.FileInfo.Extension;
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, "Extension (including the . (dot)) of the input file.");
    }
}
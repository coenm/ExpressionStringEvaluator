namespace ExpressionStringEvaluator.VariableProviders.FileInfo;

using System;
using System.Collections.Generic;
using System.IO;

/// <inheritdoc cref="IVariableProvider"/>
public class FilenameBaseVariableProvider : IVariableProvider
{
    private const string KEY = "FilenameBase";

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public string? Provide(Context context, string key, string? arg)
    {
        return Path.GetFileNameWithoutExtension(context.FileInfo.FullName);
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, "Filename of the input file without the extension.");
    }
}
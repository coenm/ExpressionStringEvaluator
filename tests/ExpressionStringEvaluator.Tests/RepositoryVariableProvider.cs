namespace ExpressionStringEvaluator.Tests;

using System;
using ExpressionStringEvaluator.VariableProviders;

public class RepositoryVariableProvider : IVariableProvider<Repository>
{
    public bool CanProvide(string key)
    {
        return !string.IsNullOrWhiteSpace(key) && key.StartsWith("Repository.", StringComparison.CurrentCultureIgnoreCase);
    }

    public object? Provide(Repository context, string key, string? arg)
    {
        var result = ProvideInner(context, key);
        return result;
    }

    public object? Provide(string key, string? arg)
    {
        throw new NotImplementedException();
    }

    private static string? ProvideInner(Repository context, string key)
    {
        var startIndex = "Repository.".Length;
        var k = key[startIndex..];

        if ("Name".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.Name;
        }

        if ("Path".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.Path;
        }

        if ("SafePath".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.SafePath;
        }

        if ("Location".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.Location;
        }

        if ("CurrentBranch".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.CurrentBranch;
        }

        if ("Branches".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return string.Join("|", context.Branches ?? Array.Empty<string>());
        }

        if ("LocalBranches".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return string.Join("|", context.LocalBranches ?? Array.Empty<string>());
        }

        if ("RemoteUrls".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return string.Join("|", context.RemoteUrls ?? Array.Empty<string>());
        }

        throw new NotImplementedException();
    }
}
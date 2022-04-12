namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;

/// <summary>
/// StringTrimStartStringMethod.
/// </summary>
public class StringTrimStartStringMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "TrimStart");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        var stringValue = ExpectSingleString(args);
        return new CombinedTypeContainer(stringValue.TrimStart());
    }
}
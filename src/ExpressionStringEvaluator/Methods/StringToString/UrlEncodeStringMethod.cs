namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;
using System.Web;

/// <summary>
/// UrlEncodeStringMethod.
/// </summary>
public class UrlEncodeStringMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "UrlEncode");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        var stringValue = ExpectSingleString(args);
        return new CombinedTypeContainer(HttpUtility.UrlEncode(stringValue));
    }
}
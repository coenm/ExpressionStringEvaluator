namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;
using System.Web;

/// <summary>
/// UrlEncodeStringMethod.
/// </summary>
public class UrlEncodeStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "UrlEncode", "HttpUtility.UrlEncode");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return new CombinedTypeContainer(HttpUtility.UrlEncode(stringValue));
    }
}
namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;
using System.Web;

/// <summary>
/// UrlDecodeStringMethod.
/// </summary>
public class UrlDecodeStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodBase.IsMethod(method, "UrlDecode");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        var stringValue = MethodBase.ExpectSingleString(args);
        return new CombinedTypeContainer(HttpUtility.UrlDecode(stringValue));
    }
}
namespace ExpressionStringEvaluator.Methods.StringToString;

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
    public object? Handle(string method, params object?[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return HttpUtility.UrlEncode(stringValue);
    }
}
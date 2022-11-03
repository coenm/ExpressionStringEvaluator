namespace ExpressionStringEvaluator.Methods.StringToString;

using System.Web;

/// <summary>
/// UrlDecodeStringMethod.
/// </summary>
public class UrlDecodeStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "UrlDecode", "HttpUtility.UrlDecode");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return HttpUtility.UrlDecode(stringValue);
    }
}
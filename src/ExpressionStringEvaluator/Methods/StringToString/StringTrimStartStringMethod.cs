namespace ExpressionStringEvaluator.Methods.StringToString;

/// <summary>
/// StringTrimStartStringMethod.
/// </summary>
public class StringTrimStartStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "TrimStart");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return stringValue.TrimStart();
    }
}
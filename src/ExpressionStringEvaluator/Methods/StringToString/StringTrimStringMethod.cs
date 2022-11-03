namespace ExpressionStringEvaluator.Methods.StringToString;

/// <summary>
/// StringTrimStringMethod.
/// </summary>
public class StringTrimStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Trim");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return stringValue.Trim();
    }
}
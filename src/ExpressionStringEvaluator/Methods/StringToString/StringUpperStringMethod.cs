namespace ExpressionStringEvaluator.Methods.StringToString;

/// <summary>
/// StringUpperStringMethod.
/// </summary>
public class StringUpperStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Upper");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return stringValue.ToUpper();
    }
}
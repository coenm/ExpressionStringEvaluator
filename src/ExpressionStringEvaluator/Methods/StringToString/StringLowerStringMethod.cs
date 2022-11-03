namespace ExpressionStringEvaluator.Methods.StringToString;

/// <summary>
/// StringLowerStringMethod.
/// </summary>
public class StringLowerStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Lower", "ToLower");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return stringValue.ToLower();
    }
}
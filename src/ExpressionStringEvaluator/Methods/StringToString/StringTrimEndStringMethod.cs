namespace ExpressionStringEvaluator.Methods.StringToString;

/// <summary>
/// StringTrimEndStringMethod.
/// </summary>
public class StringTrimEndStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "TrimEnd");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return stringValue.TrimEnd();
    }
}
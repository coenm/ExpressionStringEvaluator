namespace ExpressionStringEvaluator.Methods.StringToInt;

/// <summary>
/// StringLengthMethod.
/// </summary>
public class StringLengthMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "length");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        var stringValue = MethodHelpers.ExpectString(args[0]);
        return stringValue.Length;
    }
}
namespace ExpressionStringEvaluator.Methods.StringToBoolean;

/// <summary>
/// StringIsNullOrEmptyBooleanMethod.
/// </summary>
public class StringIsNullOrEmptyBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "IsNullOrEmpty", "string.IsNullOrEmpty");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        var stringValue = MethodHelpers.ExpectString(args[0]);
        return string.IsNullOrEmpty(stringValue);
    }
}
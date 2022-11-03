namespace ExpressionStringEvaluator.Methods.StringToBoolean;

/// <summary>
/// StringContainsStringMethod.
/// </summary>
public class StringContainsStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "StringContains");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);

        var strings = MethodHelpers.ExpectStrings(args);
        return strings[0].Contains(strings[1]);
    }
}
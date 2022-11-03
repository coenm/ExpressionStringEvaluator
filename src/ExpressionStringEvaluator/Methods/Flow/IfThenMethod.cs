namespace ExpressionStringEvaluator.Methods.Flow;

/// <summary>
/// IfThenMethod.
/// </summary>
public class IfThenMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "ifthen");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        bool b = MethodHelpers.ExpectBooleanOrBooleanString(args[0]);
        MethodHelpers.ExpectNotNull(args);
        return b ? args[1] : null;
    }
}
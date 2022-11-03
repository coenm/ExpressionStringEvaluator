namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

/// <summary>
/// OrBooleanMethod.
/// </summary>
public class OrBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Or", "Any");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectAtLeastArgumentCount(1, args);

        foreach (var item in args)
        {
            if (MethodHelpers.IsBooleanOrBooleanString(item, out var b) && b.Value)
            {
                return true;
            }
        }

        return false;
    }
}
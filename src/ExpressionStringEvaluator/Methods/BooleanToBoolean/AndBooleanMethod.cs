namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

/// <summary>
/// AndBooleanMethod.
/// </summary>
public class AndBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "And", "All");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectAtLeastArgumentCount(1, args);

        foreach (object? item in args)
        {
            if (item == null)
            {
                return false;
            }

            if (!MethodHelpers.IsBooleanOrBooleanString(item, out var b))
            {
                return false;
            }

            if (!b.Value)
            {
                return false;
            }
        }

        return true;
    }
}
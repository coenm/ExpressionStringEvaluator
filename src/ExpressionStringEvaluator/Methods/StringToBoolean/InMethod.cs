namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;

/// <summary>
/// In Methods.
/// </summary>
public class InMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "In");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        var count = MethodHelpers.ExpectAtLeastArgumentCount(2, args);

        var firstValue = args[0];
        if (firstValue == null)
        {
            throw new Exception("value cannot be null.");
        }

        for (var i = 1; i < count; i++)
        {
            if (args[i] != null && firstValue.Equals(args[i]))
            {
                return true;
            }
        }

        return false;
    }
}
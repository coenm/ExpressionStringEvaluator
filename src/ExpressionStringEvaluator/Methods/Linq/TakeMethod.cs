namespace ExpressionStringEvaluator.Methods.Linq;

using System;
using System.Linq;

/// <summary>
/// SkipMethod.
/// </summary>
public class TakeMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Take");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        object? values = args[0];
        var take = MethodHelpers.ExpectIntegerOrIntegerString(args[1]);

        if (values == null)
        {
            throw new Exception("Cannot take on null");
        }

        if (values is Array array)
        {
            return ((object[])array).Take(take).ToArray();
        }

        // or should this throw?
        throw new Exception($"Cannot take on non array {values.GetType().Name}");
    }
}
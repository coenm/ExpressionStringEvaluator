namespace ExpressionStringEvaluator.Methods.Linq;

using System;
using System.Linq;

/// <summary>
/// SkipMethod.
/// </summary>
public class SkipMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Skip");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        object? values = args[0];
        var skip = MethodHelpers.ExpectIntegerOrIntegerString(args[1]);

        if (values == null)
        {
            throw new Exception("Cannot skip on null");
        }

        if (values is Array array)
        {
            return ((object[])array).Skip(skip).ToArray();
        }

        // or should this throw?
        throw new Exception($"Cannot skip on non array {values.GetType().Name}");
    }
}
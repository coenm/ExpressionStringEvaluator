namespace ExpressionStringEvaluator.Methods.Flow;

using System;
using System.Linq;

/// <summary>
/// IfThenElseMethod.
/// </summary>
public class IfThenElseMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "ifthenelse");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(3, args);
        var b = MethodHelpers.ExpectBooleanOrBooleanString(args[0]);
        MethodHelpers.ExpectNotNull(args);
        return b ? args[1] : args[2];
    }
}
namespace ExpressionStringEvaluator.Methods.Flow;

using System;
using System.Linq;

/// <summary>
/// IfThenElseMethod.
/// </summary>
public class IfThenElseMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "ifthenelse");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(3, args);
        var b = ExpectBoolean(args[0]);
        ExpectNotNull(args);
        return b ? args[1] : args[2];
    }
}
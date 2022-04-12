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
        return MethodBase.IsMethod(method, "ifthenelse");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodBase.ExpectArgumentCount(3, args);
        var b = MethodBase.ExpectBoolean(args[0]);
        MethodBase.ExpectNotNull(args);
        return b ? args[1] : args[2];
    }
}
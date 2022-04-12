namespace ExpressionStringEvaluator.Methods.Flow;

using System;
using System.Linq;

/// <summary>
/// IfThenMethod.
/// </summary>
public class IfThenMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodBase.IsMethod(method, "ifthen");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodBase.ExpectArgumentCount(2, args);
        bool b = MethodBase.ExpectBoolean(args[0]);
        MethodBase.ExpectNotNull(args);
        return b ? args[1] : CombinedTypeContainer.NullInstance;
    }
}
namespace ExpressionStringEvaluator.Methods.Flow;

using System;
using System.Linq;

/// <summary>
/// IfThenMethod.
/// </summary>
public class IfThenMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "ifthen");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(2, args);
        bool b = ExpectBoolean(args[0]);
        ExpectNotNull(args);
        return b ? args[1] : CombinedTypeContainer.NullInstance;
    }
}
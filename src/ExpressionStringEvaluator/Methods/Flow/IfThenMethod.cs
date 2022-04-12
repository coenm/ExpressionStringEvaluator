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
        return MethodHelpers.IsMethod(method, "ifthen");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        bool b = MethodHelpers.ExpectBoolean(args[0]);
        MethodHelpers.ExpectNotNull(args);
        return b ? args[1] : CombinedTypeContainer.NullInstance;
    }
}
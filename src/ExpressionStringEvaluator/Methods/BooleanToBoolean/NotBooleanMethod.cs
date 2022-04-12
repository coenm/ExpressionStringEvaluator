namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

using System;
using System.Linq;

/// <summary>
/// NotBooleanMethod.
/// </summary>
public class NotBooleanMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "Not");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);
        CombinedTypeContainer item = args.Single();
        var b = ExpectBoolean(item);

        return b
            ? CombinedTypeContainer.FalseInstance
            : CombinedTypeContainer.TrueInstance;
    }
}
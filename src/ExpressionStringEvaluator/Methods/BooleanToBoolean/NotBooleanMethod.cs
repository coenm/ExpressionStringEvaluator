namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

using System;
using System.Linq;

/// <summary>
/// NotBooleanMethod.
/// </summary>
public class NotBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Not");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        CombinedTypeContainer item = args.Single();
        var b = MethodHelpers.ExpectBoolean(item);

        return b
            ? CombinedTypeContainer.FalseInstance
            : CombinedTypeContainer.TrueInstance;
    }
}
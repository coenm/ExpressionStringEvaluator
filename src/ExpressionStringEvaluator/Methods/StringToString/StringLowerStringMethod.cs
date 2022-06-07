namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;

/// <summary>
/// StringLowerStringMethod.
/// </summary>
public class StringLowerStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Lower", "ToLower");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return new CombinedTypeContainer(stringValue.ToLower());
    }
}
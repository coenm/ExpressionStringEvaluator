namespace ExpressionStringEvaluator.Methods.StringToInt;

using System;

/// <summary>
/// StringLengthMethod.
/// </summary>
public class StringLengthMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "length");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        var stringValue = MethodHelpers.ExpectString(args[0]);
        return new CombinedTypeContainer(stringValue.Length);
    }
}
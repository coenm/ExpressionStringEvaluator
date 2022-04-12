namespace ExpressionStringEvaluator.Methods.StringToInt;

using System;

/// <summary>
/// StringLengthMethod.
/// </summary>
public class StringLengthMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "length");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);
        var stringValue = ExpectString(args[0]);
        return new CombinedTypeContainer(stringValue.Length);
    }
}
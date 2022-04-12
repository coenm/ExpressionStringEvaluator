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
        return MethodBase.IsMethod(method, "length");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodBase.ExpectArgumentCount(1, args);
        var stringValue = MethodBase.ExpectString(args[0]);
        return new CombinedTypeContainer(stringValue.Length);
    }
}
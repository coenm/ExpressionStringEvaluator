namespace ExpressionStringEvaluator.Methods.StringToString;

using System;

/// <summary>
/// StringTrimEndStringMethod.
/// </summary>
public class StringTrimEndStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "TrimEnd");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        var stringValue = MethodHelpers.ExpectSingleString(args);
        return new CombinedTypeContainer(stringValue.TrimEnd());
    }
}
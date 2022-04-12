namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;

/// <summary>
/// StringIsNullOrEmptyBooleanMethod.
/// </summary>
public class StringIsNullOrEmptyBooleanMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "IsNullOrEmpty");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);
        var stringValue = ExpectString(args[0]);
        return string.IsNullOrEmpty(stringValue)
            ? CombinedTypeContainer.TrueInstance
            : CombinedTypeContainer.FalseInstance;
    }
}
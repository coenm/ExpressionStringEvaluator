namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;

/// <summary>
/// StringIsNullOrEmptyBooleanMethod.
/// </summary>
public class StringIsNullOrEmptyBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodBase.IsMethod(method, "IsNullOrEmpty");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodBase.ExpectArgumentCount(1, args);
        var stringValue = MethodBase.ExpectString(args[0]);
        return string.IsNullOrEmpty(stringValue)
            ? CombinedTypeContainer.TrueInstance
            : CombinedTypeContainer.FalseInstance;
    }
}
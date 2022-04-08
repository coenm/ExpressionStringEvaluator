namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;

public class StringIsNullOrEmptyBooleanMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "IsNullOrEmpty");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);
        var stringValue = ExpectString(args[0]);
        return string.IsNullOrEmpty(stringValue)
            ? CombinedTypeContainer.TrueInstance
            : CombinedTypeContainer.FalseInstance;
    }
}
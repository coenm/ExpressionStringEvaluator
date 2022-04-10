namespace ExpressionStringEvaluator.Methods.StringToInt;

using System;

public class StringLengthMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "length");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);
        var stringValue = ExpectString(args[0]);
        return new CombinedTypeContainer(stringValue.Length);
    }
}
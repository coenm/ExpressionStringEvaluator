namespace ExpressionStringEvaluator.Methods.StringToString;

using System;

public class StringTrimEndStringMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "TrimEnd");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        string stringValue = ExpectSingleString(args);
        return new CombinedTypeContainer(stringValue.TrimEnd());
    }
}
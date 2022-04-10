namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;

public class StringTrimStringMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "Trim");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        string stringValue = ExpectSingleString(args);
        return new CombinedTypeContainer(stringValue.Trim());
    }
}
namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;

public class StringUpperStringMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "Upper");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        string stringValue = ExpectSingleString(args);
        return new CombinedTypeContainer(stringValue.ToUpper());
    }
}
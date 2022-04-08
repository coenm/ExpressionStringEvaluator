namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;

public class StringTrimStartStringMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "TrimStart");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        string stringValue = ExpectSingleString(args);
        return new CombinedTypeContainer(stringValue.TrimStart());
    }
}
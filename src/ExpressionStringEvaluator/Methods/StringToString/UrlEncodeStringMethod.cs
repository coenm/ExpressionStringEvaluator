namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;
using System.Web;

public class UrlEncodeStringMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "UrlEncode");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        string stringValue = ExpectSingleString(args);
        return new CombinedTypeContainer(HttpUtility.UrlEncode(stringValue));
    }
}
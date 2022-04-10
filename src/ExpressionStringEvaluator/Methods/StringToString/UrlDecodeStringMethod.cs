namespace ExpressionStringEvaluator.Methods.StringToString;

using System;
using System.Linq;
using System.Web;

public class UrlDecodeStringMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "UrlDecode");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        string stringValue = ExpectSingleString(args);
        return new CombinedTypeContainer(HttpUtility.UrlDecode(stringValue));
    }
}
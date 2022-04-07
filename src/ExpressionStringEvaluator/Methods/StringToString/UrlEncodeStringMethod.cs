namespace ExpressionStringEvaluator.Methods.StringToString
{
    using System;
    using System.Linq;
    using System.Web;

    public class UrlEncodeStringMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "UrlEncode");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            string stringValue = ExpectSingleString(arg);
            return new CombinedTypeContainer(HttpUtility.UrlEncode(stringValue));
        }
    }
}

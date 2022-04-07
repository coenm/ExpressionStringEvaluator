namespace ExpressionStringEvaluator.Methods.StringToString
{
    using System;
    using System.Linq;

    public class StringTrimStringMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "Trim");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            string stringValue = ExpectSingleString(arg);
            return new CombinedTypeContainer(stringValue.Trim());
        }
    }
}

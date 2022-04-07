namespace ExpressionStringEvaluator.Methods.StringToString
{
    using System;

    public class StringTrimEndStringMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "TrimEnd");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            string stringValue = ExpectSingleString(arg);
            return new CombinedTypeContainer(stringValue.TrimEnd());
        }
    }
}

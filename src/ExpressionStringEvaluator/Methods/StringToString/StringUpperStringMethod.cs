namespace ExpressionStringEvaluator.Methods.StringToString
{
    using System;
    using System.Linq;

    public class StringUpperStringMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "Upper");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            string stringValue = ExpectSingleString(arg);
            return new CombinedTypeContainer(stringValue.ToUpper());
        }
    }
}

namespace ExpressionStringEvaluator.Methods.StringToInt
{
    using System;

    public class StringLengthMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "length");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            ExpectArgumentCount(1, arg);
            var stringValue = ExpectString(arg[0]);
            return new CombinedTypeContainer(stringValue.Length);
        }
    }
}

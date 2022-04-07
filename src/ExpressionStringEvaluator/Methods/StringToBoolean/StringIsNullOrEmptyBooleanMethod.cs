namespace ExpressionStringEvaluator.Methods.StringToBoolean
{
    using System;

    public class StringIsNullOrEmptyBooleanMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "IsNullOrEmpty");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            ExpectArgumentCount(1, arg);
            var stringValue = ExpectString(arg[0]);
            return string.IsNullOrEmpty(stringValue)
                ? CombinedTypeContainer.TrueInstance
                : CombinedTypeContainer.FalseInstance;
        }
    }
}

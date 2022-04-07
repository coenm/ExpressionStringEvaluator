namespace ExpressionStringEvaluator.Methods.BooleanToBoolean
{
    using System;
    using System.Linq;

    public class NotBooleanMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "Not");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            ExpectArgumentCount(1, arg);

            var item = arg.Single();

            ExpectBoolean(item);

            return item.Bool
                ? CombinedTypeContainer.FalseInstance
                : CombinedTypeContainer.TrueInstance;
        }
    }
}

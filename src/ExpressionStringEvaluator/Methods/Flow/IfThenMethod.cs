namespace ExpressionStringEvaluator.Methods.Flow
{
    using System;
    using System.Linq;

    public class IfThenMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "ifthen");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            ExpectArgumentCount(2, arg);
            bool b = ExpectBoolean(arg[0]);
            ExpectNotNull(arg);
            return arg[0].Bool ? arg[1] : CombinedTypeContainer.NullInstance;
        }
    }
}

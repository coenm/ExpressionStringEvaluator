namespace ExpressionStringEvaluator.Methods.Flow
{
    using System;
    using System.Linq;

    public class IfThenElseMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "ifthenelse", "conditional");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            ExpectArgumentCount(3, arg);
            bool b = ExpectBoolean(arg[0]);
            ExpectNotNull(arg);
            return arg[0].Bool ? arg[1] : arg[2];
        }
    }
}

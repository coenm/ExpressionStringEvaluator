
namespace ExpressionStringEvaluator.Methods.StringToBoolean
{
    using System;
    using System.Linq;

    public class StringEqualsStringMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "StringEquals");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            ExpectAtLeastArgumentCount(2, arg);
            var count = ExpectAtMostArgumentCount(3, arg);

            ExpectStrings(arg);

            if (count == 2)
            {
                return string.Equals(arg[0].String, arg[1].String)
                    ? CombinedTypeContainer.TrueInstance
                    : CombinedTypeContainer.FalseInstance;
            }

            if (count == 3)
            {
                var sc = StringComparison.CurrentCultureIgnoreCase;

                if ("CurrentCultureIgnoreCase".Equals(arg[2].String, StringComparison.CurrentCultureIgnoreCase))
                {
                    sc = StringComparison.CurrentCultureIgnoreCase;
                }

                return string.Equals(arg[0].String, arg[1].String, sc)
                    ? CombinedTypeContainer.TrueInstance
                    : CombinedTypeContainer.FalseInstance;
            }

            throw new NotImplementedException();
        }
    }
}

using System;

namespace ExpressionStringEvaluator.Methods.StringToString
{
    public class StringTrimEndStringMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "TrimEnd".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        private string Handle(string method, params string[] arg)
        {
            if (arg == null)
                return null;

            return arg[0].TrimEnd();
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            if (arg == null)
                throw new Exception("TrimEnd expectes one string argument.");

            if (arg.Length != 1)
                throw new Exception("TrimEnd expectes one string argument.");

            var singleArgument = arg[0];

            if (singleArgument.Type != typeof(string))
                throw new Exception("TrimEnd expectes one string argument.");

            return new CombinedTypeContainer(singleArgument.String.TrimEnd());
        }
    }
}

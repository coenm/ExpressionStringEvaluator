using System;
using System.Linq;

namespace ExpressionStringEvaluator.Methods.StringToString
{
    public class StringTrimStartStringMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "TrimStart".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        private string Handle(string method, params string[] arg)
        {
            if (arg == null)
                return null;

            return arg[0].TrimStart();
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            return new CombinedTypeContainer(Handle(method, arg.Select(x => x.ToString()).ToArray()));
        }
    }
}

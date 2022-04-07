using System;
using System.Linq;
using System.Web;

namespace ExpressionStringEvaluator.Methods.StringToString
{
    public class UrlDecodeStringMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "UrlDecode".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        private string Handle(string method, params string[] arg)
        {
            if (arg == null)
                return null;

            return HttpUtility.UrlDecode(arg[0]);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            return new CombinedTypeContainer(Handle(method, arg.Select(x => x.ToString()).ToArray()));
        }
    }
}

using System;
using System.Linq;
using System.Web;

namespace Core.Methods.StringToString
{
    public class UrlEncodeStringMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "UrlEncode".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        private string Handle(string method, params string[] arg)
        {
            if (arg == null)
                return null;

            return HttpUtility.UrlEncode(arg[0]);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            return new CombinedTypeContainer(Handle(method, arg.Select(x => x.ToString()).ToArray()));
        }
    }
}

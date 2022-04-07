using System;
using System.Linq;

namespace Core.Methods.StringToString
{
    public class StringTrimStringMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "Trim".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        private string Handle(string method, params string[] arg)
        {
            if (arg[0] == null)
                return null;

            return arg[0].Trim();
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            return new CombinedTypeContainer(Handle(method, arg.Select(x => x.ToString()).ToArray()));
        }
    }
}

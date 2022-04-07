using System;
using System.Linq;

namespace Core.Methods.StringToString
{
    public class StringLowerStringMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "Lower".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            return new CombinedTypeContainer(Handle(method, arg.Select(x => x.ToString()).ToArray()));
        }

        private string Handle(string method, params string[] arg)
        {
            if (string.IsNullOrWhiteSpace(arg[0]))
                return null;

            return arg[0].ToLower();
        }
    }
}

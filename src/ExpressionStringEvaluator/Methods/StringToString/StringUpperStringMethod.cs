using System;
using System.Linq;

namespace Core.Methods.StringToString
{
    public class StringUpperStringMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "Upper".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        private string Handle(string method, params string[] arg)
        {
            if (string.IsNullOrWhiteSpace(arg[0]))
                return null;

            return arg[0].ToUpper();
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            return new CombinedTypeContainer(Handle(method, arg.Select(x => x.ToString()).ToArray()));
        }
    }
}

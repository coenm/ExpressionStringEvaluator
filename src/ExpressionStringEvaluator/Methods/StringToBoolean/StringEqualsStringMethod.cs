using System;
using System.Linq;

namespace ExpressionStringEvaluator.Methods.StringToBoolean;

public class StringEqualsStringMethod : IMethod
{
    public bool CanHandle(string method)
    {
        return "StringEquals".Equals(method, StringComparison.InvariantCultureIgnoreCase);
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
    {
        return new CombinedTypeContainer(HandleInner(method, arg.Select(x => x.ToString()).ToArray()));
    }

    private bool HandleInner(string method, params string[] arg)
    {
        if (arg.Length == 2)
        {
            return arg[0].Equals(arg[1]);
        }

        if (arg.Length == 3)
        {
            var sc = StringComparison.CurrentCultureIgnoreCase;
            if ("CurrentCultureIgnoreCase".Equals(arg[2], StringComparison.CurrentCultureIgnoreCase))
            {
                sc = StringComparison.CurrentCultureIgnoreCase;
            }

            return arg[0].Equals(arg[1], sc);
        }

        throw new Exception();
    }
}

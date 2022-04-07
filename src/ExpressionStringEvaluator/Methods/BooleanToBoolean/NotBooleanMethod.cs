using System;
using System.Linq;

namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

public class NotBooleanMethod : IMethod
{
    public bool CanHandle(string method)
    {
        return "Not".Equals(method, StringComparison.InvariantCultureIgnoreCase);
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
    {
        if (arg.Length == 0)
        {
            throw new Exception();
        }

        if (arg.Length > 1)
        {
            throw new Exception();
        }

        var item = arg.First();

        if (item.Type != typeof(bool))
        {
            throw new Exception();
        }

        return new CombinedTypeContainer(!item.Bool);
    }
}

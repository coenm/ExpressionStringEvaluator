using System;

namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

public class OrBooleanMethod : IMethod
{
    public bool CanHandle(string method)
    {
        return "any".Equals(method, StringComparison.InvariantCultureIgnoreCase) || "Or".Equals(method, StringComparison.InvariantCultureIgnoreCase);
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
    {
        if (arg.Length == 0)
        {
            throw new Exception();
        }

        foreach (var item in arg)
        {
            if (item.Type == typeof(bool) && item.Bool == true)
            {
                return new CombinedTypeContainer(true);
            }
        }

        return new CombinedTypeContainer(false);
    }
}

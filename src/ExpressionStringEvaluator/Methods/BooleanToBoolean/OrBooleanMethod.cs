namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

using System;

public class OrBooleanMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "Or", "Any");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectAtLeastArgumentCount(1, args);

        foreach (CombinedTypeContainer item in args)
        {
            if (item.IsBool(out var b) && b == true)
            {
                return CombinedTypeContainer.TrueInstance;
            }
        }

        return CombinedTypeContainer.FalseInstance;
    }
}
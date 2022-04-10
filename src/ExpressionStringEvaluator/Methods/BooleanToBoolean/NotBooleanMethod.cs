namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

using System;
using System.Linq;

public class NotBooleanMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "Not");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);
        CombinedTypeContainer item = args.Single();
        var b = ExpectBoolean(item);

        return b
            ? CombinedTypeContainer.FalseInstance
            : CombinedTypeContainer.TrueInstance;
    }
}
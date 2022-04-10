namespace ExpressionStringEvaluator.Methods.Flow;

using System;
using System.Linq;

public class IfThenElseMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "ifthenelse", "conditional");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(3, args);
        var b = ExpectBoolean(args[0]);
        ExpectNotNull(args);
        return b ? args[1] : args[2];
    }
}
namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;
using System.Linq;

/// <summary>
/// StringEqualsStringMethod.
/// </summary>
public class StringEqualsStringMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "StringEquals");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectAtLeastArgumentCount(2, args);
        var count = ExpectAtMostArgumentCount(3, args);

        var strings = ExpectStrings(args);

        if (count == 2)
        {
            return string.Equals(strings[0], strings[1])
                ? CombinedTypeContainer.TrueInstance
                : CombinedTypeContainer.FalseInstance;
        }

        if (count == 3)
        {
            StringComparison sc = StringComparison.CurrentCultureIgnoreCase;

            if ("CurrentCultureIgnoreCase".Equals(strings[2], StringComparison.CurrentCultureIgnoreCase))
            {
                sc = StringComparison.CurrentCultureIgnoreCase;
            }

            return string.Equals(strings[0], strings[1], sc)
                ? CombinedTypeContainer.TrueInstance
                : CombinedTypeContainer.FalseInstance;
        }

        throw new NotImplementedException();
    }
}
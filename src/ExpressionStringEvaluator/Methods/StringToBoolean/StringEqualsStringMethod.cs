namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;
using System.Linq;

/// <summary>
/// StringEqualsStringMethod.
/// </summary>
public class StringEqualsStringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "StringEquals", "string.Equals");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectAtLeastArgumentCount(2, args);
        var count = MethodHelpers.ExpectAtMostArgumentCount(3, args);

        var strings = MethodHelpers.ExpectStrings(args);

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
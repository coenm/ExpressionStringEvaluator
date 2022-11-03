namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;

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
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectAtLeastArgumentCount(2, args);
        var count = MethodHelpers.ExpectAtMostArgumentCount(3, args);

        var strings = MethodHelpers.ExpectStrings(args);

        if (count == 2)
        {
            return string.Equals(strings[0], strings[1]);
        }

        if (count == 3)
        {
            StringComparison sc = StringComparison.CurrentCultureIgnoreCase;

            if ("CurrentCultureIgnoreCase".Equals(strings[2], StringComparison.CurrentCultureIgnoreCase))
            {
                sc = StringComparison.CurrentCultureIgnoreCase;
            }

            return string.Equals(strings[0], strings[1], sc);
        }

        throw new NotImplementedException();
    }
}
namespace ExpressionStringEvaluator.Methods.StringToString;

/// <summary>
/// SubstringMethod.
/// </summary>
public class SubstringMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Substring");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectAtLeastArgumentCount(2, args);
        var count = MethodHelpers.ExpectAtMostArgumentCount(3, args);

        var @string = MethodHelpers.ExpectString(args[0]);
        var startIndex = MethodHelpers.ExpectIntegerOrIntegerString(args[1]);

        if (count == 2)
        {
            return new CombinedTypeContainer(@string.Substring(startIndex));
        }

        var length = MethodHelpers.ExpectIntegerOrIntegerString(args[2]);
        return new CombinedTypeContainer(@string.Substring(startIndex, length));
    }
}
namespace ExpressionStringEvaluator.Methods.StringToString;

/// <summary>
/// StringReplace.
/// </summary>
public class StringReplaceMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "StringReplace");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(3, args);
        var strings = MethodHelpers.ExpectStrings(args);

        if (strings[1].Length == 1 && strings[2].Length == 1)
        {
            // use characters (probably better performance)
            return strings[0].Replace(strings[1][0], strings[2][0]);
        }

        return strings[0].Replace(strings[1], strings[2]);
    }
}
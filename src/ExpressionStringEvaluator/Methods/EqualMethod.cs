namespace ExpressionStringEvaluator.Methods;

/// <summary>
/// EqualMethod.
/// </summary>
public class EqualMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Eq", "Equal");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        var v0 = args[0];
        var v1 = args[1];

        if (v0 == null && v1 == null)
        {
            return true;
        }

        if (v0 == null || v1 == null)
        {
            return false;
        }

        if (v0 is string s && v1 is bool b)
        {
            return CompareBooleanAndString(b, s);
        }

        if (v1 is string s1 && v0 is bool b1)
        {
            return CompareBooleanAndString(b1, s1);
        }

        if (v0 is string s2 && v1 is int i)
        {
            return CompareIntAndString(i, s2);
        }

        if (v1 is string s3 && v0 is int i1)
        {
            return CompareIntAndString(i1, s3);
        }

        return v0.Equals(v1);
    }

    private static bool CompareIntAndString(int @int, string @string)
    {
        if (MethodHelpers.IsIntegerOrIntegerString(@string, out var intValue))
        {
            return @int == intValue;
        }

        return false;
    }

    private static bool CompareBooleanAndString(bool @bool, string @string)
    {
        if (MethodHelpers.IsBooleanOrBooleanString(@string, out var boolValue))
        {
            return boolValue == @bool;
        }

        return false;
    }
}
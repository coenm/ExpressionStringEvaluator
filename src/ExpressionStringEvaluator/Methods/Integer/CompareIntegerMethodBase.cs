namespace ExpressionStringEvaluator.Methods.Integer;

/// <summary>
/// Base method to compare to integers.
/// </summary>
public abstract class CompareIntegerMethodBase : IMethod
{
    /// <inheritdoc />
    public virtual bool CanHandle(string method)
    {
        return false;
    }

    /// <inheritdoc />
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        var first = MethodHelpers.ExpectIntegerOrIntegerString(args[0]);
        var second = MethodHelpers.ExpectIntegerOrIntegerString(args[1]);

        return Compare(first, second);
    }

    private protected abstract bool Compare(int first, int second);
}
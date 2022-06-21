namespace ExpressionStringEvaluator.Methods.Integer;

using System;

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
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        var first = MethodHelpers.ExpectIntegerOrIntegerString(args[0]);
        var second = MethodHelpers.ExpectIntegerOrIntegerString(args[1]);

        return Compare(first, second)
            ? CombinedTypeContainer.TrueInstance
            : CombinedTypeContainer.FalseInstance;
    }

    private protected abstract bool Compare(int first, int second);
}
namespace ExpressionStringEvaluator.Methods.Integer;

/// <summary>
/// LessThanEMethod.
/// </summary>
public class LessThanEMethod : CompareIntegerMethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public override bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "lt", "LessThan");
    }

    private protected override bool Compare(int first, int second)
    {
        return first < second;
    }
}
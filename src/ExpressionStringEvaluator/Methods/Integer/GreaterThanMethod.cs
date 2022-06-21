namespace ExpressionStringEvaluator.Methods.Integer;

/// <summary>
/// GreaterThanMethod.
/// </summary>
public class GreaterThanMethod : CompareIntegerMethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public override bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "gt", "GreaterThan");
    }

    private protected override bool Compare(int first, int second)
    {
        return first > second;
    }
}
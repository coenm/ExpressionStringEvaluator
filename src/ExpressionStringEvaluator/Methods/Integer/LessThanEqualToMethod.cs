namespace ExpressionStringEvaluator.Methods.Integer;

/// <summary>
/// LessThanEqualToMethod.
/// </summary>
public class LessThanEqualToMethod : CompareIntegerMethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public override bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "le", "LessThanEqualTo");
    }

    private protected override bool Compare(int first, int second)
    {
        return first <= second;
    }
}
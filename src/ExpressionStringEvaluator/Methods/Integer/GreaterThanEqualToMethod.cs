namespace ExpressionStringEvaluator.Methods.Integer;

/// <summary>
/// GreaterThanEqualToMethod.
/// </summary>
public class GreaterThanEqualToMethod : CompareIntegerMethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public override bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "ge", "GreaterThanEqualTo");
    }

    private protected override bool Compare(int first, int second)
    {
        return first >= second;
    }
}
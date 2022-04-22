namespace ExpressionStringEvaluator.Methods.StringToBoolean;

/// <summary>
/// In Methods.
/// </summary>
public class InMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "In");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        var count = MethodHelpers.ExpectAtLeastArgumentCount(2, args);

        var firstValue = args[0].ToString();

        for (var i = 1; i < count; i++)
        {
            if (!args[i].IsNull() && firstValue.Equals(args[i].ToString()))
            {
                return CombinedTypeContainer.TrueInstance;
            }
        }

        return CombinedTypeContainer.FalseInstance;
    }
}
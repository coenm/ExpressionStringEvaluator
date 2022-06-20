namespace ExpressionStringEvaluator.Methods.Linq;

using System.Threading;

/// <summary>
/// CountMethod.
/// </summary>
public class CountMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Count");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        CombinedTypeContainer values = args[0];

        if (values.IsArray(out CombinedTypeContainer[]? value))
        {
            return new CombinedTypeContainer(value.Length);
        }

        return new CombinedTypeContainer(0);
    }
}
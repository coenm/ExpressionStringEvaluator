namespace ExpressionStringEvaluator.Methods.Linq;

using System.Linq;

/// <summary>
/// FirstMethod.
/// </summary>
public class FirstMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "First");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        CombinedTypeContainer values = args[0];

        if (values.IsArray(out CombinedTypeContainer[]? value))
        {
            // can throws, when empty
            return value.First();
        }

        // or should this throw?
        return CombinedTypeContainer.NullInstance;
    }
}
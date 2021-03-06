namespace ExpressionStringEvaluator.Methods.Linq;

using System.Linq;

/// <summary>
/// SkipMethod.
/// </summary>
public class SkipMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Skip");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        CombinedTypeContainer values = args[0];
        CombinedTypeContainer skipContainer = args[1];
        var skip = MethodHelpers.ExpectIntegerOrIntegerString(skipContainer);

        if (values.IsArray(out CombinedTypeContainer[]? value))
        {
            // can throws, when empty
            return new CombinedTypeContainer(value.Skip(skip).ToArray());
        }

        // or should this throw?
        return CombinedTypeContainer.NullInstance;
    }
}
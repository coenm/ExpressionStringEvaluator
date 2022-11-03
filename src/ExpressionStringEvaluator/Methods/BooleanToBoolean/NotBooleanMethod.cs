namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

using System.Linq;

/// <summary>
/// NotBooleanMethod.
/// </summary>
public class NotBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Not");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        return !MethodHelpers.ExpectBooleanOrBooleanString(args.Single());
    }
}
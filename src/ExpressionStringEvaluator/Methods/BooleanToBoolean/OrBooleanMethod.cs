namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

using System;

/// <summary>
/// OrBooleanMethod.
/// </summary>
public class OrBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Or", "Any");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectAtLeastArgumentCount(1, args);

        foreach (CombinedTypeContainer item in args)
        {
            if (MethodHelpers.IsBooleanOrBooleanString(item, out var b) && b.Value)
            {
                return CombinedTypeContainer.TrueInstance;
            }
        }

        return CombinedTypeContainer.FalseInstance;
    }
}
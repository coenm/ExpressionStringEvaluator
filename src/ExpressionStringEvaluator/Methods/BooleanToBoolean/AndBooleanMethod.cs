namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

using System;

/// <summary>
/// AndBooleanMethod.
/// </summary>
public class AndBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "And", "All");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectAtLeastArgumentCount(1, args);

        foreach (CombinedTypeContainer item in args)
        {
            if (item.IsNull())
            {
                return CombinedTypeContainer.FalseInstance;
            }

            if (!item.IsBool(out var @bool))
            {
                return CombinedTypeContainer.FalseInstance;
            }

            if (!@bool.Value)
            {
                return CombinedTypeContainer.FalseInstance;
            }
        }

        return CombinedTypeContainer.TrueInstance;
    }
}
namespace ExpressionStringEvaluator.Methods.BooleanToBoolean;

using System;

/// <summary>
/// AndBooleanMethod.
/// </summary>
public class AndBooleanMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "And", "All");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectAtLeastArgumentCount(1, args);

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
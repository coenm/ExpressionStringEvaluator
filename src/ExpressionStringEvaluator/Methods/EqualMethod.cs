namespace ExpressionStringEvaluator.Methods;

/// <summary>
/// CountMethod.
/// </summary>
public class EqualMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "Eq", "Equal");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodHelpers.ExpectArgumentCount(2, args);
        CombinedTypeContainer v0 = args[0];
        CombinedTypeContainer v1 = args[1];

        if (v0.IsBool(out var boolValue0))
        {
            // expect second to be bool
            if (v1.IsBool(out var boolValue1))
            {
                return boolValue1 == boolValue0
                    ? CombinedTypeContainer.TrueInstance
                    : CombinedTypeContainer.FalseInstance;
            }
        }

        if (v0.IsInt(out var intValue0))
        {
            // expect second to be int
            if (v1.IsInt(out var intValue1))
            {
                return intValue1 == intValue0
                    ? CombinedTypeContainer.TrueInstance
                    : CombinedTypeContainer.FalseInstance;
            }
        }

        if (v0.IsNull())
        {
            // expect second to be int
            if (v1.IsNull())
            {
                return CombinedTypeContainer.TrueInstance;
            }
        }

        if (v0.IsString(out var stringValue0))
        {
            // expect second to be int
            if (v1.IsString(out var stringValue1))
            {
                return stringValue0.Equals(stringValue1)
                    ? CombinedTypeContainer.TrueInstance
                    : CombinedTypeContainer.FalseInstance;
            }
        }

        return CombinedTypeContainer.NullInstance;
    }
}
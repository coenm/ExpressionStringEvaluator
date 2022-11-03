namespace ExpressionStringEvaluator.Methods.Linq;

using System.Collections;

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
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);

        if (args[0] is IList list)
        {
            return list[0];
        }

        if (args[0] is object[] array)
        {
            return array[0];
        }

        return args[0];
    }
}
namespace ExpressionStringEvaluator.Methods.Linq;

using System;
using System.Collections;

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
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        var values = args[0];

        if (values == null)
        {
            throw new Exception("Cannot get length of null");
        }

        if (values is Array a)
        {
            return a.Length;
        }

        if (values is IList list)
        {
            return list.Count;
        }

        if (values is IDictionary dictionary)
        {
            return dictionary.Count;
        }

        return 0;
    }
}
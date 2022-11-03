namespace ExpressionStringEvaluator.Tests.TestHelpers;

using System.Linq;

internal static class ObjectHelper
{
    public static object CreateArrayContainer(params string[] input)
    {
        return CreateArray(input);
    }

    public static object CreateArrayContainer(params int[] input)
    {
        return CreateArray(input);
    }

    public static object[] CreateArray(params string[] input)
    {
        return input.ToArray();
    }

    public static object[] CreateArray(params int[] input)
    {
        return input.Select(x => (object)x).ToArray();
    }
}
namespace ExpressionStringEvaluator.Tests.TestHelpers;

using System.Linq;
using ExpressionStringEvaluator.Methods;

internal static class CombinedTypeContainerHelper
{
    public static CombinedTypeContainer CreateArrayContainer(params string[] input)
    {
        return new CombinedTypeContainer(CreateArray(input));
    }

    public static CombinedTypeContainer[] CreateArray(params string[] input)
    {
        return input.Select(x => new CombinedTypeContainer(x)).ToArray();
    }

    public static CombinedTypeContainer CreateArrayContainer(params int[] input)
    {
        return new CombinedTypeContainer(CreateArray(input));
    }

    public static CombinedTypeContainer[] CreateArray(params int[] input)
    {
        return input.Select(x => new CombinedTypeContainer(x)).ToArray();
    }
}
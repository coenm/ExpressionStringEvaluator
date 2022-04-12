namespace ExpressionStringEvaluator.Methods;

using System;
using System.Collections.Generic;
using System.Linq;

public static class MethodBase
{
    public static bool IsMethod(string method, params string[] compareTo)
    {
        return compareTo.Any(item => method.Equals(item, StringComparison.CurrentCultureIgnoreCase));
    }

    public static void ExpectArgumentCount(int expectCount, params CombinedTypeContainer[] arg)
    {
        if (arg.Length != expectCount)
        {
            throw new Exception($"Expected {expectCount} arguments but found {arg.Length}.");
        }
    }

    public static int ExpectAtLeastArgumentCount(int expectCount, params CombinedTypeContainer[] arg)
    {
        if (arg.Length < expectCount)
        {
            throw new Exception($"Expected at least {expectCount} arguments but found {arg.Length}.");
        }

        return arg.Length;
    }

    public static int ExpectAtMostArgumentCount(int expectCount, params CombinedTypeContainer[] arg)
    {
        if (arg.Length > expectCount)
        {
            throw new Exception($"Expected at most {expectCount} arguments but found {arg.Length}.");
        }

        return arg.Length;
    }

    public static string ExpectString(CombinedTypeContainer arg)
    {
        if (!arg.IsString(out var @string))
        {
            throw new Exception($"Expected string type but but found {arg.GetInnerType()?.Name ?? "null"}.");
        }

        return @string;
    }

    public static string ExpectSingleString(CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);
        return ExpectString(args[0]);
    }

    public static string[] ExpectStrings(CombinedTypeContainer[] arg)
    {
        var result = new List<string>(arg.Length);

        foreach (CombinedTypeContainer a in arg)
        {
            result.Add(ExpectString(a));
        }

        return result.ToArray();
    }

    public static bool ExpectBoolean(CombinedTypeContainer arg)
    {
        if (!arg.IsBool(out var b))
        {
            throw new Exception($"Expected boolean type but but found {arg.GetInnerType()?.Name ?? "null"}.");
        }

        return b.Value;
    }

    public static void ExpectNotNull(CombinedTypeContainer[] args)
    {
        if (args.Any(item => item == null))
        {
            throw new Exception("Expected all items not to be null.");
        }
    }
}
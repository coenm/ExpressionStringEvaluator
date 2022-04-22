namespace ExpressionStringEvaluator.Methods;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

internal static class MethodHelpers
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

    public static bool IsBooleanOrBooleanString(CombinedTypeContainer arg, [NotNullWhen(true)] out bool? value)
    {
        if (arg.IsBool(out var b))
        {
            value = b;
            return true;
        }

        if (arg.IsString(out var s))
        {
            if ("true".Equals(s.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                value = true;
                return true;
            }

            if ("false".Equals(s.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                value = false;
                return true;
            }
        }

        value = null;
        return false;
    }

    public static bool ExpectBooleanOrBooleanString(CombinedTypeContainer arg)
    {
        if (IsBooleanOrBooleanString(arg, out var b))
        {
            return b.Value;
        }

        throw new Exception($"Expected boolean but but found {arg}.");
    }

    public static void ExpectNotNull(CombinedTypeContainer[] args)
    {
        if (args.Any(item => item == null))
        {
            throw new Exception("Expected all items not to be null.");
        }
    }
}
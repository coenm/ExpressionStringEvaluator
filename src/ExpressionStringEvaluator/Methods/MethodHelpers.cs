namespace ExpressionStringEvaluator.Methods;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

internal static class MethodHelpers
{
    public static bool IsMethod(string method, params string[] compareTo)
    {
        return compareTo.Any(item => item.Equals(method, StringComparison.CurrentCultureIgnoreCase));
    }

    public static void ExpectArgumentCount(int expectCount, params object?[] arg)
    {
        if (arg.Length != expectCount)
        {
            throw new Exception($"Expected {expectCount} arguments but found {arg.Length}.");
        }
    }

    public static int ExpectAtLeastArgumentCount(int expectCount, params object?[] arg)
    {
        if (arg.Length < expectCount)
        {
            throw new Exception($"Expected at least {expectCount} arguments but found {arg.Length}.");
        }

        return arg.Length;
    }

    public static int ExpectAtMostArgumentCount(int expectCount, params object?[] arg)
    {
        if (arg.Length > expectCount)
        {
            throw new Exception($"Expected at most {expectCount} arguments but found {arg.Length}.");
        }

        return arg.Length;
    }

    public static bool IsIntegerOrIntegerString(object? arg, [NotNullWhen(true)] out int? value)
    {
        if (arg is null)
        {
            value = null;
            return false;
        }

        if (arg is int @int)
        {
            value = @int;
            return true;
        }

        if (arg is string @string && int.TryParse(@string, NumberStyles.Any, CultureInfo.CurrentCulture, out var tryParseValue))
        {
            value = tryParseValue;
            return true;
        }

        value = null;
        return false;
    }

    public static int ExpectIntegerOrIntegerString(object? arg)
    {
        if (arg is null)
        {
            throw new Exception($"Expected integer type or string with integer value but but found null.");
        }

        if (arg is int @int)
        {
            return @int;
        }

        if (arg is string @string && int.TryParse(@string, NumberStyles.Any, CultureInfo.CurrentCulture, out var value))
        {
            return value;
        }

        throw new Exception($"Expected integer type or string with integer value but but found {arg.GetType().Name ?? "null"}.");
    }

    public static string ExpectString(object? arg)
    {
        if (arg == null)
        {
            throw new Exception($"Expected string type but");
        }

        if (arg is not string @string)
        {
            throw new Exception($"Expected string type but found {arg.GetType()?.Name ?? "null"}.");
        }

        return @string;
    }

    public static string ExpectSingleString(object?[] args)
    {
        ExpectArgumentCount(1, args);
        return ExpectString(args[0]);
    }

    public static string[] ExpectStrings(object?[] arg)
    {
        var result = new List<string>(arg.Length);
        result.AddRange(arg.Select(ExpectString));
        return result.ToArray();
    }

    public static bool IsBooleanOrBooleanString(object? arg, [NotNullWhen(true)] out bool? value)
    {
        if (arg == null)
        {
            value = null;
            return false;
        }

        if (arg is bool b)
        {
            value = b;
            return true;
        }

        if (arg is string s)
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

    public static bool ExpectBooleanOrBooleanString(object? arg)
    {
        if (IsBooleanOrBooleanString(arg, out var b))
        {
            return b.Value;
        }

        throw new Exception($"Expected boolean but but found {arg}.");
    }

    public static void ExpectNotNull(object?[] args)
    {
        if (args.Any(item => item == null))
        {
            throw new Exception("Expected all items not to be null.");
        }
    }
}
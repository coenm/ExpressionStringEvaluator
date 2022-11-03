// https://github.com/tunnelvisionlabs/antlr4cs/issues/133
[assembly: System.CLSCompliant(false)]

namespace ExpressionStringEvaluator.Parser;

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;
using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.VariableProviders;

internal class LanguageVisitor<T> : LanguageBaseVisitor<object?>
    where T : new()
{
    private readonly List<IMethod> _methods;
    private readonly T _context;
    private readonly List<IVariableProvider> _providers;

    public LanguageVisitor(
        IEnumerable<IVariableProvider> providers,
        IEnumerable<IMethod> methods,
        T context)
    {
        _context = context;
        _providers = providers.ToList();
        _methods = methods.ToList();
    }

    public override object? VisitVariable(LanguageParser.VariableContext context)
    {
        var key = context.KEY().GetText();
        string? args = null;

        LanguageParser.TextWithSpacesContext? contextArg = context.arg;
        if (contextArg != null)
        {
            args = contextArg.GetText();
        }

        IVariableProvider? selectedProvider = _providers.FirstOrDefault(p => p.CanProvide(key));
        if (selectedProvider == null)
        {
            return string.Empty;
        }

        if (selectedProvider is IVariableProvider<T> typed)
        {
            return typed.Provide(_context, key, args);
        }

        return selectedProvider.Provide(key, args);
    }

    public override object? VisitTextWithSpaces(LanguageParser.TextWithSpacesContext context)
    {
        var text = Escape(context.GetText());
        return text;
    }

    public override object? VisitTextWithSpacesEscaped(LanguageParser.TextWithSpacesEscapedContext context)
    {
        var text = Escape(context.GetText())?.Replace("\\\"", "\"");
        return text;
    }

    public override object? VisitWords(LanguageParser.WordsContext context)
    {
        return context.GetText();
    }

    public override object? VisitFunction(LanguageParser.FunctionContext context)
    {
        var method = context.KEY().GetText();
        var arg = VisitArgs(context.arg);

        IMethod? m = _methods.FirstOrDefault(x => x.CanHandle(method));
        if (m == null)
        {
            return method + arg;
        }

        if (arg is object[] a)
        {
            return m.Handle(method, a);
        }

        return m.Handle(method, arg);
    }

    public override object? VisitArgs(LanguageParser.ArgsContext context)
    {
        LanguageParser.ArgumentExpressionContext[]? multipleArguments = context.argumentExpression();

        if (multipleArguments != null)
        {
            var args = new List<object?>();

            foreach (LanguageParser.ArgumentExpressionContext item in multipleArguments)
            {
                args.Add(Visit(item));
            }

            return args.ToArray();
        }

        return Array.Empty<object?>();
    }

    public override object? VisitBooleanexpression(LanguageParser.BooleanexpressionContext context)
    {
        var text = context.GetText();
        return text;
    }

    public override object? VisitEnvvariable(LanguageParser.EnvvariableContext context)
    {
        ITerminalNode envVarKey = context.KEY();
        if (envVarKey == null)
        {
            throw new Exception("Could not determine key in environment variable.");
        }

        var envVariable = envVarKey.GetText();
        IParseTree? closingSymbol = context.children[2];
        if (!"%".Equals(closingSymbol.GetText(), StringComparison.CurrentCultureIgnoreCase))
        {
            throw new Exception("Parser exception");
        }

        var key = $"Env.{envVariable}";
        IVariableProvider? m = _providers.FirstOrDefault(x => x.CanProvide(key));
        if (m != null)
        {
            if (m is IVariableProvider<T> typed)
            {
                return typed.Provide(_context, key, string.Empty);
            }

            return m.Provide(key, string.Empty);
        }

        return string.Empty; // todo
    }

    protected override object? AggregateResult(object? aggregate, object? nextResult)
    {
        if (aggregate is null)
        {
            return nextResult;
        }

        if (nextResult is null)
        {
            return aggregate;
        }

        string? result;

        if (aggregate is bool b)
        {
            result = b.ToString().ToLower();
        }
        else
        {
            result = aggregate.ToString();
        }

        if (nextResult is bool b2)
        {
            result += b2.ToString().ToLower();
        }
        else
        {
            result += nextResult.ToString();
        }

        return result;
    }

    private static string? Escape(string input)
    {
        return input
               .Replace("\\%", "%")
               .Replace("\\{", "{")
               .Replace("\\}", "}")
               .Replace("\\\\", "\\");
    }
}
// https://github.com/tunnelvisionlabs/antlr4cs/issues/133
[assembly: System.CLSCompliant(false)]

namespace ExpressionStringEvaluator.Parser;

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.VariableProviders;

internal class LanguageVisitor<T> : LanguageBaseVisitor<CombinedTypeContainer>
    where T : new()
{
    private readonly List<IMethod> _methods;
    private readonly T _context;
    private readonly List<IVariableProvider> _providers;

    public LanguageVisitor(List<IVariableProvider> providers, List<IMethod> methods, T context)
    {
        _context = context;
        _providers = providers.ToList();
        _methods = methods.ToList();
    }

    public override CombinedTypeContainer VisitVariable(LanguageParser.VariableContext context)
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
            return new CombinedTypeContainer(string.Empty);
        }

        if (selectedProvider is IVariableProvider<T> typed)
        {
            return typed.Provide(_context, key, args) ?? CombinedTypeContainer.NullInstance;
        }

        return selectedProvider.Provide(key, args) ?? CombinedTypeContainer.NullInstance;
    }

    public override CombinedTypeContainer VisitTextWithSpaces(LanguageParser.TextWithSpacesContext context)
    {
        var text = Escape(context.GetText());
        return new CombinedTypeContainer(text);
    }

    public override CombinedTypeContainer VisitTextWithSpacesEscaped(LanguageParser.TextWithSpacesEscapedContext context)
    {
        var text = Escape(context.GetText())?.Replace("\\\"", "\"");
        return new CombinedTypeContainer(text);
    }

    public override CombinedTypeContainer VisitWords(LanguageParser.WordsContext context)
    {
        return new CombinedTypeContainer(context.GetText());
    }

    public override CombinedTypeContainer VisitFunction(LanguageParser.FunctionContext context)
    {
        var method = context.KEY().GetText();
        CombinedTypeContainer arg = VisitArgs(context.arg);

        IMethod? m = _methods.FirstOrDefault(x => x.CanHandle(method));
        if (m == null)
        {
            return new CombinedTypeContainer(method + arg);
        }

        if (arg.Items != null)
        {
            return m.Handle(method, arg.Items.ToArray());
        }

        return m.Handle(method, arg);
    }

    public override CombinedTypeContainer VisitArgs(LanguageParser.ArgsContext context)
    {
        var args = new List<CombinedTypeContainer>();
            /*{
                Visit(context.ar1),
            };*/

        LanguageParser.ArgumentExpressionContext[]? multipleArguments = context.argumentExpression();

        if (multipleArguments != null)
        {
            foreach (LanguageParser.ArgumentExpressionContext item in multipleArguments)
            {
                args.Add(Visit(item));
            }
        }

        return new CombinedTypeContainer(args.ToArray());
    }

    public override CombinedTypeContainer VisitBooleanexpression(LanguageParser.BooleanexpressionContext context)
    {
        var text = context.GetText();

        if ("true".Equals(text, StringComparison.CurrentCultureIgnoreCase))
        {
            return new CombinedTypeContainer(true);
        }

        if ("false".Equals(text, StringComparison.CurrentCultureIgnoreCase))
        {
            return new CombinedTypeContainer(false);
        }

        throw new NotImplementedException();
    }

    public override CombinedTypeContainer VisitEnvvariable(LanguageParser.EnvvariableContext context)
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
                return typed.Provide(_context, key, string.Empty) ?? CombinedTypeContainer.NullInstance;
            }

            return m.Provide(key, string.Empty) ?? CombinedTypeContainer.NullInstance;
        }

        return new CombinedTypeContainer(string.Empty);
    }

    protected override CombinedTypeContainer AggregateResult(CombinedTypeContainer aggregate, CombinedTypeContainer nextResult)
    {
        if (aggregate is null)
        {
            return nextResult;
        }

        if (nextResult is null)
        {
            return aggregate;
        }

        return new CombinedTypeContainer(aggregate.ToString() + nextResult.ToString());
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
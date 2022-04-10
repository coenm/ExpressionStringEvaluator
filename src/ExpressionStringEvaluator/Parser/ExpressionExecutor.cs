namespace ExpressionStringEvaluator.Parser;

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.VariableProviders;

/// <summary>
/// ExpressionExecutor.
/// </summary>
public class ExpressionExecutor
{
    private readonly List<IVariableProvider> _providers;
    private readonly List<IMethod> _methods;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionExecutor"/> class.
    /// </summary>
    /// <param name="providers">providers.</param>
    /// <param name="methods">methods.</param>
    public ExpressionExecutor(IEnumerable<IVariableProvider> providers, IEnumerable<IMethod> methods)
    {
        _providers = providers?.ToList() ?? throw new ArgumentNullException(nameof(providers));
        _methods = methods?.ToList() ?? throw new ArgumentNullException(nameof(methods));
    }

    /// <summary>
    /// Execute.
    /// </summary>
    /// <param name="context">context.</param>
    /// <param name="input">input.</param>
    /// <typeparam name="T">Type of context.</typeparam>
    /// <returns>result.</returns>
    public CombinedTypeContainer Execute<T>(T context, string input)
        where T : new()
    {
        var visitor = new LanguageVisitor<T>(_providers, _methods, context);

        var inputStream = new AntlrInputStream(input);
        var lexer = new LanguageLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);

        var parser = new LanguageParser(commonTokenStream);
        LanguageParser.ExpressionContext expression = parser.expression();

        return visitor.Visit(expression);
    }

    /// <summary>
    /// Execute.
    /// </summary>
    /// <param name="input">input.</param>
    /// <returns>result.</returns>
    public CombinedTypeContainer Execute(string input)
    {
        return Execute<object>(new object(), input);
    }
}
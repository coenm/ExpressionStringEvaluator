using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.VariableProviders;

namespace ExpressionStringEvaluator.Parser
{
    public class LanguageVisitor : LanguageBaseVisitor<CombinedTypeContainer>
    {
        private readonly List<IMethod> _methods;
        private readonly Context _context;
        private readonly List<IVariableProvider> _providers;

        public LanguageVisitor(List<IVariableProvider> providers, List<IMethod> methods, Context context)
        {
            _context = context;
            _providers = providers.ToList();
            _methods = methods.ToList();
        }

        public override CombinedTypeContainer VisitVariable(LanguageParser.VariableContext context)
        {
            var key = context.KEY().GetText();
            string args = null;

            var contextArg = context.arg;
            if (contextArg != null)
                args = contextArg.GetText();

            var selectedProvider = _providers.FirstOrDefault(p => p.CanProvide(key));
            if (selectedProvider == null)
                return new CombinedTypeContainer(string.Empty);

            return new CombinedTypeContainer(selectedProvider.Provide(_context, key, args));
        }

        public override CombinedTypeContainer VisitTextWithSpaces(LanguageParser.TextWithSpacesContext context)
        {
            string text = context.GetText();
            return new CombinedTypeContainer(text);
        }

        public override CombinedTypeContainer VisitWords(LanguageParser.WordsContext context)
        {
            return new CombinedTypeContainer(context.GetText());
        }

        public override CombinedTypeContainer VisitFunction(LanguageParser.FunctionContext context)
        {
            var method = context.KEY().GetText();

            var arg = VisitArgs(context.arg);

            var m = _methods.FirstOrDefault(x => x.CanHandle(method));
            if (m == null)
                return new CombinedTypeContainer(method + arg);

            if (arg.Items != null)
            {
                return m.Handle(method, arg.Items.ToArray());
            }

            return m.Handle(method, arg);
        }

        public override CombinedTypeContainer VisitArgs(LanguageParser.ArgsContext context)
        {
            var args = new List<CombinedTypeContainer>
                {
                    Visit(context.ar1),
                };

            var multipleArguments = context.expression2();

            if (multipleArguments != null)
            {
                foreach (var item in multipleArguments)
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

            if ("1".Equals(text, StringComparison.CurrentCultureIgnoreCase))
            {
                return new CombinedTypeContainer(true);
            }

            if ("false".Equals(text, StringComparison.CurrentCultureIgnoreCase))
            {
                return new CombinedTypeContainer(false);
            }

            if ("0".Equals(text, StringComparison.CurrentCultureIgnoreCase))
            {
                return new CombinedTypeContainer(false);
            }

            throw new NotImplementedException();
        }

        public override CombinedTypeContainer VisitEnvvariable(LanguageParser.EnvvariableContext context)
        {
            var envVariable = context.KEY().GetText();
            var closingSymbol = context.children[2];
            if (!"%".Equals(closingSymbol.GetText(), StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("Parser exception");
            }

            string key = $"Env.{envVariable}";
            var m = _providers.FirstOrDefault(x => x.CanProvide(key));
            if (m != null)
            {
                return new CombinedTypeContainer(m.Provide(_context, key, string.Empty));
            }

            return new CombinedTypeContainer(string.Empty);
        }

        protected override CombinedTypeContainer AggregateResult(CombinedTypeContainer aggregate, CombinedTypeContainer nextResult)
        {
            if (aggregate is null)
                return nextResult;

            if (nextResult is null)
                return aggregate;

            if (aggregate.Type == typeof(bool) && nextResult.Type == typeof(bool))
            {
                return new CombinedTypeContainer(aggregate.Bool && nextResult.Bool);
            }

            return new CombinedTypeContainer(aggregate.ToString() + nextResult.ToString());
        }
    }
}

namespace ExpressionStringEvaluator.Methods
{
    using System;
    using System.Linq;

    public class IfThenElseMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return
                "ifthenelse".Equals(method, StringComparison.InvariantCultureIgnoreCase)
                ||
                "conditional".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            if (arg == null || arg.Length != 3)
            {
                throw new Exception($"Expected three arguments instead of {arg.Length}");
            }

            if (arg[0].Type != typeof(bool))
            {
                throw new Exception("first argument mult be boolean");
            }

            if (arg.Any(a => a == null))
            {
                throw new Exception("Arguments cannot be null.");
            }

            return arg[0].Bool ? arg[1] : arg[2];
        }
    }

    public class IfThenMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "ifthen".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            if (arg == null || arg.Length != 2)
            {
                throw new Exception("Expected two arguments");
            }

            if (arg[0].Type != typeof(bool))
            {
                throw new Exception("first argument mult be boolean");
            }

            if (arg.Any(a => a == null))
            {
                throw new Exception("Arguments cannot be null.");
            }

            return arg[0].Bool ? arg[1] : CombinedTypeContainer.NullInstance;
        }
    }
}

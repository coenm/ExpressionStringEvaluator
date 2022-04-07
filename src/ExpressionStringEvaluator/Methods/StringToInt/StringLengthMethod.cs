namespace ExpressionStringEvaluator.Methods.StringToInt
{
    using System;

    public class StringLengthMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "length".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            if (arg == null || arg.Length != 1)
            {
                throw new Exception("Expected one argument");
            }

            if (arg[0].Type != typeof(string))
            {
                throw new Exception("Expected string argument");
            }

            var len = arg[0].String.Length;

            return new CombinedTypeContainer(len);
        }
    }
}

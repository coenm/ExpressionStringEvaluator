namespace ExpressionStringEvaluator.Methods.StringToBoolean
{
    using System;

    public class StringIsNullOrEmptyBooleanMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "IsNullOrEmpty".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            if (arg.Length == 0)
            {
                throw new Exception();
            }

            if (arg.Length > 1)
            {
                throw new Exception();
            }

            return new CombinedTypeContainer(string.IsNullOrEmpty(arg[0].ToString()));
        }
    }
}

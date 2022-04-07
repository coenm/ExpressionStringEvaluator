namespace ExpressionStringEvaluator.Methods.BooleanToBoolean
{
    using System;

    public class AndBooleanMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "And".Equals(method, StringComparison.InvariantCultureIgnoreCase) || "all".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            if (arg.Length == 0)
            {
                throw new Exception();
            }

            foreach (var item in arg)
            {
                if (item.Type != typeof(bool))
                {
                    return new CombinedTypeContainer(false);
                }

                if (item.Bool == false)
                {
                    return new CombinedTypeContainer(false);
                }
            }

            return new CombinedTypeContainer(true);
        }
    }
}

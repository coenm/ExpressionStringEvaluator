namespace ExpressionStringEvaluator.Methods.BooleanToBoolean
{
    using System;

    public class AndBooleanMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "And", "All");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            ExpectAtLeastArgumentCount(1, arg);

            foreach (var item in arg)
            {
                if (item.IsNull())
                {
                    return CombinedTypeContainer.FalseInstance;
                }

                if (item.Type != typeof(bool))
                {
                    return CombinedTypeContainer.FalseInstance;
                }

                if (!item.Bool)
                {
                    return CombinedTypeContainer.FalseInstance;
                }
            }

            return CombinedTypeContainer.TrueInstance;
        }
    }
}

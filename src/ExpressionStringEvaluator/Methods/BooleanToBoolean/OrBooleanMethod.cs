namespace ExpressionStringEvaluator.Methods.BooleanToBoolean
{
    using System;

    public class OrBooleanMethod : MethodBase, IMethod
    {
        public bool CanHandle(string method)
        {
            return IsMethod(method, "Or", "Any");
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            ExpectAtLeastArgumentCount(1, arg);

            foreach (var item in arg)
            {
                if (!item.IsNull() && item.Type == typeof(bool) && item.Bool)
                {
                    return CombinedTypeContainer.TrueInstance;
                }
            }

            return CombinedTypeContainer.FalseInstance;
        }
    }
}

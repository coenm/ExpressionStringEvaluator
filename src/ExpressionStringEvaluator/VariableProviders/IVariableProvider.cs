using System.Collections.Generic;

namespace ExpressionStringEvaluator.VariableProviders
{
    public interface IVariableProvider
    {
        bool CanProvide(string key);

        string Provide(Context context, string key, string arg);

        IEnumerable<VariableDescription> Get();
    }
}
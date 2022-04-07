using System.Collections.Generic;
using ExpressionStringEvaluator.VariableProviders;

namespace ExpressionStringEvaluator
{
    public interface IVariableProviderFactory
    {
        IEnumerable<IVariableProvider> CreateVariableProviders();
    }
}
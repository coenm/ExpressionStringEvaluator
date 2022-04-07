namespace ExpressionStringEvaluator
{
    using System.Collections.Generic;
    using ExpressionStringEvaluator.VariableProviders;

    public interface IVariableProviderFactory
    {
        IEnumerable<IVariableProvider> CreateVariableProviders();
    }
}
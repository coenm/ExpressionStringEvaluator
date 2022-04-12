namespace ExpressionStringEvaluator.Methods;

/// <summary>
/// IMethod.
/// </summary>
public interface IMethod
{
    /// <summary>
    /// CanHandle.
    /// </summary>
    /// <param name="method">Name of method.</param>
    /// <returns><c>true</c> when it can handle. <c>false</c> otherwise.</returns>
    bool CanHandle(string method);

    /// <summary>
    /// Handle.data.
    /// </summary>
    /// <param name="method">Name of the method.</param>
    /// <param name="args">arguments.</param>
    /// <returns>Result.</returns>
    CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args);
}

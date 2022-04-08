namespace ExpressionStringEvaluator.VariableProviders;

/// <summary>
/// Variable description.
/// </summary>
public readonly struct VariableDescription
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VariableDescription"/> struct.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="description">Description.</param>
    public VariableDescription(string key, string description)
    {
        Key = key;
        Description = description;
    }

    /// <summary>
    /// Gets key.
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// Gets description.
    /// </summary>
    public string Description { get; }
}
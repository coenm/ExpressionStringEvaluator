namespace ExpressionStringEvaluator.VariableProviders.DateTime;

using System;

/// <summary>
/// DateTimeVariableProviderOptions.
/// </summary>
public class DateTimeVariableProviderOptions
{
    /// <summary>
    /// Gets or sets default format when none is given.
    /// </summary>
    public string? DefaultFormat { get; set; }

    /// <summary>
    /// Gets or sets factory method to provide the DateTime.
    /// </summary>
    public Func<DateTime>? DateTimeProvider { get; set; }
}
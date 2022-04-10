namespace ExpressionStringEvaluator.VariableProviders.DateTime;

using System;

public class DateTimeVariableProviderOptions
{
    public string? DefaultFormat { get; set; }

    public Func<DateTime>? DateTimeProvider { get; set; }
}
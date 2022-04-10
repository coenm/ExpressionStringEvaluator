namespace ExpressionStringEvaluator.VariableProviders.DateTime;

using System;

public class DateTimeNowVariableProviderOptions
{
    public string? DefaultFormat { get; set; }

    public Func<DateTime>? DateTimeProvider { get; set; }
}
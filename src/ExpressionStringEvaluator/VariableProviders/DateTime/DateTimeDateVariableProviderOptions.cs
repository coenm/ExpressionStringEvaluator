namespace ExpressionStringEvaluator.VariableProviders.DateTime;

using System;

public class DateTimeDateVariableProviderOptions
{
    public string? DefaultFormat { get; set; }

    public Func<DateTime>? DateTimeProvider { get; set; }
}
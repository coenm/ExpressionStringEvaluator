namespace ExpressionStringEvaluator.VariableProviders.DateTime;

using System;
using System.Collections.Generic;
using ExpressionStringEvaluator.Formatters;

/// <inheritdoc cref="IVariableProvider"/>
public class DateTimeDateVariableProvider : IVariableProvider
{
    private const string KEY = "Date";
    private readonly IDateTimeFormatter _formatter;

    public DateTimeDateVariableProvider(IDateTimeFormatter formatter)
    {
        _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
    }

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public string? Provide(Context context, string key, string? arg)
    {
        return _formatter.FormatDate(context.Now, context, arg);
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, "Now, formatted as date.");
    }
}
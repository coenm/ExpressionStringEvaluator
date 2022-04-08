namespace ExpressionStringEvaluator.VariableProviders.DateTime;

using System;
using System.Collections.Generic;
using ExpressionStringEvaluator.Formatters;

/// <inheritdoc cref="IVariableProvider"/>
public class DateTimeTimeVariableProvider : IVariableProvider
{
    private const string KEY = "Time";
    private readonly IDateTimeFormatter _formatter;

    public DateTimeTimeVariableProvider(IDateTimeFormatter formatter)
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
        return _formatter.FormatTime(context.Now, context, arg);
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, "Now, formatted as time.");
    }
}
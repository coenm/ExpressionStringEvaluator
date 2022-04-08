namespace ExpressionStringEvaluator.VariableProviders.DateTime;

using System;
using System.Collections.Generic;
using System.Globalization;

/// <inheritdoc cref="IVariableProvider"/>
public class DateTimeTimeVariableProvider : IVariableProvider
{
    private const string DEFAULT_FORMAT_TIME = "HH.mm.ss";
    private const string KEY = "Time";
    private readonly DateTimeVariableProviderOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeTimeVariableProvider"/> class.
    /// </summary>
    /// <param name="options">options.</param>
    /// <exception cref="ArgumentNullException">Thrown when argument is null.</exception>
    public DateTimeTimeVariableProvider(DateTimeVariableProviderOptions options)
    {
        _options = options;
    }

    /// <inheritdoc cref="IVariableProvider.CanProvide"/>
    public bool CanProvide(string key)
    {
        return KEY.Equals(key, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <inheritdoc cref="IVariableProvider.Provide"/>
    public string? Provide(string key, string? arg)
    {
        DateTime now = _options.DateTimeProvider?.Invoke() ?? DateTime.Now;
        var format = _options.DefaultFormat ?? DEFAULT_FORMAT_TIME;

        if (!string.IsNullOrWhiteSpace(arg))
        {
            format = arg;
        }

        return now.ToString(format, CultureInfo.CurrentUICulture);
    }

    /// <inheritdoc cref="IVariableProvider.Get"/>
    public IEnumerable<VariableDescription> Get()
    {
        yield return new VariableDescription(KEY, "Now, formatted as time.");
    }
}
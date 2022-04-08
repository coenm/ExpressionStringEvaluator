[assembly: System.CLSCompliant(true)]

namespace ExpressionStringEvaluator;

/// <summary>
/// DefaultFormats.
/// </summary>
public readonly struct DefaultFormats
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultFormats"/> struct.
    /// </summary>
    /// <param name="dateTimeFormat">dateTimeFormat.</param>
    /// <param name="dateFormat">dateFormat.</param>
    /// <param name="timeFormat">timeFormat.</param>
    public DefaultFormats(string dateTimeFormat, string dateFormat, string timeFormat)
    {
        DateTimeFormat = dateTimeFormat;
        DateFormat = dateFormat;
        TimeFormat = timeFormat;
    }

    /// <summary>
    /// Gets DateTimeFormat.
    /// </summary>
    public string DateTimeFormat { get; }

    /// <summary>
    /// Gets DateFormat.
    /// </summary>
    public string DateFormat { get; }

    /// <summary>
    /// Gets TimeFormat.
    /// </summary>
    public string TimeFormat { get; }
}
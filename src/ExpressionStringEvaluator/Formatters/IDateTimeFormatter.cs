namespace ExpressionStringEvaluator.Formatters;

using System;

/// <summary>
/// IDateTimeFormatter.
/// </summary>
public interface IDateTimeFormatter
{
    /// <summary>
    /// FormatDateTime.
    /// </summary>
    /// <param name="dateTime">dateTime.</param>
    /// <param name="context">context.</param>
    /// <param name="format">format.</param>
    /// <returns>string.</returns>
    string FormatDateTime(DateTime dateTime, Context context, string? format = null);

    /// <summary>
    /// FormatDate.
    /// </summary>
    /// <param name="dateTime">dateTime.</param>
    /// <param name="context">context.</param>
    /// <param name="format">format.</param>
    /// <returns>string.</returns>
    string FormatDate(DateTime dateTime, Context context, string? format = null);

    /// <summary>
    /// FormatTime.
    /// </summary>
    /// <param name="dateTime">dateTime.</param>
    /// <param name="context">context.</param>
    /// <param name="format">format.</param>
    /// <returns>string.</returns>
    string FormatTime(DateTime dateTime, Context context, string? format = null);
}
namespace ExpressionStringEvaluator.Methods;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

/// <summary>
/// CombinedTypeContainer.
/// </summary>
public class CombinedTypeContainer
{
    private readonly bool _isNull;
    private readonly Type? _type;
    private readonly string? _string;
    private readonly bool? _bool;
    private readonly int? _int;

    /// <summary>
    /// Initializes a new instance of the <see cref="CombinedTypeContainer"/> class.
    /// </summary>
    /// <param name="s">value.</param>
    public CombinedTypeContainer(string? s)
    {
        _string = s;
        _type = typeof(string);
        Items = Array.Empty<CombinedTypeContainer>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CombinedTypeContainer"/> class.
    /// </summary>
    /// <param name="b">value.</param>
    public CombinedTypeContainer(bool b)
    {
        _bool = b;
        _type = typeof(bool);
        Items = Array.Empty<CombinedTypeContainer>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CombinedTypeContainer"/> class.
    /// </summary>
    /// <param name="i">value.</param>
    public CombinedTypeContainer(int i)
    {
        _int = i;
        _type = typeof(int);
        Items = Array.Empty<CombinedTypeContainer>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CombinedTypeContainer"/> class.
    /// </summary>
    /// <param name="array">value.</param>
    public CombinedTypeContainer(CombinedTypeContainer[] array)
    {
        Items = array;
        _type = typeof(CombinedTypeContainer[]);
    }

    private CombinedTypeContainer()
    {
        _isNull = true;
        Items = Array.Empty<CombinedTypeContainer>();
    }

    /// <summary>
    /// Gets NullInstance.
    /// </summary>
    public static CombinedTypeContainer NullInstance { get; } = new CombinedTypeContainer();

    /// <summary>
    /// Gets TrueInstance.
    /// </summary>
    public static CombinedTypeContainer TrueInstance { get; } = new CombinedTypeContainer(true);

    /// <summary>
    /// Gets FalseInstance.
    /// </summary>
    public static CombinedTypeContainer FalseInstance { get; } = new CombinedTypeContainer(false);

    /// <summary>
    /// Gets Items.
    /// </summary>
    public CombinedTypeContainer[] Items { get; }

    /// <summary>
    /// IsNull.
    /// </summary>
    /// <returns>bool.</returns>
    public bool IsNull()
    {
        return _isNull;
    }

    /// <inheritdoc cref="object.ToString"/>
    public override string ToString()
    {
        if (_isNull)
        {
            return string.Empty;
        }

        if (IsString(out var s))
        {
            return s! ?? string.Empty;
        }

        if (IsBool(out var b))
        {
            return b.Value ? "true" : "false";
        }

        if (IsInt(out var i))
        {
            return i.Value.ToString();
        }

        if (_type == typeof(CombinedTypeContainer[]))
        {
            if (Items.Length == 0)
            {
                return string.Empty;
            }

            if (Items.Length == 1)
            {
                return Items[0].ToString();
            }

            return string.Join(",", Items.AsEnumerable());
        }

        throw new NotImplementedException();
    }

    /// <summary>
    /// Get inner type.
    /// </summary>
    /// <returns>Type of the inner type.</returns>
    public Type? GetInnerType()
    {
        return _type;
    }

    /// <summary>
    /// Is array.
    /// </summary>
    /// <param name="value">value.</param>
    /// <returns>bool.</returns>
    public bool IsArray([NotNullWhen(true)] out CombinedTypeContainer[]? value)
    {
        if (_type != null && _type == typeof(CombinedTypeContainer[]))
        {
            value = Items;
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>
    /// Is string.
    /// </summary>
    /// <param name="value">value.</param>
    /// <returns>bool.</returns>
    public bool IsString([NotNullWhen(true)] out string? value)
    {
        if (_type != null && _type == typeof(string))
        {
            value = _string!;
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>
    /// Is boolean.
    /// </summary>
    /// <param name="value">value.</param>
    /// <returns>bool.</returns>
    public bool IsBool([NotNullWhen(true)] out bool? value)
    {
        if (_type != null && _type == typeof(bool))
        {
            value = _bool!.Value;
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>
    /// Is integer.
    /// </summary>
    /// <param name="value">value.</param>
    /// <returns>bool.</returns>
    public bool IsInt([NotNullWhen(true)] out int? value)
    {
        if (_type != null && _type == typeof(int))
        {
            value = _int!.Value;
            return true;
        }

        value = null;
        return false;
    }
}
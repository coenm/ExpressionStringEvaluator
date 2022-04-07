using System;
using System.Linq;

namespace Core.Methods;

public class CombinedTypeContainer
{
    private bool _isNull = false;

    private CombinedTypeContainer()
    {
        _isNull = true;
    }

    public CombinedTypeContainer(string s)
    {
        String = s;
        Type = typeof(string);
    }

    public CombinedTypeContainer(bool b)
    {
        Bool = b;
        Type = typeof(bool);
    }

    public CombinedTypeContainer(int i)
    {
        Int = i;
        Type = typeof(int);
    }

    public CombinedTypeContainer(CombinedTypeContainer[] array)
    {
        Items = array;
        Type = typeof(CombinedTypeContainer[]);
    }

    public CombinedTypeContainer[] Items { get; }

    public Type Type { get; }

    public string String { get; set; }

    public bool Bool { get; set; }

    public int Int { get; set; }

    public static CombinedTypeContainer NullInstance { get; } = new CombinedTypeContainer();

    public bool IsNull() => _isNull;

    public override string ToString()
    {
        if (_isNull)
        {
            return string.Empty;
        }

        if (Type == typeof(string))
        {
            return String ?? string.Empty;
        }

        if (Type == typeof(bool))
        {
            return Bool ? "true" : "false";
        }

        if (Type == typeof(int))
        {
            return Int.ToString();
        }

        if (Type == typeof(CombinedTypeContainer[]))
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


        throw new Exception();
    }
}

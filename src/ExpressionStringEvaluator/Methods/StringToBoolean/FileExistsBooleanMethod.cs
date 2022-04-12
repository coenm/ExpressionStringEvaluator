namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;
using System.IO;

/// <summary>
/// FileExistsBooleanMethod.
/// </summary>
public class FileExistsBooleanMethod : MethodBase, IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return IsMethod(method, "FileExists");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);

        var filename = ExpectString(args[0]);

        return new CombinedTypeContainer(File.Exists(filename));
    }
}
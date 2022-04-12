namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;
using System.IO;

/// <summary>
/// FileExistsBooleanMethod.
/// </summary>
public class FileExistsBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodBase.IsMethod(method, "FileExists");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        MethodBase.ExpectArgumentCount(1, args);

        var filename = MethodBase.ExpectString(args[0]);

        return new CombinedTypeContainer(File.Exists(filename));
    }
}
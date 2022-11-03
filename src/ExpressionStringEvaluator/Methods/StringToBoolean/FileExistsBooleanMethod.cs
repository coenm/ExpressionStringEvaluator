namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System.IO;

/// <summary>
/// FileExistsBooleanMethod.
/// </summary>
public class FileExistsBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "FileExists", "File.Exists");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);

        var filename = MethodHelpers.ExpectString(args[0]);

        return File.Exists(filename);
    }
}
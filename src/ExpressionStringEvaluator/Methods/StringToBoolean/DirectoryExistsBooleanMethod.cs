namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System.IO;

/// <summary>
/// DirectoryExistsBooleanMethod.
/// </summary>
public class DirectoryExistsBooleanMethod : IMethod
{
    /// <inheritdoc cref="IMethod.CanHandle"/>
    public bool CanHandle(string method)
    {
        return MethodHelpers.IsMethod(method, "DirectoryExists", "Directory.Exists");
    }

    /// <inheritdoc cref="IMethod.Handle"/>
    public object? Handle(string method, params object?[] args)
    {
        MethodHelpers.ExpectArgumentCount(1, args);
        var directory = MethodHelpers.ExpectString(args[0]);
        return Directory.Exists(directory);
    }
}
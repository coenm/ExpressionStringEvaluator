namespace ExpressionStringEvaluator.Methods.StringToBoolean;

using System;
using System.IO;

public class FileExistsBooleanMethod : MethodBase, IMethod
{
    public bool CanHandle(string method)
    {
        return IsMethod(method, "FileExists");
    }

    public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] args)
    {
        ExpectArgumentCount(1, args);

        var filename = ExpectString(args[0]);

        return new CombinedTypeContainer(File.Exists(filename));
    }
}
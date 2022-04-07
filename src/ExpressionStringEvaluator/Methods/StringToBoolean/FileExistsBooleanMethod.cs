namespace ExpressionStringEvaluator.Methods.StringToBoolean
{
    using System;
    using System.IO;

    public class FileExistsBooleanMethod : IMethod
    {
        public bool CanHandle(string method)
        {
            return "FileExists".Equals(method, StringComparison.InvariantCultureIgnoreCase);
        }

        public CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg)
        {
            if (arg.Length == 0)
            {
                throw new Exception();
            }

            if (arg.Length > 1)
            {
                throw new Exception();
            }

            return new CombinedTypeContainer(File.Exists(arg[0].ToString()));
        }
    }
}

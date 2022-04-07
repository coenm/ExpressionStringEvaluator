namespace ExpressionStringEvaluator.Methods
{
    using System;
    using System.Linq;

    public abstract class MethodBase
    {
        public bool IsMethod(string method, params string[] compareTo)
        {
            if (compareTo == null)
            {
                return false;
            }

            return compareTo.Any(item => item.Equals(method, StringComparison.CurrentCultureIgnoreCase));
        }

        public void ExpectArgumentCount(int expectCount, params CombinedTypeContainer[] arg)
        {
            if (arg.Length != expectCount)
            {
                throw new Exception($"Expected {expectCount} arguments but found {arg.Length}.");
            }
        }

        public int ExpectAtLeastArgumentCount(int expectCount, params CombinedTypeContainer[] arg)
        {
            if (arg.Length < expectCount)
            {
                throw new Exception($"Expected at least {expectCount} arguments but found {arg.Length}.");
            }

            return arg.Length;
        }

        public int ExpectAtMostArgumentCount(int expectCount, params CombinedTypeContainer[] arg)
        {
            if (arg.Length > expectCount)
            {
                throw new Exception($"Expected at most {expectCount} arguments but found {arg.Length}.");
            }

            return arg.Length;
        }

        public string ExpectString(CombinedTypeContainer arg)
        {
            if (arg.IsNull())
            {
                throw new Exception($"Expected string type but but found null.");
            }

            if (arg.Type != typeof(string))
            {
                throw new Exception($"Expected string type but but found {arg.Type.Name}.");
            }

            return arg.String;
        }

        public string ExpectSingleString(CombinedTypeContainer[] args)
        {
            ExpectArgumentCount(1, args);
            return ExpectString(args[0]);
        }

        public void ExpectStrings(CombinedTypeContainer[] arg)
        {
            foreach (var a in arg)
            {
                ExpectString(a);
            }
        }

        public bool ExpectBoolean(CombinedTypeContainer arg)
        {
            if (arg.Type != typeof(bool))
            {
                throw new Exception($"Expected boolean type but but found {arg.Type.Name}.");
            }

            return arg.Bool;
        }

        public void ExpectNotNull(CombinedTypeContainer[] args)
        {
            if (args.Any(item => item == null))
            {
                throw new Exception("Expected all items not to be null.");
            }
        }
    }
}

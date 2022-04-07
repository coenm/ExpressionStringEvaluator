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


        public void ExpectAtLeastArgumentCount(int expectCount, params CombinedTypeContainer[] arg)
        {
            if (arg.Length < expectCount)
            {
                throw new Exception($"Expected at least {expectCount} arguments but found {arg.Length}.");
            }
        }

        public void ExpectBoolean(CombinedTypeContainer arg)
        {
            if (arg.Type != typeof(bool))
            {
                throw new Exception($"Expected boolean type but but found {arg.Type.Name}.");
            }
        }
    }
}

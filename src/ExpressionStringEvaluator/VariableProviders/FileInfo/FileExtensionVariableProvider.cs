using System;
using System.Collections.Generic;

namespace ExpressionStringEvaluator.VariableProviders.FileInfo
{
    public class FileExtensionVariableProvider : IVariableProvider
    {
        private const string KEY = "FileExtension";

        public bool CanProvide(string key)
        {
            return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
        }

        public string Provide(Context context, string key, string arg)
        {
            return context.FileInfo.Extension;
        }

        public IEnumerable<VariableDescription> Get()
        {
            yield return new VariableDescription(KEY, "Extension (including the . (dot)) of the input file.");
        }
    }
}
using System;
using System.Collections.Generic;
using ExpressionStringEvaluator.Formatters;

namespace ExpressionStringEvaluator.VariableProviders.DateTime
{
    public class DateTimeNowVariableProvider : IVariableProvider
    {
        private const string KEY = "Now";
        private readonly IDateTimeFormatter _formatter;

        public DateTimeNowVariableProvider(IDateTimeFormatter formatter)
        {
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        public bool CanProvide(string key)
        {
            return KEY.Equals(key, StringComparison.CurrentCultureIgnoreCase);
        }

        public string Provide(Context context, string key, string arg)
        {
            return _formatter.FormatDateTime(context.Now, context, arg);
        }

        public IEnumerable<VariableDescription> Get()
        {
            yield return new VariableDescription(KEY, "Now, formatted as date time.");
        }
    }
}
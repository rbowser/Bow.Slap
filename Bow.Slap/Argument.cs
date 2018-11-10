using System;
using System.Linq;

namespace Bow.Slap
{
    public class Argument<T>
    {
        private string _name = string.Empty;
        private string _short = string.Empty;
        private string _long = string.Empty;
        private string _description = string.Empty;
        private Func<T, bool> _isValid = _ => true;

        public Argument(string name)
        {
            if (!Utils.IsSimpleType(typeof(T)))
                // TODO better error message
                throw new InvalidOperationException($"Arguments do not support {typeof(T)}.");
            _name = name;
        }

        public Argument<T> Description(string arg)
        {
            _description = arg;
            return this;
        }

        public Argument<T> Long(string arg)
        {
            _long = arg;
            return this;
        }

        public Argument<T> Short(string arg)
        {
            _short = arg;
            return this;
        }

        public Argument<T> Values(params T[] values)
        {
            _isValid = arg => values.Any(v => v.Equals(arg));
            return this;
        }

        public Argument<T> ValidityCheck(Func<T, bool> isValid)
        {
            _isValid = isValid;
            return this;
        }
    }
}

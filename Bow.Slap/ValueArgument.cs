using Bow.Slap.Interfaces;
using System;
using System.Linq;

namespace Bow.Slap
{
    class ValueArgument<T> : IArgument<T>
    {
        public string Name { get; private set; }
        public string Short { get; private set; } = string.Empty;
        public string Long { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public Func<T, bool> IsValid { get; private set; } = _ => true;

        public ValueArgument(string name)
        {
            if (!Utils.IsSimpleType(typeof(T)))
                // TODO better error message
                throw new InvalidOperationException($"Arguments do not support {typeof(T)}.");
            Name = name;
        }

        public ValueArgument<T> SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public ValueArgument<T> SetLong(string @long)
        {
            Long = @long;
            return this;
        }

        public ValueArgument<T> SetShort(string @short)
        {
            Short = @short;
            return this;
        }

        public ValueArgument<T> ValidValues(params T[] values)
        {
            IsValid = arg => values.Any(v => v.Equals(arg));
            return this;
        }

        public ValueArgument<T> ValidityCheck(Func<T, bool> isValid)
        {
            IsValid = isValid;
            return this;
        }
    }
}

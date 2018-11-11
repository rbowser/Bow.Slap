using Bow.Slap.Interfaces;
using System;
using System.Linq;

namespace Bow.Slap
{
    public class ValueArgument : IArgument
    {
		public Type Type { get; }
		public string Name { get; private set; } = string.Empty;
        public string Short { get; private set; } = string.Empty;
        public string Long { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public Func<object, bool> IsValid { get; private set; } = _ => true;

        public ValueArgument(Type type)
        {
            if (!Utils.IsSupportedType(type))
                // TODO better error message
                throw new InvalidOperationException($"Arguments do not support {type}.");
            Type = type;
        }

		public ValueArgument SetName(string name)
		{
			Name = name;
			return this;
		}

        public ValueArgument SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public ValueArgument SetLong(string @long)
        {
            Long = @long;
            return this;
        }

        public ValueArgument SetShort(string @short)
        {
            Short = @short;
            return this;
        }

        public ValueArgument ValidValues(params object[] values)
        {
			if (values.Any(v => v.GetType() != Type)) throw new InvalidOperationException("Type of values don't match type of parameter.");

            IsValid = arg => values.Any(v => v.Equals(arg));
            return this;
        }

        //public ValueArgument ValidityCheck(Func<object, bool> isValid)
        //{
        //    IsValid = isValid;
        //    return this;
        //}
    }
}

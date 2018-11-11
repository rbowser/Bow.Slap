using System;
using Bow.Slap.Interfaces;

namespace Bow.Slap
{
    public class Switch : IArgument
    {
		public Type Type => typeof(bool);
		public string Name { get; private set; } = string.Empty;
        public string Short { get; private set; } = string.Empty;
        public string Long { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

		public Switch SetName(string name)
		{
			Name = name;
			return this;
		}

        public Switch SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public Switch SetLong(string @long)
        {
            Long = @long;
            return this;
        }

        public Switch SetShort(string @short)
        {
            Short = @short;
            return this;
        }
    }
}

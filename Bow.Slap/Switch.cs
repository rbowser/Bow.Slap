using Bow.Slap.Interfaces;

namespace Bow.Slap
{
    class Switch : IArgument<bool>
    {
        public string Name { get; private set; }
        public string Short { get; private set; } = string.Empty;
        public string Long { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public Switch(string name)
        {
            Name = name;
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

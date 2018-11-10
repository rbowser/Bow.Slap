using Bow.Slap.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bow.Slap
{
    class Switch : IArgument<bool>
    {
        public string Name { get; private set; } = string.Empty;
        public string Short { get; private set; } = string.Empty;
        public string Long { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public Switch(string name)
        {
            Name = name;
        }

        public Switch SetDescription(string arg)
        {
            Description = arg;
            return this;
        }

        public Switch SetLong(string arg)
        {
            Long = arg;
            return this;
        }

        public Switch SetShort(string arg)
        {
            Short = arg;
            return this;
        }
    }
}

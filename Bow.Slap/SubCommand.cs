using System.Collections;
using System.Collections.Generic;
using Bow.Slap.Interfaces;

namespace Bow.Slap
{
	class SubCommand
	{
		public string Name { get; private set; } = string.Empty;
		public string Command { get; private set; } = string.Empty;
		public List<object> _arguments = new List<object>();

		public IEnumerable<object> Arguments
		{
			get { return _arguments; }
		}

		public SubCommand(string name)
		{
			Name = name;
		}

		public SubCommand SetCommand(string arg)
		{
			Command = arg;
			return this;
		}

		public SubCommand Argument<T>(IArgument<T> arg)
		{
			_arguments.Add((arg, typeof(T)));
			return this;
		}
	}
}

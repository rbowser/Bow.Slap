using System.Collections.Generic;
using Bow.Slap.Interfaces;

namespace Bow.Slap
{
	class SubCommand
	{
		private List<object> _arguments = new List<object>();

		public string Name { get; private set; }
		public string Command { get; private set; } = string.Empty;
		public IEnumerable<object> Arguments
		{
			get { return _arguments; }
		}

		public SubCommand(string name)
		{
			Name = name;
		}

		public SubCommand SetCommand(string command)
		{
			Command = command;
			return this;
		}

		public SubCommand Argument<T>(IArgument<T> argument)
		{
			_arguments.Add((argument, typeof(T)));
			return this;
		}
	}
}

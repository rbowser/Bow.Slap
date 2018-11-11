using System;
using System.Collections.Generic;
using System.Linq;
using Bow.Slap.Interfaces;

namespace Bow.Slap
{
	class Application
	{
		private List<object> _arguments = new List<object>();
		private List<SubCommand> _subCommands = new List<SubCommand>();

		public string Name { get; }
		public string Version { get; private set; } = string.Empty;
		public string Author { get; private set; } = string.Empty;
		public IEnumerable<object> Arguments { get { return _arguments; } }
		public IEnumerable<SubCommand> SubCommands { get { return _subCommands; } }

		public Application(string name)
		{
			Name = name;
		}

		public Application SetVersion(string version)
		{
			Version = version;
			return this;
		}

		public Application SetAuthor(string author)
		{
			Author = author;
			return this;
		}

		public Application Argument<T>(IArgument<T> argument)
		{
			if (_subCommands.Any()) throw new InvalidOperationException("Cannot add arguments with subcommands.");

			_arguments.Add((argument, typeof(T)));
			return this;
		}

		public Application SubCommand(SubCommand subCommand)
		{
			if (_arguments.Any()) throw new InvalidOperationException("Cannot add subcommands with arguments");

			_subCommands.Add(subCommand);
			return this;
		}
	}
}

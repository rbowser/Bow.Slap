using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Bow.Slap.Interfaces;

namespace Bow.Slap
{
	public class Application
	{
		private List<IArgument> _arguments = new List<IArgument>();
		private List<SubCommand> _subCommands = new List<SubCommand>();

		public string Name { get; }
		public string Version { get; private set; } = string.Empty;
		public string Author { get; private set; } = string.Empty;
		public IEnumerable<IArgument> Arguments { get { return _arguments; } }
		public IEnumerable<SubCommand> SubCommands { get { return _subCommands; } }
		public Configuration Configuration { get; private set; } = Configuration.Default;

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

		public Application Argument(IArgument argument)
		{
			if (_subCommands.Any()) throw new InvalidOperationException("Cannot add arguments with subcommands.");

			_arguments.Add(argument);
			return this;
		}

		public Application SubCommand(SubCommand subCommand)
		{
			if (_arguments.Any()) throw new InvalidOperationException("Cannot add subcommands with arguments");

			_subCommands.Add(subCommand);
			return this;
		}

		public Application SetConfiguration(Configuration configuration)
		{
			Configuration = configuration;
			return this;
		}

		public dynamic Parse(string[] args)
		{
			var parser = new Parser(Configuration);
			return _arguments.Any() ? parser.Parse(args, _arguments) : parser.Parse(args, _subCommands);
		}
	}
}

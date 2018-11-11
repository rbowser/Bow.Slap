using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Bow.Slap.Interfaces;

namespace Bow.Slap
{
	class Parser
	{
		private Configuration _config;

		public Parser(Configuration config)
		{
			_config = config;
		}

		public dynamic Parse(string[] args, IEnumerable<IArgument> arguments)
		{
			var obj = new ExpandoObject() as IDictionary<string, object>;
			foreach (var arg in arguments)
				obj.Add(arg.Name, Utils.GetDefault(arg.Type));
			
			int i = 0;
			while (i < args.Length)
			{
				var declaredArg = arguments.First(a => a.Short == args[i]);
				if (declaredArg is Switch)
				{
					obj[declaredArg.Name] = true;
				}
				else
				{
					//TODO Error handling
					i++;
					var arg = Convert(args[i], declaredArg.Type);
					obj[declaredArg.Name] = arg;
				}

				i++;
			}
			
			return obj;
		}

		public dynamic Parse(string[] args, IEnumerable<SubCommand> subCommands)
		{
			throw new NotImplementedException();
		}

		private object Convert(string arg, Type type)
		{
			if (type == typeof(Guid))
				return new Guid(arg);

			if (type == typeof(DateTime))
				return DateTime.Parse(arg);

			return System.Convert.ChangeType(arg, type);
		}
	}
}

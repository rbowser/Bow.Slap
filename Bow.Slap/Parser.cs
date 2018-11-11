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
			int i = 0;
			while (i < args.Length)
			{
				var declaredArg = arguments.First(a => a.Short == args[i]);
				if (declaredArg is Switch)
				{
					obj.Add(declaredArg.Name, true);
				}
				else
				{
					i++;
					var arg = Convert.ChangeType(args[i], declaredArg.Type);
					obj.Add(declaredArg.Name, arg);
				}

				i++;
			}
			
			return obj;
		}

		public dynamic Parse(string[] args, IEnumerable<SubCommand> subCommands)
		{
			throw new NotImplementedException();
		}
	}
}

using System;

namespace Bow.Slap.Interfaces
{
	public interface IArgument
	{
		Type Type { get; }
		string Name { get; }
		string Short { get; }
		string Long { get; }
		string Description { get; }
	}
}

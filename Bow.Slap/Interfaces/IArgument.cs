namespace Bow.Slap.Interfaces
{
	public interface IArgument<T>
	{
		string Name { get; }
		string Short { get; }
		string Long { get; }
		string Description { get; }
	}
}

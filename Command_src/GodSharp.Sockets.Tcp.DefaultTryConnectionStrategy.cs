using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets.Tcp;

public class DefaultTryConnectionStrategy : ITryConnectionStrategy
{
	public int Handle(int counter)
	{
		return counter % 20 * 3000;
	}

	static DefaultTryConnectionStrategy()
	{
		Class72.smethod_20();
	}
}

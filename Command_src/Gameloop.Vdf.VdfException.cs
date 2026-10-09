using System;

namespace Gameloop.Vdf;

public sealed class VdfException : Exception
{
	public VdfException(string message)
		: base(message)
	{
	}

	static VdfException()
	{
		Class72.smethod_20();
	}
}

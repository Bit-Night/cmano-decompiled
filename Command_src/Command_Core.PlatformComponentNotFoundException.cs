using System;

namespace Command_Core;

public sealed class PlatformComponentNotFoundException : Exception
{
	public PlatformComponentNotFoundException(string ExMessage)
		: base(ExMessage)
	{
	}

	public PlatformComponentNotFoundException()
	{
	}

	static PlatformComponentNotFoundException()
	{
		Class72.smethod_20();
	}
}

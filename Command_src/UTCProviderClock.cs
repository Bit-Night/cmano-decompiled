using System;
using Microsoft.Extensions.Internal;

public class UTCProviderClock : ISystemClock
{
	public DateTimeOffset UtcNow => UtcProvider.UtcNow;

	static UTCProviderClock()
	{
		Class72.smethod_20();
	}
}

using System;

namespace Zeptomoby.OrbitTools;

public interface IEciObject
{
	string Name { get; }

	EciTime PositionEci(DateTimeOffset time);

	[Obsolete("Use oveloaded method PositionEci(DateTimeOffset)")]
	EciTime PositionEci(DateTime utc);
}

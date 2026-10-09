using Command_Core.SmartAssembly.Attributes;

namespace Command_Core;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
public class LandingZoneWrapper
{
	public Zone LandingZone;

	public LandingType LandingZoneType;

	public LandingZoneWrapper(Zone _LandingZone, LandingType _LandingZoneType)
	{
		LandingZone = _LandingZone;
		LandingZoneType = _LandingZoneType;
	}

	static LandingZoneWrapper()
	{
		Class72.smethod_20();
	}
}

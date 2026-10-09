using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission;

[Serializable]
public enum EmissionBeamFunction : byte
{
	[Description("Other.")]
	Other,
	[Description("Search.")]
	Search,
	[Description("Height finder.")]
	HeightFinder,
	[Description("Acquisition.")]
	Acquisition,
	[Description("Tracking.")]
	Tracking,
	[Description("Acquisition and tracking.")]
	AcquisitionAndTracking,
	[Description("Command guidance.")]
	CommandGuidance,
	[Description("Illumination.")]
	Illumination,
	[Description("Range only radar.")]
	RangeOnlyRadar,
	[Description("Missile beacon.")]
	MissileBeacon,
	[Description("Missile fuze.")]
	MissileFuze,
	[Description("Active radar missile seeker.")]
	ActiveRadarMissileSeeker,
	[Description("Jammer.")]
	Jammer,
	[Description("IFF.")]
	IFF,
	[Description("Navigational / Weather.")]
	NavigationalWeather,
	[Description("Meteorological.")]
	Meteorological,
	[Description("Data transmission.")]
	DataTransmission,
	[Description("Navigational directional beacon.")]
	NavigationalDirectionalBeacon
}

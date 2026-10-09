using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic;

[Serializable]
public enum EmitterFunction : byte
{
	[Description("Other.")]
	Other,
	[Description("Platform search/detect/track.")]
	PlatformSearchDetectTrack,
	[Description("Navigation.")]
	Navigation,
	[Description("Mine hunting.")]
	MineHunting,
	[Description("Weapon search/detect/track/detect.")]
	WeaponSearchDetectTrackDetect
}

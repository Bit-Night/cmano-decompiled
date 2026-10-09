using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
[Flags]
public enum DataFilter : uint
{
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	GroundBurialDepthOffset = 1u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	WaterBurialDepthOffset = 2u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	SnowBurialDepthOffset = 4u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	MineOrientation = 8u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	ThermalContrast = 0x10u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	Reflectance = 0x20u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	MineEmplacementAge = 0x40u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	TripDetonationWire = 0x80u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	Fusing = 0x100u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	ScalarDetectionCoefficient = 0x200u,
	[Description("Set bit means 'Data is requested / present', reset bit means 'Data not requested / present'.")]
	PaintScheme = 0x400u
}

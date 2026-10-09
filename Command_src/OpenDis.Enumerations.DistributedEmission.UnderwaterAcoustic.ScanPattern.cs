using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic;

[Serializable]
public enum ScanPattern : ushort
{
	[Description("Scan pattern not used.")]
	ScanPatternNotUsed,
	[Description("Conical.")]
	Conical,
	[Description("Helical.")]
	Helical,
	[Description("Raster.")]
	Raster,
	[Description("Sector search.")]
	SectorSearch,
	[Description("Continuous search.")]
	ContinuousSearch
}

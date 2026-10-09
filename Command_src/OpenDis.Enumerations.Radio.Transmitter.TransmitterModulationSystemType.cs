using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum TransmitterModulationSystemType : ushort
{
	[Description("Other.")]
	Other,
	[Description("Generic.")]
	Generic,
	[Description("HQ.")]
	HQ,
	[Description("HQII.")]
	HQII,
	[Description("HQIIA.")]
	HQIIA,
	[Description("SINCGARS.")]
	SINCGARS,
	[Description("CCTT SINCGARS.")]
	CCTTSINCGARS,
	[Description("EPLRS (Enhanced Position Location Reporting System).")]
	EPLRS,
	[Description("JTIDS/MIDS.")]
	JTIDS_MIDS
}

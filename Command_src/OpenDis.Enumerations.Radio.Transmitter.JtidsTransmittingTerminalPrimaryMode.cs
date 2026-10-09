using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum JtidsTransmittingTerminalPrimaryMode : byte
{
	[Description("NTR.")]
	NTR = 1,
	[Description("JTIDS Unit Participant.")]
	const_1
}

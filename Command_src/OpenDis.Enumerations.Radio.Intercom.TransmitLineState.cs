using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Intercom;

[Serializable]
public enum TransmitLineState : byte
{
	[Description("Transmit Line State not applicable.")]
	TransmitLineStateNotApplicable,
	[Description("Not Transmitting.")]
	NotTransmitting,
	[Description("Transmitting.")]
	Transmitting
}

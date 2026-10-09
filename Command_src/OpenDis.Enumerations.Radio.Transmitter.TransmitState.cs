using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum TransmitState : byte
{
	[Description("Off.")]
	Off,
	[Description("On but not transmitting.")]
	OnButNotTransmitting,
	[Description("On and transmitting.")]
	OnAndTransmitting
}

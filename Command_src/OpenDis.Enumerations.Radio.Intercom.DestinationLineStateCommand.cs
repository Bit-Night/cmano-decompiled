using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Intercom;

[Serializable]
public enum DestinationLineStateCommand : byte
{
	[Description("None.")]
	None,
	[Description("Set Line State - Transmitting.")]
	SetLineStateTransmitting,
	[Description("Set Line State - Not Transmitting.")]
	SetLineStateNotTransmitting,
	[Description("Return to Local Line State Control.")]
	ReturnToLocalLineStateControl
}

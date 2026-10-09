using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum JtidsTransmittingTerminalSecondaryMode : byte
{
	[Description("None.")]
	None,
	[Description("Net Position Reference.")]
	NetPositionReference,
	[Description("Primary Navigation Controller.")]
	PrimaryNavigationController,
	[Description("Secondary Navigation Controller.")]
	SecondaryNavigationController
}

using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Intercom;

[Serializable]
public enum CommunicationsType : uint
{
	[Description("Connection FDX.")]
	ConnectionFDX = 1u,
	[Description("Connection HDX - Destination is Receive Only.")]
	ConnectionHDXDestinationIsReceiveOnly,
	[Description("Connection HDX - Destination is Transmit Only.")]
	ConnectionHDXDestinationIsTransmitOnly,
	[Description("Connection HDX.")]
	ConnectionHDX
}

using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Intercom;

[Serializable]
public enum Command : byte
{
	[Description("No Command.")]
	NoCommand,
	[Description("Status.")]
	Status,
	[Description("Connect.")]
	Connect,
	[Description("Disconnect.")]
	Disconnect,
	[Description("Reset.")]
	Reset,
	[Description("On.")]
	On,
	[Description("Off.")]
	Off
}

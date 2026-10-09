using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum ClearChannel : byte
{
	[Description("Not clear channel.")]
	NotClearChannel,
	[Description("Clear channel.")]
	ClearChannel
}

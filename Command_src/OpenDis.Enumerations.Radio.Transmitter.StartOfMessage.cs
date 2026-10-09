using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum StartOfMessage : byte
{
	[Description("Not start of message.")]
	NotStartOfMessage,
	[Description("Start of Message.")]
	StartOfMessage
}

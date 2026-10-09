using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Intercom;

[Serializable]
public enum ControlType : byte
{
	[Description("Status.")]
	Status = 1,
	[Description("Request - Acknowledge Required.")]
	RequestAcknowledgeRequired,
	[Description("Request - No Acknowledge.")]
	RequestNoAcknowledge,
	[Description("Ack - Request Granted.")]
	AckRequestGranted,
	[Description("Nack - Request Denied.")]
	NackRequestDenied
}

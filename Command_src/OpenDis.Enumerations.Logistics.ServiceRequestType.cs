using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum ServiceRequestType : byte
{
	[Description("Other.")]
	Other,
	[Description("Resupply.")]
	Resupply,
	[Description("Repair.")]
	Repair
}

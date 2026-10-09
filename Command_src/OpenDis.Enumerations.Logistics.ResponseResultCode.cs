using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum ResponseResultCode : byte
{
	[Description("other.")]
	Other,
	[Description("repair ended.")]
	RepairEnded,
	[Description("invalid repair.")]
	InvalidRepair,
	[Description("repair interrupted.")]
	RepairInterrupted,
	[Description("service canceled by the supplier.")]
	ServiceCanceledByTheSupplier
}

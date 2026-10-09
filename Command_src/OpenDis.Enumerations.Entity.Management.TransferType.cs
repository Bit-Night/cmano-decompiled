using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Management;

[Serializable]
public enum TransferType : byte
{
	[Description("Other.")]
	Other,
	[Description("Controlling application requests transfer of an entity.")]
	ControllingApplicationRequestsTransferOfAnEntity,
	[Description("Application desiring control requests transfer of an entity.")]
	ApplicationDesiringControlRequestsTransferOfAnEntity,
	[Description("Mutual exchange / swap of an entity.")]
	MutualExchangeSwapOfAnEntity,
	[Description("Controlling application requests transfer of an environmental process.")]
	ControllingApplicationRequestsTransferOfAnEnvironmentalProcess,
	[Description("Application desiring controls requests transfer of an environmental process.")]
	ApplicationDesiringControlsRequestsTransferOfAnEnvironmentalProcess,
	[Description("Mutual exchange / swap of an environmental.")]
	MutualExchangeSwapOfAnEnvironmental,
	[Description("Cancel transfer.")]
	CancelTransfer
}

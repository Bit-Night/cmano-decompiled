using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission;

[Serializable]
public enum StateUpdateIndicator : byte
{
	[Description("State Update.")]
	StateUpdate,
	[Description("Changed Data Update.")]
	ChangedDataUpdate
}

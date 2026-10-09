using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic;

[Serializable]
public enum StateChangeUpdateIndicator : byte
{
	[Description("State Update.")]
	StateUpdate,
	[Description("Changed Data Update.")]
	ChangedDataUpdate
}

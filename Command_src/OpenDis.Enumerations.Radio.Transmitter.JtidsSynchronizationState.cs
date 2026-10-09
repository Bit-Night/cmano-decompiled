using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum JtidsSynchronizationState : byte
{
	[Description("Coarse Synchronization.")]
	CoarseSynchronization = 1,
	[Description("Fine Synchronization.")]
	FineSynchronization
}

using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
public enum AcknowledgeFlag : ushort
{
	[Description("Create Entity.")]
	CreateEntity = 1,
	[Description("Remove Entity.")]
	RemoveEntity,
	[Description("Start/Resume.")]
	StartResume,
	[Description("Stop/Freeze.")]
	StopFreeze,
	[Description("Transfer Control Request.")]
	TransferControlRequest
}

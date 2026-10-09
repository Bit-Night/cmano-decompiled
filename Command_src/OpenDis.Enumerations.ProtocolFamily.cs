using System;
using System.ComponentModel;

namespace OpenDis.Enumerations;

[Serializable]
public enum ProtocolFamily : byte
{
	[Description("Other.")]
	Other = 0,
	[Description("Entity Information/Interaction.")]
	EntityInformationInteraction = 1,
	[Description("Warfare.")]
	Warfare = 2,
	[Description("Logistics.")]
	Logistics = 3,
	[Description("Radio Communication.")]
	RadioCommunication = 4,
	[Description("Simulation Management.")]
	SimulationManagement = 5,
	[Description("Distributed Emission Regeneration.")]
	DistributedEmissionRegeneration = 6,
	[Description("Entity Management.")]
	EntityManagement = 7,
	[Description("Minefield.")]
	Minefield = 8,
	[Description("Synthetic Environment.")]
	SyntheticEnvironment = 9,
	[Description("Simulation Management with Reliability.")]
	SimulationManagementWithReliability = 10,
	[Description("Live Entity.")]
	LiveEntity = 11,
	[Description("Non-Real Time.")]
	NonRealTime = 12,
	[Description("Experimental - Computer Generated Forces.")]
	ExperimentalComputerGeneratedForces = 129
}

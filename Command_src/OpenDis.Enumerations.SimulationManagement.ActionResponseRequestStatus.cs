using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
public enum ActionResponseRequestStatus : uint
{
	[Description("Other.")]
	Other = 0u,
	[Description("Pending.")]
	Pending = 1u,
	[Description("Executing.")]
	Executing = 2u,
	[Description("Partially Complete.")]
	PartiallyComplete = 3u,
	[Description("Complete.")]
	Complete = 4u,
	[Description("Request rejected.")]
	RequestRejected = 5u,
	[Description("Retransmit request now.")]
	RetransmitRequestNow = 6u,
	[Description("Retransmit request later.")]
	RetransmitRequestLater = 7u,
	[Description("Invalid time parameters.")]
	InvalidTimeParameters = 8u,
	[Description("Simulation time exceeded.")]
	SimulationTimeExceeded = 9u,
	[Description("Request done.")]
	RequestDone = 10u,
	[Description("TACCSF LOS Reply-Type 1.")]
	const_11 = 100u,
	[Description("TACCSF LOS Reply-Type 2.")]
	const_12 = 101u,
	[Description("Join Exercise Request Rejected.")]
	JoinExerciseRequestRejected = 201u
}

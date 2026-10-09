using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
public enum StopFreezeReason : byte
{
	[Description("Other.")]
	Other,
	[Description("Recess.")]
	Recess,
	[Description("Termination.")]
	Termination,
	[Description("System Failure.")]
	SystemFailure,
	[Description("Security Violation.")]
	SecurityViolation,
	[Description("Entity Reconstitution.")]
	EntityReconstitution,
	[Description("Stop for reset.")]
	StopForReset,
	[Description("Stop for restart.")]
	StopForRestart,
	[Description("Abort Training Return to Tactical Operations.")]
	AbortTrainingReturnToTacticalOperations
}

namespace CommandNetcode.RT;

public enum ActiveUnitMiscAction
{
	Null,
	DisengageTargets,
	UnassignUnitsAndDisengage,
	RemoveUnitFromMission,
	ReturnToBase,
	Group,
	Detach,
	DropSonobuoyPassiveDeep,
	DropSonobuoyPassiveShallow,
	DropSonobuoyActiveDeep,
	DropSonobuoyActiveShallow,
	DeployDippingSonar,
	DropOneTarget,
	HoldPositionOn,
	HoldPositionOff,
	SummonToReestablishComms,
	LeadAllowedToSlowDownOn,
	LeadAllowedToSlowDownOff,
	ClientRequestsUnitUpdate
}

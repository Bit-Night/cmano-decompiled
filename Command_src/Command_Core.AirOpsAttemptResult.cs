namespace Command_Core;

public enum AirOpsAttemptResult
{
	Success = 0,
	Failure_other = 1,
	Damaged_facility = 2,
	Not_enough_space = 3,
	Unable_to_fit_in_hangar_space = 4,
	Failure_Program = 6,
	Too_large_for_carrier = 7,
	Unable_to_host_VTOL = 8,
	No_operational_free_parking_space = 9,
	Unsufficient_runway_length = 10,
	Unsufficient_effective_runway_size = 11,
	No_capability_to_launch = 12
}

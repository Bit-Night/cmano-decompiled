namespace Command_Core;

public interface IRecurringMission
{
	ActiveUnit.Throttle? TransitThrottle_Aircraft { get; set; }

	ActiveUnit.Throttle? StationThrottle_Aircraft { get; set; }

	ActiveUnit.Throttle? AttackThrottle_Aircraft { get; set; }

	float? TransitAltitude_Aircraft { get; set; }

	float? StationAltitude_Aircraft { get; set; }

	float? AttackAltitude_Aircraft { get; set; }

	float? AttackDistance_Aircraft { get; set; }

	bool TransitTerrainFollowing_Aircraft { get; set; }

	bool StationTerrainFollowing_Aircraft { get; set; }

	bool AttackTerrainFollowing_Aircraft { get; set; }

	ActiveUnit.Throttle TransitThrottle_Submarine { get; set; }

	ActiveUnit.Throttle StationThrottle_Submarine { get; set; }

	ActiveUnit.Throttle? AttackThrottle_Submarine { get; set; }

	float? TransitDepth_Submarine { get; set; }

	float? StationDepth_Submarine { get; set; }

	float? AttackDepth_Submarine { get; set; }

	float? AttackDistance_Submarine { get; set; }

	ActiveUnit_AI.SubmarineDepthPreset? TransitDepth_Submarine_Preset { get; set; }

	ActiveUnit_AI.SubmarineDepthPreset? StationDepth_Submarine_Preset { get; set; }

	ActiveUnit_AI.SubmarineDepthPreset? AttackDepth_Submarine_Preset { get; set; }

	ActiveUnit.Throttle TransitThrottle_Ship { get; set; }

	ActiveUnit.Throttle StationThrottle_Ship { get; set; }

	ActiveUnit.Throttle? AttackThrottle_Ship { get; set; }

	float? AttackDistance_Ship { get; set; }

	ActiveUnit.Throttle TransitThrottle_Facility { get; set; }

	ActiveUnit.Throttle StationThrottle_Facility { get; set; }

	ActiveUnit.Throttle? AttackThrottle_Facility { get; set; }
}

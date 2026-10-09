namespace Command_Core;

public sealed class AircraftMissionProfile
{
	public short DBID;

	public string Description;

	public int FormUpTime;

	public float FormUpAltitude;

	public float CruiseAltitudeIngress;

	public bool CruiseAltitudeIngressTerrainFollowing;

	public float CruiseAltitudeEgress;

	public bool CruiseAltitudeEgressTerrainFollowing;

	public ActiveUnit.Throttle CruiseThrottleSettingIngress;

	public ActiveUnit.Throttle CruiseThrottleSettingEgress;

	public bool CruiseOneWayOnly;

	public bool CruiseAtOptimumAltitude;

	public float AttackAltitudeIngress;

	public bool AttackAltitudeIngressTerrainFollowing;

	public float AttackAltitudeEgress;

	public bool AttackAltitudeEgressTerrainFollowing;

	public ActiveUnit.Throttle AttackThrottleSetting;

	public int AttackDistanceIngress;

	public int AttackDistanceEgress;

	public bool DropBombsAtMaxRange;

	public float StationAltitude;

	public bool StationAltitudeTerrainFollowing;

	public ActiveUnit.Throttle StationThrottleSetting;

	public int ReservePercentage;

	public int ReserveLoiterTime;

	public float ReserveLoiterAltitude;

	static AircraftMissionProfile()
	{
		Class72.smethod_20();
	}
}

namespace Command_Core;

public sealed class PathfindRequest
{
	public ActiveUnit theUnit;

	public Mission.Flight theFlightPlan;

	public Scenario theScenario;

	public bool theFlightPlanIngressPath;

	public Waypoint StartWP;

	public float ProximityThreshold_Deg;

	public double DestLat;

	public double DestLon;

	public bool ManouverTowardsTarget;

	public int Age;

	public int Distance;

	static PathfindRequest()
	{
		Class72.smethod_20();
	}
}

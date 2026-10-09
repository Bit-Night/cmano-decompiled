using Command_Core;

namespace Command;

public class FlightPlanVisbileOnMap
{
	public int UnitDBID;

	public int int_0;

	public bool Visible;

	public Mission.Flight theFlight;

	public FlightPlanVisbileOnMap(int unitDBID, int int_1, Mission.Flight passedFlight, bool visible)
	{
		UnitDBID = unitDBID;
		int_0 = int_1;
		theFlight = passedFlight;
		Visible = visible;
	}

	static FlightPlanVisbileOnMap()
	{
		Class72.smethod_20();
	}
}

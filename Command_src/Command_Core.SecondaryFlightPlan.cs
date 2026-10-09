namespace Command_Core;

public class SecondaryFlightPlan
{
	public int DBID;

	public int Loadout_DBID;

	public Waypoint[] FlightPlan;

	public string string_0;

	public SecondaryFlightPlan(int dBID, int loadout_DBID, Waypoint[] flightPlan, string _FPCAllsign)
	{
		DBID = dBID;
		Loadout_DBID = loadout_DBID;
		FlightPlan = flightPlan;
		string_0 = _FPCAllsign;
	}

	internal static string GetNextCallSign(int Input)
	{
		return (new string[26]
		{
			"Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf", "Hotel", "India", "Juliet",
			"Kilo", "Lima", "Mike", "November", "Oscar", "Papa", "Quebec", "Romeo", "Sierra", "Tango",
			"Uniform", "Victor", "Whiskey", "X-ray", "Yankee", "Zulu"
		})[Input + 1];
	}

	static SecondaryFlightPlan()
	{
		Class72.smethod_20();
	}
}

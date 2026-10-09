namespace Command_Core;

public class AdvancedGroupFilter
{
	public int ID;

	public int DBID;

	public int Loadout_ID;

	public AdvancedGroupFilter(int iD, int dBID, int loadout_ID)
	{
		ID = iD;
		DBID = dBID;
		Loadout_ID = loadout_ID;
	}

	static AdvancedGroupFilter()
	{
		Class72.smethod_20();
	}
}

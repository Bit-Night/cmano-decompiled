namespace Command;

public sealed class DBViewerNavigationHistoryItem
{
	public int DBID;

	public string ItemType;

	public DBViewerNavigationHistoryItem(int ID, string Type)
	{
		DBID = ID;
		ItemType = Type;
	}

	static DBViewerNavigationHistoryItem()
	{
		Class72.smethod_20();
	}
}

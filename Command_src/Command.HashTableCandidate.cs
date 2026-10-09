namespace Command;

public class HashTableCandidate
{
	public string Name;

	public bool CanContainMultipleEntryPerID;

	public Table_Type TableType;

	public HashTableCandidate(string _Name, bool _CanContainMultipleEntryPerID)
	{
		Name = _Name;
		CanContainMultipleEntryPerID = _CanContainMultipleEntryPerID;
	}

	static HashTableCandidate()
	{
		Class72.smethod_20();
	}
}

namespace Command;

public interface IRamDBHash
{
	Hashtable TableInstance { get; }

	HashtableNode NodeInstance { get; }

	HashTable_Row RowInstance { get; }
}

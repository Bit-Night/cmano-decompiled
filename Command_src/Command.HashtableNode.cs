using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public class HashtableNode : IRamDBHash
{
	public Ram_Database RamDB;

	public MSAccessHelper DataBaseConnexion;

	public Hashtable ParentHashtable;

	public Dictionary<string, Hashtable> Hashtables;

	private Dictionary<string, HashTableCandidate> dictionary_0;

	public List<string> Components;

	public bool IsSource;

	public string _DisplayName;

	public Table_Type ParentType => ParentHashtable.type;

	public Hashtable TableInstance => null;

	public HashtableNode NodeInstance => this;

	public HashTable_Row RowInstance => null;

	public bool HasComponent => Components.Count > 0;

	public bool IsMultilevelReference
	{
		get
		{
			foreach (string component in Components)
			{
				if (Operators.CompareString(component, ParentHashtable.Name, true) == 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool ReferencesAComponentHolder
	{
		get
		{
			foreach (string component in Components)
			{
				if (RamDB.Tables_Node.ContainsKey(Hashtables[component].ReferencedDatatable) && RamDB.Tables_Node[Hashtables[component].ReferencedDatatable].IsMultilevelReference)
				{
					return true;
				}
			}
			return false;
		}
	}

	public string DisplayName
	{
		get
		{
			if (!string.IsNullOrEmpty(_DisplayName))
			{
				return _DisplayName;
			}
			return ParentHashtable.Name;
		}
		set
		{
			_DisplayName = value;
		}
	}

	public HashtableNode(string[] Tables_SingleEntryPerID, string[] Tables_MultipleEntriesPerID, string ParentTable, MSAccessHelper msaccessHelper_0, string DisName, Ram_Database _RamDB, List<Ram_Database.TableComponentWrapper> _Components = null)
	{
		Hashtables = new Dictionary<string, Hashtable>();
		dictionary_0 = new Dictionary<string, HashTableCandidate>();
		Components = new List<string>();
		IsSource = false;
		_DisplayName = "";
		RamDB = _RamDB;
		DataBaseConnexion = msaccessHelper_0;
		AddTables(Tables_SingleEntryPerID, CanContainMultipleEntryPerID: false);
		AddTables(Tables_MultipleEntriesPerID, CanContainMultipleEntryPerID: true);
		PerformConversion();
		SetParent(ParentTable);
		IsSource = IsSource;
		if (!Information.IsNothing((object)_Components))
		{
			foreach (Ram_Database.TableComponentWrapper _Component in _Components)
			{
				Components.Add(_Component.ReferencerTable);
				Hashtables[_Component.ReferencerTable].ReferencedDatatable = _Component.ReferencedTable;
			}
		}
		_DisplayName = DisName;
	}

	public void AddTables(string[] Tables, bool CanContainMultipleEntryPerID)
	{
		foreach (string tableName in Tables)
		{
			AddTable(tableName, CanContainMultipleEntryPerID);
		}
	}

	public bool AddTable(string TableName, bool CanContainMultipleEntryPerID)
	{
		if (!dictionary_0.ContainsKey(TableName))
		{
			dictionary_0.Add(TableName, new HashTableCandidate(TableName, CanContainMultipleEntryPerID));
			return true;
		}
		return false;
	}

	public bool SetParent(string TableName)
	{
		if (Hashtables.ContainsKey(TableName))
		{
			ParentHashtable = Hashtables[TableName];
			return true;
		}
		return false;
	}

	public void PerformConversion()
	{
		foreach (KeyValuePair<string, HashTableCandidate> item in dictionary_0)
		{
			Hashtables.Add(item.Value.Name, ConvertTableToHashTable(item.Value, DataBaseConnexion));
			RamDB.Tables.Add(item.Value.Name, Hashtables.ElementAt(Hashtables.Count - 1).Value);
		}
	}

	public Hashtable ConvertTableToHashTable(HashTableCandidate Table, MSAccessHelper msaccessHelper_0)
	{
		DataTable dataTable = msaccessHelper_0.ExecuteDataTable("Select * FROM " + Table.Name);
		Hashtable hashtable = new Hashtable(Table.Name, RamDB);
		hashtable.Node = this;
		hashtable.CanHaveMultipleEntryPerID = Table.CanContainMultipleEntryPerID;
		DataColumnCollection columns = dataTable.Columns;
		foreach (DataColumn item in columns)
		{
			hashtable.ColumnsHeader.Add(item.ColumnName);
		}
		foreach (DataRow row in dataTable.Rows)
		{
			int num = row.Field<int>("ID");
			List<HashTable_Row> value = null;
			if (!hashtable.Rows.TryGetValue(Conversions.ToString(num), out value))
			{
				value = new List<HashTable_Row>();
				hashtable.Rows.Add(Conversions.ToString(num), value);
			}
			HashTable_Row hashTable_Row = new HashTable_Row(hashtable);
			value.Add(hashTable_Row);
			foreach (DataColumn item2 in columns)
			{
				string theValue = (row.IsNull(item2) ? "" : row[item2].ToString());
				hashTable_Row.AddOrUpdateField(item2.ColumnName, new HashTable_Field(theValue, item2.DataType));
			}
		}
		return hashtable;
	}

	static HashtableNode()
	{
		Class72.smethod_20();
	}
}

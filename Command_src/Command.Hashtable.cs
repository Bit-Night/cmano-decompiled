using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public class Hashtable : IRamDBHash
{
	public Ram_Database RamDB;

	public HashtableNode Node;

	public bool CanHaveMultipleEntryPerID;

	public Dictionary<string, List<HashTable_Row>> Rows;

	public List<string> ColumnsHeader;

	public string ReferencedDatatable;

	public string Name;

	public Table_Type _type;

	private int? nullable_0;

	public Hashtable TableInstance => this;

	public HashtableNode NodeInstance => null;

	public HashTable_Row RowInstance => null;

	public int HighestID
	{
		get
		{
			int num = 0;
			foreach (string key in Rows.Keys)
			{
				int num2 = int.Parse(key);
				if (num2 > num)
				{
					num = num2;
				}
			}
			nullable_0 = num;
			return nullable_0.Value;
		}
	}

	public Table_Type type
	{
		get
		{
			if (_type != Table_Type.Unknown)
			{
				return _type;
			}
			if (CanHaveMultipleEntryPerID)
			{
				if (ColumnsHeader.Contains("ComponentID"))
				{
					return Table_Type.Component;
				}
				if (ColumnsHeader.Contains("CodeID"))
				{
					return Table_Type.CodeCollection;
				}
			}
			if (!string.IsNullOrEmpty(ReferencedDatatable))
			{
				return Table_Type.Secondary;
			}
			return Table_Type.Primary;
		}
	}

	public bool IsMultilevelReference()
	{
		if (ReferencedDatatable != null)
		{
			HashtableNode hashtableNode = null;
			if (RamDB.Tables_Node.ContainsKey(ReferencedDatatable))
			{
				hashtableNode = RamDB.Tables_Node[ReferencedDatatable];
			}
			if (hashtableNode == null)
			{
				return false;
			}
			foreach (string component in hashtableNode.Components)
			{
				if (Operators.CompareString(component, hashtableNode.ParentHashtable.Name, true) == 0)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public bool IsDoublePointer()
	{
		int result;
		if (!IsMultilevelReference())
		{
			result = 0;
		}
		else
		{
			HashtableNode hashtableNode = null;
			if (RamDB.Tables_Node.ContainsKey(ReferencedDatatable))
			{
				hashtableNode = RamDB.Tables_Node[ReferencedDatatable];
			}
			foreach (string component in hashtableNode.Components)
			{
				if (RamDB.Tables.ContainsKey(component) && RamDB.Tables[component].IsMultilevelReference())
				{
					return true;
				}
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public Hashtable(string _Name, Ram_Database _RamDB)
	{
		Rows = new Dictionary<string, List<HashTable_Row>>();
		ColumnsHeader = new List<string>();
		ReferencedDatatable = null;
		_type = Table_Type.Unknown;
		nullable_0 = null;
		RamDB = _RamDB;
		Name = _Name;
	}

	public Hashtable(string _Name, MSAccessHelper msaccessHelper_0, bool _CanContainMultipleEntryPerID, Ram_Database _RamDB)
	{
		Rows = new Dictionary<string, List<HashTable_Row>>();
		ColumnsHeader = new List<string>();
		ReferencedDatatable = null;
		_type = Table_Type.Unknown;
		nullable_0 = null;
		Name = _Name;
		CanHaveMultipleEntryPerID = _CanContainMultipleEntryPerID;
		RamDB = _RamDB;
		DataTable dataTable = msaccessHelper_0.ExecuteDataTable("Select * FROM " + Name);
		Node = null;
		int num = dataTable.Columns.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			ColumnsHeader.Add(dataTable.Columns[i].ColumnName);
		}
		int num2 = dataTable.Rows.Count - 1;
		for (int j = 0; j <= num2; j++)
		{
			int num3 = dataTable.Rows[j].Field<int>("ID");
			if (Rows.ContainsKey(Conversions.ToString(num3)))
			{
				Rows[Conversions.ToString(num3)].Add(new HashTable_Row(this));
			}
			else
			{
				Rows.Add(Conversions.ToString(num3), new List<HashTable_Row>());
				Rows[Conversions.ToString(num3)].Add(new HashTable_Row(this));
			}
			int num4 = dataTable.Columns.Count - 1;
			for (int k = 0; k <= num4; k++)
			{
				string theValue = "";
				if (!dataTable.Rows[j].IsNull(k))
				{
					theValue = Conversions.ToString(dataTable.Rows[j][k]);
				}
				Rows[Conversions.ToString(num3)].ElementAt(Rows[Conversions.ToString(num3)].Count - 1).AddOrUpdateField(dataTable.Columns[k].ColumnName, new HashTable_Field(theValue, dataTable.Columns[k].DataType), RefreshCache: false);
			}
		}
	}

	public void DeleteRowsWithID(string ID)
	{
		if (MyProject.Forms.DBToolsForm.bool_3)
		{
			MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamDB, "RAMDB " + Name + " Source : " + RamDB.IsSource + " (DeleteRowsWithID) ID " + ID);
		}
		if (Rows.ContainsKey(ID))
		{
			Rows.Remove(ID);
		}
	}

	public void DeleteRowEqualTo(HashTable_Row Row, string ID)
	{
		int num = 0;
		if (!Rows.ContainsKey(ID))
		{
			return;
		}
		if (MyProject.Forms.DBToolsForm.bool_3)
		{
			MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamDB, "RAMDB " + Name + " Source : " + RamDB.IsSource + " (DeleteRowEqualTo) ID " + ID + ": " + Row.ToString());
		}
		foreach (HashTable_Row item in Rows[ID].ToList())
		{
			if (HashTable_Row.IsEqual(item, Row))
			{
				Rows[ID].RemoveAt(num);
			}
			num++;
		}
	}

	public void UpdateRow(string ID, string Column, string NewValue)
	{
		MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamDB, "RAMDB " + Name + " Source : " + RamDB.IsSource + " (Update Column) ID :" + ID + ", Column :" + Column + ", New value : " + NewValue);
		if (!Rows.ContainsKey(ID))
		{
			return;
		}
		if (Rows[ID].Count > 0 && Rows[ID].ElementAt(0).FieldsByColumns.ContainsKey(Column))
		{
			foreach (HashTable_Row item in Rows[ID].ToList())
			{
				item.AddOrUpdateField(Column, NewValue);
			}
			return;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	public void AddRowToID(string ID, HashTable_Row row)
	{
		if (!RamDB.IsSource || !row.ParentHashTable.RamDB.IsSource || (!RamDB.IsSource && Debugger.IsAttached))
		{
			Debugger.Break();
		}
		if (MyProject.Forms.DBToolsForm.bool_3)
		{
			MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamDB, "RAMDB " + Name + " Source : " + RamDB.IsSource + " (AddRowToID) ID " + ID + ": " + row.ToString());
		}
		if (!Rows.ContainsKey(ID))
		{
			Rows.Add(ID, new List<HashTable_Row>());
		}
		Rows[ID].Add(row);
	}

	public bool IsParent()
	{
		if (Information.IsNothing((object)Node))
		{
			return true;
		}
		if (Information.IsNothing((object)Node.ParentHashtable))
		{
			return true;
		}
		return Operators.CompareString(Node.ParentHashtable.Name, Name, true) == 0;
	}

	public List<HashTable_Row> GetRowsByID(string ID)
	{
		if (!Rows.ContainsKey(ID))
		{
			return null;
		}
		return Rows[ID];
	}

	public bool HasID(string ID)
	{
		if (!Rows.ContainsKey(ID))
		{
			return false;
		}
		return true;
	}

	public HashTable_Row GetComponentData(string ComponentID)
	{
		if (!Information.IsNothing((object)ReferencedDatatable))
		{
			if (RamDB.Tables.ContainsKey(ReferencedDatatable))
			{
				List<HashTable_Row> rowsByID = RamDB.Tables[ReferencedDatatable].GetRowsByID(ComponentID);
				if (!Information.IsNothing((object)rowsByID) && rowsByID.Count > 0)
				{
					return rowsByID.ElementAt(0);
				}
				return null;
			}
			return null;
		}
		return null;
	}

	public List<HashTable_Row> GetAllComponents(string ID)
	{
		List<HashTable_Row> list = new List<HashTable_Row>();
		List<HashTable_Row> rowsByID = GetRowsByID(ID);
		if (rowsByID == null)
		{
			return null;
		}
		foreach (HashTable_Row item in rowsByID)
		{
			HashTable_Row componentData = GetComponentData(item.FieldsByColumns["ComponentID"].Value);
			if (!Information.IsNothing((object)componentData))
			{
				list.Add(componentData);
			}
		}
		return list;
	}

	static Hashtable()
	{
		Class72.smethod_20();
	}
}

using System.Collections.Generic;

namespace Command;

public class Table_Delta
{
	public bool Editable;

	public HashTableNode_Pair Node;

	public List<Row_Delta> RowDeltas;

	public List<Field_Delta> FieldDeltas;

	public static Dictionary<MethodDelta, List<Row_Delta>> SortedQueries;

	static Table_Delta()
	{
		Class72.smethod_20();
		SortedQueries = new Dictionary<MethodDelta, List<Row_Delta>>();
	}

	public Table_Delta()
	{
		RowDeltas = new List<Row_Delta>();
		FieldDeltas = new List<Field_Delta>();
	}

	public bool HasDelta()
	{
		if (RowDeltas.Count <= 0)
		{
			return FieldDeltas.Count > 0;
		}
		return true;
	}

	public void ModifyField(string ID, Hashtable Table, string Column, string NewValue, bool Editable = true)
	{
		FieldDeltas.Add(new Field_Delta(Table, Column, ID, Table.Rows[ID][0].FieldsByColumns[Column].Value, NewValue, Table.Rows[ID][0].FieldsByColumns[Column].Type, Editable));
	}

	public void AddRow(Hashtable Table, string ID, HashTable_Row NewValue, bool Editable = true)
	{
		RowDeltas.Add(new Row_Delta(Table, ID, MethodDelta.Addition, NewValue, Editable));
	}

	public void DeleteRow(Hashtable Table, string ID, bool Editable, HashTable_Row Dataset)
	{
		RowDeltas.Add(new Row_Delta(Table, ID, MethodDelta.Deletion, Dataset, Editable));
	}

	public void Commit(CopyOver CopyoverInstance)
	{
		SortedQueries[MethodDelta.Deletion].Clear();
		SortedQueries[MethodDelta.Modification].Clear();
		SortedQueries[MethodDelta.Addition].Clear();
		foreach (Field_Delta fieldDelta in FieldDeltas)
		{
			Ram_Database.ApplyQueryToDB(fieldDelta, Common.mySourceDB_Helper, CopyoverInstance);
		}
		foreach (Row_Delta rowDelta in RowDeltas)
		{
			string componentOrCodeID = rowDelta.Value.GetComponentOrCodeID();
			if (!string.IsNullOrEmpty(componentOrCodeID) && rowDelta.Value.ParentHashTable != null)
			{
				rowDelta.Table.GetComponentData(componentOrCodeID);
			}
			SortedQueries[rowDelta.Method].Add(rowDelta);
		}
		foreach (KeyValuePair<MethodDelta, List<Row_Delta>> sortedQuery in SortedQueries)
		{
			foreach (Row_Delta item in sortedQuery.Value)
			{
				Ram_Database.ApplyQueryToDB(item, Common.mySourceDB_Helper, CopyoverInstance);
			}
		}
	}
}

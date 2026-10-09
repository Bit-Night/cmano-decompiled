using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public class HashTable_Pair
{
	public Hashtable DataSource;

	public Hashtable DataTarget;

	public HashTable_Pair(Hashtable _DataSource, Hashtable _DataTarget)
	{
		DataSource = _DataSource;
		DataTarget = _DataTarget;
	}

	public Dictionary<HashTable_Row, float> FetchSimilarRows(string ID, bool SearchInSource = true)
	{
		Dictionary<HashTable_Row, float> dictionary = new Dictionary<HashTable_Row, float>();
		Hashtable hashtable2;
		Hashtable hashtable;
		if (SearchInSource)
		{
			if (DataSource.Node.Hashtables.Count > 0 && Operators.CompareString(DataSource.Node.ParentHashtable.Name, DataSource.Name, true) == 0 && !string.IsNullOrEmpty(DataSource.ReferencedDatatable))
			{
				hashtable = DataSource.RamDB.Tables[DataSource.ReferencedDatatable];
				hashtable2 = DataTarget.RamDB.Tables[DataSource.ReferencedDatatable];
				return new Dictionary<HashTable_Row, float>();
			}
			hashtable = DataSource;
			hashtable2 = DataTarget;
		}
		else
		{
			if (DataSource.Node.Hashtables.Count > 0 && Operators.CompareString(DataSource.Node.ParentHashtable.Name, DataSource.Name, true) == 0 && !string.IsNullOrEmpty(DataSource.ReferencedDatatable))
			{
				hashtable2 = DataSource.RamDB.Tables[DataSource.ReferencedDatatable];
				hashtable = DataTarget.RamDB.Tables[DataSource.ReferencedDatatable];
				return new Dictionary<HashTable_Row, float>();
			}
			hashtable = DataTarget;
			hashtable2 = DataSource;
		}
		if (MyProject.Forms.DBToolsForm.MergeComparisonResolution == ComparisonDepth.Shallow)
		{
			float num = (float)MyProject.Forms.DBToolsForm.TB_SImilarityThreshold.Value / 100f;
			foreach (KeyValuePair<string, List<HashTable_Row>> row in hashtable.Rows)
			{
				foreach (HashTable_Row item in row.Value)
				{
					float similarity = HashTable_Row.GetSimilarity(item, hashtable2.GetRowsByID(ID).ElementAt(0));
					if (similarity > num)
					{
						dictionary.Add(item, similarity);
					}
				}
			}
		}
		return dictionary;
	}

	public Dictionary<HashTable_Row, float> FetchSimilarRows(HashTable_Row Row, bool SearchInSource = true, float SimilarityThreshold = -1f)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		if (SimilarityThreshold == -1f)
		{
			SimilarityThreshold = (float)MyProject.Forms.DBToolsForm.TB_SImilarityThreshold.Value / 100f;
		}
		try
		{
			Dictionary<HashTable_Row, float> dictionary = new Dictionary<HashTable_Row, float>();
			Hashtable hashtable = ((!SearchInSource) ? DataTarget : DataSource);
			if (MyProject.Forms.DBToolsForm.MergeComparisonResolution == ComparisonDepth.Shallow)
			{
				float num = SimilarityThreshold;
				foreach (KeyValuePair<string, List<HashTable_Row>> row in hashtable.Rows)
				{
					foreach (HashTable_Row item in row.Value)
					{
						float similarity = HashTable_Row.GetSimilarity(item, Row);
						if (similarity > num)
						{
							dictionary.Add(item, similarity);
						}
					}
				}
			}
			return dictionary;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Copy-Over 100022", "");
			Interaction.MsgBox((object)ex2.ToString(), (MsgBoxStyle)0, (object)null);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public Table_Delta PerformDeltaCheck(string ID, string ID_Target = "-1", bool BulkDeletion = true)
	{
		Table_Delta table_Delta = new Table_Delta();
		bool canHaveMultipleEntryPerID = DataSource.CanHaveMultipleEntryPerID;
		if (Operators.CompareString(ID_Target, "-1", true) == 0)
		{
			ID_Target = ID;
		}
		if (canHaveMultipleEntryPerID)
		{
			if (!DataSource.Rows.ContainsKey(ID) && DataTarget.Rows.ContainsKey(ID_Target))
			{
				foreach (HashTable_Row item in DataTarget.Rows[ID_Target].ToList())
				{
					item.AddOrUpdateField("ID", ID);
					table_Delta.AddRow(DataSource, ID, item);
				}
			}
			else if (DataSource.Rows.ContainsKey(ID) && !DataTarget.Rows.ContainsKey(ID_Target) && BulkDeletion)
			{
				foreach (HashTable_Row item2 in DataSource.Rows[ID])
				{
					table_Delta.DeleteRow(DataSource, ID, Editable: true, item2);
				}
			}
			else if (DataSource.Rows.ContainsKey(ID) && DataTarget.Rows.ContainsKey(ID_Target) && BulkDeletion)
			{
				foreach (HashTable_Row item3 in DataSource.Rows[ID])
				{
					if (!item3.HasAnEqualRowInTargetTable(DataTarget, ID_Target, IgnoreID: true))
					{
						table_Delta.DeleteRow(DataSource, ID, Editable: true, item3);
					}
				}
				foreach (HashTable_Row item4 in DataTarget.Rows[ID_Target])
				{
					if (!item4.HasAnEqualRowInTargetTable(DataSource, ID, IgnoreID: true))
					{
						table_Delta.AddRow(DataSource, ID, item4);
					}
				}
			}
		}
		else if (!DataSource.Rows.ContainsKey(ID) && DataTarget.Rows.ContainsKey(ID_Target))
		{
			HashTable_Row hashTable_Row = DataTarget.Rows[ID_Target].ElementAt(0);
			hashTable_Row.AddOrUpdateField("ID", ID);
			table_Delta.AddRow(DataSource, ID, hashTable_Row);
		}
		else if (DataSource.Rows.ContainsKey(ID) && !DataTarget.Rows.ContainsKey(ID_Target))
		{
			table_Delta.DeleteRow(DataSource, ID, Editable: true, DataSource.Rows[ID].ElementAt(0));
		}
		else if (DataSource.Rows.ContainsKey(ID) && DataTarget.Rows.ContainsKey(ID_Target) && !HashTable_Row.IsEqual(DataSource.Rows[ID].ElementAt(0), DataTarget.Rows[ID_Target].ElementAt(0), IgnoreID: true))
		{
			foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in DataSource.Rows[ID].ElementAt(0).FieldsByColumns)
			{
				if (Operators.CompareString(fieldsByColumn.Key, "ID", true) != 0 && Operators.CompareString(fieldsByColumn.Key, "CopyOverTarget", true) != 0 && Operators.CompareString(fieldsByColumn.Key, "CopyOverTargetFullName", true) != 0 && Operators.CompareString(fieldsByColumn.Key, "CopyOverTargetDB", true) != 0 && DataTarget.Rows[ID_Target].ElementAt(0).FieldsByColumns.ContainsKey(fieldsByColumn.Key) && Operators.CompareString(fieldsByColumn.Value.Value, DataTarget.Rows[ID_Target].ElementAt(0).FieldsByColumns[fieldsByColumn.Key].Value, true) != 0)
				{
					table_Delta.ModifyField(ID, DataSource, fieldsByColumn.Key, DataTarget.Rows[ID_Target].ElementAt(0).FieldsByColumns[fieldsByColumn.Key].Value);
				}
			}
		}
		return table_Delta;
	}

	static HashTable_Pair()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public class HashTable_Row : IRamDBHash
{
	private Dictionary<string, HashTable_Field> dictionary_0;

	public Hashtable ParentHashTable;

	private Table_Type table_Type_0;

	private string string_0;

	private StringBuilder stringBuilder_0;

	public static HashSet<string> SimilarityfieldsToIgnore;

	public Hashtable TableInstance => null;

	public HashtableNode NodeInstance => null;

	public HashTable_Row RowInstance => this;

	public string Name
	{
		get
		{
			if (string.IsNullOrEmpty(string_0))
			{
				if (FieldsByColumns.ContainsKey("Name"))
				{
					string_0 = FieldsByColumns["Name"].Value;
				}
				else if (FieldsByColumns.ContainsKey("ID"))
				{
					string_0 = FieldsByColumns["ID"].Value;
				}
			}
			return string_0;
		}
	}

	public Table_Type type
	{
		get
		{
			if (table_Type_0 == Table_Type.Unknown)
			{
				if (!Information.IsNothing((object)ParentHashTable))
				{
					table_Type_0 = ParentHashTable.type;
				}
				else if (!FieldsByColumns.ContainsKey("ComponentID"))
				{
					if (!FieldsByColumns.ContainsKey("CodeID"))
					{
						table_Type_0 = Table_Type.Primary;
					}
					else
					{
						table_Type_0 = Table_Type.CodeCollection;
					}
				}
				else
				{
					table_Type_0 = Table_Type.Component;
				}
			}
			return table_Type_0;
		}
	}

	public Dictionary<string, HashTable_Field> FieldsByColumns => dictionary_0;

	static HashTable_Row()
	{
		Class72.smethod_20();
		SimilarityfieldsToIgnore = new HashSet<string> { "CopyOverTarget", "CopyOverTargetFullName", "CopyOverTargetDB", "CopyOverSource", "CopyOverTargetID" };
	}

	public HashTable_Row(Hashtable _ParentHashTable)
	{
		dictionary_0 = new Dictionary<string, HashTable_Field>();
		table_Type_0 = Table_Type.Unknown;
		string_0 = "";
		stringBuilder_0 = null;
		ParentHashTable = _ParentHashTable;
	}

	public string GetComponentOrCodeID()
	{
		if (FieldsByColumns.ContainsKey("ComponentID"))
		{
			return FieldsByColumns["ComponentID"].Value;
		}
		if (!FieldsByColumns.ContainsKey("CodeID"))
		{
			return "";
		}
		return FieldsByColumns["CodeID"].Value;
	}

	public string GetID()
	{
		if (!FieldsByColumns.ContainsKey("ID"))
		{
			return "NO ID";
		}
		return FieldsByColumns["ID"].Value;
	}

	public static void CopyRow(HashTable_Row Source, HashTable_Row Target)
	{
		foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in Target.FieldsByColumns)
		{
			Source.AddOrUpdateField(fieldsByColumn.Key, new HashTable_Field(fieldsByColumn.Value.Value, fieldsByColumn.Value.Type));
		}
	}

	public static bool IsEqual(HashTable_Row RowA, HashTable_Row RowB, bool IgnoreID = false)
	{
		foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in RowA.FieldsByColumns)
		{
			if ((Operators.CompareString(fieldsByColumn.Key, "ID", true) != 0 || !IgnoreID) && Operators.CompareString(fieldsByColumn.Key, "CopyOverTarget", true) != 0 && Operators.CompareString(fieldsByColumn.Key, "CopyOverTargetFullName", true) != 0 && Operators.CompareString(fieldsByColumn.Key, "CopyOverTargetDB", true) != 0)
			{
				if (!RowB.FieldsByColumns.ContainsKey(fieldsByColumn.Key))
				{
					return false;
				}
				if (Operators.CompareString(RowA.FieldsByColumns[fieldsByColumn.Key].Value, RowB.FieldsByColumns[fieldsByColumn.Key].Value, true) != 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	public bool HasAnEqualRowInTargetTable(Hashtable TargetHashtable, string ID, bool IgnoreID = false)
	{
		if (!TargetHashtable.Rows.ContainsKey(ID))
		{
			return false;
		}
		foreach (HashTable_Row item in TargetHashtable.Rows[ID])
		{
			if (IsEqual(item, this, IgnoreID))
			{
				return true;
			}
		}
		return false;
	}

	public static float GetSimilarity(HashTable_Row RowA, HashTable_Row RowB, bool IgnoreIDField = true)
	{
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			float num = RowA.FieldsByColumns.Count;
			foreach (string item in SimilarityfieldsToIgnore)
			{
				if (RowA.FieldsByColumns.ContainsKey(item))
				{
					num -= 1f;
				}
			}
			if (IgnoreIDField && RowA.FieldsByColumns.ContainsKey("ID"))
			{
				num -= 1f;
			}
			if (num <= 0f)
			{
				return 0f;
			}
			float num2 = 0f;
			Dictionary<string, HashTable_Field> fieldsByColumns = RowB.FieldsByColumns;
			HashTable_Field value = null;
			foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in RowA.FieldsByColumns)
			{
				string key = fieldsByColumn.Key;
				if (!SimilarityfieldsToIgnore.Contains(key) && (!IgnoreIDField || Operators.CompareString(key, "ID", true) != 0))
				{
					if (Operators.CompareString(key, "Name", true) == 0 && fieldsByColumns.ContainsKey("Name"))
					{
						new bool?(Operators.CompareString(fieldsByColumn.Value.Value, fieldsByColumns["Name"].Value, true) == 0);
						num2 += 1f;
					}
					else if (fieldsByColumns.TryGetValue(key, out value) && Operators.CompareString(fieldsByColumn.Value.Value, value.Value, true) == 0)
					{
						num2 += 1f;
					}
				}
			}
			if (num2 == 0f)
			{
				return 0f;
			}
			return num2 / num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			MyProject.Forms.DBToolsForm.EnableOperationStackFilter(DBToolsForm.OperationFilterType.RamDB);
			MyProject.Forms.DBToolsForm.EnableOperationStackFilter(DBToolsForm.OperationFilterType.RamdbRoutine);
			MyProject.Forms.DBToolsForm.EnableOperationStackFilter(DBToolsForm.OperationFilterType.SQL);
			MyProject.Forms.DBToolsForm.SaveOperationStack();
			ex2.Data.Add("Error at Copy-Over 100082", "");
			Interaction.MsgBox((object)ex2.ToString(), (MsgBoxStyle)0, (object)null);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public override string ToString()
	{
		if (stringBuilder_0 == null)
		{
			method_0();
		}
		return stringBuilder_0.ToString();
	}

	private void method_0()
	{
		stringBuilder_0 = new StringBuilder();
		stringBuilder_0.Clear();
		bool flag = true;
		foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in FieldsByColumns)
		{
			if (!flag)
			{
				stringBuilder_0.Append(',');
			}
			else
			{
				flag = false;
			}
			stringBuilder_0.Append("[").Append(fieldsByColumn.Key.ToString()).Append("]")
				.Append(fieldsByColumn.Value.Value);
		}
	}

	public void AddOrUpdateField(string Column, HashTable_Field Field, bool RefreshCache = true)
	{
		HashTable_Field value = null;
		if (!FieldsByColumns.TryGetValue(Column, out value) || !value.Equals(Field))
		{
			FieldsByColumns[Column] = Field;
			if (RefreshCache)
			{
				stringBuilder_0 = null;
			}
		}
	}

	public void AddOrUpdateField(string Column, string FieldValue, bool RefreshCache = true)
	{
		HashTable_Field value = null;
		if (!FieldsByColumns.TryGetValue(Column, out value) || !value.Value.Equals(FieldValue))
		{
			FieldsByColumns[Column].Value = FieldValue;
			if (RefreshCache)
			{
				stringBuilder_0 = null;
			}
		}
	}

	public void AddOrUpdateField(Field_Delta delta, bool RefreshCache = true)
	{
		HashTable_Field value = null;
		if (!FieldsByColumns.TryGetValue(delta.Column, out value) || !value.Value.Equals(delta.TargetValue) || !value.Type.Equals(delta.Type))
		{
			FieldsByColumns[delta.Column].Value = delta.TargetValue;
			if (RefreshCache)
			{
				stringBuilder_0 = null;
			}
		}
	}

	public bool HasColumn(string Column)
	{
		return FieldsByColumns.ContainsKey(Column);
	}

	public HashTable_Field GetField(string Column)
	{
		HashTable_Field value = null;
		if (!FieldsByColumns.TryGetValue(Column, out value))
		{
			return null;
		}
		return value;
	}
}

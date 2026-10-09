using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command;

public class Ram_Database
{
	[Serializable]
	public class TableComponentWrapper
	{
		public string ReferencerTable;

		public string ReferencedTable;

		public string DisplayField;

		public TableComponentWrapper(string _ReferencerTable, string _ReferencedTable, string _DisplayField = "")
		{
			ReferencerTable = _ReferencerTable;
			ReferencedTable = _ReferencedTable;
			DisplayField = _DisplayField;
		}

		static TableComponentWrapper()
		{
			Class72.smethod_20();
		}
	}

	public class RowSimilarityWrapper
	{
		public string IdenticalName;

		public float Similarities;

		public RowSimilarityWrapper(string _IdenticalName, float _Similarities)
		{
			IdenticalName = _IdenticalName;
			Similarities = _Similarities;
		}

		static RowSimilarityWrapper()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__12-0
	{
		public Hashtable $VB$Local_HashedTableTarget;

		public _Closure$__12-0(_Closure$__12-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_HashedTableTarget = arg0.$VB$Local_HashedTableTarget;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(string f)
		{
			return $VB$Local_HashedTableTarget.ColumnsHeader.Contains(f);
		}

		static _Closure$__12-0()
		{
			Class72.smethod_20();
		}
	}

	public Dictionary<string, Hashtable> Tables;

	public Dictionary<string, HashtableNode> Tables_Node;

	public float Progress;

	public bool IsSource;

	public string Name;

	public void ProgressStep(float _step)
	{
		Progress += _step;
		MyProject.Forms.DBToolsForm.ProgressBar_Job.Value = (int)Math.Round(Progress * 100f);
		((Control)MyProject.Forms.DBToolsForm.ProgressBar_Job).Refresh();
	}

	public Ram_Database(MSAccessHelper DB, bool IsSource, string Name = "")
	{
		Tables = new Dictionary<string, Hashtable>();
		Tables_Node = new Dictionary<string, HashtableNode>();
		Table_Delta.SortedQueries.Clear();
		Table_Delta.SortedQueries.Add(MethodDelta.Deletion, new List<Row_Delta>());
		Table_Delta.SortedQueries.Add(MethodDelta.Modification, new List<Row_Delta>());
		Table_Delta.SortedQueries.Add(MethodDelta.Addition, new List<Row_Delta>());
		CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
		CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
		if (!string.IsNullOrEmpty(Name))
		{
			this.Name = Name;
		}
		else
		{
			this.Name = DB.theConnection.Database;
		}
		this.IsSource = IsSource;
		method_0(DB);
	}

	private void method_0(MSAccessHelper msaccessHelper_0)
	{
		float num = 0f;
		Dictionary<string, List<HashTableNodeConfig>> dictionary = new Dictionary<string, List<HashTableNodeConfig>>();
		foreach (HashTableNodeConfig item in MyProject.Forms.DBToolsForm.Config.ConfigCollection)
		{
			if (!dictionary.ContainsKey(item.Type))
			{
				dictionary.Add(item.Type, new List<HashTableNodeConfig>());
			}
			dictionary[item.Type].Add(item);
			num += 1f;
		}
		num = 1f / num;
		if (dictionary.ContainsKey("standalone"))
		{
			foreach (HashTableNodeConfig item2 in dictionary["standalone"])
			{
				Tables.Add(item2.PrimaryElevation, new Hashtable(item2.PrimaryElevation, msaccessHelper_0, _CanContainMultipleEntryPerID: false, this));
				ProgressStep(num);
			}
		}
		if (dictionary.ContainsKey("primarynode"))
		{
			foreach (HashTableNodeConfig item3 in dictionary["primarynode"])
			{
				Tables_Node.Add(item3.PrimaryElevation, LoadNode(item3.SecondaryTable.ToArray(), item3.ComponentsTable.ToArray(), item3.PrimaryElevation, msaccessHelper_0, item3.DisplayName));
				ProgressStep(num);
			}
		}
		if (!dictionary.ContainsKey("secondarynode"))
		{
			return;
		}
		foreach (HashTableNodeConfig item4 in dictionary["secondarynode"])
		{
			Tables_Node.Add(item4.PrimaryElevation, LoadNode(item4.SecondaryTable.ToArray(), item4.ComponentsTable.ToArray(), item4.PrimaryElevation, msaccessHelper_0, item4.DisplayName, item4.ComponentsLiaisons));
			ProgressStep(num);
		}
	}

	public static JsonCollection_RamDBConfigs LoadRamDBConfigs()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		JsonCollection_RamDBConfigs result;
		try
		{
			result = JsonConvert.DeserializeObject<JsonCollection_RamDBConfigs>(new StreamReader(Path.Combine(GameGeneral.ConfigFolderPath, "RamDB_Config.json")).ReadToEnd());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theExc = ex;
			ErrorManagement.EnqueueErrorMessage(theExc);
			MyProject.Forms.DBToolsForm.LV_Loading.Items.Add(new DarkListItem("Unable to parse RAMdb config json code."));
			Interaction.MsgBox((object)"Unable to parse RAMdb config json code.", (MsgBoxStyle)0, (object)null);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void AddEntryFromNode(string TheID, HashtableNode DataSource, HashtableNode DataTarget, bool AddSinglePointerComponents, bool AddDoublePointerComponents, CopyOver CopyOverInstance = null, string NewID = "-1")
	{
		try
		{
			MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Inserting main & secondary tables");
			List<HashTable_Row> list = InsertToTable(DataTarget.ParentHashtable, DataSource.ParentHashtable, TheID, Common.mySourceDB_Helper, ClearDestination: true, NewID, CopyOverInstance);
			foreach (KeyValuePair<string, Hashtable> hashtable in DataSource.Hashtables)
			{
				if (hashtable.Value.type != Table_Type.Component && Operators.CompareString(hashtable.Value.Name, DataSource.ParentHashtable.Name, true) != 0 && (!hashtable.Value.IsMultilevelReference() || AddDoublePointerComponents))
				{
					InsertToTable(DataTarget.Hashtables[hashtable.Key], hashtable.Value, TheID, Common.mySourceDB_Helper, ClearDestination: true, NewID, CopyOverInstance);
				}
			}
			if (AddSinglePointerComponents || AddDoublePointerComponents)
			{
				MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Inserting Component");
				foreach (KeyValuePair<string, Hashtable> hashtable2 in DataSource.Hashtables)
				{
					if (hashtable2.Value.type == Table_Type.Component)
					{
						if (hashtable2.Value.IsMultilevelReference() && AddDoublePointerComponents)
						{
							InsertToTable(DataTarget.Hashtables[hashtable2.Key], hashtable2.Value, TheID, Common.mySourceDB_Helper, ClearDestination: true, NewID, CopyOverInstance);
						}
						else if (AddSinglePointerComponents && !string.IsNullOrEmpty(hashtable2.Value.ReferencedDatatable))
						{
							InsertToTable(DataTarget.Hashtables[hashtable2.Key], hashtable2.Value, TheID, Common.mySourceDB_Helper, ClearDestination: true, NewID, CopyOverInstance);
						}
						else
						{
							InsertToTable(DataTarget.Hashtables[hashtable2.Key], hashtable2.Value, TheID, Common.mySourceDB_Helper, ClearDestination: true, NewID, CopyOverInstance);
						}
					}
				}
			}
			if (!Information.IsNothing((object)CopyOverInstance) && !Information.IsNothing((object)list) && list.Count > 0)
			{
				if (!CopyOverInstance.AppliedRowDelta.ContainsKey(DataSource.DisplayName))
				{
					CopyOverInstance.AppliedRowDelta[DataSource.DisplayName] = new List<Row_Delta>();
				}
				CopyOverInstance.AppliedRowDelta[DataSource.DisplayName].Add(new Row_Delta(DataSource.ParentHashtable, TheID, MethodDelta.Addition, list.ElementAt(0)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theExc = ex;
			ErrorManagement.EnqueueErrorMessage(theExc);
			MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Insertion of ID #" + NewID + " in table " + DataTarget.ParentHashtable.Name + " failed, skipping.");
			ProjectData.ClearProjectError();
		}
	}

	public static List<HashTable_Row> InsertToTable(Hashtable HashedTableTarget, Hashtable HashedTablesource, string string_0, MSAccessHelper msaccessHelper_0, bool ClearDestination, string NewID = "-1", CopyOver LogQuery = null)
	{
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		_Closure$__12-0 arg = default(_Closure$__12-0);
		_Closure$__12-0 CS$<>8__locals6 = new _Closure$__12-0(arg);
		CS$<>8__locals6.$VB$Local_HashedTableTarget = HashedTableTarget;
		if (ClearDestination)
		{
			msaccessHelper_0.ExecuteNonQuery($"DELETE FROM {CS$<>8__locals6.$VB$Local_HashedTableTarget.Name} WHERE ID = {NewID};", CloseConnectionWhenDone: false, LogQuery: true);
			HashedTablesource.DeleteRowsWithID(NewID);
		}
		if (!CS$<>8__locals6.$VB$Local_HashedTableTarget.Rows.ContainsKey(string_0))
		{
			return null;
		}
		if (Operators.CompareString(NewID, "-1", true) == 0)
		{
			NewID = string_0;
		}
		string arg2 = string.Join(",", from f in HashedTablesource.ColumnsHeader
			where CS$<>8__locals6.$VB$Local_HashedTableTarget.ColumnsHeader.Contains(f)
			select $"[{f}]");
		List<HashTable_Row> list = new List<HashTable_Row>();
		foreach (HashTable_Row item in CS$<>8__locals6.$VB$Local_HashedTableTarget.Rows[string_0])
		{
			if (HashedTablesource.type == Table_Type.Component && item.FieldsByColumns.ContainsKey("ComponentID"))
			{
				string value = item.FieldsByColumns["ComponentID"].Value;
				if (string.IsNullOrEmpty(HashedTablesource.ReferencedDatatable) || !HashedTablesource.RamDB.Tables.ContainsKey(HashedTablesource.ReferencedDatatable) || !HashedTablesource.RamDB.Tables[HashedTablesource.ReferencedDatatable].HasID(value))
				{
					MessageBox.Show($"ERROR: ComponentID {value} is invalid or missing in primary table {HashedTablesource.ReferencedDatatable}.");
					continue;
				}
			}
			else if (HashedTablesource.type == Table_Type.Component)
			{
				MessageBox.Show($"ERROR: No ComponentID field found in component table {HashedTablesource.Name}.");
				continue;
			}
			StringBuilder stringBuilder = new StringBuilder($"INSERT INTO {CS$<>8__locals6.$VB$Local_HashedTableTarget.Name} ({arg2}) VALUES (");
			List<string> list2 = new List<string>();
			HashTable_Row hashTable_Row = new HashTable_Row(HashedTablesource);
			foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in item.FieldsByColumns)
			{
				if (!HashedTablesource.ColumnsHeader.Contains(fieldsByColumn.Key))
				{
					continue;
				}
				if (!(fieldsByColumn.Value.Type == typeof(string)))
				{
					if (Operators.CompareString(fieldsByColumn.Key, "ID", true) == 0)
					{
						list2.Add(Conversions.ToString(int.Parse(NewID)));
					}
					else
					{
						list2.Add(string.IsNullOrEmpty(fieldsByColumn.Value.Value) ? "-999" : fieldsByColumn.Value.Value.Replace("'", "''").Replace(",", "."));
					}
				}
				else if (Operators.CompareString(fieldsByColumn.Key, "ID", true) == 0)
				{
					list2.Add(NewID);
				}
				else
				{
					list2.Add(string.IsNullOrEmpty(fieldsByColumn.Value.Value) ? "NULL" : string.Format("'{0}'", fieldsByColumn.Value.Value.Replace("'", "''")));
				}
			}
			stringBuilder.Append(string.Join(",", list2)).Append(");");
			msaccessHelper_0.ExecuteNonQuery(stringBuilder.ToString(), CloseConnectionWhenDone: false, LogQuery: true);
			HashTable_Row.CopyRow(hashTable_Row, item);
			if (hashTable_Row.FieldsByColumns.ContainsKey("ID"))
			{
				hashTable_Row.AddOrUpdateField("ID", NewID);
			}
			list.Add(hashTable_Row);
			HashedTablesource.AddRowToID(NewID, hashTable_Row);
		}
		return list;
	}

	public static void ApplyQueryToDB(Field_Delta Query, MSAccessHelper msaccessHelper_0, CopyOver CopyoverInstance)
	{
		string text = null;
		string targetValue = Query.TargetValue;
		text = ((!(Query.Type == typeof(string))) ? targetValue.Replace("'", "''") : (string.IsNullOrEmpty(Query.TargetValue) ? "NULL" : ("'" + targetValue.Replace("'", "''") + "'")));
		int num;
		string string_;
		if (Operators.CompareString(Query.TargetValue, "False", true) == 0)
		{
			num = 9;
		}
		else
		{
			if (Operators.CompareString(Query.TargetValue, "True", true) != 0)
			{
				string_ = "UPDATE " + Query.Table.Name + " SET [" + Query.Column + "] = " + text + " WHERE ID = " + Query.ID + " ;";
				goto IL_0149;
			}
			num = 9;
		}
		string[] array = new string[num];
		array[0] = "UPDATE ";
		array[1] = Query.Table.Name;
		array[2] = " SET [";
		array[3] = Query.Column;
		array[4] = "] = ";
		array[5] = text;
		array[6] = " WHERE ID = ";
		array[7] = Query.ID;
		array[8] = " ;";
		string_ = string.Concat(array);
		goto IL_0149;
		IL_0149:
		List<HashTable_Row> rowsByID = Query.Table.GetRowsByID(Query.ID);
		if (rowsByID != null && rowsByID.Count > 0)
		{
			rowsByID.ElementAt(0).AddOrUpdateField(Query);
		}
		msaccessHelper_0.ExecuteDataTable(string_, CloseConnectionWhenDone: false, LogQuery: true);
		Query.Table.UpdateRow(Query.ID, Query.Column, text);
		if (!CopyoverInstance.AppliedFieldDelta.ContainsKey(Query.Table.Node.DisplayName))
		{
			CopyoverInstance.AppliedFieldDelta[Query.Table.Node.DisplayName] = new List<Field_Delta>();
			CopyoverInstance.AppliedFieldDelta[Query.Table.Node.DisplayName].Add(Query);
		}
	}

	public static void ApplyQueryToDB(Row_Delta Query, MSAccessHelper msaccessHelper_0, CopyOver CopyoverInstance)
	{
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Query == null)
			{
				return;
			}
			HashSet<string> hashSet = null;
			if (CopyoverInstance.SourceDB_Ram != null)
			{
				hashSet = CopyoverInstance.SourceDB_Ram.Tables[Query.Table.Name].ColumnsHeader.ToHashSet();
			}
			if (Query.Method == MethodDelta.Deletion)
			{
				string text = " WHERE ";
				bool flag = true;
				foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in Query.Value.FieldsByColumns)
				{
					if (hashSet == null || hashSet.Contains(fieldsByColumn.Key))
					{
						string text2 = "";
						text2 = ((fieldsByColumn.Value.Type == typeof(string)) ? ((!string.IsNullOrEmpty(fieldsByColumn.Value.Value)) ? ("'" + fieldsByColumn.Value.Value.Replace("'", "''") + "'") : "NULL") : ((fieldsByColumn.Value.Type == typeof(bool)) ? ((!Conversions.ToBoolean(fieldsByColumn.Value.Value)) ? "0" : "1") : fieldsByColumn.Value.Value.Replace("'", "''")));
						if (!flag)
						{
							text = text + " AND " + fieldsByColumn.Key + " = " + text2;
						}
						else
						{
							text = text + fieldsByColumn.Key + " = " + text2;
							flag = false;
						}
					}
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					msaccessHelper_0.ExecuteNonQuery("DELETE FROM " + Query.Table.Name + text + ";", CloseConnectionWhenDone: false, LogQuery: true);
					Query.Table.DeleteRowEqualTo(Query.Value, Query.ID);
				}
			}
			else
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn2 in Query.Value.FieldsByColumns)
				{
					if (hashSet != null && !hashSet.Contains(fieldsByColumn2.Key))
					{
						continue;
					}
					list.Add("[" + fieldsByColumn2.Key + "]");
					if (!(fieldsByColumn2.Value.Type == typeof(string)))
					{
						if (fieldsByColumn2.Value.Type == typeof(bool))
						{
							list2.Add(Conversions.ToBoolean(fieldsByColumn2.Value.Value) ? "1" : "0");
						}
						else
						{
							list2.Add(fieldsByColumn2.Value.Value.Replace("'", "''"));
						}
					}
					else if (string.IsNullOrEmpty(fieldsByColumn2.Value.Value))
					{
						list2.Add("NULL");
					}
					else
					{
						list2.Add("'" + fieldsByColumn2.Value.Value.Replace("'", "''") + "'");
					}
				}
				if (list.Count > 0)
				{
					string text3 = "INSERT INTO " + Query.Table.Name + "(" + string.Join(",", list) + ") VALUES (" + string.Join(",", list2) + ");";
					try
					{
						msaccessHelper_0.ExecuteNonQuery(text3, CloseConnectionWhenDone: false, LogQuery: true);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception theExc = ex;
						ErrorManagement.EnqueueErrorMessage(theExc);
						MyProject.Forms.DBToolsForm.LV_Loading.Items.Add(new DarkListItem("ERROR when executing " + text3 + " , skipped query."));
						ProjectData.ClearProjectError();
					}
				}
			}
			if (!CopyoverInstance.AppliedRowDelta.ContainsKey(Query.Table.Node.DisplayName))
			{
				CopyoverInstance.AppliedRowDelta[Query.Table.Node.DisplayName] = new List<Row_Delta>();
			}
			CopyoverInstance.AppliedRowDelta[Query.Table.Node.DisplayName].Add(Query);
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception ex3 = ex2;
			ErrorManagement.EnqueueErrorMessage(ex3);
			ex3.Data.Add("Error at Copy-Over 100521", "");
			Interaction.MsgBox((object)ex3.ToString(), (MsgBoxStyle)0, (object)null);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public HashtableNode LoadNode(string[] Tables_SingleEntryPerID, string[] Tables_MultipleEntriesPerID, string ParentTable, MSAccessHelper DBConnexionSource, string DisplayName, List<TableComponentWrapper> Components = null)
	{
		return new HashtableNode(Tables_SingleEntryPerID, Tables_MultipleEntriesPerID, ParentTable, DBConnexionSource, DisplayName, this, Components);
	}

	public static void Commit(CopyOver CopyoverInstance, Dictionary<string, Table_Delta> Delta)
	{
		foreach (KeyValuePair<string, Table_Delta> Deltum in Delta)
		{
			Deltum.Value.Commit(CopyoverInstance);
		}
	}

	static Ram_Database()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public class HashTableNode_Pair
{
	public HashTableNode_Pair ParentWorkingPair;

	public HashtableNode DataSource;

	public HashtableNode DataTarget;

	public string ReadableName;

	public Ram_Database Source_RAMDB;

	public Ram_Database Target_RAMDB;

	public HashTableNode_Pair(HashtableNode _DataSource, HashtableNode _DataTarget, string _ReadableName, Ram_Database _Source_RAMDB, Ram_Database _Target_RAMDB)
	{
		ReadableName = "Undefined";
		ReadableName = _ReadableName;
		DataSource = _DataSource;
		DataTarget = _DataTarget;
		Source_RAMDB = _Source_RAMDB;
		Target_RAMDB = _Target_RAMDB;
	}

	public int CopyOver(MergeMethod_E Mode, string TheID, CopyOver CopyoverInstance, HashTable_Pair ParentPair, bool IgnoreDoublePointerHandling = false, bool PerformDuplicatePrompt = true, bool InvertedSimilarityQuery = false, bool IncludePrimaryInsertion = true, bool IsExplicitCopyOver = false)
	{
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Invalid comparison between Unknown and I4
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		string description = "Initiating Copyover (" + Mode.ToString() + ") " + ReadableName + " ID " + TheID;
		MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, description);
		try
		{
			HashTable_Pair hashTable_Pair = new HashTable_Pair(DataSource.ParentHashtable, DataTarget.ParentHashtable);
			List<HashTable_Row> rowsByID = DataTarget.ParentHashtable.GetRowsByID(TheID);
			if (rowsByID.Count != 0)
			{
				Dictionary<HashTable_Row, float> dictionary = hashTable_Pair.FetchSimilarRows(TheID);
				bool flag = true;
				int result = 0;
				CopyOverSimilarityPrompt.LV_Item lV_Item = null;
				if (Mode == MergeMethod_E.Same_Branch && IsExplicitCopyOver)
				{
					lV_Item = new CopyOverSimilarityPrompt.LV_Item(rowsByID.ElementAt(0), 0f, _OwnTable: false);
				}
				if (lV_Item == null && dictionary.Count > 0 && PerformDuplicatePrompt)
				{
					CopyOverSimilarityPrompt copyOverSimilarityPrompt = new CopyOverSimilarityPrompt();
					((RichTextBox)copyOverSimilarityPrompt.TB_Info).Text = hashTable_Pair.DataSource.Node.DisplayName + " #" + TheID.ToString() + " - Similar entries were found in the source, There is possibly an identical entry that already exists in this database, please check similarities and abort copyover if you deem it necessary to do so, or proceed to copy-over if no candidate are similar enough.";
					copyOverSimilarityPrompt.SimilarEntries_Own = hashTable_Pair.FetchSimilarRows(TheID);
					copyOverSimilarityPrompt.SimilarEntries_External = hashTable_Pair.FetchSimilarRows(TheID, SearchInSource: false);
					copyOverSimilarityPrompt.CurrentRow = DataTarget.ParentHashtable.GetRowsByID(TheID).ElementAt(0);
					copyOverSimilarityPrompt.NodePair = this;
					copyOverSimilarityPrompt.Button_SelectedCandidate.Enabled = false;
					DialogResult val = default(DialogResult);
					if (((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoCopyOverMode).Checked & ((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoPrimary).Checked)
					{
						foreach (KeyValuePair<HashTable_Row, float> item in copyOverSimilarityPrompt.SimilarEntries_Own)
						{
							if (item.Value == 1f)
							{
								lV_Item = new CopyOverSimilarityPrompt.LV_Item(item.Key, 1f, _OwnTable: true);
								val = (DialogResult)3;
								break;
							}
						}
						if (lV_Item == null && ((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoCopyOverMode_External).Checked)
						{
							foreach (KeyValuePair<HashTable_Row, float> item2 in copyOverSimilarityPrompt.SimilarEntries_External)
							{
								if (item2.Value == 1f)
								{
									lV_Item = new CopyOverSimilarityPrompt.LV_Item(item2.Key, 1f, _OwnTable: false);
									val = (DialogResult)3;
									break;
								}
							}
						}
					}
					else
					{
						val = ((Form)copyOverSimilarityPrompt).ShowDialog();
					}
					if ((int)val == 3)
					{
						flag = false;
					}
				}
				if (flag)
				{
					result = ComponentCopyOver(Mode, TheID, CopyoverInstance, hashTable_Pair, IgnoreDoublePointerHandling, IncludePrimaryInsertion, IsExplicitCopyOver);
					MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Copyover (" + Mode.ToString() + " branch) " + hashTable_Pair.DataSource.Name + " ID_a " + TheID + " ; ID_b " + result);
				}
				((Control)MyProject.Forms.DBToolsForm).Refresh();
				return result;
			}
			MessageBox.Show("Procedure error ID" + TheID + " of " + DataTarget.ParentHashtable.Name + " does not exist in target database", "ERROR", (MessageBoxButtons)0, (MessageBoxIcon)16);
			return -1;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Copy-Over 100012", "");
			Interaction.MsgBox((object)ex2.ToString(), (MsgBoxStyle)0, (object)null);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public int ComponentCopyOver(MergeMethod_E Mode, string TheID, CopyOver CopyoverInstance, HashTable_Pair ParentPair, bool IgnoreDoublePointerHandling, bool IncludePrimaryInsertion = false, bool IsExplicitCopyOver = false)
	{
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ae: Invalid comparison between Unknown and I4
		//IL_07a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Invalid comparison between Unknown and I4
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0733: Unknown result type (might be due to invalid IL or missing references)
		CopyoverInstance.AddToStack(DataSource.DisplayName, HighLevel: false);
		HashTable_Pair hashTable_Pair = new HashTable_Pair(DataSource.ParentHashtable, DataTarget.ParentHashtable);
		MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, hashTable_Pair.DataSource.Node.DisplayName + " #" + TheID.ToString() + " - No similar entry were found in the source. Copy over is proceeding with component comparison, do you want to perform automated component copyover ? You will only be prompted when no corresponding entry exists.");
		int num = -1;
		num = ((Mode != MergeMethod_E.Same_Branch || !IsExplicitCopyOver) ? (DataSource.ParentHashtable.HighestID + 1) : Conversions.ToInteger(TheID));
		if (DataTarget.ParentHashtable.type == Table_Type.Primary && IncludePrimaryInsertion)
		{
			Ram_Database.AddEntryFromNode(TheID, DataSource, DataTarget, AddSinglePointerComponents: false, AddDoublePointerComponents: false, CopyoverInstance, Conversions.ToString(num));
		}
		DialogResult val = default(DialogResult);
		foreach (string component in DataTarget.Components)
		{
			Hashtable hashtable = DataTarget.RamDB.Tables[component];
			Hashtable hashtable2 = DataSource.RamDB.Tables[component];
			HashtableNode hashtableNode = null;
			HashtableNode dataSource = null;
			if (Source_RAMDB.Tables_Node.ContainsKey(hashtable.ReferencedDatatable))
			{
				dataSource = Source_RAMDB.Tables_Node[hashtable.ReferencedDatatable];
				hashtableNode = Target_RAMDB.Tables_Node[hashtable.ReferencedDatatable];
			}
			HashTableNode_Pair hashTableNode_Pair = new HashTableNode_Pair(dataSource, hashtableNode, "", Source_RAMDB, Target_RAMDB);
			bool flag;
			if (flag = hashtableNode != null && DataTarget.RamDB.Tables[component].IsMultilevelReference())
			{
				MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Initiating Copyover of component " + component + " (double pointer type)");
			}
			else
			{
				MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Initiating Copyover of component " + component);
			}
			if (flag && !IgnoreDoublePointerHandling)
			{
				MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Double-pointer handling of " + component);
				MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Warning : table " + hashtable.Name + " is a component holder that contains a component holder, referencing a primary node : " + hashtable.ReferencedDatatable + ". A new component holder of type " + DataTarget.ParentHashtable.Name + " will be created.");
				Dictionary<string, Table_Delta> dictionary = new Dictionary<string, Table_Delta>();
				dictionary.Add(hashtable.Name, new Table_Delta());
				CopyoverInstance.AddToStack(hashtable.Name, HighLevel: false);
				List<HashTable_Row> rowsByID = hashtable.GetRowsByID(TheID);
				if (rowsByID == null)
				{
					continue;
				}
				new CopyOverPrompt();
				dictionary.Clear();
				dictionary.Add(hashtable.Name, new Table_Delta());
				foreach (HashTable_Row item in rowsByID.ToList())
				{
					HashTable_Pair parentPair = new HashTable_Pair(hashtable2, hashtable);
					int num2 = hashTableNode_Pair.CopyOver(Mode, item.FieldsByColumns["ComponentID"].Value, CopyoverInstance, parentPair, IgnoreDoublePointerHandling: true, PerformDuplicatePrompt: true, InvertedSimilarityQuery: true, IncludePrimaryInsertion: false);
					item.AddOrUpdateField("ID", Conversions.ToString(num));
					item.AddOrUpdateField("ComponentID", num2.ToString());
					dictionary[hashtable.Name].AddRow(Source_RAMDB.Tables[hashtable.Name], Conversions.ToString(num), item);
				}
				if (((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoCopyOver_Commit).Checked)
				{
					Ram_Database.Commit(CopyoverInstance, dictionary);
				}
				else
				{
					new CopyOverPrompt().Refresh(dictionary, this, Conversions.ToString(num), CopyoverInstance);
				}
			}
			else
			{
				if (flag)
				{
					continue;
				}
				if (IncludePrimaryInsertion)
				{
					Common.mySourceDB_Helper.ExecuteNonQuery("DELETE FROM " + hashtable.Name + " WHERE ID = " + TheID + ";", CloseConnectionWhenDone: false, LogQuery: true);
					DataSource.Hashtables[hashtable.Name].DeleteRowsWithID(Conversions.ToString(num));
				}
				CopyoverInstance.LowLevelStack.Clear();
				CopyoverInstance.AddToStack(hashtable.Name, HighLevel: false);
				if (!hashtable.Rows.ContainsKey(TheID) || hashtable.Rows[TheID].Count == 0)
				{
					continue;
				}
				foreach (HashTable_Row item2 in hashtable.Rows[TheID])
				{
					HashTable_Row componentData = hashtable.GetComponentData(item2.GetComponentOrCodeID());
					MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Component Pointer from target table " + hashtable.Name + " (ID #" + TheID + ") : Component : ID[" + item2.GetID() + "], ComponentID [" + item2.GetComponentOrCodeID() + "]");
					if (!Source_RAMDB.Tables.ContainsKey(hashtable.ReferencedDatatable))
					{
						MessageBox.Show("SOURCE RAMDB : Referenced table " + hashtable.ReferencedDatatable + " does not exist in " + hashtable.Name, "ERROR", (MessageBoxButtons)0, (MessageBoxIcon)16);
					}
					if (!Target_RAMDB.Tables.ContainsKey(hashtable.ReferencedDatatable))
					{
						MessageBox.Show("TARGET RAMDB :  Referenced table " + hashtable.ReferencedDatatable + " does not exist in " + hashtable.Name, "ERROR", (MessageBoxButtons)0, (MessageBoxIcon)16);
					}
					HashTable_Pair hashTable_Pair2 = new HashTable_Pair(Source_RAMDB.Tables[hashtable.ReferencedDatatable], Target_RAMDB.Tables[hashtable.ReferencedDatatable]);
					new HashTableNode_Pair(Source_RAMDB.Tables[hashtable.ReferencedDatatable].Node, Target_RAMDB.Tables[hashtable.ReferencedDatatable].Node, "", Source_RAMDB, Target_RAMDB);
					Dictionary<HashTable_Row, float> dictionary2 = hashTable_Pair2.FetchSimilarRows(componentData);
					Dictionary<HashTable_Row, float> dictionary3 = hashTable_Pair2.FetchSimilarRows(componentData, SearchInSource: false);
					CopyOverSimilarityPrompt copyOverSimilarityPrompt = new CopyOverSimilarityPrompt();
					copyOverSimilarityPrompt.SimilarEntries_Own = dictionary2;
					copyOverSimilarityPrompt.SimilarEntries_External = dictionary3;
					copyOverSimilarityPrompt.CurrentRow = componentData;
					copyOverSimilarityPrompt.NodePair = null;
					CopyOverSimilarityPrompt.LV_Item lV_Item = null;
					if (((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoCopyOverMode).Checked && ((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoSecondary).Checked)
					{
						foreach (KeyValuePair<HashTable_Row, float> item3 in dictionary2)
						{
							if (item3.Value == 1f)
							{
								lV_Item = new CopyOverSimilarityPrompt.LV_Item(item3.Key, 1f, _OwnTable: true);
								val = (DialogResult)6;
							}
						}
						if (lV_Item == null && ((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoCopyOverMode_External).Checked)
						{
							foreach (KeyValuePair<HashTable_Row, float> item4 in dictionary3)
							{
								if (item4.Value == 1f)
								{
									lV_Item = new CopyOverSimilarityPrompt.LV_Item(item4.Key, 1f, _OwnTable: false);
									val = (DialogResult)6;
								}
							}
						}
					}
					if (lV_Item == null)
					{
						((RichTextBox)copyOverSimilarityPrompt.TB_Info).Text = "Select the new component (" + hashtable.Name + ") reference that correspond best to " + componentData.Name + ". It is better to use 'own' component if possible to avoid copying over duplicate component entries.";
						copyOverSimilarityPrompt.Button_IgnoreCandidateAndProceed.Enabled = false;
						val = ((Form)copyOverSimilarityPrompt).ShowDialog();
					}
					if ((int)val == 3 || (int)val != 6 || (copyOverSimilarityPrompt.LV_Similarities.SelectedItems.Count <= 0 && lV_Item == null))
					{
						continue;
					}
					if (lV_Item == null)
					{
						lV_Item = (CopyOverSimilarityPrompt.LV_Item)copyOverSimilarityPrompt.LV_Similarities.SelectedItems[0];
					}
					MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "Similar item found (own " + lV_Item.OwnTable + ") for " + item2.ToString());
					string iD = lV_Item.Value.GetID();
					if (!lV_Item.OwnTable)
					{
						HashTable_Pair parentPair2 = new HashTable_Pair(Source_RAMDB.Tables[component], Target_RAMDB.Tables[component]);
						iD = Conversions.ToString(int.Parse(Conversions.ToString(new HashTableNode_Pair(Source_RAMDB.Tables_Node[hashtable.ReferencedDatatable], Target_RAMDB.Tables_Node[hashtable.ReferencedDatatable], Source_RAMDB.Tables_Node[hashtable.ReferencedDatatable].DisplayName, Source_RAMDB, Target_RAMDB).CopyOver(Mode, lV_Item.Value.GetID(), CopyoverInstance, parentPair2, IgnoreDoublePointerHandling: false, PerformDuplicatePrompt: false))));
						MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.RamdbRoutine, "(External table) copy-over of " + iD + " (" + lV_Item.Name + ") " + component);
						List<HashTable_Row> rowsByID2 = hashtable2.GetRowsByID(Conversions.ToString(num));
						bool flag2 = false;
						if (rowsByID2 != null)
						{
							foreach (HashTable_Row item5 in rowsByID2)
							{
								if (Operators.CompareString(item5.GetComponentOrCodeID(), iD, true) == 0)
								{
									flag2 = true;
									break;
								}
							}
						}
						if (!flag2)
						{
							Dictionary<string, Table_Delta> dictionary4 = new Dictionary<string, Table_Delta>();
							dictionary4.Add(hashtable.Name, new Table_Delta());
							dictionary4[hashtable.Name].DeleteRow(Source_RAMDB.Tables[hashtable.Name], Conversions.ToString(num), Editable: true, item2);
							HashTable_Row hashTable_Row = new HashTable_Row(Source_RAMDB.Tables[hashtable.Name]);
							HashTable_Row.CopyRow(hashTable_Row, item2);
							hashTable_Row.AddOrUpdateField("ID", Conversions.ToString(num));
							hashTable_Row.AddOrUpdateField("ComponentID", iD);
							dictionary4[hashtable.Name].AddRow(Source_RAMDB.Tables[hashtable.Name], Conversions.ToString(num), hashTable_Row);
							if (!((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoCopyOver_Commit).Checked)
							{
								new CopyOverPrompt().Refresh(dictionary4, this, Conversions.ToString(num), CopyoverInstance);
							}
							else
							{
								Ram_Database.Commit(CopyoverInstance, dictionary4);
							}
						}
						foreach (KeyValuePair<string, Hashtable> hashtable3 in DataSource.Hashtables)
						{
							if (hashtable3.Value.Name.ToLowerInvariant().Contains("misc"))
							{
								Ram_Database.InsertToTable(DataTarget.Hashtables[hashtable3.Key], hashtable3.Value, TheID, Common.mySourceDB_Helper, ClearDestination: true, Conversions.ToString(num), CopyoverInstance);
							}
						}
						continue;
					}
					List<HashTable_Row> rowsByID3 = hashtable2.GetRowsByID(Conversions.ToString(num));
					bool flag3 = false;
					if (rowsByID3 != null)
					{
						foreach (HashTable_Row item6 in rowsByID3)
						{
							if (Operators.CompareString(item6.GetComponentOrCodeID(), iD, true) == 0)
							{
								flag3 = true;
								break;
							}
						}
					}
					Dictionary<string, Table_Delta> dictionary5 = new Dictionary<string, Table_Delta>();
					HashTable_Pair hashTable_Pair3 = new HashTable_Pair(Source_RAMDB.Tables[component], Target_RAMDB.Tables[component]);
					if (Mode == MergeMethod_E.Same_Branch && IsExplicitCopyOver && (double)num == Conversions.ToDouble(TheID) && !IncludePrimaryInsertion)
					{
						dictionary5.Add(hashtable.Name, hashTable_Pair3.PerformDeltaCheck(Conversions.ToString(num), TheID, BulkDeletion: false));
					}
					else if (!flag3)
					{
						dictionary5.Add(hashtable.Name, new Table_Delta());
						HashTable_Row hashTable_Row2 = new HashTable_Row(item2.ParentHashTable);
						HashTable_Row.CopyRow(hashTable_Row2, item2);
						hashTable_Row2.AddOrUpdateField("ID", Conversions.ToString(num));
						hashTable_Row2.AddOrUpdateField("ComponentID", iD);
						dictionary5[hashtable.Name].AddRow(Source_RAMDB.Tables[hashtable.Name], Conversions.ToString(num), hashTable_Row2);
					}
					if (((CheckBox)MyProject.Forms.DBToolsForm.CB_AutoCopyOver_Commit).Checked)
					{
						Ram_Database.Commit(CopyoverInstance, dictionary5);
					}
					else
					{
						new CopyOverPrompt().Refresh(dictionary5, this, Conversions.ToString(num), CopyoverInstance);
					}
					foreach (KeyValuePair<string, Hashtable> hashtable4 in DataSource.Hashtables)
					{
						if (hashtable4.Value.Name.ToLowerInvariant().Contains("misc"))
						{
							Ram_Database.InsertToTable(DataTarget.Hashtables[hashtable4.Key], hashtable4.Value, TheID, Common.mySourceDB_Helper, ClearDestination: true, Conversions.ToString(num), CopyoverInstance);
						}
					}
				}
			}
		}
		if (!string.IsNullOrEmpty(TheID))
		{
			MyProject.Forms.DBToolsForm.LV_Loading.Items.Add(new DarkListItem("Component Copyover (different branch) " + hashTable_Pair.DataSource.Name + " ID_a " + TheID + " ; ID_b " + num));
		}
		((Control)MyProject.Forms.DBToolsForm).Refresh();
		return num;
	}

	public void Perform_CopyOver(CopyOver CopyoverInstance)
	{
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		string name = DataTarget.ParentHashtable.Name;
		if (!MyProject.Forms.DBToolsForm.MergeCandidates.ContainsKey(name))
		{
			return;
		}
		Dictionary<string, DBToolsForm.MergeCandidateWrapper> dictionary = MyProject.Forms.DBToolsForm.MergeCandidates[name];
		if (dictionary.Count == 0)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>(dictionary.Keys);
		foreach (KeyValuePair<string, List<HashTable_Row>> row in DataTarget.ParentHashtable.Rows)
		{
			string value = row.Value.ElementAt(0).FieldsByColumns["ID"].Value;
			if (!hashSet.Contains(value) && !hashSet.Contains("ALL"))
			{
				continue;
			}
			((Label)MyProject.Forms.DBToolsForm.LablCurrentCallStack).Text = $"Call stack {DataTarget.DisplayName} #{value}";
			try
			{
				CopyoverInstance.HighLevelStack.Clear();
				CopyoverInstance.AddToStack(DataSource.DisplayName, HighLevel: true);
				MyProject.Forms.DBToolsForm.bool_3 = true;
				CopyOver(MyProject.Forms.DBToolsForm.MergeMethod, value, CopyoverInstance, null, IgnoreDoublePointerHandling: false, PerformDuplicatePrompt: true, InvertedSimilarityQuery: false, IncludePrimaryInsertion: true, IsExplicitCopyOver: true);
				dictionary[value].SetStatus(DBToolsForm.MergeCandidateStatus.Successful, RefreshUI: true);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Copy-Over 100001", "");
				dictionary[value].SetStatus(DBToolsForm.MergeCandidateStatus.Failed, RefreshUI: true);
				Interaction.MsgBox((object)ex2.ToString(), (MsgBoxStyle)0, (object)null);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public Dictionary<string, Table_Delta> GetDelta(string SourceID, string TargetID)
	{
		Dictionary<string, Table_Delta> dictionary = new Dictionary<string, Table_Delta>();
		foreach (KeyValuePair<string, Hashtable> hashtable in DataSource.Hashtables)
		{
			Table_Delta table_Delta = new HashTable_Pair(hashtable.Value, DataTarget.Hashtables[hashtable.Key]).PerformDeltaCheck(SourceID, TargetID);
			if (table_Delta.HasDelta())
			{
				dictionary.Add(hashtable.Key, table_Delta);
			}
		}
		return dictionary;
	}

	static HashTableNode_Pair()
	{
		Class72.smethod_20();
	}
}

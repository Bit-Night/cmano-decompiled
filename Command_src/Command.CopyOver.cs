using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;

namespace Command;

public class CopyOver
{
	public Dictionary<string, List<Row_Delta>> AppliedRowDelta;

	public Dictionary<string, List<Field_Delta>> AppliedFieldDelta;

	public HashtableNode SourceNode;

	public HashtableNode TargetNode;

	public List<string> HighLevelStack;

	public List<string> LowLevelStack;

	public Ram_Database SourceDB_Ram;

	public Ram_Database TargetDB_Ram;

	public void AddToStack(string _call, bool HighLevel)
	{
		if (!HighLevel)
		{
			LowLevelStack.Add(_call);
		}
		else
		{
			HighLevelStack.Add(_call);
		}
		((RichTextBox)MyProject.Forms.DBToolsForm.Label_DBStack).Text = string.Join(">", HighLevelStack) + ">" + string.Join(">", LowLevelStack);
	}

	public CopyOver()
	{
		AppliedRowDelta = new Dictionary<string, List<Row_Delta>>();
		AppliedFieldDelta = new Dictionary<string, List<Field_Delta>>();
		HighLevelStack = new List<string>();
		LowLevelStack = new List<string>();
		MyProject.Forms.DBToolsForm.LV_Loading.Items.Add(new DarkListItem("--COPY OVER INITIATED--"));
		MyProject.Forms.DBToolsForm.LV_Loading.Items.Add(new DarkListItem("Loading source DB into ram"));
		((Label)MyProject.Forms.DBToolsForm.Label_JobInProgress).Text = "Loading source RAMdb";
		((Control)MyProject.Forms.DBToolsForm).Refresh();
		SourceDB_Ram = new Ram_Database(Common.mySourceDB_Helper, IsSource: true, Path.GetFileName(Common.theSourceMsAccessFileName).Replace(".mdb", "").Replace("_", ""));
		((Label)MyProject.Forms.DBToolsForm.Label_JobInProgress).Text = "Loading target RAMdb";
		MyProject.Forms.DBToolsForm.LV_Loading.Items.Add(new DarkListItem("Loading target DB into ram"));
		((Control)MyProject.Forms.DBToolsForm).Refresh();
		TargetDB_Ram = new Ram_Database(Common.myTargetDB_Helper, IsSource: false, Path.GetFileName(Common.theTargetMsAccessFileName).Replace(".mdb", "").Replace("_", ""));
	}

	public void OpenRamDBBrowser()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if (SourceDB_Ram != null)
		{
			HashtableNodeEditor hashtableNodeEditor = new HashtableNodeEditor();
			hashtableNodeEditor.Refresh_Global(this);
			((Form)hashtableNodeEditor).ShowDialog();
		}
	}

	public void GenerateDeltaReportReport()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (!TargetDB_Ram.Tables.ContainsKey("EnumOperatorCountry"))
		{
			MessageBox.Show("Error : RamDB_Config MUST contains a definition for EnumOperatorCountry to generate a report.", "Error while generating report", (MessageBoxButtons)0, (MessageBoxIcon)16);
			return;
		}
		string text = "";
		Hashtable hashtable = TargetDB_Ram.Tables["EnumOperatorCountry"];
		Dictionary<string, List<Row_Delta>> dictionary = new Dictionary<string, List<Row_Delta>>();
		foreach (KeyValuePair<string, List<Row_Delta>> appliedRowDeltum in AppliedRowDelta)
		{
			text = text + "--------------------------------" + Environment.NewLine;
			text = text + appliedRowDeltum.Key.ToUpper() + Environment.NewLine;
			text = text + "--------------------------------" + Environment.NewLine;
			foreach (Row_Delta item in appliedRowDeltum.Value)
			{
				if (item.Table.IsParent())
				{
					string text2 = "";
					text2 = ((item.Method != MethodDelta.Addition) ? (text2 + "[REMOVED] ") : (text2 + "[ADDED] "));
					text2 = ((!string.IsNullOrEmpty(item.Name)) ? (text2 + item.Name) : (text2 + item.ID));
					if (item.Value.FieldsByColumns.ContainsKey("OperatorCountry") && hashtable.Rows.ContainsKey(item.Value.FieldsByColumns["OperatorCountry"].Value))
					{
						text2 = text2 + ", " + hashtable.Rows[item.Value.FieldsByColumns["OperatorCountry"].Value][0].FieldsByColumns["Description"].Value;
					}
					if (item.Value.FieldsByColumns.ContainsKey("YearCommissioned"))
					{
						text2 = text2 + " [" + item.Value.FieldsByColumns["YearCommissioned"].Value;
						if (item.Value.FieldsByColumns.ContainsKey("YearDecommissioned"))
						{
							text2 = text2 + "-" + item.Value.FieldsByColumns["YearDecommissioned"].Value;
						}
						text2 += "]";
					}
					text = text + text2 + Environment.NewLine;
				}
				else
				{
					if (!dictionary.ContainsKey(item.Table.Node.DisplayName))
					{
						dictionary.Add(item.Table.Node.DisplayName, new List<Row_Delta>());
					}
					dictionary[item.Table.Node.DisplayName].Add(item);
				}
			}
		}
		foreach (KeyValuePair<string, List<Field_Delta>> appliedFieldDeltum in AppliedFieldDelta)
		{
			if (appliedFieldDeltum.Value.Count == 0)
			{
				continue;
			}
			text = text + "--------------------------------" + Environment.NewLine;
			text = text + "MODIFIED " + appliedFieldDeltum.Key.ToUpper() + Environment.NewLine;
			text = text + "--------------------------------" + Environment.NewLine;
			foreach (Field_Delta item2 in appliedFieldDeltum.Value)
			{
				string text3 = "";
				text3 = text3 + item2.Column + " [ID : " + item2.ID + "] " + item2.OriginalValue + " ---> " + item2.TargetValue;
				text = text + text3 + Environment.NewLine;
			}
			if (!dictionary.ContainsKey(appliedFieldDeltum.Key))
			{
				continue;
			}
			foreach (Row_Delta item3 in dictionary[appliedFieldDeltum.Key])
			{
				string text4 = "";
				text4 = ((item3.Method != MethodDelta.Addition) ? (text4 + "[REMOVED CODE/COMPONENT] ") : (text4 + "[ADDED CODE/COMPONENT] "));
				Information.IsNothing((object)item3.Table.Node.ParentHashtable);
				string text5 = "Primary";
				if (!string.IsNullOrEmpty(item3.Table.ReferencedDatatable))
				{
					text5 = item3.Table.ReferencedDatatable;
				}
				if (!Information.IsNothing((object)item3.Table.Node))
				{
					text5 = item3.Table.Node._DisplayName;
				}
				string componentOrCodeID = item3.Value.GetComponentOrCodeID();
				string text6 = "";
				int num;
				if (!string.IsNullOrEmpty(componentOrCodeID) && item3.Table.type == Table_Type.Component)
				{
					text6 = "(" + item3.Table.GetComponentData(componentOrCodeID).Name + ")";
					num = 11;
				}
				else
				{
					num = 11;
				}
				string[] array = new string[num];
				array[0] = text4;
				array[1] = "For ";
				array[2] = text5;
				array[3] = " #";
				array[4] = item3.ID;
				array[5] = ", ";
				array[6] = item3.Table.Name;
				array[7] = " ID #";
				array[8] = componentOrCodeID;
				array[9] = " ";
				array[10] = text6;
				text4 = string.Concat(array);
				text = text + text4 + Environment.NewLine;
			}
		}
		((RichTextBox)MyProject.Forms.DBToolsForm.Report).Text = text;
	}

	public void DoCopyOver()
	{
		MyProject.Forms.DBToolsForm.ClearOperationStack();
		foreach (KeyValuePair<string, HashtableNode> item in SourceDB_Ram.Tables_Node)
		{
			new HashTableNode_Pair(item.Value, TargetDB_Ram.Tables_Node[item.Key], item.Value.DisplayName, SourceDB_Ram, TargetDB_Ram).Perform_CopyOver(this);
			if (MyProject.Forms.DBToolsForm._PendingCopyOverAbortion)
			{
				break;
			}
		}
		MyProject.Forms.DBToolsForm._PendingCopyOverAbortion = false;
		GenerateDeltaReportReport();
		if (MyProject.Forms.DBToolsForm.DebugMode)
		{
			MyProject.Forms.DBToolsForm.SaveOperationStack();
		}
	}

	static CopyOver()
	{
		Class72.smethod_20();
	}
}

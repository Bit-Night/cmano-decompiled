using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class CopyOverSimilarityPrompt : DarkSecondaryFormBase
{
	public class LV_Item
	{
		public HashTable_Row Value;

		public float SimilarityValue;

		public bool OwnTable;

		public string Name
		{
			get
			{
				string text = "";
				int num;
				if (!OwnTable)
				{
					text += "(External)";
					num = 8;
				}
				else
				{
					text += "(Own)";
					num = 8;
				}
				string[] array = new string[num];
				array[0] = text;
				array[1] = " [#";
				array[2] = Value.GetID();
				array[3] = "] ";
				array[4] = Value.Name;
				array[5] = " (";
				array[6] = (SimilarityValue * 100f).ToString("#.#");
				array[7] = "%)";
				return string.Concat(array);
			}
		}

		public LV_Item(HashTable_Row _Value, float _SimilarityValue, bool _OwnTable)
		{
			OwnTable = false;
			SimilarityValue = _SimilarityValue;
			Value = _Value;
			OwnTable = _OwnTable;
		}

		static LV_Item()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_Similarities")]
	private ListBox _LV_Similarities;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AbortCopyOver")]
	private DarkButton _Button_AbortCopyOver;

	public Dictionary<HashTable_Row, float> SimilarEntries_Own;

	public Dictionary<HashTable_Row, float> SimilarEntries_External;

	public HashTable_Row CurrentRow;

	public List<HashTable_Row> SimilaritiesRows;

	public LV_Item SelectedCandidate;

	public HashTableNode_Pair NodePair;

	internal virtual ListBox LV_Similarities
	{
		[CompilerGenerated]
		get
		{
			return _LV_Similarities;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			ListBox val = _LV_Similarities;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_LV_Similarities = value;
			val = _LV_Similarities;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_Similarities")]
	internal virtual DarkLabel Label_Similarities { get; set; }

	[field: AccessedThroughProperty("ButtonSkip")]
	internal virtual DarkButton ButtonSkip { get; set; }

	[field: AccessedThroughProperty("Button_SelectedCandidate")]
	internal virtual DarkButton Button_SelectedCandidate { get; set; }

	[field: AccessedThroughProperty("Button_IgnoreCandidateAndProceed")]
	internal virtual DarkButton Button_IgnoreCandidateAndProceed { get; set; }

	[field: AccessedThroughProperty("LV_SelectedSimilar_Delta")]
	internal virtual ListBox LV_SelectedSimilar_Delta { get; set; }

	[field: AccessedThroughProperty("Label_Row")]
	internal virtual DarkLabel Label_Row { get; set; }

	[field: AccessedThroughProperty("TB_InfoUseSelected")]
	internal virtual DarkRichTextBox TB_InfoUseSelected { get; set; }

	[field: AccessedThroughProperty("RichTextBox1")]
	internal virtual DarkRichTextBox RichTextBox1 { get; set; }

	[field: AccessedThroughProperty("RichTextBox2")]
	internal virtual DarkRichTextBox RichTextBox2 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("TB_Info")]
	internal virtual DarkRichTextBox TB_Info { get; set; }

	internal virtual DarkButton Button_AbortCopyOver
	{
		[CompilerGenerated]
		get
		{
			return _Button_AbortCopyOver;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkButton darkButton = _Button_AbortCopyOver;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_AbortCopyOver = value;
			darkButton = _Button_AbortCopyOver;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	public CopyOverSimilarityPrompt()
	{
		((Form)this).Shown += CopyOverSimilarityPrompt_Shown;
		SimilarEntries_Own = new Dictionary<HashTable_Row, float>();
		SimilarEntries_External = new Dictionary<HashTable_Row, float>();
		SimilaritiesRows = new List<HashTable_Row>();
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_1 != null)
			{
				icontainer_1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CopyOverSimilarityPrompt));
		LV_Similarities = new ListBox();
		Label_Similarities = new DarkLabel();
		ButtonSkip = new DarkButton();
		Button_SelectedCandidate = new DarkButton();
		Button_IgnoreCandidateAndProceed = new DarkButton();
		LV_SelectedSimilar_Delta = new ListBox();
		Label_Row = new DarkLabel();
		TB_InfoUseSelected = new DarkRichTextBox();
		RichTextBox1 = new DarkRichTextBox();
		RichTextBox2 = new DarkRichTextBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		TB_Info = new DarkRichTextBox();
		Button_AbortCopyOver = new DarkButton();
		((Control)this).SuspendLayout();
		LV_Similarities.BackColor = Color.FromArgb(60, 63, 65);
		LV_Similarities.ForeColor = Color.Gainsboro;
		((ListControl)LV_Similarities).FormattingEnabled = true;
		LV_Similarities.ItemHeight = 15;
		((Control)LV_Similarities).Location = new Point(12, 107);
		((Control)LV_Similarities).Name = "LV_Similarities";
		((Control)LV_Similarities).Size = new Size(463, 229);
		((Control)LV_Similarities).TabIndex = 0;
		Label_Similarities.AutoSize = true;
		((Control)Label_Similarities).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Similarities).Location = new Point(9, 91);
		((Control)Label_Similarities).Name = "Label_Similarities";
		((Control)Label_Similarities).Size = new Size(312, 15);
		((Control)Label_Similarities).TabIndex = 1;
		((Label)Label_Similarities).Text = "Theses entries have high similarities, select your candidate";
		((Button)ButtonSkip).AutoSizeMode = (AutoSizeMode)0;
		((Button)ButtonSkip).DialogResult = (DialogResult)3;
		((Control)ButtonSkip).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonSkip).Location = new Point(12, 459);
		((Control)ButtonSkip).Name = "ButtonSkip";
		((Control)ButtonSkip).Padding = new Padding(5);
		((Control)ButtonSkip).Size = new Size(338, 47);
		((Control)ButtonSkip).TabIndex = 2;
		ButtonSkip.Text = "Skip copy-over";
		((Button)Button_SelectedCandidate).AutoSizeMode = (AutoSizeMode)0;
		((Button)Button_SelectedCandidate).DialogResult = (DialogResult)6;
		((Control)Button_SelectedCandidate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_SelectedCandidate).Location = new Point(12, 404);
		((Control)Button_SelectedCandidate).Name = "Button_SelectedCandidate";
		((Control)Button_SelectedCandidate).Padding = new Padding(5);
		((Control)Button_SelectedCandidate).Size = new Size(338, 49);
		((Control)Button_SelectedCandidate).TabIndex = 3;
		Button_SelectedCandidate.Text = "Create new entry from selected candidate";
		((Button)Button_IgnoreCandidateAndProceed).AutoSizeMode = (AutoSizeMode)0;
		((Button)Button_IgnoreCandidateAndProceed).DialogResult = (DialogResult)1;
		((Control)Button_IgnoreCandidateAndProceed).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_IgnoreCandidateAndProceed).Location = new Point(12, 351);
		((Control)Button_IgnoreCandidateAndProceed).Name = "Button_IgnoreCandidateAndProceed";
		((Control)Button_IgnoreCandidateAndProceed).Padding = new Padding(5);
		((Control)Button_IgnoreCandidateAndProceed).Size = new Size(338, 47);
		((Control)Button_IgnoreCandidateAndProceed).TabIndex = 4;
		Button_IgnoreCandidateAndProceed.Text = "Ignore candidates and proceed";
		LV_SelectedSimilar_Delta.BackColor = Color.FromArgb(60, 63, 65);
		LV_SelectedSimilar_Delta.ForeColor = Color.Gainsboro;
		LV_SelectedSimilar_Delta.ItemHeight = 15;
		((Control)LV_SelectedSimilar_Delta).Location = new Point(481, 107);
		((Control)LV_SelectedSimilar_Delta).Name = "LV_SelectedSimilar_Delta";
		((Control)LV_SelectedSimilar_Delta).Size = new Size(491, 229);
		((Control)LV_SelectedSimilar_Delta).TabIndex = 5;
		LV_SelectedSimilar_Delta.SelectionMode = (SelectionMode)0;
		Label_Row.AutoSize = true;
		((Control)Label_Row).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Row).Location = new Point(13, 13);
		((Control)Label_Row).Name = "Label_Row";
		((Control)Label_Row).Size = new Size(41, 15);
		((Control)Label_Row).TabIndex = 6;
		((Label)Label_Row).Text = "Label2";
		((TextBoxBase)TB_InfoUseSelected).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)TB_InfoUseSelected).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_InfoUseSelected).Location = new Point(360, 404);
		((Control)TB_InfoUseSelected).Name = "TB_InfoUseSelected";
		((TextBoxBase)TB_InfoUseSelected).ReadOnly = true;
		((Control)TB_InfoUseSelected).RightToLeft = (RightToLeft)0;
		((Control)TB_InfoUseSelected).Size = new Size(616, 46);
		((Control)TB_InfoUseSelected).TabIndex = 7;
		((RichTextBox)TB_InfoUseSelected).Text = componentResourceManager.GetString("TB_InfoUseSelected.Text");
		((TextBoxBase)RichTextBox1).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)RichTextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox1).Location = new Point(360, 352);
		((Control)RichTextBox1).Name = "RichTextBox1";
		((TextBoxBase)RichTextBox1).ReadOnly = true;
		((Control)RichTextBox1).RightToLeft = (RightToLeft)0;
		((Control)RichTextBox1).Size = new Size(616, 46);
		((Control)RichTextBox1).TabIndex = 8;
		((RichTextBox)RichTextBox1).Text = "If no viable candidate were found, you can decide to add a brand new entry to the database.";
		((TextBoxBase)RichTextBox2).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)RichTextBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox2).Location = new Point(356, 459);
		((Control)RichTextBox2).Name = "RichTextBox2";
		((TextBoxBase)RichTextBox2).ReadOnly = true;
		((Control)RichTextBox2).RightToLeft = (RightToLeft)0;
		((Control)RichTextBox2).Size = new Size(616, 46);
		((Control)RichTextBox2).TabIndex = 9;
		((RichTextBox)RichTextBox2).Text = "Skip the procedure, to pospone a copy-over or in case you are prompted to double-check  similar entry.";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(792, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(197, 15);
		((Control)Label1).TabIndex = 10;
		((Label)Label1).Text = "Own : entries in the source database";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(781, 30);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(210, 15);
		((Control)Label2).TabIndex = 11;
		((Label)Label2).Text = "External : entries in the target database";
		((TextBoxBase)TB_Info).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)TB_Info).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_Info).Location = new Point(12, 27);
		((Control)TB_Info).Name = "TB_Info";
		((TextBoxBase)TB_Info).ReadOnly = true;
		((Control)TB_Info).RightToLeft = (RightToLeft)0;
		((Control)TB_Info).Size = new Size(697, 61);
		((Control)TB_Info).TabIndex = 12;
		((RichTextBox)TB_Info).Text = "";
		((Button)Button_AbortCopyOver).AutoSizeMode = (AutoSizeMode)0;
		((ButtonBase)Button_AbortCopyOver).BackColor = Color.IndianRed;
		((Control)Button_AbortCopyOver).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_AbortCopyOver).Location = new Point(12, 512);
		((Control)Button_AbortCopyOver).Name = "Button_AbortCopyOver";
		((Control)Button_AbortCopyOver).Padding = new Padding(5);
		((Control)Button_AbortCopyOver).Size = new Size(960, 31);
		((Control)Button_AbortCopyOver).TabIndex = 13;
		Button_AbortCopyOver.Text = "SHEDULE COPY OVER ABORTION";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(984, 546);
		((Control)this).Controls.Add((Control)(object)Button_AbortCopyOver);
		((Control)this).Controls.Add((Control)(object)TB_Info);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)RichTextBox2);
		((Control)this).Controls.Add((Control)(object)RichTextBox1);
		((Control)this).Controls.Add((Control)(object)TB_InfoUseSelected);
		((Control)this).Controls.Add((Control)(object)Button_IgnoreCandidateAndProceed);
		((Control)this).Controls.Add((Control)(object)Button_SelectedCandidate);
		((Control)this).Controls.Add((Control)(object)Label_Row);
		((Control)this).Controls.Add((Control)(object)ButtonSkip);
		((Control)this).Controls.Add((Control)(object)LV_SelectedSimilar_Delta);
		((Control)this).Controls.Add((Control)(object)Label_Similarities);
		((Control)this).Controls.Add((Control)(object)LV_Similarities);
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximumSize = new Size(1000, 585);
		((Form)this).MinimumSize = new Size(1000, 557);
		((Control)this).Name = "CopyOverSimilarityPrompt";
		((Form)this).Text = "CopyOverSimilarityPrompt";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void CopyOverSimilarityPrompt_Shown(object sender, EventArgs e)
	{
		LV_Similarities.Items.Clear();
		((ListControl)LV_Similarities).DisplayMember = "Name";
		((ListControl)LV_SelectedSimilar_Delta).DisplayMember = "Text";
		((Label)Label_Row).Text = "[#" + CurrentRow.GetID() + "] " + CurrentRow.Name;
		List<LV_Item> list = new List<LV_Item>();
		foreach (KeyValuePair<HashTable_Row, float> item in SimilarEntries_Own)
		{
			list.Add(new LV_Item(item.Key, item.Value, _OwnTable: true));
		}
		foreach (KeyValuePair<HashTable_Row, float> item2 in SimilarEntries_External)
		{
			list.Add(new LV_Item(item2.Key, item2.Value, _OwnTable: false));
		}
		list.Sort([SpecialName] (LV_Item y, LV_Item x) => x.SimilarityValue.CompareTo(y.SimilarityValue));
		foreach (LV_Item item3 in list)
		{
			LV_Similarities.Items.Add((object)item3);
		}
		((Label)Label_Similarities).Text = list.Count + " similar entries. Select your candidate.";
		method_2();
	}

	private void method_2()
	{
		if (!MyProject.Forms.DBToolsForm._PendingCopyOverAbortion)
		{
			Button_AbortCopyOver.Text = "SHEDULE COPY OVER PAUSE";
		}
		else
		{
			Button_AbortCopyOver.Text = "Copy over pause is already sheduled for the next node.";
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(LV_Similarities.SelectedItem)))
		{
			SelectedCandidate = (LV_Item)LV_Similarities.SelectedItem;
			method_4();
		}
	}

	private void method_4()
	{
		LV_SelectedSimilar_Delta.Items.Clear();
		if (SelectedCandidate == null || SelectedCandidate.Value == null)
		{
			return;
		}
		if (SelectedCandidate.OwnTable)
		{
			Button_SelectedCandidate.Text = "Change ID reference (skips duplicate)";
		}
		else
		{
			Button_SelectedCandidate.Text = "Create new entry from selected candidate";
		}
		string value = SelectedCandidate.Value.FieldsByColumns["ID"].Value;
		string value2 = CurrentRow.FieldsByColumns["ID"].Value;
		if (NodePair != null)
		{
			Dictionary<string, Table_Delta> delta = NodePair.GetDelta(value, value2);
			{
				foreach (KeyValuePair<string, Table_Delta> item in delta)
				{
					foreach (Field_Delta fieldDelta in item.Value.FieldDeltas)
					{
						LV_SelectedSimilar_Delta.Items.Add((object)(fieldDelta.Column + " : " + fieldDelta.OriginalValue + " --> " + fieldDelta.TargetValue));
					}
					foreach (Row_Delta rowDelta in item.Value.RowDeltas)
					{
						string text = "ID : " + value;
						if (rowDelta.Value != null)
						{
							foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in rowDelta.Value.FieldsByColumns)
							{
								text = text + fieldsByColumn.Key + " : " + fieldsByColumn.Value.Value + " | ";
							}
						}
						LV_SelectedSimilar_Delta.Items.Add((object)("[" + rowDelta.Table.Name + "] ( " + rowDelta.Method.ToString() + " )  " + text));
					}
				}
				return;
			}
		}
		foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn2 in SelectedCandidate.Value.FieldsByColumns)
		{
			if (Operators.CompareString(fieldsByColumn2.Value.Value, CurrentRow.FieldsByColumns[fieldsByColumn2.Key].Value, true) != 0)
			{
				LV_SelectedSimilar_Delta.Items.Add((object)new DarkListItem(fieldsByColumn2.Key + " : " + CurrentRow.FieldsByColumns[fieldsByColumn2.Key].Value + " --> " + fieldsByColumn2.Value.Value));
			}
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		MyProject.Forms.DBToolsForm._PendingCopyOverAbortion = true;
		method_2();
	}

	static CopyOverSimilarityPrompt()
	{
		Class72.smethod_20();
	}
}

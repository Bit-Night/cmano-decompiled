using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitDecisionChecklistWindow : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	private bool bool_2;

	public string SelectedUnitID;

	private string string_0;

	private DateTime dateTime_0;

	[field: AccessedThroughProperty("RootFlowLayoutPanel")]
	internal virtual FlowLayoutPanel RootFlowLayoutPanel { get; set; }

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		RootFlowLayoutPanel = new FlowLayoutPanel();
		((Control)this).SuspendLayout();
		((Control)RootFlowLayoutPanel).Dock = (DockStyle)5;
		((Control)RootFlowLayoutPanel).Location = new Point(0, 0);
		((Control)RootFlowLayoutPanel).Margin = new Padding(0);
		((Control)RootFlowLayoutPanel).Name = "RootFlowLayoutPanel";
		((Control)RootFlowLayoutPanel).Size = new Size(643, 345);
		((Control)RootFlowLayoutPanel).TabIndex = 0;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(643, 345);
		((Control)this).Controls.Add((Control)(object)RootFlowLayoutPanel);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "UnitDecisionChecklistWindow";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Unit Message Log";
		((Control)this).ResumeLayout(false);
	}

	private void UnitDecisionChecklistWindow_Resize(object sender, EventArgs e)
	{
		RefreshWindow(OnlyIfNewMessages: false);
		method_2();
	}

	[DllImport("user32.dll")]
	private static extern IntPtr SetActiveWindow(IntPtr intptr_0);

	public UnitDecisionChecklistWindow()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Control)this).Resize += UnitDecisionChecklistWindow_Resize;
		((Form)this).FormClosing += new FormClosingEventHandler(UnitDecisionChecklistWindow_FormClosing);
		((Form)this).Load += UnitDecisionChecklistWindow_Load;
		((Control)this).Resize += UnitDecisionChecklistWindow_Resize_1;
		((Form)this).Shown += UnitDecisionChecklistWindow_Shown;
		RTMPEnabled = true;
		InitializeComponent_1();
		((Control)this).SetStyle((ControlStyles)512, false);
	}

	private void UnitDecisionChecklistWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void UnitDecisionChecklistWindow_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void UnitDecisionChecklistWindow_Resize_1(object sender, EventArgs e)
	{
		RefreshWindow(OnlyIfNewMessages: false);
		method_2();
	}

	private void UnitDecisionChecklistWindow_Shown(object sender, EventArgs e)
	{
		Client.MustRefreshMainForm = true;
		ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[SelectedUnitID];
		if (activeUnit != null)
		{
			((Form)this).Text = "AI decision checklist log for: " + activeUnit.Name;
		}
		RefreshWindow(OnlyIfNewMessages: false);
	}

	public void Clear()
	{
		string_0 = null;
		dateTime_0 = DateTime.MinValue;
		((Control)RootFlowLayoutPanel).Controls.Clear();
	}

	public void RefreshWindow(bool OnlyIfNewMessages, bool TriggeredByMainform = false)
	{
		if (!((Control)this).Visible)
		{
			return;
		}
		if (SelectedUnitID != null)
		{
			ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[SelectedUnitID];
			if (activeUnit != null)
			{
				activeUnit.AI.ActiveSecondsLeftInDebugModeAI = activeUnit.get_UnitSide(SetSideOnly: false).ParentScen.TimeCompression_SimSeconds * 10;
				Queue<(DateTime, List<DecisionChecklist.Result>)> statusEvaluationDebugHistory = activeUnit.AI.StatusEvaluationDebugHistory;
				if (statusEvaluationDebugHistory != null && statusEvaluationDebugHistory.Count != 0)
				{
					if (!SelectedUnitID.Equals(string_0) || !dateTime_0.Equals(statusEvaluationDebugHistory.Last().Item1))
					{
						((Control)RootFlowLayoutPanel).Controls.Clear();
						foreach (var item in statusEvaluationDebugHistory)
						{
							DarkRichTextBox darkRichTextBox = new DarkRichTextBox();
							((Control)RootFlowLayoutPanel).Controls.Add((Control)(object)darkRichTextBox);
							AppendLine((RichTextBox)(object)darkRichTextBox, item.Item1.ToString(), Color.Red, bold: true);
							foreach (DecisionChecklist.Result item2 in item.Item2)
							{
								AppendLine((RichTextBox)(object)darkRichTextBox, item2.decisionItemName, Color.White, bold: true);
								AppendLine(color: (!item2.isBlocking()) ? Color.LightGreen : Color.LightCoral, rtb: (RichTextBox)(object)darkRichTextBox, text: "   " + item2.reason, bold: false);
								if (item2.finalStatus.HasValue)
								{
									AppendLine((RichTextBox)(object)darkRichTextBox, "        " + Misc.ToEnglishString(item2.finalStatus.Value, activeUnit), Color.DeepSkyBlue, bold: true);
								}
							}
							(dateTime_0, _) = item;
						}
						method_2();
					}
					string_0 = SelectedUnitID;
				}
				else
				{
					Clear();
				}
			}
			else
			{
				Clear();
			}
		}
		else
		{
			Clear();
		}
	}

	public void AppendLine(RichTextBox rtb, string text, Color color, bool bold)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((TextBoxBase)rtb).SelectionStart = rtb.TextLength;
		rtb.SelectionLength = 0;
		rtb.SelectionColor = color;
		rtb.SelectionFont = new Font(rtb.Font, (FontStyle)(bold ? 1 : 0));
		((TextBoxBase)rtb).AppendText(text);
		((TextBoxBase)rtb).AppendText(Environment.NewLine);
		rtb.SelectionColor = rtb.ForeColor;
		rtb.SelectionFont = rtb.Font;
	}

	private void method_2()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		foreach (Control control in ((Control)RootFlowLayoutPanel).Controls)
		{
			control.Height = ((Control)RootFlowLayoutPanel).Height - 10;
			control.Width = (int)Math.Round((double)((Control)RootFlowLayoutPanel).Width / (double)((ArrangedElementCollection)((Control)RootFlowLayoutPanel).Controls).Count) - 10;
		}
	}

	static UnitDecisionChecklistWindow()
	{
		Class72.smethod_20();
	}
}

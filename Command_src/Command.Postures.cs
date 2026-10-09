using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Postures : DarkSecondaryFormBase
{
	public enum PostureChangeMode
	{
		ScenarioEditor,
		Player
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("LB_Sides")]
	private DarkListView _LB_Sides;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox1")]
	private DarkUIComboBox _ComboBox1;

	public Side SelectedSide;

	public Side TargetSide;

	public int Mode;

	[CompilerGenerated]
	private bool bool_2;

	internal virtual DarkListView LB_Sides
	{
		[CompilerGenerated]
		get
		{
			return _LB_Sides;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_2;
			DarkListView darkListView = _LB_Sides;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LB_Sides = value;
			darkListView = _LB_Sides;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIComboBox darkUIComboBox = _ComboBox1;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox1 = value;
			darkUIComboBox = _ComboBox1;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

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

	public Postures()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += Postures_Load;
		((Control)this).KeyDown += new KeyEventHandler(Postures_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(Postures_FormClosing);
		Mode = 0;
		RTMPEnabled = true;
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
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		LB_Sides = new DarkListView();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		ComboBox1 = new DarkUIComboBox();
		((Control)this).SuspendLayout();
		((Control)LB_Sides).Anchor = (AnchorStyles)15;
		((Control)LB_Sides).Location = new Point(12, 25);
		((Control)LB_Sides).Name = "LB_Sides";
		((Control)LB_Sides).Size = new Size(214, 147);
		((Control)LB_Sides).TabIndex = 1;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(9, 9);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(99, 15);
		((Control)Label1).TabIndex = 4;
		((Label)Label1).Text = "Select target side:";
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(9, 188);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(224, 13);
		((Control)Label2).TabIndex = 5;
		Label2.AutoSize = true;
		((Label)Label2).Text = "Consider this side to be...";
		((ComboBox)ComboBox1).BackColor = Color.Transparent;
		((ComboBox)ComboBox1).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox1).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox1).Font = new Font("Segoe UI", 7f);
		((ListControl)ComboBox1).FormattingEnabled = true;
		((ComboBox)ComboBox1).Items.AddRange(new object[4] { "Neutral", "Friendly", "Unfriendly", "Hostile" });
		((Control)ComboBox1).Location = new Point(12, 204);
		((Control)ComboBox1).Name = "ComboBox1";
		((Control)ComboBox1).Size = new Size(216, 21);
		((Control)ComboBox1).TabIndex = 6;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(238, 233);
		((Control)this).Controls.Add((Control)(object)ComboBox1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)LB_Sides);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Postures";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Postures";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void Postures_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Form)this).Text = "Postures for side: " + SelectedSide.Name;
		((Label)Label2).Text = SelectedSide.Name + " consider this side to be...";
		foreach (Side item in Client.CurrentScenario.Sides_ReadOnly.OrderBy([SpecialName] (Side theS) => theS.Name))
		{
			if (item != SelectedSide)
			{
				LB_Sides.Items.Add(new DarkListItem(item.Name));
			}
		}
		if (LB_Sides.Items.Count > 0)
		{
			LB_Sides.SelectItem(0);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		if (LB_Sides.SelectedIndices.Count == 0)
		{
			return;
		}
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (Operators.CompareString(side.Name, LB_Sides.SelectedItems[0].Text, true) == 0)
			{
				TargetSide = side;
				break;
			}
		}
		((ComboBox)ComboBox1).SelectedIndex = (int)SelectedSide.get_ConsidersThisSideToBe(TargetSide, (Scenario)null);
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		if (Information.IsNothing((object)TargetSide))
		{
			DarkMessageBox.ShowError("First, select a target side for which the posture will apply.", "No target side selected!");
			return;
		}
		bool flag = true;
		Misc.PostureStance postureStance = (Misc.PostureStance)((ComboBox)ComboBox1).SelectedIndex;
		if (Mode == 1 && postureStance != Misc.PostureStance.Hostile && SelectedSide.get_ConsidersThisSideToBe(TargetSide, (Scenario)null) == Misc.PostureStance.Hostile && TargetSide.get_ConsidersThisSideToBe(SelectedSide, (Scenario)null) == Misc.PostureStance.Hostile)
		{
			flag = (int)DarkMessageBox.ShowWarning("You are adopting a non-hostile posture towards a hostile side. This may cause problems in some scenarios where mutual hostility is assumed. Do you wish to set the non-hostile posture anyway?", "Adopting Non-Hostile Posture", DarkDialogButton.OkCancel) == 1;
		}
		if (!flag)
		{
			((ComboBox)ComboBox1).SelectedIndex = (int)SelectedSide.get_ConsidersThisSideToBe(TargetSide, (Scenario)null);
			return;
		}
		SelectedSide.set_ConsidersThisSideToBe(TargetSide, (Scenario)null, postureStance);
		int mustRefreshMainForm;
		if (Client.Realtime && !Client.RealtimeAC)
		{
			Client.RealtimeTerminal.SendSidePostureUpdate();
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void Postures_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
	}

	private void Postures_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static Postures()
	{
		Class72.smethod_20();
	}
}

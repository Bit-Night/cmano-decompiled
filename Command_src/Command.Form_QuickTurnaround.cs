using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Form_QuickTurnaround : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("CB_QuickTurnaround")]
	[CompilerGenerated]
	private DarkCheckBox _CB_QuickTurnaround;

	[AccessedThroughProperty("Combo_NumberOfSorties")]
	[CompilerGenerated]
	private DarkUIComboBox _Combo_NumberOfSorties;

	[CompilerGenerated]
	private bool bool_2;

	private Aircraft aircraft_0;

	private int int_0;

	private int int_1;

	private bool bool_3;

	internal virtual DarkCheckBox CB_QuickTurnaround
	{
		[CompilerGenerated]
		get
		{
			return _CB_QuickTurnaround;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = pkhLydCxyuI;
			DarkCheckBox darkCheckBox = _CB_QuickTurnaround;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_QuickTurnaround = value;
			darkCheckBox = _CB_QuickTurnaround;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox Combo_NumberOfSorties
	{
		[CompilerGenerated]
		get
		{
			return _Combo_NumberOfSorties;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIComboBox darkUIComboBox = _Combo_NumberOfSorties;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_Combo_NumberOfSorties = value;
			darkUIComboBox = _Combo_NumberOfSorties;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_QuickTurnaroundInfo")]
	internal virtual DarkLabel Label_QuickTurnaroundInfo { get; set; }

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

	public Form_QuickTurnaround()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(Form_QuickTurnaround_FormClosing);
		((Form)this).Load += cqrLyGhqRra;
		((Control)this).KeyDown += new KeyEventHandler(Form_QuickTurnaround_KeyDown);
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
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		CB_QuickTurnaround = new DarkCheckBox();
		Combo_NumberOfSorties = new DarkUIComboBox();
		Label_QuickTurnaroundInfo = new DarkLabel();
		((Control)this).SuspendLayout();
		((ButtonBase)CB_QuickTurnaround).AutoSize = true;
		((Control)CB_QuickTurnaround).Location = new Point(11, 12);
		((Control)CB_QuickTurnaround).Name = "CB_QuickTurnaround";
		((Control)CB_QuickTurnaround).Size = new Size(161, 19);
		((Control)CB_QuickTurnaround).TabIndex = 0;
		((ButtonBase)CB_QuickTurnaround).Text = "Enable Quick Turnaround";
		((ComboBox)Combo_NumberOfSorties).BackColor = Color.Transparent;
		((ComboBox)Combo_NumberOfSorties).DrawMode = (DrawMode)1;
		((ComboBox)Combo_NumberOfSorties).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_NumberOfSorties).Font = new Font("Segoe UI", 7f);
		((ListControl)Combo_NumberOfSorties).FormattingEnabled = true;
		((Control)Combo_NumberOfSorties).Location = new Point(178, 11);
		((Control)Combo_NumberOfSorties).Name = "Combo_NumberOfSorties";
		((Control)Combo_NumberOfSorties).Size = new Size(147, 21);
		((Control)Combo_NumberOfSorties).TabIndex = 1;
		Label_QuickTurnaroundInfo.AutoSize = true;
		((Control)Label_QuickTurnaroundInfo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_QuickTurnaroundInfo).Location = new Point(331, 16);
		((Control)Label_QuickTurnaroundInfo).Name = "Label_QuickTurnaroundInfo";
		((Control)Label_QuickTurnaroundInfo).Size = new Size(155, 15);
		((Control)Label_QuickTurnaroundInfo).TabIndex = 2;
		((Label)Label_QuickTurnaroundInfo).Text = "Label_QuickTurnaroundInfo";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(483, 44);
		((Control)this).Controls.Add((Control)(object)Label_QuickTurnaroundInfo);
		((Control)this).Controls.Add((Control)(object)Combo_NumberOfSorties);
		((Control)this).Controls.Add((Control)(object)CB_QuickTurnaround);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Form_QuickTurnaround";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Quick Turnaround configuration for airborne aircraft for";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void Form_QuickTurnaround_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		Client.MustRefreshMainForm = true;
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
		}
	}

	private void cqrLyGhqRra(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Control)MyProject.Forms.MainForm).Enabled = false;
		((Form)this).Text = ((Form)this).Text + " " + Client.SelectedUnit.Name;
		bool_3 = false;
		((Label)Label_QuickTurnaroundInfo).Text = "";
		((Control)CB_QuickTurnaround).Enabled = false;
		((Control)Combo_NumberOfSorties).Enabled = false;
		if (!Information.IsNothing((object)Client.SelectedUnit) && Client.SelectedUnit.IsAircraft)
		{
			aircraft_0 = (Aircraft)Client.SelectedUnit;
			if (!Information.IsNothing((object)aircraft_0.Loadout) && aircraft_0.Loadout.QuickTurnaround)
			{
				Aircraft_AirOps airOps = aircraft_0.AirOps;
				int_1 = aircraft_0.Loadout.QuickTurnaround_MaxSorties;
				((Control)CB_QuickTurnaround).Enabled = true;
				((CheckBox)CB_QuickTurnaround).Checked = airOps.QuickTurnaround_Enabled;
				((Control)Combo_NumberOfSorties).Enabled = airOps.QuickTurnaround_Enabled;
				method_2(airOps.QuickTurnaround_SortiesTotal, ref aircraft_0);
			}
		}
		bool_3 = true;
	}

	private void pkhLydCxyuI(object sender, EventArgs e)
	{
		if (bool_3)
		{
			method_2(int_1, ref aircraft_0);
		}
	}

	private void method_2(int? nullable_0, ref Aircraft aircraft_1)
	{
		Aircraft_AirOps airOps = aircraft_1.AirOps;
		if (((CheckBox)CB_QuickTurnaround).Checked)
		{
			((Control)Combo_NumberOfSorties).Enabled = true;
			method_3(nullable_0);
			((Control)Label_QuickTurnaroundInfo).Enabled = true;
			((Label)Label_QuickTurnaroundInfo).Text = MyProject.Forms.AirOps.QuickTurnaroundPenaltyText();
			if (bool_3)
			{
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendAirborneAircraftQuickTurnaroundMessage(aircraft_1, enableQuickTurnaround: true, airOps.QuickTurnaround_SortiesTotal);
				}
				else
				{
					CoreClientCode.SetAirborneAircraftQuickTurnaround_Core(aircraft_1, QuickTurnaroundOn: true, airOps.QuickTurnaround_SortiesTotal);
				}
			}
			return;
		}
		((Control)Combo_NumberOfSorties).Enabled = false;
		method_3(nullable_0);
		((Control)Label_QuickTurnaroundInfo).Enabled = false;
		((Label)Label_QuickTurnaroundInfo).Text = "";
		if (bool_3)
		{
			if (!Client.Realtime)
			{
				CoreClientCode.SetAirborneAircraftQuickTurnaround_Core(aircraft_1, QuickTurnaroundOn: false, airOps.QuickTurnaround_SortiesTotal);
			}
			else
			{
				Client.RealtimeTerminal.SendAirborneAircraftQuickTurnaroundMessage(aircraft_1, enableQuickTurnaround: false, airOps.QuickTurnaround_SortiesTotal);
			}
		}
	}

	private void method_3(int? nullable_0)
	{
		((ComboBox)Combo_NumberOfSorties).BeginUpdate();
		((ComboBox)Combo_NumberOfSorties).Items.Clear();
		((ComboBox)Combo_NumberOfSorties).SelectedIndex = -1;
		if (((CheckBox)CB_QuickTurnaround).Checked)
		{
			int num = int_1;
			for (int i = 2; i <= num; i++)
			{
				if (i == int_1)
				{
					((ComboBox)Combo_NumberOfSorties).Items.Add((object)(Conversions.ToString(i) + " Sorties (Maximum)"));
				}
				else
				{
					((ComboBox)Combo_NumberOfSorties).Items.Add((object)(Conversions.ToString(i) + " Sorties"));
				}
			}
			Aircraft_AirOps airOps = aircraft_0.AirOps;
			if (!bool_3)
			{
				((ComboBox)Combo_NumberOfSorties).SelectedIndex = airOps.QuickTurnaround_SortiesTotal - 2;
			}
			else
			{
				((ComboBox)Combo_NumberOfSorties).SelectedIndex = int_1 - 2;
			}
			if (((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 <= aircraft_0.Loadout.QuickTurnaround_MaxSorties)
			{
				int maxSorties = ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2;
				if (!Client.Realtime)
				{
					CoreClientCode.SetAirborneAircraftQuickTurnaround_Core(aircraft_0, QuickTurnaroundOn: true, maxSorties);
				}
				else
				{
					Client.RealtimeTerminal.SendAirborneAircraftQuickTurnaroundMessage(aircraft_0, enableQuickTurnaround: true, maxSorties);
				}
			}
		}
		((ComboBox)Combo_NumberOfSorties).EndUpdate();
		((Label)Label_QuickTurnaroundInfo).Text = MyProject.Forms.AirOps.QuickTurnaroundPenaltyText();
	}

	private void Form_QuickTurnaround_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		((Label)Label_QuickTurnaroundInfo).Text = MyProject.Forms.AirOps.QuickTurnaroundPenaltyText();
		if (!bool_3)
		{
			return;
		}
		_ = aircraft_0.AirOps;
		if (((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 <= aircraft_0.Loadout.QuickTurnaround_MaxSorties)
		{
			int maxSorties = ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2;
			if (Client.Realtime)
			{
				Client.RealtimeTerminal.SendAirborneAircraftQuickTurnaroundMessage(aircraft_0, enableQuickTurnaround: true, maxSorties);
			}
			else
			{
				CoreClientCode.SetAirborneAircraftQuickTurnaround_Core(aircraft_0, QuickTurnaroundOn: true, maxSorties);
			}
		}
	}

	static Form_QuickTurnaround()
	{
		Class72.smethod_20();
	}
}

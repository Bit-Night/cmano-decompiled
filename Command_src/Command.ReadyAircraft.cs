using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ReadyAircraft : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHostsMagazinesToolStripMenuItem")]
	private DarkToolStripMenuItem _CheckHostsMagazinesToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton _Button3;

	[CompilerGenerated]
	[AccessedThroughProperty("Button4")]
	private DarkUIButton _Button4;

	[CompilerGenerated]
	[AccessedThroughProperty("Button5")]
	private DarkUIButton _Button5;

	[AccessedThroughProperty("QuickTurnaround_AdditionalTimePenalty")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ShowOnlyUsable")]
	private DarkCheckBox _CB_ShowOnlyUsable;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_QuickTurnaround")]
	private DarkCheckBox _CB_QuickTurnaround;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_NumberOfSorties")]
	private DarkUIComboBox _Combo_NumberOfSorties;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_LoadoutItems")]
	private DarkDataGridView _DGV_LoadoutItems;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_Loadouts")]
	private DarkDataGridView _DGV_Loadouts;

	[CompilerGenerated]
	[AccessedThroughProperty("RangeProfileDescription")]
	private DataGridViewTextBoxColumn cMuSySbxAj9;

	[CompilerGenerated]
	private bool bool_2;

	public List<Aircraft> SelectedAircraft;

	public List<Mission.EmptyAircraftSlot> SelectedEmptySlot;

	public int SelectedLoadout;

	private DataTable dataTable_0;

	private DataTable dataTable_1;

	private Dictionary<int, int> dictionary_0;

	private HashSet<int> hashSet_0;

	private string string_0;

	private bool bool_3;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int? TycSyoMclCb;

	private bool bool_4;

	[field: AccessedThroughProperty("Label_Loadout")]
	internal virtual DarkLabel Label_Loadout { get; set; }

	internal virtual DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("MenuStrip1")]
	internal virtual DarkMenuStrip MenuStrip1 { get; set; }

	internal virtual DarkToolStripMenuItem CheckHostsMagazinesToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _CheckHostsMagazinesToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkToolStripMenuItem darkToolStripMenuItem = _CheckHostsMagazinesToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_CheckHostsMagazinesToolStripMenuItem = value;
			darkToolStripMenuItem = _CheckHostsMagazinesToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIButton darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button3 = value;
			darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	internal virtual DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return _Button4;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _Button4;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button4 = value;
			darkUIButton = _Button4;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button5
	{
		[CompilerGenerated]
		get
		{
			return _Button5;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button5;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button5 = value;
			darkUIButton = _Button5;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DataGridViewTextBoxColumn QuickTurnaround_AdditionalTimePenalty
	{
		[CompilerGenerated]
		get
		{
			return dataGridViewTextBoxColumn_0;
		}
		[CompilerGenerated]
		set
		{
			dataGridViewTextBoxColumn_0 = value;
		}
	}

	internal virtual DarkCheckBox CB_ShowOnlyUsable
	{
		[CompilerGenerated]
		get
		{
			return _CB_ShowOnlyUsable;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkCheckBox darkCheckBox = _CB_ShowOnlyUsable;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ShowOnlyUsable = value;
			darkCheckBox = _CB_ShowOnlyUsable;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

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
			EventHandler eventHandler = method_20;
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
			EventHandler eventHandler = method_17;
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

	internal virtual DarkDataGridView DGV_LoadoutItems
	{
		[CompilerGenerated]
		get
		{
			return _DGV_LoadoutItems;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_15);
			DarkDataGridView darkDataGridView = _DGV_LoadoutItems;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellContentClick -= val;
			}
			_DGV_LoadoutItems = value;
			darkDataGridView = _DGV_LoadoutItems;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellContentClick += val;
			}
		}
	}

	internal virtual DarkDataGridView DGV_Loadouts
	{
		[CompilerGenerated]
		get
		{
			return _DGV_Loadouts;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellMouseEventHandler val = new DataGridViewCellMouseEventHandler(method_12);
			EventHandler eventHandler = method_13;
			DataGridViewCellFormattingEventHandler val2 = new DataGridViewCellFormattingEventHandler(method_16);
			DarkDataGridView darkDataGridView = _DGV_Loadouts;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellMouseDoubleClick -= val;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellFormatting -= val2;
			}
			_DGV_Loadouts = value;
			darkDataGridView = _DGV_Loadouts;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellMouseDoubleClick += val;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellFormatting += val2;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("Loadout")]
	internal virtual DataGridViewTextBoxColumn Loadout { get; set; }

	[field: AccessedThroughProperty("NumberOfLoadouts")]
	internal virtual DataGridViewTextBoxColumn NumberOfLoadouts { get; set; }

	[field: AccessedThroughProperty("NumberOfLoadoutsIncludingMountedWeapons")]
	internal virtual DataGridViewTextBoxColumn NumberOfLoadoutsIncludingMountedWeapons { get; set; }

	[field: AccessedThroughProperty("NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly")]
	internal virtual DataGridViewTextBoxColumn NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly { get; set; }

	[field: AccessedThroughProperty("ReadyTime")]
	internal virtual DataGridViewTextBoxColumn ReadyTime { get; set; }

	[field: AccessedThroughProperty("ReadyTime_Sustained")]
	internal virtual DataGridViewTextBoxColumn ReadyTime_Sustained { get; set; }

	[field: AccessedThroughProperty("QuickTurnaroundDescription")]
	internal virtual DataGridViewTextBoxColumn QuickTurnaroundDescription { get; set; }

	[field: AccessedThroughProperty("TimeofDay")]
	internal virtual DataGridViewTextBoxColumn TimeofDay { get; set; }

	[field: AccessedThroughProperty("Weather")]
	internal virtual DataGridViewTextBoxColumn Weather { get; set; }

	internal virtual DataGridViewTextBoxColumn RangeProfileDescription
	{
		[CompilerGenerated]
		get
		{
			return cMuSySbxAj9;
		}
		[CompilerGenerated]
		set
		{
			cMuSySbxAj9 = value;
		}
	}

	[field: AccessedThroughProperty("LoadoutRoleDescription")]
	internal virtual DataGridViewTextBoxColumn LoadoutRoleDescription { get; set; }

	[field: AccessedThroughProperty("LoadoutRole")]
	internal virtual DataGridViewTextBoxColumn LoadoutRole { get; set; }

	[field: AccessedThroughProperty("RequiresBuddyIllumination")]
	internal virtual DataGridViewTextBoxColumn RequiresBuddyIllumination { get; set; }

	[field: AccessedThroughProperty("DefaultCombatRadius")]
	internal virtual DataGridViewTextBoxColumn DefaultCombatRadius { get; set; }

	[field: AccessedThroughProperty("DefaultTimeOnStation")]
	internal virtual DataGridViewTextBoxColumn DefaultTimeOnStation { get; set; }

	[field: AccessedThroughProperty("DefaultMissionProfile")]
	internal virtual DataGridViewTextBoxColumn DefaultMissionProfile { get; set; }

	[field: AccessedThroughProperty("AttackAltitude")]
	internal virtual DataGridViewTextBoxColumn AttackAltitude { get; set; }

	[field: AccessedThroughProperty("QuickTurnaround")]
	internal virtual DataGridViewTextBoxColumn QuickTurnaround { get; set; }

	[field: AccessedThroughProperty("QuickTurnaround_MaxSorties")]
	internal virtual DataGridViewTextBoxColumn QuickTurnaround_MaxSorties { get; set; }

	[field: AccessedThroughProperty("QuickTurnaround_AirborneTime")]
	internal virtual DataGridViewTextBoxColumn QuickTurnaround_AirborneTime { get; set; }

	[field: AccessedThroughProperty("QuickTurnaround_ReadyTime")]
	internal virtual DataGridViewTextBoxColumn QuickTurnaround_ReadyTime { get; set; }

	[field: AccessedThroughProperty("QuickTurnaround_StanddownTime")]
	internal virtual DataGridViewTextBoxColumn QuickTurnaround_StanddownTime { get; set; }

	[field: AccessedThroughProperty("QuickTurnaround_TimeofDay")]
	internal virtual DataGridViewTextBoxColumn QuickTurnaround_TimeofDay { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("Column_Description")]
	internal virtual DataGridViewLinkColumn Column_Description { get; set; }

	[field: AccessedThroughProperty("Available")]
	internal virtual DataGridViewTextBoxColumn Available { get; set; }

	[field: AccessedThroughProperty("AvailableTotal")]
	internal virtual DataGridViewTextBoxColumn AvailableTotal { get; set; }

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

	public ReadyAircraft()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(ReadyAircraft_FormClosing);
		((Form)this).Load += ReadyAircraft_Load;
		((Control)this).KeyDown += new KeyEventHandler(ReadyAircraft_KeyDown);
		RTMPEnabled = true;
		dataTable_0 = new DataTable();
		dataTable_1 = new DataTable();
		dictionary_0 = new Dictionary<int, int>();
		hashSet_0 = new HashSet<int>();
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Expected O, but got Unknown
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ad: Expected O, but got Unknown
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Expected O, but got Unknown
		//IL_08c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0949: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Expected O, but got Unknown
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a10: Expected O, but got Unknown
		//IL_0b2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b36: Expected O, but got Unknown
		//IL_0be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf3: Expected O, but got Unknown
		//IL_0fab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb5: Expected O, but got Unknown
		//IL_112f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1139: Expected O, but got Unknown
		//IL_1a73: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d45: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		CB_ShowOnlyUsable = new DarkCheckBox();
		Button5 = new DarkUIButton();
		Button4 = new DarkUIButton();
		Label8 = new DarkLabel();
		Label7 = new DarkLabel();
		Label6 = new DarkLabel();
		Label5 = new DarkLabel();
		Label2 = new DarkLabel();
		Button3 = new DarkUIButton();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Label_Loadout = new DarkLabel();
		DGV_LoadoutItems = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		Column_Description = new DataGridViewLinkColumn();
		Available = new DataGridViewTextBoxColumn();
		AvailableTotal = new DataGridViewTextBoxColumn();
		DGV_Loadouts = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Loadout = new DataGridViewTextBoxColumn();
		NumberOfLoadouts = new DataGridViewTextBoxColumn();
		NumberOfLoadoutsIncludingMountedWeapons = new DataGridViewTextBoxColumn();
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly = new DataGridViewTextBoxColumn();
		ReadyTime = new DataGridViewTextBoxColumn();
		ReadyTime_Sustained = new DataGridViewTextBoxColumn();
		QuickTurnaroundDescription = new DataGridViewTextBoxColumn();
		TimeofDay = new DataGridViewTextBoxColumn();
		Weather = new DataGridViewTextBoxColumn();
		RangeProfileDescription = new DataGridViewTextBoxColumn();
		LoadoutRoleDescription = new DataGridViewTextBoxColumn();
		LoadoutRole = new DataGridViewTextBoxColumn();
		RequiresBuddyIllumination = new DataGridViewTextBoxColumn();
		DefaultCombatRadius = new DataGridViewTextBoxColumn();
		DefaultTimeOnStation = new DataGridViewTextBoxColumn();
		DefaultMissionProfile = new DataGridViewTextBoxColumn();
		AttackAltitude = new DataGridViewTextBoxColumn();
		QuickTurnaround = new DataGridViewTextBoxColumn();
		QuickTurnaround_MaxSorties = new DataGridViewTextBoxColumn();
		QuickTurnaround_AirborneTime = new DataGridViewTextBoxColumn();
		QuickTurnaround_ReadyTime = new DataGridViewTextBoxColumn();
		QuickTurnaround_StanddownTime = new DataGridViewTextBoxColumn();
		QuickTurnaround_TimeofDay = new DataGridViewTextBoxColumn();
		MenuStrip1 = new DarkMenuStrip();
		CheckHostsMagazinesToolStripMenuItem = new DarkToolStripMenuItem();
		Label1 = new DarkLabel();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		CB_QuickTurnaround = new DarkCheckBox();
		Combo_NumberOfSorties = new DarkUIComboBox();
		Label_QuickTurnaroundInfo = new DarkLabel();
		((ISupportInitialize)(object)DGV_LoadoutItems).BeginInit();
		((ISupportInitialize)(object)DGV_Loadouts).BeginInit();
		((Control)MenuStrip1).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((ButtonBase)CB_ShowOnlyUsable).AutoSize = true;
		((Control)CB_ShowOnlyUsable).Location = new Point(145, 5);
		((Control)CB_ShowOnlyUsable).Name = "CB_ShowOnlyUsable";
		((Control)CB_ShowOnlyUsable).Size = new Size(167, 19);
		((Control)CB_ShowOnlyUsable).TabIndex = 30;
		((ButtonBase)CB_ShowOnlyUsable).Text = "Show only usable loadouts";
		((Control)Button5).Anchor = (AnchorStyles)6;
		((ButtonBase)Button5).BackColor = Color.Transparent;
		((Button)Button5).DialogResult = (DialogResult)0;
		((Control)Button5).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button5).ForeColor = SystemColors.Control;
		((Control)Button5).Location = new Point(85, 538);
		((Control)Button5).Name = "Button5";
		((Control)Button5).Padding = new Padding(5);
		Button5.RoundRadius = 0;
		((Control)Button5).Size = new Size(213, 23);
		((Control)Button5).TabIndex = 26;
		Button5.Text = "OK - Ready (Exclude Optional Weapons)";
		((Control)Button4).Anchor = (AnchorStyles)6;
		((ButtonBase)Button4).BackColor = Color.Transparent;
		((Button)Button4).DialogResult = (DialogResult)0;
		((Control)Button4).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button4).ForeColor = Color.IndianRed;
		((Control)Button4).Location = new Point(497, 538);
		((Control)Button4).Name = "Button4";
		((Control)Button4).Padding = new Padding(5);
		Button4.RoundRadius = 0;
		((Control)Button4).Size = new Size(296, 23);
		((Control)Button4).TabIndex = 25;
		Button4.Text = "Ready Immediately - Ignore Magazines (ScenEdit)";
		((Control)Label8).Anchor = (AnchorStyles)6;
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(655, 444);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(227, 15);
		((Control)Label8).TabIndex = 24;
		((Label)Label8).Text = "NumberOfLoadoutsTotal_MandatoryOnly";
		((Control)Label7).Anchor = (AnchorStyles)6;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(655, 429);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(139, 15);
		((Control)Label7).TabIndex = 23;
		((Label)Label7).Text = "NumberOfLoadoutsTotal";
		((Control)Label6).Anchor = (AnchorStyles)6;
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(655, 414);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(153, 15);
		((Control)Label6).TabIndex = 22;
		((Label)Label6).Text = "NumberOfLoadoutsOnBase";
		((Control)Label5).Anchor = (AnchorStyles)6;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(655, 399);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(83, 15);
		((Control)Label5).TabIndex = 21;
		((Label)Label5).Text = "AttackAltitude";
		((Control)Label2).Anchor = (AnchorStyles)6;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(655, 384);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(134, 15);
		((Control)Label2).TabIndex = 18;
		((Label)Label2).Text = "LoadoutRoleDescription";
		((Control)Button3).Anchor = (AnchorStyles)6;
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Button)Button3).DialogResult = (DialogResult)0;
		((Control)Button3).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button3).ForeColor = Color.IndianRed;
		((Control)Button3).Location = new Point(304, 538);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(187, 23);
		((Control)Button3).TabIndex = 16;
		Button3.Text = "Ready Immediately (ScenEdit)";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(1016, 538);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 14;
		Button2.Text = "Cancel";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(4, 538);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 13;
		Button1.Text = "OK - Ready";
		((Control)Label_Loadout).Anchor = (AnchorStyles)6;
		Label_Loadout.AutoSize = true;
		((Control)Label_Loadout).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label_Loadout).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Loadout).Location = new Point(3, 382);
		((Control)Label_Loadout).Name = "Label_Loadout";
		((Control)Label_Loadout).Size = new Size(92, 13);
		((Control)Label_Loadout).TabIndex = 12;
		((Label)Label_Loadout).Text = "Loadout Details:";
		((DataGridView)DGV_LoadoutItems).AllowUserToAddRows = false;
		((DataGridView)DGV_LoadoutItems).AllowUserToDeleteRows = false;
		((Control)DGV_LoadoutItems).Anchor = (AnchorStyles)6;
		((DataGridView)DGV_LoadoutItems).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)6;
		((DataGridView)DGV_LoadoutItems).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		((DataGridView)DGV_LoadoutItems).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_LoadoutItems).BorderStyle = (BorderStyle)2;
		((Control)DGV_LoadoutItems).CausesValidation = false;
		((DataGridView)DGV_LoadoutItems).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_LoadoutItems).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)DataGridViewTextBoxColumn1,
			(DataGridViewColumn)Column_Description,
			(DataGridViewColumn)Available,
			(DataGridViewColumn)AvailableTotal
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_LoadoutItems).DefaultCellStyle = val2;
		((DataGridView)DGV_LoadoutItems).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_LoadoutItems).EnableHeadersVisualStyles = false;
		((Control)DGV_LoadoutItems).Location = new Point(3, 397);
		((DataGridView)DGV_LoadoutItems).MultiSelect = false;
		((Control)DGV_LoadoutItems).Name = "DGV_LoadoutItems";
		((DataGridView)DGV_LoadoutItems).RowHeadersVisible = false;
		((DataGridView)DGV_LoadoutItems).RowHeadersWidth = 20;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_LoadoutItems).RowsDefaultCellStyle = val3;
		((DataGridView)DGV_LoadoutItems).RowTemplate.Height = 15;
		((DataGridView)DGV_LoadoutItems).RowTemplate.Resizable = (DataGridViewTriState)2;
		((DataGridView)DGV_LoadoutItems).ScrollBars = (ScrollBars)2;
		((DataGridView)DGV_LoadoutItems).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_LoadoutItems).Size = new Size(650, 135);
		((Control)DGV_LoadoutItems).TabIndex = 11;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).DataPropertyName = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Visible = false;
		((DataGridViewColumn)Column_Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)Column_Description).DataPropertyName = "Item";
		((DataGridViewColumn)Column_Description).HeaderText = "Stores (click for info)";
		Column_Description.LinkBehavior = (LinkBehavior)2;
		Column_Description.LinkColor = Color.LightBlue;
		((DataGridViewColumn)Column_Description).MinimumWidth = 470;
		((DataGridViewColumn)Column_Description).Name = "Column_Description";
		((DataGridViewColumn)Column_Description).ReadOnly = true;
		((DataGridViewColumn)Column_Description).Resizable = (DataGridViewTriState)1;
		Column_Description.TrackVisitedState = false;
		((DataGridViewColumn)Column_Description).Width = 470;
		((DataGridViewColumn)Available).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Available).DataPropertyName = "Available";
		((DataGridViewColumn)Available).HeaderText = "# Available, Magazines";
		((DataGridViewColumn)Available).MinimumWidth = 90;
		((DataGridViewColumn)Available).Name = "Available";
		((DataGridViewColumn)Available).ReadOnly = true;
		Available.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Available).ToolTipText = "The number of weapons available in the base's ammo dump";
		((DataGridViewColumn)AvailableTotal).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)AvailableTotal).DataPropertyName = "AvailableTotal";
		((DataGridViewColumn)AvailableTotal).HeaderText = "# Available, Mags + A/C";
		((DataGridViewColumn)AvailableTotal).MinimumWidth = 90;
		((DataGridViewColumn)AvailableTotal).Name = "AvailableTotal";
		((DataGridViewColumn)AvailableTotal).ReadOnly = true;
		AvailableTotal.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)AvailableTotal).ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft";
		((DataGridView)DGV_Loadouts).AllowUserToAddRows = false;
		((DataGridView)DGV_Loadouts).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Loadouts).AllowUserToResizeRows = false;
		((Control)DGV_Loadouts).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_Loadouts).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Loadouts).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_Loadouts).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Loadouts).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Loadouts).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_Loadouts).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_Loadouts).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[24]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)Loadout,
			(DataGridViewColumn)NumberOfLoadouts,
			(DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons,
			(DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly,
			(DataGridViewColumn)ReadyTime,
			(DataGridViewColumn)ReadyTime_Sustained,
			(DataGridViewColumn)QuickTurnaroundDescription,
			(DataGridViewColumn)TimeofDay,
			(DataGridViewColumn)Weather,
			(DataGridViewColumn)RangeProfileDescription,
			(DataGridViewColumn)LoadoutRoleDescription,
			(DataGridViewColumn)LoadoutRole,
			(DataGridViewColumn)RequiresBuddyIllumination,
			(DataGridViewColumn)DefaultCombatRadius,
			(DataGridViewColumn)DefaultTimeOnStation,
			(DataGridViewColumn)DefaultMissionProfile,
			(DataGridViewColumn)AttackAltitude,
			(DataGridViewColumn)QuickTurnaround,
			(DataGridViewColumn)QuickTurnaround_MaxSorties,
			(DataGridViewColumn)QuickTurnaround_AirborneTime,
			(DataGridViewColumn)QuickTurnaround_ReadyTime,
			(DataGridViewColumn)QuickTurnaround_StanddownTime,
			(DataGridViewColumn)QuickTurnaround_TimeofDay
		});
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Loadouts).DefaultCellStyle = val5;
		((DataGridView)DGV_Loadouts).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_Loadouts).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_Loadouts).GridColor = SystemColors.ControlText;
		((Control)DGV_Loadouts).Location = new Point(3, 27);
		((DataGridView)DGV_Loadouts).MultiSelect = false;
		((Control)DGV_Loadouts).Name = "DGV_Loadouts";
		((DataGridView)DGV_Loadouts).RowHeadersVisible = false;
		((DataGridView)DGV_Loadouts).RowHeadersWidth = 10;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Loadouts).RowsDefaultCellStyle = val6;
		((DataGridView)DGV_Loadouts).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_Loadouts).Size = new Size(1088, 315);
		((Control)DGV_Loadouts).TabIndex = 8;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft";
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)Loadout).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Loadout).DataPropertyName = "Name";
		((DataGridViewColumn)Loadout).HeaderText = "Loadout Name";
		((DataGridViewColumn)Loadout).MinimumWidth = 300;
		((DataGridViewColumn)Loadout).Name = "Loadout";
		((DataGridViewColumn)Loadout).ReadOnly = true;
		((DataGridViewColumn)Loadout).Width = 300;
		((DataGridViewColumn)NumberOfLoadouts).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)NumberOfLoadouts).DataPropertyName = "NumberOfLoadouts";
		((DataGridViewColumn)NumberOfLoadouts).HeaderText = "# Available, Magazines";
		((DataGridViewColumn)NumberOfLoadouts).MinimumWidth = 90;
		((DataGridViewColumn)NumberOfLoadouts).Name = "NumberOfLoadouts";
		((DataGridViewColumn)NumberOfLoadouts).ReadOnly = true;
		((DataGridViewColumn)NumberOfLoadouts).ToolTipText = "The number of weapons available in the base's ammo dump";
		((DataGridViewColumn)NumberOfLoadouts).Width = 90;
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons).DataPropertyName = "NumberOfLoadoutsIncludingMountedWeapons";
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons).HeaderText = "# Available, Mags + A/C";
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons).MinimumWidth = 90;
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons).Name = "NumberOfLoadoutsIncludingMountedWeapons";
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons).ReadOnly = true;
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons).ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft";
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapons).Width = 90;
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly).DataPropertyName = "NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly";
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly).HeaderText = "# Available, Mandatory";
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly).MinimumWidth = 90;
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly).Name = "NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly";
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly).ReadOnly = true;
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly).ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft, excluding any optional weapons";
		((DataGridViewColumn)NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly).Width = 90;
		((DataGridViewColumn)ReadyTime).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)ReadyTime).DataPropertyName = "ReadyTime";
		((DataGridViewColumn)ReadyTime).HeaderText = "Ready Time, Surge Ops";
		((DataGridViewColumn)ReadyTime).MinimumWidth = 100;
		((DataGridViewColumn)ReadyTime).Name = "ReadyTime";
		((DataGridViewColumn)ReadyTime).ReadOnly = true;
		((DataGridViewColumn)ReadyTime_Sustained).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)ReadyTime_Sustained).DataPropertyName = "ReadyTime_Sustained";
		((DataGridViewColumn)ReadyTime_Sustained).HeaderText = "Ready Time, Sustained Ops";
		((DataGridViewColumn)ReadyTime_Sustained).MinimumWidth = 100;
		((DataGridViewColumn)ReadyTime_Sustained).Name = "ReadyTime_Sustained";
		((DataGridViewColumn)ReadyTime_Sustained).ReadOnly = true;
		((DataGridViewColumn)QuickTurnaroundDescription).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)QuickTurnaroundDescription).DataPropertyName = "QuickTurnaroundDescription";
		((DataGridViewColumn)QuickTurnaroundDescription).HeaderText = "Quick Turnaround";
		((DataGridViewColumn)QuickTurnaroundDescription).MinimumWidth = 120;
		((DataGridViewColumn)QuickTurnaroundDescription).Name = "QuickTurnaroundDescription";
		((DataGridViewColumn)QuickTurnaroundDescription).ReadOnly = true;
		((DataGridViewColumn)QuickTurnaroundDescription).Width = 120;
		((DataGridViewColumn)TimeofDay).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)TimeofDay).DataPropertyName = "TimeofDay";
		((DataGridViewColumn)TimeofDay).HeaderText = "Time of Day";
		((DataGridViewColumn)TimeofDay).MinimumWidth = 90;
		((DataGridViewColumn)TimeofDay).Name = "TimeofDay";
		((DataGridViewColumn)TimeofDay).ReadOnly = true;
		((DataGridViewColumn)TimeofDay).Width = 90;
		((DataGridViewColumn)Weather).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)Weather).DataPropertyName = "Weather";
		((DataGridViewColumn)Weather).HeaderText = "Weather";
		((DataGridViewColumn)Weather).MinimumWidth = 90;
		((DataGridViewColumn)Weather).Name = "Weather";
		((DataGridViewColumn)Weather).ReadOnly = true;
		((DataGridViewColumn)Weather).Width = 90;
		((DataGridViewColumn)RangeProfileDescription).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)RangeProfileDescription).DataPropertyName = "RangeProfileDescription";
		((DataGridViewColumn)RangeProfileDescription).HeaderText = "Radius / Profile";
		((DataGridViewColumn)RangeProfileDescription).MinimumWidth = 517;
		((DataGridViewColumn)RangeProfileDescription).Name = "RangeProfileDescription";
		((DataGridViewColumn)RangeProfileDescription).ReadOnly = true;
		((DataGridViewColumn)RangeProfileDescription).Width = 517;
		((DataGridViewColumn)LoadoutRoleDescription).DataPropertyName = "LoadoutRoleDescription";
		((DataGridViewColumn)LoadoutRoleDescription).HeaderText = "LoadoutRoleDescription";
		((DataGridViewColumn)LoadoutRoleDescription).Name = "LoadoutRoleDescription";
		((DataGridViewColumn)LoadoutRoleDescription).Visible = false;
		((DataGridViewColumn)LoadoutRole).DataPropertyName = "LoadoutRole";
		((DataGridViewColumn)LoadoutRole).HeaderText = "LoadoutRole";
		((DataGridViewColumn)LoadoutRole).Name = "LoadoutRole";
		((DataGridViewColumn)LoadoutRole).Visible = false;
		((DataGridViewColumn)RequiresBuddyIllumination).DataPropertyName = "RequiresBuddyIllumination";
		((DataGridViewColumn)RequiresBuddyIllumination).HeaderText = "RequiresBuddyIllumination";
		((DataGridViewColumn)RequiresBuddyIllumination).Name = "RequiresBuddyIllumination";
		((DataGridViewColumn)RequiresBuddyIllumination).Visible = false;
		((DataGridViewColumn)DefaultCombatRadius).DataPropertyName = "DefaultCombatRadius";
		((DataGridViewColumn)DefaultCombatRadius).HeaderText = "DefaultCombatRadius";
		((DataGridViewColumn)DefaultCombatRadius).Name = "DefaultCombatRadius";
		((DataGridViewColumn)DefaultCombatRadius).Visible = false;
		((DataGridViewColumn)DefaultTimeOnStation).DataPropertyName = "DefaultTimeOnStation";
		((DataGridViewColumn)DefaultTimeOnStation).HeaderText = "DefaultTimeOnStation";
		((DataGridViewColumn)DefaultTimeOnStation).Name = "DefaultTimeOnStation";
		((DataGridViewColumn)DefaultTimeOnStation).Visible = false;
		((DataGridViewColumn)DefaultMissionProfile).DataPropertyName = "DefaultMissionProfile";
		((DataGridViewColumn)DefaultMissionProfile).HeaderText = "DefaultMissionProfile";
		((DataGridViewColumn)DefaultMissionProfile).Name = "DefaultMissionProfile";
		((DataGridViewColumn)DefaultMissionProfile).Visible = false;
		((DataGridViewColumn)AttackAltitude).DataPropertyName = "AttackAltitude";
		((DataGridViewColumn)AttackAltitude).HeaderText = "AttackAltitude";
		((DataGridViewColumn)AttackAltitude).Name = "AttackAltitude";
		((DataGridViewColumn)AttackAltitude).Visible = false;
		((DataGridViewColumn)QuickTurnaround).DataPropertyName = "QuickTurnaround";
		((DataGridViewColumn)QuickTurnaround).HeaderText = "QuickTurnaround";
		((DataGridViewColumn)QuickTurnaround).Name = "QuickTurnaround";
		((DataGridViewColumn)QuickTurnaround).Visible = false;
		((DataGridViewColumn)QuickTurnaround_MaxSorties).DataPropertyName = "QuickTurnaround_MaxSorties";
		((DataGridViewColumn)QuickTurnaround_MaxSorties).HeaderText = "QuickTurnaround_MaxSorties";
		((DataGridViewColumn)QuickTurnaround_MaxSorties).Name = "QuickTurnaround_MaxSorties";
		((DataGridViewColumn)QuickTurnaround_MaxSorties).Visible = false;
		((DataGridViewColumn)QuickTurnaround_AirborneTime).DataPropertyName = "QuickTurnaround_AirborneTime";
		((DataGridViewColumn)QuickTurnaround_AirborneTime).HeaderText = "QuickTurnaround_AirborneTime";
		((DataGridViewColumn)QuickTurnaround_AirborneTime).Name = "QuickTurnaround_AirborneTime";
		((DataGridViewColumn)QuickTurnaround_AirborneTime).Visible = false;
		((DataGridViewColumn)QuickTurnaround_ReadyTime).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)QuickTurnaround_ReadyTime).DataPropertyName = "QuickTurnaround_ReadyTime";
		((DataGridViewColumn)QuickTurnaround_ReadyTime).HeaderText = "QuickTurnaround_ReadyTime";
		((DataGridViewColumn)QuickTurnaround_ReadyTime).Name = "QuickTurnaround_ReadyTime";
		((DataGridViewColumn)QuickTurnaround_ReadyTime).Visible = false;
		((DataGridViewColumn)QuickTurnaround_StanddownTime).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)QuickTurnaround_StanddownTime).DataPropertyName = "QuickTurnaround_AdditionalTimePenalty";
		((DataGridViewColumn)QuickTurnaround_StanddownTime).HeaderText = "QuickTurnaround_StanddownTime";
		((DataGridViewColumn)QuickTurnaround_StanddownTime).Name = "QuickTurnaround_StanddownTime";
		((DataGridViewColumn)QuickTurnaround_StanddownTime).Visible = false;
		((DataGridViewColumn)QuickTurnaround_TimeofDay).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)QuickTurnaround_TimeofDay).DataPropertyName = "QuickTurnaround_TimeofDay";
		((DataGridViewColumn)QuickTurnaround_TimeofDay).HeaderText = "QuickTurnaround_TimeofDay";
		((DataGridViewColumn)QuickTurnaround_TimeofDay).Name = "QuickTurnaround_TimeofDay";
		((DataGridViewColumn)QuickTurnaround_TimeofDay).Visible = false;
		((ToolStrip)MenuStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)MenuStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)MenuStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)CheckHostsMagazinesToolStripMenuItem });
		((Control)MenuStrip1).Location = new Point(0, 0);
		((Control)MenuStrip1).Name = "MenuStrip1";
		((Control)MenuStrip1).Padding = new Padding(3, 2, 0, 2);
		((Control)MenuStrip1).Size = new Size(1094, 24);
		((Control)MenuStrip1).TabIndex = 15;
		((Control)MenuStrip1).Text = "MenuStrip1";
		((ToolStripItem)CheckHostsMagazinesToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)CheckHostsMagazinesToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)CheckHostsMagazinesToolStripMenuItem).Name = "CheckHostsMagazinesToolStripMenuItem";
		((ToolStripItem)CheckHostsMagazinesToolStripMenuItem).Size = new Size(138, 20);
		((ToolStripItem)CheckHostsMagazinesToolStripMenuItem).Text = "Check Base Magazines";
		((Control)Label1).Anchor = (AnchorStyles)6;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(655, 459);
		((Control)Label1).MaximumSize = new Size(400, 40);
		((Control)Label1).MinimumSize = new Size(400, 40);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(400, 40);
		((Control)Label1).TabIndex = 31;
		((Label)Label1).Text = "Weapon State";
		((Control)FlowLayoutPanel1).Anchor = (AnchorStyles)14;
		((Control)FlowLayoutPanel1).BackColor = Color.FromArgb(60, 63, 65);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)CB_QuickTurnaround);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Combo_NumberOfSorties);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label_QuickTurnaroundInfo);
		((Control)FlowLayoutPanel1).Location = new Point(3, 348);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(1088, 31);
		((Control)FlowLayoutPanel1).TabIndex = 37;
		((Control)CB_QuickTurnaround).Anchor = (AnchorStyles)4;
		((Control)CB_QuickTurnaround).Location = new Point(3, 5);
		((Control)CB_QuickTurnaround).Name = "CB_QuickTurnaround";
		((Control)CB_QuickTurnaround).Size = new Size(148, 17);
		((Control)CB_QuickTurnaround).TabIndex = 32;
		((ButtonBase)CB_QuickTurnaround).Text = "Enable Quick Turnaround";
		((Control)Combo_NumberOfSorties).Anchor = (AnchorStyles)4;
		((ComboBox)Combo_NumberOfSorties).BackColor = Color.FromArgb(60, 63, 65);
		((ComboBox)Combo_NumberOfSorties).DrawMode = (DrawMode)1;
		((ComboBox)Combo_NumberOfSorties).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_NumberOfSorties).Font = new Font("Segoe UI", 7f);
		((ListControl)Combo_NumberOfSorties).FormattingEnabled = true;
		((Control)Combo_NumberOfSorties).Location = new Point(157, 3);
		((Control)Combo_NumberOfSorties).Name = "Combo_NumberOfSorties";
		((Control)Combo_NumberOfSorties).Size = new Size(166, 21);
		((Control)Combo_NumberOfSorties).TabIndex = 33;
		((Control)Label_QuickTurnaroundInfo).Anchor = (AnchorStyles)4;
		Label_QuickTurnaroundInfo.AutoSize = true;
		((Control)Label_QuickTurnaroundInfo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_QuickTurnaroundInfo).Location = new Point(329, 6);
		((Control)Label_QuickTurnaroundInfo).Name = "Label_QuickTurnaroundInfo";
		((Control)Label_QuickTurnaroundInfo).Size = new Size(41, 15);
		((Control)Label_QuickTurnaroundInfo).TabIndex = 34;
		((Label)Label_QuickTurnaroundInfo).Text = "Label1";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1094, 564);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)CB_ShowOnlyUsable);
		((Control)this).Controls.Add((Control)(object)Button5);
		((Control)this).Controls.Add((Control)(object)Button4);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Button3);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label_Loadout);
		((Control)this).Controls.Add((Control)(object)DGV_LoadoutItems);
		((Control)this).Controls.Add((Control)(object)DGV_Loadouts);
		((Control)this).Controls.Add((Control)(object)MenuStrip1);
		((Form)this).KeyPreview = true;
		((Form)this).MainMenuStrip = (MenuStrip)(object)MenuStrip1;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ReadyAircraft";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Ready Aircraft";
		((ISupportInitialize)(object)DGV_LoadoutItems).EndInit();
		((ISupportInitialize)(object)DGV_Loadouts).EndInit();
		((Control)MenuStrip1).ResumeLayout(false);
		((Control)MenuStrip1).PerformLayout();
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void Show(string[] argsArray)
	{
		ReadyAircraft readyAircraft = new ReadyAircraft();
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(argsArray[0], Client.CurrentScenario);
		if (activeUnitByNameOrID.IsAircraft)
		{
			readyAircraft.SelectedAircraft = new List<Aircraft> { (Aircraft)activeUnitByNameOrID };
			((Control)readyAircraft).Show();
		}
	}

	private void ReadyAircraft_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void ReadyAircraft_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Control)Button3).Visible = Client.AllowEditModeActions;
		((Control)Button4).Visible = Client.AllowEditModeActions;
		if (SimConfiguration.DefaultGamePreferences.OnlyShowAvailableLoadouts)
		{
			((CheckBox)CB_ShowOnlyUsable).Checked = true;
		}
		else
		{
			((CheckBox)CB_ShowOnlyUsable).Checked = false;
		}
		method_2();
		string text;
		string text2;
		if (SelectedAircraft.Count > 0)
		{
			text = Misc.RemoveHiddenString(SelectedAircraft[0].UnitClass);
			text2 = SelectedAircraft[0].AirOps.CurrentHostUnit.Name;
		}
		else if (!Information.IsNothing((object)SelectedEmptySlot) && SelectedEmptySlot.Count > 0)
		{
			text = SelectedEmptySlot[0].ReferenceUnit_UnitClass;
			text2 = SelectedEmptySlot[0].CurrentHostUnit_Name;
		}
		else
		{
			text = "<No Unit Selected>";
			text2 = "<No Host Unit Selected>";
		}
		int num = SelectedAircraft.Count;
		if (!Information.IsNothing((object)SelectedEmptySlot))
		{
			num += SelectedEmptySlot.Count;
		}
		((Form)this).Text = "Ready Aircraft: " + Conversions.ToString(num) + "x " + text + " at " + text2;
	}

	private void method_2()
	{
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		List<Aircraft> selectedAircraft = this.SelectedAircraft;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		bool UnlimitedAirWeapons = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		dictionary_0 = DBFunctions.GetSelectedAircraftTotalWeaponQty(selectedAircraft, ref sqliteConnection_, ref UnlimitedAirWeapons);
		if (this.SelectedAircraft.Count > 0)
		{
			int dBID = this.SelectedAircraft[0].DBID;
			Dictionary<int, int> selectedAircraftTotalWeaponQty = dictionary_0;
			sqliteConnection_ = Client.CurrentScenario.DBConnection;
			Scenario currentScenario = Client.CurrentScenario;
			UnlimitedAirWeapons = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
			Scenario CurrentScenario = Client.CurrentScenario;
			List<Aircraft> selectedAircraft2;
			Aircraft SelectedAircraft = (selectedAircraft2 = this.SelectedAircraft)[0];
			int num = 0;
			bool ExcludeOptionalWeapons = false;
			DataTable dataTable = DBFunctions.LoadoutsForThisAircraft_DT(dBID, selectedAircraftTotalWeaponQty, ref sqliteConnection_, currentScenario, ref UnlimitedAirWeapons, ref CurrentScenario, ref SelectedAircraft, ref num, ref ExcludeOptionalWeapons);
			selectedAircraft2[0] = SelectedAircraft;
			dataTable_1 = dataTable;
		}
		else
		{
			if (Information.IsNothing((object)SelectedEmptySlot) || SelectedEmptySlot.Count <= 0)
			{
				return;
			}
			Scenario CurrentScenario = Client.CurrentScenario;
			Aircraft SelectedAircraft2 = new Aircraft(ref CurrentScenario);
			SelectedAircraft2.AirOps.CurrentHostUnit = SelectedEmptySlot[0].get_CurrentHostUnit(Client.CurrentScenario);
			int referenceUnit_DBID = SelectedEmptySlot[0].ReferenceUnit_DBID;
			Dictionary<int, int> selectedAircraftTotalWeaponQty2 = dictionary_0;
			sqliteConnection_ = Client.CurrentScenario.DBConnection;
			Scenario currentScenario2 = Client.CurrentScenario;
			bool ExcludeOptionalWeapons = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
			CurrentScenario = Client.CurrentScenario;
			int num = 0;
			UnlimitedAirWeapons = false;
			dataTable_1 = DBFunctions.LoadoutsForThisAircraft_DT(referenceUnit_DBID, selectedAircraftTotalWeaponQty2, ref sqliteConnection_, currentScenario2, ref ExcludeOptionalWeapons, ref CurrentScenario, ref SelectedAircraft2, ref num, ref UnlimitedAirWeapons);
		}
		DataView dataView = new DataView(dataTable_1);
		if (Client.CurrentScenario.Cache_DisabledLoadouts.Count > 0)
		{
			dataView.RowFilter = "ID Not In (" + string.Join(",", Client.CurrentScenario.Cache_DisabledLoadouts) + ")";
		}
		if (((CheckBox)CB_ShowOnlyUsable).Checked)
		{
			if (Client.CurrentScenario.Cache_DisabledLoadouts.Count > 0)
			{
				dataView.RowFilter += " AND ";
			}
			dataView.RowFilter += "NOT NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly = '0'";
		}
		((DataGridView)DGV_Loadouts).DataSource = dataView;
		if (SelectedLoadout == 0)
		{
			SelectedLoadout = Conversions.ToInteger(((DataGridView)DGV_Loadouts).Rows[0].Cells["ID"].Value);
		}
		method_7(dictionary_0);
		foreach (Aircraft item in this.SelectedAircraft)
		{
			if (!Information.IsNothing((object)item.Loadout) && !hashSet_0.Contains(item.LoadoutDBID))
			{
				hashSet_0.Add(item.LoadoutDBID);
			}
		}
		if (!Information.IsNothing((object)SelectedEmptySlot))
		{
			foreach (Mission.EmptyAircraftSlot item2 in SelectedEmptySlot)
			{
				if (item2.int_0 != 0 && !hashSet_0.Contains(item2.int_0))
				{
					hashSet_0.Add(item2.int_0);
				}
			}
		}
		if (hashSet_0.Count == 1)
		{
			int num2 = hashSet_0.ElementAtOrDefault(0);
			{
				IEnumerator enumerator3 = ((IEnumerable)((DataGridView)DGV_Loadouts).Rows).GetEnumerator();
				try
				{
					DataGridViewRow val;
					while (true)
					{
						if (enumerator3.MoveNext())
						{
							val = (DataGridViewRow)enumerator3.Current;
							if (Conversions.ToInteger(val.Cells["ID"].Value) == num2)
							{
								break;
							}
							val.Selected = false;
							continue;
						}
						return;
					}
					val.Selected = true;
					return;
				}
				finally
				{
					IDisposable disposable = enumerator3 as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		foreach (DataGridViewRow item3 in (IEnumerable)((DataGridView)DGV_Loadouts).Rows)
		{
			item3.Selected = false;
		}
	}

	private int method_3(int int_5, Dictionary<int, int> dictionary_1, bool bool_5)
	{
		int result;
		try
		{
			int num;
			DataTable dataTable;
			ActiveUnit activeUnit = default(ActiveUnit);
			if (!Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				num = 9999999;
				dataTable = new DataTable();
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				dataTable = DBFunctions.ItemsForThisLoadout(int_5, ref sqliteConnection_, ref bool_5);
				if (SelectedAircraft.Count <= 0)
				{
					if (!Information.IsNothing((object)SelectedEmptySlot) && SelectedEmptySlot.Count > 0)
					{
						activeUnit = SelectedEmptySlot[0].get_CurrentHostUnit(Client.CurrentScenario);
					}
					goto IL_00ac;
				}
				if (!Information.IsNothing((object)SelectedAircraft[0]))
				{
					activeUnit = SelectedAircraft[0].AirOps.CurrentHostUnit;
					goto IL_00ac;
				}
				result = 0;
			}
			else
			{
				result = int.MaxValue;
			}
			goto end_IL_0001;
			IL_00ac:
			if (!Information.IsNothing((object)activeUnit))
			{
				foreach (DataRow row in dataTable.Rows)
				{
					if (bool_5 && Conversions.ToBoolean(row["Optional"]))
					{
						continue;
					}
					int num2 = Conversions.ToInteger(row["ComponentID"]);
					int num3 = Conversions.ToInteger(row["Quantity"]);
					if (num3 != 0)
					{
						Scenario theScen = Client.CurrentScenario;
						if (!Weapon.WeaponIsNonRivalrous(num2, ref theScen))
						{
							int num4 = activeUnit.Weaponry.HowManyOfThisWeaponOnMagazines(num2);
							int num5 = 0;
							if (!Information.IsNothing((object)dictionary_1) && dictionary_1.ContainsKey(num2))
							{
								num5 = dictionary_1[num2];
							}
							int num6 = (num4 + num5) / num3;
							if (num6 < num)
							{
								num = num6;
							}
						}
						continue;
					}
					result = 0;
					goto end_IL_0001;
				}
				result = num;
			}
			else
			{
				result = 0;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101137", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num7;
			if (!Debugger.IsAttached)
			{
				num7 = 0;
			}
			else
			{
				Debugger.Break();
				num7 = 0;
			}
			result = num7;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_4(object sender, EventArgs e)
	{
		method_9(bool_5: false, bool_6: true, bool_7: false, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
	}

	private void method_5(object sender, EventArgs e)
	{
		method_9(bool_5: false, bool_6: true, bool_7: true, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
	}

	private void method_6(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_7(Dictionary<int, int> dictionary_1)
	{
		try
		{
			if (Conversions.ToInteger(dataTable_1.AsEnumerable().ElementAtOrDefault(0)["ID"]) > 4)
			{
				DataRow[] array = dataTable_1.Select("ID = " + Conversions.ToString(SelectedLoadout));
				if (array.Count() > 0)
				{
					((Label)Label2).Text = Conversions.ToString(array[0]["LoadoutRoleDescription"]);
					((Label)Label1).Text = "Loadout's default weapon state " + Conversions.ToString(array[0]["WinchesterShotgunDescription"]);
					((Label)Label5).Text = "Default Attack Altitude: " + Conversions.ToString(array[0]["AttackAltitude"]);
					((Label)Label6).Text = "Loadouts available in magazines: " + Conversions.ToString(array[0]["NumberOfLoadouts"]);
					((Label)Label7).Text = "Loadouts available, including weapons mounted on currently selected aircraft: " + Conversions.ToString(array[0]["NumberOfLoadoutsIncludingMountedWeapons"]);
					((Label)Label8).Text = "Loadouts available, same as above but with mandatory (i.e. excluding optional) weapons only: " + Conversions.ToString(array[0]["NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"]);
				}
				int selectedLoadout = SelectedLoadout;
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				bool ExcludeOptionalWeapons = false;
				dataTable_0 = DBFunctions.ItemsForThisLoadout(selectedLoadout, ref sqliteConnection_, ref ExcludeOptionalWeapons);
				dataTable_0.Columns.Add("Available");
				dataTable_0.Columns.Add("AvailableTotal");
				ActiveUnit activeUnit = default(ActiveUnit);
				foreach (DataRow row in dataTable_0.Rows)
				{
					int num = Conversions.ToInteger(row["ComponentID"]);
					Scenario theScen = Client.CurrentScenario;
					if (!Weapon.WeaponIsNonRivalrous(num, ref theScen))
					{
						if (!Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
						{
							if (SelectedAircraft.Count <= 0)
							{
								if (!Information.IsNothing((object)SelectedEmptySlot) && SelectedEmptySlot.Count > 0)
								{
									activeUnit = SelectedEmptySlot[0].get_CurrentHostUnit(Client.CurrentScenario);
								}
							}
							else if (!Information.IsNothing((object)SelectedAircraft[0]))
							{
								activeUnit = SelectedAircraft[0].AirOps.CurrentHostUnit;
							}
							int num2;
							int num3;
							if (!Information.IsNothing((object)activeUnit))
							{
								num2 = activeUnit.Weaponry.HowManyOfThisWeaponOnMagazines(Conversions.ToInteger(row["ComponentID"]));
								num3 = 0;
							}
							else
							{
								num2 = 0;
								num3 = 0;
							}
							int num4 = num3;
							if (!Information.IsNothing((object)dictionary_1) && dictionary_1.ContainsKey(num))
							{
								num4 = dictionary_1[num];
							}
							row["Available"] = num2;
							row["AvailableTotal"] = num2 + num4;
						}
						else
						{
							row["Available"] = "Unlimited";
							row["AvailableTotal"] = "Unlimited";
						}
					}
					else
					{
						row["Available"] = "-";
						row["AvailableTotal"] = "-";
					}
					row["Item"] = Misc.RemoveHiddenString(Conversions.ToString(row["Item"]));
				}
				((DataGridView)DGV_LoadoutItems).AutoGenerateColumns = false;
				((DataGridView)DGV_LoadoutItems).DataSource = dataTable_0;
			}
			else
			{
				((Label)Label2).Text = "";
				((Label)Label5).Text = "";
				((Label)Label1).Text = "";
				((Label)Label6).Text = "";
				((Label)Label7).Text = "";
				((Label)Label8).Text = "";
				dataTable_0.Rows.Clear();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101138", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (SelectedAircraft[0].AirOps.CurrentHostUnit.SharedMagazines.Length > 0)
		{
			Client.theMagazinesWindow = new Magazines();
			Client.theMagazinesWindow.SelectedUnit = SelectedAircraft[0].AirOps.CurrentHostUnit;
			((Control)Client.theMagazinesWindow).Show();
		}
		else
		{
			DarkMessageBox.ShowError("The current host for these aircraft has no magazines available.", "No mags!");
		}
	}

	private void method_9(bool bool_5, bool bool_6, bool bool_7, bool bool_8)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Invalid comparison between Unknown and I4
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Invalid comparison between Unknown and I4
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Invalid comparison between Unknown and I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Invalid comparison between Unknown and I4
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Invalid comparison between Unknown and I4
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Invalid comparison between Unknown and I4
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Invalid comparison between Unknown and I4
		((Control)this).Cursor = Cursors.WaitCursor;
		try
		{
			if (SelectedAircraft.Count > 0)
			{
				foreach (Aircraft item in SelectedAircraft)
				{
					if (!Information.IsNothing((object)item.Loadout) && bool_8)
					{
						item.AirOps.UnloadStores();
					}
				}
			}
			bool flag = default(bool);
			bool flag2 = default(bool);
			bool flag3 = default(bool);
			bool flag4 = default(bool);
			foreach (Aircraft item2 in SelectedAircraft)
			{
				Aircraft theAC = item2;
				Aircraft_AirOps theAO = theAC.AirOps;
				if (theAO.QuickTurnaround_Enabled && !((CheckBox)CB_QuickTurnaround).Checked && !flag)
				{
					if (theAO.QuickTurnaround_SortiesFlown > 0)
					{
						DialogResult val = DarkMessageBox.ShowWarning("Aircraft " + theAC.Name + " had Quick Turnaround enabled previously, but disabled on the selected loadout. Do you want to keep the new configuration and stand down?", "Disable Quick Turnaround and Stand Down?", DarkDialogButton.YesNoCancel);
						if ((int)val == 6)
						{
							theAO.QuickTurnaround_Enabled = false;
							theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
						}
						else if ((int)val == 7)
						{
							flag2 = true;
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						theAO.UpdateQuickTurnaroundSettings_Reset(ref theAO);
					}
				}
				if (theAO.QuickTurnaround_Enabled && !flag)
				{
					Loadout loadout = DBFunctions.GetLoadout(ref theAC.ParentScen, SelectedLoadout, ExcludeOptionalWeapons: false, GetPayloadWeight: false);
					if (theAO.QuickTurnaround_SortiesFlown >= loadout.QuickTurnaround_MaxSorties && loadout.QuickTurnaround)
					{
						DialogResult val2 = DarkMessageBox.ShowWarning("Aircraft " + theAC.Name + " has flown more Quick Turnaround sorties than the selected loadout allows. Do you want to switch to the new loadout and stand down?", "Stand Down?", DarkDialogButton.YesNoCancel);
						if ((int)val2 == 6)
						{
							theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
							flag2 = false;
						}
						else if ((int)val2 == 7)
						{
							flag3 = true;
						}
						else
						{
							flag = true;
						}
					}
					else if (!loadout.QuickTurnaround)
					{
						theAO.UpdateQuickTurnaroundSettings_Reset(ref theAO);
					}
					if (!flag && theAO.QuickTurnaround_SortiesFlown > 0)
					{
						float num = theAO.QuickTurnaround_AirborneTime_Flown / (float)theAO.QuickTurnaround_SortiesFlown;
						if ((double)num > (double)(theAC.Loadout.QuickTurnaround_AirborneTime * 60) / (double)(((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2) && !flag)
						{
							if (theAO.QuickTurnaround_SortiesFlown <= ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 - 2)
							{
								if (num + theAO.QuickTurnaround_AirborneTime_Flown >= (float)(theAC.Loadout.QuickTurnaround_AirborneTime * 60))
								{
									flag4 = true;
								}
							}
							else
							{
								flag4 = true;
							}
							if (flag4)
							{
								DialogResult val3 = DarkMessageBox.ShowWarning("Aircraft " + theAC.Name + " has flown " + Conversions.ToString(theAO.QuickTurnaround_SortiesFlown) + " of " + Conversions.ToString(loadout.QuickTurnaround_MaxSorties) + " quick turnaround sorties. Total airborne time is " + Misc.TimeString((long)Math.Round(theAO.QuickTurnaround_AirborneTime_Flown)) + " of allowed " + Misc.TimeString(theAC.Loadout.QuickTurnaround_AirborneTime * 60) + ". Average airborne time for the completed sorties is " + Misc.TimeString((long)Math.Round(num)) + " which is greater than the remaining allowed airborne time. Because of this the aircraft needs to stand down. Do you want to switch to the new loadout and stand down?", "Stand Down?", DarkDialogButton.YesNoCancel);
								if ((int)val3 == 6)
								{
									theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
									flag2 = false;
								}
								else if ((int)val3 == 7)
								{
									flag3 = true;
								}
								else
								{
									flag = true;
								}
							}
						}
					}
				}
				int num2 = ((!Information.IsNothing((object)theAC.Loadout)) ? theAC.Loadout.DBID : 0);
				if (theAC.Loadout == null || theAC.Loadout.Weapons.Count() <= 0)
				{
					theAC.Loadout = null;
					theAC.Weaponry.ClearCachedWeapons();
				}
				ActiveUnit currentHostUnit = theAO.CurrentHostUnit;
				if (!flag3 && !flag)
				{
					currentHostUnit.AirOps.OutfitAC(ref theAC, SelectedLoadout, num2, bool_5, bool_7, bool_8, bool_6, PlayerFeedback: true);
				}
				else
				{
					currentHostUnit.AirOps.OutfitAC(ref theAC, num2, num2, bool_5, bool_7, bool_8, bool_6, PlayerFeedback: true);
				}
				currentHostUnit.AirOps.RefuelAC_Simple(ref theAC);
				currentHostUnit.AirOps.RepairAC(ref theAC);
				if (bool_5 && currentHostUnit.IsShip)
				{
					AirFacility hostAirFacility = currentHostUnit.AirOps.WhichFacilityCanHostThis(theAC);
					theAO.HostAirFacility = hostAirFacility;
					if (theAO.Condition == Aircraft_AirOps._AirOpsCondition.Readying)
					{
						theAO.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
					}
				}
				if ((int)((CheckBox)CB_QuickTurnaround).CheckState != 2)
				{
					if (!flag2 && !flag)
					{
						theAO.QuickTurnaround_Enabled = ((CheckBox)CB_QuickTurnaround).Checked;
					}
					if (!Information.IsNothing((object)TycSyoMclCb))
					{
						if (((ComboBox)Combo_NumberOfSorties).SelectedIndex >= 0 && ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 <= theAC.Loadout.QuickTurnaround_MaxSorties)
						{
							theAO.QuickTurnaround_SortiesTotal = ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2;
						}
						else
						{
							TycSyoMclCb = null;
						}
					}
					else if (!flag2 && !flag && !((CheckBox)CB_QuickTurnaround).Checked)
					{
						theAO.QuickTurnaround_SortiesTotal = 0;
					}
				}
				if (!Information.IsNothing((object)theAC.ActiveMissionOrPackage()))
				{
					theAC.ActiveMissionOrPackage().TimeSincePlayerNotification = 0;
				}
			}
			if (!Information.IsNothing((object)SelectedEmptySlot))
			{
				foreach (Mission.EmptyAircraftSlot item3 in SelectedEmptySlot)
				{
					item3.int_0 = SelectedLoadout;
					item3.Loadout_ExcludeOptionalWeapons = bool_7;
					if (!flag)
					{
						item3.Loadout_QuickTurnaround = ((CheckBox)CB_QuickTurnaround).Checked;
					}
					if (Information.IsNothing((object)TycSyoMclCb))
					{
						if (!flag && !((CheckBox)CB_QuickTurnaround).Checked)
						{
							item3.Loadout_QuickTurnaround_NumberOfSorties = 0;
						}
					}
					else if (((ComboBox)Combo_NumberOfSorties).SelectedIndex >= 0 && ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 <= item3.Loadout_QuickTurnaround_MaxSorties)
					{
						item3.Loadout_QuickTurnaround_NumberOfSorties = ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2;
					}
					else
					{
						TycSyoMclCb = null;
					}
					Scenario theScen = Client.CurrentScenario;
					Loadout loadout2 = DBFunctions.GetLoadout(ref theScen, SelectedLoadout, ExcludeOptionalWeapons: false, GetPayloadWeight: false);
					item3.LoadoutName = loadout2.Name;
					item3.Loadout_QuickTurnaround_MaxSorties = loadout2.QuickTurnaround_MaxSorties;
				}
			}
			if (((Control)MyProject.Forms.AirOps).Visible)
			{
				MyProject.Forms.AirOps.RefreshForm();
			}
			if (!Information.IsNothing((object)Client.MissionEditorWindow) && ((Control)Client.MissionEditorWindow).Visible)
			{
				Client.MissionEditorWindow.RefreshAll();
			}
			((Control)this).Cursor = Cursors.Default;
			if (!flag)
			{
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendRearmAircraftMessage(SelectedAircraft, bool_5, bool_6, bool_7, bool_8, SelectedLoadout, ((CheckBox)CB_QuickTurnaround).Checked);
				}
				((Form)this).Close();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101139", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		method_9(bool_5: true, bool_6: true, bool_7: false, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
	}

	private void method_11(object sender, EventArgs e)
	{
		method_9(bool_5: true, bool_6: true, bool_7: false, bool_8: false);
	}

	private void method_12(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			SelectedLoadout = Conversions.ToInteger(((DataGridView)DGV_Loadouts).Rows[e.RowIndex].Cells["ID"].Value);
			if (method_3(SelectedLoadout, dictionary_0, bool_5: false) > 0)
			{
				method_9(bool_5: false, bool_6: true, bool_7: false, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
			}
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Loadouts).SelectedRows).Count != 0)
		{
			SelectedLoadout = Conversions.ToInteger(((DataGridView)DGV_Loadouts).SelectedRows[0].Cells["ID"].Value);
			if (!Information.IsNothing((object)SelectedEmptySlot) && SelectedEmptySlot.Count > 0)
			{
				Button1.Enabled = true;
				Button5.Enabled = true;
				Button3.Enabled = false;
				Button4.Enabled = false;
			}
			else
			{
				Button1.Enabled = method_3(SelectedLoadout, dictionary_0, bool_5: false) > 0;
				Button5.Enabled = method_3(SelectedLoadout, dictionary_0, bool_5: true) > 0;
				Button3.Enabled = Button1.Enabled;
				Button4.Enabled = true;
			}
			method_7(dictionary_0);
			method_14();
		}
	}

	private void method_14()
	{
		//IL_0aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aac: Invalid comparison between Unknown and I4
		//IL_0b1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b23: Invalid comparison between Unknown and I4
		//IL_0ae7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aed: Invalid comparison between Unknown and I4
		//IL_092f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0935: Invalid comparison between Unknown and I4
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a14: Invalid comparison between Unknown and I4
		//IL_09d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d6: Invalid comparison between Unknown and I4
		bool flag = true;
		int num = 0;
		int num2 = 0;
		List<Aircraft> selectedAircraft = SelectedAircraft;
		Aircraft aircraft = default(Aircraft);
		if (selectedAircraft != null && selectedAircraft.Count > 0)
		{
			aircraft = SelectedAircraft[0];
		}
		DataRow[] array;
		bool? flag2 = default(bool?);
		if (aircraft?.Loadout != null && hashSet_0.Count == 1 && hashSet_0.ElementAtOrDefault(0) == SelectedLoadout)
		{
			array = dataTable_1.Select("ID = " + Conversions.ToString(hashSet_0.ElementAtOrDefault(0)));
			if (array.Count() > 0)
			{
				byte? b = (byte?)aircraft.Doctrine.get_AirOpsTempo(aircraft.ParentScen, MultipleUnits: false, UnitIsOperating: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					string_0 = Misc.TimeString(aircraft.Loadout.ReadyTime_Sustained * 60);
				}
				else
				{
					string_0 = Misc.TimeString(aircraft.Loadout.ReadyTime * 60);
				}
				bool_3 = aircraft.Loadout.QuickTurnaround;
				int_1 = aircraft.Loadout.QuickTurnaround_ReadyTime;
				int_3 = aircraft.Loadout.QuickTurnaround_MaxSorties;
				int_4 = aircraft.Loadout.QuickTurnaround_AdditionalTimePenalty;
				int_0 = aircraft.Loadout.QuickTurnaround_AirborneTime;
			}
			foreach (Aircraft item in SelectedAircraft)
			{
				num++;
				Aircraft_AirOps airOps = item.AirOps;
				if (num == 1)
				{
					flag2 = airOps.QuickTurnaround_Enabled;
					TycSyoMclCb = airOps.QuickTurnaround_SortiesTotal;
					continue;
				}
				bool quickTurnaround_Enabled = airOps.QuickTurnaround_Enabled;
				bool? flag3 = (flag2.HasValue ? new bool?(quickTurnaround_Enabled != (flag2 == true)) : ((bool?)null));
				if ((flag3 ?? true) && !Information.IsNothing((object)flag2) && flag3.HasValue)
				{
					flag2 = null;
				}
				int quickTurnaround_SortiesTotal = airOps.QuickTurnaround_SortiesTotal;
				int? tycSyoMclCb = TycSyoMclCb;
				flag3 = (tycSyoMclCb.HasValue ? new bool?(quickTurnaround_SortiesTotal != tycSyoMclCb.GetValueOrDefault()) : ((bool?)null));
				if ((flag3 ?? true) && !Information.IsNothing((object)TycSyoMclCb) && flag3.HasValue)
				{
					TycSyoMclCb = null;
				}
			}
			if (!Information.IsNothing((object)SelectedEmptySlot))
			{
				foreach (Mission.EmptyAircraftSlot item2 in SelectedEmptySlot)
				{
					num2++;
					if (num > 0 && num2 == 1)
					{
						flag2 = item2.Loadout_QuickTurnaround;
						TycSyoMclCb = item2.Loadout_QuickTurnaround_NumberOfSorties;
						continue;
					}
					bool quickTurnaround_Enabled = item2.Loadout_QuickTurnaround;
					bool? flag3 = ((!flag2.HasValue) ? ((bool?)null) : new bool?(quickTurnaround_Enabled != (flag2 == true)));
					if ((flag3 ?? true) && !Information.IsNothing((object)flag2) && flag3.HasValue)
					{
						flag2 = null;
					}
					int quickTurnaround_SortiesTotal = item2.Loadout_QuickTurnaround_NumberOfSorties;
					int? tycSyoMclCb = TycSyoMclCb;
					flag3 = (tycSyoMclCb.HasValue ? new bool?(quickTurnaround_SortiesTotal != tycSyoMclCb.GetValueOrDefault()) : ((bool?)null));
					if ((flag3 ?? true) && !Information.IsNothing((object)TycSyoMclCb) && flag3.HasValue)
					{
						TycSyoMclCb = null;
					}
				}
			}
		}
		else if (!Information.IsNothing((object)SelectedEmptySlot) && SelectedEmptySlot.Count > 0 && hashSet_0.Count == 1 && hashSet_0.ElementAtOrDefault(0) == SelectedLoadout)
		{
			array = dataTable_1.Select("ID = " + Conversions.ToString(SelectedLoadout));
			if (array.Count() > 0)
			{
				string_0 = Conversions.ToString(array[0]["ReadyTime"]);
				bool_3 = Conversions.ToBoolean(array[0]["QuickTurnaround"]);
				int_1 = Conversions.ToInteger(array[0]["QuickTurnaround_ReadyTime"]);
				int_3 = Conversions.ToInteger(array[0]["QuickTurnaround_MaxSorties"]);
				int_4 = Conversions.ToInteger(array[0]["QuickTurnaround_AdditionalTimePenalty"]);
				int_0 = Conversions.ToInteger(array[0]["QuickTurnaround_AirborneTime"]);
			}
			foreach (Mission.EmptyAircraftSlot item3 in SelectedEmptySlot)
			{
				num2++;
				if (num2 == 1)
				{
					flag2 = item3.Loadout_QuickTurnaround;
					TycSyoMclCb = item3.Loadout_QuickTurnaround_NumberOfSorties;
					continue;
				}
				bool quickTurnaround_Enabled = item3.Loadout_QuickTurnaround;
				bool? flag3 = (flag2.HasValue ? new bool?(quickTurnaround_Enabled != (flag2 == true)) : ((bool?)null));
				if ((flag3 ?? true) && !Information.IsNothing((object)flag2) && flag3.HasValue)
				{
					flag2 = null;
				}
				int quickTurnaround_SortiesTotal = item3.Loadout_QuickTurnaround_NumberOfSorties;
				int? tycSyoMclCb = TycSyoMclCb;
				flag3 = (tycSyoMclCb.HasValue ? new bool?(quickTurnaround_SortiesTotal != tycSyoMclCb.GetValueOrDefault()) : ((bool?)null));
				if ((flag3 ?? true) && !Information.IsNothing((object)TycSyoMclCb) && flag3.HasValue)
				{
					TycSyoMclCb = null;
				}
			}
		}
		else
		{
			array = dataTable_1.Select("ID = " + Conversions.ToString(SelectedLoadout));
			if (array.Count() > 0)
			{
				string_0 = Conversions.ToString(array[0]["ReadyTime"]);
				bool_3 = Conversions.ToBoolean(array[0]["QuickTurnaround"]);
				int_1 = Conversions.ToInteger(array[0]["QuickTurnaround_ReadyTime"]);
				int_3 = Conversions.ToInteger(array[0]["QuickTurnaround_MaxSorties"]);
				int_4 = Conversions.ToInteger(array[0]["QuickTurnaround_AdditionalTimePenalty"]);
				int_0 = Conversions.ToInteger(array[0]["QuickTurnaround_AirborneTime"]);
			}
		}
		if (!bool_3)
		{
			flag = false;
		}
		else if (Information.IsNothing((object)aircraft))
		{
			if (!Information.IsNothing((object)SelectedEmptySlot) && SelectedEmptySlot.Count <= 0)
			{
			}
		}
		else
		{
			int? elementState = aircraft.Doctrine.GetElementState(Doctrine.DoctrineItem_E.QuickTurnAroundForAircraft);
			int? tycSyoMclCb = elementState;
			if ((tycSyoMclCb.HasValue ? new bool?(tycSyoMclCb == 2) : ((bool?)null)) != true)
			{
				tycSyoMclCb = elementState;
				if (((!tycSyoMclCb.HasValue) ? ((bool?)null) : new bool?(tycSyoMclCb == 1)) == true)
				{
					if (array.Count() > 0)
					{
						Loadout loadout = new Loadout(Conversions.ToInteger(array[0]["ID"]), Conversions.ToString(array[0]["Name"]), 0, 0, 0, 0, (Loadout.LoadoutRole)Conversions.ToInteger(array[0]["LoadoutRole"]), (Loadout._LoadoutDayNight)0, Command_Core.Loadout._LoadoutWeather.AllWeather, 0f, 0, 0, theReBuddyIllum: false, ExcludeOptionalWeapons: false, Conversions.ToBoolean(array[0]["QuickTurnaround"]), Conversions.ToInteger(array[0]["QuickTurnaround_ReadyTime"]), Conversions.ToInteger(array[0]["QuickTurnaround_MaxSorties"]), Conversions.ToInteger(array[0]["QuickTurnaround_AdditionalTimePenalty"]), Conversions.ToInteger(array[0]["QuickTurnaround_AirborneTime"]), (Loadout._LoadoutDayNight)1, Doctrine._WeaponState.LoadoutSetting);
						if (!loadout.IsAAW && !loadout.IsSupportOrPatrol && !loadout.IsASW)
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
			}
			else
			{
				flag = false;
			}
		}
		bool_4 = false;
		if (hashSet_0.Count == 1 && hashSet_0.ElementAtOrDefault(0) == SelectedLoadout)
		{
			if (!flag)
			{
				((Control)CB_QuickTurnaround).Enabled = false;
				if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
				{
					((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)0;
				}
				else
				{
					((CheckBox)CB_QuickTurnaround).Checked = false;
				}
				method_21(0);
			}
			else
			{
				((Control)CB_QuickTurnaround).Enabled = true;
				if (Information.IsNothing((object)flag2))
				{
					((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)2;
					method_21(TycSyoMclCb);
					((Control)Combo_NumberOfSorties).Enabled = false;
					((Control)Label_QuickTurnaroundInfo).Enabled = true;
					((Label)Label_QuickTurnaroundInfo).Text = "Selection includes aircraft with and without the Quick Turnaround option set.";
				}
				else if (flag2 != true)
				{
					if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
					{
						((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)0;
					}
					else
					{
						((CheckBox)CB_QuickTurnaround).Checked = false;
					}
					method_21(int_3);
				}
				else
				{
					if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
					{
						((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)1;
					}
					else
					{
						((CheckBox)CB_QuickTurnaround).Checked = true;
					}
					method_21(TycSyoMclCb);
					((Control)Combo_NumberOfSorties).Enabled = true;
					((Control)Label_QuickTurnaroundInfo).Enabled = true;
					if (!Information.IsNothing((object)TycSyoMclCb))
					{
						((Label)Label_QuickTurnaroundInfo).Text = method_18();
					}
					else
					{
						((Label)Label_QuickTurnaroundInfo).Text = "";
					}
				}
			}
		}
		else
		{
			if (!flag)
			{
				((Control)CB_QuickTurnaround).Enabled = false;
				if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
				{
					((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)0;
				}
				else
				{
					((CheckBox)CB_QuickTurnaround).Checked = false;
				}
			}
			else if (bool_3)
			{
				((Control)CB_QuickTurnaround).Enabled = true;
				if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
				{
					((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)0;
				}
				else
				{
					((CheckBox)CB_QuickTurnaround).Checked = false;
				}
			}
			else
			{
				((Control)CB_QuickTurnaround).Enabled = false;
				if ((int)((CheckBox)CB_QuickTurnaround).CheckState == 2)
				{
					((CheckBox)CB_QuickTurnaround).CheckState = (CheckState)0;
				}
				else
				{
					((CheckBox)CB_QuickTurnaround).Checked = false;
				}
			}
			method_21(int_3);
		}
		bool_4 = true;
	}

	private void method_15(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1 && (object)((DataGridView)DGV_LoadoutItems).Columns[e.ColumnIndex].CellType == typeof(DataGridViewLinkCell))
		{
			int selectedObjectID = Conversions.ToInteger(dataTable_0.Rows[e.RowIndex]["ComponentID"]);
			Client.smethod_17("Weapon", selectedObjectID);
		}
	}

	private void method_16(object sender, DataGridViewCellFormattingEventArgs e)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		try
		{
			if (!Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				DataGridViewRow val = ((DataGridView)DGV_Loadouts).Rows[e.RowIndex];
				if (Operators.CompareString(((DataGridView)DGV_Loadouts).Columns[e.ColumnIndex].Name, "NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly", true) == 0 && (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((ConvertEventArgs)e).Value)) || Conversions.ToInteger(((ConvertEventArgs)e).Value) <= 0) && Operators.CompareString(Conversions.ToString(((ConvertEventArgs)e).Value), "Unlimited", true) != 0)
				{
					val.DefaultCellStyle.ForeColor = Color.DarkGray;
					val.DefaultCellStyle.Font = new Font(((Control)this).Font, (FontStyle)2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200110", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ReadyAircraft_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Invalid comparison between Unknown and I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Invalid comparison between Unknown and I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 13 && ((Control)this).Visible)
		{
			if (method_3(SelectedLoadout, dictionary_0, bool_5: false) > 0)
			{
				method_9(bool_5: false, bool_6: true, bool_7: false, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
			}
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 107 && (int)e.KeyCode != 109))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		((Label)Label_QuickTurnaroundInfo).Text = method_18();
		if (bool_4)
		{
			if (((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 <= int_3 && ((ComboBox)Combo_NumberOfSorties).SelectedIndex >= 0)
			{
				TycSyoMclCb = ((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2;
			}
			else
			{
				TycSyoMclCb = null;
			}
		}
	}

	private string method_18()
	{
		if (((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2 > int_3)
		{
			return "";
		}
		return Conversions.ToString(((ComboBox)Combo_NumberOfSorties).SelectedIndex + 2) + " sorties @ " + Misc.TimeString(int_0 * 60) + " maximum airborne time and " + Misc.TimeString(int_1 * 60) + " turnaround, with " + string_0 + " standdown ready time";
	}

	private void method_19(int? nullable_0)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		((ComboBox)Combo_NumberOfSorties).BeginUpdate();
		((ComboBox)Combo_NumberOfSorties).Items.Clear();
		if ((int)((CheckBox)CB_QuickTurnaround).CheckState != 2 && ((CheckBox)CB_QuickTurnaround).Checked)
		{
			int num = int_3;
			for (int i = 2; i <= num; i++)
			{
				if (i == int_3)
				{
					((ComboBox)Combo_NumberOfSorties).Items.Add((object)(Conversions.ToString(i) + " Sorties (Maximum)"));
				}
				else
				{
					((ComboBox)Combo_NumberOfSorties).Items.Add((object)(Conversions.ToString(i) + " Sorties"));
				}
			}
			if (!Information.IsNothing((object)nullable_0) && ((ComboBox)Combo_NumberOfSorties).Items.Count > 0)
			{
				((ComboBox)Combo_NumberOfSorties).SelectedIndex = ((ComboBox)Combo_NumberOfSorties).Items.Count - 1;
			}
			else
			{
				((ComboBox)Combo_NumberOfSorties).Items.Add((object)"Various");
				((ComboBox)Combo_NumberOfSorties).SelectedIndex = ((ComboBox)Combo_NumberOfSorties).Items.Count - 1;
			}
		}
		((ComboBox)Combo_NumberOfSorties).EndUpdate();
	}

	private void method_20(object sender, EventArgs e)
	{
		method_21(int_3);
	}

	private void method_21(int? nullable_0)
	{
		if (!((CheckBox)CB_QuickTurnaround).Checked)
		{
			((Control)Combo_NumberOfSorties).Enabled = false;
			method_19(nullable_0);
			((Control)Label_QuickTurnaroundInfo).Enabled = false;
			((Label)Label_QuickTurnaroundInfo).Text = "";
		}
		else
		{
			((Control)Combo_NumberOfSorties).Enabled = true;
			method_19(nullable_0);
			((Control)Label_QuickTurnaroundInfo).Enabled = true;
			((Label)Label_QuickTurnaroundInfo).Text = method_18();
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		method_2();
		if (!((CheckBox)CB_ShowOnlyUsable).Checked)
		{
			SimConfiguration.DefaultGamePreferences.OnlyShowAvailableLoadouts = false;
		}
		else
		{
			SimConfiguration.DefaultGamePreferences.OnlyShowAvailableLoadouts = true;
		}
	}

	static ReadyAircraft()
	{
		Class72.smethod_20();
	}
}

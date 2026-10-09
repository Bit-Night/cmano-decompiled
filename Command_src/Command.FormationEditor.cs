using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Command_Core;
using Command.My;
using CommandNetcode.RT;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FormationEditor : DarkSecondaryFormBase, GInterface0
{
	public enum CompositionTypeCombo
	{
		None = 3,
		Different_Types = 2,
		Different_Classes = 1,
		Different_Loadouts = 0
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("AssignToPatrol_TSMI")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _AssignToPatrol_TSMI;

	[AccessedThroughProperty("TV_Units")]
	[CompilerGenerated]
	private DarkTreeView _TV_Units;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonEdit")]
	private DarkUIButton _ButtonEdit;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonReload")]
	private DarkUIButton _ButtonReload;

	[CompilerGenerated]
	[AccessedThroughProperty("combo_Formations")]
	private DarkUIComboBox _combo_Formations;

	[AccessedThroughProperty("ButtonSpacingUnit")]
	[CompilerGenerated]
	private DarkUIButton _ButtonSpacingUnit;

	[CompilerGenerated]
	[AccessedThroughProperty("button_SetImmediate")]
	private DarkUIButton _button_SetImmediate;

	[AccessedThroughProperty("button_SetFormation")]
	[CompilerGenerated]
	private DarkUIButton _button_SetFormation;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonRemove")]
	private DarkUIButton _ButtonRemove;

	[AccessedThroughProperty("ComboSorting")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboSorting;

	[AccessedThroughProperty("ButtonSetAsLeader")]
	[CompilerGenerated]
	private DarkUIButton _ButtonSetAsLeader;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_SetStationFixed")]
	private DarkUIButton _TSB_SetStationFixed;

	[AccessedThroughProperty("TSB_SetStationRelative")]
	[CompilerGenerated]
	private DarkUIButton _TSB_SetStationRelative;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MembersInheritIcon")]
	private DarkUICheckBox _CB_MembersInheritIcon;

	[AccessedThroughProperty("CBSprintDrift")]
	[CompilerGenerated]
	private DarkUICheckBox _CBSprintDrift;

	[AccessedThroughProperty("NumUpDownBearing")]
	[CompilerGenerated]
	private NumericUpDown _NumUpDownBearing;

	[CompilerGenerated]
	[AccessedThroughProperty("NumUD_Spacing")]
	private NumericUpDown _NumUD_Spacing;

	[AccessedThroughProperty("ButtonNewGroup")]
	[CompilerGenerated]
	private DarkUIButton _ButtonNewGroup;

	[AccessedThroughProperty("ButtonRenameGroup")]
	[CompilerGenerated]
	private DarkUIButton _ButtonRenameGroup;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonParentGroup")]
	private DarkUIButton _ButtonParentGroup;

	[AccessedThroughProperty("ButtonDisband")]
	[CompilerGenerated]
	private DarkUIButton _ButtonDisband;

	public Group SelectedGroup;

	public Patrol SelectedPatrol;

	private Keys[] keys_0;

	private List<StandardFormation> list_0;

	private static int int_0;

	private static int int_1;

	private CompositionTypeCombo compositionTypeCombo_0;

	private MapProfile.MapViewMode mapViewMode_0;

	[CompilerGenerated]
	private bool bool_2;

	private static int int_2;

	private int int_3;

	private bool bool_3;

	private LockObject lockObject_0;

	[field: AccessedThroughProperty("CMenu_Unit")]
	internal virtual DarkContextMenu CMenu_Unit { get; set; }

	internal virtual DarkToolStripMenuItem AssignToPatrol_TSMI
	{
		[CompilerGenerated]
		get
		{
			return _AssignToPatrol_TSMI;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkToolStripMenuItem darkToolStripMenuItem = _AssignToPatrol_TSMI;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_AssignToPatrol_TSMI = value;
			darkToolStripMenuItem = _AssignToPatrol_TSMI;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("RemoveFromPatrol_TSMI")]
	internal virtual DarkToolStripMenuItem RemoveFromPatrol_TSMI { get; set; }

	internal virtual DarkTreeView TV_Units
	{
		[CompilerGenerated]
		get
		{
			return _TV_Units;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_16);
			MouseEventHandler val2 = new MouseEventHandler(method_17);
			DarkTreeView darkTreeView = _TV_Units;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick -= val;
				((Control)darkTreeView).MouseDoubleClick -= val2;
			}
			_TV_Units = value;
			darkTreeView = _TV_Units;
			if (darkTreeView != null)
			{
				((Control)darkTreeView).MouseClick += val;
				((Control)darkTreeView).MouseDoubleClick += val2;
			}
		}
	}

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			Timer val = timer_0;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_0 = value;
			val = timer_0;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonEdit
	{
		[CompilerGenerated]
		get
		{
			return _ButtonEdit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			DarkUIButton darkUIButton = _ButtonEdit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonEdit = value;
			darkUIButton = _ButtonEdit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonReload
	{
		[CompilerGenerated]
		get
		{
			return _ButtonReload;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkUIButton darkUIButton = _ButtonReload;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonReload = value;
			darkUIButton = _ButtonReload;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUIComboBox combo_Formations
	{
		[CompilerGenerated]
		get
		{
			return _combo_Formations;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIComboBox darkUIComboBox = _combo_Formations;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_combo_Formations = value;
			darkUIComboBox = _combo_Formations;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	internal virtual DarkUIButton ButtonSpacingUnit
	{
		[CompilerGenerated]
		get
		{
			return _ButtonSpacingUnit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_32;
			DarkUIButton darkUIButton = _ButtonSpacingUnit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonSpacingUnit = value;
			darkUIButton = _ButtonSpacingUnit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton button_SetImmediate
	{
		[CompilerGenerated]
		get
		{
			return _button_SetImmediate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkUIButton darkUIButton = _button_SetImmediate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_button_SetImmediate = value;
			darkUIButton = _button_SetImmediate;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton button_SetFormation
	{
		[CompilerGenerated]
		get
		{
			return _button_SetFormation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkUIButton darkUIButton = _button_SetFormation;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_button_SetFormation = value;
			darkUIButton = _button_SetFormation;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonRemove
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRemove;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			DarkUIButton darkUIButton = _ButtonRemove;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonRemove = value;
			darkUIButton = _ButtonRemove;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	internal virtual DarkUIComboBox ComboSorting
	{
		[CompilerGenerated]
		get
		{
			return _ComboSorting;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIComboBox darkUIComboBox = _ComboSorting;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_ComboSorting = value;
			darkUIComboBox = _ComboSorting;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonSetAsLeader
	{
		[CompilerGenerated]
		get
		{
			return _ButtonSetAsLeader;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUIButton darkUIButton = _ButtonSetAsLeader;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonSetAsLeader = value;
			darkUIButton = _ButtonSetAsLeader;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox4")]
	internal virtual DarkGroupBox DarkGroupBox4 { get; set; }

	internal virtual DarkUIButton TSB_SetStationFixed
	{
		[CompilerGenerated]
		get
		{
			return _TSB_SetStationFixed;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIButton darkUIButton = _TSB_SetStationFixed;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_TSB_SetStationFixed = value;
			darkUIButton = _TSB_SetStationFixed;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton TSB_SetStationRelative
	{
		[CompilerGenerated]
		get
		{
			return _TSB_SetStationRelative;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIButton darkUIButton = _TSB_SetStationRelative;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_TSB_SetStationRelative = value;
			darkUIButton = _TSB_SetStationRelative;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox5")]
	internal virtual DarkGroupBox DarkGroupBox5 { get; set; }

	internal virtual DarkUICheckBox CB_MembersInheritIcon
	{
		[CompilerGenerated]
		get
		{
			return _CB_MembersInheritIcon;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkUICheckBox darkUICheckBox = _CB_MembersInheritIcon;
			if (darkUICheckBox != null)
			{
				((Control)darkUICheckBox).Click -= eventHandler;
			}
			_CB_MembersInheritIcon = value;
			darkUICheckBox = _CB_MembersInheritIcon;
			if (darkUICheckBox != null)
			{
				((Control)darkUICheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("PictureBox1")]
	internal virtual PictureBox PictureBox1 { get; set; }

	internal virtual DarkUICheckBox CBSprintDrift
	{
		[CompilerGenerated]
		get
		{
			return _CBSprintDrift;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUICheckBox darkUICheckBox = _CBSprintDrift;
			if (darkUICheckBox != null)
			{
				((Control)darkUICheckBox).Click -= eventHandler;
			}
			_CBSprintDrift = value;
			darkUICheckBox = _CBSprintDrift;
			if (darkUICheckBox != null)
			{
				((Control)darkUICheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual NumericUpDown NumUpDownBearing
	{
		[CompilerGenerated]
		get
		{
			return _NumUpDownBearing;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			EventHandler eventHandler2 = method_25;
			NumericUpDown val = _NumUpDownBearing;
			if (val != null)
			{
				val.TextChanged -= eventHandler;
				val.ValueChanged -= eventHandler2;
			}
			_NumUpDownBearing = value;
			val = _NumUpDownBearing;
			if (val != null)
			{
				val.TextChanged += eventHandler;
				val.ValueChanged += eventHandler2;
			}
		}
	}

	internal virtual NumericUpDown NumUD_Spacing
	{
		[CompilerGenerated]
		get
		{
			return _NumUD_Spacing;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			EventHandler eventHandler2 = method_23;
			NumericUpDown val = _NumUD_Spacing;
			if (val != null)
			{
				val.TextChanged -= eventHandler;
				val.ValueChanged -= eventHandler2;
			}
			_NumUD_Spacing = value;
			val = _NumUD_Spacing;
			if (val != null)
			{
				val.TextChanged += eventHandler;
				val.ValueChanged += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("GB_Formation")]
	internal virtual DarkGroupBox GB_Formation { get; set; }

	internal virtual DarkUIButton ButtonNewGroup
	{
		[CompilerGenerated]
		get
		{
			return _ButtonNewGroup;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_34;
			DarkUIButton darkUIButton = _ButtonNewGroup;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonNewGroup = value;
			darkUIButton = _ButtonNewGroup;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonRenameGroup
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRenameGroup;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_36;
			DarkUIButton darkUIButton = _ButtonRenameGroup;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonRenameGroup = value;
			darkUIButton = _ButtonRenameGroup;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelGroupName")]
	internal virtual DarkLabel LabelGroupName { get; set; }

	internal virtual DarkUIButton ButtonParentGroup
	{
		[CompilerGenerated]
		get
		{
			return _ButtonParentGroup;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_37;
			DarkUIButton darkUIButton = _ButtonParentGroup;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonParentGroup = value;
			darkUIButton = _ButtonParentGroup;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonDisband
	{
		[CompilerGenerated]
		get
		{
			return _ButtonDisband;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_38;
			DarkUIButton darkUIButton = _ButtonDisband;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonDisband = value;
			darkUIButton = _ButtonDisband;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
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

	static FormationEditor()
	{
		Class72.smethod_20();
		int_0 = 0;
	}

	public FormationEditor()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(FormationEditor_FormClosing);
		((Form)this).Load += FormationEditor_Load;
		((Control)this).KeyDown += new KeyEventHandler(FormationEditor_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(qAuSkpoOyCg);
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)115,
			(Keys)27
		};
		list_0 = new List<StandardFormation>();
		RTMPEnabled = true;
		int_3 = int.MaxValue;
		bool_3 = false;
		lockObject_0 = new LockObject();
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
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Expected O, but got Unknown
		//IL_0c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c58: Expected O, but got Unknown
		//IL_0fb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbf: Expected O, but got Unknown
		//IL_1591: Unknown result type (might be due to invalid IL or missing references)
		//IL_159b: Expected O, but got Unknown
		icontainer_1 = new Container();
		CMenu_Unit = new DarkContextMenu();
		AssignToPatrol_TSMI = new DarkToolStripMenuItem();
		RemoveFromPatrol_TSMI = new DarkToolStripMenuItem();
		TV_Units = new DarkTreeView();
		Timer1 = new Timer(icontainer_1);
		GB_Formation = new DarkGroupBox();
		NumUpDownBearing = new NumericUpDown();
		NumUD_Spacing = new NumericUpDown();
		PictureBox1 = new PictureBox();
		DarkLabel5 = new DarkLabel();
		DarkLabel4 = new DarkLabel();
		ButtonSpacingUnit = new DarkUIButton();
		button_SetImmediate = new DarkUIButton();
		button_SetFormation = new DarkUIButton();
		ButtonEdit = new DarkUIButton();
		ButtonReload = new DarkUIButton();
		DarkLabel2 = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		combo_Formations = new DarkUIComboBox();
		DarkGroupBox2 = new DarkGroupBox();
		ButtonNewGroup = new DarkUIButton();
		ButtonRemove = new DarkUIButton();
		DarkLabel3 = new DarkLabel();
		ComboSorting = new DarkUIComboBox();
		ButtonSetAsLeader = new DarkUIButton();
		DarkGroupBox4 = new DarkGroupBox();
		TSB_SetStationFixed = new DarkUIButton();
		TSB_SetStationRelative = new DarkUIButton();
		DarkGroupBox5 = new DarkGroupBox();
		ButtonRenameGroup = new DarkUIButton();
		CBSprintDrift = new DarkUICheckBox();
		CB_MembersInheritIcon = new DarkUICheckBox();
		LabelGroupName = new DarkLabel();
		ButtonParentGroup = new DarkUIButton();
		ButtonDisband = new DarkUIButton();
		((Control)CMenu_Unit).SuspendLayout();
		((Control)GB_Formation).SuspendLayout();
		((ISupportInitialize)NumUpDownBearing).BeginInit();
		((ISupportInitialize)NumUD_Spacing).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)DarkGroupBox4).SuspendLayout();
		((Control)DarkGroupBox5).SuspendLayout();
		((Control)this).SuspendLayout();
		((ToolStrip)CMenu_Unit).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)CMenu_Unit).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)CMenu_Unit).ImageScalingSize = new Size(20, 20);
		((ToolStrip)CMenu_Unit).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)AssignToPatrol_TSMI,
			(ToolStripItem)RemoveFromPatrol_TSMI
		});
		((Control)CMenu_Unit).Name = "CMenu_ThreatAxis";
		((Control)CMenu_Unit).Size = new Size(181, 48);
		((ToolStripItem)AssignToPatrol_TSMI).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)AssignToPatrol_TSMI).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)AssignToPatrol_TSMI).Name = "AssignToPatrol_TSMI";
		((ToolStripItem)AssignToPatrol_TSMI).Size = new Size(180, 22);
		((ToolStripItem)AssignToPatrol_TSMI).Text = "Assign to Patrol...";
		((ToolStripItem)RemoveFromPatrol_TSMI).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)RemoveFromPatrol_TSMI).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)RemoveFromPatrol_TSMI).Name = "RemoveFromPatrol_TSMI";
		((ToolStripItem)RemoveFromPatrol_TSMI).Size = new Size(180, 22);
		((ToolStripItem)RemoveFromPatrol_TSMI).Text = "Remove from Patrol";
		((Control)TV_Units).AllowDrop = true;
		((Control)TV_Units).Anchor = (AnchorStyles)15;
		((Control)TV_Units).BackColor = Color.FromArgb(50, 53, 55);
		((Control)TV_Units).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)TV_Units).Location = new Point(6, 46);
		TV_Units.MaxDragChange = 20;
		((Control)TV_Units).Name = "TV_Units";
		((Control)TV_Units).Size = new Size(634, 264);
		((Control)TV_Units).TabIndex = 12;
		Timer1.Interval = 1000;
		((Control)GB_Formation).Controls.Add((Control)(object)NumUpDownBearing);
		((Control)GB_Formation).Controls.Add((Control)(object)NumUD_Spacing);
		((Control)GB_Formation).Controls.Add((Control)(object)PictureBox1);
		((Control)GB_Formation).Controls.Add((Control)(object)DarkLabel5);
		((Control)GB_Formation).Controls.Add((Control)(object)DarkLabel4);
		((Control)GB_Formation).Controls.Add((Control)(object)ButtonSpacingUnit);
		((Control)GB_Formation).Controls.Add((Control)(object)button_SetImmediate);
		((Control)GB_Formation).Controls.Add((Control)(object)button_SetFormation);
		((Control)GB_Formation).Controls.Add((Control)(object)ButtonEdit);
		((Control)GB_Formation).Controls.Add((Control)(object)ButtonReload);
		((Control)GB_Formation).Controls.Add((Control)(object)DarkLabel2);
		((Control)GB_Formation).Controls.Add((Control)(object)DarkLabel1);
		((Control)GB_Formation).Controls.Add((Control)(object)combo_Formations);
		((Control)GB_Formation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_Formation).Location = new Point(14, 36);
		((Control)GB_Formation).Name = "GB_Formation";
		((Control)GB_Formation).Size = new Size(404, 134);
		((Control)GB_Formation).TabIndex = 16;
		((GroupBox)GB_Formation).TabStop = false;
		((GroupBox)GB_Formation).Text = "Formation";
		((UpDownBase)NumUpDownBearing).BackColor = Color.FromArgb(40, 40, 40);
		((UpDownBase)NumUpDownBearing).ForeColor = SystemColors.Menu;
		((Control)NumUpDownBearing).Location = new Point(61, 101);
		NumUpDownBearing.Maximum = new decimal(new int[4] { 360, 0, 0, 0 });
		((Control)NumUpDownBearing).Name = "NumUpDownBearing";
		((Control)NumUpDownBearing).Size = new Size(125, 23);
		((Control)NumUpDownBearing).TabIndex = 19;
		((UpDownBase)NumUD_Spacing).BackColor = Color.FromArgb(40, 40, 40);
		((UpDownBase)NumUD_Spacing).ForeColor = SystemColors.Menu;
		((Control)NumUD_Spacing).Location = new Point(61, 61);
		NumUD_Spacing.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		((Control)NumUD_Spacing).Name = "NumUD_Spacing";
		((Control)NumUD_Spacing).Size = new Size(125, 23);
		((Control)NumUD_Spacing).TabIndex = 18;
		((Control)PictureBox1).Anchor = (AnchorStyles)9;
		((Control)PictureBox1).Location = new Point(297, 24);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(100, 100);
		PictureBox1.TabIndex = 16;
		PictureBox1.TabStop = false;
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(188, 101);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(12, 15);
		((Control)DarkLabel5).TabIndex = 11;
		((Label)DarkLabel5).Text = "°";
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(6, 103);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(52, 15);
		((Control)DarkLabel4).TabIndex = 9;
		((Label)DarkLabel4).Text = "Heading";
		((ButtonBase)ButtonSpacingUnit).BackColor = Color.Transparent;
		((Button)ButtonSpacingUnit).DialogResult = (DialogResult)0;
		((Control)ButtonSpacingUnit).ForeColor = SystemColors.Control;
		((Control)ButtonSpacingUnit).Location = new Point(192, 61);
		((Control)ButtonSpacingUnit).Name = "ButtonSpacingUnit";
		ButtonSpacingUnit.RoundRadius = 0;
		((Control)ButtonSpacingUnit).Size = new Size(39, 26);
		((Control)ButtonSpacingUnit).TabIndex = 8;
		ButtonSpacingUnit.Text = "nm";
		((Control)button_SetImmediate).Anchor = (AnchorStyles)9;
		((ButtonBase)button_SetImmediate).BackColor = Color.Transparent;
		((Button)button_SetImmediate).DialogResult = (DialogResult)0;
		((Control)button_SetImmediate).ForeColor = SystemColors.Control;
		((Control)button_SetImmediate).Location = new Point(277, 0);
		((Control)button_SetImmediate).Name = "button_SetImmediate";
		button_SetImmediate.RoundRadius = 0;
		((Control)button_SetImmediate).Size = new Size(57, 19);
		((Control)button_SetImmediate).TabIndex = 7;
		button_SetImmediate.Text = "Place";
		((Control)button_SetFormation).Anchor = (AnchorStyles)9;
		((ButtonBase)button_SetFormation).BackColor = Color.Transparent;
		((Button)button_SetFormation).DialogResult = (DialogResult)0;
		((Control)button_SetFormation).ForeColor = SystemColors.Control;
		((Control)button_SetFormation).Location = new Point(340, 0);
		((Control)button_SetFormation).Name = "button_SetFormation";
		button_SetFormation.RoundRadius = 0;
		((Control)button_SetFormation).Size = new Size(57, 19);
		((Control)button_SetFormation).TabIndex = 6;
		button_SetFormation.Text = "Assign";
		((ButtonBase)ButtonEdit).BackColor = Color.Transparent;
		((Button)ButtonEdit).DialogResult = (DialogResult)0;
		((Control)ButtonEdit).ForeColor = SystemColors.Control;
		((Control)ButtonEdit).Location = new Point(255, 28);
		((Control)ButtonEdit).Name = "ButtonEdit";
		ButtonEdit.RoundRadius = 0;
		((Control)ButtonEdit).Size = new Size(37, 19);
		((Control)ButtonEdit).TabIndex = 5;
		ButtonEdit.Text = "Edit";
		((ButtonBase)ButtonReload).BackColor = Color.Transparent;
		((Button)ButtonReload).DialogResult = (DialogResult)0;
		((Control)ButtonReload).ForeColor = SystemColors.Control;
		((Control)ButtonReload).Location = new Point(192, 28);
		((Control)ButtonReload).Name = "ButtonReload";
		ButtonReload.RoundRadius = 0;
		((Control)ButtonReload).Size = new Size(55, 19);
		((Control)ButtonReload).TabIndex = 4;
		ButtonReload.Text = "Reload";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(6, 66);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(49, 15);
		((Control)DarkLabel2).TabIndex = 2;
		((Label)DarkLabel2).Text = "Spacing";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(6, 28);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(31, 15);
		((Control)DarkLabel1).TabIndex = 1;
		((Label)DarkLabel1).Text = "Type";
		((ComboBox)combo_Formations).BackColor = Color.Transparent;
		((ComboBox)combo_Formations).DrawMode = (DrawMode)1;
		((ComboBox)combo_Formations).DropDownStyle = (ComboBoxStyle)2;
		((Control)combo_Formations).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)combo_Formations).FormattingEnabled = true;
		((Control)combo_Formations).Location = new Point(61, 26);
		((Control)combo_Formations).Name = "combo_Formations";
		((Control)combo_Formations).Size = new Size(125, 21);
		((Control)combo_Formations).TabIndex = 0;
		((Control)DarkGroupBox2).Anchor = (AnchorStyles)15;
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonNewGroup);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonRemove);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel3);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ComboSorting);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonSetAsLeader);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkGroupBox4);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)TV_Units);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(14, 176);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(646, 316);
		((Control)DarkGroupBox2).TabIndex = 17;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Composition";
		((ButtonBase)ButtonNewGroup).BackColor = Color.Transparent;
		((Button)ButtonNewGroup).DialogResult = (DialogResult)0;
		((Control)ButtonNewGroup).ForeColor = SystemColors.Control;
		((Control)ButtonNewGroup).Location = new Point(207, 16);
		((Control)ButtonNewGroup).Name = "ButtonNewGroup";
		ButtonNewGroup.RoundRadius = 0;
		((Control)ButtonNewGroup).Size = new Size(85, 22);
		((Control)ButtonNewGroup).TabIndex = 21;
		ButtonNewGroup.Text = "New group";
		((ButtonBase)ButtonRemove).BackColor = Color.Transparent;
		((Button)ButtonRemove).DialogResult = (DialogResult)0;
		((Control)ButtonRemove).ForeColor = SystemColors.Control;
		((Control)ButtonRemove).Location = new Point(336, 16);
		((Control)ButtonRemove).Name = "ButtonRemove";
		ButtonRemove.RoundRadius = 0;
		((Control)ButtonRemove).Size = new Size(68, 22);
		((Control)ButtonRemove).TabIndex = 20;
		ButtonRemove.Text = "Remove";
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(6, 19);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(45, 15);
		((Control)DarkLabel3).TabIndex = 6;
		((Label)DarkLabel3).Text = "Sorting";
		((ComboBox)ComboSorting).BackColor = Color.Transparent;
		((ComboBox)ComboSorting).DrawMode = (DrawMode)1;
		((ComboBox)ComboSorting).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboSorting).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboSorting).FormattingEnabled = true;
		((ComboBox)ComboSorting).Items.AddRange(new object[5] { "None", "Different Types", "Different Classes", "Different Loadouts", "" });
		((Control)ComboSorting).Location = new Point(57, 17);
		((Control)ComboSorting).Name = "ComboSorting";
		((Control)ComboSorting).Size = new Size(143, 21);
		((Control)ComboSorting).TabIndex = 6;
		((ButtonBase)ButtonSetAsLeader).BackColor = Color.Transparent;
		((Button)ButtonSetAsLeader).DialogResult = (DialogResult)0;
		((Control)ButtonSetAsLeader).ForeColor = SystemColors.Control;
		((Control)ButtonSetAsLeader).Location = new Point(410, 16);
		((Control)ButtonSetAsLeader).Name = "ButtonSetAsLeader";
		ButtonSetAsLeader.RoundRadius = 0;
		((Control)ButtonSetAsLeader).Size = new Size(78, 22);
		((Control)ButtonSetAsLeader).TabIndex = 8;
		ButtonSetAsLeader.Text = "Set as Leader";
		((Control)DarkGroupBox4).Anchor = (AnchorStyles)9;
		((Control)DarkGroupBox4).Controls.Add((Control)(object)TSB_SetStationFixed);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)TSB_SetStationRelative);
		((Control)DarkGroupBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox4).Location = new Point(494, 0);
		((Control)DarkGroupBox4).Name = "DarkGroupBox4";
		((Control)DarkGroupBox4).Size = new Size(152, 42);
		((Control)DarkGroupBox4).TabIndex = 19;
		((GroupBox)DarkGroupBox4).TabStop = false;
		((GroupBox)DarkGroupBox4).Text = "Station Bearing";
		((ButtonBase)TSB_SetStationFixed).BackColor = Color.Transparent;
		((Button)TSB_SetStationFixed).DialogResult = (DialogResult)0;
		((Control)TSB_SetStationFixed).ForeColor = SystemColors.Control;
		((Control)TSB_SetStationFixed).Location = new Point(87, 16);
		((Control)TSB_SetStationFixed).Name = "TSB_SetStationFixed";
		TSB_SetStationFixed.RoundRadius = 0;
		((Control)TSB_SetStationFixed).Size = new Size(56, 22);
		((Control)TSB_SetStationFixed).TabIndex = 7;
		TSB_SetStationFixed.Text = "Fixed";
		((ButtonBase)TSB_SetStationRelative).BackColor = Color.Transparent;
		((Button)TSB_SetStationRelative).DialogResult = (DialogResult)0;
		((Control)TSB_SetStationRelative).ForeColor = SystemColors.Control;
		((Control)TSB_SetStationRelative).Location = new Point(6, 16);
		((Control)TSB_SetStationRelative).Name = "TSB_SetStationRelative";
		TSB_SetStationRelative.RoundRadius = 0;
		((Control)TSB_SetStationRelative).Size = new Size(75, 22);
		((Control)TSB_SetStationRelative).TabIndex = 6;
		TSB_SetStationRelative.Text = "Relative";
		((Control)DarkGroupBox5).Anchor = (AnchorStyles)9;
		((Control)DarkGroupBox5).Controls.Add((Control)(object)ButtonDisband);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)ButtonRenameGroup);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)CBSprintDrift);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)CB_MembersInheritIcon);
		((Control)DarkGroupBox5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox5).Location = new Point(424, 36);
		((Control)DarkGroupBox5).Name = "DarkGroupBox5";
		((Control)DarkGroupBox5).Size = new Size(236, 134);
		((Control)DarkGroupBox5).TabIndex = 17;
		((GroupBox)DarkGroupBox5).TabStop = false;
		((GroupBox)DarkGroupBox5).Text = "Misc";
		((ButtonBase)ButtonRenameGroup).BackColor = Color.Transparent;
		((Button)ButtonRenameGroup).DialogResult = (DialogResult)0;
		((Control)ButtonRenameGroup).ForeColor = SystemColors.Control;
		((Control)ButtonRenameGroup).Location = new Point(12, 22);
		((Control)ButtonRenameGroup).Name = "ButtonRenameGroup";
		ButtonRenameGroup.RoundRadius = 0;
		((Control)ButtonRenameGroup).Size = new Size(101, 25);
		((Control)ButtonRenameGroup).TabIndex = 20;
		ButtonRenameGroup.Text = "Rename group";
		((ButtonBase)CBSprintDrift).BackColor = Color.Transparent;
		((CheckBox)CBSprintDrift).Checked = false;
		((Control)CBSprintDrift).Cursor = Cursors.Hand;
		((Control)CBSprintDrift).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CBSprintDrift).Location = new Point(12, 98);
		((Control)CBSprintDrift).Name = "CBSprintDrift";
		((Control)CBSprintDrift).Size = new Size(186, 18);
		((Control)CBSprintDrift).TabIndex = 16;
		((ButtonBase)CBSprintDrift).Text = "Sprint and drift";
		((ButtonBase)CB_MembersInheritIcon).BackColor = Color.Transparent;
		((CheckBox)CB_MembersInheritIcon).Checked = false;
		((Control)CB_MembersInheritIcon).Cursor = Cursors.Hand;
		((Control)CB_MembersInheritIcon).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_MembersInheritIcon).Location = new Point(12, 61);
		((Control)CB_MembersInheritIcon).Name = "CB_MembersInheritIcon";
		((Control)CB_MembersInheritIcon).Size = new Size(186, 18);
		((Control)CB_MembersInheritIcon).TabIndex = 15;
		((ButtonBase)CB_MembersInheritIcon).Text = "Members use leader's icon";
		LabelGroupName.AutoSize = true;
		((Control)LabelGroupName).Font = new Font("Segoe UI", 14f);
		((Control)LabelGroupName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelGroupName).Location = new Point(9, 6);
		((Control)LabelGroupName).Name = "LabelGroupName";
		((Control)LabelGroupName).Size = new Size(117, 25);
		((Control)LabelGroupName).TabIndex = 18;
		((Label)LabelGroupName).Text = "Group name";
		((Control)ButtonParentGroup).Anchor = (AnchorStyles)9;
		((ButtonBase)ButtonParentGroup).BackColor = Color.Transparent;
		((Button)ButtonParentGroup).DialogResult = (DialogResult)0;
		((Control)ButtonParentGroup).ForeColor = SystemColors.Control;
		((Control)ButtonParentGroup).Location = new Point(508, 8);
		((Control)ButtonParentGroup).Name = "ButtonParentGroup";
		ButtonParentGroup.RoundRadius = 0;
		((Control)ButtonParentGroup).Size = new Size(152, 25);
		((Control)ButtonParentGroup).TabIndex = 20;
		ButtonParentGroup.Text = "Parent group";
		((ButtonBase)ButtonDisband).BackColor = Color.Transparent;
		((Button)ButtonDisband).DialogResult = (DialogResult)0;
		((Control)ButtonDisband).ForeColor = SystemColors.Control;
		((Control)ButtonDisband).Location = new Point(126, 22);
		((Control)ButtonDisband).Name = "ButtonDisband";
		ButtonDisband.RoundRadius = 0;
		((Control)ButtonDisband).Size = new Size(101, 25);
		((Control)ButtonDisband).TabIndex = 21;
		ButtonDisband.Text = "Disband group";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(672, 500);
		((Control)this).Controls.Add((Control)(object)ButtonParentGroup);
		((Control)this).Controls.Add((Control)(object)LabelGroupName);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox5);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)this).Controls.Add((Control)(object)GB_Formation);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(688, 539);
		((Control)this).Name = "FormationEditor";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Formation Editor";
		((Control)CMenu_Unit).ResumeLayout(false);
		((Control)GB_Formation).ResumeLayout(false);
		((Control)GB_Formation).PerformLayout();
		((ISupportInitialize)NumUpDownBearing).EndInit();
		((ISupportInitialize)NumUD_Spacing).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox2).PerformLayout();
		((Control)DarkGroupBox4).ResumeLayout(false);
		((Control)DarkGroupBox5).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[SpecialName]
	private CompositionTypeCombo method_2()
	{
		return compositionTypeCombo_0;
	}

	[SpecialName]
	private void method_3(CompositionTypeCombo compositionTypeCombo_1)
	{
		compositionTypeCombo_0 = compositionTypeCombo_1;
		RefreshTVUnits();
	}

	[SpecialName]
	private string method_4()
	{
		return ButtonSpacingUnit.Text;
	}

	[SpecialName]
	private void method_5(string string_0)
	{
		ButtonSpacingUnit.Text = string_0;
	}

	public void RefreshForm()
	{
		DarkTreeNode darkTreeNode = null;
		int mustRefreshMainForm;
		if (SelectedGroup != null)
		{
			foreach (ActiveUnit value in SelectedGroup.Units.Values)
			{
				darkTreeNode = null;
				foreach (DarkTreeNode node in TV_Units.Nodes)
				{
					if (node.Tag == value)
					{
						darkTreeNode = node;
						break;
					}
				}
				if (darkTreeNode != null)
				{
					darkTreeNode.Text = method_7(value);
				}
				else
				{
					method_6(value);
				}
			}
			foreach (DarkTreeNode node2 in TV_Units.Nodes)
			{
				if (node2.Tag == null)
				{
					continue;
				}
				darkTreeNode = null;
				foreach (ActiveUnit value2 in SelectedGroup.Units.Values)
				{
					if (node2.Tag == value2)
					{
						darkTreeNode = node2;
						break;
					}
				}
				if (darkTreeNode == null)
				{
					TV_Units.Nodes.Remove(node2);
				}
			}
			if (int_3 > 10)
			{
				if (!string.IsNullOrEmpty(SelectedGroup.LastFormationSet))
				{
					int num = ((ComboBox)combo_Formations).FindString(SelectedGroup.LastFormationSet);
					if (num < 0)
					{
						goto IL_0230;
					}
					((ComboBox)combo_Formations).SelectedIndex = num;
					NumUD_Spacing.Value = new decimal(SelectedGroup.LastFormationSpacing);
					switch (SelectedGroup.LastFormationSpacingUnits)
					{
					default:
						mustRefreshMainForm = 1;
						break;
					case 1:
						method_5("nm");
						mustRefreshMainForm = 1;
						break;
					case 0:
						method_5("m");
						mustRefreshMainForm = 1;
						break;
					}
				}
				else
				{
					if (((ComboBox)combo_Formations).Items.Count <= 0)
					{
						goto IL_0230;
					}
					((ComboBox)combo_Formations).SelectedIndex = 0;
					NumUD_Spacing.Value = 1m;
					method_5("nm");
					mustRefreshMainForm = 1;
				}
				goto IL_0231;
			}
		}
		goto IL_0230;
		IL_0230:
		mustRefreshMainForm = 1;
		goto IL_0231;
		IL_0231:
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void method_6(ActiveUnit activeUnit_0)
	{
		DarkTreeNode darkTreeNode = new DarkTreeNode(method_7(activeUnit_0));
		TV_Units.Nodes.Add(darkTreeNode);
		darkTreeNode.Tag = activeUnit_0;
	}

	private string method_7(ActiveUnit activeUnit_0)
	{
		string text = activeUnit_0.Name;
		if (activeUnit_0.IsGroupLead())
		{
			text = "[LEAD] " + text;
		}
		string text2;
		if (!activeUnit_0.IsAircraft)
		{
			text2 = "";
		}
		else
		{
			Aircraft aircraft = (Aircraft)activeUnit_0;
			text2 = ((!Information.IsNothing((object)aircraft.Loadout)) ? (" (" + aircraft.Loadout.Name + ")") : "");
		}
		string text3 = ((!string.IsNullOrEmpty(activeUnit_0.UnitClass)) ? (" (" + Misc.RemoveHiddenString(activeUnit_0.UnitClass) + ")") : "");
		return text + text3 + text2;
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			SelectedGroup = null;
			SelectedPatrol = null;
			TV_Units.Nodes.Clear();
			((ToolStripDropDownItem)AssignToPatrol_TSMI).DropDownItems.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void LoadStandardFormations()
	{
		list_0 = new List<StandardFormation>();
		string text = Path.Combine(GameGeneral.ResourcesFolderPath, "Formation\\StandardFormations.txt");
		List<string> list = new List<string>();
		if (!FileExistsNative.FileExistsFast(text))
		{
			return;
		}
		try
		{
			FileStream stream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			StreamReader streamReader = new StreamReader(stream);
			while (!streamReader.EndOfStream)
			{
				list.Add(streamReader.ReadLine());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error loading group formation data", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
			return;
		}
		if (list.Count <= 1 || !int.TryParse(list[0], out var result))
		{
			return;
		}
		int num = result;
		for (int i = 1; i <= num; i++)
		{
			StandardFormation standardFormation = new StandardFormation();
			if (standardFormation.LoadText(list[i]))
			{
				list_0.Add(standardFormation);
			}
		}
	}

	public void RefreshTVUnits()
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		Dictionary<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>> dictionary = SelectedGroup.FetchUnitsByCompositionDenominator((Group.E_CompositionType)method_2());
		_ = dictionary.Count;
		TV_Units.Nodes.Clear();
		foreach (KeyValuePair<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>> item in dictionary)
		{
			if (item.Value.Count == 0)
			{
				continue;
			}
			string text4 = "error";
			ActiveUnit activeUnit = item.Value.ElementAt(0);
			switch (method_2())
			{
			case CompositionTypeCombo.Different_Loadouts:
				text4 = activeUnit.UnitClass + " (" + activeUnit.UnitType.ToString() + ")";
				if (activeUnit.IsAircraft)
				{
					text4 = text4 + " " + ((Aircraft)activeUnit).LoadoutName;
				}
				break;
			case CompositionTypeCombo.Different_Classes:
				text4 = activeUnit.UnitClass + " (" + activeUnit.UnitType.ToString() + ")";
				break;
			case CompositionTypeCombo.Different_Types:
				text4 = activeUnit.UnitType.ToString();
				break;
			case CompositionTypeCombo.None:
				text4 = "Mixed units";
				break;
			}
			DarkTreeNode darkTreeNode = new DarkTreeNode(text4);
			TV_Units.Nodes.Add(darkTreeNode);
			foreach (ActiveUnit item2 in item.Value)
			{
				string text5 = item2.Name;
				if (item2.IsGroupLead())
				{
					text5 = "[LEAD] " + text5;
				}
				if (!item2.IsAircraft)
				{
					text2 = "";
				}
				else
				{
					Aircraft aircraft = (Aircraft)item2;
					text2 = ((!Information.IsNothing((object)aircraft.Loadout)) ? (" (" + aircraft.Loadout.Name + ")") : "");
				}
				text = (string.IsNullOrEmpty(item2.UnitClass) ? "" : (" (" + Misc.RemoveHiddenString(item2.UnitClass) + ")"));
				text3 = ((!item2.IsGroup) ? "" : (" (" + ((Group)item2).TypeDescription + ")"));
				DarkTreeNode darkTreeNode2 = new DarkTreeNode(text5 + text + text2 + text3);
				darkTreeNode2.ForeColor = Color.FromArgb(255, 170, 170, 170);
				darkTreeNode.Nodes.Add(darkTreeNode2);
				darkTreeNode2.Tag = item2;
			}
		}
		Module1.ExpandAll(TV_Units);
	}

	public void RefreshName()
	{
		((Form)this).Text = "Formation Editor - " + SelectedGroup.Name;
		((Label)LabelGroupName).Text = SelectedGroup.Name + " (" + SelectedGroup.TypeDescription + ")";
	}

	public void InitStandardFormationsUI()
	{
		if (list_0 == null || list_0.Count == 0)
		{
			LoadStandardFormations();
		}
		ButtonSpacingUnit.Text = "nm";
		((ComboBox)combo_Formations).Items.Clear();
		foreach (StandardFormation item in list_0)
		{
			((ComboBox)combo_Formations).Items.Add((object)item.Name);
		}
		int_0 = 0;
	}

	public void BuildForm()
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		RefreshName();
		((Control)this).SuspendLayout();
		InitStandardFormationsUI();
		if (((ActiveUnit)SelectedGroup).get_ParentGroup(UsingMissionPlanner: false) == null)
		{
			((Control)ButtonParentGroup).Visible = false;
		}
		else
		{
			((Control)ButtonParentGroup).Visible = true;
			ButtonParentGroup.Text = "Parent :" + ((ActiveUnit)SelectedGroup).get_ParentGroup(UsingMissionPlanner: false).Name;
		}
		((ComboBox)ComboSorting).Items.Clear();
		foreach (object value in Enum.GetValues(typeof(CompositionTypeCombo)))
		{
			CompositionTypeCombo compositionTypeCombo = (CompositionTypeCombo)Conversions.ToInteger(value);
			((ComboBox)ComboSorting).Items.Add((object)compositionTypeCombo.ToString().Replace("_", " "));
		}
		((ComboBox)ComboSorting).SelectedIndex = 3;
		if (list_0.Count == 0)
		{
			DarkMessageBox.ShowError("No standard formation found ! The file " + Path.Combine(GameGeneral.ResourcesFolderPath, "Formation\\StandardFormations.txt") + " does not exist or is unreadable. Closing . . .", "Error");
			((Form)this).Close();
			return;
		}
		((ComboBox)combo_Formations).SelectedIndex = int_0;
		NumUD_Spacing.Value = new decimal(Math.Max(1, int_1));
		NumUpDownBearing.Value = new decimal((int)Math.Round(SelectedGroup.DesiredHeading));
		button_SetFormation.Enabled = true;
		button_SetImmediate.Enabled = button_SetFormation.Enabled;
		((Control)button_SetImmediate).Visible = Client.AllowEditModeActions;
		((CheckBox)CB_MembersInheritIcon).Checked = SelectedGroup.MembersInheritIcon;
		if (((ComboBox)combo_Formations).SelectedItem != null)
		{
			((GroupBox)GB_Formation).Text = "Formation (" + ((ComboBox)combo_Formations).SelectedItem.ToString() + ")";
		}
		RefreshTVUnits();
		if (string.IsNullOrEmpty(SelectedGroup.LastFormationSet))
		{
			if (((ComboBox)combo_Formations).Items.Count > 0)
			{
				((ComboBox)combo_Formations).SelectedIndex = 0;
				NumUD_Spacing.Value = 1m;
				method_5("nm");
			}
		}
		else
		{
			int num = ((ComboBox)combo_Formations).FindString(SelectedGroup.LastFormationSet);
			if (num >= 0)
			{
				((ComboBox)combo_Formations).SelectedIndex = num;
				NumUD_Spacing.Value = new decimal(SelectedGroup.LastFormationSpacing);
			}
		}
		((Control)this).ResumeLayout();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		foreach (Keys val in array)
		{
			if (keyData == val)
			{
				int result;
				if (!((Control)this).Visible)
				{
					((Form)this).Activate();
					result = 1;
				}
				else
				{
					((Form)this).Close();
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	private void FormationEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		Timer1.Stop();
		Client.CurrentMapProfile.ViewMode = mapViewMode_0;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void FormationEditor_Load(object sender, EventArgs e)
	{
		if (Client.Realtime)
		{
			bool_3 = true;
		}
		mapViewMode_0 = Client.CurrentMapProfile.ViewMode;
		Client.CurrentMapProfile.ViewMode = MapProfile.MapViewMode.UnitView;
		Client.SelectedUnitChanged += method_8;
		Group.UnitAdded += method_9;
		Group.UnitRemoved += method_10;
		LoadStandardFormations();
		BuildForm();
		Timer1.Start();
	}

	private void method_8(Module_Unit.Unit unit_0)
	{
		int_3 = int.MaxValue;
		using IEnumerator<DarkTreeNode> enumerator = Module1.AllNodes(TV_Units).GetEnumerator();
		DarkTreeNode current;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				if (current.Tag == null)
				{
					((Control)CBSprintDrift).Visible = false;
					TSB_SetStationFixed.Enabled = false;
					TSB_SetStationRelative.Enabled = false;
					ButtonRemove.Enabled = false;
				}
				else if (current.Tag == unit_0)
				{
					break;
				}
				continue;
			}
			return;
		}
		TV_Units.SelectNode(current);
		ButtonRemove.Enabled = true;
		if (!((ActiveUnit)unit_0).IsGroupLead())
		{
			((Control)CBSprintDrift).Visible = unit_0.IsBoat;
			TSB_SetStationFixed.Enabled = true;
			TSB_SetStationRelative.Enabled = true;
		}
		else
		{
			((Control)CBSprintDrift).Visible = false;
			TSB_SetStationFixed.Enabled = false;
			TSB_SetStationRelative.Enabled = false;
		}
		((CheckBox)CBSprintDrift).Checked = ((ActiveUnit)unit_0).Navigator.SprintDrift;
		if (((Control)this).Visible)
		{
			((Control)this).Focus();
		}
	}

	private void method_9(Group group_0, ActiveUnit activeUnit_0)
	{
		if (group_0 == SelectedGroup)
		{
			BuildForm();
		}
	}

	private void method_10(Group group_0, ActiveUnit activeUnit_0)
	{
		if (group_0 == SelectedGroup)
		{
			BuildForm();
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count == 0 || TV_Units.SelectedNodes[0].Tag == null)
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
		if (!(objectValue is ActiveUnit))
		{
			return;
		}
		ActiveUnit activeUnit = (ActiveUnit)objectValue;
		if (!activeUnit.IsGroupLead())
		{
			if (!bool_3)
			{
				activeUnit.Navigator.SprintDrift = ((CheckBox)CBSprintDrift).Checked;
			}
			else
			{
				Client.RealtimeTerminal.SendFormationSprintDrift(activeUnit, ((CheckBox)CBSprintDrift).Checked);
			}
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag)))
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
		if (objectValue is ActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)objectValue;
			if (bool_3)
			{
				Client.RealtimeTerminal.SendFormationSetLead(activeUnit);
			}
			else
			{
				SelectedGroup.SetGroupLead(activeUnit);
			}
			BuildForm();
			Client.MustRefreshMainForm = true;
		}
	}

	private bool method_13(TreeNode treeNode_0, TreeNode treeNode_1)
	{
		if (treeNode_1.Parent == null)
		{
			return false;
		}
		if (!((object)treeNode_1.Parent).Equals((object?)treeNode_0))
		{
			return method_13(treeNode_0, treeNode_1.Parent);
		}
		return true;
	}

	private void method_14(ActiveUnit activeUnit_0)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		if (Information.IsNothing((object)activeUnit_0.ActiveMissionOrPackage()))
		{
			((ToolStripMenuItem)RemoveFromPatrol_TSMI).Enabled = false;
		}
		else
		{
			((ToolStripMenuItem)RemoveFromPatrol_TSMI).Enabled = activeUnit_0.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol;
		}
		((ToolStripDropDownItem)AssignToPatrol_TSMI).DropDownItems.Clear();
		foreach (Patrol patrol in SelectedGroup.Patrols)
		{
			ToolStripMenuItem val = new ToolStripMenuItem(patrol.Name);
			((ToolStripItem)val).Tag = patrol;
			((ToolStripItem)val).MouseDown += new MouseEventHandler(method_15);
			((ToolStripDropDownItem)AssignToPatrol_TSMI).DropDownItems.Add((ToolStripItem)(object)val);
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		ToolStripMenuItem val = (ToolStripMenuItem)((sender is ToolStripMenuItem) ? sender : null);
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(((ToolStripItem)val).Tag)) || !(((ToolStripItem)val).Tag is Patrol))
		{
			return;
		}
		using List<Patrol>.Enumerator enumerator = SelectedGroup.Patrols.GetEnumerator();
		Patrol current;
		do
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				continue;
			}
			return;
		}
		while (Operators.CompareString(current.Name, ((ToolStripItem)val).Text, true) != 0);
		ActiveUnit obj = (ActiveUnit)Client.SelectedUnit;
		Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
		obj.Set_AssignedMissionOrPackage(current, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
		BuildForm();
	}

	private void method_16(object sender, MouseEventArgs e)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		if (TV_Units.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_Units.SelectedNodes[0];
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(darkTreeNode.Tag)))
		{
			if (darkTreeNode.Nodes.Count > 1)
			{
				ButtonNewGroup.Enabled = true;
			}
			return;
		}
		if (darkTreeNode.Tag is ActiveUnit)
		{
			Client.SelectThisUnit((Module_Unit.Unit)darkTreeNode.Tag, ThisUnitOnly: true);
			if ((int)e.Button == 2097152)
			{
				method_14((ActiveUnit)darkTreeNode.Tag);
				((ToolStripDropDown)CMenu_Unit).Show((Control)(object)TV_Units, e.X, e.Y);
			}
		}
		ButtonNewGroup.Enabled = false;
	}

	private void method_17(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)e.Button == 1048576)
		{
			DarkTreeNode darkTreeNode = TV_Units.SelectedNodes[0];
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(darkTreeNode.Tag)) && darkTreeNode.Tag is ActiveUnit && ((ActiveUnit)darkTreeNode.Tag).IsGroup)
			{
				SelectedGroup = (Group)darkTreeNode.Tag;
				BuildForm();
			}
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count != 0 && !Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag)))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
			if (objectValue is ActiveUnit && !((ActiveUnit)objectValue).IsGroupLead())
			{
				Client.SelectedBearingType = ReferencePoint.OrientationType.Rotating;
				Client.CurrentUserAction = Client.UserAction.AddingFormationStation;
			}
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count != 0 && !Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag)))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
			if (objectValue is ActiveUnit && !((ActiveUnit)objectValue).IsGroupLead())
			{
				Client.SelectedBearingType = ReferencePoint.OrientationType.Fixed;
				Client.CurrentUserAction = Client.UserAction.AddingFormationStation;
			}
		}
	}

	private void FormationEditor_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		if ((int)e.KeyCode == 115 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
	}

	private void qAuSkpoOyCg(object sender, FormClosedEventArgs e)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		((Control)CBSprintDrift).Click -= method_11;
		Client.SelectedUnitChanged -= method_8;
		Group.UnitAdded -= method_9;
		Group.UnitRemoved -= method_10;
		foreach (ToolStripMenuItem item in (ArrangedElementCollection)((ToolStripDropDownItem)AssignToPatrol_TSMI).DropDownItems)
		{
			((ToolStripItem)item).MouseDown -= new MouseEventHandler(method_15);
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		int_3 = 0;
		if (((Control)this).Visible)
		{
			int_0 = ((ComboBox)combo_Formations).SelectedIndex;
		}
		button_SetFormation.Enabled = true;
		button_SetImmediate.Enabled = button_SetFormation.Enabled;
		((Control)button_SetImmediate).Visible = Client.AllowEditModeActions;
	}

	private void method_21(object sender, EventArgs e)
	{
		if (((Control)this).Visible)
		{
			method_3((CompositionTypeCombo)((ComboBox)ComboSorting).SelectedIndex);
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		int_3 = 0;
		if (((Control)this).Visible)
		{
			int_1 = Convert.ToInt32(NumUD_Spacing.Value);
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		int_3 = 0;
		if (((Control)this).Visible)
		{
			int_1 = Convert.ToInt32(NumUD_Spacing.Value);
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		int_3 = 0;
		if (((Control)this).Visible)
		{
			int_2 = Convert.ToInt32(NumUpDownBearing.Value);
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		int_3 = 0;
		if (((Control)this).Visible)
		{
			int_2 = Convert.ToInt32(NumUpDownBearing.Value);
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		if (SelectedGroup != null && SelectedGroup.GroupLead != null)
		{
			_ = ((ComboBox)combo_Formations).SelectedIndex;
			float baseDistance = Convert.ToSingle(NumUD_Spacing.Value);
			float baseHeading = Convert.ToSingle(NumUpDownBearing.Value);
			string text = ((ComboBox)combo_Formations).SelectedItem.ToString();
			int num = 1;
			if (Operators.CompareString(method_4(), "m", true) == 0)
			{
				num = 0;
			}
			((GroupBox)GB_Formation).Text = "Formation " + text;
			if (!bool_3)
			{
				StandardFormation.SetFormation(SelectedGroup, text, baseHeading, baseDistance, num, teleportToStations: false);
			}
			else
			{
				Client.RealtimeTerminal.SendSetFormation(SelectedGroup, text, baseHeading, baseDistance, num, teleportUnits: false);
			}
			int_3 = int.MaxValue;
		}
	}

	private void method_27(object sender, EventArgs e)
	{
		if (SelectedGroup != null && SelectedGroup.GroupLead != null)
		{
			_ = ((ComboBox)combo_Formations).SelectedIndex;
			float baseDistance = Convert.ToSingle(NumUD_Spacing.Value);
			float baseHeading = Convert.ToSingle(NumUpDownBearing.Value);
			string text = ((ComboBox)combo_Formations).SelectedItem.ToString();
			int num = 1;
			if (Operators.CompareString(method_4(), "m", true) == 0)
			{
				num = 0;
			}
			((GroupBox)GB_Formation).Text = "Formation " + text;
			if (bool_3)
			{
				Client.RealtimeTerminal.SendSetFormation(SelectedGroup, text, baseHeading, baseDistance, num, teleportUnits: true);
			}
			else
			{
				StandardFormation.SetFormation(SelectedGroup, text, baseHeading, baseDistance, num, teleportToStations: true);
			}
			int_3 = int.MaxValue;
			MyProject.Forms.MainForm.AdjustToUserActionChange();
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		try
		{
			int num;
			if (int_3 < int.MaxValue)
			{
				int_3++;
				num = 0;
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			flag = (bool_3 ? (Client.RealtimeTerminal.LastGameSpeed > 0 && int_3 > 10 && !((UpDownBase)NumUpDownBearing).Focused) : (Client.CurrentGame.Status == Game._GameStatus.Running && !((UpDownBase)NumUpDownBearing).Focused));
			if (flag && ((SelectedGroup != null) & (SelectedGroup.GroupLead != null)))
			{
				NumUpDownBearing.Value = new decimal((int)Math.Round(SelectedGroup.GroupLead.DesiredHeading));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9346354850", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
	}

	private void method_29(object sender, EventArgs e)
	{
		SelectedGroup.MembersInheritIcon = ((CheckBox)CB_MembersInheritIcon).Checked;
	}

	private void method_30(object sender, EventArgs e)
	{
		LoadStandardFormations();
		BuildForm();
	}

	private void method_31(object sender, EventArgs e)
	{
		string text = Path.Combine(GameGeneral.ResourcesFolderPath, "Formation\\StandardFormations.txt");
		try
		{
			if (FileExistsNative.FileExistsFast(text))
			{
				Process.Start(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error while accessing StandardFormations.txt", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		int_3 = 0;
		if (Operators.CompareString(method_4(), "m", true) == 0)
		{
			method_5("nm");
		}
		else
		{
			method_5("m");
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count == 0)
		{
			return;
		}
		lock (lockObject_0)
		{
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag)))
			{
				return;
			}
			object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
			if (!(objectValue is ActiveUnit))
			{
				return;
			}
			ActiveUnit activeUnit = (ActiveUnit)objectValue;
			if (SelectedGroup.Units.ContainsKey(activeUnit.ObjectID))
			{
				SelectedGroup.Units.Remove(activeUnit.ObjectID);
				if (bool_3)
				{
					List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
					list.Add(activeUnit);
					Client.RealtimeTerminal.SendActiveUnitMiscActionMessage(list, ActiveUnitMiscAction.Detach);
				}
			}
			BuildForm();
			Client.MustRefreshMainForm = true;
		}
	}

	private void method_34(object sender, EventArgs e)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		if (TV_Units.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_Units.SelectedNodes[0];
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(darkTreeNode.Tag)) && darkTreeNode.Nodes.Count > 1)
		{
			if (bool_3)
			{
				Client.RealtimeTerminal.SendActiveUnitMiscActionMessage(method_35(darkTreeNode), ActiveUnitMiscAction.Group);
				return;
			}
			Scenario theScen = Client.CurrentScenario;
			Side theSide = Client.CurrentSide;
			Group obj = new Group(ref theScen, ref theSide, method_35(darkTreeNode));
			Client.CurrentSide = theSide;
			Group obj2 = obj;
			obj2.Name = darkTreeNode.Text;
			DarkMessageBox.ShowInformation("A new group was created out of this node (" + darkTreeNode.Text + "), it consists of " + obj2.Units.Count + " units.", "New group created");
		}
	}

	private List<ActiveUnit> method_35(DarkTreeNode darkTreeNode_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(node.Tag)) && node.Nodes.Count == 0)
			{
				if (node.Tag is ActiveUnit)
				{
					list.Add((ActiveUnit)node.Tag);
				}
			}
			else if (node.Nodes.Count > 0)
			{
				list.AddRange(method_35(node));
			}
		}
		return list;
	}

	private void method_36(object sender, EventArgs e)
	{
		SelectedGroup.Name = InputDialog.CallDialog("Rename Group");
		if (bool_3)
		{
			Client.RealtimeTerminal.SendUnitRename(SelectedGroup, SelectedGroup.Name);
		}
		BuildForm();
	}

	private void method_37(object sender, EventArgs e)
	{
		if (((ActiveUnit)SelectedGroup).get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			SelectedGroup = ((ActiveUnit)SelectedGroup).get_ParentGroup(UsingMissionPlanner: false);
			BuildForm();
		}
	}

	private void method_38(object sender, EventArgs e)
	{
		if (!bool_3)
		{
			SelectedGroup.Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: true, "Disbanded", null, RegisterAsLosses: false);
		}
		else
		{
			Client.RealtimeTerminal.SendActiveUnitMiscActionMessage(SelectedGroup.Units.Values, ActiveUnitMiscAction.Detach);
		}
		((Form)this).Close();
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TankerPlanner : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_TankerMinimum_Total")]
	private DarkUITextBox _TextBox_TankerMinimum_Total;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_TankerMinimum_Airborne")]
	private DarkUITextBox _TextBox_TankerMinimum_Airborne;

	[AccessedThroughProperty("TextBox_TankerMinimum_Station")]
	[CompilerGenerated]
	private DarkUITextBox _TextBox_TankerMinimum_Station;

	[AccessedThroughProperty("ListBox_Tankers")]
	[CompilerGenerated]
	private DarkListView _ListBox_Tankers;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_MaxReceiversInQueuePerTanker_Airborne")]
	private DarkUITextBox _TextBox_MaxReceiversInQueuePerTanker_Airborne;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_FuelQtyToStartLookingForTanker")]
	private DarkUITextBox _TextBox_FuelQtyToStartLookingForTanker;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_FollowReceiversNumber")]
	private DarkUIComboBox _Combo_FollowReceiversNumber;

	[AccessedThroughProperty("RadioButton_Mission")]
	[CompilerGenerated]
	private DarkRadioButton _RadioButton_Mission;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioButton_Automatic")]
	private DarkRadioButton _RadioButton_Automatic;

	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_50")]
	[CompilerGenerated]
	private DarkRadioButton _RadioButton_TankerMaxDistance_Airborne_50;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_100")]
	private DarkRadioButton _RadioButton_TankerMaxDistance_Airborne_100;

	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_250")]
	[CompilerGenerated]
	private DarkRadioButton _RadioButton_TankerMaxDistance_Airborne_250;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_500")]
	private DarkRadioButton _RadioButton_TankerMaxDistance_Airborne_500;

	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_Tactical")]
	[CompilerGenerated]
	private DarkRadioButton _RadioButton_TankerMaxDistance_Airborne_Tactical;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox_LaunchMissionWithoutTankersInPlace")]
	private DarkCheckBox _CheckBox_LaunchMissionWithoutTankersInPlace;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_FollowReceivers")]
	private DarkCheckBox _CB_FollowReceivers;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox_KeepOnMissionWithoutTankersInPlace")]
	private DarkCheckBox _CheckBox_KeepOnMissionWithoutTankersInPlace;

	[CompilerGenerated]
	private bool bool_2;

	public Mission TheMission;

	public Waypoint TheWaypoint;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	internal virtual DarkUITextBox TextBox_TankerMinimum_Total
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_TankerMinimum_Total;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			EventHandler eventHandler2 = method_7;
			DarkUITextBox darkUITextBox = _TextBox_TankerMinimum_Total;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox_TankerMinimum_Total = value;
			darkUITextBox = _TextBox_TankerMinimum_Total;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2 { get; set; }

	internal virtual DarkUITextBox TextBox_TankerMinimum_Airborne
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_TankerMinimum_Airborne;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			EventHandler eventHandler2 = method_9;
			DarkUITextBox darkUITextBox = _TextBox_TankerMinimum_Airborne;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox_TankerMinimum_Airborne = value;
			darkUITextBox = _TextBox_TankerMinimum_Airborne;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3 { get; set; }

	internal virtual DarkUITextBox TextBox_TankerMinimum_Station
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_TankerMinimum_Station;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			EventHandler eventHandler2 = method_11;
			DarkUITextBox darkUITextBox = _TextBox_TankerMinimum_Station;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox_TankerMinimum_Station = value;
			darkUITextBox = _TextBox_TankerMinimum_Station;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkListView ListBox_Tankers
	{
		[CompilerGenerated]
		get
		{
			return _ListBox_Tankers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkListView darkListView = _ListBox_Tankers;
			if (darkListView != null)
			{
				((Control)darkListView).Click -= eventHandler;
			}
			_ListBox_Tankers = value;
			darkListView = _ListBox_Tankers;
			if (darkListView != null)
			{
				((Control)darkListView).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal virtual Label Label6 { get; set; }

	internal virtual DarkUITextBox TextBox_MaxReceiversInQueuePerTanker_Airborne
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_MaxReceiversInQueuePerTanker_Airborne;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			EventHandler eventHandler2 = method_13;
			DarkUITextBox darkUITextBox = _TextBox_MaxReceiversInQueuePerTanker_Airborne;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox_MaxReceiversInQueuePerTanker_Airborne = value;
			darkUITextBox = _TextBox_MaxReceiversInQueuePerTanker_Airborne;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal virtual Label Label8 { get; set; }

	internal virtual DarkUITextBox TextBox_FuelQtyToStartLookingForTanker
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_FuelQtyToStartLookingForTanker;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			EventHandler eventHandler2 = method_15;
			DarkUITextBox darkUITextBox = _TextBox_FuelQtyToStartLookingForTanker;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox_FuelQtyToStartLookingForTanker = value;
			darkUITextBox = _TextBox_FuelQtyToStartLookingForTanker;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual Label Label7 { get; set; }

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual DarkGroupBox GroupBox3 { get; set; }

	[field: AccessedThroughProperty("GroupBox4")]
	internal virtual DarkGroupBox GroupBox4 { get; set; }

	internal virtual DarkUIComboBox Combo_FollowReceiversNumber
	{
		[CompilerGenerated]
		get
		{
			return _Combo_FollowReceiversNumber;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			DarkUIComboBox darkUIComboBox = _Combo_FollowReceiversNumber;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_FollowReceiversNumber = value;
			darkUIComboBox = _Combo_FollowReceiversNumber;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RadioButton_Mission
	{
		[CompilerGenerated]
		get
		{
			return _RadioButton_Mission;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkRadioButton darkRadioButton = _RadioButton_Mission;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RadioButton_Mission = value;
			darkRadioButton = _RadioButton_Mission;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RadioButton_Automatic
	{
		[CompilerGenerated]
		get
		{
			return _RadioButton_Automatic;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkRadioButton darkRadioButton = _RadioButton_Automatic;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RadioButton_Automatic = value;
			darkRadioButton = _RadioButton_Automatic;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RadioButton_TankerMaxDistance_Airborne_50
	{
		[CompilerGenerated]
		get
		{
			return _RadioButton_TankerMaxDistance_Airborne_50;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkRadioButton darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_50;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RadioButton_TankerMaxDistance_Airborne_50 = value;
			darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_50;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RadioButton_TankerMaxDistance_Airborne_100
	{
		[CompilerGenerated]
		get
		{
			return _RadioButton_TankerMaxDistance_Airborne_100;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkRadioButton darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_100;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RadioButton_TankerMaxDistance_Airborne_100 = value;
			darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_100;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RadioButton_TankerMaxDistance_Airborne_250
	{
		[CompilerGenerated]
		get
		{
			return _RadioButton_TankerMaxDistance_Airborne_250;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkRadioButton darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_250;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RadioButton_TankerMaxDistance_Airborne_250 = value;
			darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_250;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RadioButton_TankerMaxDistance_Airborne_500
	{
		[CompilerGenerated]
		get
		{
			return _RadioButton_TankerMaxDistance_Airborne_500;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkRadioButton darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_500;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RadioButton_TankerMaxDistance_Airborne_500 = value;
			darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_500;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RadioButton_TankerMaxDistance_Airborne_Tactical
	{
		[CompilerGenerated]
		get
		{
			return _RadioButton_TankerMaxDistance_Airborne_Tactical;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkRadioButton darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_Tactical;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RadioButton_TankerMaxDistance_Airborne_Tactical = value;
			darkRadioButton = _RadioButton_TankerMaxDistance_Airborne_Tactical;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CheckBox_LaunchMissionWithoutTankersInPlace
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox_LaunchMissionWithoutTankersInPlace;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkCheckBox darkCheckBox = _CheckBox_LaunchMissionWithoutTankersInPlace;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CheckBox_LaunchMissionWithoutTankersInPlace = value;
			darkCheckBox = _CheckBox_LaunchMissionWithoutTankersInPlace;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_FollowReceivers
	{
		[CompilerGenerated]
		get
		{
			return _CB_FollowReceivers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkCheckBox darkCheckBox = _CB_FollowReceivers;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_FollowReceivers = value;
			darkCheckBox = _CB_FollowReceivers;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CheckBox_KeepOnMissionWithoutTankersInPlace
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox_KeepOnMissionWithoutTankersInPlace;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkCheckBox darkCheckBox = _CheckBox_KeepOnMissionWithoutTankersInPlace;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CheckBox_KeepOnMissionWithoutTankersInPlace = value;
			darkCheckBox = _CheckBox_KeepOnMissionWithoutTankersInPlace;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
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

	public TankerPlanner()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Control)this).VisibleChanged += TankerPlanner_VisibleChanged;
		((Form)this).FormClosing += new FormClosingEventHandler(TankerPlanner_FormClosing);
		((Control)this).KeyDown += new KeyEventHandler(TankerPlanner_KeyDown);
		((Form)this).Load += TankerPlanner_Load;
		RTMPEnabled = true;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
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
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Expected O, but got Unknown
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Expected O, but got Unknown
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Expected O, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_0934: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Expected O, but got Unknown
		//IL_0ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acd: Expected O, but got Unknown
		//IL_0cb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc0: Expected O, but got Unknown
		//IL_1135: Unknown result type (might be due to invalid IL or missing references)
		//IL_113f: Expected O, but got Unknown
		//IL_1233: Unknown result type (might be due to invalid IL or missing references)
		//IL_123d: Expected O, but got Unknown
		RadioButton_Mission = new DarkRadioButton();
		RadioButton_Automatic = new DarkRadioButton();
		GroupBox1 = new DarkGroupBox();
		RadioButton_TankerMaxDistance_Airborne_50 = new DarkRadioButton();
		RadioButton_TankerMaxDistance_Airborne_100 = new DarkRadioButton();
		RadioButton_TankerMaxDistance_Airborne_250 = new DarkRadioButton();
		RadioButton_TankerMaxDistance_Airborne_500 = new DarkRadioButton();
		RadioButton_TankerMaxDistance_Airborne_Tactical = new DarkRadioButton();
		TextBox_TankerMinimum_Total = new DarkUITextBox();
		Label1 = new Label();
		Label2 = new Label();
		TextBox_TankerMinimum_Airborne = new DarkUITextBox();
		Label3 = new Label();
		TextBox_TankerMinimum_Station = new DarkUITextBox();
		ListBox_Tankers = new DarkListView();
		Label6 = new Label();
		TextBox_MaxReceiversInQueuePerTanker_Airborne = new DarkUITextBox();
		CheckBox_LaunchMissionWithoutTankersInPlace = new DarkCheckBox();
		GroupBox3 = new DarkGroupBox();
		CheckBox_KeepOnMissionWithoutTankersInPlace = new DarkCheckBox();
		GroupBox4 = new DarkGroupBox();
		Combo_FollowReceiversNumber = new DarkUIComboBox();
		Label8 = new Label();
		TextBox_FuelQtyToStartLookingForTanker = new DarkUITextBox();
		CB_FollowReceivers = new DarkCheckBox();
		Label7 = new Label();
		((Control)GroupBox1).SuspendLayout();
		((Control)GroupBox3).SuspendLayout();
		((Control)GroupBox4).SuspendLayout();
		((Control)this).SuspendLayout();
		((ButtonBase)RadioButton_Mission).BackColor = Color.Transparent;
		((Control)RadioButton_Mission).Cursor = Cursors.Hand;
		((Control)RadioButton_Mission).Font = new Font("Segoe UI", 9f);
		((Control)RadioButton_Mission).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RadioButton_Mission).Location = new Point(12, 29);
		((Control)RadioButton_Mission).Name = "RadioButton_Mission";
		((Control)RadioButton_Mission).Size = new Size(382, 21);
		((Control)RadioButton_Mission).TabIndex = 0;
		((ButtonBase)RadioButton_Mission).Text = "Use tankers assigned to specific missions";
		((ButtonBase)RadioButton_Automatic).BackColor = Color.Transparent;
		((Control)RadioButton_Automatic).Cursor = Cursors.Hand;
		((Control)RadioButton_Automatic).Font = new Font("Segoe UI", 9f);
		((Control)RadioButton_Automatic).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RadioButton_Automatic).Location = new Point(12, 12);
		((Control)RadioButton_Automatic).Name = "RadioButton_Automatic";
		((Control)RadioButton_Automatic).Size = new Size(382, 21);
		((Control)RadioButton_Automatic).TabIndex = 3;
		((ButtonBase)RadioButton_Automatic).Text = "Use nearest tanker with enough fuel to serve receivers";
		((Control)GroupBox1).Anchor = (AnchorStyles)13;
		((Control)GroupBox1).Controls.Add((Control)(object)RadioButton_TankerMaxDistance_Airborne_50);
		((Control)GroupBox1).Controls.Add((Control)(object)RadioButton_TankerMaxDistance_Airborne_100);
		((Control)GroupBox1).Controls.Add((Control)(object)RadioButton_TankerMaxDistance_Airborne_250);
		((Control)GroupBox1).Controls.Add((Control)(object)RadioButton_TankerMaxDistance_Airborne_500);
		((Control)GroupBox1).Controls.Add((Control)(object)RadioButton_TankerMaxDistance_Airborne_Tactical);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(400, 237);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(423, 112);
		((Control)GroupBox1).TabIndex = 4;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Airborne receivers can book tankers within...";
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_50).BackColor = Color.Transparent;
		((Control)RadioButton_TankerMaxDistance_Airborne_50).Cursor = Cursors.Hand;
		((Control)RadioButton_TankerMaxDistance_Airborne_50).Font = new Font("Segoe UI", 9f);
		((Control)RadioButton_TankerMaxDistance_Airborne_50).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RadioButton_TankerMaxDistance_Airborne_50).Location = new Point(6, 85);
		((Control)RadioButton_TankerMaxDistance_Airborne_50).Name = "RadioButton_TankerMaxDistance_Airborne_50";
		((Control)RadioButton_TankerMaxDistance_Airborne_50).Size = new Size(54, 21);
		((Control)RadioButton_TankerMaxDistance_Airborne_50).TabIndex = 4;
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_50).Text = "50 nm";
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_100).BackColor = Color.Transparent;
		((Control)RadioButton_TankerMaxDistance_Airborne_100).Cursor = Cursors.Hand;
		((Control)RadioButton_TankerMaxDistance_Airborne_100).Font = new Font("Segoe UI", 9f);
		((Control)RadioButton_TankerMaxDistance_Airborne_100).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RadioButton_TankerMaxDistance_Airborne_100).Location = new Point(6, 68);
		((Control)RadioButton_TankerMaxDistance_Airborne_100).Name = "RadioButton_TankerMaxDistance_Airborne_100";
		((Control)RadioButton_TankerMaxDistance_Airborne_100).Size = new Size(60, 21);
		((Control)RadioButton_TankerMaxDistance_Airborne_100).TabIndex = 3;
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_100).Text = "100 nm";
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_250).BackColor = Color.Transparent;
		((Control)RadioButton_TankerMaxDistance_Airborne_250).Cursor = Cursors.Hand;
		((Control)RadioButton_TankerMaxDistance_Airborne_250).Font = new Font("Segoe UI", 9f);
		((Control)RadioButton_TankerMaxDistance_Airborne_250).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RadioButton_TankerMaxDistance_Airborne_250).Location = new Point(6, 51);
		((Control)RadioButton_TankerMaxDistance_Airborne_250).Name = "RadioButton_TankerMaxDistance_Airborne_250";
		((Control)RadioButton_TankerMaxDistance_Airborne_250).Size = new Size(60, 21);
		((Control)RadioButton_TankerMaxDistance_Airborne_250).TabIndex = 2;
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_250).Text = "250 nm";
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_500).BackColor = Color.Transparent;
		((Control)RadioButton_TankerMaxDistance_Airborne_500).Cursor = Cursors.Hand;
		((Control)RadioButton_TankerMaxDistance_Airborne_500).Font = new Font("Segoe UI", 9f);
		((Control)RadioButton_TankerMaxDistance_Airborne_500).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RadioButton_TankerMaxDistance_Airborne_500).Location = new Point(6, 34);
		((Control)RadioButton_TankerMaxDistance_Airborne_500).Name = "RadioButton_TankerMaxDistance_Airborne_500";
		((Control)RadioButton_TankerMaxDistance_Airborne_500).Size = new Size(60, 21);
		((Control)RadioButton_TankerMaxDistance_Airborne_500).TabIndex = 1;
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_500).Text = "500 nm";
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_Tactical).BackColor = Color.Transparent;
		((Control)RadioButton_TankerMaxDistance_Airborne_Tactical).Cursor = Cursors.Hand;
		((Control)RadioButton_TankerMaxDistance_Airborne_Tactical).Font = new Font("Segoe UI", 9f);
		((Control)RadioButton_TankerMaxDistance_Airborne_Tactical).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RadioButton_TankerMaxDistance_Airborne_Tactical).Location = new Point(6, 17);
		((Control)RadioButton_TankerMaxDistance_Airborne_Tactical).Name = "RadioButton_TankerMaxDistance_Airborne_Tactical";
		((Control)RadioButton_TankerMaxDistance_Airborne_Tactical).Size = new Size(381, 21);
		((Control)RadioButton_TankerMaxDistance_Airborne_Tactical).TabIndex = 0;
		((ButtonBase)RadioButton_TankerMaxDistance_Airborne_Tactical).Text = "Receiver's tactical range with current fuel load and flight profile";
		TextBox_TankerMinimum_Total.AutoCompleteCustomSource = null;
		TextBox_TankerMinimum_Total.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_TankerMinimum_Total.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_TankerMinimum_Total).BackColor = Color.Transparent;
		TextBox_TankerMinimum_Total.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_TankerMinimum_Total).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_TankerMinimum_Total.Image = null;
		TextBox_TankerMinimum_Total.Lines = null;
		((Control)TextBox_TankerMinimum_Total).Location = new Point(317, 15);
		TextBox_TankerMinimum_Total.MaxLength = 32767;
		TextBox_TankerMinimum_Total.Multiline = false;
		((Control)TextBox_TankerMinimum_Total).Name = "TextBox_TankerMinimum_Total";
		TextBox_TankerMinimum_Total.ReadOnly = false;
		TextBox_TankerMinimum_Total.ScrollBars = (ScrollBars)0;
		TextBox_TankerMinimum_Total.SelectionStart = 0;
		((Control)TextBox_TankerMinimum_Total).Size = new Size(100, 20);
		((Control)TextBox_TankerMinimum_Total).TabIndex = 6;
		TextBox_TankerMinimum_Total.TextAlign = (HorizontalAlignment)0;
		TextBox_TankerMinimum_Total.UseSystemPasswordChar = false;
		TextBox_TankerMinimum_Total.WatermarkText = "";
		((Control)Label1).Location = new Point(4, 17);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(220, 13);
		((Control)Label1).TabIndex = 7;
		Label1.Text = "Minimum number of tankers needed:";
		((Control)Label2).Location = new Point(4, 38);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(220, 13);
		((Control)Label2).TabIndex = 9;
		Label2.Text = "Minimum number of tankers airborne:";
		TextBox_TankerMinimum_Airborne.AutoCompleteCustomSource = null;
		TextBox_TankerMinimum_Airborne.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_TankerMinimum_Airborne.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_TankerMinimum_Airborne).BackColor = Color.Transparent;
		TextBox_TankerMinimum_Airborne.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_TankerMinimum_Airborne).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_TankerMinimum_Airborne.Image = null;
		TextBox_TankerMinimum_Airborne.Lines = null;
		((Control)TextBox_TankerMinimum_Airborne).Location = new Point(317, 36);
		TextBox_TankerMinimum_Airborne.MaxLength = 32767;
		TextBox_TankerMinimum_Airborne.Multiline = false;
		((Control)TextBox_TankerMinimum_Airborne).Name = "TextBox_TankerMinimum_Airborne";
		TextBox_TankerMinimum_Airborne.ReadOnly = false;
		TextBox_TankerMinimum_Airborne.ScrollBars = (ScrollBars)0;
		TextBox_TankerMinimum_Airborne.SelectionStart = 0;
		((Control)TextBox_TankerMinimum_Airborne).Size = new Size(100, 20);
		((Control)TextBox_TankerMinimum_Airborne).TabIndex = 8;
		TextBox_TankerMinimum_Airborne.TextAlign = (HorizontalAlignment)0;
		TextBox_TankerMinimum_Airborne.UseSystemPasswordChar = false;
		TextBox_TankerMinimum_Airborne.WatermarkText = "";
		((Control)Label3).Location = new Point(4, 59);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(250, 13);
		((Control)Label3).TabIndex = 11;
		Label3.Text = "Minimum number of tankers on station:";
		TextBox_TankerMinimum_Station.AutoCompleteCustomSource = null;
		TextBox_TankerMinimum_Station.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_TankerMinimum_Station.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_TankerMinimum_Station).BackColor = Color.Transparent;
		TextBox_TankerMinimum_Station.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_TankerMinimum_Station).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_TankerMinimum_Station.Image = null;
		TextBox_TankerMinimum_Station.Lines = null;
		((Control)TextBox_TankerMinimum_Station).Location = new Point(317, 57);
		TextBox_TankerMinimum_Station.MaxLength = 32767;
		TextBox_TankerMinimum_Station.Multiline = false;
		((Control)TextBox_TankerMinimum_Station).Name = "TextBox_TankerMinimum_Station";
		TextBox_TankerMinimum_Station.ReadOnly = false;
		TextBox_TankerMinimum_Station.ScrollBars = (ScrollBars)0;
		TextBox_TankerMinimum_Station.SelectionStart = 0;
		((Control)TextBox_TankerMinimum_Station).Size = new Size(100, 20);
		((Control)TextBox_TankerMinimum_Station).TabIndex = 10;
		TextBox_TankerMinimum_Station.TextAlign = (HorizontalAlignment)0;
		TextBox_TankerMinimum_Station.UseSystemPasswordChar = false;
		TextBox_TankerMinimum_Station.WatermarkText = "";
		((Control)ListBox_Tankers).Location = new Point(12, 50);
		ListBox_Tankers.MultiSelect = true;
		((Control)ListBox_Tankers).Name = "ListBox_Tankers";
		ListBox_Tankers.RelatedInfos = null;
		((Control)ListBox_Tankers).Size = new Size(382, 279);
		((Control)ListBox_Tankers).TabIndex = 15;
		((Control)Label6).Location = new Point(4, 22);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(300, 13);
		((Control)Label6).TabIndex = 18;
		Label6.Text = "Maximum number of receivers in queue per tanker:";
		TextBox_MaxReceiversInQueuePerTanker_Airborne.AutoCompleteCustomSource = null;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_MaxReceiversInQueuePerTanker_Airborne).BackColor = Color.Transparent;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_MaxReceiversInQueuePerTanker_Airborne).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Image = null;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Lines = null;
		((Control)TextBox_MaxReceiversInQueuePerTanker_Airborne).Location = new Point(310, 20);
		TextBox_MaxReceiversInQueuePerTanker_Airborne.MaxLength = 32767;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Multiline = false;
		((Control)TextBox_MaxReceiversInQueuePerTanker_Airborne).Name = "TextBox_MaxReceiversInQueuePerTanker_Airborne";
		TextBox_MaxReceiversInQueuePerTanker_Airborne.ReadOnly = false;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.ScrollBars = (ScrollBars)0;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.SelectionStart = 0;
		((Control)TextBox_MaxReceiversInQueuePerTanker_Airborne).Size = new Size(104, 20);
		((Control)TextBox_MaxReceiversInQueuePerTanker_Airborne).TabIndex = 17;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.TextAlign = (HorizontalAlignment)0;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.UseSystemPasswordChar = false;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.WatermarkText = "";
		((ButtonBase)CheckBox_LaunchMissionWithoutTankersInPlace).AutoSize = true;
		((Control)CheckBox_LaunchMissionWithoutTankersInPlace).Location = new Point(6, 78);
		((Control)CheckBox_LaunchMissionWithoutTankersInPlace).Name = "CheckBox_LaunchMissionWithoutTankersInPlace";
		((Control)CheckBox_LaunchMissionWithoutTankersInPlace).Size = new Size(331, 19);
		((Control)CheckBox_LaunchMissionWithoutTankersInPlace).TabIndex = 19;
		((ButtonBase)CheckBox_LaunchMissionWithoutTankersInPlace).Text = "Launch mission without tankers in place (extremely risky!)";
		((Control)GroupBox3).Anchor = (AnchorStyles)13;
		((Control)GroupBox3).Controls.Add((Control)(object)CheckBox_KeepOnMissionWithoutTankersInPlace);
		((Control)GroupBox3).Controls.Add((Control)(object)Label1);
		((Control)GroupBox3).Controls.Add((Control)(object)TextBox_TankerMinimum_Total);
		((Control)GroupBox3).Controls.Add((Control)(object)CheckBox_LaunchMissionWithoutTankersInPlace);
		((Control)GroupBox3).Controls.Add((Control)(object)TextBox_TankerMinimum_Airborne);
		((Control)GroupBox3).Controls.Add((Control)(object)Label2);
		((Control)GroupBox3).Controls.Add((Control)(object)TextBox_TankerMinimum_Station);
		((Control)GroupBox3).Controls.Add((Control)(object)Label3);
		((Control)GroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox3).Location = new Point(400, 12);
		((Control)GroupBox3).Name = "GroupBox3";
		((Control)GroupBox3).Size = new Size(423, 125);
		((Control)GroupBox3).TabIndex = 21;
		((GroupBox)GroupBox3).TabStop = false;
		((GroupBox)GroupBox3).Text = "Mission planning details";
		((ButtonBase)CheckBox_KeepOnMissionWithoutTankersInPlace).AutoSize = true;
		((Control)CheckBox_KeepOnMissionWithoutTankersInPlace).Location = new Point(6, 100);
		((Control)CheckBox_KeepOnMissionWithoutTankersInPlace).Name = "CheckBox_KeepOnMissionWithoutTankersInPlace";
		((Control)CheckBox_KeepOnMissionWithoutTankersInPlace).Size = new Size(248, 19);
		((Control)CheckBox_KeepOnMissionWithoutTankersInPlace).TabIndex = 20;
		((ButtonBase)CheckBox_KeepOnMissionWithoutTankersInPlace).Text = "Proceed the flight with no tankers in place";
		((Control)GroupBox4).Anchor = (AnchorStyles)13;
		((Control)GroupBox4).Controls.Add((Control)(object)Combo_FollowReceiversNumber);
		((Control)GroupBox4).Controls.Add((Control)(object)Label8);
		((Control)GroupBox4).Controls.Add((Control)(object)TextBox_FuelQtyToStartLookingForTanker);
		((Control)GroupBox4).Controls.Add((Control)(object)CB_FollowReceivers);
		((Control)GroupBox4).Controls.Add((Control)(object)Label7);
		((Control)GroupBox4).Controls.Add((Control)(object)TextBox_MaxReceiversInQueuePerTanker_Airborne);
		((Control)GroupBox4).Controls.Add((Control)(object)Label6);
		((Control)GroupBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox4).Location = new Point(400, 143);
		((Control)GroupBox4).Name = "GroupBox4";
		((Control)GroupBox4).Size = new Size(423, 90);
		((Control)GroupBox4).TabIndex = 22;
		((GroupBox)GroupBox4).TabStop = false;
		((GroupBox)GroupBox4).Text = "Mission execution details";
		((Control)Combo_FollowReceiversNumber).Anchor = (AnchorStyles)13;
		((ComboBox)Combo_FollowReceiversNumber).BackColor = Color.Transparent;
		((ComboBox)Combo_FollowReceiversNumber).DrawMode = (DrawMode)1;
		((ComboBox)Combo_FollowReceiversNumber).DropDownStyle = (ComboBoxStyle)2;
		((ComboBox)Combo_FollowReceiversNumber).DropDownWidth = 500;
		((Control)Combo_FollowReceiversNumber).Font = new Font("Segoe UI", 7f);
		((ListControl)Combo_FollowReceiversNumber).FormattingEnabled = true;
		((Control)Combo_FollowReceiversNumber).Location = new Point(312, 62);
		((Control)Combo_FollowReceiversNumber).Name = "Combo_FollowReceiversNumber";
		((Control)Combo_FollowReceiversNumber).Size = new Size(102, 21);
		((Control)Combo_FollowReceiversNumber).TabIndex = 28;
		((Control)Label8).Location = new Point(300, 44);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(115, 13);
		((Control)Label8).TabIndex = 21;
		Label8.Text = "percent of mission fuel.";
		TextBox_FuelQtyToStartLookingForTanker.AutoCompleteCustomSource = null;
		TextBox_FuelQtyToStartLookingForTanker.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_FuelQtyToStartLookingForTanker.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_FuelQtyToStartLookingForTanker).BackColor = Color.Transparent;
		TextBox_FuelQtyToStartLookingForTanker.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_FuelQtyToStartLookingForTanker).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_FuelQtyToStartLookingForTanker.Image = null;
		TextBox_FuelQtyToStartLookingForTanker.Lines = null;
		((Control)TextBox_FuelQtyToStartLookingForTanker).Location = new Point(267, 40);
		TextBox_FuelQtyToStartLookingForTanker.MaxLength = 32767;
		TextBox_FuelQtyToStartLookingForTanker.Multiline = false;
		((Control)TextBox_FuelQtyToStartLookingForTanker).Name = "TextBox_FuelQtyToStartLookingForTanker";
		TextBox_FuelQtyToStartLookingForTanker.ReadOnly = false;
		TextBox_FuelQtyToStartLookingForTanker.ScrollBars = (ScrollBars)0;
		TextBox_FuelQtyToStartLookingForTanker.SelectionStart = 0;
		((Control)TextBox_FuelQtyToStartLookingForTanker).Size = new Size(32, 20);
		((Control)TextBox_FuelQtyToStartLookingForTanker).TabIndex = 19;
		TextBox_FuelQtyToStartLookingForTanker.TextAlign = (HorizontalAlignment)0;
		TextBox_FuelQtyToStartLookingForTanker.UseSystemPasswordChar = false;
		TextBox_FuelQtyToStartLookingForTanker.WatermarkText = "";
		((ButtonBase)CB_FollowReceivers).AutoSize = true;
		((Control)CB_FollowReceivers).Location = new Point(6, 64);
		((Control)CB_FollowReceivers).Name = "CB_FollowReceivers";
		((Control)CB_FollowReceivers).Size = new Size(309, 19);
		((Control)CB_FollowReceivers).TabIndex = 19;
		((ButtonBase)CB_FollowReceivers).Text = "Tanker follows receiver's flightplan (enroute refueling)";
		((Control)Label7).Location = new Point(4, 43);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(289, 17);
		((Control)Label7).TabIndex = 20;
		Label7.Text = "Receivers start looking for tanker when down to ";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(837, 353);
		((Control)this).Controls.Add((Control)(object)GroupBox4);
		((Control)this).Controls.Add((Control)(object)GroupBox3);
		((Control)this).Controls.Add((Control)(object)ListBox_Tankers);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)RadioButton_Automatic);
		((Control)this).Controls.Add((Control)(object)RadioButton_Mission);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(853, 392);
		((Control)this).Name = "TankerPlanner";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Tanker Planner";
		((Form)this).TopMost = true;
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox3).ResumeLayout(false);
		((Control)GroupBox3).PerformLayout();
		((Control)GroupBox4).ResumeLayout(false);
		((Control)GroupBox4).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	private void method_2(bool bool_9, bool bool_10)
	{
		if (Client.Realtime && !Client.RealtimeAC)
		{
			if (bool_9 && TheMission != null && (Client.MissionEditorWindow == null || !((Control)Client.MissionEditorWindow).Visible))
			{
				Client.RealtimeTerminal.PollForLocalMissionStateChange(TheMission);
			}
			if (bool_10 && TheWaypoint != null)
			{
				Client.RealtimeTerminal.SendWaypointUpdate(null, TheWaypoint);
			}
		}
	}

	private void method_3()
	{
		ListBox_Tankers.Items.Clear();
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (side != Client.CurrentSide && !Module_Side.IsAlliedWithThisSide(side, Client.CurrentSide))
			{
				continue;
			}
			foreach (Mission item in side.Missions.OrderBy([SpecialName] (Mission theMission) => theMission.Name))
			{
				if (item.MissionClass == Mission._MissionClass.Support || item.MissionClass == Mission._MissionClass.Ferry)
				{
					DarkListItem darkListItem = new DarkListItem();
					if (side == Client.CurrentSide)
					{
						darkListItem.Text = item.Name;
					}
					else
					{
						darkListItem.Text = item.Name + " (" + side.Name + ")";
					}
					darkListItem.Tag = item;
					ListBox_Tankers.Items.Add(darkListItem);
				}
			}
		}
		List<int> list = new List<int>();
		int num = ListBox_Tankers.Items.Count - 1;
		for (int num2 = 0; num2 <= num; num2++)
		{
			if (Information.IsNothing((object)TheMission))
			{
				if (!Information.IsNothing((object)TheWaypoint) && TheWaypoint.TankerMissions.Contains((Mission)ListBox_Tankers.Items[num2].Tag))
				{
					list.Add(num2);
				}
			}
			else if (TheMission.TankerMissions.Contains((Mission)ListBox_Tankers.Items[num2].Tag))
			{
				list.Add(num2);
			}
		}
		if (list.Count > 0)
		{
			ListBox_Tankers.SelectItems(list);
		}
	}

	public void RefreshForMission(string MissionID)
	{
		if (TheMission != null && Operators.CompareString(TheMission.ObjectID, MissionID, true) == 0)
		{
			RefreshForm();
		}
	}

	public void RefreshForFlightPlan(Waypoint[] FlightPlan)
	{
		if (TheWaypoint == null)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < FlightPlan.Length)
			{
				if (Operators.CompareString(FlightPlan[num].ObjectID, TheWaypoint.ObjectID, true) == 0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return;
		}
		RefreshForm();
	}

	public void RefreshForm()
	{
		if (!((Control)this).Visible)
		{
			return;
		}
		if (!Information.IsNothing((object)TheMission))
		{
			switch (TheMission.TankerUsage)
			{
			case Mission.TankerMethod.Automatic:
				((RadioButton)RadioButton_Automatic).Checked = true;
				((RadioButton)RadioButton_Mission).Checked = false;
				break;
			case Mission.TankerMethod.Mission:
				((RadioButton)RadioButton_Automatic).Checked = false;
				((RadioButton)RadioButton_Mission).Checked = true;
				break;
			}
		}
		else if (!Information.IsNothing((object)TheWaypoint))
		{
			switch (TheWaypoint.TankerUsage)
			{
			case Mission.TankerMethod.Automatic:
				((RadioButton)RadioButton_Automatic).Checked = true;
				((RadioButton)RadioButton_Mission).Checked = false;
				break;
			case Mission.TankerMethod.Mission:
				((RadioButton)RadioButton_Automatic).Checked = false;
				((RadioButton)RadioButton_Mission).Checked = true;
				break;
			}
		}
		method_4();
	}

	private void TankerPlanner_VisibleChanged(object sender, EventArgs e)
	{
		RefreshForm();
	}

	private void TankerPlanner_FormClosing(object sender, FormClosingEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = true;
		try
		{
			method_16();
			method_17();
			method_18();
			method_19();
			method_20();
			if (!Information.IsNothing((object)TheMission))
			{
				if (TheMission.TankerUsage == Mission.TankerMethod.Mission && (TheMission.TankerMissions == null || TheMission.TankerMissions.Count == 0))
				{
					TheMission.TankerUsage = Mission.TankerMethod.Automatic;
					method_2(bool_9: true, bool_10: false);
				}
			}
			else if (!Information.IsNothing((object)TheWaypoint) && TheWaypoint.TankerUsage == Mission.TankerMethod.Mission && TheWaypoint.TankerMissions.Count == 0)
			{
				TheWaypoint.TankerUsage = Mission.TankerMethod.Automatic;
				method_2(bool_9: false, bool_10: true);
			}
			((Control)this).Hide();
			((Control)ListBox_Tankers).Select();
			((Control)Client.MissionEditorWindow).BringToFront();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			((Control)this).Hide();
			if (Client.MissionEditorWindow != null && ((Control)Client.MissionEditorWindow).Visible)
			{
				((Control)Client.MissionEditorWindow).BringToFront();
			}
			ex2?.Data.Add("Error at 9876245", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4()
	{
		if (!Information.IsNothing((object)TheMission))
		{
			((Control)TextBox_FuelQtyToStartLookingForTanker).Enabled = true;
			((Control)Label7).Enabled = true;
			((Control)Label8).Enabled = true;
			((Control)Combo_FollowReceiversNumber).Enabled = false;
			((Control)GroupBox1).Enabled = true;
			((Control)GroupBox3).Enabled = true;
			((Control)GroupBox4).Enabled = true;
			((Control)CheckBox_LaunchMissionWithoutTankersInPlace).Enabled = true;
			((Control)CheckBox_KeepOnMissionWithoutTankersInPlace).Enabled = true;
			switch (TheMission.TankerUsage)
			{
			case Mission.TankerMethod.Mission:
				((Control)ListBox_Tankers).Enabled = true;
				((Control)TextBox_TankerMinimum_Total).Enabled = true;
				((Control)TextBox_TankerMinimum_Airborne).Enabled = true;
				((Control)TextBox_TankerMinimum_Station).Enabled = true;
				((Control)Label1).Enabled = true;
				((Control)Label2).Enabled = true;
				((Control)Label3).Enabled = true;
				method_3();
				break;
			case Mission.TankerMethod.Automatic:
				((Control)ListBox_Tankers).Enabled = false;
				((Control)TextBox_TankerMinimum_Total).Enabled = false;
				((Control)TextBox_TankerMinimum_Airborne).Enabled = false;
				((Control)TextBox_TankerMinimum_Station).Enabled = false;
				((Control)Label1).Enabled = false;
				((Control)Label2).Enabled = false;
				((Control)Label3).Enabled = false;
				ListBox_Tankers.Items.Clear();
				break;
			}
		}
		else if (!Information.IsNothing((object)TheWaypoint))
		{
			((Control)TextBox_FuelQtyToStartLookingForTanker).Enabled = false;
			((Control)Label7).Enabled = false;
			((Control)Label8).Enabled = false;
			((Control)GroupBox1).Enabled = true;
			((Control)GroupBox4).Enabled = true;
			((Control)GroupBox3).Enabled = false;
			switch (TheWaypoint.TankerUsage)
			{
			case Mission.TankerMethod.Mission:
				((Control)ListBox_Tankers).Enabled = true;
				method_3();
				break;
			case Mission.TankerMethod.Automatic:
				((Control)ListBox_Tankers).Enabled = false;
				ListBox_Tankers.Items.Clear();
				break;
			}
			if (!TheWaypoint.TankerFollowsReceivers)
			{
				((Control)Combo_FollowReceiversNumber).Enabled = false;
			}
			else
			{
				((Control)Combo_FollowReceiversNumber).Enabled = true;
			}
		}
		if (!Information.IsNothing((object)TheMission))
		{
			if (TheMission.TankerUsage == Mission.TankerMethod.Mission)
			{
				if (TheMission.TankerMinNumber_Total > 0)
				{
					TextBox_TankerMinimum_Total.Text = Conversions.ToString(TheMission.TankerMinNumber_Total);
				}
				else
				{
					TextBox_TankerMinimum_Total.Text = "Not specified";
				}
				if (TheMission.TankerMinNumber_Airborne <= 0)
				{
					TextBox_TankerMinimum_Airborne.Text = "Not specified";
				}
				else
				{
					TextBox_TankerMinimum_Airborne.Text = Conversions.ToString(TheMission.TankerMinNumber_Airborne);
				}
				if (TheMission.TankerMinNumber_Station <= 0)
				{
					TextBox_TankerMinimum_Station.Text = "Not specified";
				}
				else
				{
					TextBox_TankerMinimum_Station.Text = Conversions.ToString(TheMission.TankerMinNumber_Station);
				}
			}
		}
		else if (!Information.IsNothing((object)TheWaypoint) && TheWaypoint.TankerUsage == Mission.TankerMethod.Mission)
		{
			TextBox_TankerMinimum_Total.Text = "N/A";
			TextBox_TankerMinimum_Airborne.Text = "N/A";
			TextBox_TankerMinimum_Station.Text = "N/A";
			((CheckBox)CheckBox_LaunchMissionWithoutTankersInPlace).Checked = false;
		}
		((CheckBox)CheckBox_LaunchMissionWithoutTankersInPlace).Checked = TheMission.LaunchMissionWithoutTankersInPlace;
		((CheckBox)CheckBox_KeepOnMissionWithoutTankersInPlace).Checked = TheMission.KeepOnMissionWithoutTankersInPlace;
		DataTable theComboBox_FollowReceiversNumber = new DataTable();
		if (!Information.IsNothing((object)TheMission))
		{
			((CheckBox)CB_FollowReceivers).Checked = TheMission.TankerFollowsReceivers;
			if (TheMission.MaxReceiversInQueuePerTanker_Airborne > 0)
			{
				TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = Conversions.ToString(TheMission.MaxReceiversInQueuePerTanker_Airborne);
			}
			else
			{
				TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "Not specified";
			}
			if (TheMission.FuelQtyToStartLookingForTanker_Airborne > 0)
			{
				TextBox_FuelQtyToStartLookingForTanker.Text = Conversions.ToString(TheMission.FuelQtyToStartLookingForTanker_Airborne);
			}
			else
			{
				TextBox_FuelQtyToStartLookingForTanker.Text = "None";
			}
			((ComboBox)Combo_FollowReceiversNumber).SelectedIndex = -1;
		}
		else if (!Information.IsNothing((object)TheWaypoint))
		{
			((CheckBox)CB_FollowReceivers).Checked = TheWaypoint.TankerFollowsReceivers;
			if (TheWaypoint.MaxReceiversInQueuePerTanker_Airborne > 0)
			{
				TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = Conversions.ToString(TheWaypoint.MaxReceiversInQueuePerTanker_Airborne);
			}
			else
			{
				TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "Not specified";
			}
			TextBox_FuelQtyToStartLookingForTanker.Text = "N/A";
			ComboBox combobox = (ComboBox)(object)Combo_FollowReceiversNumber;
			ComboBox_FollowReceiversNumber(ref combobox, ref theComboBox_FollowReceiversNumber, TheWaypoint.TankerFollowsReceivers_NumberOfWaypoints);
			Combo_FollowReceiversNumber = (DarkUIComboBox)(object)combobox;
		}
		if (!Information.IsNothing((object)TheMission))
		{
			if (TheMission.TankerMaxDistance_Airborne == int.MaxValue)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = true;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = false;
			}
			else if (TheMission.TankerMaxDistance_Airborne == 500)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = true;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = false;
			}
			else if (TheMission.TankerMaxDistance_Airborne == 250)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = true;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = false;
			}
			else if (TheMission.TankerMaxDistance_Airborne == 100)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = true;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = false;
			}
			else if (TheMission.TankerMaxDistance_Airborne == 50)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = true;
			}
		}
		else if (!Information.IsNothing((object)TheWaypoint))
		{
			if (TheWaypoint.TankerMaxDistance_Airborne == int.MaxValue)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = true;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = false;
			}
			else if (TheWaypoint.TankerMaxDistance_Airborne == 500)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = true;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = false;
			}
			else if (TheWaypoint.TankerMaxDistance_Airborne == 250)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = true;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = false;
			}
			else if (TheWaypoint.TankerMaxDistance_Airborne == 100)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = true;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = false;
			}
			else if (TheWaypoint.TankerMaxDistance_Airborne == 50)
			{
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_Tactical).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_500).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_250).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_100).Checked = false;
				((RadioButton)RadioButton_TankerMaxDistance_Airborne_50).Checked = true;
			}
		}
	}

	public static void ComboBox_FollowReceiversNumber(ref ComboBox combobox, ref DataTable theComboBox_FollowReceiversNumber, int theNumber)
	{
		if (!theComboBox_FollowReceiversNumber.Columns.Contains("ID"))
		{
			theComboBox_FollowReceiversNumber.Columns.Add("ID", typeof(int));
		}
		if (!theComboBox_FollowReceiversNumber.Columns.Contains("Description"))
		{
			theComboBox_FollowReceiversNumber.Columns.Add("Description", typeof(string));
		}
		theComboBox_FollowReceiversNumber.Rows.Add(0, Mission.get_TankerFollowsReceiverString(Mission._TankerFollowsReceiver.UntilFull));
		theComboBox_FollowReceiversNumber.Rows.Add(1, Mission.get_TankerFollowsReceiverString(Mission._TankerFollowsReceiver.Waypoint1));
		theComboBox_FollowReceiversNumber.Rows.Add(2, Mission.get_TankerFollowsReceiverString(Mission._TankerFollowsReceiver.Waypoint2));
		theComboBox_FollowReceiversNumber.Rows.Add(3, Mission.get_TankerFollowsReceiverString(Mission._TankerFollowsReceiver.Weaypoin3));
		theComboBox_FollowReceiversNumber.Rows.Add(4, Mission.get_TankerFollowsReceiverString(Mission._TankerFollowsReceiver.UntilHoldWaypoint));
		theComboBox_FollowReceiversNumber.Rows.Add(5, Mission.get_TankerFollowsReceiverString(Mission._TankerFollowsReceiver.UntilStationWaypoint));
		theComboBox_FollowReceiversNumber.Rows.Add(6, Mission.get_TankerFollowsReceiverString(Mission._TankerFollowsReceiver.UntilLandingMarshalWaypoint));
		ComboBox obj = combobox;
		obj.DataSource = theComboBox_FollowReceiversNumber;
		((ListControl)obj).DisplayMember = "Description";
		((ListControl)obj).ValueMember = "ID";
		obj.SelectedIndex = Mission.FollowReceiversNumber_To_FollowReceiversSelection(theNumber);
	}

	private void TankerPlanner_KeyDown(object sender, KeyEventArgs e)
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

	private void method_5(object sender, EventArgs e)
	{
		bool bool_ = false;
		bool bool_2 = false;
		int num = ListBox_Tankers.Items.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (!ListBox_Tankers.SelectedItems.Contains(ListBox_Tankers.Items[i]))
			{
				if (Information.IsNothing((object)TheMission))
				{
					if (!Information.IsNothing((object)TheWaypoint) && TheWaypoint.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
					{
						TheWaypoint.TankerMissions.Remove((Mission)ListBox_Tankers.Items[i].Tag);
						bool_2 = true;
					}
				}
				else if (TheMission.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
				{
					TheMission.TankerMissions.Remove((Mission)ListBox_Tankers.Items[i].Tag);
					bool_ = true;
				}
			}
			else if (Information.IsNothing((object)TheMission))
			{
				if (!Information.IsNothing((object)TheWaypoint) && !TheWaypoint.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
				{
					TheWaypoint.TankerMissions.Add((Mission)ListBox_Tankers.Items[i].Tag);
					bool_2 = true;
				}
			}
			else if (!TheMission.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
			{
				TheMission.TankerMissions.Add((Mission)ListBox_Tankers.Items[i].Tag);
				bool_ = true;
			}
			method_2(bool_, bool_2);
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_7(object sender, EventArgs e)
	{
		method_16();
	}

	private void method_8(object sender, EventArgs e)
	{
		bool_4 = true;
	}

	private void method_9(object sender, EventArgs e)
	{
		method_17();
	}

	private void method_10(object sender, EventArgs e)
	{
		bool_5 = true;
	}

	private void method_11(object sender, EventArgs e)
	{
		method_18();
	}

	private void method_12(object sender, EventArgs e)
	{
		bool_7 = true;
	}

	private void method_13(object sender, EventArgs e)
	{
		method_19();
	}

	private void method_14(object sender, EventArgs e)
	{
		bool_8 = true;
	}

	private void method_15(object sender, EventArgs e)
	{
		method_20();
	}

	private void method_16()
	{
		if (bool_3)
		{
			if (Information.IsNothing((object)TheMission))
			{
				return;
			}
			if (string.IsNullOrEmpty(TextBox_TankerMinimum_Total.Text))
			{
				TheMission.TankerMinNumber_Total = 0;
				TextBox_TankerMinimum_Total.Text = "Not specified";
			}
			if (!Versioned.IsNumeric((object)TextBox_TankerMinimum_Total.Text))
			{
				return;
			}
			int num = Conversions.ToInteger(TextBox_TankerMinimum_Total.Text);
			if (num < 0)
			{
				num = 0;
			}
			TheMission.TankerMinNumber_Total = num;
			if (num == 0)
			{
				TextBox_TankerMinimum_Total.Text = "Not specified";
			}
			else
			{
				TextBox_TankerMinimum_Total.Text = Conversions.ToString(num);
			}
		}
		method_2(bool_9: true, bool_10: false);
		bool_3 = false;
	}

	private void method_17()
	{
		if (bool_4)
		{
			if (Information.IsNothing((object)TheMission))
			{
				return;
			}
			if (string.IsNullOrEmpty(TextBox_TankerMinimum_Airborne.Text))
			{
				TheMission.TankerMinNumber_Airborne = 0;
				TextBox_TankerMinimum_Airborne.Text = "Not specified";
			}
			if (!Versioned.IsNumeric((object)TextBox_TankerMinimum_Airborne.Text))
			{
				return;
			}
			int num = Conversions.ToInteger(TextBox_TankerMinimum_Airborne.Text);
			if (num < 0)
			{
				num = 0;
			}
			TheMission.TankerMinNumber_Airborne = num;
			if (num != 0)
			{
				TextBox_TankerMinimum_Airborne.Text = Conversions.ToString(num);
			}
			else
			{
				TextBox_TankerMinimum_Airborne.Text = "Not specified";
			}
		}
		method_2(bool_9: true, bool_10: false);
		bool_4 = false;
	}

	private void method_18()
	{
		if (bool_5)
		{
			if (Information.IsNothing((object)TheMission))
			{
				return;
			}
			if (string.IsNullOrEmpty(TextBox_TankerMinimum_Station.Text))
			{
				TheMission.TankerMinNumber_Station = 0;
				TextBox_TankerMinimum_Station.Text = "Not specified";
			}
			if (!Versioned.IsNumeric((object)TextBox_TankerMinimum_Station.Text))
			{
				return;
			}
			int num = Conversions.ToInteger(TextBox_TankerMinimum_Station.Text);
			if (num < 0)
			{
				num = 0;
			}
			TheMission.TankerMinNumber_Station = num;
			if (num != 0)
			{
				TextBox_TankerMinimum_Station.Text = Conversions.ToString(num);
			}
			else
			{
				TextBox_TankerMinimum_Station.Text = "Not specified";
			}
		}
		method_2(bool_9: true, bool_10: false);
		bool_5 = false;
	}

	private void method_19()
	{
		bool bool_ = false;
		bool bool_2 = false;
		if (bool_7)
		{
			if (Information.IsNothing((object)TheMission))
			{
				if (!Information.IsNothing((object)TheWaypoint))
				{
					if (string.IsNullOrEmpty(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text))
					{
						TheWaypoint.MaxReceiversInQueuePerTanker_Airborne = 0;
						bool_2 = true;
						TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "Not specified";
					}
					if (!Versioned.IsNumeric((object)TextBox_MaxReceiversInQueuePerTanker_Airborne.Text))
					{
						return;
					}
					int num = Conversions.ToInteger(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text);
					if (num < 0)
					{
						num = 0;
					}
					TheWaypoint.MaxReceiversInQueuePerTanker_Airborne = num;
					bool_2 = true;
					if (num == 0)
					{
						TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "Not specified";
					}
					else
					{
						TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = Conversions.ToString(num);
					}
				}
			}
			else
			{
				if (string.IsNullOrEmpty(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text))
				{
					TheMission.MaxReceiversInQueuePerTanker_Airborne = 0;
					bool_ = true;
					TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "Not specified";
				}
				if (!Versioned.IsNumeric((object)TextBox_MaxReceiversInQueuePerTanker_Airborne.Text))
				{
					return;
				}
				int num2 = Conversions.ToInteger(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text);
				if (num2 < 0)
				{
					num2 = 0;
				}
				TheMission.MaxReceiversInQueuePerTanker_Airborne = num2;
				bool_ = true;
				if (num2 != 0)
				{
					TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = Conversions.ToString(num2);
				}
				else
				{
					TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "Not specified";
				}
			}
		}
		method_2(bool_, bool_2);
		bool_7 = false;
	}

	private void method_20()
	{
		if (bool_8)
		{
			if (TheMission == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(TextBox_FuelQtyToStartLookingForTanker.Text))
			{
				TheMission.SetDefaultFuelQtyToStartLookingForTanker_Airborne();
				TextBox_FuelQtyToStartLookingForTanker.Text = Conversions.ToString(TheMission.FuelQtyToStartLookingForTanker_Airborne);
			}
			else
			{
				if (!Versioned.IsNumeric((object)TextBox_FuelQtyToStartLookingForTanker.Text))
				{
					return;
				}
				int num = Conversions.ToInteger(TextBox_FuelQtyToStartLookingForTanker.Text);
				if (num > 90)
				{
					TextBox_FuelQtyToStartLookingForTanker.Text = "90";
					TheMission.FuelQtyToStartLookingForTanker_Airborne = 90;
				}
				else if (num < 0)
				{
					TextBox_FuelQtyToStartLookingForTanker.Text = "0";
					TheMission.FuelQtyToStartLookingForTanker_Airborne = 0;
				}
				else
				{
					TheMission.FuelQtyToStartLookingForTanker_Airborne = num;
				}
			}
		}
		method_2(bool_9: true, bool_10: false);
		bool_8 = false;
	}

	private void method_21(object sender, EventArgs e)
	{
		if (((RadioButton)RadioButton_Mission).Checked)
		{
			if (!Information.IsNothing((object)TheMission))
			{
				TheMission.TankerUsage = Mission.TankerMethod.Mission;
				method_2(bool_9: true, bool_10: false);
			}
			else if (!Information.IsNothing((object)TheWaypoint))
			{
				TheWaypoint.TankerUsage = Mission.TankerMethod.Mission;
				method_2(bool_9: false, bool_10: true);
			}
			method_4();
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)TheMission))
		{
			if (!Information.IsNothing((object)TheWaypoint))
			{
				TheWaypoint.TankerMaxDistance_Airborne = int.MaxValue;
				method_2(bool_9: false, bool_10: true);
			}
		}
		else
		{
			TheMission.TankerMaxDistance_Airborne = int.MaxValue;
			method_2(bool_9: true, bool_10: false);
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)TheMission))
		{
			if (!Information.IsNothing((object)TheWaypoint))
			{
				TheWaypoint.TankerMaxDistance_Airborne = 500;
				method_2(bool_9: false, bool_10: true);
			}
		}
		else
		{
			TheMission.TankerMaxDistance_Airborne = 500;
			method_2(bool_9: true, bool_10: false);
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)TheMission))
		{
			if (!Information.IsNothing((object)TheWaypoint))
			{
				TheWaypoint.TankerMaxDistance_Airborne = 250;
				method_2(bool_9: false, bool_10: true);
			}
		}
		else
		{
			TheMission.TankerMaxDistance_Airborne = 250;
			method_2(bool_9: true, bool_10: false);
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)TheMission))
		{
			TheMission.TankerMaxDistance_Airborne = 100;
			method_2(bool_9: true, bool_10: false);
		}
		else if (!Information.IsNothing((object)TheWaypoint))
		{
			TheWaypoint.TankerMaxDistance_Airborne = 100;
			method_2(bool_9: false, bool_10: true);
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)TheMission))
		{
			TheMission.TankerMaxDistance_Airborne = 50;
			method_2(bool_9: true, bool_10: false);
		}
		else if (!Information.IsNothing((object)TheWaypoint))
		{
			TheWaypoint.TankerMaxDistance_Airborne = 50;
			method_2(bool_9: false, bool_10: true);
		}
	}

	private void method_27(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)TheMission))
		{
			TheMission.LaunchMissionWithoutTankersInPlace = ((CheckBox)CheckBox_LaunchMissionWithoutTankersInPlace).Checked;
			method_2(bool_9: true, bool_10: false);
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)TheMission))
		{
			TheMission.KeepOnMissionWithoutTankersInPlace = ((CheckBox)CheckBox_KeepOnMissionWithoutTankersInPlace).Checked;
			method_2(bool_9: true, bool_10: false);
		}
	}

	private void TankerPlanner_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_29(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)TheMission))
		{
			if (!Information.IsNothing((object)TheWaypoint))
			{
				TheWaypoint.TankerFollowsReceivers = ((CheckBox)CB_FollowReceivers).Checked;
				method_2(bool_9: false, bool_10: true);
				if (!TheWaypoint.TankerFollowsReceivers)
				{
					((Control)Combo_FollowReceiversNumber).Enabled = false;
				}
				else
				{
					((Control)Combo_FollowReceiversNumber).Enabled = true;
				}
			}
		}
		else
		{
			TheMission.TankerFollowsReceivers = ((CheckBox)CB_FollowReceivers).Checked;
			method_2(bool_9: true, bool_10: false);
		}
	}

	private void method_30(object sender, EventArgs e)
	{
		if (!((RadioButton)RadioButton_Automatic).Checked)
		{
			return;
		}
		if (Information.IsNothing((object)TheMission))
		{
			if (!Information.IsNothing((object)TheWaypoint))
			{
				TheWaypoint.TankerUsage = Mission.TankerMethod.Automatic;
				method_2(bool_9: false, bool_10: true);
			}
		}
		else
		{
			TheMission.TankerUsage = Mission.TankerMethod.Automatic;
			method_2(bool_9: true, bool_10: false);
		}
		method_4();
	}

	private void method_31(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)TheWaypoint))
		{
			TheWaypoint.TankerFollowsReceivers_NumberOfWaypoints = (int)Mission.FollowReceiversSelection_To_FollowReceiversNumber(((ComboBox)Combo_FollowReceiversNumber).SelectedIndex);
			method_2(bool_9: false, bool_10: true);
		}
	}

	static TankerPlanner()
	{
		Class72.smethod_20();
	}
}

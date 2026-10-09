using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanWaypoints : UserControl
{
	[CompilerGenerated]
	internal sealed class _Closure$__205-0
	{
		public Waypoint $VB$Local_theWaypoint;

		public Func<Waypoint, bool> $I0;

		public _Closure$__205-0(_Closure$__205-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWaypoint = arg0.$VB$Local_theWaypoint;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Waypoint x)
		{
			return Operators.CompareString(x.Description, $VB$Local_theWaypoint.Description, true) == 0;
		}

		static _Closure$__205-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_Waypoints")]
	private DarkDataGridView _DGV_Waypoints;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_InsertWaypoint")]
	private DarkUIButton _Button_InsertWaypoint;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DeleteWaypoint")]
	private DarkUIButton _Button_DeleteWaypoint;

	[AccessedThroughProperty("Button_EditTime")]
	[CompilerGenerated]
	private DarkUIButton _Button_EditTime;

	[AccessedThroughProperty("Button_EditSpeedAltitude")]
	[CompilerGenerated]
	private DarkUIButton _Button_EditSpeedAltitude;

	[AccessedThroughProperty("Button_EditDoctrine")]
	[CompilerGenerated]
	private DarkUIButton _Button_EditDoctrine;

	[AccessedThroughProperty("Button_EditAAR")]
	[CompilerGenerated]
	private DarkUIButton _Button_EditAAR;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearTime")]
	private DarkUIButton _Button_ClearTime;

	[AccessedThroughProperty("Button_EditSensorUsage")]
	[CompilerGenerated]
	private DarkUIButton _Button_EditSensorUsage;

	[CompilerGenerated]
	[AccessedThroughProperty("AARSettings")]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditTargetAndWeapons")]
	private DarkUIButton _Button_EditTargetAndWeapons;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Filter")]
	private DarkUICheckBox _CB_Filter;

	public Mission.Flight.FlightElement FlightPlan_Element;

	[CompilerGenerated]
	private string string_0;

	internal virtual DarkDataGridView DGV_Waypoints
	{
		[CompilerGenerated]
		get
		{
			return _DGV_Waypoints;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			DataGridViewColumnEventHandler val = new DataGridViewColumnEventHandler(method_7);
			PaintEventHandler val2 = new PaintEventHandler(method_8);
			EventHandler eventHandler = method_9;
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(method_10);
			DataGridViewCellEventHandler val4 = new DataGridViewCellEventHandler(method_11);
			EventHandler eventHandler2 = method_12;
			EventHandler eventHandler3 = method_14;
			DarkDataGridView darkDataGridView = _DGV_Waypoints;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).ColumnWidthChanged -= val;
				((Control)darkDataGridView).Paint -= val2;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellClick -= val3;
				((DataGridView)darkDataGridView).CellValueChanged -= val4;
				((DataGridView)darkDataGridView).CurrentCellDirtyStateChanged -= eventHandler2;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler3;
			}
			_DGV_Waypoints = value;
			darkDataGridView = _DGV_Waypoints;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).ColumnWidthChanged += val;
				((Control)darkDataGridView).Paint += val2;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellClick += val3;
				((DataGridView)darkDataGridView).CellValueChanged += val4;
				((DataGridView)darkDataGridView).CurrentCellDirtyStateChanged += eventHandler2;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler3;
			}
		}
	}

	internal virtual DarkUIButton Button_InsertWaypoint
	{
		[CompilerGenerated]
		get
		{
			return _Button_InsertWaypoint;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			DarkUIButton darkUIButton = _Button_InsertWaypoint;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_InsertWaypoint = value;
			darkUIButton = _Button_InsertWaypoint;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_DeleteWaypoint
	{
		[CompilerGenerated]
		get
		{
			return _Button_DeleteWaypoint;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			DarkUIButton darkUIButton = _Button_DeleteWaypoint;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_DeleteWaypoint = value;
			darkUIButton = _Button_DeleteWaypoint;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_EditTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_EditTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditTime = value;
			darkUIButton = _Button_EditTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_EditSpeedAltitude
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditSpeedAltitude;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_EditSpeedAltitude;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditSpeedAltitude = value;
			darkUIButton = _Button_EditSpeedAltitude;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_EditDoctrine
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditDoctrine;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button_EditDoctrine;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditDoctrine = value;
			darkUIButton = _Button_EditDoctrine;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_EditAAR
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditAAR;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button_EditAAR;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditAAR = value;
			darkUIButton = _Button_EditAAR;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn3 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn4 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn5")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn5 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn6")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn6 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn7")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn7 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn8")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn8 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn9")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn9 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn10")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn10 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn11")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn11 { get; set; }

	internal virtual DarkUIButton Button_ClearTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_ClearTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _Button_ClearTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ClearTime = value;
			darkUIButton = _Button_ClearTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_EditSensorUsage
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditSensorUsage;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIButton darkUIButton = _Button_EditSensorUsage;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditSensorUsage = value;
			darkUIButton = _Button_EditSensorUsage;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("ObjectID")]
	internal virtual DataGridViewTextBoxColumn ObjectID { get; set; }

	[field: AccessedThroughProperty("Type")]
	internal virtual DataGridViewComboBoxColumn Type { get; set; }

	[field: AccessedThroughProperty("Time_Zulu")]
	internal virtual DataGridViewTextBoxColumn Time_Zulu { get; set; }

	[field: AccessedThroughProperty("Time_Local")]
	internal virtual DataGridViewTextBoxColumn Time_Local { get; set; }

	[field: AccessedThroughProperty("TimeFixedImg")]
	internal virtual DataGridViewImageColumn TimeFixedImg { get; set; }

	[field: AccessedThroughProperty("TimeFixed")]
	internal virtual DataGridViewTextBoxColumn TimeFixed { get; set; }

	[field: AccessedThroughProperty("DesiredSpeed")]
	internal virtual DataGridViewTextBoxColumn DesiredSpeed { get; set; }

	[field: AccessedThroughProperty("SpeedFixedImg")]
	internal virtual DataGridViewImageColumn SpeedFixedImg { get; set; }

	[field: AccessedThroughProperty("SpeedFixed")]
	internal virtual DataGridViewTextBoxColumn SpeedFixed { get; set; }

	[field: AccessedThroughProperty("DesiredAltitude")]
	internal virtual DataGridViewTextBoxColumn DesiredAltitude { get; set; }

	[field: AccessedThroughProperty("Leg_Distance")]
	internal virtual DataGridViewTextBoxColumn Leg_Distance { get; set; }

	[field: AccessedThroughProperty("Leg_TotalDistance")]
	internal virtual DataGridViewTextBoxColumn Leg_TotalDistance { get; set; }

	[field: AccessedThroughProperty("Leg_Time")]
	internal virtual DataGridViewTextBoxColumn Leg_Time { get; set; }

	[field: AccessedThroughProperty("Hold_Time")]
	internal virtual DataGridViewTextBoxColumn Hold_Time { get; set; }

	[field: AccessedThroughProperty("Leg_TotalTime")]
	internal virtual DataGridViewTextBoxColumn Leg_TotalTime { get; set; }

	[field: AccessedThroughProperty("Leg_FuelRequired")]
	internal virtual DataGridViewTextBoxColumn Leg_FuelRequired { get; set; }

	[field: AccessedThroughProperty("Leg_FuelRemaining")]
	internal virtual DataGridViewTextBoxColumn Leg_FuelRemaining { get; set; }

	[field: AccessedThroughProperty("SpeedToT")]
	internal virtual DataGridViewComboBoxColumn SpeedToT { get; set; }

	[field: AccessedThroughProperty("Formation")]
	internal virtual DataGridViewComboBoxColumn Formation { get; set; }

	[field: AccessedThroughProperty("AARUsage")]
	internal virtual DataGridViewComboBoxColumn AARUsage { get; set; }

	[field: AccessedThroughProperty("AARSelection")]
	internal virtual DataGridViewComboBoxColumn AARSelection { get; set; }

	internal virtual DataGridViewTextBoxColumn AARSettings
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

	[field: AccessedThroughProperty("SensorUsage")]
	internal virtual DataGridViewTextBoxColumn SensorUsage { get; set; }

	[field: AccessedThroughProperty("Doctrine")]
	internal virtual DataGridViewTextBoxColumn Doctrine { get; set; }

	[field: AccessedThroughProperty("TurnRate")]
	internal virtual DataGridViewComboBoxColumn TurnRate { get; set; }

	[field: AccessedThroughProperty("Coordinates")]
	internal virtual DataGridViewTextBoxColumn Coordinates { get; set; }

	internal virtual DarkUIButton Button_EditTargetAndWeapons
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditTargetAndWeapons;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			EventHandler eventHandler2 = method_16;
			DarkUIButton darkUIButton = _Button_EditTargetAndWeapons;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
				((Control)darkUIButton).Click -= eventHandler2;
			}
			_Button_EditTargetAndWeapons = value;
			darkUIButton = _Button_EditTargetAndWeapons;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
				((Control)darkUIButton).Click += eventHandler2;
			}
		}
	}

	internal virtual DarkUICheckBox CB_Filter
	{
		[CompilerGenerated]
		get
		{
			return _CB_Filter;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUICheckBox darkUICheckBox = _CB_Filter;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_Filter = value;
			darkUICheckBox = _CB_Filter;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	public string OldErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((ContainerControl)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
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
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected O, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Expected O, but got Unknown
		//IL_1797: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a1: Expected O, but got Unknown
		//IL_17e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1855: Unknown result type (might be due to invalid IL or missing references)
		//IL_185f: Expected O, but got Unknown
		//IL_18a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1913: Unknown result type (might be due to invalid IL or missing references)
		//IL_191d: Expected O, but got Unknown
		//IL_195e: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19de: Expected O, but got Unknown
		//IL_1a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9f: Expected O, but got Unknown
		//IL_1adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5c: Expected O, but got Unknown
		//IL_1b9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c1a: Expected O, but got Unknown
		//IL_1c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd8: Expected O, but got Unknown
		//IL_1d16: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d93: Expected O, but got Unknown
		//IL_1dd0: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		DataGridViewCellStyle val10 = new DataGridViewCellStyle();
		DataGridViewCellStyle val11 = new DataGridViewCellStyle();
		DataGridViewCellStyle val12 = new DataGridViewCellStyle();
		DataGridViewCellStyle val13 = new DataGridViewCellStyle();
		DataGridViewCellStyle val14 = new DataGridViewCellStyle();
		DataGridViewCellStyle val15 = new DataGridViewCellStyle();
		DataGridViewCellStyle val16 = new DataGridViewCellStyle();
		DataGridViewCellStyle val17 = new DataGridViewCellStyle();
		DataGridViewCellStyle val18 = new DataGridViewCellStyle();
		DataGridViewCellStyle val19 = new DataGridViewCellStyle();
		DGV_Waypoints = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		ObjectID = new DataGridViewTextBoxColumn();
		Type = new DataGridViewComboBoxColumn();
		Time_Zulu = new DataGridViewTextBoxColumn();
		Time_Local = new DataGridViewTextBoxColumn();
		TimeFixedImg = new DataGridViewImageColumn();
		TimeFixed = new DataGridViewTextBoxColumn();
		DesiredSpeed = new DataGridViewTextBoxColumn();
		SpeedFixedImg = new DataGridViewImageColumn();
		SpeedFixed = new DataGridViewTextBoxColumn();
		DesiredAltitude = new DataGridViewTextBoxColumn();
		Leg_Distance = new DataGridViewTextBoxColumn();
		Leg_TotalDistance = new DataGridViewTextBoxColumn();
		Leg_Time = new DataGridViewTextBoxColumn();
		Hold_Time = new DataGridViewTextBoxColumn();
		Leg_TotalTime = new DataGridViewTextBoxColumn();
		Leg_FuelRequired = new DataGridViewTextBoxColumn();
		Leg_FuelRemaining = new DataGridViewTextBoxColumn();
		SpeedToT = new DataGridViewComboBoxColumn();
		Formation = new DataGridViewComboBoxColumn();
		AARUsage = new DataGridViewComboBoxColumn();
		AARSelection = new DataGridViewComboBoxColumn();
		AARSettings = new DataGridViewTextBoxColumn();
		SensorUsage = new DataGridViewTextBoxColumn();
		Doctrine = new DataGridViewTextBoxColumn();
		TurnRate = new DataGridViewComboBoxColumn();
		Coordinates = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
		CB_Filter = new DarkUICheckBox();
		Button_EditTargetAndWeapons = new DarkUIButton();
		Button_ClearTime = new DarkUIButton();
		Button_EditAAR = new DarkUIButton();
		Button_EditSensorUsage = new DarkUIButton();
		Button_EditDoctrine = new DarkUIButton();
		Button_EditSpeedAltitude = new DarkUIButton();
		Button_EditTime = new DarkUIButton();
		Button_DeleteWaypoint = new DarkUIButton();
		Button_InsertWaypoint = new DarkUIButton();
		((ISupportInitialize)(object)DGV_Waypoints).BeginInit();
		((Control)this).SuspendLayout();
		((DataGridView)DGV_Waypoints).AllowUserToAddRows = false;
		((DataGridView)DGV_Waypoints).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Waypoints).AllowUserToOrderColumns = true;
		((DataGridView)DGV_Waypoints).AllowUserToResizeColumns = false;
		((DataGridView)DGV_Waypoints).AllowUserToResizeRows = false;
		((Control)DGV_Waypoints).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_Waypoints).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Waypoints).BorderStyle = (BorderStyle)0;
		((DataGridView)DGV_Waypoints).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Waypoints).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.BackColor = SystemColors.Control;
		val.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		val.ForeColor = SystemColors.WindowText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Waypoints).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_Waypoints).ColumnHeadersHeight = 18;
		((DataGridView)DGV_Waypoints).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[27]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)ObjectID,
			(DataGridViewColumn)Type,
			(DataGridViewColumn)Time_Zulu,
			(DataGridViewColumn)Time_Local,
			(DataGridViewColumn)TimeFixedImg,
			(DataGridViewColumn)TimeFixed,
			(DataGridViewColumn)DesiredSpeed,
			(DataGridViewColumn)SpeedFixedImg,
			(DataGridViewColumn)SpeedFixed,
			(DataGridViewColumn)DesiredAltitude,
			(DataGridViewColumn)Leg_Distance,
			(DataGridViewColumn)Leg_TotalDistance,
			(DataGridViewColumn)Leg_Time,
			(DataGridViewColumn)Hold_Time,
			(DataGridViewColumn)Leg_TotalTime,
			(DataGridViewColumn)Leg_FuelRequired,
			(DataGridViewColumn)Leg_FuelRemaining,
			(DataGridViewColumn)SpeedToT,
			(DataGridViewColumn)Formation,
			(DataGridViewColumn)AARUsage,
			(DataGridViewColumn)AARSelection,
			(DataGridViewColumn)AARSettings,
			(DataGridViewColumn)SensorUsage,
			(DataGridViewColumn)Doctrine,
			(DataGridViewColumn)TurnRate,
			(DataGridViewColumn)Coordinates
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		val2.ForeColor = SystemColors.ControlText;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Waypoints).DefaultCellStyle = val2;
		((DataGridView)DGV_Waypoints).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_Waypoints).EnableHeadersVisualStyles = false;
		((Control)DGV_Waypoints).Location = new Point(0, 21);
		((Control)DGV_Waypoints).Name = "DGV_Waypoints";
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Control;
		val3.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = SystemColors.WindowText;
		val3.SelectionBackColor = SystemColors.Highlight;
		val3.SelectionForeColor = SystemColors.HighlightText;
		val3.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Waypoints).RowHeadersDefaultCellStyle = val3;
		((DataGridView)DGV_Waypoints).RowHeadersVisible = false;
		((DataGridView)DGV_Waypoints).RowHeadersWidth = 10;
		val4.BackColor = Color.FromArgb(60, 63, 65);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Waypoints).RowsDefaultCellStyle = val4;
		((DataGridView)DGV_Waypoints).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_Waypoints).Size = new Size(589, 282);
		((Control)DGV_Waypoints).TabIndex = 10;
		((DataGridViewColumn)ID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)4;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		val5.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)ID).DefaultCellStyle = val5;
		((DataGridViewColumn)ID).Frozen = true;
		((DataGridViewColumn)ID).HeaderText = "#";
		((DataGridViewColumn)ID).MinimumWidth = 8;
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Width = 8;
		((DataGridViewColumn)ObjectID).DataPropertyName = "ObjectID";
		((DataGridViewColumn)ObjectID).HeaderText = "ObjectID";
		((DataGridViewColumn)ObjectID).MinimumWidth = 8;
		((DataGridViewColumn)ObjectID).Name = "ObjectID";
		((DataGridViewColumn)ObjectID).Visible = false;
		((DataGridViewColumn)ObjectID).Width = 150;
		Type.AutoComplete = false;
		((DataGridViewColumn)Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Type).DataPropertyName = "Type";
		Type.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)Type).Frozen = true;
		((DataGridViewColumn)Type).HeaderText = "Type";
		Type.MaxDropDownItems = 20;
		((DataGridViewColumn)Type).MinimumWidth = 8;
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)Type).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)Type).Width = 79;
		((DataGridViewColumn)Time_Zulu).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Time_Zulu).DataPropertyName = "Time_Zulu";
		val6.Alignment = (DataGridViewContentAlignment)512;
		((DataGridViewColumn)Time_Zulu).DefaultCellStyle = val6;
		((DataGridViewColumn)Time_Zulu).HeaderText = "Zulu Time";
		((DataGridViewColumn)Time_Zulu).MinimumWidth = 8;
		((DataGridViewColumn)Time_Zulu).Name = "Time_Zulu";
		((DataGridViewColumn)Time_Zulu).ReadOnly = true;
		((DataGridViewColumn)Time_Zulu).Width = 120;
		((DataGridViewColumn)Time_Local).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Time_Local).DataPropertyName = "Time_Local";
		val7.Alignment = (DataGridViewContentAlignment)512;
		((DataGridViewColumn)Time_Local).DefaultCellStyle = val7;
		((DataGridViewColumn)Time_Local).HeaderText = "Local Time";
		((DataGridViewColumn)Time_Local).MinimumWidth = 8;
		((DataGridViewColumn)Time_Local).Name = "Time_Local";
		((DataGridViewColumn)Time_Local).ReadOnly = true;
		((DataGridViewColumn)Time_Local).Width = 125;
		((DataGridViewColumn)TimeFixedImg).AutoSizeMode = (DataGridViewAutoSizeColumnMode)4;
		((DataGridViewColumn)TimeFixedImg).DataPropertyName = "TimeFixedImg";
		((DataGridViewColumn)TimeFixedImg).HeaderText = " ";
		((DataGridViewColumn)TimeFixedImg).MinimumWidth = 8;
		((DataGridViewColumn)TimeFixedImg).Name = "TimeFixedImg";
		((DataGridViewColumn)TimeFixedImg).Width = 8;
		((DataGridViewColumn)TimeFixed).DataPropertyName = "TimeFixed";
		((DataGridViewColumn)TimeFixed).HeaderText = "TimeFixed";
		((DataGridViewColumn)TimeFixed).MinimumWidth = 8;
		((DataGridViewColumn)TimeFixed).Name = "TimeFixed";
		((DataGridViewColumn)TimeFixed).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)TimeFixed).Visible = false;
		((DataGridViewColumn)TimeFixed).Width = 8;
		((DataGridViewColumn)DesiredSpeed).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DesiredSpeed).DataPropertyName = "DesiredSpeed";
		val8.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)DesiredSpeed).DefaultCellStyle = val8;
		((DataGridViewColumn)DesiredSpeed).HeaderText = " Speed";
		((DataGridViewColumn)DesiredSpeed).MinimumWidth = 8;
		((DataGridViewColumn)DesiredSpeed).Name = "DesiredSpeed";
		((DataGridViewColumn)DesiredSpeed).ReadOnly = true;
		((DataGridViewColumn)DesiredSpeed).Width = 96;
		((DataGridViewColumn)SpeedFixedImg).AutoSizeMode = (DataGridViewAutoSizeColumnMode)4;
		((DataGridViewColumn)SpeedFixedImg).DataPropertyName = "SpeedFixedImg";
		((DataGridViewColumn)SpeedFixedImg).HeaderText = " ";
		((DataGridViewColumn)SpeedFixedImg).MinimumWidth = 8;
		((DataGridViewColumn)SpeedFixedImg).Name = "SpeedFixedImg";
		((DataGridViewColumn)SpeedFixedImg).Width = 8;
		((DataGridViewColumn)SpeedFixed).DataPropertyName = "SpeedFixed";
		val9.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)SpeedFixed).DefaultCellStyle = val9;
		((DataGridViewColumn)SpeedFixed).HeaderText = "SpeedFixed";
		((DataGridViewColumn)SpeedFixed).MinimumWidth = 8;
		((DataGridViewColumn)SpeedFixed).Name = "SpeedFixed";
		((DataGridViewColumn)SpeedFixed).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)SpeedFixed).Visible = false;
		((DataGridViewColumn)SpeedFixed).Width = 8;
		((DataGridViewColumn)DesiredAltitude).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DesiredAltitude).DataPropertyName = "DesiredAltitude";
		val10.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)DesiredAltitude).DefaultCellStyle = val10;
		((DataGridViewColumn)DesiredAltitude).HeaderText = "Altitude";
		((DataGridViewColumn)DesiredAltitude).MinimumWidth = 8;
		((DataGridViewColumn)DesiredAltitude).Name = "DesiredAltitude";
		((DataGridViewColumn)DesiredAltitude).ReadOnly = true;
		((DataGridViewColumn)DesiredAltitude).Width = 104;
		((DataGridViewColumn)Leg_Distance).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_Distance).DataPropertyName = "Leg_Distance";
		val11.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_Distance).DefaultCellStyle = val11;
		((DataGridViewColumn)Leg_Distance).HeaderText = "Leg Distance";
		((DataGridViewColumn)Leg_Distance).MinimumWidth = 8;
		((DataGridViewColumn)Leg_Distance).Name = "Leg_Distance";
		((DataGridViewColumn)Leg_Distance).Width = 141;
		((DataGridViewColumn)Leg_TotalDistance).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_TotalDistance).DataPropertyName = "Leg_TotalDistance";
		val12.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_TotalDistance).DefaultCellStyle = val12;
		((DataGridViewColumn)Leg_TotalDistance).HeaderText = "Total Distance";
		((DataGridViewColumn)Leg_TotalDistance).MinimumWidth = 8;
		((DataGridViewColumn)Leg_TotalDistance).Name = "Leg_TotalDistance";
		((DataGridViewColumn)Leg_TotalDistance).Width = 150;
		((DataGridViewColumn)Leg_Time).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_Time).DataPropertyName = "Leg_Time";
		val13.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_Time).DefaultCellStyle = val13;
		((DataGridViewColumn)Leg_Time).HeaderText = "Leg Time";
		((DataGridViewColumn)Leg_Time).MinimumWidth = 8;
		((DataGridViewColumn)Leg_Time).Name = "Leg_Time";
		((DataGridViewColumn)Leg_Time).ToolTipText = "Time needed to fly this leg.";
		((DataGridViewColumn)Leg_Time).Width = 113;
		((DataGridViewColumn)Hold_Time).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Hold_Time).DataPropertyName = "Hold_Time";
		val14.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Hold_Time).DefaultCellStyle = val14;
		((DataGridViewColumn)Hold_Time).HeaderText = "Hold Time";
		((DataGridViewColumn)Hold_Time).MinimumWidth = 8;
		((DataGridViewColumn)Hold_Time).Name = "Hold_Time";
		((DataGridViewColumn)Hold_Time).ToolTipText = "Loiter time at waypoint to allow flight to form up (Push Point).";
		((DataGridViewColumn)Hold_Time).Width = 122;
		((DataGridViewColumn)Leg_TotalTime).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_TotalTime).DataPropertyName = "Leg_TotalTime";
		val15.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_TotalTime).DefaultCellStyle = val15;
		((DataGridViewColumn)Leg_TotalTime).HeaderText = "Total Time";
		((DataGridViewColumn)Leg_TotalTime).MinimumWidth = 8;
		((DataGridViewColumn)Leg_TotalTime).Name = "Leg_TotalTime";
		((DataGridViewColumn)Leg_TotalTime).Width = 122;
		((DataGridViewColumn)Leg_FuelRequired).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_FuelRequired).DataPropertyName = "Leg_FuelRequired";
		val16.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_FuelRequired).DefaultCellStyle = val16;
		((DataGridViewColumn)Leg_FuelRequired).HeaderText = "Leg Fuel";
		((DataGridViewColumn)Leg_FuelRequired).MinimumWidth = 8;
		((DataGridViewColumn)Leg_FuelRequired).Name = "Leg_FuelRequired";
		((DataGridViewColumn)Leg_FuelRequired).ToolTipText = "Fuel neeed to fly this leg.";
		((DataGridViewColumn)Leg_FuelRequired).Width = 107;
		((DataGridViewColumn)Leg_FuelRemaining).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_FuelRemaining).DataPropertyName = "Leg_FuelRemaining";
		val17.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_FuelRemaining).DefaultCellStyle = val17;
		((DataGridViewColumn)Leg_FuelRemaining).HeaderText = "Remaining Fuel";
		((DataGridViewColumn)Leg_FuelRemaining).MinimumWidth = 8;
		((DataGridViewColumn)Leg_FuelRemaining).Name = "Leg_FuelRemaining";
		((DataGridViewColumn)Leg_FuelRemaining).ToolTipText = "Remaining mission fuel (i.e. total fuel minus reserves) after this leg has been completed.";
		((DataGridViewColumn)Leg_FuelRemaining).Width = 161;
		SpeedToT.AutoComplete = false;
		((DataGridViewColumn)SpeedToT).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)SpeedToT).DataPropertyName = "SpeedToT";
		SpeedToT.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)SpeedToT).HeaderText = "Adjust Speed for ToT";
		((DataGridViewColumn)SpeedToT).MinimumWidth = 8;
		((DataGridViewColumn)SpeedToT).Name = "SpeedToT";
		((DataGridViewColumn)SpeedToT).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)SpeedToT).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)SpeedToT).Width = 201;
		Formation.AutoComplete = false;
		((DataGridViewColumn)Formation).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Formation).DataPropertyName = "Formation";
		Formation.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)Formation).HeaderText = "Formation";
		((DataGridViewColumn)Formation).MinimumWidth = 8;
		((DataGridViewColumn)Formation).Name = "Formation";
		((DataGridViewColumn)Formation).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)Formation).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)Formation).Width = 122;
		AARUsage.AutoComplete = false;
		((DataGridViewColumn)AARUsage).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)AARUsage).DataPropertyName = "AARUsage";
		AARUsage.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)AARUsage).HeaderText = "Tankers (AAR)";
		((DataGridViewColumn)AARUsage).MinimumWidth = 8;
		((DataGridViewColumn)AARUsage).Name = "AARUsage";
		((DataGridViewColumn)AARUsage).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)AARUsage).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)AARUsage).Width = 147;
		AARSelection.AutoComplete = false;
		((DataGridViewColumn)AARSelection).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)AARSelection).DataPropertyName = "AARSelection";
		AARSelection.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)AARSelection).HeaderText = "Tanker Selection";
		((DataGridViewColumn)AARSelection).MinimumWidth = 8;
		((DataGridViewColumn)AARSelection).Name = "AARSelection";
		((DataGridViewColumn)AARSelection).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)AARSelection).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)AARSelection).Width = 167;
		((DataGridViewColumn)AARSettings).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)AARSettings).DataPropertyName = "AARSettings";
		((DataGridViewColumn)AARSettings).HeaderText = "Tanker Planner Settings";
		((DataGridViewColumn)AARSettings).MinimumWidth = 8;
		((DataGridViewColumn)AARSettings).Name = "AARSettings";
		((DataGridViewColumn)AARSettings).ReadOnly = true;
		((DataGridViewColumn)AARSettings).Width = 222;
		((DataGridViewColumn)SensorUsage).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)SensorUsage).DataPropertyName = "SensorUsage";
		((DataGridViewColumn)SensorUsage).HeaderText = "Sensor Usage";
		((DataGridViewColumn)SensorUsage).MinimumWidth = 8;
		((DataGridViewColumn)SensorUsage).Name = "SensorUsage";
		((DataGridViewColumn)SensorUsage).Width = 147;
		((DataGridViewColumn)Doctrine).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Doctrine).DataPropertyName = "Doctrine";
		((DataGridViewColumn)Doctrine).HeaderText = "Doctrine / EMCON / WRA";
		((DataGridViewColumn)Doctrine).MinimumWidth = 8;
		((DataGridViewColumn)Doctrine).Name = "Doctrine";
		((DataGridViewColumn)Doctrine).Width = 241;
		TurnRate.AutoComplete = false;
		((DataGridViewColumn)TurnRate).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)TurnRate).DataPropertyName = "TurnRate";
		TurnRate.FlatStyle = (FlatStyle)0;
		((DataGridViewColumn)TurnRate).HeaderText = "Turn Rate";
		((DataGridViewColumn)TurnRate).MinimumWidth = 8;
		((DataGridViewColumn)TurnRate).Name = "TurnRate";
		((DataGridViewColumn)TurnRate).Width = 88;
		((DataGridViewColumn)Coordinates).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Coordinates).DataPropertyName = "Coordinates";
		((DataGridViewColumn)Coordinates).HeaderText = "Coordinates";
		((DataGridViewColumn)Coordinates).MinimumWidth = 8;
		((DataGridViewColumn)Coordinates).Name = "Coordinates";
		((DataGridViewColumn)Coordinates).Width = 136;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).DataPropertyName = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Frozen = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "Wpt";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).DataPropertyName = "Time_Zulu";
		val18.Alignment = (DataGridViewContentAlignment)512;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).DefaultCellStyle = val18;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).HeaderText = "Zulu";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Name = "DataGridViewTextBoxColumn2";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).DataPropertyName = "Time_Local";
		val19.Alignment = (DataGridViewContentAlignment)512;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).DefaultCellStyle = val19;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).HeaderText = "Local";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Name = "DataGridViewTextBoxColumn3";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).DataPropertyName = "TimeFixed";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).HeaderText = "TimeFixed";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Name = "DataGridViewTextBoxColumn4";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Visible = false;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Width = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn5).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn5).DataPropertyName = "DesiredSpeed";
		((DataGridViewColumn)DataGridViewTextBoxColumn5).HeaderText = " ";
		((DataGridViewColumn)DataGridViewTextBoxColumn5).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn5).Name = "DataGridViewTextBoxColumn5";
		((DataGridViewColumn)DataGridViewTextBoxColumn5).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn5).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn6).DataPropertyName = "SpeedFixed";
		((DataGridViewColumn)DataGridViewTextBoxColumn6).HeaderText = "SpeedFixed";
		((DataGridViewColumn)DataGridViewTextBoxColumn6).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn6).Name = "DataGridViewTextBoxColumn6";
		((DataGridViewColumn)DataGridViewTextBoxColumn6).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)DataGridViewTextBoxColumn6).Visible = false;
		((DataGridViewColumn)DataGridViewTextBoxColumn6).Width = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn7).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn7).DataPropertyName = "DesiredAltitude";
		((DataGridViewColumn)DataGridViewTextBoxColumn7).HeaderText = "DesiredAltitude";
		((DataGridViewColumn)DataGridViewTextBoxColumn7).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn7).Name = "DataGridViewTextBoxColumn7";
		((DataGridViewColumn)DataGridViewTextBoxColumn7).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn7).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn8).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn8).DataPropertyName = "AARSettings";
		((DataGridViewColumn)DataGridViewTextBoxColumn8).HeaderText = "AARSettings";
		((DataGridViewColumn)DataGridViewTextBoxColumn8).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn8).Name = "DataGridViewTextBoxColumn8";
		((DataGridViewColumn)DataGridViewTextBoxColumn8).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn8).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn9).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn9).DataPropertyName = "Doctrine";
		((DataGridViewColumn)DataGridViewTextBoxColumn9).HeaderText = "Doctrine / EMCON / WRA";
		((DataGridViewColumn)DataGridViewTextBoxColumn9).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn9).Name = "DataGridViewTextBoxColumn9";
		((DataGridViewColumn)DataGridViewTextBoxColumn9).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn10).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn10).DataPropertyName = "SensorUsage";
		((DataGridViewColumn)DataGridViewTextBoxColumn10).HeaderText = "Sensor Usage";
		((DataGridViewColumn)DataGridViewTextBoxColumn10).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn10).Name = "DataGridViewTextBoxColumn10";
		((DataGridViewColumn)DataGridViewTextBoxColumn10).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn11).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DataGridViewTextBoxColumn11).DataPropertyName = "Coordinates";
		((DataGridViewColumn)DataGridViewTextBoxColumn11).HeaderText = "Coordinates";
		((DataGridViewColumn)DataGridViewTextBoxColumn11).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn11).Name = "DataGridViewTextBoxColumn11";
		((DataGridViewColumn)DataGridViewTextBoxColumn11).Width = 150;
		((ButtonBase)CB_Filter).AutoSize = true;
		((ButtonBase)CB_Filter).BackColor = Color.Transparent;
		((CheckBox)CB_Filter).Checked = true;
		((CheckBox)CB_Filter).CheckState = (CheckState)1;
		((Control)CB_Filter).Cursor = Cursors.Hand;
		((Control)CB_Filter).Dock = (DockStyle)1;
		((Control)CB_Filter).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_Filter).Location = new Point(0, 0);
		((Control)CB_Filter).Name = "CB_Filter";
		((Control)CB_Filter).Size = new Size(589, 24);
		((Control)CB_Filter).TabIndex = 22;
		((ButtonBase)CB_Filter).Text = "Visible on map";
		((Control)Button_EditTargetAndWeapons).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_EditTargetAndWeapons).BackColor = Color.Transparent;
		((Control)Button_EditTargetAndWeapons).Font = new Font("Segoe UI", 8f);
		((Control)Button_EditTargetAndWeapons).ForeColor = SystemColors.Control;
		((Control)Button_EditTargetAndWeapons).Location = new Point(494, 305);
		((Control)Button_EditTargetAndWeapons).Name = "Button_EditTargetAndWeapons";
		((Control)Button_EditTargetAndWeapons).Padding = new Padding(5);
		Button_EditTargetAndWeapons.RoundRadius = 0;
		((Control)Button_EditTargetAndWeapons).Size = new Size(92, 48);
		((Control)Button_EditTargetAndWeapons).TabIndex = 21;
		Button_EditTargetAndWeapons.Text = "Targeteering & Weaponeering";
		((Control)Button_ClearTime).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ClearTime).BackColor = Color.Transparent;
		((Control)Button_ClearTime).Font = new Font("Segoe UI", 8f);
		((Control)Button_ClearTime).ForeColor = SystemColors.Control;
		((Control)Button_ClearTime).Location = new Point(423, 305);
		((Control)Button_ClearTime).Name = "Button_ClearTime";
		((Control)Button_ClearTime).Padding = new Padding(5);
		Button_ClearTime.RoundRadius = 0;
		((Control)Button_ClearTime).Size = new Size(70, 24);
		((Control)Button_ClearTime).TabIndex = 21;
		Button_ClearTime.Text = "Clear Time";
		((Control)Button_EditAAR).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_EditAAR).BackColor = Color.Transparent;
		((Control)Button_EditAAR).Font = new Font("Segoe UI", 8f);
		((Control)Button_EditAAR).ForeColor = SystemColors.Control;
		((Control)Button_EditAAR).Location = new Point(174, 329);
		((Control)Button_EditAAR).Name = "Button_EditAAR";
		((Control)Button_EditAAR).Padding = new Padding(5);
		Button_EditAAR.RoundRadius = 0;
		((Control)Button_EditAAR).Size = new Size(174, 24);
		((Control)Button_EditAAR).TabIndex = 20;
		Button_EditAAR.Text = "Edit Air-to-Air Refuelling Settings";
		((Control)Button_EditSensorUsage).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_EditSensorUsage).BackColor = Color.Transparent;
		((Control)Button_EditSensorUsage).Font = new Font("Segoe UI", 8f);
		((Control)Button_EditSensorUsage).ForeColor = SystemColors.Control;
		((Control)Button_EditSensorUsage).Location = new Point(349, 329);
		((Control)Button_EditSensorUsage).Name = "Button_EditSensorUsage";
		((Control)Button_EditSensorUsage).Padding = new Padding(5);
		Button_EditSensorUsage.RoundRadius = 0;
		((Control)Button_EditSensorUsage).Size = new Size(144, 24);
		((Control)Button_EditSensorUsage).TabIndex = 19;
		Button_EditSensorUsage.Text = "Edit Sensor Usage";
		((Control)Button_EditDoctrine).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_EditDoctrine).BackColor = Color.Transparent;
		((Control)Button_EditDoctrine).Font = new Font("Segoe UI", 8f);
		((Control)Button_EditDoctrine).ForeColor = SystemColors.Control;
		((Control)Button_EditDoctrine).Location = new Point(-1, 329);
		((Control)Button_EditDoctrine).Name = "Button_EditDoctrine";
		((Control)Button_EditDoctrine).Padding = new Padding(5);
		Button_EditDoctrine.RoundRadius = 0;
		((Control)Button_EditDoctrine).Size = new Size(174, 24);
		((Control)Button_EditDoctrine).TabIndex = 18;
		Button_EditDoctrine.Text = "Edit Doctrine / EMCON / WRA";
		((Control)Button_EditSpeedAltitude).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_EditSpeedAltitude).BackColor = Color.Transparent;
		((Control)Button_EditSpeedAltitude).Font = new Font("Segoe UI", 8f);
		((Control)Button_EditSpeedAltitude).ForeColor = SystemColors.Control;
		((Control)Button_EditSpeedAltitude).Location = new Point(191, 305);
		((Control)Button_EditSpeedAltitude).Name = "Button_EditSpeedAltitude";
		((Control)Button_EditSpeedAltitude).Padding = new Padding(5);
		Button_EditSpeedAltitude.RoundRadius = 0;
		((Control)Button_EditSpeedAltitude).Size = new Size(115, 24);
		((Control)Button_EditSpeedAltitude).TabIndex = 17;
		Button_EditSpeedAltitude.Text = "Edit Speed / Altitude";
		((Control)Button_EditTime).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_EditTime).BackColor = Color.Transparent;
		((Control)Button_EditTime).Font = new Font("Segoe UI", 8f);
		((Control)Button_EditTime).ForeColor = SystemColors.Control;
		((Control)Button_EditTime).Location = new Point(307, 305);
		((Control)Button_EditTime).Name = "Button_EditTime";
		((Control)Button_EditTime).Padding = new Padding(5);
		Button_EditTime.RoundRadius = 0;
		((Control)Button_EditTime).Size = new Size(115, 24);
		((Control)Button_EditTime).TabIndex = 16;
		Button_EditTime.Text = "Edit Time";
		((Control)Button_DeleteWaypoint).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_DeleteWaypoint).BackColor = Color.Transparent;
		((Control)Button_DeleteWaypoint).Font = new Font("Segoe UI", 8f);
		((Control)Button_DeleteWaypoint).ForeColor = SystemColors.Control;
		((Control)Button_DeleteWaypoint).Location = new Point(95, 305);
		((Control)Button_DeleteWaypoint).Name = "Button_DeleteWaypoint";
		((Control)Button_DeleteWaypoint).Padding = new Padding(5);
		Button_DeleteWaypoint.RoundRadius = 0;
		((Control)Button_DeleteWaypoint).Size = new Size(95, 24);
		((Control)Button_DeleteWaypoint).TabIndex = 13;
		Button_DeleteWaypoint.Text = "Delete Waypoint";
		((Control)Button_InsertWaypoint).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_InsertWaypoint).BackColor = Color.Transparent;
		((Control)Button_InsertWaypoint).Font = new Font("Segoe UI", 8f);
		((Control)Button_InsertWaypoint).ForeColor = SystemColors.Control;
		((Control)Button_InsertWaypoint).Location = new Point(-1, 305);
		((Control)Button_InsertWaypoint).Name = "Button_InsertWaypoint";
		((Control)Button_InsertWaypoint).Padding = new Padding(5);
		Button_InsertWaypoint.RoundRadius = 0;
		((Control)Button_InsertWaypoint).Size = new Size(95, 24);
		((Control)Button_InsertWaypoint).TabIndex = 12;
		Button_InsertWaypoint.Text = "Insert Waypoint";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).BackColor = Color.FromArgb(60, 63, 65);
		((Control)this).Controls.Add((Control)(object)CB_Filter);
		((Control)this).Controls.Add((Control)(object)Button_EditTargetAndWeapons);
		((Control)this).Controls.Add((Control)(object)Button_ClearTime);
		((Control)this).Controls.Add((Control)(object)Button_EditAAR);
		((Control)this).Controls.Add((Control)(object)Button_EditSensorUsage);
		((Control)this).Controls.Add((Control)(object)Button_EditDoctrine);
		((Control)this).Controls.Add((Control)(object)Button_EditSpeedAltitude);
		((Control)this).Controls.Add((Control)(object)Button_EditTime);
		((Control)this).Controls.Add((Control)(object)Button_DeleteWaypoint);
		((Control)this).Controls.Add((Control)(object)Button_InsertWaypoint);
		((Control)this).Controls.Add((Control)(object)DGV_Waypoints);
		((Control)this).Name = "FlightPlanWaypoints";
		((Control)this).Size = new Size(589, 352);
		((ISupportInitialize)(object)DGV_Waypoints).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public FlightPlanWaypoints()
	{
		InitializeComponent();
		((Control)CB_Filter).Visible = GameGeneral.EnableLoadoutFilter;
		((Control)CB_Filter).Enabled = GameGeneral.EnableLoadoutFilter;
	}

	private void method_0(object sender, EventArgs e)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Invalid comparison between Unknown and I4
		try
		{
			_Closure$__205-0 arg = default(_Closure$__205-0);
			_Closure$__205-0 CS$<>8__locals9 = new _Closure$__205-0(arg);
			int count = ((DataGridView)DGV_Waypoints).Rows.Count;
			bool flag = false;
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow val = ((DataGridView)DGV_Waypoints).Rows[i];
				if (!val.Selected)
				{
					continue;
				}
				CS$<>8__locals9.$VB$Local_theWaypoint = (Waypoint)((DataGridViewBand)val).Tag;
				if (CS$<>8__locals9.$VB$Local_theWaypoint.IsStationStartWaypoint() || CS$<>8__locals9.$VB$Local_theWaypoint.IsHoldStartWaypoint())
				{
					((Form)new DarkMessageBox("Cannot insert a new waypoint between Start and End Station waypoints!")).ShowDialog();
					continue;
				}
				if (FlightPlan_Element != Mission.Flight.FlightElement.LeadElement)
				{
					CS$<>8__locals9.$VB$Local_theWaypoint = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[i];
				}
				if (CS$<>8__locals9.$VB$Local_theWaypoint.IsSplitWaypoint())
				{
					((Form)new DarkMessageBox("Cannot insert waypoints with Split formation. Change the formation and try again.")).ShowDialog();
					return;
				}
				List<Mission.Flight> list = new List<Mission.Flight>();
				if (Client.FlightPlanEditorWindow.SelectedMission.FlightList.Count <= 1)
				{
					list.Add(Client.FlightPlanEditorWindow.SelectedFlight);
				}
				else if ((int)DarkMessageBox.ShowInformation("Would you like to insert the Waypoint for all the flights in this mission?", "Multiple Wp addition", DarkDialogButton.YesNo) == 6)
				{
					list = Client.FlightPlanEditorWindow.SelectedMission.FlightList;
				}
				else
				{
					list.Add(Client.FlightPlanEditorWindow.SelectedFlight);
				}
				foreach (Mission.Flight item in list)
				{
					Waypoint waypoint = item.FlightPlan.Where((CS$<>8__locals9.$I0 != null) ? CS$<>8__locals9.$I0 : (CS$<>8__locals9.$I0 = [SpecialName] (Waypoint x) => Operators.CompareString(x.Description, CS$<>8__locals9.$VB$Local_theWaypoint.Description, true) == 0)).FirstOrDefault();
					if (waypoint != null)
					{
						if (Client.Realtime && !Client.RealtimeAC)
						{
							Client.RealtimeTerminal.SendChangeFlightInsertWaypointAfter(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, item, FlightPlan_Element, waypoint);
							continue;
						}
						CoreClientCode.ChangeFightPlanInsertWaypoint_Core(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, item, FlightPlan_Element, waypoint);
						flag = true;
					}
				}
				break;
			}
			if (flag)
			{
				if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count > 0)
				{
					Client.FlightPlanEditorWindow.SelectedRow = ((DataGridViewBand)((DataGridView)DGV_Waypoints).SelectedRows[0]).Index;
					Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)DGV_Waypoints).Rows[Client.FlightPlanEditorWindow.SelectedRow]).Tag;
					((DataGridView)DGV_Waypoints).Rows[0].Selected = false;
				}
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_Limited: true, RefreshFlightplanEditorWindow_ReloadhGrid: true, RefreshFlightplanEditorWindow_DrawLocks: false);
				if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
				{
					FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
					ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
					FlightPlanEditor flightPlanEditorWindow;
					Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
					FlightPlanEditor flightPlanEditorWindow2;
					Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
					flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
					flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
					flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
				}
				if (((Control)Client.AirTaskingOrderWindow).Visible)
				{
					Client.AirTaskingOrderWindow.RefreshWindow();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count == 0)
			{
				return;
			}
			for (int i = ((DataGridView)DGV_Waypoints).Rows.Count - 1; i >= 0; i += -1)
			{
				DataGridViewRow val = ((DataGridView)DGV_Waypoints).Rows[i];
				if (!val.Selected)
				{
					continue;
				}
				Waypoint waypoint = (Waypoint)((DataGridViewBand)val).Tag;
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
					if (FlightPlan_Element != Mission.Flight.FlightElement.LeadElement)
					{
						waypoint = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[i];
					}
					if (!waypoint.IsSplitWaypoint())
					{
						if (Client.Realtime && !Client.RealtimeAC)
						{
							if (Client.SelectedWaypoint != null && Operators.CompareString(Client.SelectedWaypoint.ObjectID, waypoint.ObjectID, true) == 0)
							{
								method_18(null);
							}
							Client.RealtimeTerminal.SendChangeFlightPlanDeleteWaypoint(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint);
						}
						else
						{
							CoreClientCode.ChangeFightPlanDeleteWaypoint_Core(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint);
							flag = true;
						}
					}
					else
					{
						((Form)new DarkMessageBox("Cannot delete waypoints with Split formation. Change the formation and try again.")).ShowDialog();
					}
					continue;
				}
				if (!waypoint.IsHoldWaypoint())
				{
					if (!waypoint.IsStationWaypoint())
					{
						((Form)new DarkMessageBox("Cannot delete waypoint!")).ShowDialog();
					}
					else
					{
						((Form)new DarkMessageBox("Cannot delete a Station Start or Station End waypoint!")).ShowDialog();
					}
				}
				else
				{
					((Form)new DarkMessageBox("Cannot delete a Hold Start or Hold End waypoint!")).ShowDialog();
				}
			}
			if (flag)
			{
				if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count > 0)
				{
					Client.FlightPlanEditorWindow.SelectedRow = ((DataGridViewBand)((DataGridView)DGV_Waypoints).SelectedRows[0]).Index;
					Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)DGV_Waypoints).Rows[Client.FlightPlanEditorWindow.SelectedRow]).Tag;
					((DataGridView)DGV_Waypoints).Rows[0].Selected = false;
				}
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_Limited: true, RefreshFlightplanEditorWindow_ReloadhGrid: true, RefreshFlightplanEditorWindow_DrawLocks: false);
				if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
				{
					FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
					ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
					FlightPlanEditor flightPlanEditorWindow;
					Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
					FlightPlanEditor flightPlanEditorWindow2;
					Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
					flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
					flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
					flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
				}
				if (((Control)Client.AirTaskingOrderWindow).Visible)
				{
					Client.AirTaskingOrderWindow.RefreshWindow();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		try
		{
			FlightPlanEditor.DoNotNotifyFlightError = true;
			Waypoint waypoint = default(Waypoint);
			for (int i = ((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows.Count - 1; i >= 0; i += -1)
			{
				DataGridViewRow val = ((DataGridView)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints).Rows[i];
				if (val.Selected)
				{
					waypoint = (Waypoint)((DataGridViewBand)val).Tag;
					break;
				}
			}
			if (Information.IsNothing((object)waypoint) || (Client.FlightPlanEditorWindow.SelectedFlight.Type == Mission._FlightType.FlightplanTemplate && !waypoint.IsStationEndWaypoint()))
			{
				return;
			}
			Client.FlightPlanTimeWindow.ViaFlightPlanEditor = true;
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow;
			Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2;
			Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
			flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
			flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
			((Control)Client.FlightPlanTimeWindow).Show();
			((Control)Client.FlightPlanTimeWindow).BringToFront();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 78364648fbfgsf", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int doNotNotifyFlightError;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				doNotNotifyFlightError = 0;
			}
			else
			{
				doNotNotifyFlightError = 0;
			}
			FlightPlanEditor.DoNotNotifyFlightError = (byte)doNotNotifyFlightError != 0;
			ProjectData.ClearProjectError();
		}
		FlightPlanEditor.DoNotNotifyFlightError = false;
	}

	private void method_3(object sender, EventArgs e)
	{
		int num = ((DataGridView)DGV_Waypoints).Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataGridViewRow val = ((DataGridView)DGV_Waypoints).Rows[i];
			if (val.Selected)
			{
				Waypoint waypoint_ = (Waypoint)((DataGridViewBand)val).Tag;
				method_18(waypoint_);
				MyProject.Forms.SpeedAlt.LoadForm();
				((Control)MyProject.Forms.SpeedAlt).Show();
				break;
			}
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count > 0)
		{
			Waypoint waypoint = (Waypoint)((DataGridViewBand)((DataGridView)DGV_Waypoints).SelectedRows[0]).Tag;
			if (!Information.IsNothing((object)waypoint))
			{
				MainForm mainForm = MyProject.Forms.MainForm;
				ReadOnlyCollection<Module_Unit.Unit> theSelectedUnits = null;
				List<ActiveUnit> theSelectedActiveUnit = null;
				mainForm.ShowDoctrineROE(waypoint, ref theSelectedUnits, ref theSelectedActiveUnit, UnitIsOperating: false);
			}
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count > 0)
		{
			Waypoint waypoint = (Waypoint)((DataGridViewBand)((DataGridView)DGV_Waypoints).SelectedRows[0]).Tag;
			if (!Information.IsNothing((object)waypoint) && waypoint.Type == Waypoint.WaypointType.Refuel)
			{
				MyProject.Forms.TankerPlanner.TheMission = null;
				MyProject.Forms.TankerPlanner.TheWaypoint = waypoint;
				((Control)MyProject.Forms.TankerPlanner).Show();
			}
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count > 0)
		{
			Waypoint waypoint = (Waypoint)((DataGridViewBand)((DataGridView)DGV_Waypoints).SelectedRows[0]).Tag;
			if (!Information.IsNothing((object)waypoint))
			{
				DoctrineForm obj = new DoctrineForm
				{
					Subject = waypoint,
					isEscorts = false
				};
				((TabControl)obj.TabControl1A).SelectedIndex = 1;
				((Control)obj).Show();
			}
		}
	}

	private void method_7(object sender, DataGridViewColumnEventArgs e)
	{
		Rectangle displayRectangle = ((DataGridView)DGV_Waypoints).DisplayRectangle;
		((Control)DGV_Waypoints).Invalidate(displayRectangle);
	}

	private void method_8(object sender, PaintEventArgs e)
	{
		try
		{
			if (((DataGridView)DGV_Waypoints).Rows.Count > 0)
			{
				Rectangle cellDisplayRectangle = ((DataGridView)DGV_Waypoints).GetCellDisplayRectangle(((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["TimeFixedImg"]).Index, 0, false);
				Rectangle cellDisplayRectangle2 = ((DataGridView)DGV_Waypoints).GetCellDisplayRectangle(((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["TimeFixedImg"]).Index, ((DataGridView)DGV_Waypoints).Rows.Count - 1, false);
				float num = cellDisplayRectangle.Right;
				float num2 = cellDisplayRectangle.Top;
				float num3 = cellDisplayRectangle2.Right;
				float num4 = cellDisplayRectangle2.Bottom;
				e.Graphics.DrawLine(Pens.DarkGray, num, num2, num3, num4);
				cellDisplayRectangle = ((DataGridView)DGV_Waypoints).GetCellDisplayRectangle(((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["SpeedFixedImg"]).Index, 0, false);
				cellDisplayRectangle2 = ((DataGridView)DGV_Waypoints).GetCellDisplayRectangle(((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["SpeedFixedImg"]).Index, ((DataGridView)DGV_Waypoints).Rows.Count - 1, false);
				num = cellDisplayRectangle.Right;
				num2 = cellDisplayRectangle.Top;
				num3 = cellDisplayRectangle2.Right;
				num4 = cellDisplayRectangle2.Bottom;
				e.Graphics.DrawLine(Pens.DarkGray, num, num2, num3, num4);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (!Client.FlightPlanEditorWindow.WaypointList_Refresh)
		{
			return;
		}
		DisplayLocks();
		EnableAndDisableCells();
		EnableAndDisableButtons();
		try
		{
			List<ActiveUnit> source = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(Client.FlightPlanEditorWindow.SelectedMission, Client.CurrentScenario)
				where !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
				select x).ToList();
			if (Client.FlightPlanEditorWindow.SelectedFlight == null && Client.FlightPlanEditorWindow.SelectedMission.FlightList != null && Client.FlightPlanEditorWindow.SelectedMission.FlightList.Count > 0)
			{
				Client.FlightPlanEditorWindow.SelectedFlight = Client.FlightPlanEditorWindow.SelectedMission.FlightList.First();
			}
			if (Client.FlightPlanEditorWindow.SelectedFlight != null)
			{
				source = source.Where([SpecialName] (ActiveUnit x) => Operators.CompareString(x.Navigator.get_Flight(HierarchySearch: true).Callsign, Client.FlightPlanEditorWindow.SelectedFlight.Callsign, true) == 0).ToList();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 98723454657411", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DisplayLocks()
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		try
		{
			Client.FlightPlanEditorWindow.theImageLocked.MakeTransparent(Color.White);
			Client.FlightPlanEditorWindow.theImageUnlocked.MakeTransparent(Color.White);
			Client.FlightPlanEditorWindow.theImageNotConfigured.MakeTransparent(Color.White);
			Client.FlightPlanEditorWindow.theImageNotLockable.MakeTransparent(Color.White);
			Client.FlightPlanEditorWindow.theImageRelative.MakeTransparent(Color.White);
			bool waypointList_Refresh = Client.FlightPlanEditorWindow.WaypointList_Refresh;
			Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_Waypoints).Rows)
			{
				DataGridViewRow val = item;
				if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["TimeFixed"].Value), 1))
				{
					if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["TimeFixed"].Value), 0))
					{
						if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageUnlocked)
						{
							val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageUnlocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["TimeFixed"].Value), 2))
					{
						if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageNotLockable)
						{
							val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageNotLockable;
						}
					}
					else if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["TimeFixed"].Value), 3))
					{
						if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageNotConfigured)
						{
							val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageNotConfigured;
						}
					}
					else if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageRelative)
					{
						val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageRelative;
					}
				}
				else if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageLocked)
				{
					val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageLocked;
				}
				if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["SpeedFixed"].Value), 1))
				{
					if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageLocked)
					{
						val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageLocked;
					}
				}
				else if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["SpeedFixed"].Value), 0))
				{
					if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["SpeedFixed"].Value), 2))
					{
						if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageNotLockable)
						{
							val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageNotLockable;
						}
					}
					else if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["SpeedFixed"].Value), 3))
					{
						if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageNotConfigured)
						{
							val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageNotConfigured;
						}
					}
					else if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageRelative)
					{
						val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageRelative;
					}
				}
				else if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageUnlocked)
				{
					val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageUnlocked;
				}
			}
			Client.FlightPlanEditorWindow.WaypointList_Refresh = waypointList_Refresh;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EnableAndDisableCells()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		try
		{
			bool flag = true;
			Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = default(Doctrine._UseUnderwayRefuelAndReplenishment?);
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_Waypoints).Rows)
			{
				DataGridViewRow val = item;
				Waypoint waypoint = (Waypoint)((DataGridViewBand)val).Tag;
				if (Information.IsNothing((object)waypoint))
				{
					continue;
				}
				if (waypoint.Type == Waypoint.WaypointType.StationEnd)
				{
					val.Cells["Type"].ReadOnly = true;
					val.Cells["Type"].Style.BackColor = Color.LightGray;
					val.Cells["Type"].Style.SelectionBackColor = Color.LightGray;
					val.Cells["Type"].Style.SelectionForeColor = Color.Black;
				}
				else if (val.Cells["Type"].ReadOnly)
				{
					val.Cells["Type"].ReadOnly = false;
					val.Cells["Type"].Style.BackColor = default(Color);
					val.Cells["Type"].Style.SelectionBackColor = default(Color);
				}
				int num;
				if (waypoint.Type == Waypoint.WaypointType.HoldEnd)
				{
					val.Cells["Type"].ReadOnly = true;
					val.Cells["Type"].Style.SelectionBackColor = Color.LightGray;
					val.Cells["Type"].Style.SelectionForeColor = Color.Black;
					num = 1;
				}
				else if (!val.Cells["Type"].ReadOnly)
				{
					num = 1;
				}
				else
				{
					val.Cells["Type"].ReadOnly = false;
					val.Cells["Type"].Style.BackColor = default(Color);
					val.Cells["Type"].Style.SelectionBackColor = default(Color);
					num = 1;
				}
				flag = (byte)num != 0;
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = waypoint.GetDoctrine(Client.CurrentScenario).get_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
				byte? b = (byte?)useUnderwayRefuelAndReplenishment;
				bool? flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
				bool? flag3 = (!flag2) ?? flag2;
				int num2;
				if ((!flag3) ?? false)
				{
					num2 = 0;
				}
				else
				{
					b = (byte?)useUnderwayRefuelAndReplenishment;
					bool? flag5;
					bool? flag4 = (flag5 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)));
					bool? flag6;
					flag5 = (flag6 = ((flag4.HasValue && flag5 != true) ? new bool?(false) : (Information.IsNothing((object)useUnderwayRefuelAndReplenishment2) ? new bool?(false) : flag5)));
					bool? obj;
					if (flag5.HasValue && flag6 != true)
					{
						obj = false;
					}
					else
					{
						b = (byte?)useUnderwayRefuelAndReplenishment2;
						bool? flag7;
						flag5 = (flag7 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)));
						obj = ((!flag5.HasValue) ? ((bool?)null) : ((flag7 == true) & flag6));
					}
					flag2 = obj;
					if (((!flag2) ?? flag2) == true && flag3.HasValue)
					{
						if (val.Cells["AARSelection"].ReadOnly)
						{
							val.Cells["AARSelection"].ReadOnly = false;
							val.Cells["AARSelection"].Style.BackColor = default(Color);
							val.Cells["AARSelection"].Style.ForeColor = default(Color);
							val.Cells["AARSelection"].Style.SelectionBackColor = default(Color);
							val.Cells["AARSelection"].Style.SelectionForeColor = default(Color);
						}
						goto IL_0599;
					}
					num2 = 0;
				}
				flag = (byte)num2 != 0;
				val.Cells["AARSelection"].ReadOnly = true;
				val.Cells["AARSelection"].Style.BackColor = Color.LightGray;
				val.Cells["AARSelection"].Style.ForeColor = val.Cells["AARSelection"].Style.BackColor;
				val.Cells["AARSelection"].Style.SelectionBackColor = Color.LightGray;
				val.Cells["AARSelection"].Style.SelectionForeColor = val.Cells["AARSelection"].Style.SelectionBackColor;
				goto IL_0599;
				IL_0599:
				b = (byte?)useUnderwayRefuelAndReplenishment;
				flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 4));
				if (((!flag3) ?? flag3) == true)
				{
					useUnderwayRefuelAndReplenishment2 = useUnderwayRefuelAndReplenishment;
				}
				if (waypoint.Type != Waypoint.WaypointType.StationEnd && waypoint.Type != Waypoint.WaypointType.Assemble && waypoint.Type != Waypoint.WaypointType.HoldEnd && waypoint.Type != Waypoint.WaypointType.TakeOff)
				{
					if (val.Cells["SpeedToT"].ReadOnly)
					{
						val.Cells["SpeedToT"].ReadOnly = false;
						val.Cells["SpeedToT"].Style.BackColor = default(Color);
						val.Cells["SpeedToT"].Style.ForeColor = default(Color);
						val.Cells["SpeedToT"].Style.SelectionBackColor = default(Color);
						val.Cells["SpeedToT"].Style.SelectionForeColor = default(Color);
					}
				}
				else
				{
					val.Cells["SpeedToT"].ReadOnly = true;
					val.Cells["SpeedToT"].Style.BackColor = Color.LightGray;
					val.Cells["SpeedToT"].Style.ForeColor = val.Cells["SpeedToT"].Style.BackColor;
					val.Cells["SpeedToT"].Style.SelectionBackColor = Color.LightGray;
					val.Cells["SpeedToT"].Style.SelectionForeColor = val.Cells["SpeedToT"].Style.SelectionBackColor;
				}
				if (!Information.IsNothing((object)Client.FlightPlanEditorWindow.SelectedFlight))
				{
					if (Client.FlightPlanEditorWindow.SelectedFlight.DesiredAircraftQty > 1)
					{
						val.Cells["Formation"].ReadOnly = false;
						val.Cells["Formation"].Style.BackColor = default(Color);
						val.Cells["Formation"].Style.ForeColor = default(Color);
						val.Cells["Formation"].Style.SelectionBackColor = default(Color);
						val.Cells["Formation"].Style.SelectionForeColor = default(Color);
					}
					else
					{
						val.Cells["Formation"].ReadOnly = true;
						val.Cells["Formation"].Style.BackColor = Color.LightGray;
						val.Cells["Formation"].Style.ForeColor = val.Cells["Formation"].Style.BackColor;
						val.Cells["Formation"].Style.SelectionBackColor = Color.LightGray;
						val.Cells["Formation"].Style.SelectionForeColor = val.Cells["Formation"].Style.SelectionBackColor;
					}
				}
				Doctrine._UnderwayRefuelAndReplenishmentSelection? underwayRefuelAndReplenishmentSelection = waypoint.GetDoctrine(Client.CurrentScenario).get_ReplenishmentSelection(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
				if (waypoint.Type == Waypoint.WaypointType.Refuel && flag)
				{
					b = (byte?)underwayRefuelAndReplenishmentSelection;
					flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 4));
					if (((!flag3) ?? flag3) == true)
					{
						if (val.Cells["AARSettings"].ReadOnly)
						{
							val.Cells["AARSettings"].ReadOnly = false;
							val.Cells["AARSettings"].Style.BackColor = default(Color);
							val.Cells["AARSettings"].Style.ForeColor = default(Color);
							val.Cells["AARSettings"].Style.SelectionBackColor = default(Color);
							val.Cells["AARSettings"].Style.SelectionForeColor = default(Color);
						}
						continue;
					}
				}
				val.Cells["AARSettings"].ReadOnly = true;
				val.Cells["AARSettings"].Style.BackColor = Color.LightGray;
				val.Cells["AARSettings"].Style.ForeColor = val.Cells["AARSettings"].Style.BackColor;
				val.Cells["AARSettings"].Style.SelectionBackColor = Color.LightGray;
				val.Cells["AARSettings"].Style.SelectionForeColor = val.Cells["AARSettings"].Style.SelectionBackColor;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EnableAndDisableButtons()
	{
		try
		{
			Button_InsertWaypoint.Enabled = false;
			Button_DeleteWaypoint.Enabled = false;
			Button_EditSpeedAltitude.Enabled = false;
			Button_EditTime.Enabled = false;
			Button_ClearTime.Enabled = false;
			Button_EditDoctrine.Enabled = false;
			Button_EditAAR.Enabled = false;
			Button_EditSensorUsage.Enabled = false;
			Button_EditTargetAndWeapons.Enabled = false;
			if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count == 1)
			{
				int num = ((DataGridView)DGV_Waypoints).Rows.Count - 1;
				int num2 = 0;
				Waypoint waypoint;
				while (true)
				{
					if (num2 > num)
					{
						return;
					}
					DataGridViewRow val = ((DataGridView)DGV_Waypoints).Rows[num2];
					if (val.Selected)
					{
						waypoint = (Waypoint)((DataGridViewBand)val).Tag;
						if (!Information.IsNothing((object)waypoint))
						{
							break;
						}
					}
					num2++;
				}
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.TakeOff:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
				case Waypoint.WaypointType.StationEnd:
				case Waypoint.WaypointType.HoldEnd:
					Button_InsertWaypoint.Enabled = true;
					break;
				}
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
					Button_DeleteWaypoint.Enabled = true;
					break;
				}
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.LandingMarshal:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.TakeOff:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
				case Waypoint.WaypointType.StationStart_Racetrack:
				case Waypoint.WaypointType.StationStart_FigureEight:
				case Waypoint.WaypointType.StationStart_Area:
				case Waypoint.WaypointType.StationStart_RaceTrackRandom:
				case Waypoint.WaypointType.StationEnd:
				case Waypoint.WaypointType.HoldStart:
				case Waypoint.WaypointType.HoldEnd:
					Button_EditSpeedAltitude.Enabled = true;
					break;
				}
				if (Client.FlightPlanEditorWindow.SelectedFlight.Task != Mission._FlightTask.QRA)
				{
					if (Client.FlightPlanEditorWindow.SelectedFlight.Type == Mission._FlightType.FlightplanTemplate)
					{
						Waypoint.WaypointType type = waypoint.Type;
						if (type == Waypoint.WaypointType.StationEnd)
						{
							Button_EditTime.Enabled = true;
						}
					}
					else
					{
						switch (waypoint.Type)
						{
						case Waypoint.WaypointType.Assemble:
						case Waypoint.WaypointType.TurningPoint:
						case Waypoint.WaypointType.InitialPoint:
						case Waypoint.WaypointType.Target:
						case Waypoint.WaypointType.LandingMarshal:
						case Waypoint.WaypointType.StrikeIngress:
						case Waypoint.WaypointType.StrikeEgress:
						case Waypoint.WaypointType.Refuel:
						case Waypoint.WaypointType.TakeOff:
						case Waypoint.WaypointType.WeaponLaunch:
						case Waypoint.WaypointType.Land:
						case Waypoint.WaypointType.WeaponTarget:
						case Waypoint.WaypointType.StationStart_Racetrack:
						case Waypoint.WaypointType.StationStart_FigureEight:
						case Waypoint.WaypointType.StationStart_Area:
						case Waypoint.WaypointType.StationStart_RaceTrackRandom:
						case Waypoint.WaypointType.StationEnd:
						case Waypoint.WaypointType.HoldStart:
						case Waypoint.WaypointType.HoldEnd:
							Button_EditTime.Enabled = true;
							break;
						}
					}
				}
				Waypoint.WaypointType type2 = waypoint.Type;
				if (type2 != Waypoint.WaypointType.Target)
				{
				}
				if (((DataGridView)DGV_Waypoints).Rows.Count > 0)
				{
					Button_ClearTime.Enabled = true;
				}
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.LandingMarshal:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.TakeOff:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
				case Waypoint.WaypointType.StationStart_Racetrack:
				case Waypoint.WaypointType.StationStart_FigureEight:
				case Waypoint.WaypointType.StationStart_Area:
				case Waypoint.WaypointType.StationStart_RaceTrackRandom:
				case Waypoint.WaypointType.StationEnd:
				case Waypoint.WaypointType.HoldStart:
				case Waypoint.WaypointType.HoldEnd:
					Button_EditDoctrine.Enabled = true;
					break;
				}
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = waypoint.GetDoctrine(Client.CurrentScenario).get_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
				Waypoint.WaypointType type3 = waypoint.Type;
				byte? b;
				bool? flag2;
				if (type3 == Waypoint.WaypointType.Refuel)
				{
					b = (byte?)useUnderwayRefuelAndReplenishment;
					bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					flag2 = (!flag) ?? flag;
					if (flag2 ?? true)
					{
						b = (byte?)useUnderwayRefuelAndReplenishment;
						bool? flag4;
						bool? flag3 = (flag4 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)));
						bool? flag5;
						Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = default(Doctrine._UseUnderwayRefuelAndReplenishment?);
						flag4 = (flag5 = ((flag3.HasValue && flag4 != true) ? new bool?(false) : (Information.IsNothing((object)useUnderwayRefuelAndReplenishment2) ? new bool?(false) : flag4)));
						bool? obj;
						if (flag4.HasValue && flag5 != true)
						{
							obj = false;
						}
						else
						{
							b = (byte?)useUnderwayRefuelAndReplenishment2;
							bool? flag6;
							flag4 = (flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)));
							obj = ((!flag4.HasValue) ? ((bool?)null) : ((flag6 == true) & flag5));
						}
						flag = obj;
						if (((!flag) ?? flag) == true && flag2.HasValue)
						{
							Button_EditAAR.Enabled = true;
						}
					}
				}
				b = (byte?)useUnderwayRefuelAndReplenishment;
				flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 4));
				if (((!flag2) ?? flag2) == true)
				{
					Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = useUnderwayRefuelAndReplenishment;
				}
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.LandingMarshal:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.TakeOff:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
				case Waypoint.WaypointType.StationStart_Racetrack:
				case Waypoint.WaypointType.StationStart_FigureEight:
				case Waypoint.WaypointType.StationStart_Area:
				case Waypoint.WaypointType.StationStart_RaceTrackRandom:
				case Waypoint.WaypointType.StationEnd:
				case Waypoint.WaypointType.HoldStart:
				case Waypoint.WaypointType.HoldEnd:
					Button_EditSensorUsage.Enabled = true;
					break;
				case Waypoint.WaypointType.Split:
				case Waypoint.WaypointType.Formate:
				case Waypoint.WaypointType.Marshal:
				case Waypoint.WaypointType.Land:
				case Waypoint.WaypointType.PickupPoint:
					break;
				}
			}
			else if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count <= 1)
			{
				if (((DataGridView)DGV_Waypoints).Rows.Count > 0)
				{
					Button_ClearTime.Enabled = true;
				}
			}
			else if (((DataGridView)DGV_Waypoints).Rows.Count > 0)
			{
				Button_ClearTime.Enabled = true;
				Button_DeleteWaypoint.Enabled = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_10(object sender, DataGridViewCellEventArgs e)
	{
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			int num = ((DataGridView)DGV_Waypoints).Rows.Count - 1;
			DataGridViewRow val2 = default(DataGridViewRow);
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow val = ((DataGridView)DGV_Waypoints).Rows[i];
				if (!val.Selected)
				{
					continue;
				}
				val2 = val;
				method_18((Waypoint)((DataGridViewBand)val2).Tag);
				DataGridViewColumn val3 = ((DataGridView)DGV_Waypoints).Columns[e.ColumnIndex];
				if (Operators.CompareString(val3.Name, "Type", true) != 0)
				{
					if (Operators.CompareString(val3.Name, "Formation", true) == 0)
					{
						if (!((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
						{
							DataTable theComboBoxDataSource_Formation = new DataTable();
							DataGridViewComboBoxCell val4 = (DataGridViewComboBoxCell)((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
							Waypoint.ComboBoxDataSource_Formation(ref theComboBoxDataSource_Formation);
							val4.DataSource = theComboBoxDataSource_Formation;
							val4.DisplayMember = "Description";
							val4.ValueMember = "ID";
							val4.DropDownWidth = 500;
						}
						((DataGridView)DGV_Waypoints).BeginEdit(true);
						if (((DataGridView)DGV_Waypoints).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_Waypoints).EditingControl))
						{
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_Waypoints).EditingControl).DroppedDown = true;
						}
						break;
					}
					if (Operators.CompareString(val3.Name, "AARUsage", true) == 0)
					{
						Waypoint waypoint = (Waypoint)((DataGridViewBand)val).Tag;
						if (!Information.IsNothing((object)waypoint))
						{
							if (!((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
							{
								DataTable dataTable = new DataTable();
								Doctrine doctrine = waypoint.GetDoctrine(Client.CurrentScenario);
								Doctrine.DoctrineItem_E theDocEnum = Command_Core.Doctrine.DoctrineItem_E.UseReplenishment;
								doctrine.Populate_DataTable_States(dataTable, ref theDocEnum);
								DataGridViewComboBoxCell val5 = (DataGridViewComboBoxCell)((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
								val5.DataSource = dataTable;
								val5.DisplayMember = "Description";
								val5.ValueMember = "ID";
								val5.DropDownWidth = 500;
							}
							((DataGridView)DGV_Waypoints).BeginEdit(true);
							if (((DataGridView)DGV_Waypoints).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_Waypoints).EditingControl))
							{
								((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_Waypoints).EditingControl).DroppedDown = true;
							}
							break;
						}
					}
					if (Operators.CompareString(val3.Name, "AARSelection", true) == 0)
					{
						Waypoint waypoint2 = (Waypoint)((DataGridViewBand)val).Tag;
						if (!Information.IsNothing((object)waypoint2))
						{
							if (!((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
							{
								DataTable dataTable2 = new DataTable();
								Doctrine doctrine2 = waypoint2.GetDoctrine(Client.CurrentScenario);
								Doctrine.DoctrineItem_E theDocEnum = Command_Core.Doctrine.DoctrineItem_E.ReplenishmentSelection;
								doctrine2.Populate_DataTable_States(dataTable2, ref theDocEnum);
								DataGridViewComboBoxCell val6 = (DataGridViewComboBoxCell)((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
								val6.DataSource = dataTable2;
								val6.DisplayMember = "Description";
								val6.ValueMember = "ID";
								val6.DropDownWidth = 500;
							}
							((DataGridView)DGV_Waypoints).BeginEdit(true);
							if (((DataGridView)DGV_Waypoints).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_Waypoints).EditingControl))
							{
								((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_Waypoints).EditingControl).DroppedDown = true;
							}
							break;
						}
					}
					if (Operators.CompareString(val3.Name, "SpeedToT", true) != 0)
					{
						if (Operators.CompareString(val3.Name, "TurnRate", true) != 0)
						{
							if (Operators.CompareString(val3.Name, "TimeFixedImg", true) != 0)
							{
								if (Operators.CompareString(val3.Name, "SpeedFixedImg", true) != 0)
								{
									break;
								}
								Waypoint waypoint3 = (Waypoint)((DataGridViewBand)val).Tag;
								int num2;
								if (Client.Realtime && !Client.RealtimeAC)
								{
									Client.RealtimeTerminal.SendChangeFlightToggleWaypointSpeed(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint3);
									num2 = 1;
								}
								else
								{
									if (Client.FlightPlanEditorWindow.SelectedFlight.ReferenceUnit_DBID == 0)
									{
										((Form)new DarkMessageBox("Flightplan Templates with no aircraft type selected may only use fixed speeds!")).ShowDialog();
									}
									CoreClientCode.ChangeFlightPlanToggleWaypointSpeed_Core(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint3);
									num2 = 1;
								}
								flag2 = (byte)num2 != 0;
								break;
							}
							Waypoint waypoint4 = (Waypoint)((DataGridViewBand)val).Tag;
							if (!Information.IsNothing((object)waypoint4.Time_Zulu))
							{
								if (Client.Realtime && !Client.RealtimeAC)
								{
									Client.RealtimeTerminal.SendChangeFlightToggleWaypointTime(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint4);
									break;
								}
								CoreClientCode.ChangeFlightPlanToggleWaypointTime_Core(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint4);
								val.Cells["TimeFixed"].Value = waypoint4.TimeFixed;
								flag2 = true;
								flag4 = true;
							}
						}
						else
						{
							if (!((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
							{
								DataTable theComboBoxDataSource_TurnRate = new DataTable();
								DataGridViewComboBoxCell val7 = (DataGridViewComboBoxCell)((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
								Waypoint.ComboBoxDataSource_TurnRate(ref theComboBoxDataSource_TurnRate);
								val7.DataSource = theComboBoxDataSource_TurnRate;
								val7.DisplayMember = "Description";
								val7.ValueMember = "ID";
								val7.DropDownWidth = 500;
							}
							((DataGridView)DGV_Waypoints).BeginEdit(true);
							if (((DataGridView)DGV_Waypoints).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_Waypoints).EditingControl))
							{
								((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_Waypoints).EditingControl).DroppedDown = true;
							}
						}
					}
					else
					{
						if (!((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
						{
							DataTable theComboBoxDataSource_SpeedToT = new DataTable();
							DataGridViewComboBoxCell val8 = (DataGridViewComboBoxCell)((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
							Waypoint.ComboBoxDataSource_SpeedToT(ref theComboBoxDataSource_SpeedToT);
							val8.DataSource = theComboBoxDataSource_SpeedToT;
							val8.DisplayMember = "Description";
							val8.ValueMember = "ID";
							val8.DropDownWidth = 500;
						}
						((DataGridView)DGV_Waypoints).BeginEdit(true);
						if (((DataGridView)DGV_Waypoints).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_Waypoints).EditingControl))
						{
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_Waypoints).EditingControl).DroppedDown = true;
						}
					}
				}
				else
				{
					if (!((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
					{
						DataTable theComboBoxDataSource_WaypointType = new DataTable();
						DataGridViewComboBoxCell val9 = (DataGridViewComboBoxCell)((DataGridView)DGV_Waypoints)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
						Waypoint.ComboBoxDataSource_WaypointType(ref theComboBoxDataSource_WaypointType);
						val9.DataSource = theComboBoxDataSource_WaypointType;
						val9.DisplayMember = "Description";
						val9.ValueMember = "ID";
						val9.DropDownWidth = 500;
					}
					((DataGridView)DGV_Waypoints).BeginEdit(true);
					if (((DataGridView)DGV_Waypoints).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_Waypoints).EditingControl))
					{
						((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_Waypoints).EditingControl).DroppedDown = true;
					}
				}
				break;
			}
			if (Information.IsNothing((object)val2))
			{
				Button_InsertWaypoint.Enabled = false;
				Button_DeleteWaypoint.Enabled = false;
				Button_EditTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				Button_EditSpeedAltitude.Enabled = false;
				Button_EditDoctrine.Enabled = false;
				Button_EditAAR.Enabled = false;
				Button_EditSensorUsage.Enabled = false;
			}
			else
			{
				Button_InsertWaypoint.Enabled = true;
				Button_DeleteWaypoint.Enabled = true;
				Button_EditTime.Enabled = true;
				Button_ClearTime.Enabled = true;
				Button_EditSpeedAltitude.Enabled = true;
				Button_EditDoctrine.Enabled = true;
				Button_EditAAR.Enabled = true;
				Button_EditSensorUsage.Enabled = true;
			}
			if (flag)
			{
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, flag2, RefreshFlightplanEditorWindow_Limited: false, flag3, RefreshFlightplanEditorWindow_DrawLocks: false);
			}
			else if (flag3)
			{
				Client.FlightPlanEditorWindow.LoadGrid();
			}
			else if (flag2)
			{
				Client.FlightPlanEditorWindow.RefreshGrid();
			}
			if (flag || flag3 || flag2)
			{
				DisplayLocks();
				EnableAndDisableCells();
			}
			if (((Control)Client.FlightPlanTimeWindow).Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
			{
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
				FlightPlanEditor flightPlanEditorWindow;
				Mission.Flight theSelectedFlight = (flightPlanEditorWindow = Client.FlightPlanEditorWindow).SelectedFlight;
				FlightPlanEditor flightPlanEditorWindow2;
				Waypoint theSelectedWaypoint = (flightPlanEditorWindow2 = Client.FlightPlanEditorWindow).SelectedWaypoint;
				flightPlanTimeWindow.RefreshStats(ref selectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, SetDateTimeIfNeccessary: true);
				flightPlanEditorWindow2.SelectedWaypoint = theSelectedWaypoint;
				flightPlanEditorWindow.SelectedFlight = theSelectedFlight;
			}
			if (flag4 && ((Control)Client.AirTaskingOrderWindow).Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
				Client.AirTaskingOrderWindow.DisplayLocks();
			}
			EnableAndDisableButtons();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200588", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Waypoint GetActualWaypoint(ref Waypoint theWaypoint, Mission.Flight.FlightElement theElement)
	{
		Waypoint result;
		try
		{
			if (theElement == Mission.Flight.FlightElement.LeadElement)
			{
				result = theWaypoint;
			}
			else if (theWaypoint.FlightFormation == Waypoint.Formation.Spread)
			{
				result = theWaypoint;
			}
			else
			{
				switch (theElement)
				{
				case Mission.Flight.FlightElement.LeadElementWingman:
					if (Information.IsNothing((object)theWaypoint.Waypoint_LeadElementWingman))
					{
						break;
					}
					result = theWaypoint.Waypoint_LeadElementWingman;
					goto end_IL_0001;
				case Mission.Flight.FlightElement.SecondElement:
					if (Information.IsNothing((object)theWaypoint.Waypoint_SecondElement))
					{
						break;
					}
					result = theWaypoint.Waypoint_SecondElement;
					goto end_IL_0001;
				case Mission.Flight.FlightElement.SecondElementWingman:
					if (Information.IsNothing((object)theWaypoint.Waypoint_SecondElementWingman))
					{
						break;
					}
					result = theWaypoint.Waypoint_SecondElementWingman;
					goto end_IL_0001;
				case Mission.Flight.FlightElement.ThirdElement:
					if (Information.IsNothing((object)theWaypoint.Waypoint_ThirdElement))
					{
						break;
					}
					result = theWaypoint.Waypoint_ThirdElement;
					goto end_IL_0001;
				case Mission.Flight.FlightElement.ThirdElementWingman:
					if (Information.IsNothing((object)theWaypoint.Waypoint_ThirdElementWingman))
					{
						break;
					}
					result = theWaypoint.Waypoint_ThirdElementWingman;
					goto end_IL_0001;
				}
				result = theWaypoint;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_11(object sender, DataGridViewCellEventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count != 0 && Client.FlightPlanEditorWindow.WaypointList_Refresh)
		{
			method_13(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		Client.FlightPlanEditorWindow.WaypointList_Refresh = true;
		if (((DataGridView)DGV_Waypoints).IsCurrentCellDirty)
		{
			((DataGridView)DGV_Waypoints).CommitEdit((DataGridViewDataErrorContexts)512);
		}
	}

	private void method_13(object sender, DataGridViewCellEventArgs e)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_0856: Invalid comparison between Unknown and I4
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Invalid comparison between Unknown and I4
		try
		{
			List<Mission.Flight> list = new List<Mission.Flight>();
			Waypoint waypoint = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex];
			bool? flag = null;
			if (Client.FlightPlanEditorWindow.SelectedMission.FlightList.Count > 1)
			{
				if ((int)DarkMessageBox.ShowInformation("Would you like to Update the Waypoint #" + waypoint.Description + " for all the flights in this mission?", "Multiple Wp addition", DarkDialogButton.YesNo) == 6)
				{
					list = Client.FlightPlanEditorWindow.SelectedMission.FlightList;
				}
				else
				{
					list.Add(Client.FlightPlanEditorWindow.SelectedFlight);
				}
			}
			else
			{
				list.Add(Client.FlightPlanEditorWindow.SelectedFlight);
			}
			Mission.Flight selectedFlight = Client.FlightPlanEditorWindow.SelectedFlight;
			foreach (Mission.Flight item in list)
			{
				Client.FlightPlanEditorWindow.SelectedFlight = item;
				bool flag2 = false;
				if (Information.IsNothing((object)Client.FlightPlanEditorWindow.SelectedFlight) || e.RowIndex > Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan.Count() - 1)
				{
					return;
				}
				waypoint = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex];
				Waypoint waypoint2 = null;
				bool flag3 = false;
				bool flag4 = false;
				if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["Type"]).Index)
				{
					DataGridViewCell obj = ((DataGridView)DGV_Waypoints)[e.ColumnIndex, e.RowIndex];
					object Type = RuntimeHelpers.GetObjectValue(obj.Value);
					int? num = Waypoint.WaypointTypeSelection_To_WaypointType(ref Type);
					obj.Value = RuntimeHelpers.GetObjectValue(Type);
					Waypoint.WaypointType value = (Waypoint.WaypointType)num.Value;
					if (e.RowIndex != 0)
					{
						if (e.RowIndex == ((DataGridView)DGV_Waypoints).Rows.Count - 1)
						{
							if (value == Waypoint.WaypointType.Land)
							{
								flag3 = true;
							}
							else
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("The last waypoint in a flightplan must be the Landing waypoint!")).ShowDialog();
							}
						}
						else if (e.RowIndex == ((DataGridView)DGV_Waypoints).Rows.Count - 2)
						{
							if (value == Waypoint.WaypointType.LandingMarshal)
							{
								flag3 = true;
							}
							else
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("The second last waypoint in a flightplan must be the Landing Marshal waypoint!")).ShowDialog();
							}
						}
						else if (value == Waypoint.WaypointType.TakeOff)
						{
							if (e.RowIndex != 0)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("The Take-Off waypoint must be the first waypoint in a flightplan!")).ShowDialog();
							}
							else
							{
								flag3 = true;
							}
						}
						else if (value == Waypoint.WaypointType.Land)
						{
							if (e.RowIndex == ((DataGridView)DGV_Waypoints).Rows.Count - 1)
							{
								flag3 = true;
							}
							else
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("The Landing waypoint must be the last waypoint in a flightplan!")).ShowDialog();
							}
						}
						else if (value == Waypoint.WaypointType.LandingMarshal)
						{
							if (e.RowIndex == ((DataGridView)DGV_Waypoints).Rows.Count - 2)
							{
								flag3 = true;
							}
							else
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("The Landing Marshal waypoint must be the second last waypoint in a flightplan!")).ShowDialog();
							}
						}
						else if (value != Waypoint.WaypointType.StationStart_Area && value != Waypoint.WaypointType.StationStart_FigureEight && value != Waypoint.WaypointType.StationStart_Racetrack && value != Waypoint.WaypointType.StationStart_RaceTrackRandom)
						{
							if (value == Waypoint.WaypointType.StationEnd)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("The Station End waypoint is set automatically when a Station Start waypoint is configured. Select Station Start instead.")).ShowDialog();
							}
							else if (value == Waypoint.WaypointType.HoldStart)
							{
								if (e.RowIndex >= 1)
								{
									if (e.RowIndex <= ((DataGridView)DGV_Waypoints).Rows.Count - 4)
									{
										waypoint2 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex + 1];
										_ = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex];
										if (waypoint2.IsHoldStartWaypoint() && !waypoint2.IsHoldEndWaypoint())
										{
											Client.FlightPlanEditorWindow.LoadGrid();
											((Form)new DarkMessageBox("The waypoint after a Hold Start waypoint cannot be another Hold Start waypoint!")).ShowDialog();
										}
										else if (waypoint.FlightFormation != Waypoint.Formation.Split && waypoint2.FlightFormation != Waypoint.Formation.Split)
										{
											if (waypoint2.Type != Waypoint.WaypointType.TurningPoint && waypoint2.Type != Waypoint.WaypointType.StrikeIngress && waypoint2.Type != Waypoint.WaypointType.StrikeEgress)
											{
												Client.FlightPlanEditorWindow.LoadGrid();
												((Form)new DarkMessageBox("The waypoint after Hold Start will be changed into a Hold End waypoint, and can only be of type Turning Point.")).ShowDialog();
											}
											else
											{
												flag3 = true;
											}
										}
										else
										{
											Client.FlightPlanEditorWindow.LoadGrid();
											((Form)new DarkMessageBox("Hold Start or Hold End waypoints can not use Split formations. Change the formation to Spread and try again.")).ShowDialog();
										}
									}
									else
									{
										Client.FlightPlanEditorWindow.LoadGrid();
										((Form)new DarkMessageBox("The last three waypoints in a flightplan can not be a Hold Start waypoint! Reason: Neither the Landing nor Landing Marshal waypoints can be a Hold End waypoint. Note! The waypoint after Hold Start is automatically turned into a Hold End waypoint.")).ShowDialog();
									}
								}
								else
								{
									Client.FlightPlanEditorWindow.LoadGrid();
									((Form)new DarkMessageBox("The first waypoint in a flightplan can not be a Hold Start waypoint!")).ShowDialog();
								}
							}
							else if (value == Waypoint.WaypointType.HoldEnd)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("The Hold End waypoint is set automatically when a Hold Start waypoint is configured. Select Hold Start instead.")).ShowDialog();
							}
							else if ((value == Waypoint.WaypointType.InitialPoint || value == Waypoint.WaypointType.WeaponLaunch) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Strike)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("Only strike missions may use Initial Point or Weapon Release waypoints.")).ShowDialog();
							}
							else if ((value == Waypoint.WaypointType.InitialPoint || value == Waypoint.WaypointType.WeaponLaunch) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass == Mission._MissionClass.Strike && Client.FlightPlanEditorWindow.SelectedFlight.IsEscort)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("Escorts for strike missions cannot use Initial Point or Weapon Release waypoints. Change Flight Task to a non-escort type if you wish to attack specific targets.")).ShowDialog();
							}
							else if ((value == Waypoint.WaypointType.Target || value == Waypoint.WaypointType.WeaponTarget) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Strike)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("Only strike missions may use Target or Weapon Target waypoints.")).ShowDialog();
							}
							else if ((value == Waypoint.WaypointType.Target || value == Waypoint.WaypointType.WeaponTarget) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass == Mission._MissionClass.Strike && Client.FlightPlanEditorWindow.SelectedFlight.IsEscort)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("Escorts for strike missions cannot use Target or Weapon Target waypoints. Change Flight Task to a non-escort type if you wish to attack specific targets.")).ShowDialog();
							}
							else if ((value == Waypoint.WaypointType.StrikeIngress || value == Waypoint.WaypointType.StrikeEgress) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Strike)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("Only strike missions may use Ingress or Egress waypoints.")).ShowDialog();
							}
							else if ((value == Waypoint.WaypointType.StrikeIngress || value == Waypoint.WaypointType.StrikeEgress) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass == Mission._MissionClass.Strike && Client.FlightPlanEditorWindow.SelectedFlight.IsEscort)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("Escorts for strike missions must use Turning Point waypoints, not Turning Point (Ingress) or Turning Point (Egress).")).ShowDialog();
							}
							else if (value == Waypoint.WaypointType.TurningPoint && Client.FlightPlanEditorWindow.SelectedMission.MissionClass == Mission._MissionClass.Strike && !Client.FlightPlanEditorWindow.SelectedFlight.IsEscort)
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("Use Turning Point (Ingress) or Turning Point (Egress) waypoints for strike missions.")).ShowDialog();
							}
							else
							{
								waypoint2 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex + 1];
								_ = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex];
								flag3 = true;
								if (value == Waypoint.WaypointType.Refuel)
								{
									bool flag5 = false;
									Waypoint[] flightPlan = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan;
									foreach (Waypoint waypoint3 in flightPlan)
									{
										if (waypoint3.Type != Waypoint.WaypointType.Refuel && waypoint3 != waypoint && !Information.IsNothing((object)waypoint3.GetDoctrine(Client.CurrentScenario).get_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false)))
										{
											byte? b = (byte?)waypoint3.GetDoctrine(Client.CurrentScenario).get_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
											bool? flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
											if (((!flag6) ?? flag6) == true)
											{
												flag5 = true;
												break;
											}
										}
									}
									if (flag5)
									{
										if (list.Count > 1)
										{
											if (!flag.HasValue)
											{
												if ((int)DarkMessageBox.ShowWarning("Disable Air-to-Air Refuelling (AAR) doctrine for all waypoints except Refuel-type waypoints? THIS WILL CHANGE IT FOR ALL THE FLIGHTS IN THE MISSION", "AAR Doctrine", DarkDialogButton.YesNo) == 6)
												{
													flag4 = true;
												}
												flag = flag4;
											}
											else
											{
												flag4 = flag.Value;
											}
										}
										else if ((int)DarkMessageBox.ShowWarning(Client.FlightPlanEditorWindow.SelectedFlight.Callsign + ": Disable Air-to-Air Refuelling (AAR) doctrine for all waypoints except Refuel-type waypoints?", "AAR Doctrine", DarkDialogButton.YesNo) == 6)
										{
											flag4 = true;
										}
									}
								}
							}
						}
						else if (e.RowIndex < 1)
						{
							Client.FlightPlanEditorWindow.LoadGrid();
							((Form)new DarkMessageBox("The first waypoint in a flightplan can not be a Station Start waypoint!")).ShowDialog();
						}
						else if (e.RowIndex <= ((DataGridView)DGV_Waypoints).Rows.Count - 4)
						{
							if (Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Patrol && Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Support && (Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Strike || !Client.FlightPlanEditorWindow.SelectedFlight.IsEscort))
							{
								Client.FlightPlanEditorWindow.LoadGrid();
								((Form)new DarkMessageBox("Only patrol missions, support missions and strike mission escorts may use station waypoints.")).ShowDialog();
							}
							else
							{
								waypoint2 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex + 1];
								_ = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex];
								if (waypoint2.IsStationStartWaypoint() && !waypoint2.IsStationEndWaypoint())
								{
									Client.FlightPlanEditorWindow.LoadGrid();
									((Form)new DarkMessageBox("The waypoint after a Station Start waypoint cannot be another Station Start waypoint!")).ShowDialog();
								}
								else if (waypoint.FlightFormation != Waypoint.Formation.Split && waypoint2.FlightFormation != Waypoint.Formation.Split)
								{
									if (waypoint2.Type != Waypoint.WaypointType.TurningPoint && waypoint2.Type != Waypoint.WaypointType.StrikeIngress && waypoint2.Type != Waypoint.WaypointType.StrikeEgress && waypoint2.Type != Waypoint.WaypointType.StationEnd)
									{
										Client.FlightPlanEditorWindow.LoadGrid();
										((Form)new DarkMessageBox("The waypoint after Station Start will be changed into a Station End waypoint, and can only be of type Turning Point.")).ShowDialog();
									}
									else
									{
										flag3 = true;
									}
								}
								else
								{
									Client.FlightPlanEditorWindow.LoadGrid();
									((Form)new DarkMessageBox("Station Start or Station End waypoints can not use Split formations. Change the formation to Spread and try again.")).ShowDialog();
								}
							}
						}
						else
						{
							Client.FlightPlanEditorWindow.LoadGrid();
							((Form)new DarkMessageBox("The last three waypoints in a flightplan can not be a Station Start waypoint! Reason: Neither the Landing nor Landing Marshal waypoints can be a Station End waypoint. Note! The waypoint after Station Start is automatically turned into a Station End waypoint.")).ShowDialog();
						}
					}
					else if (value == Waypoint.WaypointType.TakeOff)
					{
						flag3 = true;
					}
					else
					{
						Client.FlightPlanEditorWindow.LoadGrid();
						((Form)new DarkMessageBox("The first waypoint in a flightplan must be the Take-Off waypoint!")).ShowDialog();
					}
					if (flag3)
					{
						if (Client.Realtime && !Client.RealtimeAC)
						{
							Client.RealtimeTerminal.SendChangeFlightPlanWaypointType(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint, value, waypoint2, flag4);
						}
						else
						{
							CoreClientCode.ChangeFlightPlanWaypointType_Core(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint, value, waypoint2, flag4);
							Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_Limited: false, RefreshFlightplanEditorWindow_ReloadhGrid: false, RefreshFlightplanEditorWindow_DrawLocks: false);
							flag2 = true;
						}
					}
				}
				if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["Formation"]).Index)
				{
					DataGridViewCell obj2 = ((DataGridView)DGV_Waypoints)[e.ColumnIndex, e.RowIndex];
					object Type = RuntimeHelpers.GetObjectValue(obj2.Value);
					int? num = Waypoint.FormationSelection_To_Formation(ref Type);
					obj2.Value = RuntimeHelpers.GetObjectValue(Type);
					Waypoint.Formation formation = (Waypoint.Formation)num.Value;
					if (formation == Waypoint.Formation.Split && waypoint.IsStationWaypoint())
					{
						Client.FlightPlanEditorWindow.LoadGrid();
						((Form)new DarkMessageBox("Station waypoints cannot be set to Split formation.")).ShowDialog();
					}
					else if (formation == Waypoint.Formation.Split && waypoint.IsHoldOrAssembleWaypoint())
					{
						Client.FlightPlanEditorWindow.LoadGrid();
						((Form)new DarkMessageBox("Hold and Assemble waypoints cannot be set to Split formation.")).ShowDialog();
					}
					else if (formation == Waypoint.Formation.Split && e.RowIndex <= 1)
					{
						Client.FlightPlanEditorWindow.LoadGrid();
						((Form)new DarkMessageBox("The first two waypoint in a flightplan cannot be set to Split formation.")).ShowDialog();
					}
					else if (formation == Waypoint.Formation.Split && e.RowIndex >= ((DataGridView)DGV_Waypoints).Rows.Count - 1)
					{
						Client.FlightPlanEditorWindow.LoadGrid();
						((Form)new DarkMessageBox("The last waypoint in a flightplan cannot be set to Split formation.")).ShowDialog();
					}
					else if (formation == Waypoint.Formation.Split && waypoint.Type == Waypoint.WaypointType.LandingMarshal)
					{
						Client.FlightPlanEditorWindow.LoadGrid();
						((Form)new DarkMessageBox("A landing marshal waypoint cannot be set to Split formation.")).ShowDialog();
					}
					else
					{
						Waypoint waypoint4 = null;
						Waypoint waypoint5 = null;
						if (e.RowIndex > 0 && e.RowIndex < Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan.Count() - 2)
						{
							waypoint4 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex - 1];
							waypoint5 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex + 1];
						}
						else
						{
							formation = Waypoint.Formation.Spread;
							((Form)new DarkMessageBox("The first waypoint or the last two waypoints in a flightplan cannot be split.")).ShowDialog();
						}
						if (Client.Realtime && !Client.RealtimeAC)
						{
							Client.RealtimeTerminal.SendChangeFlightPlanWaypointFormation(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint, formation, waypoint5, waypoint4);
						}
						else
						{
							CoreClientCode.ChangeFlightPlanWaypointFormation_Core(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint, formation, waypoint5, waypoint4);
							Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_Limited: true, RefreshFlightplanEditorWindow_ReloadhGrid: true, RefreshFlightplanEditorWindow_DrawLocks: false);
							flag2 = true;
						}
					}
				}
				if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["TurnRate"]).Index)
				{
					DataGridViewCell obj3 = ((DataGridView)DGV_Waypoints)[e.ColumnIndex, e.RowIndex];
					object Type = RuntimeHelpers.GetObjectValue(obj3.Value);
					int? num = Waypoint.TurnRateSelection_To_TurnRate(ref Type);
					obj3.Value = RuntimeHelpers.GetObjectValue(Type);
					Waypoint.TurnRateCategory turnRateCategory = (Waypoint.TurnRateCategory)num.Value;
					if (Client.Realtime && !Client.RealtimeAC)
					{
						Client.RealtimeTerminal.SendChangeFlightPlanWaypointTurnRate(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint, turnRateCategory);
					}
					else
					{
						waypoint.TurnRate_Navigation = turnRateCategory;
						Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_Limited: true, RefreshFlightplanEditorWindow_ReloadhGrid: false, RefreshFlightplanEditorWindow_DrawLocks: false);
						flag2 = true;
					}
				}
				if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["AARUsage"]).Index)
				{
					int num2 = Conversions.ToInteger(((DataGridView)DGV_Waypoints)[e.ColumnIndex, e.RowIndex].Value);
					if (Client.Realtime && !Client.RealtimeAC)
					{
						Client.RealtimeTerminal.SendChangeFlightPlanWaypointDoctriineAARUsage(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint, num2);
					}
					else
					{
						waypoint.GetDoctrine(Client.CurrentScenario).set_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UseUnderwayRefuelAndReplenishment?)(Doctrine._UseUnderwayRefuelAndReplenishment)num2);
						Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_Limited: false, RefreshFlightplanEditorWindow_ReloadhGrid: false, RefreshFlightplanEditorWindow_DrawLocks: false);
					}
				}
				if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["AARSelection"]).Index)
				{
					int num3 = Conversions.ToInteger(((DataGridView)DGV_Waypoints)[e.ColumnIndex, e.RowIndex].Value);
					if (Client.Realtime && Client.RealtimeAC)
					{
						Client.RealtimeTerminal.SendChangeFlightPlanWaypointDoctriineAARSelection(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint, num3);
					}
					else
					{
						waypoint.GetDoctrine(Client.CurrentScenario).set_ReplenishmentSelection(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)(Doctrine._UnderwayRefuelAndReplenishmentSelection)num3);
						Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_Limited: false, RefreshFlightplanEditorWindow_ReloadhGrid: false, RefreshFlightplanEditorWindow_DrawLocks: false);
					}
				}
				if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_Waypoints).Columns["SpeedToT"]).Index)
				{
					DataGridViewCell obj4 = ((DataGridView)DGV_Waypoints)[e.ColumnIndex, e.RowIndex];
					object Type = RuntimeHelpers.GetObjectValue(obj4.Value);
					int? num = Waypoint.SpeedToTSelection_To_SpeedToT(ref Type);
					obj4.Value = RuntimeHelpers.GetObjectValue(Type);
					Waypoint.SpeedToT value2 = (Waypoint.SpeedToT)num.Value;
					if (Client.Realtime && Client.RealtimeAC)
					{
						Client.RealtimeTerminal.SendChangeFlightPlanWaypointSpeedTOT(Client.CurrentScenario, Client.CurrentSide, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, FlightPlan_Element, waypoint, value2);
					}
					else
					{
						waypoint.SpeedAdjustmentToT = value2;
					}
				}
				DisplayLocks();
				EnableAndDisableCells();
				EnableAndDisableButtons();
				if (flag2 && ((Control)Client.AirTaskingOrderWindow).Visible)
				{
					Client.AirTaskingOrderWindow.RefreshWindow();
					Client.AirTaskingOrderWindow.EnableAndDisableButtons();
				}
				Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
			}
			Client.FlightPlanEditorWindow.SelectedFlight = selectedFlight;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		if (Client.FlightPlanEditorWindow.WaypointList_Refresh)
		{
			_ = ((BaseCollection)((DataGridView)DGV_Waypoints).SelectedRows).Count;
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		try
		{
			bool isPackage = !Information.IsNothing((object)Client.FlightPlanEditorWindow.SelectedMission) && Client.FlightPlanEditorWindow.SelectedMission.Category == Mission.MissionCategory.Package;
			AirTaskingOrder.ClearFlightTime(Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, isPackage);
			if (!Client.Realtime)
			{
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: false, RefreshFlightplanEditorWindow: true, RefreshFlightplanEditorWindow_Limited: false, RefreshFlightplanEditorWindow_ReloadhGrid: false, RefreshFlightplanEditorWindow_DrawLocks: true);
				EnableAndDisableCells();
				EnableAndDisableButtons();
				AMP_General.RefreshFlightPlanErrorWindow();
				Client.MustRefreshMainForm = true;
				if (((Control)Client.AirTaskingOrderWindow).Visible)
				{
					Client.AirTaskingOrderWindow.LoadWindow();
				}
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				Mission theSelectedMission = null;
				Mission.Flight theSelectedFlight = null;
				Waypoint theSelectedWaypoint = null;
				flightPlanTimeWindow.RefreshStats(ref theSelectedMission, ref theSelectedFlight, ref theSelectedWaypoint, Mission.Flight.FlightElement.None, SetDateTimeIfNeccessary: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			((Form)new DarkMessageBox("Not yet, sorry!")).ShowDialog();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		List<ActiveUnit> source = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(Client.FlightPlanEditorWindow.SelectedMission, Client.CurrentScenario)
			where !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
			select x).ToList();
		source = source.Where([SpecialName] (ActiveUnit x) => x.IsAircraft).ToList();
		source = source.Where([SpecialName] (ActiveUnit x) => Operators.CompareString(x.Navigator.get_Flight(HierarchySearch: true).Callsign, Client.FlightPlanEditorWindow.SelectedFlight.Callsign, true) == 0).ToList();
		ActiveUnit activeUnit = default(ActiveUnit);
		if (((TabControl)Client.FlightPlanEditorWindow.TabControl_Aircraft).SelectedIndex >= 0)
		{
			activeUnit = source[((TabControl)Client.FlightPlanEditorWindow.TabControl_Aircraft).SelectedIndex];
		}
		if (activeUnit == null)
		{
			return;
		}
		bool flag = false;
		if (Client.FPVisibility == null)
		{
			Client.FPVisibility = new List<FlightPlanVisbileOnMap>();
		}
		foreach (FlightPlanVisbileOnMap item in Client.FPVisibility)
		{
			if ((Operators.CompareString(item.theFlight.Callsign, ((ActiveUnit_Navigator)((Aircraft)activeUnit).Navigator).get_Flight(HierarchySearch: true).Callsign, true) == 0) & (item.UnitDBID == activeUnit.DBID) & (item.int_0 == ((Aircraft)activeUnit).LoadoutDBID))
			{
				item.Visible = ((CheckBox)CB_Filter).Checked;
				flag = true;
				Client.MustRefreshMainForm = true;
			}
		}
		if (!flag)
		{
			Client.FPVisibility.Add(new FlightPlanVisbileOnMap(activeUnit.DBID, ((Aircraft)activeUnit).LoadoutDBID, ((ActiveUnit_Navigator)((Aircraft)activeUnit).Navigator).get_Flight(HierarchySearch: true), ((CheckBox)CB_Filter).Checked));
		}
	}

	private void method_18(Waypoint waypoint_0)
	{
		Client.FlightPlanEditorWindow.SelectedWaypoint = waypoint_0;
		Client.SelectedWaypoint = waypoint_0;
		if (waypoint_0 == null && ((Control)MyProject.Forms.SpeedAlt).Visible)
		{
			((Control)MyProject.Forms.SpeedAlt).Hide();
		}
		MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint = waypoint_0;
		MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = null;
		MyProject.Forms.SpeedAlt.SpeedAlt_Flight = Client.FlightPlanEditorWindow.SelectedFlight;
		MyProject.Forms.SpeedAlt.SpeedAlt_Mission = Client.FlightPlanEditorWindow.SelectedMission;
	}

	static FlightPlanWaypoints()
	{
		Class72.smethod_20();
	}
}

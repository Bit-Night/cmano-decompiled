using System;
using System.Collections;
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
public sealed class FlightPlanWaypointsWeapon : UserControl
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_WaypointsWeapon")]
	private DarkDataGridView _DGV_WaypointsWeapon;

	[AccessedThroughProperty("Button_ClearTime")]
	[CompilerGenerated]
	private DarkButton tfyygcCcln;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditSpeedAltitude")]
	private DarkButton _Button_EditSpeedAltitude;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditTime")]
	private DarkButton _Button_EditTime;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DeleteWaypoint")]
	private DarkButton _Button_DeleteWaypoint;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_InsertWaypoint")]
	private DarkButton _Button_InsertWaypoint;

	[CompilerGenerated]
	[AccessedThroughProperty("Time_Local")]
	private DataGridViewTextBoxColumn PrAywxFwIr;

	[CompilerGenerated]
	[AccessedThroughProperty("Leg_Time")]
	private DataGridViewTextBoxColumn trwyrNtMou;

	internal virtual DarkDataGridView DGV_WaypointsWeapon
	{
		[CompilerGenerated]
		get
		{
			return _DGV_WaypointsWeapon;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			DataGridViewCellPaintingEventHandler val = new DataGridViewCellPaintingEventHandler(method_4);
			DataGridViewColumnEventHandler val2 = new DataGridViewColumnEventHandler(method_5);
			PaintEventHandler val3 = new PaintEventHandler(method_6);
			ScrollEventHandler val4 = new ScrollEventHandler(method_7);
			EventHandler eventHandler = method_8;
			EventHandler eventHandler2 = method_9;
			EventHandler eventHandler3 = method_10;
			DataGridViewCellEventHandler val5 = new DataGridViewCellEventHandler(method_11);
			DataGridViewCellEventHandler val6 = new DataGridViewCellEventHandler(method_12);
			EventHandler eventHandler4 = method_13;
			EventHandler eventHandler5 = method_15;
			DarkDataGridView darkDataGridView = _DGV_WaypointsWeapon;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellPainting -= val;
				((DataGridView)darkDataGridView).ColumnWidthChanged -= val2;
				((Control)darkDataGridView).Paint -= val3;
				((DataGridView)darkDataGridView).Scroll -= val4;
				((Control)darkDataGridView).MouseHover -= eventHandler;
				((Control)darkDataGridView).Enter -= eventHandler2;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler3;
				((DataGridView)darkDataGridView).CellClick -= val5;
				((DataGridView)darkDataGridView).CellValueChanged -= val6;
				((DataGridView)darkDataGridView).CurrentCellDirtyStateChanged -= eventHandler4;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler5;
			}
			_DGV_WaypointsWeapon = value;
			darkDataGridView = _DGV_WaypointsWeapon;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellPainting += val;
				((DataGridView)darkDataGridView).ColumnWidthChanged += val2;
				((Control)darkDataGridView).Paint += val3;
				((DataGridView)darkDataGridView).Scroll += val4;
				((Control)darkDataGridView).MouseHover += eventHandler;
				((Control)darkDataGridView).Enter += eventHandler2;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler3;
				((DataGridView)darkDataGridView).CellClick += val5;
				((DataGridView)darkDataGridView).CellValueChanged += val6;
				((DataGridView)darkDataGridView).CurrentCellDirtyStateChanged += eventHandler4;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler5;
			}
		}
	}

	internal virtual DarkButton Button_ClearTime
	{
		[CompilerGenerated]
		get
		{
			return tfyygcCcln;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkButton darkButton = tfyygcCcln;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			tfyygcCcln = value;
			darkButton = tfyygcCcln;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_EditSpeedAltitude
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
			DarkButton darkButton = _Button_EditSpeedAltitude;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_EditSpeedAltitude = value;
			darkButton = _Button_EditSpeedAltitude;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_EditTime
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
			DarkButton darkButton = _Button_EditTime;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_EditTime = value;
			darkButton = _Button_EditTime;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_DeleteWaypoint
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
			DarkButton darkButton = _Button_DeleteWaypoint;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_DeleteWaypoint = value;
			darkButton = _Button_DeleteWaypoint;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_InsertWaypoint
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
			DarkButton darkButton = _Button_InsertWaypoint;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_InsertWaypoint = value;
			darkButton = _Button_InsertWaypoint;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
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

	internal virtual DataGridViewTextBoxColumn Time_Local
	{
		[CompilerGenerated]
		get
		{
			return PrAywxFwIr;
		}
		[CompilerGenerated]
		set
		{
			PrAywxFwIr = value;
		}
	}

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

	internal virtual DataGridViewTextBoxColumn Leg_Time
	{
		[CompilerGenerated]
		get
		{
			return trwyrNtMou;
		}
		[CompilerGenerated]
		set
		{
			trwyrNtMou = value;
		}
	}

	[field: AccessedThroughProperty("Hold_Time")]
	internal virtual DataGridViewTextBoxColumn Hold_Time { get; set; }

	[field: AccessedThroughProperty("Leg_TotalTime")]
	internal virtual DataGridViewTextBoxColumn Leg_TotalTime { get; set; }

	[field: AccessedThroughProperty("Leg_FuelRequired")]
	internal virtual DataGridViewTextBoxColumn Leg_FuelRequired { get; set; }

	[field: AccessedThroughProperty("Leg_FuelRemaining")]
	internal virtual DataGridViewTextBoxColumn Leg_FuelRemaining { get; set; }

	[field: AccessedThroughProperty("Coordinates")]
	internal virtual DataGridViewTextBoxColumn Coordinates { get; set; }

	public FlightPlanWaypointsWeapon()
	{
		InitializeComponent();
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
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
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Expected O, but got Unknown
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Expected O, but got Unknown
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
		Button_ClearTime = new DarkButton();
		Button_EditSpeedAltitude = new DarkButton();
		Button_EditTime = new DarkButton();
		Button_DeleteWaypoint = new DarkButton();
		Button_InsertWaypoint = new DarkButton();
		DGV_WaypointsWeapon = new DarkDataGridView();
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
		Coordinates = new DataGridViewTextBoxColumn();
		((ISupportInitialize)(object)DGV_WaypointsWeapon).BeginInit();
		((Control)this).SuspendLayout();
		((Control)Button_ClearTime).Anchor = (AnchorStyles)4;
		((Button)Button_ClearTime).AutoSizeMode = (AutoSizeMode)0;
		((Control)Button_ClearTime).Location = new Point(371, 301);
		((Control)Button_ClearTime).Name = "Button_ClearTime";
		((Control)Button_ClearTime).Padding = new Padding(5);
		((Control)Button_ClearTime).Size = new Size(86, 33);
		((Control)Button_ClearTime).TabIndex = 26;
		Button_ClearTime.Text = "Clear Time";
		((Control)Button_EditSpeedAltitude).Anchor = (AnchorStyles)4;
		((Button)Button_EditSpeedAltitude).AutoSizeMode = (AutoSizeMode)0;
		((Control)Button_EditSpeedAltitude).Location = new Point(187, 301);
		((Control)Button_EditSpeedAltitude).Name = "Button_EditSpeedAltitude";
		((Control)Button_EditSpeedAltitude).Padding = new Padding(5);
		((Control)Button_EditSpeedAltitude).Size = new Size(86, 33);
		((Control)Button_EditSpeedAltitude).TabIndex = 25;
		Button_EditSpeedAltitude.Text = "Edit Speed / Altitude";
		((Control)Button_EditTime).Anchor = (AnchorStyles)4;
		((Button)Button_EditTime).AutoSizeMode = (AutoSizeMode)0;
		((Control)Button_EditTime).Location = new Point(279, 301);
		((Control)Button_EditTime).Name = "Button_EditTime";
		((Control)Button_EditTime).Padding = new Padding(5);
		((Control)Button_EditTime).Size = new Size(86, 33);
		((Control)Button_EditTime).TabIndex = 24;
		Button_EditTime.Text = "Edit Time";
		((Control)Button_DeleteWaypoint).Anchor = (AnchorStyles)4;
		((Button)Button_DeleteWaypoint).AutoSizeMode = (AutoSizeMode)0;
		((Control)Button_DeleteWaypoint).Location = new Point(95, 301);
		((Control)Button_DeleteWaypoint).Name = "Button_DeleteWaypoint";
		((Control)Button_DeleteWaypoint).Padding = new Padding(5);
		((Control)Button_DeleteWaypoint).Size = new Size(86, 33);
		((Control)Button_DeleteWaypoint).TabIndex = 23;
		Button_DeleteWaypoint.Text = "Delete Waypoint";
		((Control)Button_InsertWaypoint).Anchor = (AnchorStyles)4;
		((Button)Button_InsertWaypoint).AutoSizeMode = (AutoSizeMode)0;
		((Control)Button_InsertWaypoint).Location = new Point(3, 301);
		((Control)Button_InsertWaypoint).Name = "Button_InsertWaypoint";
		((Control)Button_InsertWaypoint).Padding = new Padding(5);
		((Control)Button_InsertWaypoint).Size = new Size(86, 33);
		((Control)Button_InsertWaypoint).TabIndex = 22;
		Button_InsertWaypoint.Text = "Insert Waypoint";
		((DataGridView)DGV_WaypointsWeapon).AllowUserToAddRows = false;
		((DataGridView)DGV_WaypointsWeapon).AllowUserToDeleteRows = false;
		((DataGridView)DGV_WaypointsWeapon).AllowUserToOrderColumns = true;
		((DataGridView)DGV_WaypointsWeapon).AllowUserToResizeColumns = false;
		((DataGridView)DGV_WaypointsWeapon).AllowUserToResizeRows = false;
		((Control)DGV_WaypointsWeapon).Anchor = (AnchorStyles)13;
		((DataGridView)DGV_WaypointsWeapon).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_WaypointsWeapon).BorderStyle = (BorderStyle)0;
		((DataGridView)DGV_WaypointsWeapon).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_WaypointsWeapon).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.BackColor = SystemColors.Control;
		val.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		val.ForeColor = SystemColors.WindowText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_WaypointsWeapon).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_WaypointsWeapon).ColumnHeadersHeight = 22;
		((DataGridView)DGV_WaypointsWeapon).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[19]
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
			(DataGridViewColumn)Coordinates
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		val2.ForeColor = SystemColors.ControlText;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle = val2;
		((DataGridView)DGV_WaypointsWeapon).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_WaypointsWeapon).EnableHeadersVisualStyles = false;
		((Control)DGV_WaypointsWeapon).Location = new Point(0, 0);
		((Control)DGV_WaypointsWeapon).Name = "DGV_WaypointsWeapon";
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Control;
		val3.Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = SystemColors.WindowText;
		val3.SelectionBackColor = SystemColors.Highlight;
		val3.SelectionForeColor = SystemColors.HighlightText;
		val3.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_WaypointsWeapon).RowHeadersDefaultCellStyle = val3;
		((DataGridView)DGV_WaypointsWeapon).RowHeadersVisible = false;
		((DataGridView)DGV_WaypointsWeapon).RowHeadersWidth = 10;
		val4.BackColor = Color.FromArgb(60, 63, 65);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_WaypointsWeapon).RowsDefaultCellStyle = val4;
		((DataGridView)DGV_WaypointsWeapon).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_WaypointsWeapon).Size = new Size(501, 295);
		((Control)DGV_WaypointsWeapon).TabIndex = 11;
		((DataGridViewColumn)ID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)4;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		val5.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)ID).DefaultCellStyle = val5;
		((DataGridViewColumn)ID).Frozen = true;
		((DataGridViewColumn)ID).HeaderText = "#";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Width = 5;
		((DataGridViewColumn)ObjectID).DataPropertyName = "ObjectID";
		((DataGridViewColumn)ObjectID).HeaderText = "ObjectID";
		((DataGridViewColumn)ObjectID).Name = "ObjectID";
		((DataGridViewColumn)ObjectID).Visible = false;
		((DataGridViewColumn)Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Type).DataPropertyName = "Type";
		((DataGridViewColumn)Type).Frozen = true;
		((DataGridViewColumn)Type).HeaderText = "Type";
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)Type).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)Type).Width = 54;
		((DataGridViewColumn)Time_Zulu).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Time_Zulu).DataPropertyName = "Time_Zulu";
		val6.Alignment = (DataGridViewContentAlignment)512;
		((DataGridViewColumn)Time_Zulu).DefaultCellStyle = val6;
		((DataGridViewColumn)Time_Zulu).HeaderText = "Zulu Time";
		((DataGridViewColumn)Time_Zulu).Name = "Time_Zulu";
		((DataGridViewColumn)Time_Zulu).ReadOnly = true;
		((DataGridViewColumn)Time_Zulu).Width = 77;
		((DataGridViewColumn)Time_Local).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Time_Local).DataPropertyName = "Time_Local";
		val7.Alignment = (DataGridViewContentAlignment)512;
		((DataGridViewColumn)Time_Local).DefaultCellStyle = val7;
		((DataGridViewColumn)Time_Local).HeaderText = "Local Time";
		((DataGridViewColumn)Time_Local).Name = "Time_Local";
		((DataGridViewColumn)Time_Local).ReadOnly = true;
		((DataGridViewColumn)Time_Local).Width = 82;
		((DataGridViewColumn)TimeFixedImg).AutoSizeMode = (DataGridViewAutoSizeColumnMode)4;
		((DataGridViewColumn)TimeFixedImg).DataPropertyName = "TimeFixedImg";
		((DataGridViewColumn)TimeFixedImg).HeaderText = " ";
		((DataGridViewColumn)TimeFixedImg).Name = "TimeFixedImg";
		((DataGridViewColumn)TimeFixedImg).Width = 5;
		((DataGridViewColumn)TimeFixed).DataPropertyName = "TimeFixed";
		((DataGridViewColumn)TimeFixed).HeaderText = "TimeFixed";
		((DataGridViewColumn)TimeFixed).Name = "TimeFixed";
		((DataGridViewColumn)TimeFixed).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)TimeFixed).Visible = false;
		((DataGridViewColumn)TimeFixed).Width = 5;
		((DataGridViewColumn)DesiredSpeed).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DesiredSpeed).DataPropertyName = "DesiredSpeed";
		val8.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)DesiredSpeed).DefaultCellStyle = val8;
		((DataGridViewColumn)DesiredSpeed).HeaderText = " Speed";
		((DataGridViewColumn)DesiredSpeed).Name = "DesiredSpeed";
		((DataGridViewColumn)DesiredSpeed).ReadOnly = true;
		((DataGridViewColumn)DesiredSpeed).Width = 64;
		((DataGridViewColumn)SpeedFixedImg).AutoSizeMode = (DataGridViewAutoSizeColumnMode)4;
		((DataGridViewColumn)SpeedFixedImg).DataPropertyName = "SpeedFixedImg";
		((DataGridViewColumn)SpeedFixedImg).HeaderText = " ";
		((DataGridViewColumn)SpeedFixedImg).Name = "SpeedFixedImg";
		((DataGridViewColumn)SpeedFixedImg).Width = 5;
		((DataGridViewColumn)SpeedFixed).DataPropertyName = "SpeedFixed";
		val9.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)SpeedFixed).DefaultCellStyle = val9;
		((DataGridViewColumn)SpeedFixed).HeaderText = "SpeedFixed";
		((DataGridViewColumn)SpeedFixed).Name = "SpeedFixed";
		((DataGridViewColumn)SpeedFixed).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)SpeedFixed).Visible = false;
		((DataGridViewColumn)SpeedFixed).Width = 5;
		((DataGridViewColumn)DesiredAltitude).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)DesiredAltitude).DataPropertyName = "DesiredAltitude";
		val10.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)DesiredAltitude).DefaultCellStyle = val10;
		((DataGridViewColumn)DesiredAltitude).HeaderText = "Altitude";
		((DataGridViewColumn)DesiredAltitude).Name = "DesiredAltitude";
		((DataGridViewColumn)DesiredAltitude).ReadOnly = true;
		((DataGridViewColumn)DesiredAltitude).Width = 65;
		((DataGridViewColumn)Leg_Distance).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_Distance).DataPropertyName = "Leg_Distance";
		val11.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_Distance).DefaultCellStyle = val11;
		((DataGridViewColumn)Leg_Distance).HeaderText = "Leg Distance";
		((DataGridViewColumn)Leg_Distance).Name = "Leg_Distance";
		((DataGridViewColumn)Leg_Distance).Width = 93;
		((DataGridViewColumn)Leg_TotalDistance).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_TotalDistance).DataPropertyName = "Leg_TotalDistance";
		val12.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_TotalDistance).DefaultCellStyle = val12;
		((DataGridViewColumn)Leg_TotalDistance).HeaderText = "Total Distance";
		((DataGridViewColumn)Leg_TotalDistance).Name = "Leg_TotalDistance";
		((DataGridViewColumn)Leg_TotalDistance).Width = 99;
		((DataGridViewColumn)Leg_Time).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_Time).DataPropertyName = "Leg_Time";
		val13.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_Time).DefaultCellStyle = val13;
		((DataGridViewColumn)Leg_Time).HeaderText = "Leg Time";
		((DataGridViewColumn)Leg_Time).Name = "Leg_Time";
		((DataGridViewColumn)Leg_Time).ToolTipText = "Time needed to fly this leg.";
		((DataGridViewColumn)Leg_Time).Width = 74;
		((DataGridViewColumn)Hold_Time).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Hold_Time).DataPropertyName = "Hold_Time";
		val14.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Hold_Time).DefaultCellStyle = val14;
		((DataGridViewColumn)Hold_Time).HeaderText = "Hold Time";
		((DataGridViewColumn)Hold_Time).Name = "Hold_Time";
		((DataGridViewColumn)Hold_Time).ToolTipText = "Loiter time at waypoint to allow flight to form up (Push Point).";
		((DataGridViewColumn)Hold_Time).Width = 78;
		((DataGridViewColumn)Leg_TotalTime).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_TotalTime).DataPropertyName = "Leg_TotalTime";
		val15.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_TotalTime).DefaultCellStyle = val15;
		((DataGridViewColumn)Leg_TotalTime).HeaderText = "Total Time";
		((DataGridViewColumn)Leg_TotalTime).Name = "Leg_TotalTime";
		((DataGridViewColumn)Leg_TotalTime).Width = 80;
		((DataGridViewColumn)Leg_FuelRequired).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_FuelRequired).DataPropertyName = "Leg_FuelRequired";
		val16.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_FuelRequired).DefaultCellStyle = val16;
		((DataGridViewColumn)Leg_FuelRequired).HeaderText = "Leg Fuel";
		((DataGridViewColumn)Leg_FuelRequired).Name = "Leg_FuelRequired";
		((DataGridViewColumn)Leg_FuelRequired).ToolTipText = "Fuel neeed to fly this leg.";
		((DataGridViewColumn)Leg_FuelRequired).Width = 71;
		((DataGridViewColumn)Leg_FuelRemaining).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Leg_FuelRemaining).DataPropertyName = "Leg_FuelRemaining";
		val17.Alignment = (DataGridViewContentAlignment)64;
		((DataGridViewColumn)Leg_FuelRemaining).DefaultCellStyle = val17;
		((DataGridViewColumn)Leg_FuelRemaining).HeaderText = "Remaining Fuel";
		((DataGridViewColumn)Leg_FuelRemaining).Name = "Leg_FuelRemaining";
		((DataGridViewColumn)Leg_FuelRemaining).ToolTipText = "Remaining mission fuel (i.e. total fuel minus reserves) after this leg has been completed.";
		((DataGridViewColumn)Leg_FuelRemaining).Width = 103;
		((DataGridViewColumn)Coordinates).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Coordinates).DataPropertyName = "Coordinates";
		((DataGridViewColumn)Coordinates).HeaderText = "Coordinates";
		((DataGridViewColumn)Coordinates).Name = "Coordinates";
		((DataGridViewColumn)Coordinates).Width = 86;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((UserControl)this).AutoSizeMode = (AutoSizeMode)0;
		((Control)this).BackColor = Color.Transparent;
		((Control)this).Controls.Add((Control)(object)Button_ClearTime);
		((Control)this).Controls.Add((Control)(object)Button_EditSpeedAltitude);
		((Control)this).Controls.Add((Control)(object)Button_EditTime);
		((Control)this).Controls.Add((Control)(object)Button_DeleteWaypoint);
		((Control)this).Controls.Add((Control)(object)Button_InsertWaypoint);
		((Control)this).Controls.Add((Control)(object)DGV_WaypointsWeapon);
		((Control)this).Name = "FlightPlanWaypointsWeapon";
		((Control)this).Size = new Size(505, 424);
		((ISupportInitialize)(object)DGV_WaypointsWeapon).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void method_0(object sender, EventArgs e)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			int count = ((DataGridView)DGV_WaypointsWeapon).Rows.Count;
			int num = count - 1;
			Waypoint theOriginalWaypoint = default(Waypoint);
			Waypoint waypoint10 = default(Waypoint);
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow val = ((DataGridView)DGV_WaypointsWeapon).Rows[i];
				if (!val.Selected)
				{
					continue;
				}
				theOriginalWaypoint = (Waypoint)((DataGridViewBand)val).Tag;
				if (theOriginalWaypoint.IsStationStartWaypoint() || theOriginalWaypoint.IsHoldStartWaypoint())
				{
					Interaction.MsgBox((object)"Cannot insert a new waypoint between Start and End Station waypoints!", (MsgBoxStyle)0, (object)null);
					continue;
				}
				if (theOriginalWaypoint.IsSplitWaypoint())
				{
					Interaction.MsgBox((object)"Cannot insert waypoints with Split formation. Change the formation and try again.", (MsgBoxStyle)0, (object)null);
					return;
				}
				int num2;
				Waypoint.WaypointType type;
				int assignObjectID;
				switch (theOriginalWaypoint.Type)
				{
				default:
					num2 = 0;
					goto IL_013e;
				case Waypoint.WaypointType.ManualPlottedCourseWaypoint:
					type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
					assignObjectID = 1;
					break;
				case Waypoint.WaypointType.TurningPoint:
					type = Waypoint.WaypointType.TurningPoint;
					assignObjectID = 1;
					break;
				case Waypoint.WaypointType.StrikeIngress:
					type = Waypoint.WaypointType.StrikeIngress;
					assignObjectID = 1;
					break;
				case Waypoint.WaypointType.StrikeEgress:
					type = Waypoint.WaypointType.StrikeEgress;
					assignObjectID = 1;
					break;
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Split:
				case Waypoint.WaypointType.WeaponLaunch:
					type = Waypoint.WaypointType.StrikeIngress;
					assignObjectID = 1;
					break;
				case Waypoint.WaypointType.Formate:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.WeaponTarget:
					type = Waypoint.WaypointType.StrikeEgress;
					assignObjectID = 1;
					break;
				case Waypoint.WaypointType.TerminalPoint:
				case Waypoint.WaypointType.LocalizationRun:
				case Waypoint.WaypointType.PathfindingPoint:
				case Waypoint.WaypointType.PickupPoint:
					num2 = 0;
					goto IL_013e;
				case Waypoint.WaypointType.PatrolStation:
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.LandingMarshal:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.TakeOff:
				case Waypoint.WaypointType.Marshal:
				case Waypoint.WaypointType.Land:
				case Waypoint.WaypointType.StationStart_Racetrack:
				case Waypoint.WaypointType.StationStart_FigureEight:
				case Waypoint.WaypointType.StationStart_Area:
				case Waypoint.WaypointType.StationStart_RaceTrackRandom:
				case Waypoint.WaypointType.StationEnd:
				case Waypoint.WaypointType.HoldStart:
				case Waypoint.WaypointType.HoldEnd:
					{
						type = Waypoint.WaypointType.TurningPoint;
						assignObjectID = 1;
						break;
					}
					IL_013e:
					type = (Waypoint.WaypointType)num2;
					assignObjectID = 1;
					break;
				}
				GeoPoint geoPoint = new GeoPoint((byte)assignObjectID != 0);
				GeoPoint geoPoint2 = new GeoPoint();
				GeoPoint geoPoint3 = new GeoPoint();
				GeoPoint geoPoint4 = new GeoPoint();
				GeoPoint geoPoint5 = new GeoPoint();
				GeoPoint geoPoint6 = new GeoPoint();
				if (i + 1 <= count - 1)
				{
					Waypoint waypoint = Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute[i + 1];
					double x = Math2.CalcAzimuth(theOriginalWaypoint.Latitude, theOriginalWaypoint.Longitude, waypoint.Latitude, waypoint.Longitude);
					double num3 = Math2.CalcDist(theOriginalWaypoint.Latitude, theOriginalWaypoint.Longitude, waypoint.Latitude, waypoint.Longitude);
					Waypoint waypoint2 = theOriginalWaypoint;
					double Lon = waypoint2.Longitude;
					Waypoint waypoint3;
					double Lat = (waypoint3 = theOriginalWaypoint).Latitude;
					GeoPoint geoPoint7;
					double out_lon = (geoPoint7 = geoPoint).Longitude;
					GeoPoint geoPoint8;
					double out_lat = (geoPoint8 = geoPoint).Latitude;
					double distance_NM = num3 / 2.0;
					double bearing = Math2.NormalizeBearing(x);
					Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
					geoPoint8.Latitude = out_lat;
					geoPoint7.Longitude = out_lon;
					waypoint3.Latitude = Lat;
					waypoint2.Longitude = Lon;
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_LeadElementWingman))
					{
						Waypoint waypoint_LeadElementWingman = theOriginalWaypoint.Waypoint_LeadElementWingman;
						Waypoint waypoint4 = (Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman) ? waypoint : waypoint.Waypoint_LeadElementWingman);
						x = Math2.CalcAzimuth(waypoint_LeadElementWingman.Latitude, waypoint_LeadElementWingman.Longitude, waypoint4.Latitude, waypoint4.Longitude);
						num3 = Math2.CalcDist(waypoint_LeadElementWingman.Latitude, waypoint_LeadElementWingman.Longitude, waypoint4.Latitude, waypoint4.Longitude);
						bearing = waypoint_LeadElementWingman.Longitude;
						distance_NM = (waypoint3 = waypoint_LeadElementWingman).Latitude;
						out_lat = (geoPoint8 = geoPoint2).Longitude;
						out_lon = (geoPoint7 = geoPoint2).Latitude;
						Lat = num3 / 2.0;
						Lon = Math2.NormalizeBearing(x);
						Geodesic_EdWilliams.CalcPoint_Williams(ref bearing, ref distance_NM, ref out_lat, ref out_lon, ref Lat, ref Lon);
						geoPoint7.Latitude = out_lon;
						geoPoint8.Longitude = out_lat;
						waypoint3.Latitude = distance_NM;
						waypoint_LeadElementWingman.Longitude = bearing;
					}
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_SecondElement))
					{
						Waypoint waypoint_SecondElement = theOriginalWaypoint.Waypoint_SecondElement;
						Waypoint waypoint5 = (Information.IsNothing((object)waypoint.Waypoint_SecondElement) ? waypoint : waypoint.Waypoint_SecondElement);
						x = Math2.CalcAzimuth(waypoint_SecondElement.Latitude, waypoint_SecondElement.Longitude, waypoint5.Latitude, waypoint5.Longitude);
						num3 = Math2.CalcDist(waypoint_SecondElement.Latitude, waypoint_SecondElement.Longitude, waypoint5.Latitude, waypoint5.Longitude);
						Lon = waypoint_SecondElement.Longitude;
						Lat = (waypoint3 = waypoint_SecondElement).Latitude;
						out_lon = (geoPoint7 = geoPoint).Longitude;
						out_lat = (geoPoint8 = geoPoint).Latitude;
						distance_NM = num3 / 2.0;
						bearing = Math2.NormalizeBearing(x);
						Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
						geoPoint8.Latitude = out_lat;
						geoPoint7.Longitude = out_lon;
						waypoint3.Latitude = Lat;
						waypoint_SecondElement.Longitude = Lon;
					}
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_SecondElementWingman))
					{
						Waypoint waypoint_SecondElement2 = theOriginalWaypoint.Waypoint_SecondElement;
						Waypoint waypoint6 = ((!Information.IsNothing((object)waypoint.Waypoint_SecondElement)) ? waypoint.Waypoint_SecondElement : waypoint);
						x = Math2.CalcAzimuth(waypoint_SecondElement2.Latitude, waypoint_SecondElement2.Longitude, waypoint6.Latitude, waypoint6.Longitude);
						num3 = Math2.CalcDist(waypoint_SecondElement2.Latitude, waypoint_SecondElement2.Longitude, waypoint6.Latitude, waypoint6.Longitude);
						bearing = waypoint_SecondElement2.Longitude;
						distance_NM = (waypoint3 = waypoint_SecondElement2).Latitude;
						out_lat = (geoPoint8 = geoPoint).Longitude;
						out_lon = (geoPoint7 = geoPoint).Latitude;
						Lat = num3 / 2.0;
						Lon = Math2.NormalizeBearing(x);
						Geodesic_EdWilliams.CalcPoint_Williams(ref bearing, ref distance_NM, ref out_lat, ref out_lon, ref Lat, ref Lon);
						geoPoint7.Latitude = out_lon;
						geoPoint8.Longitude = out_lat;
						waypoint3.Latitude = distance_NM;
						waypoint_SecondElement2.Longitude = bearing;
					}
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_ThirdElement))
					{
						Waypoint waypoint_SecondElement3 = theOriginalWaypoint.Waypoint_SecondElement;
						Waypoint waypoint7 = (Information.IsNothing((object)waypoint.Waypoint_SecondElement) ? waypoint : waypoint.Waypoint_SecondElement);
						x = Math2.CalcAzimuth(waypoint_SecondElement3.Latitude, waypoint_SecondElement3.Longitude, waypoint7.Latitude, waypoint7.Longitude);
						num3 = Math2.CalcDist(waypoint_SecondElement3.Latitude, waypoint_SecondElement3.Longitude, waypoint7.Latitude, waypoint7.Longitude);
						Lon = waypoint_SecondElement3.Longitude;
						Lat = (waypoint3 = waypoint_SecondElement3).Latitude;
						out_lon = (geoPoint7 = geoPoint).Longitude;
						out_lat = (geoPoint8 = geoPoint).Latitude;
						distance_NM = num3 / 2.0;
						bearing = Math2.NormalizeBearing(x);
						Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
						geoPoint8.Latitude = out_lat;
						geoPoint7.Longitude = out_lon;
						waypoint3.Latitude = Lat;
						waypoint_SecondElement3.Longitude = Lon;
					}
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_ThirdElementWingman))
					{
						Waypoint waypoint_SecondElement4 = theOriginalWaypoint.Waypoint_SecondElement;
						Waypoint waypoint8 = (Information.IsNothing((object)waypoint.Waypoint_SecondElement) ? waypoint : waypoint.Waypoint_SecondElement);
						x = Math2.CalcAzimuth(waypoint_SecondElement4.Latitude, waypoint_SecondElement4.Longitude, waypoint8.Latitude, waypoint8.Longitude);
						num3 = Math2.CalcDist(waypoint_SecondElement4.Latitude, waypoint_SecondElement4.Longitude, waypoint8.Latitude, waypoint8.Longitude);
						bearing = waypoint_SecondElement4.Longitude;
						distance_NM = (waypoint3 = waypoint_SecondElement4).Latitude;
						out_lat = (geoPoint8 = geoPoint).Longitude;
						out_lon = (geoPoint7 = geoPoint).Latitude;
						Lat = num3 / 2.0;
						Lon = Math2.NormalizeBearing(x);
						Geodesic_EdWilliams.CalcPoint_Williams(ref bearing, ref distance_NM, ref out_lat, ref out_lon, ref Lat, ref Lon);
						geoPoint7.Latitude = out_lon;
						geoPoint8.Longitude = out_lat;
						waypoint3.Latitude = distance_NM;
						waypoint_SecondElement4.Longitude = bearing;
					}
				}
				else
				{
					Waypoint waypoint9 = theOriginalWaypoint;
					double Lon = waypoint9.Longitude;
					Waypoint waypoint3;
					double Lat = (waypoint3 = theOriginalWaypoint).Latitude;
					GeoPoint geoPoint7;
					double out_lon = (geoPoint7 = geoPoint).Longitude;
					GeoPoint geoPoint8;
					double out_lat = (geoPoint8 = geoPoint).Latitude;
					int distance_NM2 = 10;
					int bearing2 = 0;
					Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM2, ref bearing2);
					geoPoint8.Latitude = out_lat;
					geoPoint7.Longitude = out_lon;
					waypoint3.Latitude = Lat;
					waypoint9.Longitude = Lon;
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_LeadElementWingman))
					{
						Waypoint waypoint_LeadElementWingman2 = theOriginalWaypoint.Waypoint_LeadElementWingman;
						out_lat = waypoint_LeadElementWingman2.Longitude;
						out_lon = (waypoint3 = theOriginalWaypoint.Waypoint_LeadElementWingman).Latitude;
						Lat = (geoPoint8 = geoPoint).Longitude;
						Lon = (geoPoint7 = geoPoint).Latitude;
						bearing2 = 10;
						distance_NM2 = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref out_lat, ref out_lon, ref Lat, ref Lon, ref bearing2, ref distance_NM2);
						geoPoint7.Latitude = Lon;
						geoPoint8.Longitude = Lat;
						waypoint3.Latitude = out_lon;
						waypoint_LeadElementWingman2.Longitude = out_lat;
					}
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_SecondElement))
					{
						Waypoint waypoint_SecondElement5 = theOriginalWaypoint.Waypoint_SecondElement;
						Lon = waypoint_SecondElement5.Longitude;
						Lat = (waypoint3 = theOriginalWaypoint.Waypoint_SecondElement).Latitude;
						out_lon = (geoPoint7 = geoPoint).Longitude;
						out_lat = (geoPoint8 = geoPoint).Latitude;
						distance_NM2 = 10;
						bearing2 = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM2, ref bearing2);
						geoPoint8.Latitude = out_lat;
						geoPoint7.Longitude = out_lon;
						waypoint3.Latitude = Lat;
						waypoint_SecondElement5.Longitude = Lon;
					}
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_SecondElementWingman))
					{
						Waypoint waypoint_SecondElementWingman = theOriginalWaypoint.Waypoint_SecondElementWingman;
						out_lat = waypoint_SecondElementWingman.Longitude;
						out_lon = (waypoint3 = theOriginalWaypoint.Waypoint_SecondElementWingman).Latitude;
						Lat = (geoPoint8 = geoPoint).Longitude;
						Lon = (geoPoint7 = geoPoint).Latitude;
						bearing2 = 10;
						distance_NM2 = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref out_lat, ref out_lon, ref Lat, ref Lon, ref bearing2, ref distance_NM2);
						geoPoint7.Latitude = Lon;
						geoPoint8.Longitude = Lat;
						waypoint3.Latitude = out_lon;
						waypoint_SecondElementWingman.Longitude = out_lat;
					}
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_ThirdElement))
					{
						Waypoint waypoint_ThirdElement = theOriginalWaypoint.Waypoint_ThirdElement;
						Lon = waypoint_ThirdElement.Longitude;
						Lat = (waypoint3 = theOriginalWaypoint.Waypoint_ThirdElement).Latitude;
						out_lon = (geoPoint7 = geoPoint).Longitude;
						out_lat = (geoPoint8 = geoPoint).Latitude;
						distance_NM2 = 10;
						bearing2 = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM2, ref bearing2);
						geoPoint8.Latitude = out_lat;
						geoPoint7.Longitude = out_lon;
						waypoint3.Latitude = Lat;
						waypoint_ThirdElement.Longitude = Lon;
					}
					if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_ThirdElementWingman))
					{
						Waypoint waypoint_ThirdElementWingman = theOriginalWaypoint.Waypoint_ThirdElementWingman;
						out_lat = waypoint_ThirdElementWingman.Longitude;
						out_lon = (waypoint3 = theOriginalWaypoint.Waypoint_ThirdElementWingman).Latitude;
						Lat = (geoPoint8 = geoPoint).Longitude;
						Lon = (geoPoint7 = geoPoint).Latitude;
						bearing2 = 10;
						distance_NM2 = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref out_lat, ref out_lon, ref Lat, ref Lon, ref bearing2, ref distance_NM2);
						geoPoint7.Latitude = Lon;
						geoPoint8.Longitude = Lat;
						waypoint3.Latitude = out_lon;
						waypoint_ThirdElementWingman.Longitude = out_lat;
					}
				}
				Scenario theScen = Client.CurrentScenario;
				Doctrine FlightLeadDoctrine = null;
				waypoint10 = Waypoint.CopyWaypoint(ref theScen, ref theOriginalWaypoint, CopyWingmanWaypoints: true, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
				waypoint10.Type = type;
				waypoint10.Latitude = geoPoint.Latitude;
				waypoint10.Longitude = geoPoint.Longitude;
				waypoint10.Hold_Time = 0f;
				waypoint10.Station_Time = 0f;
				waypoint10.SpacingManeuver_Time = 0f;
				if (!Information.IsNothing((object)waypoint10.Waypoint_LeadElementWingman))
				{
					Waypoint waypoint_LeadElementWingman3 = waypoint10.Waypoint_LeadElementWingman;
					waypoint_LeadElementWingman3.Type = type;
					waypoint_LeadElementWingman3.Latitude = geoPoint2.Latitude;
					waypoint_LeadElementWingman3.Longitude = geoPoint2.Longitude;
				}
				if (!Information.IsNothing((object)waypoint10.Waypoint_SecondElement))
				{
					Waypoint waypoint_SecondElement6 = waypoint10.Waypoint_SecondElement;
					waypoint_SecondElement6.Type = type;
					waypoint_SecondElement6.Latitude = geoPoint3.Latitude;
					waypoint_SecondElement6.Longitude = geoPoint3.Longitude;
				}
				if (!Information.IsNothing((object)waypoint10.Waypoint_SecondElementWingman))
				{
					Waypoint waypoint_SecondElementWingman2 = waypoint10.Waypoint_SecondElementWingman;
					waypoint_SecondElementWingman2.Type = type;
					waypoint_SecondElementWingman2.Latitude = geoPoint4.Latitude;
					waypoint_SecondElementWingman2.Longitude = geoPoint4.Longitude;
				}
				if (!Information.IsNothing((object)waypoint10.Waypoint_ThirdElement))
				{
					Waypoint waypoint_ThirdElement2 = waypoint10.Waypoint_ThirdElement;
					waypoint_ThirdElement2.Type = type;
					waypoint_ThirdElement2.Latitude = geoPoint5.Latitude;
					waypoint_ThirdElement2.Longitude = geoPoint5.Longitude;
				}
				if (!Information.IsNothing((object)waypoint10.Waypoint_ThirdElementWingman))
				{
					Waypoint waypoint_ThirdElementWingman2 = waypoint10.Waypoint_ThirdElementWingman;
					waypoint_ThirdElementWingman2.Type = type;
					waypoint_ThirdElementWingman2.Latitude = geoPoint6.Latitude;
					waypoint_ThirdElementWingman2.Longitude = geoPoint6.Longitude;
				}
				ActiveUnit_Navigator.AddWaypoint(ref Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute, i + 1, waypoint10);
				break;
			}
			if (!Information.IsNothing((object)theOriginalWaypoint) && !Information.IsNothing((object)waypoint10))
			{
				for (int j = Client.CurrentScenario.ActiveUnits_List.Count - 1; j >= 0; j += -1)
				{
					ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits_List[j];
					if (Information.IsNothing((object)activeUnit) || !activeUnit.IsOperating())
					{
						continue;
					}
					if ((activeUnit.IsAircraft || (activeUnit.IsGroup && ((Group)activeUnit).Type == Group.GroupType.AirGroup)) && activeUnit.Navigator.HasFlightPlan && !Information.IsNothing((object)activeUnit.get_UnitSide(SetSideOnly: false)) && activeUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
					{
						int distance_NM2 = activeUnit.Navigator.PlottedCourse.Count() - 1;
						for (int k = 0; k <= distance_NM2; k++)
						{
							if (activeUnit.Navigator.PlottedCourse[k] == theOriginalWaypoint && k >= 0)
							{
								ActiveUnit_Navigator navigator = activeUnit.Navigator;
								Waypoint[] theFlightPlan = navigator.PlottedCourse;
								ActiveUnit_Navigator.AddWaypoint(ref theFlightPlan, k + 1, waypoint10);
								navigator.PlottedCourse = theFlightPlan;
								flag = true;
							}
							if (flag)
							{
								break;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			if (((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count > 0)
			{
				Client.FlightPlanEditorWeaponRouteWindow.SelectedRow = ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).SelectedRows[0]).Index;
				Client.FlightPlanEditorWeaponRouteWindow.SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Rows[Client.FlightPlanEditorWeaponRouteWindow.SelectedRow]).Tag;
				((DataGridView)DGV_WaypointsWeapon).Rows[0].Selected = false;
			}
			Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: true, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: true, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
			if (((Control)Client.FlightPlanTimeWindow).Visible)
			{
			}
			if (((Control)Client.AirTaskingOrderWindow).Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
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
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count == 0)
			{
				return;
			}
			for (int i = ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 1; i >= 0; i += -1)
			{
				DataGridViewRow val = ((DataGridView)DGV_WaypointsWeapon).Rows[i];
				if (!val.Selected)
				{
					continue;
				}
				Waypoint waypoint = (Waypoint)((DataGridViewBand)val).Tag;
				switch (waypoint.Type)
				{
				default:
					if (waypoint.IsHoldWaypoint())
					{
						Interaction.MsgBox((object)"Cannot delete a Hold Start or Hold End waypoint!", (MsgBoxStyle)0, (object)null);
					}
					else if (waypoint.IsStationWaypoint())
					{
						Interaction.MsgBox((object)"Cannot delete a Station Start or Station End waypoint!", (MsgBoxStyle)0, (object)null);
					}
					else
					{
						Interaction.MsgBox((object)"Cannot delete waypoint!", (MsgBoxStyle)0, (object)null);
					}
					break;
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
					if (waypoint.IsSplitWaypoint())
					{
						Interaction.MsgBox((object)"Cannot delete waypoints with Split formation. Change the formation and try again.", (MsgBoxStyle)0, (object)null);
					}
					else
					{
						if (Information.IsNothing((object)waypoint))
						{
							break;
						}
						foreach (ActiveUnit unit in Client.CurrentSide.Units)
						{
							if (!unit.Navigator.HasPlottedCourse())
							{
								continue;
							}
							if (!unit.Navigator.PlottedCourse.Contains(waypoint))
							{
								if (!Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_LeadElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_LeadElementWingman, RemoveWingmanWaypoints: false);
								}
								else if (!Information.IsNothing((object)waypoint.Waypoint_SecondElement) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_SecondElement))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_SecondElement, RemoveWingmanWaypoints: false);
								}
								else if (!Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_SecondElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_SecondElementWingman, RemoveWingmanWaypoints: false);
								}
								else if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElement) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_ThirdElement))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_ThirdElement, RemoveWingmanWaypoints: false);
								}
								else if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_ThirdElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_ThirdElementWingman, RemoveWingmanWaypoints: false);
								}
							}
							else
							{
								unit.Navigator.RemoveWaypoint_Soft(waypoint, RemoveWingmanWaypoints: true);
							}
						}
					}
					break;
				}
			}
			if (((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count > 0)
			{
				Client.FlightPlanEditorWeaponRouteWindow.SelectedRow = ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).SelectedRows[0]).Index;
				Client.FlightPlanEditorWeaponRouteWindow.SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Rows[Client.FlightPlanEditorWeaponRouteWindow.SelectedRow]).Tag;
				((DataGridView)DGV_WaypointsWeapon).Rows[0].Selected = false;
			}
			Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: true, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: true, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
			if (((Control)Client.FlightPlanTimeWindow).Visible)
			{
			}
			if (((Control)Client.AirTaskingOrderWindow).Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
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
		Waypoint waypoint = default(Waypoint);
		for (int i = ((DataGridView)Client.FlightPlanEditorWeaponRouteWindow.theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows.Count - 1; i >= 0; i += -1)
		{
			DataGridViewRow val = ((DataGridView)Client.FlightPlanEditorWeaponRouteWindow.theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[i];
			if (val.Selected)
			{
				waypoint = (Waypoint)((DataGridViewBand)val).Tag;
				break;
			}
		}
		if (!Information.IsNothing((object)waypoint))
		{
			Client.FlightPlanTimeWindow.ViaFlightPlanEditor = true;
			((Control)Client.FlightPlanTimeWindow).Show();
			((Control)Client.FlightPlanTimeWindow).BringToFront();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		int num = ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataGridViewRow val = ((DataGridView)DGV_WaypointsWeapon).Rows[i];
			if (val.Selected)
			{
				Waypoint speedAlt_FlightPlanWaypoint = (Waypoint)((DataGridViewBand)val).Tag;
				MyProject.Forms.SpeedAlt.SpeedAlt_FlightPlanWaypoint = speedAlt_FlightPlanWaypoint;
				MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = null;
				MyProject.Forms.SpeedAlt.SpeedAlt_Flight = null;
				MyProject.Forms.SpeedAlt.SpeedAlt_Mission = null;
				MyProject.Forms.SpeedAlt.LoadForm();
				((Control)MyProject.Forms.SpeedAlt).Show();
				break;
			}
		}
	}

	private void method_4(object sender, DataGridViewCellPaintingEventArgs e)
	{
		try
		{
			if (e.RowIndex == 0 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["Time_Zulu"]).Index)
			{
				Rectangle cellBounds = e.CellBounds;
				cellBounds.Y += (int)Math.Round((double)e.CellBounds.Height / 2.0);
				cellBounds.Height = (int)Math.Round((double)e.CellBounds.Height / 2.0);
				e.PaintBackground(cellBounds, true);
				e.PaintContent(cellBounds);
			}
			else if (e.RowIndex == 0 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["DesiredSpeed"]).Index)
			{
				Rectangle cellBounds2 = e.CellBounds;
				cellBounds2.Y += (int)Math.Round((double)e.CellBounds.Height / 2.0);
				cellBounds2.Height = (int)Math.Round((double)e.CellBounds.Height / 2.0);
				e.PaintBackground(cellBounds2, true);
				e.PaintContent(cellBounds2);
			}
			else if (e.RowIndex == 0)
			{
				_ = (e.ColumnIndex == 2) | (e.ColumnIndex == 3);
			}
			if (((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["Time_Local"]).Index == e.ColumnIndex && e.RowIndex >= 0)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				if (((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).SelectedRows[0]).Index == e.RowIndex)
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.SelectionBackColor, 1, (ButtonBorderStyle)3, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0);
				}
				else
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0);
				}
				Rectangle cellBounds3 = e.CellBounds;
				int width = ((DataGridView)DGV_WaypointsWeapon).GetCellDisplayRectangle(((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["TimeFixedImg"]).Index, e.RowIndex, true).Width;
				cellBounds3.Width += width;
				ControlPaint.DrawBorder(e.Graphics, cellBounds3, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, Color.Red, 0, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["DesiredSpeed"]).Index == e.ColumnIndex && e.RowIndex >= 0)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				if (((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).SelectedRows[0]).Index == e.RowIndex)
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.SelectionBackColor, 1, (ButtonBorderStyle)3, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0);
				}
				else
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0);
				}
				Rectangle cellBounds4 = e.CellBounds;
				int width2 = ((DataGridView)DGV_WaypointsWeapon).GetCellDisplayRectangle(((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["SpeedFixedImg"]).Index, e.RowIndex, true).Width;
				cellBounds4.Width += width2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds4, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, Color.Red, 0, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["Time_Local"]).Index == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0);
				Rectangle cellBounds5 = e.CellBounds;
				cellBounds5.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds5, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3);
				cellBounds5.Y++;
				cellBounds5.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds5, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 2, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["DesiredSpeed"]).Index == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0);
				Rectangle cellBounds6 = e.CellBounds;
				cellBounds6.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds6, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3);
				cellBounds6.Y++;
				cellBounds6.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds6, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 2, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["TimeFixedImg"]).Index == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0);
				Rectangle cellBounds7 = e.CellBounds;
				cellBounds7.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds7, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3);
				cellBounds7.Height -= 2;
				cellBounds7.Y++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds7, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 2, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["SpeedFixedImg"]).Index == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, (DataGridViewPaintParts)123);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)3, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).DefaultCellStyle.BackColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)0);
				Rectangle cellBounds8 = e.CellBounds;
				cellBounds8.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds8, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)3);
				cellBounds8.Y++;
				cellBounds8.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds8, ((DataGridView)DGV_WaypointsWeapon).GridColor, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 2, (ButtonBorderStyle)3, Color.Red, 1, (ButtonBorderStyle)0, e.CellStyle.BackColor, 1, (ButtonBorderStyle)3);
				((HandledEventArgs)(object)e).Handled = true;
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

	private void method_5(object sender, DataGridViewColumnEventArgs e)
	{
		Rectangle displayRectangle = ((DataGridView)DGV_WaypointsWeapon).DisplayRectangle;
		((Control)DGV_WaypointsWeapon).Invalidate(displayRectangle);
	}

	private void method_6(object sender, PaintEventArgs e)
	{
	}

	private void method_7(object sender, ScrollEventArgs e)
	{
	}

	private void method_8(object sender, EventArgs e)
	{
	}

	private void method_9(object sender, EventArgs e)
	{
	}

	private void method_10(object sender, EventArgs e)
	{
		if (Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh)
		{
			DisplayLocks();
			EnableAndDisableCells();
			EnableAndDisableButtons();
		}
	}

	public void DisplayLocks()
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		try
		{
			Client.FlightPlanEditorWeaponRouteWindow.theImageLocked.MakeTransparent(Color.White);
			Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked.MakeTransparent(Color.White);
			Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured.MakeTransparent(Color.White);
			Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable.MakeTransparent(Color.White);
			Client.FlightPlanEditorWeaponRouteWindow.theImageRelative.MakeTransparent(Color.White);
			bool waypointList_Refresh = Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh;
			Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = false;
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_WaypointsWeapon).Rows)
			{
				DataGridViewRow val = item;
				if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["TimeFixed"].Value), 1))
				{
					if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["TimeFixed"].Value), 0))
					{
						if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["TimeFixed"].Value), 2))
						{
							if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable)
							{
								val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable;
							}
						}
						else if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["TimeFixed"].Value), 3))
						{
							if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageRelative)
							{
								val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageRelative;
							}
						}
						else if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured)
						{
							val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured;
						}
					}
					else if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked)
					{
						val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked;
					}
				}
				else if (val.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageLocked)
				{
					val.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageLocked;
				}
				if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["SpeedFixed"].Value), 1))
				{
					if (object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["SpeedFixed"].Value), 0))
					{
						if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked)
						{
							val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked;
						}
					}
					else if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["SpeedFixed"].Value), 2))
					{
						if (!object.Equals(RuntimeHelpers.GetObjectValue(val.Cells["SpeedFixed"].Value), 3))
						{
							if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured)
							{
								val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured;
							}
						}
						else if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageRelative)
						{
							val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageRelative;
						}
					}
					else if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable)
					{
						val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable;
					}
				}
				else if (val.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageLocked)
				{
					val.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageLocked;
				}
			}
			Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = waypointList_Refresh;
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		try
		{
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_WaypointsWeapon).Rows)
			{
				DataGridViewRow val = item;
				Waypoint waypoint = (Waypoint)((DataGridViewBand)val).Tag;
				if (!Information.IsNothing((object)waypoint))
				{
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
					if (waypoint.Type == Waypoint.WaypointType.HoldEnd)
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

	public void EnableAndDisableButtons()
	{
		try
		{
			Button_InsertWaypoint.Enabled = false;
			Button_DeleteWaypoint.Enabled = false;
			Button_EditSpeedAltitude.Enabled = false;
			Button_EditTime.Enabled = false;
			Button_ClearTime.Enabled = false;
			if (((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count == 1)
			{
				int num = ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 1;
				int num2 = 0;
				Waypoint waypoint;
				while (true)
				{
					if (num2 > num)
					{
						return;
					}
					DataGridViewRow val = ((DataGridView)DGV_WaypointsWeapon).Rows[num2];
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
				Button_EditTime.Enabled = true;
			}
			else if (((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count > 1)
			{
				if (((DataGridView)DGV_WaypointsWeapon).Rows.Count > 0)
				{
					Button_ClearTime.Enabled = true;
					Button_DeleteWaypoint.Enabled = true;
				}
			}
			else if (((DataGridView)DGV_WaypointsWeapon).Rows.Count > 0)
			{
				Button_ClearTime.Enabled = true;
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

	private void method_11(object sender, DataGridViewCellEventArgs e)
	{
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0890: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07be: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0840: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			int num = ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 1;
			int num2 = 0;
			DataGridViewRow val2 = default(DataGridViewRow);
			while (num2 <= num)
			{
				DataGridViewRow val = ((DataGridView)DGV_WaypointsWeapon).Rows[num2];
				if (!val.Selected)
				{
					num2++;
					continue;
				}
				val2 = val;
				Client.FlightPlanEditorWeaponRouteWindow.SelectedWaypoint = (Waypoint)((DataGridViewBand)val2).Tag;
				Client.SelectedWaypoint = Client.FlightPlanEditorWeaponRouteWindow.SelectedWaypoint;
				DataGridViewColumn val3 = ((DataGridView)DGV_WaypointsWeapon).Columns[e.ColumnIndex];
				if (Operators.CompareString(val3.Name, "Type", true) == 0)
				{
					if (!((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
					{
						DataTable theComboBoxDataSource_WaypointType = new DataTable();
						DataGridViewComboBoxCell val4 = (DataGridViewComboBoxCell)((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
						Waypoint.ComboBoxDataSource_WaypointType_WeaponRoute(ref theComboBoxDataSource_WaypointType);
						val4.DataSource = theComboBoxDataSource_WaypointType;
						val4.DisplayMember = "Description";
						val4.ValueMember = "ID";
						val4.DropDownWidth = 500;
					}
					((DataGridView)DGV_WaypointsWeapon).BeginEdit(true);
					if (((DataGridView)DGV_WaypointsWeapon).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_WaypointsWeapon).EditingControl))
					{
						((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_WaypointsWeapon).EditingControl).DroppedDown = true;
					}
					break;
				}
				int num3;
				if (Operators.CompareString(val3.Name, "Formation", true) != 0)
				{
					if (Operators.CompareString(val3.Name, "AARUsage", true) == 0)
					{
						Waypoint waypoint = (Waypoint)((DataGridViewBand)val).Tag;
						if (!Information.IsNothing((object)waypoint))
						{
							if (!((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
							{
								DataTable dataTable = new DataTable();
								Doctrine doctrine = waypoint.GetDoctrine(Client.CurrentScenario);
								Doctrine.DoctrineItem_E theDocEnum = Doctrine.DoctrineItem_E.UseReplenishment;
								doctrine.Populate_DataTable_States(dataTable, ref theDocEnum);
								DataGridViewComboBoxCell val5 = (DataGridViewComboBoxCell)((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
								val5.DataSource = dataTable;
								val5.DisplayMember = "Description";
								val5.ValueMember = "ID";
								val5.DropDownWidth = 500;
							}
							((DataGridView)DGV_WaypointsWeapon).BeginEdit(true);
							if (((DataGridView)DGV_WaypointsWeapon).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_WaypointsWeapon).EditingControl))
							{
								((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_WaypointsWeapon).EditingControl).DroppedDown = true;
							}
							break;
						}
					}
					if (Operators.CompareString(val3.Name, "AARSelection", true) == 0)
					{
						Waypoint waypoint2 = (Waypoint)((DataGridViewBand)val).Tag;
						if (!Information.IsNothing((object)waypoint2))
						{
							if (!((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
							{
								DataTable dataTable2 = new DataTable();
								Doctrine doctrine2 = waypoint2.GetDoctrine(Client.CurrentScenario);
								Doctrine.DoctrineItem_E theDocEnum = Doctrine.DoctrineItem_E.ReplenishmentSelection;
								doctrine2.Populate_DataTable_States(dataTable2, ref theDocEnum);
								DataGridViewComboBoxCell val6 = (DataGridViewComboBoxCell)((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
								val6.DataSource = dataTable2;
								val6.DisplayMember = "Description";
								val6.ValueMember = "ID";
								val6.DropDownWidth = 500;
							}
							((DataGridView)DGV_WaypointsWeapon).BeginEdit(true);
							if (((DataGridView)DGV_WaypointsWeapon).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_WaypointsWeapon).EditingControl))
							{
								((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_WaypointsWeapon).EditingControl).DroppedDown = true;
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
								if (waypoint3.SpeedFixed == Waypoint.FixedFree.Free)
								{
									if (Information.IsNothing((object)waypoint3.DesiredSpeed) && waypoint3.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
									{
										goto IL_056a;
									}
									waypoint3.SpeedFixed = Waypoint.FixedFree.Fixed;
									num3 = 1;
								}
								else if (waypoint3.SpeedFixed == Waypoint.FixedFree.Fixed)
								{
									if (waypoint3.Type != Waypoint.WaypointType.TakeOff && waypoint3.Type != Waypoint.WaypointType.Land)
									{
										waypoint3.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
										waypoint3.DesiredSpeed = null;
										waypoint3.DesiredSpeedOverride = null;
										waypoint3.SpeedFixed = Waypoint.FixedFree.Free;
										num3 = 1;
									}
									else
									{
										waypoint3.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
										waypoint3.DesiredSpeed = null;
										waypoint3.DesiredSpeedOverride = null;
										waypoint3.SpeedFixed = Waypoint.FixedFree.Fixed;
										num3 = 1;
									}
								}
								else
								{
									if (waypoint3.SpeedFixed != Waypoint.FixedFree.Relative)
									{
										goto IL_056a;
									}
									waypoint3.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
									waypoint3.DesiredSpeed = null;
									waypoint3.DesiredSpeedOverride = null;
									waypoint3.SpeedFixed = Waypoint.FixedFree.Free;
									num3 = 1;
								}
								goto IL_056b;
							}
							Waypoint waypoint4 = (Waypoint)((DataGridViewBand)val).Tag;
							if (Information.IsNothing((object)waypoint4.Time_Zulu))
							{
								break;
							}
							int num4;
							if (waypoint4.TimeFixed != Waypoint.FixedFree.Free)
							{
								if (waypoint4.TimeFixed == Waypoint.FixedFree.Fixed)
								{
									if (waypoint4.FlightFormation == Waypoint.Formation.Split)
									{
										waypoint4.TimeFixed = Waypoint.FixedFree.Relative;
										val.Cells["TimeFixed"].Value = waypoint4.TimeFixed;
										num4 = 1;
									}
									else
									{
										waypoint4.TimeFixed = Waypoint.FixedFree.Free;
										val.Cells["TimeFixed"].Value = waypoint4.TimeFixed;
										num4 = 1;
									}
								}
								else if (waypoint4.TimeFixed == Waypoint.FixedFree.Relative)
								{
									waypoint4.TimeFixed = Waypoint.FixedFree.Free;
									val.Cells["TimeFixed"].Value = waypoint4.TimeFixed;
									num4 = 1;
								}
								else
								{
									num4 = 1;
								}
							}
							else
							{
								waypoint4.TimeFixed = Waypoint.FixedFree.Fixed;
								val.Cells["TimeFixed"].Value = waypoint4.TimeFixed;
								num4 = 1;
							}
							flag = (byte)num4 != 0;
							flag2 = true;
							flag4 = true;
							break;
						}
						if (!((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
						{
							DataTable theComboBoxDataSource_TurnRate = new DataTable();
							DataGridViewComboBoxCell val7 = (DataGridViewComboBoxCell)((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
							Waypoint.ComboBoxDataSource_TurnRate(ref theComboBoxDataSource_TurnRate);
							val7.DataSource = theComboBoxDataSource_TurnRate;
							val7.DisplayMember = "Description";
							val7.ValueMember = "ID";
							val7.DropDownWidth = 500;
						}
						((DataGridView)DGV_WaypointsWeapon).BeginEdit(true);
						if (((DataGridView)DGV_WaypointsWeapon).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_WaypointsWeapon).EditingControl))
						{
							((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_WaypointsWeapon).EditingControl).DroppedDown = true;
						}
						break;
					}
					if (!((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
					{
						DataTable theComboBoxDataSource_SpeedToT = new DataTable();
						DataGridViewComboBoxCell val8 = (DataGridViewComboBoxCell)((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
						Waypoint.ComboBoxDataSource_SpeedToT(ref theComboBoxDataSource_SpeedToT);
						val8.DataSource = theComboBoxDataSource_SpeedToT;
						val8.DisplayMember = "Description";
						val8.ValueMember = "ID";
						val8.DropDownWidth = 500;
					}
					((DataGridView)DGV_WaypointsWeapon).BeginEdit(true);
					if (((DataGridView)DGV_WaypointsWeapon).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_WaypointsWeapon).EditingControl))
					{
						((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_WaypointsWeapon).EditingControl).DroppedDown = true;
					}
					break;
				}
				if (!((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index].IsInEditMode)
				{
					DataTable theComboBoxDataSource_Formation = new DataTable();
					DataGridViewComboBoxCell val9 = (DataGridViewComboBoxCell)((DataGridView)DGV_WaypointsWeapon)[((DataGridViewBand)val3).Index, ((DataGridViewBand)val).Index];
					Waypoint.ComboBoxDataSource_Formation(ref theComboBoxDataSource_Formation);
					val9.DataSource = theComboBoxDataSource_Formation;
					val9.DisplayMember = "Description";
					val9.ValueMember = "ID";
					val9.DropDownWidth = 500;
				}
				((DataGridView)DGV_WaypointsWeapon).BeginEdit(true);
				if (((DataGridView)DGV_WaypointsWeapon).Rows[e.RowIndex].Cells[((DataGridViewColumn)Type).Name].Selected && !Information.IsNothing((object)((DataGridView)DGV_WaypointsWeapon).EditingControl))
				{
					((ComboBox)(DataGridViewComboBoxEditingControl)((DataGridView)DGV_WaypointsWeapon).EditingControl).DroppedDown = true;
				}
				break;
				IL_056b:
				flag = (byte)num3 != 0;
				flag2 = true;
				break;
				IL_056a:
				num3 = 1;
				goto IL_056b;
			}
			if (!Information.IsNothing((object)val2))
			{
				Button_InsertWaypoint.Enabled = true;
				Button_DeleteWaypoint.Enabled = true;
				Button_EditTime.Enabled = true;
				Button_ClearTime.Enabled = true;
				Button_EditSpeedAltitude.Enabled = true;
			}
			else
			{
				Button_InsertWaypoint.Enabled = false;
				Button_DeleteWaypoint.Enabled = false;
				Button_EditTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				Button_EditSpeedAltitude.Enabled = false;
			}
			if (!flag)
			{
				if (!flag3)
				{
					if (flag2)
					{
						Client.FlightPlanEditorWeaponRouteWindow.RefreshGrid();
					}
				}
				else
				{
					Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
				}
			}
			else
			{
				Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, flag2, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, flag3, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
			}
			if (flag || flag3 || flag2)
			{
				DisplayLocks();
				EnableAndDisableCells();
			}
			if (((Control)Client.FlightPlanTimeWindow).Visible)
			{
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
			else if (theWaypoint.FlightFormation != Waypoint.Formation.Spread)
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
			else
			{
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

	private void method_12(object sender, DataGridViewCellEventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count != 0 && Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh)
		{
			method_14(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = true;
		if (((DataGridView)DGV_WaypointsWeapon).IsCurrentCellDirty)
		{
			((DataGridView)DGV_WaypointsWeapon).CommitEdit((DataGridViewDataErrorContexts)512);
		}
	}

	private void method_14(object sender, DataGridViewCellEventArgs e)
	{
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			if (Information.IsNothing((object)Client.FlightPlanEditorWeaponRouteWindow.SelectedWeapon) || e.RowIndex > Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute.Count() - 1)
			{
				return;
			}
			Waypoint waypoint = Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute[e.RowIndex];
			if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["Type"]).Index)
			{
				DataGridViewCell obj = ((DataGridView)DGV_WaypointsWeapon)[e.ColumnIndex, e.RowIndex];
				object Type = RuntimeHelpers.GetObjectValue(obj.Value);
				int? num = Waypoint.WaypointTypeSelection_To_WaypointType_WeaponRoute(ref Type);
				obj.Value = RuntimeHelpers.GetObjectValue(Type);
				Waypoint.WaypointType value = (Waypoint.WaypointType)num.Value;
				if (e.RowIndex != 0)
				{
					if (e.RowIndex == ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 1)
					{
						if (value == Waypoint.WaypointType.Land)
						{
							waypoint.Type = value;
						}
						else
						{
							Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
							Interaction.MsgBox((object)"The last waypoint in a flightplan must be the Landing waypoint!", (MsgBoxStyle)0, (object)null);
						}
					}
					else if (e.RowIndex == ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 2)
					{
						if (value == Waypoint.WaypointType.LandingMarshal)
						{
							waypoint.Type = value;
						}
						else
						{
							Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
							Interaction.MsgBox((object)"The second last waypoint in a flightplan must be the Landing Marshal waypoint!", (MsgBoxStyle)0, (object)null);
						}
					}
					else
					{
						int num2;
						bool flag2;
						bool flag3;
						int num4;
						switch (value)
						{
						case Waypoint.WaypointType.TakeOff:
							if (e.RowIndex != 0)
							{
								Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
								Interaction.MsgBox((object)"The Take-Off waypoint must be the first waypoint in a flightplan!", (MsgBoxStyle)0, (object)null);
							}
							else
							{
								waypoint.Type = value;
							}
							break;
						case Waypoint.WaypointType.Land:
							if (e.RowIndex == ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 1)
							{
								waypoint.Type = value;
								break;
							}
							Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
							Interaction.MsgBox((object)"The Landing waypoint must be the last waypoint in a flightplan!", (MsgBoxStyle)0, (object)null);
							break;
						case Waypoint.WaypointType.LandingMarshal:
							if (e.RowIndex == ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 2)
							{
								waypoint.Type = value;
								break;
							}
							Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
							Interaction.MsgBox((object)"The Landing Marshal waypoint must be the second last waypoint in a flightplan!", (MsgBoxStyle)0, (object)null);
							break;
						case Waypoint.WaypointType.StationEnd:
							Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
							Interaction.MsgBox((object)"The Station End waypoint is set automatically when a Station Start waypoint is configured. Select Station Start instead.", (MsgBoxStyle)0, (object)null);
							break;
						case Waypoint.WaypointType.HoldStart:
							if (e.RowIndex < 1)
							{
								Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
								Interaction.MsgBox((object)"The first waypoint in a flightplan can not be a Hold Start waypoint!", (MsgBoxStyle)0, (object)null);
							}
							else if (e.RowIndex > ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 4)
							{
								Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
								Interaction.MsgBox((object)"The last three waypoints in a flightplan can not be a Hold Start waypoint! Reason: Neither the Landing nor Landing Marshal waypoints can be a Hold End waypoint. Note! The waypoint after Hold Start is automatically turned into a Hold End waypoint.", (MsgBoxStyle)0, (object)null);
							}
							break;
						case Waypoint.WaypointType.HoldEnd:
							Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
							Interaction.MsgBox((object)"The Hold End waypoint is set automatically when a Hold Start waypoint is configured. Select Hold Start instead.", (MsgBoxStyle)0, (object)null);
							break;
						default:
						{
							int num5;
							if (!waypoint.IsHoldStartWaypoint())
							{
								if (!waypoint.IsStationStartWaypoint())
								{
									num2 = 0;
									goto IL_02fe;
								}
								num5 = 1;
							}
							else
							{
								num5 = 1;
							}
							flag = (byte)num5 != 0;
							num2 = 0;
							goto IL_02fe;
						}
						case Waypoint.WaypointType.StationStart_Racetrack:
						case Waypoint.WaypointType.StationStart_FigureEight:
						case Waypoint.WaypointType.StationStart_Area:
						case Waypoint.WaypointType.StationStart_RaceTrackRandom:
							{
								if (e.RowIndex < 1)
								{
									Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
									Interaction.MsgBox((object)"The first waypoint in a flightplan can not be a Station Start waypoint!", (MsgBoxStyle)0, (object)null);
								}
								else if (e.RowIndex > ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 4)
								{
									Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
									Interaction.MsgBox((object)"The last three waypoints in a flightplan can not be a Station Start waypoint! Reason: Neither the Landing nor Landing Marshal waypoints can be a Station End waypoint. Note! The waypoint after Station Start is automatically turned into a Station End waypoint.", (MsgBoxStyle)0, (object)null);
								}
								break;
							}
							IL_02fe:
							flag2 = (byte)num2 != 0;
							flag3 = false;
							if (waypoint.Type != Waypoint.WaypointType.WeaponTarget && value != Waypoint.WaypointType.WeaponTarget && waypoint.Type != Waypoint.WaypointType.Target && value != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.InitialPoint && value != Waypoint.WaypointType.InitialPoint && waypoint.Type != Waypoint.WaypointType.WeaponLaunch)
							{
								if (value != Waypoint.WaypointType.WeaponLaunch)
								{
									int num3;
									if (waypoint.Type != Waypoint.WaypointType.TurningPoint && value != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.StrikeIngress && value != Waypoint.WaypointType.StrikeIngress && waypoint.Type != Waypoint.WaypointType.StrikeEgress)
									{
										if (value != Waypoint.WaypointType.StrikeEgress)
										{
											goto IL_037d;
										}
										num3 = 1;
									}
									else
									{
										num3 = 1;
									}
									flag3 = (byte)num3 != 0;
									goto IL_037d;
								}
								num4 = 1;
							}
							else
							{
								num4 = 1;
							}
							flag2 = (byte)num4 != 0;
							goto IL_037d;
							IL_037d:
							waypoint.Type = value;
							switch (value)
							{
							case Waypoint.WaypointType.Assemble:
								waypoint.Hold_Time = 600f;
								flag = true;
								break;
							case Waypoint.WaypointType.Refuel:
								Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
								break;
							default:
								if (!flag2)
								{
									if (flag3)
									{
										Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
									}
								}
								else
								{
									Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
									flag = true;
								}
								break;
							}
							break;
						}
					}
				}
				else if (value == Waypoint.WaypointType.TakeOff)
				{
					waypoint.Type = value;
				}
				else
				{
					Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
					Interaction.MsgBox((object)"The first waypoint in a flightplan must be the Take-Off waypoint!", (MsgBoxStyle)0, (object)null);
				}
				if (waypoint.Type != Waypoint.WaypointType.Assemble && waypoint.Type != Waypoint.WaypointType.HoldEnd)
				{
					if (waypoint.Hold_Time > 0f)
					{
						waypoint.Hold_Time = 0f;
						Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
						flag = true;
					}
				}
				else
				{
					Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
					flag = true;
				}
			}
			if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["Formation"]).Index)
			{
				DataGridViewCell obj2 = ((DataGridView)DGV_WaypointsWeapon)[e.ColumnIndex, e.RowIndex];
				object Type = RuntimeHelpers.GetObjectValue(obj2.Value);
				int? num = Waypoint.FormationSelection_To_Formation(ref Type);
				obj2.Value = RuntimeHelpers.GetObjectValue(Type);
				Waypoint.Formation value2 = (Waypoint.Formation)num.Value;
				if (value2 == Waypoint.Formation.Split && waypoint.IsStationWaypoint())
				{
					Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
					Interaction.MsgBox((object)"Station waypoints cannot be set to Split formation.", (MsgBoxStyle)0, (object)null);
				}
				else if (value2 == Waypoint.Formation.Split && waypoint.IsHoldOrAssembleWaypoint())
				{
					Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
					Interaction.MsgBox((object)"Hold and Assemble waypoints cannot be set to Split formation.", (MsgBoxStyle)0, (object)null);
				}
				else if (value2 == Waypoint.Formation.Split && e.RowIndex <= 1)
				{
					Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
					Interaction.MsgBox((object)"The first two waypoint in a flightplan cannot be set to Split formation.", (MsgBoxStyle)0, (object)null);
				}
				else if (value2 == Waypoint.Formation.Split && e.RowIndex >= ((DataGridView)DGV_WaypointsWeapon).Rows.Count - 1)
				{
					Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
					Interaction.MsgBox((object)"The last waypoint in a flightplan cannot be set to Split formation.", (MsgBoxStyle)0, (object)null);
				}
				else if (value2 == Waypoint.Formation.Split && waypoint.Type == Waypoint.WaypointType.LandingMarshal)
				{
					Client.FlightPlanEditorWeaponRouteWindow.LoadGrid();
					Interaction.MsgBox((object)"A landing marshal waypoint cannot be set to Split formation.", (MsgBoxStyle)0, (object)null);
				}
				else
				{
					Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: true, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: true, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
					flag = true;
				}
			}
			if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["TurnRate"]).Index)
			{
				DataGridViewCell obj3 = ((DataGridView)DGV_WaypointsWeapon)[e.ColumnIndex, e.RowIndex];
				object Type = RuntimeHelpers.GetObjectValue(obj3.Value);
				int? num = Waypoint.TurnRateSelection_To_TurnRate(ref Type);
				obj3.Value = RuntimeHelpers.GetObjectValue(Type);
				waypoint.TurnRate_Navigation = (Waypoint.TurnRateCategory)num.Value;
				Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: true, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
				flag = true;
			}
			if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["AARUsage"]).Index)
			{
				waypoint.GetDoctrine(Client.CurrentScenario).set_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UseUnderwayRefuelAndReplenishment?)(Doctrine._UseUnderwayRefuelAndReplenishment)Conversions.ToInteger(((DataGridView)DGV_WaypointsWeapon)[e.ColumnIndex, e.RowIndex].Value));
				Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
			}
			if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["AARSelection"]).Index)
			{
				waypoint.GetDoctrine(Client.CurrentScenario).set_ReplenishmentSelection(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)(Doctrine._UnderwayRefuelAndReplenishmentSelection)Conversions.ToInteger(((DataGridView)DGV_WaypointsWeapon)[e.ColumnIndex, e.RowIndex].Value));
				Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: true, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: false);
			}
			if (e.RowIndex != -1 && e.ColumnIndex == ((DataGridViewBand)((DataGridView)DGV_WaypointsWeapon).Columns["SpeedToT"]).Index)
			{
				DataGridViewCell obj4 = ((DataGridView)DGV_WaypointsWeapon)[e.ColumnIndex, e.RowIndex];
				object Type = RuntimeHelpers.GetObjectValue(obj4.Value);
				int? num = Waypoint.SpeedToTSelection_To_SpeedToT(ref Type);
				obj4.Value = RuntimeHelpers.GetObjectValue(Type);
				waypoint.SpeedAdjustmentToT = (Waypoint.SpeedToT)num.Value;
			}
			DisplayLocks();
			EnableAndDisableCells();
			EnableAndDisableButtons();
			if (flag && ((Control)Client.AirTaskingOrderWindow).Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
				Client.AirTaskingOrderWindow.EnableAndDisableButtons();
			}
			Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = false;
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

	private void method_15(object sender, EventArgs e)
	{
		if (Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh)
		{
			_ = ((BaseCollection)((DataGridView)DGV_WaypointsWeapon).SelectedRows).Count;
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		try
		{
			Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(RefreshMainform: false, RefreshFlightPlanEditorWeaponRouteWindow: true, RefreshFlightPlanEditorWeaponRouteWindow_Limited: false, RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid: false, RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks: true);
			EnableAndDisableCells();
			EnableAndDisableButtons();
			AMP_General.RefreshFlightPlanErrorWindow();
			Client.MustRefreshMainForm = true;
			MyProject.Forms.MainForm.MapRender_Tactical();
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

	static FlightPlanWaypointsWeapon()
	{
		Class72.smethod_20();
	}
}

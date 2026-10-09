using System;
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
public sealed class FlightPlanEditorWeaponRoute : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	public bool WaypointList_Refresh;

	public Weapon SelectedWeapon;

	public Waypoint[] SelectedRoute;

	public Waypoint SelectedWaypoint;

	public int SelectedRow;

	public FlightPlanWaypointsWeapon theFlightPlanWaypointsWeapon;

	private DataTable dataTable_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private DataTable dataTable_1;

	public Bitmap theImageLocked;

	public Bitmap theImageUnlocked;

	public Bitmap theImageNotConfigured;

	public Bitmap theImageNotLockable;

	public Bitmap theImageRelative;

	[field: AccessedThroughProperty("Button_ClearRoute")]
	internal virtual DarkButton Button_ClearRoute { get; set; }

	[field: AccessedThroughProperty("Button_CopyRouteFromWeapon1")]
	internal virtual DarkButton Button_CopyRouteFromWeapon1 { get; set; }

	[field: AccessedThroughProperty("FlightPlanWaypointsWeapon1")]
	internal virtual FlightPlanWaypointsWeapon FlightPlanWaypointsWeapon1 { get; set; }

	[field: AccessedThroughProperty("Label_AircraftType")]
	internal virtual DarkLabel Label_AircraftType { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label_ImpactDateAndTime")]
	internal virtual DarkLabel Label_ImpactDateAndTime { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label_LaunchDateAndTime")]
	internal virtual DarkLabel Label_LaunchDateAndTime { get; set; }

	[field: AccessedThroughProperty("GroupBox_SelectedFlight")]
	internal virtual DarkGroupBox GroupBox_SelectedFlight { get; set; }

	[field: AccessedThroughProperty("Combo_CurrentWeapon")]
	internal virtual DarkUIComboBox Combo_CurrentWeapon { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Combo_CurrentAircraft")]
	internal virtual DarkUIComboBox Combo_CurrentAircraft { get; set; }

	[field: AccessedThroughProperty("Button_CopyRouteToAllWeapons")]
	internal virtual DarkButton Button_CopyRouteToAllWeapons { get; set; }

	public FlightPlanEditorWeaponRoute()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(FlightPlanEditorWeaponRoute_FormClosing);
		((Control)this).VisibleChanged += FlightPlanEditorWeaponRoute_VisibleChanged;
		((Control)this).KeyDown += new KeyEventHandler(FlightPlanEditorWeaponRoute_KeyDown);
		((Form)this).Shown += FlightPlanEditorWeaponRoute_Shown;
		WaypointList_Refresh = true;
		SelectedRow = 0;
		dataTable_0 = new DataTable();
		dataTable_1 = new DataTable();
		theImageLocked = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Locked_16.png");
		theImageUnlocked = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Unlocked_16.png");
		theImageNotConfigured = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotConfigured_16.png");
		theImageNotLockable = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotLockable_16.png");
		theImageRelative = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Relative_16.png");
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
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Expected O, but got Unknown
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Expected O, but got Unknown
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		Button_ClearRoute = new DarkButton();
		Button_CopyRouteFromWeapon1 = new DarkButton();
		FlightPlanWaypointsWeapon1 = new FlightPlanWaypointsWeapon();
		Label_AircraftType = new DarkLabel();
		Label6 = new DarkLabel();
		Label8 = new DarkLabel();
		Label_ImpactDateAndTime = new DarkLabel();
		Label5 = new DarkLabel();
		Label_LaunchDateAndTime = new DarkLabel();
		GroupBox_SelectedFlight = new DarkGroupBox();
		Combo_CurrentWeapon = new DarkUIComboBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Combo_CurrentAircraft = new DarkUIComboBox();
		Button_CopyRouteToAllWeapons = new DarkButton();
		((Control)GroupBox_SelectedFlight).SuspendLayout();
		((Control)this).SuspendLayout();
		Button_ClearRoute.Enabled = false;
		((Control)Button_ClearRoute).Location = new Point(302, 49);
		((Control)Button_ClearRoute).Name = "Button_ClearRoute";
		((Control)Button_ClearRoute).Padding = new Padding(5);
		((Control)Button_ClearRoute).Size = new Size(185, 24);
		((Control)Button_ClearRoute).TabIndex = 37;
		Button_ClearRoute.Text = "Clear Route";
		((Control)Button_CopyRouteFromWeapon1).Location = new Point(302, 80);
		((Control)Button_CopyRouteFromWeapon1).Name = "Button_CopyRouteFromWeapon1";
		((Control)Button_CopyRouteFromWeapon1).Padding = new Padding(5);
		((Control)Button_CopyRouteFromWeapon1).Size = new Size(185, 24);
		((Control)Button_CopyRouteFromWeapon1).TabIndex = 35;
		Button_CopyRouteFromWeapon1.Text = "Copy Route From Weapon #1";
		((UserControl)FlightPlanWaypointsWeapon1).AutoSizeMode = (AutoSizeMode)0;
		((Control)FlightPlanWaypointsWeapon1).BackColor = Color.Transparent;
		((Control)FlightPlanWaypointsWeapon1).Dock = (DockStyle)2;
		((Control)FlightPlanWaypointsWeapon1).Location = new Point(0, 282);
		((Control)FlightPlanWaypointsWeapon1).MinimumSize = new Size(500, 500);
		((Control)FlightPlanWaypointsWeapon1).Name = "FlightPlanWaypointsWeapon1";
		((Control)FlightPlanWaypointsWeapon1).Size = new Size(629, 500);
		((Control)FlightPlanWaypointsWeapon1).TabIndex = 38;
		Label_AircraftType.AutoSize = true;
		((Control)Label_AircraftType).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AircraftType).Location = new Point(125, 147);
		((Control)Label_AircraftType).Name = "Label_AircraftType";
		((Control)Label_AircraftType).Size = new Size(93, 15);
		((Control)Label_AircraftType).TabIndex = 40;
		((Label)Label_AircraftType).Text = "<Weapon type>";
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(18, 147);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(54, 15);
		((Control)Label6).TabIndex = 39;
		((Label)Label6).Text = "Weapon:";
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(18, 226);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(101, 15);
		((Control)Label8).TabIndex = 44;
		((Label)Label8).Text = "Zulu impact time:";
		Label_ImpactDateAndTime.AutoSize = true;
		((Control)Label_ImpactDateAndTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ImpactDateAndTime).Location = new Point(125, 226);
		((Control)Label_ImpactDateAndTime).Name = "Label_ImpactDateAndTime";
		((Control)Label_ImpactDateAndTime).Size = new Size(136, 15);
		((Control)Label_ImpactDateAndTime).TabIndex = 43;
		((Label)Label_ImpactDateAndTime).Text = "<Impact date and time>";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(18, 198);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(100, 15);
		((Control)Label5).TabIndex = 42;
		((Label)Label5).Text = "Zulu launch time:";
		Label_LaunchDateAndTime.AutoSize = true;
		((Control)Label_LaunchDateAndTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_LaunchDateAndTime).Location = new Point(125, 198);
		((Control)Label_LaunchDateAndTime).Name = "Label_LaunchDateAndTime";
		((Control)Label_LaunchDateAndTime).Size = new Size(138, 15);
		((Control)Label_LaunchDateAndTime).TabIndex = 41;
		((Label)Label_LaunchDateAndTime).Text = "<Launch date and time>";
		((Control)GroupBox_SelectedFlight).Controls.Add((Control)(object)Combo_CurrentWeapon);
		((Control)GroupBox_SelectedFlight).Controls.Add((Control)(object)Label1);
		((Control)GroupBox_SelectedFlight).Controls.Add((Control)(object)Label2);
		((Control)GroupBox_SelectedFlight).Controls.Add((Control)(object)Combo_CurrentAircraft);
		((Control)GroupBox_SelectedFlight).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_SelectedFlight).Location = new Point(14, 11);
		((Control)GroupBox_SelectedFlight).Name = "GroupBox_SelectedFlight";
		((Control)GroupBox_SelectedFlight).Size = new Size(240, 84);
		((Control)GroupBox_SelectedFlight).TabIndex = 45;
		((GroupBox)GroupBox_SelectedFlight).TabStop = false;
		((GroupBox)GroupBox_SelectedFlight).Text = "Selected Weapon Route";
		((ComboBox)Combo_CurrentWeapon).BackColor = Color.Transparent;
		((ComboBox)Combo_CurrentWeapon).DrawMode = (DrawMode)1;
		((ComboBox)Combo_CurrentWeapon).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_CurrentWeapon).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_CurrentWeapon).FormattingEnabled = true;
		((Control)Combo_CurrentWeapon).Location = new Point(69, 48);
		((Control)Combo_CurrentWeapon).Name = "Combo_CurrentWeapon";
		((Control)Combo_CurrentWeapon).Size = new Size(153, 21);
		((Control)Combo_CurrentWeapon).TabIndex = 12;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(9, 25);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(49, 15);
		((Control)Label1).TabIndex = 11;
		((Label)Label1).Text = "Aircraft:";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(9, 53);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(54, 15);
		((Control)Label2).TabIndex = 11;
		((Label)Label2).Text = "Weapon:";
		((ComboBox)Combo_CurrentAircraft).BackColor = Color.Transparent;
		((ComboBox)Combo_CurrentAircraft).DrawMode = (DrawMode)1;
		((ComboBox)Combo_CurrentAircraft).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_CurrentAircraft).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_CurrentAircraft).FormattingEnabled = true;
		((Control)Combo_CurrentAircraft).Location = new Point(69, 24);
		((Control)Combo_CurrentAircraft).Name = "Combo_CurrentAircraft";
		((Control)Combo_CurrentAircraft).Size = new Size(153, 21);
		((Control)Combo_CurrentAircraft).TabIndex = 12;
		((Control)Button_CopyRouteToAllWeapons).Location = new Point(302, 110);
		((Control)Button_CopyRouteToAllWeapons).Name = "Button_CopyRouteToAllWeapons";
		((Control)Button_CopyRouteToAllWeapons).Padding = new Padding(5);
		((Control)Button_CopyRouteToAllWeapons).Size = new Size(185, 24);
		((Control)Button_CopyRouteToAllWeapons).TabIndex = 46;
		Button_CopyRouteToAllWeapons.Text = "Copy Route To All Weapons";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(629, 782);
		((Control)this).Controls.Add((Control)(object)Button_CopyRouteToAllWeapons);
		((Control)this).Controls.Add((Control)(object)GroupBox_SelectedFlight);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label_ImpactDateAndTime);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label_LaunchDateAndTime);
		((Control)this).Controls.Add((Control)(object)Label_AircraftType);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)FlightPlanWaypointsWeapon1);
		((Control)this).Controls.Add((Control)(object)Button_ClearRoute);
		((Control)this).Controls.Add((Control)(object)Button_CopyRouteFromWeapon1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(515, 821);
		((Control)this).Name = "FlightPlanEditorWeaponRoute";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit route for weapon <Weapon Name>";
		((Control)GroupBox_SelectedFlight).ResumeLayout(false);
		((Control)GroupBox_SelectedFlight).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void FlightPlanEditorWeaponRoute_FormClosing(object sender, FormClosingEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = true;
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void FlightPlanEditorWeaponRoute_VisibleChanged(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((Control)this).Visible)
		{
			LoadWindow();
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	public void LoadWindow()
	{
		LoadGrid();
		RefreshStats(RefreshAircraftNameAndLoadout: false);
		if (((Control)Client.FlightPlanTimeWindow).Visible)
		{
		}
	}

	public void RefreshWindow()
	{
		RefreshGrid();
		if (((Control)Client.FlightPlanTimeWindow).Visible)
		{
		}
	}

	public void ReloadWindow()
	{
		LoadWindow();
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private string method_2(ref ActiveUnit.Throttle throttle_0)
	{
		switch (throttle_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return throttle_0.ToString();
		case ActiveUnit.Throttle.FullStop:
			return "Full Stop";
		case ActiveUnit.Throttle.Loiter:
			return "Loiter";
		case ActiveUnit.Throttle.Cruise:
			return "Cruise";
		case ActiveUnit.Throttle.Full:
			return "Military";
		case ActiveUnit.Throttle.Flank:
			return "Afterburner";
		}
	}

	internal void RefreshStats(bool RefreshAircraftNameAndLoadout)
	{
		try
		{
			method_3();
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

	private void method_3()
	{
	}

	internal void LoadGrid()
	{
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		theFlightPlanWaypointsWeapon = FlightPlanWaypointsWeapon1;
		SelectedRow = 0;
		SelectedWaypoint = null;
		WaypointList_Refresh = false;
		dataTable_0.Clear();
		WaypointList_Refresh = true;
		if (dataTable_0.Columns.Count == 0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(string));
				int_0 = 0;
			}
			if (!dataTable_0.Columns.Contains("ObjectID"))
			{
				dataTable_0.Columns.Add("ObjectID", typeof(string));
				int_1 = 1;
			}
			if (!dataTable_0.Columns.Contains("Type"))
			{
				dataTable_0.Columns.Add("Type", typeof(int));
				int_2 = 2;
			}
			if (!dataTable_0.Columns.Contains("Time_Zulu"))
			{
				dataTable_0.Columns.Add("Time_Zulu", typeof(string));
				int_3 = 3;
			}
			if (!dataTable_0.Columns.Contains("Time_Local"))
			{
				dataTable_0.Columns.Add("Time_Local", typeof(string));
				int_4 = 4;
			}
			if (!dataTable_0.Columns.Contains("TimeFixedImg"))
			{
				dataTable_0.Columns.Add("TimeFixedImg", typeof(Image));
				int_6 = 5;
			}
			if (!dataTable_0.Columns.Contains("TimeFixed"))
			{
				dataTable_0.Columns.Add("TimeFixed", typeof(int));
				int_5 = 6;
			}
			if (!dataTable_0.Columns.Contains("DesiredSpeed"))
			{
				dataTable_0.Columns.Add("DesiredSpeed", typeof(string));
				int_7 = 7;
			}
			if (!dataTable_0.Columns.Contains("SpeedFixedImg"))
			{
				dataTable_0.Columns.Add("SpeedFixedImg", typeof(Image));
				int_9 = 8;
			}
			if (!dataTable_0.Columns.Contains("SpeedFixed"))
			{
				dataTable_0.Columns.Add("SpeedFixed", typeof(int));
				int_8 = 9;
			}
			if (!dataTable_0.Columns.Contains("DesiredAltitude"))
			{
				dataTable_0.Columns.Add("DesiredAltitude", typeof(string));
				int_10 = 10;
			}
			if (!dataTable_0.Columns.Contains("Leg_Distance"))
			{
				dataTable_0.Columns.Add("Leg_Distance", typeof(string));
				int_16 = 11;
			}
			if (!dataTable_0.Columns.Contains("Leg_TotalDistance"))
			{
				dataTable_0.Columns.Add("Leg_TotalDistance", typeof(string));
				int_17 = 12;
			}
			if (!dataTable_0.Columns.Contains("Leg_Time"))
			{
				dataTable_0.Columns.Add("Leg_Time", typeof(string));
				int_13 = 13;
			}
			if (!dataTable_0.Columns.Contains("Hold_Time"))
			{
				dataTable_0.Columns.Add("Hold_Time", typeof(string));
				int_14 = 14;
			}
			if (!dataTable_0.Columns.Contains("Leg_TotalTime"))
			{
				dataTable_0.Columns.Add("Leg_TotalTime", typeof(string));
				int_15 = 15;
			}
			if (!dataTable_0.Columns.Contains("Leg_FuelRequired"))
			{
				dataTable_0.Columns.Add("Leg_FuelRequired", typeof(string));
				int_11 = 16;
			}
			if (!dataTable_0.Columns.Contains("Leg_FuelRemaining"))
			{
				dataTable_0.Columns.Add("Leg_FuelRemaining", typeof(string));
				int_12 = 17;
			}
			if (!dataTable_0.Columns.Contains("Coordinates"))
			{
				dataTable_0.Columns.Add("Coordinates", typeof(string));
				int_18 = 18;
			}
		}
		DataGridViewComboBoxColumn val = (DataGridViewComboBoxColumn)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Columns[((DataGridViewBand)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Columns[int_2]).Index];
		Waypoint.ComboBoxDataSource_WaypointType_WeaponRoute(ref dataTable_1);
		val.DataSource = dataTable_1;
		val.DisplayMember = "Description";
		val.ValueMember = "ID";
		WaypointList_Refresh = false;
		Waypoint[] selectedRoute = SelectedRoute;
		for (int i = 0; i < selectedRoute.Length; i = checked(i + 1))
		{
			DataRow row = dataTable_0.NewRow();
			dataTable_0.Rows.Add(row);
		}
		WaypointList_Refresh = true;
		RefreshGrid();
		WaypointList_Refresh = false;
		((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).DataSource = new DataView(dataTable_0);
		WaypointList_Refresh = true;
		int count = ((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows.Count;
		int num = SelectedRoute.Count();
		for (int j = count - 1; j >= 0; j += -1)
		{
			if (j <= num - 1)
			{
				Information.IsNothing((object)SelectedRoute[j]);
			}
		}
		WaypointList_Refresh = false;
		if (((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).RowCount <= 0)
		{
			SelectedWaypoint = null;
		}
		else if (SelectedRow <= ((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).RowCount - 1)
		{
			((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[0].Selected = false;
			((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[SelectedRow].Selected = true;
			SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[SelectedRow]).Tag;
		}
		else
		{
			((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[0].Selected = false;
			((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).RowCount - 1].Selected = true;
			SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[0]).Tag;
		}
		WaypointList_Refresh = true;
		WaypointList_Refresh = false;
		theFlightPlanWaypointsWeapon.DisplayLocks();
		WaypointList_Refresh = true;
		theFlightPlanWaypointsWeapon.EnableAndDisableCells();
		theFlightPlanWaypointsWeapon.EnableAndDisableButtons();
	}

	internal void RefreshGrid()
	{
		try
		{
			if (Information.IsNothing((object)SelectedWeapon))
			{
				((Form)this).Text = "Weapon Route Editor for aircraft and weapon <NO MISSION OR FLIGHT SELECTED>";
				return;
			}
			if (Information.IsNothing((object)SelectedRoute))
			{
				((Form)this).Text = "Flightplan Editor for flight <NO FLIGHT SELECTED>";
				return;
			}
			((Form)this).Text = "Flightplan Editor for flight ";
			int num = 1;
			DateTime time = Client.CurrentScenario.Time;
			bool use_DST = Client.CurrentScenario.Use_DST;
			string dST_Start = Client.CurrentScenario.DST_Start;
			string dST_End = Client.CurrentScenario.DST_End;
			bool flag = false;
			bool flag2 = false;
			((Control)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).SuspendLayout();
			try
			{
				int num2 = SelectedRoute.Count() - 1;
				DateTime? dateTime = default(DateTime?);
				string text9 = default(string);
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = default(Doctrine._UseUnderwayRefuelAndReplenishment?);
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = default(Doctrine._UseUnderwayRefuelAndReplenishment?);
				string text13 = default(string);
				for (int num3 = 0; num3 <= num2; num3++)
				{
					Waypoint waypoint = SelectedRoute[num3];
					DataRow dataRow = dataTable_0.Rows[num3];
					int num4 = Waypoint.WaypointType_To_WaypointTypeSelection_WeaponRoute(waypoint.Type);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_2]), num4))
					{
						dataRow[int_2] = num4;
					}
					string text = (string.IsNullOrEmpty(waypoint.Description) ? Conversions.ToString(num) : waypoint.Description);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_0]), text))
					{
						dataRow[int_0] = text;
					}
					num++;
					dataRow[int_1] = waypoint.ObjectID;
					string text2;
					if (!Information.IsNothing((object)waypoint.Time_Zulu) && !flag)
					{
						dateTime = ((!Information.IsNothing((object)waypoint.Time_Zulu_Weapon)) ? waypoint.Time_Zulu_Weapon : waypoint.Time_Zulu);
						text2 = ((dateTime.Value.Hour >= 10) ? (dateTime.Value.Hour + ":") : ("0" + dateTime.Value.Hour + ":"));
						text2 = ((dateTime.Value.Minute >= 10) ? (text2 + dateTime.Value.Minute + ":") : (text2 + "0" + dateTime.Value.Minute + ":"));
						text2 = ((dateTime.Value.Second >= 10) ? (text2 + dateTime.Value.Second) : (text2 + "0" + dateTime.Value.Second));
						if (waypoint.Type == Waypoint.WaypointType.TakeOff)
						{
							string text3 = dateTime.Value.Year + "-";
							text3 = ((dateTime.Value.Month >= 10) ? (text3 + dateTime.Value.Month + "-") : (text3 + "0" + dateTime.Value.Month + "-"));
							text3 = ((dateTime.Value.Day >= 10) ? (text3 + dateTime.Value.Day) : (text3 + "0" + dateTime.Value.Day));
							_ = text3 + ", " + text2;
						}
						else if (waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponTarget || waypoint.IsStationStartWaypoint())
						{
							string text4 = dateTime.Value.Year + "-";
							text4 = ((dateTime.Value.Month >= 10) ? (text4 + dateTime.Value.Month + "-") : (text4 + "0" + dateTime.Value.Month + "-"));
							text4 = ((dateTime.Value.Day >= 10) ? (text4 + dateTime.Value.Day) : (text4 + "0" + dateTime.Value.Day));
							_ = text4 + ", " + text2;
						}
					}
					else
					{
						text2 = "-";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_3]), text2))
					{
						dataRow[int_3] = text2;
					}
					string text5;
					if (!Information.IsNothing((object)dateTime) && !Information.IsNothing((object)waypoint.Time_Local) && !flag)
					{
						DateTime? dateTime2 = (Information.IsNothing((object)waypoint.Time_Zulu_Weapon) ? waypoint.Time_Local : waypoint.Time_Local_Weapon);
						text5 = ((dateTime2.Value.Hour >= 10) ? (dateTime2.Value.Hour + ":") : ("0" + dateTime2.Value.Hour + ":"));
						text5 = ((dateTime2.Value.Minute >= 10) ? (text5 + dateTime2.Value.Minute + ":") : (text5 + "0" + dateTime2.Value.Minute + ":"));
						text5 = ((dateTime2.Value.Second >= 10) ? (text5 + dateTime2.Value.Second) : (text5 + "0" + dateTime2.Value.Second));
						waypoint.TimeOfDay = SunModule.GetTimeOfDay(null, dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, UseCurrentScenarioTime: false, waypoint.Latitude, waypoint.Longitude, 0.0);
						if (!Information.IsNothing((object)waypoint.Time_Zulu_Weapon))
						{
							waypoint.Time_Local = Misc.LocalTime(waypoint.Time_Zulu_Weapon.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
						}
						else
						{
							waypoint.Time_Local = Misc.LocalTime(waypoint.Time_Zulu.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
						}
						text5 = text5 + " (" + SunModule.GetTimeOfDay_String(waypoint.TimeOfDay, time, waypoint.Longitude, use_DST, dST_Start, dST_End) + ")";
					}
					else
					{
						text5 = "-";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_4]), text5))
					{
						dataRow[int_4] = text5;
					}
					Waypoint.FixedFree fixedFree = ((Information.IsNothing((object)dateTime) || flag) ? Waypoint.FixedFree.None : waypoint.TimeFixed);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_5]), fixedFree))
					{
						dataRow[int_5] = fixedFree;
					}
					if (!waypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits && (waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured || waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured || waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured))
					{
						string text6 = "";
						if (waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.Active)
						{
							text6 = "Radar active";
						}
						else if (waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.Passive)
						{
							text6 = "Radar passive";
						}
						if (waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.Active)
						{
							if (!string.IsNullOrEmpty(text6))
							{
								text6 += ", ";
							}
							text6 += "Sonar active";
						}
						else if (waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.Passive)
						{
							if (!string.IsNullOrEmpty(text6))
							{
								text6 += ", ";
							}
							text6 += "Sonar passive";
						}
						if (waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Active)
						{
							if (!string.IsNullOrEmpty(text6))
							{
								text6 += ", ";
							}
							text6 += "OECM active";
						}
						else if (waypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Passive)
						{
							if (!string.IsNullOrEmpty(text6))
							{
								text6 += ", ";
							}
							text6 += "OECM passive";
						}
						if (string.IsNullOrEmpty(text6))
						{
							text6 = "Not configured";
						}
					}
					string text7 = Misc.CoordsToEnglish(waypoint.Latitude, waypoint.Longitude);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_18]), text7))
					{
						dataRow[int_18] = text7;
					}
					string text8 = ((waypoint.Leg_FuelRequired < -2.1474836E+09f) ? "Unknown, Aircraft Type and Loadout Type not set" : (((!Information.IsNothing((object)waypoint.Time_Zulu) || (waypoint.Type != Waypoint.WaypointType.HoldEnd && waypoint.Type != Waypoint.WaypointType.StationEnd)) && waypoint.Type != Waypoint.WaypointType.TakeOff) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRequired)) + " kg") : "-"));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_11]), text8))
					{
						dataRow[int_11] = text8;
					}
					if (waypoint.Leg_FuelRemaining > 2.1474836E+09f)
					{
						text9 = "Unknown";
					}
					else
					{
						byte? b = (byte?)useUnderwayRefuelAndReplenishment;
						bool? flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
						bool? flag4 = (!flag3) ?? flag3;
						if (flag4 ?? true)
						{
							b = (byte?)useUnderwayRefuelAndReplenishment;
							bool? flag6;
							bool? flag5 = (flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)));
							bool? flag7;
							flag6 = (flag7 = ((flag5.HasValue && flag6 != true) ? new bool?(false) : ((!Information.IsNothing((object)useUnderwayRefuelAndReplenishment2)) ? flag6 : new bool?(false))));
							bool? obj;
							if (flag6.HasValue && flag7 != true)
							{
								obj = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment2;
								bool? flag8;
								flag6 = (flag8 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)));
								obj = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) & flag7));
							}
							flag3 = obj;
							if (((!flag3) ?? flag3) == true && flag4.HasValue)
							{
								text9 = "Unknown, AAR allowed";
								flag2 = false;
								goto IL_0cef;
							}
						}
						if (flag2)
						{
							text9 = "Unknown, Station Time not set";
						}
					}
					goto IL_0cef;
					IL_0cef:
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_12]), text9))
					{
						dataRow[int_12] = text9;
					}
					useUnderwayRefuelAndReplenishment2 = useUnderwayRefuelAndReplenishment;
					useUnderwayRefuelAndReplenishment = waypoint.GetDoctrine(Client.CurrentScenario).get_UseReplenishment(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
					string text10 = Misc.TimeString((long)Math.Round(waypoint.Leg_Time_Straight + waypoint.Leg_Time_Turn), 0, ReturnNo: false, ReturnZero: true);
					if (waypoint.Leg_Time_Weapon > 0f)
					{
						text10 = text10 + " (Weapon: " + Misc.TimeString((long)Math.Round(waypoint.Leg_Time_Weapon), 0, ReturnNo: false, ReturnZero: true) + ")";
					}
					else if (waypoint.Type == Waypoint.WaypointType.HoldEnd || waypoint.Type == Waypoint.WaypointType.StationEnd || waypoint.Type == Waypoint.WaypointType.TakeOff)
					{
						text10 = "-";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_13]), text10))
					{
						dataRow[int_13] = text10;
					}
					string text11 = ((flag || waypoint.Type == Waypoint.WaypointType.TakeOff) ? "-" : Misc.TimeString((long)Math.Round(waypoint.Leg_TotalTime), 0, ReturnNo: false, ReturnZero: true));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_15]), text11))
					{
						dataRow[int_15] = text11;
					}
					string text12 = ((waypoint.Type == Waypoint.WaypointType.HoldEnd || waypoint.Type == Waypoint.WaypointType.StationEnd || waypoint.Type == Waypoint.WaypointType.TakeOff || (int)Math.Round(waypoint.Leg_Distance_Straight + waypoint.Leg_Distance_Turn) == 0) ? "-" : (Conversions.ToString((int)Math.Round(waypoint.Leg_Distance_Straight + waypoint.Leg_Distance_Turn)) + " nm"));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_16]), text12))
					{
						dataRow[int_16] = text12;
					}
					if (flag || waypoint.Type == Waypoint.WaypointType.TakeOff)
					{
						text13 = "-";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_17]), text13))
					{
						dataRow[int_17] = text13;
					}
					string text14 = ((waypoint.Hold_Time > 0f && waypoint.Station_Time == 0f && waypoint.SpacingManeuver_Time == 0f) ? (Information.IsNothing((object)dateTime) ? "N/A" : (Misc.TimeString((long)Math.Round(waypoint.Hold_Time), 0, ReturnNo: false, ReturnZero: true) + " Hold")) : ((waypoint.Hold_Time == 0f && waypoint.Station_Time == 0f && waypoint.SpacingManeuver_Time > 0f) ? ((!(waypoint.Separation_Time > 0f)) ? (Misc.TimeString((long)Math.Round(waypoint.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing") : (Misc.TimeString((long)Math.Round(waypoint.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " 90/90, " + Misc.TimeString((long)Math.Round(waypoint.Separation_Time), 0, ReturnNo: false, ReturnZero: true) + " Separation")) : ((waypoint.Hold_Time > 0f && waypoint.Station_Time == 0f && waypoint.SpacingManeuver_Time > 0f) ? (Information.IsNothing((object)dateTime) ? ("N/A Hold, " + Misc.TimeString((long)Math.Round(waypoint.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing") : (Misc.TimeString((long)Math.Round(waypoint.Hold_Time), 0, ReturnNo: false, ReturnZero: true) + " Hold, " + Misc.TimeString((long)Math.Round(waypoint.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing")) : ((waypoint.Hold_Time == 0f && waypoint.Station_Time > 0f && waypoint.SpacingManeuver_Time == 0f) ? ((!Information.IsNothing((object)dateTime)) ? (Misc.TimeString((long)Math.Round(waypoint.Station_Time), 0, ReturnNo: false, ReturnZero: true) + " Station") : "N/A") : ((waypoint.Hold_Time != 0f || !(waypoint.Station_Time > 0f) || !(waypoint.SpacingManeuver_Time > 0f)) ? "-" : (Information.IsNothing((object)dateTime) ? ("N/A Station, " + Misc.TimeString((long)Math.Round(waypoint.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing") : (Misc.TimeString((long)Math.Round(waypoint.Station_Time), 0, ReturnNo: false, ReturnZero: true) + " Station, " + Misc.TimeString((long)Math.Round(waypoint.SpacingManeuver_Time), 0, ReturnNo: false, ReturnZero: true) + " Spacing")))))));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_14]), text14))
					{
						dataRow[int_14] = text14;
					}
					if (waypoint.Type == Waypoint.WaypointType.WeaponTarget)
					{
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_10]), "-"))
						{
							dataRow[int_10] = "-";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_7]), "-"))
						{
							dataRow[int_7] = "-";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_8]), Waypoint.FixedFree.None))
						{
							dataRow[int_8] = Waypoint.FixedFree.None;
						}
					}
					else
					{
						string text15;
						if (!Information.IsNothing((object)waypoint.DesiredSpeedOverride) && !Information.IsNothing((object)waypoint.DesiredSpeed))
						{
							float? desiredSpeed;
							float? num5 = (desiredSpeed = waypoint.DesiredSpeed);
							text15 = (num5.HasValue ? Conversions.ToString(desiredSpeed.GetValueOrDefault()) : null) + " kt";
						}
						else if (!Information.IsNothing((object)waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
						{
							ActiveUnit.Throttle throttle_ = (ActiveUnit.Throttle)waypoint.ThrottlePreset;
							text15 = method_2(ref throttle_);
							if (waypoint.DesiredAltitudeOverride && !Information.IsNothing((object)waypoint.DesiredSpeed))
							{
								string text16 = text15;
								float? desiredSpeed;
								float? num5 = (desiredSpeed = waypoint.DesiredSpeed);
								text15 = text16 + " (" + ((!num5.HasValue) ? null : Conversions.ToString(desiredSpeed.GetValueOrDefault())) + " kt)";
							}
						}
						else
						{
							text15 = "Speed Not set!";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_7]), text15))
						{
							dataRow[int_7] = text15;
						}
						Waypoint.FixedFree speedFixed = waypoint.SpeedFixed;
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_8]), speedFixed))
						{
							dataRow[int_8] = speedFixed;
						}
						string text17 = "";
						if (!Information.IsNothing((object)waypoint.DesiredAltitudeOverride) && (!Information.IsNothing((object)waypoint.DesiredAltitude) || (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))))
						{
							if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
								{
									text17 = (((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value)) + " m AGL"));
								}
								else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
								{
									text17 = (((int)Math.Round(waypoint.DesiredAltitude.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude.Value)) + " m ASL"));
								}
							}
							else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
							{
								text17 = (((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude_TerrainFollowing * 3.28084f).Value)) + " ft AGL"));
							}
							else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
							{
								text17 = (((int)Math.Round(waypoint.DesiredAltitude.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude * 3.28084f).Value)) + " ft ASL"));
							}
						}
						else if (!Information.IsNothing((object)waypoint.AltitudePreset) && waypoint.AltitudePreset != ActiveUnit_AI.AircraftAltitudePreset.None)
						{
							switch (waypoint.AltitudePreset)
							{
							case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
								text17 = "Minimum";
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
								if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
									{
										text17 = Conversions.ToString(305) + " m AGL";
									}
									else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
									{
										text17 = Conversions.ToString(305) + " m ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
								{
									text17 = Conversions.ToString(305) + " ft AGL";
								}
								else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
								{
									text17 = Conversions.ToString(305) + " ft ASL";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
								if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
									{
										text17 = Conversions.ToString(610) + " m AGL";
									}
									else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
									{
										text17 = Conversions.ToString(610) + " m ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
								{
									text17 = Conversions.ToString(610) + " ft AGL";
								}
								else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
								{
									text17 = Conversions.ToString(610) + " ft ASL";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.const_4:
								if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
									{
										text17 = Conversions.ToString(3658) + " m AGL";
									}
									else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
									{
										text17 = Conversions.ToString(3658) + " m ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
								{
									text17 = Conversions.ToString(3658) + " ft AGL";
								}
								else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
								{
									text17 = Conversions.ToString(3658) + " ft ASL";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.const_5:
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
									{
										text17 = Conversions.ToString(7620) + " ft AGL";
									}
									else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
									{
										text17 = Conversions.ToString(7620) + " ft ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
								{
									text17 = Conversions.ToString(7620) + " m AGL";
								}
								else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
								{
									text17 = Conversions.ToString(7620) + " m ASL";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.const_6:
								if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
									{
										text17 = Conversions.ToString(10973) + " m AGL";
									}
									else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
									{
										text17 = Conversions.ToString(10973) + " m ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
								{
									text17 = Conversions.ToString(10973) + " ft AGL";
								}
								else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
								{
									text17 = Conversions.ToString(10973) + " ft ASL";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
								text17 = "Maximum";
								break;
							}
						}
						else
						{
							text17 = "Altitude not set!";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[int_10]), text17))
						{
							dataRow[int_10] = text17;
						}
					}
				}
			}
			finally
			{
				((Control)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).ResumeLayout();
			}
			if (((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows.Count > 0)
			{
				WaypointList_Refresh = false;
				if (((BaseCollection)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).SelectedRows[0]).Index > 0 && SelectedRow != ((DataGridViewBand)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).SelectedRows[0]).Index)
				{
					if (SelectedRow <= ((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows.Count - 1)
					{
						((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[SelectedRow].Selected = false;
					}
					SelectedRow = ((DataGridViewBand)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).SelectedRows[0]).Index;
				}
				((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[0].Selected = false;
				if (((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).RowCount > 0)
				{
					if (SelectedRow <= ((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).RowCount - 1)
					{
						((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[SelectedRow].Selected = false;
						((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[SelectedRow].Selected = true;
					}
					else
					{
						((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).RowCount - 1].Selected = false;
						((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).Rows[((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).RowCount - 1].Selected = true;
					}
				}
				SelectedWaypoint = (Waypoint)((DataGridViewBand)((DataGridView)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon).SelectedRows[0]).Tag;
				WaypointList_Refresh = true;
			}
			else
			{
				SelectedWaypoint = null;
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

	private void FlightPlanEditorWeaponRoute_KeyDown(object sender, KeyEventArgs e)
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
			((Control)this).Hide();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void FlightPlanEditorWeaponRoute_Shown(object sender, EventArgs e)
	{
	}

	public void RecalculateFlightPlanFuelAndTimes(bool RefreshMainform, bool RefreshFlightPlanEditorWeaponRouteWindow, bool RefreshFlightPlanEditorWeaponRouteWindow_Limited, bool RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid, bool RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks)
	{
		try
		{
			if (((Control)this).Visible && RefreshFlightPlanEditorWeaponRouteWindow)
			{
				if (!RefreshFlightPlanEditorWeaponRouteWindow_Limited)
				{
					if (RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid)
					{
						LoadGrid();
					}
					else
					{
						RefreshGrid();
						if (RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks)
						{
							theFlightPlanWaypointsWeapon.DisplayLocks();
						}
					}
				}
				else
				{
					Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = false;
					if (RefreshFlightPlanEditorWeaponRouteWindow_ReloadhGrid)
					{
						LoadGrid();
					}
					else
					{
						RefreshGrid();
						if (RefreshFlightPlanEditorWeaponRouteWindow_DrawLocks)
						{
							theFlightPlanWaypointsWeapon.DisplayLocks();
						}
					}
					Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = true;
				}
			}
			if (RefreshMainform)
			{
				AMP_General.RefreshFlightPlanErrorWindow();
				Client.MustRefreshMainForm = true;
				MyProject.Forms.MainForm.MapRender_Tactical();
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

	static FlightPlanEditorWeaponRoute()
	{
		Class72.smethod_20();
	}
}

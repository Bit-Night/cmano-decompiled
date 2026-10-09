using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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
public sealed class SelectLoadout : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("DGV_Loadouts")]
	[CompilerGenerated]
	private DarkDataGridView _DGV_Loadouts;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	public string AircraftName;

	public int AircraftID;

	public Side AircraftSide;

	private int int_0;

	private Geopoint_Struct geopoint_Struct_0;

	private DataTable dataTable_0;

	private DataTable dataTable_1;

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
			KeyEventHandler val = new KeyEventHandler(method_6);
			EventHandler eventHandler = method_7;
			DarkDataGridView darkDataGridView = _DGV_Loadouts;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).KeyDown -= val;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_DGV_Loadouts = value;
			darkDataGridView = _DGV_Loadouts;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).KeyDown += val;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DGV_LoadoutItems")]
	internal virtual DarkDataGridView DGV_LoadoutItems { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

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
			EventHandler eventHandler = method_2;
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
			EventHandler eventHandler = method_4;
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

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("ComponentID")]
	internal virtual DataGridViewTextBoxColumn ComponentID { get; set; }

	[field: AccessedThroughProperty("Quantity")]
	internal virtual DataGridViewTextBoxColumn Quantity { get; set; }

	[field: AccessedThroughProperty("Item")]
	internal virtual DataGridViewTextBoxColumn Item { get; set; }

	[field: AccessedThroughProperty("Internal")]
	internal virtual DataGridViewTextBoxColumn Internal { get; set; }

	[field: AccessedThroughProperty("OptionalWeapon")]
	internal virtual DataGridViewTextBoxColumn OptionalWeapon { get; set; }

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("Loadout")]
	internal virtual DataGridViewTextBoxColumn Loadout { get; set; }

	[field: AccessedThroughProperty("AttackAltitude")]
	internal virtual DataGridViewTextBoxColumn AttackAltitude { get; set; }

	public SelectLoadout()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += SelectLoadout_Load;
		((Control)this).KeyDown += new KeyEventHandler(SelectLoadout_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(SelectLoadout_FormClosing);
		dataTable_0 = new DataTable();
		dataTable_1 = new DataTable();
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
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Expected O, but got Unknown
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e5: Expected O, but got Unknown
		//IL_0998: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Expected O, but got Unknown
		//IL_0a53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DGV_Loadouts = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Loadout = new DataGridViewTextBoxColumn();
		AttackAltitude = new DataGridViewTextBoxColumn();
		DGV_LoadoutItems = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		ComponentID = new DataGridViewTextBoxColumn();
		Quantity = new DataGridViewTextBoxColumn();
		Item = new DataGridViewTextBoxColumn();
		Internal = new DataGridViewTextBoxColumn();
		OptionalWeapon = new DataGridViewTextBoxColumn();
		Label1 = new DarkLabel();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		((ISupportInitialize)(object)DGV_Loadouts).BeginInit();
		((ISupportInitialize)(object)DGV_LoadoutItems).BeginInit();
		((Control)this).SuspendLayout();
		((DataGridView)DGV_Loadouts).AllowUserToAddRows = false;
		((DataGridView)DGV_Loadouts).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Loadouts).AllowUserToResizeRows = false;
		((DataGridView)DGV_Loadouts).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Loadouts).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_Loadouts).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Loadouts).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Loadouts).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_Loadouts).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_Loadouts).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)Loadout,
			(DataGridViewColumn)AttackAltitude
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Loadouts).DefaultCellStyle = val2;
		((Control)DGV_Loadouts).Dock = (DockStyle)1;
		((DataGridView)DGV_Loadouts).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_Loadouts).EnableHeadersVisualStyles = false;
		((Control)DGV_Loadouts).Location = new Point(0, 0);
		((DataGridView)DGV_Loadouts).MultiSelect = false;
		((Control)DGV_Loadouts).Name = "DGV_Loadouts";
		((DataGridView)DGV_Loadouts).RowHeadersVisible = false;
		((DataGridView)DGV_Loadouts).RowHeadersWidth = 10;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Loadouts).RowsDefaultCellStyle = val3;
		((DataGridView)DGV_Loadouts).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_Loadouts).Size = new Size(442, 279);
		((Control)DGV_Loadouts).TabIndex = 7;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)Loadout).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Loadout).DataPropertyName = "Name";
		((DataGridViewColumn)Loadout).HeaderText = "Loadout";
		((DataGridViewColumn)Loadout).Name = "Loadout";
		((DataGridViewColumn)Loadout).ReadOnly = true;
		((DataGridViewColumn)AttackAltitude).DataPropertyName = "AttackAltitude";
		((DataGridViewColumn)AttackAltitude).HeaderText = "Attack Altitude";
		((DataGridViewColumn)AttackAltitude).Name = "AttackAltitude";
		((DataGridViewColumn)AttackAltitude).ReadOnly = true;
		((DataGridView)DGV_LoadoutItems).AllowUserToAddRows = false;
		((DataGridView)DGV_LoadoutItems).AllowUserToDeleteRows = false;
		((Control)DGV_LoadoutItems).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_LoadoutItems).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)6;
		((DataGridView)DGV_LoadoutItems).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		((DataGridView)DGV_LoadoutItems).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_LoadoutItems).BorderStyle = (BorderStyle)2;
		((Control)DGV_LoadoutItems).CausesValidation = false;
		((DataGridView)DGV_LoadoutItems).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_LoadoutItems).ColumnHeadersVisible = false;
		((DataGridView)DGV_LoadoutItems).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[6]
		{
			(DataGridViewColumn)DataGridViewTextBoxColumn1,
			(DataGridViewColumn)ComponentID,
			(DataGridViewColumn)Quantity,
			(DataGridViewColumn)Item,
			(DataGridViewColumn)Internal,
			(DataGridViewColumn)OptionalWeapon
		});
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_LoadoutItems).DefaultCellStyle = val5;
		((DataGridView)DGV_LoadoutItems).EditMode = (DataGridViewEditMode)4;
		((Control)DGV_LoadoutItems).Enabled = false;
		((DataGridView)DGV_LoadoutItems).EnableHeadersVisualStyles = false;
		((Control)DGV_LoadoutItems).Location = new Point(3, 302);
		((DataGridView)DGV_LoadoutItems).MultiSelect = false;
		((Control)DGV_LoadoutItems).Name = "DGV_LoadoutItems";
		((DataGridView)DGV_LoadoutItems).RowHeadersVisible = false;
		((DataGridView)DGV_LoadoutItems).RowHeadersWidth = 4;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_LoadoutItems).RowsDefaultCellStyle = val6;
		((DataGridView)DGV_LoadoutItems).RowTemplate.Height = 15;
		((DataGridView)DGV_LoadoutItems).RowTemplate.Resizable = (DataGridViewTriState)2;
		((DataGridView)DGV_LoadoutItems).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_LoadoutItems).Size = new Size(439, 115);
		((Control)DGV_LoadoutItems).TabIndex = 9;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).DataPropertyName = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Visible = false;
		((DataGridViewColumn)ComponentID).DataPropertyName = "ComponentID";
		((DataGridViewColumn)ComponentID).HeaderText = "ComponentID";
		((DataGridViewColumn)ComponentID).Name = "ComponentID";
		((DataGridViewColumn)ComponentID).Visible = false;
		((DataGridViewColumn)ComponentID).Width = 5;
		((DataGridViewColumn)Quantity).DataPropertyName = "Quantity";
		((DataGridViewColumn)Quantity).HeaderText = "Quantity";
		((DataGridViewColumn)Quantity).Name = "Quantity";
		((DataGridViewColumn)Quantity).Visible = false;
		((DataGridViewColumn)Quantity).Width = 5;
		((DataGridViewColumn)Item).DataPropertyName = "Fill";
		((DataGridViewColumn)Item).HeaderText = "Item";
		((DataGridViewColumn)Item).Name = "Item";
		((DataGridViewColumn)Item).Width = 5;
		((DataGridViewColumn)Internal).DataPropertyName = "Internal";
		((DataGridViewColumn)Internal).HeaderText = "Internal";
		((DataGridViewColumn)Internal).Name = "Internal";
		((DataGridViewColumn)Internal).Visible = false;
		((DataGridViewColumn)Internal).Width = 5;
		((DataGridViewColumn)OptionalWeapon).DataPropertyName = "Optional";
		((DataGridViewColumn)OptionalWeapon).HeaderText = "OptionalWeapon";
		((DataGridViewColumn)OptionalWeapon).Name = "OptionalWeapon";
		((DataGridViewColumn)OptionalWeapon).Visible = false;
		((DataGridViewColumn)OptionalWeapon).Width = 5;
		((Control)Label1).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(0, 286);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(90, 13);
		((Control)Label1).TabIndex = 10;
		((Label)Label1).Text = "Loadout items:";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(3, 438);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 11;
		Button1.Text = "OK";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)2;
		((Control)Button2).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(367, 438);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 12;
		Button2.Text = "Cancel";
		((Form)this).AcceptButton = (IButtonControl)(object)Button1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).CancelButton = (IButtonControl)(object)Button2;
		((Form)this).ClientSize = new Size(442, 464);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)DGV_LoadoutItems);
		((Control)this).Controls.Add((Control)(object)DGV_Loadouts);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "SelectLoadout";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "SelectLoadout";
		((ISupportInitialize)(object)DGV_Loadouts).EndInit();
		((ISupportInitialize)(object)DGV_LoadoutItems).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void SelectLoadout_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		geopoint_Struct_0 = MyProject.Forms.MainForm.MapClickWorldPoint;
		((DataGridView)DGV_Loadouts).AutoGenerateColumns = false;
		int aircraftID = AircraftID;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Scenario currentScenario = Client.CurrentScenario;
		bool UnlimitedAirWeapons = false;
		Scenario CurrentScenario = null;
		Aircraft SelectedAircraft = null;
		int num = 0;
		bool ExcludeOptionalWeapons = false;
		dataTable_0 = DBFunctions.LoadoutsForThisAircraft_DT(aircraftID, null, ref sqliteConnection_, currentScenario, ref UnlimitedAirWeapons, ref CurrentScenario, ref SelectedAircraft, ref num, ref ExcludeOptionalWeapons);
		((DataGridView)DGV_Loadouts).DataSource = dataTable_0;
		((DataGridView)DGV_LoadoutItems).DataSource = method_5(int_0);
		int_0 = Conversions.ToInteger(((DataGridView)DGV_Loadouts).Rows[0].Cells["ID"].Value);
		if (Client.AddingDecoyPlatform & AddUnit.Unarmed)
		{
			method_3();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Aircraft theAircraft = Client.CurrentScenario.AddNewAircraft(AircraftSide, AircraftName, geopoint_Struct_0.Longitude, geopoint_Struct_0.Latitude, AircraftID, int_0, 100f, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, MyProject.Forms.AddUnit.string_0);
			Aircraft aircraft = theAircraft;
			Aircraft aircraft2;
			ActiveUnit theAU;
			bool Return_theAltitude_TerrainFollowing = (aircraft2 = theAircraft).get_DesiredAltitude_UseTerrainFollowing(theAU = theAircraft);
			float desiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref Return_theAltitude_TerrainFollowing);
			aircraft2.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
			aircraft.DesiredAltitude = desiredAltitude;
			theAircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theAircraft.DesiredAltitude);
			short elevation = Terrain.GetElevation(theAircraft.get_Latitude((GlobalVariables.BooleanObject)null), theAircraft.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, Client.CurrentScenario);
			if (theAircraft.DesiredAltitude < (float)(elevation + 1))
			{
				theAircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)(elevation + 1));
			}
			else
			{
				theAircraft.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theAircraft.DesiredAltitude);
			}
			if (!Information.IsNothing((object)theAircraft.Loadout))
			{
				WeaponRec[] weapons = theAircraft.Loadout.Weapons;
				for (int i = 0; i < weapons.Length; i = checked(i + 1))
				{
					weapons[i].get_ReferenceWeapon(theAircraft.ParentScen).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				}
			}
			if (Client.AddingDecoyPlatform & AddUnit.Unarmed)
			{
				theAircraft.IsDecoy = true;
				theAircraft.Weaponry.Disarm();
			}
			AddUnit.theAddedUnit = theAircraft;
			Client.MustRefreshMainForm = true;
			if (((Control)MyProject.Forms.AddUnit).Visible)
			{
				((Form)MyProject.Forms.AddUnit).Close();
			}
			((Form)this).Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("Error: " + ex2.Message, "Error");
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private DataTable method_5(int int_1)
	{
		int loadoutID = int_0;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		bool ExcludeOptionalWeapons = false;
		return DBFunctions.ItemsForThisLoadout(loadoutID, ref sqliteConnection_, ref ExcludeOptionalWeapons);
	}

	private void method_6(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			method_3();
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Loadouts).SelectedRows).Count != 0)
		{
			int_0 = Conversions.ToInteger(((DataGridView)DGV_Loadouts).SelectedRows[0].Cells["ID"].Value);
			((DataGridView)DGV_LoadoutItems).DataSource = method_5(int_0);
		}
	}

	private void SelectLoadout_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
	}

	private void SelectLoadout_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static SelectLoadout()
	{
		Class72.smethod_20();
	}
}

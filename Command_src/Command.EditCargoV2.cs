using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
public sealed class EditCargoV2 : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("UnloadButton")]
	private DarkUIButton _UnloadButton;

	[CompilerGenerated]
	[AccessedThroughProperty("CargoSourceTabControl")]
	private DarkUITabControl _CargoSourceTabControl;

	[AccessedThroughProperty("DBGrid")]
	[CompilerGenerated]
	private DarkDataGridView _DBGrid;

	[AccessedThroughProperty("LoadButton")]
	[CompilerGenerated]
	private DarkUIButton _LoadButton;

	[CompilerGenerated]
	[AccessedThroughProperty("InventoryGridView")]
	private DarkDataGridView _InventoryGridView;

	[CompilerGenerated]
	[AccessedThroughProperty("ExistingUnitsGridView")]
	private DarkDataGridView _ExistingUnitsGridView;

	[CompilerGenerated]
	[AccessedThroughProperty("DeleteButton")]
	private DarkUIButton _DeleteButton;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Filter")]
	private DarkCheckBox _CB_Filter;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Filter")]
	private DarkUITextBox _TB_Filter;

	[CompilerGenerated]
	[AccessedThroughProperty("EditContainerButton")]
	private DarkUIButton _EditContainerButton;

	public ActiveUnit SelectedHost;

	private ICargoHost icargoHost_0;

	private CargoType cargoType_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private string lMiBqemfTx;

	private bool bool_2;

	private DataTable[] dataTable_0;

	private Keys[] keys_0;

	private List<Loadout> list_0;

	internal virtual DarkUIButton UnloadButton
	{
		[CompilerGenerated]
		get
		{
			return _UnloadButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIButton darkUIButton = _UnloadButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_UnloadButton = value;
			darkUIButton = _UnloadButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("UnloadCounter")]
	internal virtual DarkNumericUpDown UnloadCounter { get; set; }

	internal virtual DarkUITabControl CargoSourceTabControl
	{
		[CompilerGenerated]
		get
		{
			return _CargoSourceTabControl;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUITabControl darkUITabControl = _CargoSourceTabControl;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_CargoSourceTabControl = value;
			darkUITabControl = _CargoSourceTabControl;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("UnitsTab")]
	internal virtual TabPage UnitsTab { get; set; }

	internal virtual DarkDataGridView DBGrid
	{
		[CompilerGenerated]
		get
		{
			return _DBGrid;
		}
		[CompilerGenerated]
		set
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			EventHandler eventHandler = method_9;
			EventHandler eventHandler2 = method_10;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_13);
			DarkDataGridView darkDataGridView = _DBGrid;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).Sorted -= eventHandler2;
				((DataGridView)darkDataGridView).CellContentClick -= val;
			}
			_DBGrid = value;
			darkDataGridView = _DBGrid;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).Sorted += eventHandler2;
				((DataGridView)darkDataGridView).CellContentClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("LoadCounter")]
	internal virtual DarkNumericUpDown LoadCounter { get; set; }

	internal virtual DarkUIButton LoadButton
	{
		[CompilerGenerated]
		get
		{
			return _LoadButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _LoadButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_LoadButton = value;
			darkUIButton = _LoadButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("Panel_LoadedCargo")]
	internal virtual DarkSectionPanel Panel_LoadedCargo { get; set; }

	[field: AccessedThroughProperty("Panel_AvailableCargo")]
	internal virtual DarkSectionPanel Panel_AvailableCargo { get; set; }

	internal virtual DarkDataGridView InventoryGridView
	{
		[CompilerGenerated]
		get
		{
			return _InventoryGridView;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			EventHandler eventHandler2 = method_21;
			DarkDataGridView darkDataGridView = _InventoryGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((Control)darkDataGridView).MouseHover -= eventHandler2;
			}
			_InventoryGridView = value;
			darkDataGridView = _InventoryGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((Control)darkDataGridView).MouseHover += eventHandler2;
			}
		}
	}

	internal virtual DarkDataGridView ExistingUnitsGridView
	{
		[CompilerGenerated]
		get
		{
			return _ExistingUnitsGridView;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkDataGridView darkDataGridView = _ExistingUnitsGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_ExistingUnitsGridView = value;
			darkDataGridView = _ExistingUnitsGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("SizeLabel")]
	internal virtual DarkLabel SizeLabel { get; set; }

	[field: AccessedThroughProperty("ExistingUnitTypeCol")]
	internal virtual DataGridViewTextBoxColumn ExistingUnitTypeCol { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("ExistingUnitSizeCol")]
	internal virtual DataGridViewTextBoxColumn ExistingUnitSizeCol { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn3 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn4 { get; set; }

	[field: AccessedThroughProperty("NoUnitsWarningLabel")]
	internal virtual DarkLabel NoUnitsWarningLabel { get; set; }

	[field: AccessedThroughProperty("CustomNameTextBox")]
	internal virtual DarkUITextBox CustomNameTextBox { get; set; }

	[field: AccessedThroughProperty("CustomNameLabel")]
	internal virtual DarkLabel CustomNameLabel { get; set; }

	[field: AccessedThroughProperty("MassBar")]
	internal virtual DarkUIProgressBar MassBar { get; set; }

	[field: AccessedThroughProperty("CrewBar")]
	internal virtual DarkUIProgressBar CrewBar { get; set; }

	[field: AccessedThroughProperty("AreaBar")]
	internal virtual DarkUIProgressBar AreaBar { get; set; }

	internal virtual DarkUIButton DeleteButton
	{
		[CompilerGenerated]
		get
		{
			return _DeleteButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUIButton darkUIButton = _DeleteButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DeleteButton = value;
			darkUIButton = _DeleteButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_Filter
	{
		[CompilerGenerated]
		get
		{
			return _CB_Filter;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkCheckBox darkCheckBox = _CB_Filter;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_Filter = value;
			darkCheckBox = _CB_Filter;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox TB_Filter
	{
		[CompilerGenerated]
		get
		{
			return _TB_Filter;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_19;
			DarkUITextBox darkUITextBox = _TB_Filter;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TB_Filter = value;
			darkUITextBox = _TB_Filter;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton EditContainerButton
	{
		[CompilerGenerated]
		get
		{
			return _EditContainerButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _EditContainerButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_EditContainerButton = value;
			darkUIButton = _EditContainerButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("InvColName")]
	internal virtual DataGridViewTextBoxColumn InvColName { get; set; }

	[field: AccessedThroughProperty("InvColMass")]
	internal virtual DataGridViewTextBoxColumn InvColMass { get; set; }

	[field: AccessedThroughProperty("InvColArea")]
	internal virtual DataGridViewTextBoxColumn InvColArea { get; set; }

	[field: AccessedThroughProperty("InvColCrew")]
	internal virtual DataGridViewTextBoxColumn InvColCrew { get; set; }

	[field: AccessedThroughProperty("GroundTab")]
	internal virtual TabPage GroundTab { get; set; }

	[field: AccessedThroughProperty("ContainerTab")]
	internal virtual TabPage ContainerTab { get; set; }

	[field: AccessedThroughProperty("FacilityTab")]
	internal virtual TabPage FacilityTab { get; set; }

	[field: AccessedThroughProperty("MountTab")]
	internal virtual TabPage MountTab { get; set; }

	[field: AccessedThroughProperty("AircraftTab")]
	internal virtual TabPage AircraftTab { get; set; }

	public EditCargoV2()
	{
		((Form)this).Load += EditCargoV2_Load;
		((Form)this).Shown += EditCargoV2_Shown;
		lMiBqemfTx = "";
		bool_2 = false;
		dataTable_0 = new DataTable[0];
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
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
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected O, but got Unknown
		//IL_07c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Expected O, but got Unknown
		//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc2: Expected O, but got Unknown
		//IL_0e41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4b: Expected O, but got Unknown
		//IL_0f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9d: Expected O, but got Unknown
		//IL_0fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1136: Unknown result type (might be due to invalid IL or missing references)
		//IL_1140: Expected O, but got Unknown
		//IL_1152: Unknown result type (might be due to invalid IL or missing references)
		//IL_115c: Expected O, but got Unknown
		//IL_11a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e7: Expected O, but got Unknown
		//IL_12f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fe: Expected O, but got Unknown
		//IL_1317: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1468: Unknown result type (might be due to invalid IL or missing references)
		//IL_1820: Unknown result type (might be due to invalid IL or missing references)
		//IL_182a: Expected O, but got Unknown
		//IL_18e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f2: Expected O, but got Unknown
		//IL_1bdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be5: Expected O, but got Unknown
		//IL_1c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d25: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		UnloadButton = new DarkUIButton();
		UnloadCounter = new DarkNumericUpDown();
		CargoSourceTabControl = new DarkUITabControl();
		UnitsTab = new TabPage();
		NoUnitsWarningLabel = new DarkLabel();
		ExistingUnitsGridView = new DarkDataGridView();
		ExistingUnitTypeCol = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		ExistingUnitSizeCol = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		GroundTab = new TabPage();
		ContainerTab = new TabPage();
		FacilityTab = new TabPage();
		MountTab = new TabPage();
		AircraftTab = new TabPage();
		DBGrid = new DarkDataGridView();
		LoadCounter = new DarkNumericUpDown();
		LoadButton = new DarkUIButton();
		TableLayoutPanel1 = new TableLayoutPanel();
		Panel_LoadedCargo = new DarkSectionPanel();
		DeleteButton = new DarkUIButton();
		EditContainerButton = new DarkUIButton();
		CrewBar = new DarkUIProgressBar();
		AreaBar = new DarkUIProgressBar();
		MassBar = new DarkUIProgressBar();
		SizeLabel = new DarkLabel();
		InventoryGridView = new DarkDataGridView();
		InvColName = new DataGridViewTextBoxColumn();
		InvColMass = new DataGridViewTextBoxColumn();
		InvColArea = new DataGridViewTextBoxColumn();
		InvColCrew = new DataGridViewTextBoxColumn();
		Panel_AvailableCargo = new DarkSectionPanel();
		CB_Filter = new DarkCheckBox();
		TB_Filter = new DarkUITextBox();
		CustomNameLabel = new DarkLabel();
		CustomNameTextBox = new DarkUITextBox();
		((ISupportInitialize)UnloadCounter).BeginInit();
		((Control)CargoSourceTabControl).SuspendLayout();
		((Control)UnitsTab).SuspendLayout();
		((ISupportInitialize)(object)ExistingUnitsGridView).BeginInit();
		((Control)AircraftTab).SuspendLayout();
		((ISupportInitialize)(object)DBGrid).BeginInit();
		((ISupportInitialize)LoadCounter).BeginInit();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)Panel_LoadedCargo).SuspendLayout();
		((ISupportInitialize)(object)InventoryGridView).BeginInit();
		((Control)Panel_AvailableCargo).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)UnloadButton).Anchor = (AnchorStyles)6;
		((ButtonBase)UnloadButton).BackColor = Color.Transparent;
		((Control)UnloadButton).ForeColor = SystemColors.Control;
		((Control)UnloadButton).Location = new Point(71, 548);
		((Control)UnloadButton).Name = "UnloadButton";
		((Control)UnloadButton).Padding = new Padding(5);
		UnloadButton.RoundRadius = 0;
		((Control)UnloadButton).Size = new Size(108, 23);
		((Control)UnloadButton).TabIndex = 2;
		UnloadButton.Text = "Unload Selected";
		((Control)UnloadCounter).Anchor = (AnchorStyles)6;
		((UpDownBase)UnloadCounter).BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)UnloadCounter).BorderStyle = (BorderStyle)0;
		((Control)UnloadCounter).Font = new Font("Segoe UI", 12f);
		((UpDownBase)UnloadCounter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)UnloadCounter).Location = new Point(9, 546);
		((NumericUpDown)UnloadCounter).Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		((NumericUpDown)UnloadCounter).Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)UnloadCounter).Name = "UnloadCounter";
		((Control)UnloadCounter).Size = new Size(54, 25);
		((Control)UnloadCounter).TabIndex = 3;
		((NumericUpDown)UnloadCounter).Value = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)CargoSourceTabControl).Anchor = (AnchorStyles)15;
		((Control)CargoSourceTabControl).Controls.Add((Control)(object)UnitsTab);
		((Control)CargoSourceTabControl).Controls.Add((Control)(object)GroundTab);
		((Control)CargoSourceTabControl).Controls.Add((Control)(object)ContainerTab);
		((Control)CargoSourceTabControl).Controls.Add((Control)(object)FacilityTab);
		((Control)CargoSourceTabControl).Controls.Add((Control)(object)MountTab);
		((Control)CargoSourceTabControl).Controls.Add((Control)(object)AircraftTab);
		((Control)CargoSourceTabControl).Cursor = Cursors.Hand;
		((TabControl)CargoSourceTabControl).ItemSize = new Size(80, 20);
		((Control)CargoSourceTabControl).Location = new Point(4, 28);
		((Control)CargoSourceTabControl).Name = "CargoSourceTabControl";
		((TabControl)CargoSourceTabControl).SelectedIndex = 0;
		((Control)CargoSourceTabControl).Size = new Size(724, 511);
		((Control)CargoSourceTabControl).TabIndex = 4;
		UnitsTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)UnitsTab).Controls.Add((Control)(object)NoUnitsWarningLabel);
		((Control)UnitsTab).Controls.Add((Control)(object)ExistingUnitsGridView);
		UnitsTab.Location = new Point(4, 24);
		((Control)UnitsTab).Name = "UnitsTab";
		((Control)UnitsTab).Padding = new Padding(3);
		((Control)UnitsTab).Size = new Size(716, 483);
		UnitsTab.TabIndex = 0;
		UnitsTab.Text = "Existing Units";
		((Control)NoUnitsWarningLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NoUnitsWarningLabel).Location = new Point(3, 22);
		((Control)NoUnitsWarningLabel).Name = "NoUnitsWarningLabel";
		((Control)NoUnitsWarningLabel).Size = new Size(700, 460);
		((Control)NoUnitsWarningLabel).TabIndex = 14;
		((Label)NoUnitsWarningLabel).Text = "(You must create units capable of being loaded as cargo for this host.)";
		((Label)NoUnitsWarningLabel).TextAlign = (ContentAlignment)32;
		((Control)NoUnitsWarningLabel).Visible = false;
		((DataGridView)ExistingUnitsGridView).AllowUserToAddRows = false;
		((DataGridView)ExistingUnitsGridView).AllowUserToDeleteRows = false;
		((DataGridView)ExistingUnitsGridView).AllowUserToOrderColumns = true;
		((DataGridView)ExistingUnitsGridView).AllowUserToResizeRows = false;
		((Control)ExistingUnitsGridView).Anchor = (AnchorStyles)15;
		((DataGridView)ExistingUnitsGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)ExistingUnitsGridView).BorderStyle = (BorderStyle)0;
		((DataGridView)ExistingUnitsGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)ExistingUnitsGridView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)ExistingUnitsGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)1;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)ExistingUnitsGridView).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)ExistingUnitsGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)ExistingUnitsGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[6]
		{
			(DataGridViewColumn)ExistingUnitTypeCol,
			(DataGridViewColumn)DataGridViewTextBoxColumn1,
			(DataGridViewColumn)ExistingUnitSizeCol,
			(DataGridViewColumn)DataGridViewTextBoxColumn2,
			(DataGridViewColumn)DataGridViewTextBoxColumn3,
			(DataGridViewColumn)DataGridViewTextBoxColumn4
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)ExistingUnitsGridView).DefaultCellStyle = val2;
		((DataGridView)ExistingUnitsGridView).EnableHeadersVisualStyles = false;
		((Control)ExistingUnitsGridView).Location = new Point(0, 0);
		((Control)ExistingUnitsGridView).Name = "ExistingUnitsGridView";
		((DataGridView)ExistingUnitsGridView).ReadOnly = true;
		((DataGridView)ExistingUnitsGridView).RowHeadersVisible = false;
		((DataGridView)ExistingUnitsGridView).RowHeadersWidth = 51;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)ExistingUnitsGridView).RowsDefaultCellStyle = val3;
		((DataGridView)ExistingUnitsGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)ExistingUnitsGridView).Size = new Size(713, 480);
		((Control)ExistingUnitsGridView).TabIndex = 13;
		((DataGridViewColumn)ExistingUnitTypeCol).HeaderText = "Type";
		((DataGridViewColumn)ExistingUnitTypeCol).MinimumWidth = 6;
		((DataGridViewColumn)ExistingUnitTypeCol).Name = "ExistingUnitTypeCol";
		((DataGridViewColumn)ExistingUnitTypeCol).ReadOnly = true;
		((DataGridViewColumn)ExistingUnitTypeCol).Width = 90;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "Name";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).ReadOnly = true;
		DataGridViewTextBoxColumn1.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Width = 390;
		((DataGridViewColumn)ExistingUnitSizeCol).HeaderText = "Size";
		((DataGridViewColumn)ExistingUnitSizeCol).MinimumWidth = 6;
		((DataGridViewColumn)ExistingUnitSizeCol).Name = "ExistingUnitSizeCol";
		((DataGridViewColumn)ExistingUnitSizeCol).ReadOnly = true;
		((DataGridViewColumn)ExistingUnitSizeCol).Width = 78;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).HeaderText = "Mass";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Name = "DataGridViewTextBoxColumn2";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Width = 48;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).HeaderText = "Area";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Name = "DataGridViewTextBoxColumn3";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Width = 48;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).HeaderText = "PAX";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Name = "DataGridViewTextBoxColumn4";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Width = 46;
		GroundTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)GroundTab).Controls.Add((Control)(object)DBGrid);
		GroundTab.Location = new Point(4, 24);
		((Control)GroundTab).Margin = new Padding(0);
		((Control)GroundTab).Name = "GroundTab";
		((Control)GroundTab).Size = new Size(716, 483);
		GroundTab.TabIndex = 2;
		GroundTab.Text = "Ground";
		ContainerTab.BackColor = Color.FromArgb(60, 63, 65);
		ContainerTab.Location = new Point(4, 24);
		((Control)ContainerTab).Name = "ContainerTab";
		((Control)ContainerTab).Padding = new Padding(3);
		((Control)ContainerTab).Size = new Size(716, 483);
		ContainerTab.TabIndex = 3;
		ContainerTab.Text = "Container";
		FacilityTab.BackColor = Color.FromArgb(60, 63, 65);
		FacilityTab.Location = new Point(4, 24);
		((Control)FacilityTab).Name = "FacilityTab";
		((Control)FacilityTab).Padding = new Padding(3);
		((Control)FacilityTab).Size = new Size(716, 483);
		FacilityTab.TabIndex = 4;
		FacilityTab.Text = "Mobile Facility";
		MountTab.BackColor = Color.FromArgb(60, 63, 65);
		MountTab.Location = new Point(4, 24);
		((Control)MountTab).Name = "MountTab";
		((Control)MountTab).Padding = new Padding(3);
		((Control)MountTab).Size = new Size(716, 483);
		MountTab.TabIndex = 5;
		MountTab.Text = "Mount";
		AircraftTab.BackColor = Color.FromArgb(60, 63, 65);
		AircraftTab.Location = new Point(4, 24);
		((Control)AircraftTab).Name = "AircraftTab";
		((Control)AircraftTab).Padding = new Padding(3);
		((Control)AircraftTab).Size = new Size(716, 483);
		AircraftTab.TabIndex = 6;
		AircraftTab.Text = "Aircraft";
		((DataGridView)DBGrid).AllowUserToAddRows = false;
		((DataGridView)DBGrid).AllowUserToDeleteRows = false;
		((DataGridView)DBGrid).AllowUserToOrderColumns = true;
		((DataGridView)DBGrid).AllowUserToResizeRows = false;
		((Control)DBGrid).Anchor = (AnchorStyles)15;
		((DataGridView)DBGrid).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DBGrid).BorderStyle = (BorderStyle)0;
		((DataGridView)DBGrid).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DBGrid).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)DBGrid).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)1;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DBGrid).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)DBGrid).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = SystemColors.Highlight;
		val5.SelectionForeColor = SystemColors.HighlightText;
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DBGrid).DefaultCellStyle = val5;
		((DataGridView)DBGrid).EnableHeadersVisualStyles = false;
		((Control)DBGrid).Location = new Point(2, 2);
		((Control)DBGrid).Name = "DBGrid";
		((DataGridView)DBGrid).ReadOnly = true;
		((DataGridView)DBGrid).RowHeadersVisible = false;
		((DataGridView)DBGrid).RowHeadersWidth = 51;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)DBGrid).RowsDefaultCellStyle = val6;
		((DataGridView)DBGrid).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DBGrid).Size = new Size(716, 483);
		((Control)DBGrid).TabIndex = 0;
		((Control)LoadCounter).Anchor = (AnchorStyles)6;
		((UpDownBase)LoadCounter).BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)LoadCounter).BorderStyle = (BorderStyle)0;
		((Control)LoadCounter).Font = new Font("Segoe UI", 12f);
		((UpDownBase)LoadCounter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LoadCounter).Location = new Point(253, 546);
		((Control)LoadCounter).Margin = new Padding(0);
		((NumericUpDown)LoadCounter).Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		((NumericUpDown)LoadCounter).Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)LoadCounter).Name = "LoadCounter";
		((Control)LoadCounter).Size = new Size(54, 25);
		((Control)LoadCounter).TabIndex = 6;
		((NumericUpDown)LoadCounter).Value = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)LoadButton).Anchor = (AnchorStyles)6;
		((ButtonBase)LoadButton).BackColor = Color.Transparent;
		((Control)LoadButton).ForeColor = SystemColors.Control;
		((Control)LoadButton).Location = new Point(312, 548);
		((Control)LoadButton).Name = "LoadButton";
		((Control)LoadButton).Padding = new Padding(5);
		LoadButton.RoundRadius = 0;
		((Control)LoadButton).Size = new Size(124, 23);
		((Control)LoadButton).TabIndex = 5;
		LoadButton.Text = "Load Selected";
		((Control)TableLayoutPanel1).Anchor = (AnchorStyles)15;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 306f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 732f));
		TableLayoutPanel1.Controls.Add((Control)(object)Panel_LoadedCargo, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)Panel_AvailableCargo, 1, 0);
		((Control)TableLayoutPanel1).Location = new Point(0, 0);
		((Control)TableLayoutPanel1).Margin = new Padding(0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)TableLayoutPanel1).Size = new Size(1034, 574);
		((Control)TableLayoutPanel1).TabIndex = 8;
		((Control)Panel_LoadedCargo).Anchor = (AnchorStyles)15;
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)DeleteButton);
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)EditContainerButton);
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)CrewBar);
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)AreaBar);
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)MassBar);
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)SizeLabel);
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)InventoryGridView);
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)UnloadButton);
		((Control)Panel_LoadedCargo).Controls.Add((Control)(object)UnloadCounter);
		((Control)Panel_LoadedCargo).Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Panel_LoadedCargo).Location = new Point(0, 0);
		((Control)Panel_LoadedCargo).Margin = new Padding(0);
		((Control)Panel_LoadedCargo).Name = "Panel_LoadedCargo";
		Panel_LoadedCargo.SectionHeader = "Current Cargo at ";
		((Control)Panel_LoadedCargo).Size = new Size(306, 574);
		((Control)Panel_LoadedCargo).TabIndex = 0;
		((Control)DeleteButton).Anchor = (AnchorStyles)6;
		((ButtonBase)DeleteButton).BackColor = Color.Transparent;
		((Control)DeleteButton).ForeColor = Color.Red;
		((Control)DeleteButton).Location = new Point(197, 548);
		((Control)DeleteButton).Name = "DeleteButton";
		((Control)DeleteButton).Padding = new Padding(5);
		DeleteButton.RoundRadius = 0;
		((Control)DeleteButton).Size = new Size(101, 23);
		((Control)DeleteButton).TabIndex = 17;
		DeleteButton.Text = "Delete Selected";
		((Control)EditContainerButton).Anchor = (AnchorStyles)6;
		((ButtonBase)EditContainerButton).BackColor = Color.Transparent;
		((Control)EditContainerButton).ForeColor = SystemColors.Control;
		((Control)EditContainerButton).Location = new Point(197, 548);
		((Control)EditContainerButton).Name = "EditContainerButton";
		((Control)EditContainerButton).Padding = new Padding(5);
		EditContainerButton.RoundRadius = 0;
		((Control)EditContainerButton).Size = new Size(101, 23);
		((Control)EditContainerButton).TabIndex = 17;
		EditContainerButton.Text = "Edit Container";
		((Control)CrewBar).Anchor = (AnchorStyles)14;
		((Control)CrewBar).BackColor = Color.Transparent;
		CrewBar.CustomForeColor = Color.Transparent;
		((Control)CrewBar).Location = new Point(8, 522);
		CrewBar.Maximum = 100;
		((Control)CrewBar).Name = "CrewBar";
		CrewBar.ShowProgressLines = false;
		CrewBar.ShowProgressValue = false;
		CrewBar.ShowText = true;
		((Control)CrewBar).Size = new Size(290, 20);
		((Control)CrewBar).TabIndex = 16;
		((Control)CrewBar).Text = "PAX:";
		CrewBar.Value = 0;
		((Control)AreaBar).Anchor = (AnchorStyles)14;
		((Control)AreaBar).BackColor = Color.Transparent;
		AreaBar.CustomForeColor = Color.Transparent;
		((Control)AreaBar).Location = new Point(8, 499);
		AreaBar.Maximum = 100;
		((Control)AreaBar).Name = "AreaBar";
		AreaBar.ShowProgressLines = false;
		AreaBar.ShowProgressValue = false;
		AreaBar.ShowText = true;
		((Control)AreaBar).Size = new Size(290, 20);
		((Control)AreaBar).TabIndex = 15;
		((Control)AreaBar).Text = "Area:";
		AreaBar.Value = 0;
		((Control)MassBar).Anchor = (AnchorStyles)14;
		((Control)MassBar).BackColor = Color.Transparent;
		MassBar.CustomForeColor = Color.Transparent;
		((Control)MassBar).Location = new Point(8, 476);
		MassBar.Maximum = 100;
		((Control)MassBar).Name = "MassBar";
		MassBar.ShowProgressLines = false;
		MassBar.ShowProgressValue = false;
		MassBar.ShowText = true;
		((Control)MassBar).Size = new Size(290, 20);
		((Control)MassBar).TabIndex = 14;
		((Control)MassBar).Text = "Mass:";
		MassBar.Value = 0;
		((Control)SizeLabel).Anchor = (AnchorStyles)14;
		((Control)SizeLabel).ForeColor = Color.White;
		((Control)SizeLabel).Location = new Point(8, 453);
		((Control)SizeLabel).Name = "SizeLabel";
		((Control)SizeLabel).Size = new Size(290, 20);
		((Control)SizeLabel).TabIndex = 13;
		((Label)SizeLabel).Text = "Max Size:";
		((Label)SizeLabel).TextAlign = (ContentAlignment)16;
		((DataGridView)InventoryGridView).AllowUserToAddRows = false;
		((DataGridView)InventoryGridView).AllowUserToDeleteRows = false;
		((DataGridView)InventoryGridView).AllowUserToOrderColumns = true;
		((Control)InventoryGridView).Anchor = (AnchorStyles)15;
		((DataGridView)InventoryGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)InventoryGridView).BorderStyle = (BorderStyle)0;
		((DataGridView)InventoryGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)InventoryGridView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)InventoryGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = Color.FromArgb(66, 77, 95);
		val7.Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.LightGray;
		val7.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val7.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val7.WrapMode = (DataGridViewTriState)1;
		((DataGridView)InventoryGridView).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)InventoryGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)InventoryGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)InvColName,
			(DataGridViewColumn)InvColMass,
			(DataGridViewColumn)InvColArea,
			(DataGridViewColumn)InvColCrew
		});
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = Color.FromArgb(60, 63, 65);
		val8.Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.LightGray;
		val8.SelectionBackColor = SystemColors.Highlight;
		val8.SelectionForeColor = SystemColors.HighlightText;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)InventoryGridView).DefaultCellStyle = val8;
		((DataGridView)InventoryGridView).EnableHeadersVisualStyles = false;
		((Control)InventoryGridView).Location = new Point(0, 28);
		((Control)InventoryGridView).Name = "InventoryGridView";
		((DataGridView)InventoryGridView).ReadOnly = true;
		((DataGridView)InventoryGridView).RowHeadersVisible = false;
		((DataGridView)InventoryGridView).RowHeadersWidth = 51;
		val9.BackColor = Color.FromArgb(60, 63, 65);
		val9.ForeColor = Color.LightGray;
		val9.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val9.SelectionForeColor = Color.LightGray;
		((DataGridView)InventoryGridView).RowsDefaultCellStyle = val9;
		((DataGridView)InventoryGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)InventoryGridView).Size = new Size(308, 417);
		((Control)InventoryGridView).TabIndex = 12;
		((DataGridViewColumn)InvColName).HeaderText = "Name";
		((DataGridViewColumn)InvColName).MinimumWidth = 6;
		((DataGridViewColumn)InvColName).Name = "InvColName";
		((DataGridViewColumn)InvColName).ReadOnly = true;
		InvColName.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)InvColName).Width = 162;
		((DataGridViewColumn)InvColMass).HeaderText = "Mass";
		((DataGridViewColumn)InvColMass).MinimumWidth = 6;
		((DataGridViewColumn)InvColMass).Name = "InvColMass";
		((DataGridViewColumn)InvColMass).ReadOnly = true;
		((DataGridViewColumn)InvColMass).Width = 48;
		((DataGridViewColumn)InvColArea).HeaderText = "Area";
		((DataGridViewColumn)InvColArea).MinimumWidth = 6;
		((DataGridViewColumn)InvColArea).Name = "InvColArea";
		((DataGridViewColumn)InvColArea).ReadOnly = true;
		((DataGridViewColumn)InvColArea).Width = 48;
		((DataGridViewColumn)InvColCrew).HeaderText = "PAX";
		((DataGridViewColumn)InvColCrew).MinimumWidth = 6;
		((DataGridViewColumn)InvColCrew).Name = "InvColCrew";
		((DataGridViewColumn)InvColCrew).ReadOnly = true;
		((DataGridViewColumn)InvColCrew).Width = 32;
		((Control)Panel_AvailableCargo).Anchor = (AnchorStyles)15;
		((Control)Panel_AvailableCargo).Controls.Add((Control)(object)CB_Filter);
		((Control)Panel_AvailableCargo).Controls.Add((Control)(object)TB_Filter);
		((Control)Panel_AvailableCargo).Controls.Add((Control)(object)CustomNameLabel);
		((Control)Panel_AvailableCargo).Controls.Add((Control)(object)CustomNameTextBox);
		((Control)Panel_AvailableCargo).Controls.Add((Control)(object)CargoSourceTabControl);
		((Control)Panel_AvailableCargo).Controls.Add((Control)(object)LoadButton);
		((Control)Panel_AvailableCargo).Controls.Add((Control)(object)LoadCounter);
		((Control)Panel_AvailableCargo).Font = new Font("Segoe UI", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Panel_AvailableCargo).Location = new Point(306, 0);
		((Control)Panel_AvailableCargo).Margin = new Padding(0);
		((Control)Panel_AvailableCargo).Name = "Panel_AvailableCargo";
		Panel_AvailableCargo.SectionHeader = "Load or Create Cargo (Units, Mounts, Containers and Contents)";
		((Control)Panel_AvailableCargo).Size = new Size(732, 574);
		((Control)Panel_AvailableCargo).TabIndex = 1;
		((Control)CB_Filter).Anchor = (AnchorStyles)10;
		((ButtonBase)CB_Filter).AutoSize = true;
		((Control)CB_Filter).Location = new Point(460, 551);
		((Control)CB_Filter).Name = "CB_Filter";
		((Control)CB_Filter).Size = new Size(74, 19);
		((Control)CB_Filter).TabIndex = 15;
		((ButtonBase)CB_Filter).Text = "Filter by:";
		((Control)TB_Filter).Anchor = (AnchorStyles)10;
		TB_Filter.AutoCompleteCustomSource = null;
		TB_Filter.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Filter.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Filter).BackColor = Color.Transparent;
		TB_Filter.Font = new Font("Segoe UI", 10f);
		((Control)TB_Filter).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Filter.Image = null;
		TB_Filter.Lines = null;
		((Control)TB_Filter).Location = new Point(537, 550);
		TB_Filter.MaxLength = 32767;
		TB_Filter.Multiline = false;
		((Control)TB_Filter).Name = "TB_Filter";
		TB_Filter.ReadOnly = false;
		TB_Filter.ScrollBars = (ScrollBars)0;
		TB_Filter.SelectionStart = 0;
		((Control)TB_Filter).Size = new Size(186, 20);
		((Control)TB_Filter).TabIndex = 14;
		TB_Filter.TextAlign = (HorizontalAlignment)0;
		TB_Filter.UseSystemPasswordChar = false;
		TB_Filter.WatermarkText = "";
		TB_Filter.WordWrap = false;
		((Control)CustomNameLabel).Anchor = (AnchorStyles)6;
		CustomNameLabel.AutoSize = true;
		((Control)CustomNameLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)CustomNameLabel).Location = new Point(0, 549);
		((Control)CustomNameLabel).Name = "CustomNameLabel";
		((Control)CustomNameLabel).Size = new Size(88, 15);
		((Control)CustomNameLabel).TabIndex = 8;
		((Label)CustomNameLabel).Text = "Custom Name:";
		((Label)CustomNameLabel).TextAlign = (ContentAlignment)64;
		((Control)CustomNameTextBox).Anchor = (AnchorStyles)6;
		CustomNameTextBox.AutoCompleteCustomSource = null;
		CustomNameTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		CustomNameTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)CustomNameTextBox).BackColor = Color.Transparent;
		((Control)CustomNameTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		CustomNameTextBox.Image = null;
		CustomNameTextBox.Lines = null;
		((Control)CustomNameTextBox).Location = new Point(97, 547);
		CustomNameTextBox.MaxLength = 256;
		CustomNameTextBox.Multiline = false;
		((Control)CustomNameTextBox).Name = "CustomNameTextBox";
		CustomNameTextBox.ReadOnly = false;
		CustomNameTextBox.ScrollBars = (ScrollBars)0;
		CustomNameTextBox.SelectionStart = 0;
		((Control)CustomNameTextBox).Size = new Size(147, 23);
		((Control)CustomNameTextBox).TabIndex = 7;
		CustomNameTextBox.TextAlign = (HorizontalAlignment)0;
		CustomNameTextBox.UseSystemPasswordChar = false;
		CustomNameTextBox.WatermarkText = "";
		CustomNameTextBox.WordWrap = false;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1034, 583);
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditCargoV2";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit Cargo";
		((ISupportInitialize)UnloadCounter).EndInit();
		((Control)CargoSourceTabControl).ResumeLayout(false);
		((Control)UnitsTab).ResumeLayout(false);
		((ISupportInitialize)(object)ExistingUnitsGridView).EndInit();
		((Control)AircraftTab).ResumeLayout(false);
		((ISupportInitialize)(object)DBGrid).EndInit();
		((ISupportInitialize)LoadCounter).EndInit();
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)Panel_LoadedCargo).ResumeLayout(false);
		((ISupportInitialize)(object)InventoryGridView).EndInit();
		((Control)Panel_AvailableCargo).ResumeLayout(false);
		((Control)Panel_AvailableCargo).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			SelectedHost = null;
			icargoHost_0 = null;
			((DataGridView)InventoryGridView).Rows.Clear();
			((DataGridView)ExistingUnitsGridView).Rows.Clear();
			ArrayExtensions.Clear(ref dataTable_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Keys val = array[num];
				if (keyData == val)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		int result;
		if (!((Control)this).Visible)
		{
			result = 1;
		}
		else
		{
			((Form)this).Close();
			result = 1;
		}
		return (byte)result != 0;
	}

	private void EditCargoV2_Load(object sender, EventArgs e)
	{
		Scenario.UnitAdded += HandleUnitAdded;
		Scenario.UnitRemoved += HandleUnitRemoved;
		bool_2 = SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo;
		if (dataTable_0.Length < ((TabControl)CargoSourceTabControl).TabCount)
		{
			dataTable_0 = new DataTable[((TabControl)CargoSourceTabControl).TabCount + 1];
		}
	}

	private void EditCargoV2_Shown(object sender, EventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (SelectedHost is Group)
		{
			DarkMessageBox.ShowError("Please choose an individual unit, not a group.", "Error");
			((Form)this).Close();
			return;
		}
		icargoHost_0 = (ICargoHost)SelectedHost;
		((Form)this).Text = "Edit Cargo for " + SelectedHost.Name;
		Panel_LoadedCargo.SectionHeader = "Current Cargo at " + SelectedHost.Name;
		LoadButton.Enabled = false;
		((Control)LoadCounter).Visible = false;
		UnloadButton.Enabled = false;
		((Control)DeleteButton).Visible = false;
		((Control)UnloadCounter).Visible = false;
		((Control)CustomNameLabel).Visible = false;
		((Control)CustomNameTextBox).Visible = false;
		EditContainerButton.Enabled = false;
		PopulateInventory();
		method_7(null, null);
		method_4();
		method_2();
		method_3();
	}

	public void RefreshForm()
	{
		PopulateInventory();
		method_4();
		method_6();
		method_3();
		if (bool_2 != SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			if (((Control)MyProject.Forms.EditCargoContainer).Visible)
			{
				((Form)MyProject.Forms.EditCargoContainer).Close();
			}
			method_12(null, null);
			bool_2 = SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo;
		}
		MyProject.Forms.MainForm.RightColumn1.AdjustToSelectionChange(Client.SelectedUnit, Client.SelectedUnit);
	}

	private void method_2()
	{
		cargoType_0 = icargoHost_0.GetCargo_Type();
		float_0 = icargoHost_0.GetCargo_Mass();
		float_1 = icargoHost_0.GetCargo_Area();
		float_2 = icargoHost_0.GetCargo_Crew();
		Cargo[] cargoArray = icargoHost_0.CargoArray;
		foreach (Cargo cargo in cargoArray)
		{
			float_0 -= cargo.RequiredMass;
			float_1 -= cargo.RequiredArea;
			float_2 -= cargo.RequiredCrewSpace;
		}
	}

	private void method_3()
	{
		CargoUICommon.UpdateCapacityLabels(SelectedHost, SizeLabel, MassBar, float_0, AreaBar, float_1, CrewBar, float_2);
	}

	protected void PopulateInventory()
	{
		CargoUICommon.PopulateGridViewCargoInventory(InventoryGridView, SelectedHost, SelectedHost.OnboardCargo.ToList());
		method_7(null, null);
	}

	internal static List<ActiveUnit> GetActiveUnitsThatCanBeMovedIntoCargo(ActiveUnit host)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit activeUnits_ in host.ParentScen.ActiveUnits_List)
		{
			if (activeUnits_ != host && activeUnits_.get_UnitSide(SetSideOnly: false) == host.get_UnitSide(SetSideOnly: false) && activeUnits_.IsOperating() && activeUnits_ is ICargoClient && ((ICargoClient)activeUnits_).GetRequiredCargoType() != CargoType.NoCargo)
			{
				list.Add(activeUnits_);
			}
		}
		if (host.IsFixedFacility && host.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			list.AddRange(host.get_ParentGroup(UsingMissionPlanner: false).GetHostedUnitsThatCanBeLoadedAsCargo());
		}
		else
		{
			list.AddRange(host.GetHostedUnitsThatCanBeLoadedAsCargo());
		}
		return list;
	}

	private void method_4()
	{
		int num = -1;
		bool flag = !string.IsNullOrEmpty(lMiBqemfTx);
		if (((BaseCollection)((DataGridView)ExistingUnitsGridView).SelectedRows).Count > 0)
		{
			num = ((DataGridViewBand)((DataGridView)ExistingUnitsGridView).SelectedRows[0]).Index;
		}
		((DataGridView)ExistingUnitsGridView).Rows.Clear();
		List<ActiveUnit> activeUnitsThatCanBeMovedIntoCargo = GetActiveUnitsThatCanBeMovedIntoCargo(SelectedHost);
		foreach (ActiveUnit item in activeUnitsThatCanBeMovedIntoCargo)
		{
			if (item != SelectedHost && item.get_UnitSide(SetSideOnly: false) == SelectedHost.get_UnitSide(SetSideOnly: false) && item is ICargoClient && (!flag || LikeOperator.LikeString(item.Name, lMiBqemfTx, (CompareMethod)1)))
			{
				ICargoClient cargoClient = (ICargoClient)item;
				int requiredCargoType = (int)cargoClient.GetRequiredCargoType();
				int num2 = ((DataGridView)ExistingUnitsGridView).Rows.Add();
				DataGridViewRow val = ((DataGridView)ExistingUnitsGridView).Rows[num2];
				((DataGridViewBand)val).Tag = item;
				val.Cells[0].Value = item.UnitType_String;
				string text = item.Name;
				if (item.IsAircraft && ((Aircraft)item).AirOps.HostAirFacility != null)
				{
					text = "[HOSTED] " + text + " (" + item.UnitClass + ")";
				}
				else if (item.DockingOps.HostDockFacility != null)
				{
					text = "[HOSTED] " + text;
				}
				val.Cells[1].Value = text;
				if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
				{
					val.Cells[3].Value = Cargo.DisplayValueMass(cargoClient.GetRequiredMass(), USUnits: true).ToString("N");
					val.Cells[4].Value = Cargo.DisplayValueArea(cargoClient.GetRequiredArea(), USUnits: true).ToString("N");
				}
				else
				{
					val.Cells[3].Value = cargoClient.GetRequiredMass().ToString("N");
					val.Cells[4].Value = cargoClient.GetRequiredArea().ToString("N");
				}
				val.Cells[5].Value = cargoClient.GetRequiredCrewSpace().ToString();
				val.Cells[2].Value = CargoUICommon.GetSizeString(requiredCargoType);
				if (!icargoHost_0.CanLoad(cargoClient) && !icargoHost_0.CanTow(cargoClient))
				{
					val.DefaultCellStyle.ForeColor = Color.Red;
					val.DefaultCellStyle.SelectionForeColor = Color.Red;
				}
			}
		}
		if (((DataGridView)ExistingUnitsGridView).Rows.Count > 0)
		{
			((Control)NoUnitsWarningLabel).Visible = false;
			if (num > -1)
			{
				((DataGridView)ExistingUnitsGridView).ClearSelection();
				if (num >= ((DataGridView)ExistingUnitsGridView).Rows.Count)
				{
					num = ((DataGridView)ExistingUnitsGridView).Rows.Count - 1;
				}
				((DataGridView)ExistingUnitsGridView).Rows[num].Selected = true;
			}
		}
		else
		{
			((Control)NoUnitsWarningLabel).Visible = true;
		}
		((Control)ExistingUnitsGridView).Refresh();
		if (((TabControl)CargoSourceTabControl).SelectedIndex == 0)
		{
			method_8(null, null);
		}
	}

	private bool method_5(DataGridViewRow dataGridViewRow_0, int int_0, CargoType cargoType_1, float float_3, float float_4, float float_5)
	{
		if (Cargo.InputValueMass(Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Mass"].Value) * (float)int_0, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) > float_3)
		{
			return false;
		}
		if (Cargo.InputValueArea(Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Area"].Value) * (float)int_0, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) > float_4)
		{
			return false;
		}
		if (Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Crew"].Value) * (float)int_0 > float_5)
		{
			return false;
		}
		int sizeValueFromString = CargoUICommon.GetSizeValueFromString(Conversions.ToString(dataGridViewRow_0.Cells["Cargo_Type"].Value));
		int result;
		if (sizeValueFromString == 0)
		{
			result = 0;
		}
		else
		{
			if (sizeValueFromString <= (int)cargoType_1)
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private void method_6()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		int int_ = 1;
		bool flag = true;
		bool flag2 = !string.IsNullOrEmpty(lMiBqemfTx);
		if (((Control)LoadCounter).Enabled)
		{
			int_ = Convert.ToInt32(((NumericUpDown)LoadCounter).Value);
		}
		method_2();
		if (flag2 && ((DataGridView)DBGrid).CurrentCell != null)
		{
			((DataGridView)DBGrid).CurrentCell = null;
		}
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DBGrid).Rows)
		{
			DataGridViewRow val = item;
			flag = true;
			if (flag2)
			{
				flag = LikeOperator.LikeString(Conversions.ToString(val.Cells[2].Value), lMiBqemfTx, (CompareMethod)1);
			}
			if (method_5(val, int_, cargoType_0, float_0, float_1, float_2))
			{
				val.DefaultCellStyle.ForeColor = ((DataGridView)DBGrid).DefaultCellStyle.ForeColor;
				val.DefaultCellStyle.SelectionForeColor = ((DataGridView)DBGrid).DefaultCellStyle.SelectionForeColor;
			}
			else
			{
				val.DefaultCellStyle.ForeColor = Color.Red;
				val.DefaultCellStyle.SelectionForeColor = Color.Red;
			}
			val.Visible = flag;
		}
		method_9(null, null);
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)InventoryGridView).SelectedRows)
		{
			DataGridViewRow val = item;
			if (((DataGridViewBand)val).Tag == null)
			{
				continue;
			}
			if (!(((DataGridViewBand)val).Tag is CargoManifestItem))
			{
				if (((DataGridViewBand)val).Tag is Cargo && ((Cargo)((DataGridViewBand)val).Tag).CargoObjectActiveUnit != null)
				{
					flag = true;
				}
				else if (((DataGridViewBand)val).Tag is Cargo && ((Cargo)((DataGridViewBand)val).Tag).CurrentType == Cargo.CargoObjectType.CargoContainer)
				{
					flag3 = true;
				}
			}
			else
			{
				flag2 = true;
				num = Math.Max(num, ((CargoManifestItem)((DataGridViewBand)val).Tag).quantity);
			}
		}
		if (flag3)
		{
			((Control)UnloadButton).Visible = false;
			((Control)DeleteButton).Left = ((Control)UnloadButton).Left;
			((Control)DeleteButton).Visible = true;
			((Control)EditContainerButton).Visible = true;
		}
		else if (flag2 || flag)
		{
			((Control)DeleteButton).Left = ((Control)EditContainerButton).Left;
			((Control)UnloadButton).Visible = true;
			((Control)DeleteButton).Visible = true;
			((Control)EditContainerButton).Visible = false;
		}
		DeleteButton.Enabled = flag2 || flag || flag3;
		((Control)UnloadCounter).Visible = flag2;
		UnloadButton.Enabled = flag;
		EditContainerButton.Enabled = flag3;
		if (flag2)
		{
			((NumericUpDown)UnloadCounter).Maximum = new decimal(num);
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		LoadButton.Enabled = false;
		IEnumerator enumerator = ((BaseCollection)((DataGridView)ExistingUnitsGridView).SelectedRows).GetEnumerator();
		try
		{
			DataGridViewRow val;
			do
			{
				if (enumerator.MoveNext())
				{
					val = (DataGridViewRow)enumerator.Current;
					continue;
				}
				return;
			}
			while (((DataGridViewBand)val).Tag == null || (!icargoHost_0.CanLoad((ICargoClient)((DataGridViewBand)val).Tag) && !icargoHost_0.CanTow((ICargoClient)((DataGridViewBand)val).Tag)));
			LoadButton.Enabled = true;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		int int_ = 1;
		if (((Control)LoadCounter).Visible)
		{
			int_ = Convert.ToInt32(((NumericUpDown)LoadCounter).Value);
		}
		LoadButton.Enabled = false;
		method_2();
		IEnumerator enumerator = ((BaseCollection)((DataGridView)DBGrid).SelectedRows).GetEnumerator();
		try
		{
			DataGridViewRow dataGridViewRow_;
			do
			{
				if (enumerator.MoveNext())
				{
					dataGridViewRow_ = (DataGridViewRow)enumerator.Current;
					continue;
				}
				return;
			}
			while (!method_5(dataGridViewRow_, int_, cargoType_0, float_0, float_1, float_2));
			LoadButton.Enabled = true;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		method_6();
	}

	private DataTable method_11(int int_0, Scenario scenario_0)
	{
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		if (dataTable_0[int_0] == null)
		{
			bool flag = false;
			DataTable dataTable = null;
			if (SelectedHost != null)
			{
				try
				{
					switch (int_0)
					{
					case 1:
					{
						SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
						dataTable = DBFunctions.GetAllCargoGroundUnits(ref sqliteConnection_);
						break;
					}
					case 2:
					{
						SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
						dataTable = DBFunctions.GetAllCargoContainers(ref sqliteConnection_);
						break;
					}
					case 3:
					{
						SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
						DataTable allCargoMounts = DBFunctions.GetAllCargoMounts(ref sqliteConnection_);
						sqliteConnection_ = SelectedHost.ParentScen.DBConnection;
						dataTable = DBFunctions.GetAllCargoFacilities(ref sqliteConnection_, allCargoMounts);
						break;
					}
					case 4:
					{
						SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
						dataTable = DBFunctions.GetAllCargoMounts(ref sqliteConnection_);
						break;
					}
					case 5:
					{
						SQLiteConnection sqliteConnection_ = SelectedHost.ParentScen.DBConnection;
						dataTable = DBFunctions.GetAllCargoAircraft(ref sqliteConnection_);
						break;
					}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					flag = true;
					ProjectData.ClearProjectError();
				}
				if (!flag && dataTable != null && dataTable.Columns.Count >= 8 && dataTable.Rows.Count >= 1)
				{
					DataTable dataTable2 = dataTable.Clone();
					if (dataTable2.Columns.Contains("Deprecated"))
					{
						dataTable2.Columns.Remove("Deprecated");
					}
					dataTable2.Columns["Cargo_Type"].DataType = typeof(string);
					foreach (DataRow row in dataTable.Rows)
					{
						dataTable2.ImportRow(row);
					}
					foreach (DataRow row2 in dataTable2.Rows)
					{
						int sizeValue = int.Parse(Conversions.ToString(row2["Cargo_Type"]));
						row2["Cargo_Type"] = CargoUICommon.GetSizeString(sizeValue);
					}
					dataTable_0[int_0] = dataTable2;
					return dataTable2;
				}
				DarkMessageBox.ShowError("Unable to use currently loaded database for cargo related tasks. Please upgrade scenario to latest database.", "Error");
				return null;
			}
			return null;
		}
		return dataTable_0[int_0];
	}

	private void method_12(object sender, EventArgs e)
	{
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		int selectedIndex = ((TabControl)CargoSourceTabControl).SelectedIndex;
		if (selectedIndex == 0)
		{
			((Control)LoadCounter).Visible = false;
			((Control)CustomNameLabel).Visible = false;
			((Control)CustomNameTextBox).Visible = false;
			method_4();
			return;
		}
		if (bool_2 != SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			dataTable_0 = new DataTable[((TabControl)CargoSourceTabControl).TabCount + 1];
			bool_2 = SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo;
		}
		DataTable dataTable = default(DataTable);
		if (SelectedHost != null)
		{
			dataTable = method_11(selectedIndex, SelectedHost.ParentScen);
		}
		((Control)LoadCounter).Visible = true;
		((Control)CustomNameLabel).Visible = true;
		((Control)CustomNameTextBox).Visible = true;
		if (SelectedHost == null || dataTable == null)
		{
			return;
		}
		((Control)DBGrid).Parent = (Control)(object)((TabControl)CargoSourceTabControl).SelectedTab;
		((Control)DBGrid).Width = ((Control)DBGrid).Parent.Width;
		((Control)DBGrid).Height = ((Control)DBGrid).Parent.Height;
		((DataGridView)DBGrid).DataSource = new DataView(dataTable);
		((DataGridView)DBGrid).Columns["UnitType"].HeaderText = "Type";
		((DataGridView)DBGrid).Columns["Cargo_Type"].HeaderText = "Cargo Size";
		((DataGridView)DBGrid).Columns["Cargo_Mass"].HeaderText = "Mass";
		((DataGridView)DBGrid).Columns["Cargo_Mass"].DefaultCellStyle.Format = "N";
		((DataGridView)DBGrid).Columns["Cargo_Area"].HeaderText = "Area";
		((DataGridView)DBGrid).Columns["Cargo_Area"].DefaultCellStyle.Format = "N";
		((DataGridView)DBGrid).Columns["Cargo_Crew"].HeaderText = "PAX";
		((DataGridView)DBGrid).Columns["Cargo_ParadropCapable"].HeaderText = "Airdrop";
		((DataGridView)DBGrid).AutoResizeColumns();
		if (((DataGridView)DBGrid).Columns["Name"].Width > 300)
		{
			((DataGridView)DBGrid).Columns["Name"].Width = 300;
		}
		if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DBGrid).Rows)
			{
				float metricTons = Conversions.ToSingle(item.Cells["Cargo_Mass"].Value);
				item.Cells["Cargo_Mass"].Value = Cargo.DisplayValueMass(metricTons, USUnits: true);
				metricTons = Conversions.ToSingle(item.Cells["Cargo_Area"].Value);
				item.Cells["Cargo_Area"].Value = Cargo.DisplayValueArea(metricTons, USUnits: true);
			}
		}
		((Control)DBGrid).Refresh();
		method_6();
	}

	private void method_13(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void method_14(ref Aircraft aircraft_0, string string_0, float float_3, float float_4, int int_0, bool bool_3)
	{
		if (list_0 == null)
		{
			list_0 = DBFunctions.LoadoutsForThisAircraft(aircraft_0.DBID, aircraft_0.ParentScen);
		}
		aircraft_0.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
		aircraft_0.AirOps.ConditionTimer = 0f;
		CargoType sizeValueFromString = (CargoType)CargoUICommon.GetSizeValueFromString(string_0);
		Loadout loadout = null;
		foreach (Loadout item in list_0)
		{
			if (item.Role == Loadout.LoadoutRole.PackedForCargo)
			{
				if (item.Cargo_Type == sizeValueFromString && item.Cargo_Mass == float_3 && item.Cargo_Area == float_4 && item.Cargo_Crew == int_0 && item.Cargo_ParadropCapable == bool_3)
				{
					DBFunctions.GetLoadout(ref aircraft_0, item.DBID, ExcludeOptionalWeapons: true);
					return;
				}
			}
			else if (loadout == null && item.Role == Loadout.LoadoutRole.Reserve)
			{
				loadout = item;
			}
		}
		aircraft_0.Loadout = loadout;
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		new List<Cargo>();
		int num = 1;
		string text = "";
		bool flag = false;
		bool flag2 = false;
		method_2();
		string text2 = LoadButton.Text;
		LoadButton.Enabled = false;
		LoadButton.Text = "Working...";
		if (((TabControl)CargoSourceTabControl).SelectedIndex <= 0)
		{
			foreach (DataGridViewRow item in (BaseCollection)((DataGridView)ExistingUnitsGridView).SelectedRows)
			{
				ActiveUnit activeUnit = (ActiveUnit)((DataGridViewBand)item).Tag;
				ICargoClient potentialCargo = (ICargoClient)activeUnit;
				if (!icargoHost_0.CanLoad(potentialCargo))
				{
					if (!icargoHost_0.CanTow(potentialCargo))
					{
						flag2 = true;
						break;
					}
					Cargo cargo = new Cargo(SelectedHost, activeUnit);
					cargo.StorageType = Cargo.CargoStorageType.TowedExternal;
					activeUnit.DockingOps.LoadIntoCargo(SelectedHost);
					icargoHost_0.Add(cargo);
				}
				else
				{
					Cargo c = new Cargo(SelectedHost, activeUnit);
					activeUnit.DockingOps.LoadIntoCargo(SelectedHost);
					icargoHost_0.Add(c);
				}
			}
		}
		else
		{
			Aircraft aircraft = null;
			Mount mount = null;
			Vehicle vehicle = null;
			Facility facility = null;
			int num2 = 1;
			if (((Control)LoadCounter).Visible)
			{
				num = Convert.ToInt32(((NumericUpDown)LoadCounter).Value);
			}
			if (((Control)CustomNameTextBox).Visible)
			{
				text = CustomNameTextBox.Text;
				flag = !string.IsNullOrEmpty(text);
			}
			foreach (DataGridViewRow item2 in (BaseCollection)((DataGridView)DBGrid).SelectedRows)
			{
				DataGridViewRow val = item2;
				int num3 = Conversions.ToInteger(val.Cells["ID"].Value);
				if (num3 > 0)
				{
					list_0 = null;
					int num4 = num - 1;
					for (int i = 0; i <= num4; i++)
					{
						string text3 = val.Cells["UnitType"].Value.ToString();
						if (Operators.CompareString(text3, "Ground Unit", true) == 0)
						{
							if (flag)
							{
								vehicle = Client.CurrentScenario.AddNewVehicle(Client.CurrentSide, num3, text + " #" + Conversions.ToString(num2), SelectedHost.get_Longitude((GlobalVariables.BooleanObject)null), SelectedHost.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
								num2++;
							}
							else
							{
								SQLiteConnection theConn = SelectedHost.ParentScen.DBConnection;
								text = DBFunctions.GetVehicleName(num3, ref theConn);
								text = text + " #" + Conversions.ToString(SelectedHost.ParentScen.UnitsAutoIncrement);
								vehicle = Client.CurrentScenario.AddNewVehicle(Client.CurrentSide, num3, text, SelectedHost.get_Longitude((GlobalVariables.BooleanObject)null), SelectedHost.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
							}
							if (!icargoHost_0.CanLoad(vehicle))
							{
								if (!icargoHost_0.CanTow(vehicle))
								{
									SelectedHost.ParentScen.DeleteUnitImmediately(vehicle.ObjectID, ScenEditAction: true, "Failed to load into cargo.", null, RegisterAsLosses: false);
									flag2 = true;
									break;
								}
								Cargo cargo2 = new Cargo(SelectedHost, vehicle);
								cargo2.StorageType = Cargo.CargoStorageType.TowedExternal;
								vehicle.DockingOps.LoadIntoCargo(SelectedHost);
								icargoHost_0.Add(cargo2);
							}
							else
							{
								Cargo c2 = new Cargo(SelectedHost, vehicle);
								vehicle.DockingOps.LoadIntoCargo(SelectedHost);
								icargoHost_0.Add(c2);
							}
						}
						else if (Operators.CompareString(text3, "Mobile Facility", true) == 0)
						{
							if (flag)
							{
								facility = Client.CurrentScenario.AddNewFacility(Client.CurrentSide, num3, text + " #" + Conversions.ToString(num2), SelectedHost.get_Longitude((GlobalVariables.BooleanObject)null), SelectedHost.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
								num2++;
							}
							else
							{
								SQLiteConnection theConn = SelectedHost.ParentScen.DBConnection;
								text = DBFunctions.GetFacilityName(num3, ref theConn);
								text = text + " #" + Conversions.ToString(SelectedHost.ParentScen.UnitsAutoIncrement);
								facility = Client.CurrentScenario.AddNewFacility(Client.CurrentSide, num3, text, SelectedHost.get_Longitude((GlobalVariables.BooleanObject)null), SelectedHost.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
							}
							if (!icargoHost_0.CanLoad(facility))
							{
								SelectedHost.ParentScen.DeleteUnitImmediately(facility.ObjectID, ScenEditAction: true, "Failed to load into cargo.", null, RegisterAsLosses: false);
								flag2 = true;
								break;
							}
							Cargo c3 = new Cargo(SelectedHost, facility);
							facility.DockingOps.LoadIntoCargo(SelectedHost);
							icargoHost_0.Add(c3);
						}
						else if (Operators.CompareString(text3, "Mount", true) == 0)
						{
							mount = DBFunctions.GetMount(num3, ref SelectedHost.ParentScen);
							if (!icargoHost_0.CanLoad(mount))
							{
								flag2 = true;
								break;
							}
							Cargo c4 = new Cargo(SelectedHost, mount);
							icargoHost_0.Add(c4);
						}
						else if (Operators.CompareString(text3, "Container", true) == 0)
						{
							CargoContainer cargoContainer = DBFunctions.GetCargoContainer(num3, ref SelectedHost.ParentScen);
							if (!icargoHost_0.CanLoad(cargoContainer))
							{
								flag2 = true;
								break;
							}
							Cargo c5 = new Cargo(SelectedHost, cargoContainer, (ICargoHost)SelectedHost);
							icargoHost_0.Add(c5);
						}
						else if (Operators.CompareString(text3, "Aircraft", true) == 0)
						{
							if (flag)
							{
								aircraft = Client.CurrentScenario.AddNewAircraft(Client.CurrentSide, text + " #" + Conversions.ToString(num2), SelectedHost.get_Longitude((GlobalVariables.BooleanObject)null), SelectedHost.get_Latitude((GlobalVariables.BooleanObject)null), num3, 0, SelectedHost.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, null, IgnoreOperationalCeiling: true);
								num2++;
							}
							else
							{
								SQLiteConnection theConn = SelectedHost.ParentScen.DBConnection;
								text = DBFunctions.GetAircraftName(num3, ref theConn);
								text = text + " #" + Conversions.ToString(SelectedHost.ParentScen.UnitsAutoIncrement);
								aircraft = Client.CurrentScenario.AddNewAircraft(Client.CurrentSide, text, SelectedHost.get_Longitude((GlobalVariables.BooleanObject)null), SelectedHost.get_Latitude((GlobalVariables.BooleanObject)null), num3, 0, SelectedHost.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, null, IgnoreOperationalCeiling: true);
							}
							method_14(ref aircraft, Conversions.ToString(val.Cells["Cargo_Type"].Value), Conversions.ToSingle(val.Cells["Cargo_Mass"].Value), Conversions.ToSingle(val.Cells["Cargo_Area"].Value), Conversions.ToInteger(val.Cells["Cargo_Crew"].Value), Conversions.ToBoolean(val.Cells["Cargo_ParadropCapable"].Value));
							if (!icargoHost_0.CanLoad(aircraft))
							{
								SelectedHost.ParentScen.DeleteUnitImmediately(aircraft.ObjectID, ScenEditAction: true, "Failed to load into cargo.", null, RegisterAsLosses: false);
								flag2 = true;
								break;
							}
							Cargo c6 = new Cargo(SelectedHost, aircraft);
							aircraft.DockingOps.LoadIntoCargo(SelectedHost);
							icargoHost_0.Add(c6);
						}
					}
				}
				if (flag2)
				{
					break;
				}
			}
			CustomNameTextBox.Text = "";
		}
		LoadButton.Text = text2;
		LoadButton.Enabled = true;
		if (flag2)
		{
			DarkMessageBox.ShowWarning("Unable to add all of the selected cargo to host - maximum capacity exceeded.", "Out of space!");
		}
		RefreshForm();
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		List<Cargo> list = new List<Cargo>();
		List<Cargo> list2 = new List<Cargo>();
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)InventoryGridView).SelectedRows)
		{
			DataGridViewRow val = item;
			if (!(((DataGridViewBand)val).Tag is CargoManifestItem))
			{
				Cargo cargo = (Cargo)((DataGridViewBand)val).Tag;
				Cargo.CargoObjectType currentType = cargo.CurrentType;
				if ((uint)(currentType - 4) > 1u)
				{
					list.Add(cargo);
				}
			}
		}
		if (list.Count > 0)
		{
			List<Cargo> list3 = new List<Cargo>();
			foreach (Cargo item2 in list)
			{
				list3.Clear();
				string cargoObjectID = item2.CargoObjectID;
				if (SelectedHost.ParentScen.ActiveUnits.TryGetValue(cargoObjectID, out var value))
				{
					list3.Add(item2);
					double latitude_old = value.Latitude_old;
					double longitude_old = value.Longitude_old;
					ActiveUnit selectedHost = SelectedHost;
					ICargoHost cargoHost;
					Cargo[] CargoList = (cargoHost = icargoHost_0).CargoArray;
					Cargo.UnloadCargoAtLocation(selectedHost, ref CargoList, list3, latitude_old, longitude_old, SelectedHost.ParentScen, SelectedHost.get_UnitSide(SetSideOnly: false), paradropOnly: false, ByUser: true);
					cargoHost.CargoArray = CargoList;
				}
			}
		}
		if (list2.Count > 0)
		{
			foreach (Cargo item3 in list2)
			{
				icargoHost_0.Remove(item3);
			}
		}
		method_2();
		RefreshForm();
	}

	public void HandleUnitAdded(Scenario theScen, string theUnitObjectID)
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				HandleUnitAdded(theScen, theUnitObjectID);
			}));
		}
		else if (((Control)this).Visible)
		{
			RefreshForm();
		}
	}

	public void HandleUnitRemoved(Scenario theScen, ActiveUnit theUnit)
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				HandleUnitRemoved(theScen, theUnit);
			}));
		}
		else if (((Control)this).Visible)
		{
			if (theUnit == SelectedHost)
			{
				SelectedHost = null;
				icargoHost_0 = null;
				((Form)this).Close();
			}
			else
			{
				RefreshForm();
			}
		}
	}

	private void wjrNfXaMeJ()
	{
		method_4();
		method_6();
	}

	private void method_17(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		List<Cargo> list = new List<Cargo>();
		int num = 0;
		int num2 = 0;
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)InventoryGridView).SelectedRows)
		{
			DataGridViewRow val = item;
			if (((DataGridViewBand)val).Tag is CargoManifestItem)
			{
				CargoManifestItem cargoManifestItem = (CargoManifestItem)((DataGridViewBand)val).Tag;
				int num3;
				if (((Control)UnloadCounter).Visible)
				{
					num = Convert.ToInt32(((NumericUpDown)UnloadCounter).Value);
					if (num > cargoManifestItem.quantity)
					{
						num = cargoManifestItem.quantity;
						num3 = 0;
					}
					else
					{
						num3 = 0;
					}
				}
				else
				{
					num = 1;
					num3 = 0;
				}
				for (num2 = num3; num2 < SelectedHost.OnboardCargo.Count(); num2++)
				{
					if (num <= 0)
					{
						break;
					}
					if (SelectedHost.OnboardCargo[num2].CurrentType == cargoManifestItem.objectType && SelectedHost.OnboardCargo[num2].CargoObjectDBID == cargoManifestItem.DBID)
					{
						list.Add(SelectedHost.OnboardCargo[num2]);
						num--;
					}
				}
			}
			else
			{
				list.Add((Cargo)((DataGridViewBand)val).Tag);
			}
		}
		if (list.Count > 0)
		{
			foreach (Cargo item2 in list)
			{
				ArrayExtensions.Remove(ref SelectedHost.OnboardCargo, item2);
				ActiveUnit cargoObjectActiveUnit = item2.CargoObjectActiveUnit;
				if (cargoObjectActiveUnit != null)
				{
					Client.CurrentScenario.DeleteUnitImmediately(cargoObjectActiveUnit.ObjectID, ScenEditAction: true, "Unit was deleted while editing cargo.", null, RegisterAsLosses: false);
				}
			}
		}
		method_2();
		RefreshForm();
	}

	private void method_18(object sender, EventArgs e)
	{
		if (!((CheckBox)CB_Filter).Checked)
		{
			lMiBqemfTx = "";
		}
		else
		{
			lMiBqemfTx = "*" + Misc.EscapeLikeValue(TB_Filter.Text) + "*";
		}
		if (((TabControl)CargoSourceTabControl).SelectedIndex <= 0)
		{
			method_4();
		}
		else
		{
			method_6();
		}
	}

	private void method_19(object object_0)
	{
		if (((CheckBox)CB_Filter).Checked && Operators.CompareString(TB_Filter.Text, "", true) != 0)
		{
			lMiBqemfTx = "*" + Misc.EscapeLikeValue(TB_Filter.Text) + "*";
			if (((TabControl)CargoSourceTabControl).SelectedIndex <= 0)
			{
				method_4();
			}
			else
			{
				method_6();
			}
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		if (((BaseCollection)((DataGridView)InventoryGridView).SelectedRows).Count <= 0)
		{
			return;
		}
		int num = ((BaseCollection)((DataGridView)InventoryGridView).SelectedRows).Count - 1;
		int num2 = 0;
		Cargo cargo;
		while (true)
		{
			if (num2 > num)
			{
				return;
			}
			if (((DataGridViewBand)((DataGridView)InventoryGridView).SelectedRows[num2]).Tag is Cargo)
			{
				cargo = (Cargo)((DataGridViewBand)((DataGridView)InventoryGridView).SelectedRows[num2]).Tag;
				if (cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
				{
					break;
				}
			}
			num2++;
		}
		MyProject.Forms.EditCargoContainer.SelectedActiveUnit = SelectedHost;
		MyProject.Forms.EditCargoContainer.SelectedContainer = cargo.CargoObjectContainer;
		((Form)MyProject.Forms.EditCargoContainer).ShowDialog();
	}

	private void method_21(object sender, EventArgs e)
	{
	}

	static EditCargoV2()
	{
		Class72.smethod_20();
	}
}

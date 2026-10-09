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
public class EditCargoContainer : DarkSecondaryFormBase
{
	private class Class1
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private int int_0;

		public string Name
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

		public int ID
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public Class1(string string_1, int int_1)
		{
			Name = string_1;
			ID = int_1;
		}

		static Class1()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("InventoryGridView")]
	private DarkDataGridView _InventoryGridView;

	[CompilerGenerated]
	[AccessedThroughProperty("RemoveButton")]
	private DarkUIButton _RemoveButton;

	[AccessedThroughProperty("ContentsSourceTabControl")]
	[CompilerGenerated]
	private DarkUITabControl _ContentsSourceTabControl;

	[AccessedThroughProperty("DBGrid")]
	[CompilerGenerated]
	private DarkDataGridView _DBGrid;

	[CompilerGenerated]
	[AccessedThroughProperty("AddButton")]
	private DarkUIButton _AddButton;

	[AccessedThroughProperty("FuelTrackBar")]
	[CompilerGenerated]
	private TrackBar _FuelTrackBar;

	[CompilerGenerated]
	[AccessedThroughProperty("FuelTypeComboBox")]
	private DarkUIComboBox _FuelTypeComboBox;

	[CompilerGenerated]
	[AccessedThroughProperty("UserContentLengthTextbox")]
	private DarkUITextBox _UserContentLengthTextbox;

	[CompilerGenerated]
	[AccessedThroughProperty("UserContentHeightTextBox")]
	private DarkUITextBox _UserContentHeightTextBox;

	[AccessedThroughProperty("UserContentWidthTextBox")]
	[CompilerGenerated]
	private DarkUITextBox _UserContentWidthTextBox;

	public ActiveUnit SelectedActiveUnit;

	public CargoContainer SelectedContainer;

	private ICargoHost icargoHost_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private CargoContainerContent cargoContainerContent_0;

	private bool bool_2;

	private Keys[] keys_0;

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("DarkSectionPanel1")]
	internal virtual DarkSectionPanel DarkSectionPanel1 { get; set; }

	[field: AccessedThroughProperty("CrewBar")]
	internal virtual DarkUIProgressBar CrewBar { get; set; }

	[field: AccessedThroughProperty("AreaBar")]
	internal virtual DarkUIProgressBar AreaBar { get; set; }

	[field: AccessedThroughProperty("MassBar")]
	internal virtual DarkUIProgressBar MassBar { get; set; }

	[field: AccessedThroughProperty("SizeLabel")]
	internal virtual DarkLabel SizeLabel { get; set; }

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
			EventHandler eventHandler = method_10;
			DarkDataGridView darkDataGridView = _InventoryGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_InventoryGridView = value;
			darkDataGridView = _InventoryGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
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

	internal virtual DarkUIButton RemoveButton
	{
		[CompilerGenerated]
		get
		{
			return _RemoveButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIButton darkUIButton = _RemoveButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_RemoveButton = value;
			darkUIButton = _RemoveButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("RemoveCounter")]
	internal virtual DarkNumericUpDown RemoveCounter { get; set; }

	[field: AccessedThroughProperty("DarkSectionPanel2")]
	internal virtual DarkSectionPanel DarkSectionPanel2 { get; set; }

	internal virtual DarkUITabControl ContentsSourceTabControl
	{
		[CompilerGenerated]
		get
		{
			return _ContentsSourceTabControl;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUITabControl darkUITabControl = _ContentsSourceTabControl;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_ContentsSourceTabControl = value;
			darkUITabControl = _ContentsSourceTabControl;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FuelTab")]
	internal virtual TabPage FuelTab { get; set; }

	[field: AccessedThroughProperty("AmmunitionTab")]
	internal virtual TabPage AmmunitionTab { get; set; }

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
			EventHandler eventHandler = method_9;
			EventHandler eventHandler2 = method_22;
			DarkDataGridView darkDataGridView = _DBGrid;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).Sorted -= eventHandler2;
			}
			_DBGrid = value;
			darkDataGridView = _DBGrid;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).Sorted += eventHandler2;
			}
		}
	}

	internal virtual DarkUIButton AddButton
	{
		[CompilerGenerated]
		get
		{
			return _AddButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _AddButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_AddButton = value;
			darkUIButton = _AddButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("AddCounter")]
	internal virtual DarkNumericUpDown AddCounter { get; set; }

	[field: AccessedThroughProperty("UserDefinedTab")]
	internal virtual TabPage UserDefinedTab { get; set; }

	[field: AccessedThroughProperty("LabelFuelMassUnits")]
	internal virtual DarkLabel LabelFuelMassUnits { get; set; }

	internal virtual TrackBar FuelTrackBar
	{
		[CompilerGenerated]
		get
		{
			return _FuelTrackBar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			TrackBar val = _FuelTrackBar;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_FuelTrackBar = value;
			val = _FuelTrackBar;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_FuelSlider")]
	internal virtual DarkLabel Label_FuelSlider { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUIComboBox FuelTypeComboBox
	{
		[CompilerGenerated]
		get
		{
			return _FuelTypeComboBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIComboBox darkUIComboBox = _FuelTypeComboBox;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_FuelTypeComboBox = value;
			darkUIComboBox = _FuelTypeComboBox;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("UserContentNameTextBox")]
	internal virtual DarkUITextBox UserContentNameTextBox { get; set; }

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7 { get; set; }

	[field: AccessedThroughProperty("FuelVolumeMaxLabel")]
	internal virtual DarkLabel FuelVolumeMaxLabel { get; set; }

	[field: AccessedThroughProperty("FuelVolumeMinLabel")]
	internal virtual DarkLabel FuelVolumeMinLabel { get; set; }

	internal virtual DarkUITextBox UserContentLengthTextbox
	{
		[CompilerGenerated]
		get
		{
			return _UserContentLengthTextbox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUITextBox darkUITextBox = _UserContentLengthTextbox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).LostFocus -= eventHandler;
			}
			_UserContentLengthTextbox = value;
			darkUITextBox = _UserContentLengthTextbox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).LostFocus += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("UserContentCargoSizeLabel")]
	internal virtual DarkLabel UserContentCargoSizeLabel { get; set; }

	[field: AccessedThroughProperty("DarkLabel9")]
	internal virtual DarkLabel DarkLabel9 { get; set; }

	[field: AccessedThroughProperty("DarkLabel8")]
	internal virtual DarkLabel DarkLabel8 { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	[field: AccessedThroughProperty("UserContentMassTextbox")]
	internal virtual DarkUITextBox UserContentMassTextbox { get; set; }

	internal virtual DarkUITextBox UserContentHeightTextBox
	{
		[CompilerGenerated]
		get
		{
			return _UserContentHeightTextBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUITextBox darkUITextBox = _UserContentHeightTextBox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).LostFocus -= eventHandler;
			}
			_UserContentHeightTextBox = value;
			darkUITextBox = _UserContentHeightTextBox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).LostFocus += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox UserContentWidthTextBox
	{
		[CompilerGenerated]
		get
		{
			return _UserContentWidthTextBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUITextBox darkUITextBox = _UserContentWidthTextBox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).LostFocus -= eventHandler;
			}
			_UserContentWidthTextBox = value;
			darkUITextBox = _UserContentWidthTextBox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).LostFocus += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelCustomMassUnits")]
	internal virtual DarkLabel LabelCustomMassUnits { get; set; }

	[field: AccessedThroughProperty("LabelCustomAreaUnits")]
	internal virtual DarkLabel LabelCustomAreaUnits { get; set; }

	[field: AccessedThroughProperty("FuelWarningLabel")]
	internal virtual DarkLabel FuelWarningLabel { get; set; }

	[field: AccessedThroughProperty("FuelMassLabel")]
	internal virtual DarkLabel FuelMassLabel { get; set; }

	[field: AccessedThroughProperty("FuelVolumeLabel")]
	internal virtual DarkLabel FuelVolumeLabel { get; set; }

	[field: AccessedThroughProperty("LabelFuelVolumeUnits")]
	internal virtual DarkLabel LabelFuelVolumeUnits { get; set; }

	[field: AccessedThroughProperty("UnitsTab")]
	internal virtual TabPage UnitsTab { get; set; }

	[field: AccessedThroughProperty("UnitsGridView")]
	internal virtual DarkDataGridView UnitsGridView { get; set; }

	[field: AccessedThroughProperty("HostColName")]
	internal virtual DataGridViewTextBoxColumn HostColName { get; set; }

	[field: AccessedThroughProperty("HostColSize")]
	internal virtual DataGridViewTextBoxColumn HostColSize { get; set; }

	[field: AccessedThroughProperty("HostColMass")]
	internal virtual DataGridViewTextBoxColumn HostColMass { get; set; }

	[field: AccessedThroughProperty("HostColArea")]
	internal virtual DataGridViewTextBoxColumn HostColArea { get; set; }

	[field: AccessedThroughProperty("HostColCrew")]
	internal virtual DataGridViewTextBoxColumn HostColCrew { get; set; }

	public EditCargoContainer()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += EditCargoContainer_Load;
		((Form)this).Shown += EditCargoContainer_Shown;
		((Form)this).FormClosing += new FormClosingEventHandler(EditCargoContainer_FormClosing);
		cargoContainerContent_0 = new CargoContainerContent();
		bool_2 = false;
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
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Expected O, but got Unknown
		//IL_095d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Expected O, but got Unknown
		//IL_0be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c74: Expected O, but got Unknown
		//IL_0d8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1000: Expected O, but got Unknown
		//IL_107c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1086: Expected O, but got Unknown
		//IL_12c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_186e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1878: Expected O, but got Unknown
		//IL_1a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2600: Unknown result type (might be due to invalid IL or missing references)
		//IL_26de: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e8: Expected O, but got Unknown
		//IL_27ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_27b6: Expected O, but got Unknown
		//IL_2a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b14: Expected O, but got Unknown
		//IL_2b54: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		TableLayoutPanel1 = new TableLayoutPanel();
		DarkSectionPanel1 = new DarkSectionPanel();
		CrewBar = new DarkUIProgressBar();
		AreaBar = new DarkUIProgressBar();
		MassBar = new DarkUIProgressBar();
		SizeLabel = new DarkLabel();
		InventoryGridView = new DarkDataGridView();
		InvColName = new DataGridViewTextBoxColumn();
		InvColMass = new DataGridViewTextBoxColumn();
		InvColArea = new DataGridViewTextBoxColumn();
		InvColCrew = new DataGridViewTextBoxColumn();
		RemoveButton = new DarkUIButton();
		RemoveCounter = new DarkNumericUpDown();
		DarkSectionPanel2 = new DarkSectionPanel();
		ContentsSourceTabControl = new DarkUITabControl();
		AmmunitionTab = new TabPage();
		DBGrid = new DarkDataGridView();
		FuelTab = new TabPage();
		FuelVolumeLabel = new DarkLabel();
		LabelFuelVolumeUnits = new DarkLabel();
		FuelWarningLabel = new DarkLabel();
		FuelMassLabel = new DarkLabel();
		FuelVolumeMaxLabel = new DarkLabel();
		FuelVolumeMinLabel = new DarkLabel();
		LabelFuelMassUnits = new DarkLabel();
		FuelTrackBar = new TrackBar();
		Label_FuelSlider = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		FuelTypeComboBox = new DarkUIComboBox();
		UserDefinedTab = new TabPage();
		LabelCustomAreaUnits = new DarkLabel();
		LabelCustomMassUnits = new DarkLabel();
		UserContentMassTextbox = new DarkUITextBox();
		UserContentHeightTextBox = new DarkUITextBox();
		UserContentWidthTextBox = new DarkUITextBox();
		UserContentLengthTextbox = new DarkUITextBox();
		UserContentCargoSizeLabel = new DarkLabel();
		DarkLabel9 = new DarkLabel();
		DarkLabel8 = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		UserContentNameTextBox = new DarkUITextBox();
		DarkLabel6 = new DarkLabel();
		DarkLabel7 = new DarkLabel();
		UnitsTab = new TabPage();
		UnitsGridView = new DarkDataGridView();
		HostColName = new DataGridViewTextBoxColumn();
		HostColSize = new DataGridViewTextBoxColumn();
		HostColMass = new DataGridViewTextBoxColumn();
		HostColArea = new DataGridViewTextBoxColumn();
		HostColCrew = new DataGridViewTextBoxColumn();
		AddButton = new DarkUIButton();
		AddCounter = new DarkNumericUpDown();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)DarkSectionPanel1).SuspendLayout();
		((ISupportInitialize)(object)InventoryGridView).BeginInit();
		((ISupportInitialize)RemoveCounter).BeginInit();
		((Control)DarkSectionPanel2).SuspendLayout();
		((Control)ContentsSourceTabControl).SuspendLayout();
		((Control)AmmunitionTab).SuspendLayout();
		((ISupportInitialize)(object)DBGrid).BeginInit();
		((Control)FuelTab).SuspendLayout();
		((ISupportInitialize)FuelTrackBar).BeginInit();
		((Control)UserDefinedTab).SuspendLayout();
		((Control)UnitsTab).SuspendLayout();
		((ISupportInitialize)(object)UnitsGridView).BeginInit();
		((ISupportInitialize)AddCounter).BeginInit();
		((Control)this).SuspendLayout();
		((Control)TableLayoutPanel1).Anchor = (AnchorStyles)15;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 306f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 700f));
		TableLayoutPanel1.Controls.Add((Control)(object)DarkSectionPanel1, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)DarkSectionPanel2, 1, 0);
		((Control)TableLayoutPanel1).Location = new Point(0, 0);
		((Control)TableLayoutPanel1).Margin = new Padding(0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)TableLayoutPanel1).Size = new Size(1008, 464);
		((Control)TableLayoutPanel1).TabIndex = 9;
		((Control)DarkSectionPanel1).Anchor = (AnchorStyles)15;
		((Control)DarkSectionPanel1).Controls.Add((Control)(object)CrewBar);
		((Control)DarkSectionPanel1).Controls.Add((Control)(object)AreaBar);
		((Control)DarkSectionPanel1).Controls.Add((Control)(object)MassBar);
		((Control)DarkSectionPanel1).Controls.Add((Control)(object)SizeLabel);
		((Control)DarkSectionPanel1).Controls.Add((Control)(object)InventoryGridView);
		((Control)DarkSectionPanel1).Controls.Add((Control)(object)RemoveButton);
		((Control)DarkSectionPanel1).Controls.Add((Control)(object)RemoveCounter);
		((Control)DarkSectionPanel1).Location = new Point(0, 0);
		((Control)DarkSectionPanel1).Margin = new Padding(0);
		((Control)DarkSectionPanel1).Name = "DarkSectionPanel1";
		DarkSectionPanel1.SectionHeader = "Current Contents:";
		((Control)DarkSectionPanel1).Size = new Size(306, 464);
		((Control)DarkSectionPanel1).TabIndex = 0;
		((Control)CrewBar).Anchor = (AnchorStyles)14;
		((Control)CrewBar).BackColor = Color.Transparent;
		CrewBar.CustomForeColor = Color.Transparent;
		((Control)CrewBar).Location = new Point(8, 412);
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
		((Control)AreaBar).Location = new Point(8, 389);
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
		((Control)MassBar).Location = new Point(8, 366);
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
		((Control)SizeLabel).Location = new Point(8, 343);
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
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)InventoryGridView).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)InventoryGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)InventoryGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)InvColName,
			(DataGridViewColumn)InvColMass,
			(DataGridViewColumn)InvColArea,
			(DataGridViewColumn)InvColCrew
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)InventoryGridView).DefaultCellStyle = val2;
		((DataGridView)InventoryGridView).EnableHeadersVisualStyles = false;
		((Control)InventoryGridView).Location = new Point(0, 28);
		((Control)InventoryGridView).Name = "InventoryGridView";
		((DataGridView)InventoryGridView).ReadOnly = true;
		((DataGridView)InventoryGridView).RowHeadersVisible = false;
		((DataGridView)InventoryGridView).RowHeadersWidth = 51;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)InventoryGridView).RowsDefaultCellStyle = val3;
		((DataGridView)InventoryGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)InventoryGridView).Size = new Size(306, 307);
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
		((DataGridViewColumn)InvColCrew).Width = 36;
		((Control)RemoveButton).Anchor = (AnchorStyles)6;
		((ButtonBase)RemoveButton).BackColor = Color.Transparent;
		((Control)RemoveButton).ForeColor = SystemColors.Control;
		((Control)RemoveButton).Location = new Point(82, 438);
		((Control)RemoveButton).Name = "RemoveButton";
		((Control)RemoveButton).Padding = new Padding(5);
		RemoveButton.RoundRadius = 0;
		((Control)RemoveButton).Size = new Size(124, 23);
		((Control)RemoveButton).TabIndex = 2;
		RemoveButton.Text = "Remove Selected";
		((Control)RemoveCounter).Anchor = (AnchorStyles)6;
		((UpDownBase)RemoveCounter).BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)RemoveCounter).BorderStyle = (BorderStyle)0;
		((Control)RemoveCounter).Font = new Font("Segoe UI", 12f);
		((UpDownBase)RemoveCounter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RemoveCounter).Location = new Point(24, 436);
		((NumericUpDown)RemoveCounter).Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		((NumericUpDown)RemoveCounter).Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)RemoveCounter).Name = "RemoveCounter";
		((Control)RemoveCounter).Size = new Size(54, 30);
		((Control)RemoveCounter).TabIndex = 3;
		((NumericUpDown)RemoveCounter).Value = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)DarkSectionPanel2).Controls.Add((Control)(object)ContentsSourceTabControl);
		((Control)DarkSectionPanel2).Controls.Add((Control)(object)AddButton);
		((Control)DarkSectionPanel2).Controls.Add((Control)(object)AddCounter);
		((Control)DarkSectionPanel2).Location = new Point(306, 0);
		((Control)DarkSectionPanel2).Margin = new Padding(0);
		((Control)DarkSectionPanel2).Name = "DarkSectionPanel2";
		DarkSectionPanel2.SectionHeader = "Available Contents:";
		((Control)DarkSectionPanel2).Size = new Size(702, 464);
		((Control)DarkSectionPanel2).TabIndex = 1;
		((Control)ContentsSourceTabControl).Anchor = (AnchorStyles)15;
		((Control)ContentsSourceTabControl).Controls.Add((Control)(object)AmmunitionTab);
		((Control)ContentsSourceTabControl).Controls.Add((Control)(object)FuelTab);
		((Control)ContentsSourceTabControl).Controls.Add((Control)(object)UserDefinedTab);
		((Control)ContentsSourceTabControl).Controls.Add((Control)(object)UnitsTab);
		((Control)ContentsSourceTabControl).Cursor = Cursors.Hand;
		((TabControl)ContentsSourceTabControl).ItemSize = new Size(80, 20);
		((Control)ContentsSourceTabControl).Location = new Point(4, 28);
		((Control)ContentsSourceTabControl).Name = "ContentsSourceTabControl";
		((TabControl)ContentsSourceTabControl).SelectedIndex = 0;
		((Control)ContentsSourceTabControl).Size = new Size(660, 401);
		((Control)ContentsSourceTabControl).TabIndex = 4;
		AmmunitionTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)AmmunitionTab).Controls.Add((Control)(object)DBGrid);
		AmmunitionTab.Location = new Point(4, 24);
		((Control)AmmunitionTab).Name = "AmmunitionTab";
		((Control)AmmunitionTab).Padding = new Padding(3);
		((Control)AmmunitionTab).Size = new Size(652, 373);
		AmmunitionTab.TabIndex = 0;
		AmmunitionTab.Text = "Munitions";
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
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DBGrid).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)DBGrid).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f);
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
		((Control)DBGrid).Size = new Size(654, 375);
		((Control)DBGrid).TabIndex = 0;
		FuelTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)FuelTab).Controls.Add((Control)(object)FuelVolumeLabel);
		((Control)FuelTab).Controls.Add((Control)(object)LabelFuelVolumeUnits);
		((Control)FuelTab).Controls.Add((Control)(object)FuelWarningLabel);
		((Control)FuelTab).Controls.Add((Control)(object)FuelMassLabel);
		((Control)FuelTab).Controls.Add((Control)(object)FuelVolumeMaxLabel);
		((Control)FuelTab).Controls.Add((Control)(object)FuelVolumeMinLabel);
		((Control)FuelTab).Controls.Add((Control)(object)LabelFuelMassUnits);
		((Control)FuelTab).Controls.Add((Control)(object)FuelTrackBar);
		((Control)FuelTab).Controls.Add((Control)(object)Label_FuelSlider);
		((Control)FuelTab).Controls.Add((Control)(object)DarkLabel1);
		((Control)FuelTab).Controls.Add((Control)(object)FuelTypeComboBox);
		FuelTab.Location = new Point(4, 24);
		((Control)FuelTab).Name = "FuelTab";
		((Control)FuelTab).Padding = new Padding(3);
		((Control)FuelTab).Size = new Size(652, 373);
		FuelTab.TabIndex = 1;
		FuelTab.Text = "Fuel";
		((Control)FuelVolumeLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FuelVolumeLabel).Location = new Point(133, 116);
		((Control)FuelVolumeLabel).Name = "FuelVolumeLabel";
		((Control)FuelVolumeLabel).Size = new Size(89, 15);
		((Control)FuelVolumeLabel).TabIndex = 13;
		((Label)FuelVolumeLabel).Text = "0";
		((Label)FuelVolumeLabel).TextAlign = (ContentAlignment)64;
		LabelFuelVolumeUnits.AutoSize = true;
		((Control)LabelFuelVolumeUnits).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelFuelVolumeUnits).Location = new Point(228, 116);
		((Control)LabelFuelVolumeUnits).Name = "LabelFuelVolumeUnits";
		((Control)LabelFuelVolumeUnits).Size = new Size(41, 20);
		((Control)LabelFuelVolumeUnits).TabIndex = 12;
		((Label)LabelFuelVolumeUnits).Text = "liters";
		((Control)FuelWarningLabel).ForeColor = Color.Red;
		((Control)FuelWarningLabel).Location = new Point(101, 161);
		((Control)FuelWarningLabel).Name = "FuelWarningLabel";
		((Control)FuelWarningLabel).Size = new Size(327, 22);
		((Control)FuelWarningLabel).TabIndex = 11;
		((Label)FuelWarningLabel).TextAlign = (ContentAlignment)32;
		((Control)FuelMassLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FuelMassLabel).Location = new Point(133, 141);
		((Control)FuelMassLabel).Name = "FuelMassLabel";
		((Control)FuelMassLabel).Size = new Size(89, 15);
		((Control)FuelMassLabel).TabIndex = 10;
		((Label)FuelMassLabel).Text = "0";
		((Label)FuelMassLabel).TextAlign = (ContentAlignment)64;
		((Control)FuelVolumeMaxLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FuelVolumeMaxLabel).Location = new Point(192, 98);
		((Control)FuelVolumeMaxLabel).Name = "FuelVolumeMaxLabel";
		((Control)FuelVolumeMaxLabel).Size = new Size(200, 15);
		((Control)FuelVolumeMaxLabel).TabIndex = 9;
		((Label)FuelVolumeMaxLabel).Text = "20000";
		((Label)FuelVolumeMaxLabel).TextAlign = (ContentAlignment)32;
		FuelVolumeMinLabel.AutoSize = true;
		((Control)FuelVolumeMinLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FuelVolumeMinLabel).Location = new Point(101, 98);
		((Control)FuelVolumeMinLabel).Name = "FuelVolumeMinLabel";
		((Control)FuelVolumeMinLabel).Size = new Size(17, 20);
		((Control)FuelVolumeMinLabel).TabIndex = 8;
		((Label)FuelVolumeMinLabel).Text = "0";
		((Label)FuelVolumeMinLabel).TextAlign = (ContentAlignment)32;
		LabelFuelMassUnits.AutoSize = true;
		((Control)LabelFuelMassUnits).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelFuelMassUnits).Location = new Point(228, 141);
		((Control)LabelFuelMassUnits).Name = "LabelFuelMassUnits";
		((Control)LabelFuelMassUnits).Size = new Size(74, 20);
		((Control)LabelFuelMassUnits).TabIndex = 5;
		((Label)LabelFuelMassUnits).Text = "kilograms";
		FuelTrackBar.LargeChange = 1000;
		((Control)FuelTrackBar).Location = new Point(95, 68);
		FuelTrackBar.Maximum = 20000;
		((Control)FuelTrackBar).Name = "FuelTrackBar";
		((Control)FuelTrackBar).Size = new Size(209, 56);
		FuelTrackBar.SmallChange = 500;
		((Control)FuelTrackBar).TabIndex = 3;
		FuelTrackBar.TickFrequency = 1000;
		Label_FuelSlider.AutoSize = true;
		((Control)Label_FuelSlider).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_FuelSlider).Location = new Point(20, 71);
		((Control)Label_FuelSlider).Name = "Label_FuelSlider";
		((Control)Label_FuelSlider).Size = new Size(78, 20);
		((Control)Label_FuelSlider).TabIndex = 2;
		((Label)Label_FuelSlider).Text = "Fuel Liters:";
		((Label)Label_FuelSlider).TextAlign = (ContentAlignment)64;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(24, 22);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(74, 20);
		((Control)DarkLabel1).TabIndex = 1;
		((Label)DarkLabel1).Text = "Fuel Type:";
		((Label)DarkLabel1).TextAlign = (ContentAlignment)64;
		((ComboBox)FuelTypeComboBox).BackColor = Color.Transparent;
		((ComboBox)FuelTypeComboBox).DrawMode = (DrawMode)1;
		((ComboBox)FuelTypeComboBox).DropDownStyle = (ComboBoxStyle)2;
		((Control)FuelTypeComboBox).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)FuelTypeComboBox).FormattingEnabled = true;
		((Control)FuelTypeComboBox).Location = new Point(95, 19);
		((Control)FuelTypeComboBox).Name = "FuelTypeComboBox";
		((Control)FuelTypeComboBox).Size = new Size(209, 24);
		((Control)FuelTypeComboBox).TabIndex = 0;
		UserDefinedTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)UserDefinedTab).Controls.Add((Control)(object)LabelCustomAreaUnits);
		((Control)UserDefinedTab).Controls.Add((Control)(object)LabelCustomMassUnits);
		((Control)UserDefinedTab).Controls.Add((Control)(object)UserContentMassTextbox);
		((Control)UserDefinedTab).Controls.Add((Control)(object)UserContentHeightTextBox);
		((Control)UserDefinedTab).Controls.Add((Control)(object)UserContentWidthTextBox);
		((Control)UserDefinedTab).Controls.Add((Control)(object)UserContentLengthTextbox);
		((Control)UserDefinedTab).Controls.Add((Control)(object)UserContentCargoSizeLabel);
		((Control)UserDefinedTab).Controls.Add((Control)(object)DarkLabel9);
		((Control)UserDefinedTab).Controls.Add((Control)(object)DarkLabel8);
		((Control)UserDefinedTab).Controls.Add((Control)(object)DarkLabel5);
		((Control)UserDefinedTab).Controls.Add((Control)(object)DarkLabel3);
		((Control)UserDefinedTab).Controls.Add((Control)(object)UserContentNameTextBox);
		((Control)UserDefinedTab).Controls.Add((Control)(object)DarkLabel6);
		((Control)UserDefinedTab).Controls.Add((Control)(object)DarkLabel7);
		UserDefinedTab.Location = new Point(4, 24);
		((Control)UserDefinedTab).Name = "UserDefinedTab";
		((Control)UserDefinedTab).Padding = new Padding(3);
		((Control)UserDefinedTab).Size = new Size(652, 373);
		UserDefinedTab.TabIndex = 2;
		UserDefinedTab.Text = "User Defined";
		LabelCustomAreaUnits.AutoSize = true;
		((Control)LabelCustomAreaUnits).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelCustomAreaUnits).Location = new Point(347, 72);
		((Control)LabelCustomAreaUnits).Name = "LabelCustomAreaUnits";
		((Control)LabelCustomAreaUnits).Size = new Size(54, 20);
		((Control)LabelCustomAreaUnits).TabIndex = 24;
		((Label)LabelCustomAreaUnits).Text = "meters";
		((Label)LabelCustomAreaUnits).TextAlign = (ContentAlignment)16;
		LabelCustomMassUnits.AutoSize = true;
		((Control)LabelCustomMassUnits).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelCustomMassUnits).Location = new Point(161, 140);
		((Control)LabelCustomMassUnits).Name = "LabelCustomMassUnits";
		((Control)LabelCustomMassUnits).Size = new Size(74, 20);
		((Control)LabelCustomMassUnits).TabIndex = 25;
		((Label)LabelCustomMassUnits).Text = "kilograms";
		((Label)LabelCustomMassUnits).TextAlign = (ContentAlignment)16;
		UserContentMassTextbox.AutoCompleteCustomSource = null;
		UserContentMassTextbox.AutoCompleteMode = (AutoCompleteMode)0;
		UserContentMassTextbox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)UserContentMassTextbox).BackColor = Color.Transparent;
		((Control)UserContentMassTextbox).ForeColor = Color.FromArgb(189, 189, 189);
		UserContentMassTextbox.Image = null;
		UserContentMassTextbox.Lines = null;
		((Control)UserContentMassTextbox).Location = new Point(112, 137);
		UserContentMassTextbox.MaxLength = 32767;
		UserContentMassTextbox.Multiline = false;
		((Control)UserContentMassTextbox).Name = "UserContentMassTextbox";
		UserContentMassTextbox.ReadOnly = false;
		UserContentMassTextbox.ScrollBars = (ScrollBars)0;
		UserContentMassTextbox.SelectionStart = 0;
		((Control)UserContentMassTextbox).Size = new Size(47, 18);
		((Control)UserContentMassTextbox).TabIndex = 17;
		UserContentMassTextbox.Text = "1";
		UserContentMassTextbox.TextAlign = (HorizontalAlignment)0;
		UserContentMassTextbox.UseSystemPasswordChar = false;
		UserContentMassTextbox.WatermarkText = "";
		UserContentMassTextbox.WordWrap = false;
		UserContentHeightTextBox.AutoCompleteCustomSource = null;
		UserContentHeightTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		UserContentHeightTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)UserContentHeightTextBox).BackColor = Color.Transparent;
		((Control)UserContentHeightTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		UserContentHeightTextBox.Image = null;
		UserContentHeightTextBox.Lines = null;
		((Control)UserContentHeightTextBox).Location = new Point(312, 70);
		UserContentHeightTextBox.MaxLength = 32767;
		UserContentHeightTextBox.Multiline = false;
		((Control)UserContentHeightTextBox).Name = "UserContentHeightTextBox";
		UserContentHeightTextBox.ReadOnly = false;
		UserContentHeightTextBox.ScrollBars = (ScrollBars)0;
		UserContentHeightTextBox.SelectionStart = 0;
		((Control)UserContentHeightTextBox).Size = new Size(34, 18);
		((Control)UserContentHeightTextBox).TabIndex = 16;
		UserContentHeightTextBox.Text = "1";
		UserContentHeightTextBox.TextAlign = (HorizontalAlignment)0;
		UserContentHeightTextBox.UseSystemPasswordChar = false;
		UserContentHeightTextBox.WatermarkText = "";
		UserContentHeightTextBox.WordWrap = false;
		UserContentWidthTextBox.AutoCompleteCustomSource = null;
		UserContentWidthTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		UserContentWidthTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)UserContentWidthTextBox).BackColor = Color.Transparent;
		((Control)UserContentWidthTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		UserContentWidthTextBox.Image = null;
		UserContentWidthTextBox.Lines = null;
		((Control)UserContentWidthTextBox).Location = new Point(207, 70);
		UserContentWidthTextBox.MaxLength = 32767;
		UserContentWidthTextBox.Multiline = false;
		((Control)UserContentWidthTextBox).Name = "UserContentWidthTextBox";
		UserContentWidthTextBox.ReadOnly = false;
		UserContentWidthTextBox.ScrollBars = (ScrollBars)0;
		UserContentWidthTextBox.SelectionStart = 0;
		((Control)UserContentWidthTextBox).Size = new Size(34, 18);
		((Control)UserContentWidthTextBox).TabIndex = 15;
		UserContentWidthTextBox.Text = "1";
		UserContentWidthTextBox.TextAlign = (HorizontalAlignment)0;
		UserContentWidthTextBox.UseSystemPasswordChar = false;
		UserContentWidthTextBox.WatermarkText = "";
		UserContentWidthTextBox.WordWrap = false;
		UserContentLengthTextbox.AutoCompleteCustomSource = null;
		UserContentLengthTextbox.AutoCompleteMode = (AutoCompleteMode)0;
		UserContentLengthTextbox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)UserContentLengthTextbox).BackColor = Color.Transparent;
		((Control)UserContentLengthTextbox).ForeColor = Color.FromArgb(189, 189, 189);
		UserContentLengthTextbox.Image = null;
		UserContentLengthTextbox.Lines = null;
		((Control)UserContentLengthTextbox).Location = new Point(112, 70);
		UserContentLengthTextbox.MaxLength = 32767;
		UserContentLengthTextbox.Multiline = false;
		((Control)UserContentLengthTextbox).Name = "UserContentLengthTextbox";
		UserContentLengthTextbox.ReadOnly = false;
		UserContentLengthTextbox.ScrollBars = (ScrollBars)0;
		UserContentLengthTextbox.SelectionStart = 0;
		((Control)UserContentLengthTextbox).Size = new Size(34, 18);
		((Control)UserContentLengthTextbox).TabIndex = 14;
		UserContentLengthTextbox.Text = "1";
		UserContentLengthTextbox.TextAlign = (HorizontalAlignment)0;
		UserContentLengthTextbox.UseSystemPasswordChar = false;
		UserContentLengthTextbox.WatermarkText = "";
		UserContentLengthTextbox.WordWrap = false;
		UserContentCargoSizeLabel.AutoSize = true;
		((Control)UserContentCargoSizeLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)UserContentCargoSizeLabel).Location = new Point(110, 99);
		((Control)UserContentCargoSizeLabel).Name = "UserContentCargoSizeLabel";
		((Control)UserContentCargoSizeLabel).Size = new Size(45, 20);
		((Control)UserContentCargoSizeLabel).TabIndex = 23;
		((Label)UserContentCargoSizeLabel).Text = "None";
		((Label)UserContentCargoSizeLabel).TextAlign = (ContentAlignment)16;
		DarkLabel9.AutoSize = true;
		((Control)DarkLabel9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel9).Location = new Point(263, 72);
		((Control)DarkLabel9).Name = "DarkLabel9";
		((Control)DarkLabel9).Size = new Size(57, 20);
		((Control)DarkLabel9).TabIndex = 21;
		((Label)DarkLabel9).Text = "Height:";
		((Label)DarkLabel9).TextAlign = (ContentAlignment)64;
		DarkLabel8.AutoSize = true;
		((Control)DarkLabel8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel8).Location = new Point(162, 72);
		((Control)DarkLabel8).Name = "DarkLabel8";
		((Control)DarkLabel8).Size = new Size(52, 20);
		((Control)DarkLabel8).TabIndex = 20;
		((Label)DarkLabel8).Text = "Width:";
		((Label)DarkLabel8).TextAlign = (ContentAlignment)64;
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(62, 72);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(57, 20);
		((Control)DarkLabel5).TabIndex = 19;
		((Label)DarkLabel5).Text = "Length:";
		((Label)DarkLabel5).TextAlign = (ContentAlignment)64;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(44, 99);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(83, 20);
		((Control)DarkLabel3).TabIndex = 22;
		((Label)DarkLabel3).Text = "Cargo Size:";
		((Label)DarkLabel3).TextAlign = (ContentAlignment)64;
		UserContentNameTextBox.AutoCompleteCustomSource = null;
		UserContentNameTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		UserContentNameTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)UserContentNameTextBox).BackColor = Color.Transparent;
		((Control)UserContentNameTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		UserContentNameTextBox.Image = null;
		UserContentNameTextBox.Lines = null;
		((Control)UserContentNameTextBox).Location = new Point(112, 36);
		UserContentNameTextBox.MaxLength = 32767;
		UserContentNameTextBox.Multiline = false;
		((Control)UserContentNameTextBox).Name = "UserContentNameTextBox";
		UserContentNameTextBox.ReadOnly = false;
		UserContentNameTextBox.ScrollBars = (ScrollBars)0;
		UserContentNameTextBox.SelectionStart = 0;
		((Control)UserContentNameTextBox).Size = new Size(264, 18);
		((Control)UserContentNameTextBox).TabIndex = 13;
		UserContentNameTextBox.Text = "Generic Cargo";
		UserContentNameTextBox.TextAlign = (HorizontalAlignment)0;
		UserContentNameTextBox.UseSystemPasswordChar = false;
		UserContentNameTextBox.WatermarkText = "";
		UserContentNameTextBox.WordWrap = false;
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(73, 139);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(45, 20);
		((Control)DarkLabel6).TabIndex = 24;
		((Label)DarkLabel6).Text = "Mass:";
		((Label)DarkLabel6).TextAlign = (ContentAlignment)64;
		DarkLabel7.AutoSize = true;
		((Control)DarkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel7).Location = new Point(11, 36);
		((Control)DarkLabel7).Name = "DarkLabel7";
		((Control)DarkLabel7).Size = new Size(108, 20);
		((Control)DarkLabel7).TabIndex = 18;
		((Label)DarkLabel7).Text = "Content Name:";
		((Label)DarkLabel7).TextAlign = (ContentAlignment)64;
		UnitsTab.BackColor = Color.FromArgb(60, 63, 65);
		((Control)UnitsTab).Controls.Add((Control)(object)UnitsGridView);
		UnitsTab.Location = new Point(4, 24);
		((Control)UnitsTab).Name = "UnitsTab";
		((Control)UnitsTab).Padding = new Padding(3);
		((Control)UnitsTab).Size = new Size(652, 373);
		UnitsTab.TabIndex = 3;
		UnitsTab.Text = "Units";
		((DataGridView)UnitsGridView).AllowUserToAddRows = false;
		((DataGridView)UnitsGridView).AllowUserToDeleteRows = false;
		((DataGridView)UnitsGridView).AllowUserToOrderColumns = true;
		((Control)UnitsGridView).Anchor = (AnchorStyles)15;
		((DataGridView)UnitsGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)UnitsGridView).BorderStyle = (BorderStyle)0;
		((DataGridView)UnitsGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)UnitsGridView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)UnitsGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = Color.FromArgb(66, 77, 95);
		val7.Font = new Font("Segoe UI", 9f);
		val7.ForeColor = Color.LightGray;
		val7.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val7.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val7.WrapMode = (DataGridViewTriState)1;
		((DataGridView)UnitsGridView).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)UnitsGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)UnitsGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)HostColName,
			(DataGridViewColumn)HostColSize,
			(DataGridViewColumn)HostColMass,
			(DataGridViewColumn)HostColArea,
			(DataGridViewColumn)HostColCrew
		});
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = Color.FromArgb(60, 63, 65);
		val8.Font = new Font("Segoe UI", 9f);
		val8.ForeColor = Color.LightGray;
		val8.SelectionBackColor = SystemColors.Highlight;
		val8.SelectionForeColor = SystemColors.HighlightText;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)UnitsGridView).DefaultCellStyle = val8;
		((DataGridView)UnitsGridView).EnableHeadersVisualStyles = false;
		((Control)UnitsGridView).Location = new Point(0, 0);
		((Control)UnitsGridView).Name = "UnitsGridView";
		((DataGridView)UnitsGridView).ReadOnly = true;
		((DataGridView)UnitsGridView).RowHeadersVisible = false;
		((DataGridView)UnitsGridView).RowHeadersWidth = 51;
		val9.BackColor = Color.FromArgb(60, 63, 65);
		val9.ForeColor = Color.LightGray;
		val9.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val9.SelectionForeColor = Color.LightGray;
		((DataGridView)UnitsGridView).RowsDefaultCellStyle = val9;
		((DataGridView)UnitsGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)UnitsGridView).Size = new Size(648, 372);
		((Control)UnitsGridView).TabIndex = 24;
		((DataGridViewColumn)HostColName).HeaderText = "Name";
		((DataGridViewColumn)HostColName).MinimumWidth = 6;
		((DataGridViewColumn)HostColName).Name = "HostColName";
		((DataGridViewColumn)HostColName).ReadOnly = true;
		HostColName.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)HostColName).Width = 426;
		((DataGridViewColumn)HostColSize).HeaderText = "Size";
		((DataGridViewColumn)HostColSize).MinimumWidth = 6;
		((DataGridViewColumn)HostColSize).Name = "HostColSize";
		((DataGridViewColumn)HostColSize).ReadOnly = true;
		((DataGridViewColumn)HostColSize).Width = 64;
		((DataGridViewColumn)HostColMass).HeaderText = "Mass";
		((DataGridViewColumn)HostColMass).MinimumWidth = 6;
		((DataGridViewColumn)HostColMass).Name = "HostColMass";
		((DataGridViewColumn)HostColMass).ReadOnly = true;
		((DataGridViewColumn)HostColMass).Width = 50;
		((DataGridViewColumn)HostColArea).HeaderText = "Area";
		((DataGridViewColumn)HostColArea).MinimumWidth = 6;
		((DataGridViewColumn)HostColArea).Name = "HostColArea";
		((DataGridViewColumn)HostColArea).ReadOnly = true;
		((DataGridViewColumn)HostColArea).Width = 50;
		((DataGridViewColumn)HostColCrew).HeaderText = "PAX";
		((DataGridViewColumn)HostColCrew).MinimumWidth = 6;
		((DataGridViewColumn)HostColCrew).Name = "HostColCrew";
		((DataGridViewColumn)HostColCrew).ReadOnly = true;
		((DataGridViewColumn)HostColCrew).Width = 36;
		((Control)AddButton).Anchor = (AnchorStyles)6;
		((ButtonBase)AddButton).BackColor = Color.Transparent;
		((Control)AddButton).ForeColor = SystemColors.Control;
		((Control)AddButton).Location = new Point(312, 438);
		((Control)AddButton).Name = "AddButton";
		((Control)AddButton).Padding = new Padding(5);
		AddButton.RoundRadius = 0;
		((Control)AddButton).Size = new Size(124, 23);
		((Control)AddButton).TabIndex = 5;
		AddButton.Text = "Add Selected";
		((Control)AddCounter).Anchor = (AnchorStyles)6;
		((UpDownBase)AddCounter).BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)AddCounter).BorderStyle = (BorderStyle)0;
		((Control)AddCounter).Font = new Font("Segoe UI", 12f);
		((UpDownBase)AddCounter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)AddCounter).Location = new Point(253, 436);
		((Control)AddCounter).Margin = new Padding(0);
		((NumericUpDown)AddCounter).Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		((NumericUpDown)AddCounter).Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)AddCounter).Name = "AddCounter";
		((Control)AddCounter).Size = new Size(54, 30);
		((Control)AddCounter).TabIndex = 6;
		((NumericUpDown)AddCounter).Value = new decimal(new int[4] { 1, 0, 0, 0 });
		((ContainerControl)this).AutoScaleDimensions = new SizeF(8f, 20f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1054, 471);
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Control)this).Name = "EditCargoContainer";
		((Form)this).Text = "`";
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)DarkSectionPanel1).ResumeLayout(false);
		((ISupportInitialize)(object)InventoryGridView).EndInit();
		((ISupportInitialize)RemoveCounter).EndInit();
		((Control)DarkSectionPanel2).ResumeLayout(false);
		((Control)ContentsSourceTabControl).ResumeLayout(false);
		((Control)AmmunitionTab).ResumeLayout(false);
		((ISupportInitialize)(object)DBGrid).EndInit();
		((Control)FuelTab).ResumeLayout(false);
		((Control)FuelTab).PerformLayout();
		((ISupportInitialize)FuelTrackBar).EndInit();
		((Control)UserDefinedTab).ResumeLayout(false);
		((Control)UserDefinedTab).PerformLayout();
		((Control)UnitsTab).ResumeLayout(false);
		((ISupportInitialize)(object)UnitsGridView).EndInit();
		((ISupportInitialize)AddCounter).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public void UpdateDisplayedUnitsOfMeasure()
	{
		((Label)LabelFuelVolumeUnits).Text = Strings.StrConv(Cargo.CargoLiquidVolumeLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo), (VbStrConv)3, 0);
		((Label)LabelFuelMassUnits).Text = Strings.StrConv(Cargo.CargoSmallMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo), (VbStrConv)3, 0);
		((Label)LabelCustomAreaUnits).Text = Strings.StrConv(Cargo.CargoDistanceLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo), (VbStrConv)3, 0);
		((Label)LabelCustomMassUnits).Text = Strings.StrConv(Cargo.CargoSmallMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo), (VbStrConv)3, 0);
		((Label)Label_FuelSlider).Text = "Fuel " + Cargo.CargoLiquidVolumeLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		foreach (Keys val in array)
		{
			if (keyData == val)
			{
				int result;
				if (((Control)this).Visible)
				{
					((Form)this).Close();
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	private void EditCargoContainer_Load(object sender, EventArgs e)
	{
		((ComboBox)FuelTypeComboBox).Items.Clear();
		((ListControl)FuelTypeComboBox).DisplayMember = "Name";
		((ListControl)FuelTypeComboBox).ValueMember = "ID";
		((ComboBox)FuelTypeComboBox).Items.AddRange(new object[5]
		{
			new Class1("Aviation Fuel", 2001),
			new Class1("Diesel", 3001),
			new Class1("Oil Fuel", 3002),
			new Class1("Gas Fuel", 3003),
			new Class1("Gasoline", 3006)
		});
		((ComboBox)FuelTypeComboBox).SelectedIndex = 0;
	}

	private void EditCargoContainer_Shown(object sender, EventArgs e)
	{
		icargoHost_0 = SelectedContainer;
		((Form)this).Text = "Edit Contents for " + SelectedContainer.Name;
		if (SelectedContainer.ContainerType == CargoContainer.CargoContainerType.Tank)
		{
			FuelTab.Enabled = true;
			AmmunitionTab.Enabled = false;
			UserDefinedTab.Enabled = false;
			UnitsTab.Enabled = false;
			((TabControl)ContentsSourceTabControl).SelectedIndex = 1;
		}
		else
		{
			FuelTab.Enabled = false;
			AmmunitionTab.Enabled = true;
			UserDefinedTab.Enabled = true;
			UnitsTab.Enabled = true;
			if (((TabControl)ContentsSourceTabControl).SelectedIndex == 1)
			{
				((TabControl)ContentsSourceTabControl).SelectedIndex = 0;
			}
			if (((DataGridView)DBGrid).DataSource == null)
			{
				method_13(null, null);
			}
		}
		AddButton.Enabled = false;
		((Control)AddCounter).Visible = false;
		RemoveButton.Enabled = false;
		((Control)RemoveCounter).Visible = false;
		UpdateDisplayedUnitsOfMeasure();
		method_4();
		method_2();
		method_3();
		method_12();
		method_11();
		method_5();
		method_13(null, null);
	}

	private void EditCargoContainer_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (((Control)MyProject.Forms.EditCargoV2).Visible)
		{
			((Control)MyProject.Forms.EditCargoV2).Show();
		}
	}

	public void RefreshForm()
	{
		UpdateDisplayedUnitsOfMeasure();
		method_4();
		method_5();
		method_2();
		method_3();
		if (bool_2 != SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			method_13(null, null);
		}
		MyProject.Forms.MainForm.RightColumn1.AdjustToSelectionChange(Client.SelectedUnit, Client.SelectedUnit);
	}

	private void method_2()
	{
		float_0 = icargoHost_0.GetCargo_Mass();
		float_1 = icargoHost_0.GetCargo_Area();
		float_2 = icargoHost_0.GetCargo_Crew();
		float_3 = SelectedContainer.PayloadVolume;
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
		((Label)SizeLabel).Text = "Max Size: ";
		switch ((int)icargoHost_0.GetCargo_Type())
		{
		case 2000:
			((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c2000;
			break;
		case 1000:
			((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c1000;
			break;
		case 0:
			((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c0000;
			break;
		case 5000:
			((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c5000;
			break;
		case 4000:
			((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c4000;
			break;
		case 3000:
			((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c3000;
			break;
		}
		float cargo_Mass = icargoHost_0.GetCargo_Mass();
		float num = Cargo.DisplayValueMass(cargo_Mass - float_0, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		float num2 = Cargo.DisplayValueMass(cargo_Mass, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		((Control)MassBar).Text = "Mass: " + num.ToString("N") + " / " + num2.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (cargo_Mass == 0f)
		{
			MassBar.Value = 100;
		}
		else
		{
			MassBar.Value = (int)Math.Round(100f * ((cargo_Mass - float_0) / cargo_Mass));
		}
		if (float_0 == 0f)
		{
			((Control)MassBar).ForeColor = Color.LightGray;
			((Control)MassBar).Text = "[FULL] " + ((Control)MassBar).Text;
		}
		else
		{
			((Control)MassBar).ForeColor = Color.White;
		}
		cargo_Mass = icargoHost_0.GetCargo_Area();
		num = Cargo.DisplayValueArea(cargo_Mass - float_1, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		num2 = Cargo.DisplayValueArea(cargo_Mass, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		((Control)AreaBar).Text = "Area: " + num.ToString("N") + " / " + num2.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (cargo_Mass == 0f)
		{
			AreaBar.Value = 100;
		}
		else
		{
			AreaBar.Value = (int)Math.Round(100f * ((cargo_Mass - float_1) / cargo_Mass));
		}
		if (float_1 == 0f)
		{
			((Control)AreaBar).ForeColor = Color.LightGray;
			((Control)AreaBar).Text = "[FULL] " + ((Control)AreaBar).Text;
		}
		else
		{
			((Control)AreaBar).ForeColor = Color.White;
		}
		cargo_Mass = icargoHost_0.GetCargo_Crew();
		((Control)CrewBar).Text = "PAX: " + (cargo_Mass - float_2) + " / " + cargo_Mass.ToString("N0") + " Pers.";
		if (cargo_Mass == 0f)
		{
			CrewBar.Value = 100;
		}
		else
		{
			CrewBar.Value = (int)Math.Round(100f * ((cargo_Mass - float_2) / cargo_Mass));
		}
		if (float_2 == 0f)
		{
			((Control)CrewBar).ForeColor = Color.LightGray;
			((Control)CrewBar).Text = "[FULL] " + ((Control)CrewBar).Text;
		}
		else
		{
			((Control)CrewBar).ForeColor = Color.White;
		}
	}

	private void method_4()
	{
		int num = -1;
		if (((BaseCollection)((DataGridView)InventoryGridView).SelectedRows).Count > 0)
		{
			num = ((DataGridViewBand)((DataGridView)InventoryGridView).SelectedRows[0]).Index;
		}
		((DataGridView)InventoryGridView).Rows.Clear();
		if (SelectedContainer.CargoArray.Count() < 1)
		{
			return;
		}
		int num2 = 0;
		((DataGridView)InventoryGridView).Rows.Add(icargoHost_0.CargoArray.Count());
		Cargo[] cargoArray = icargoHost_0.CargoArray;
		foreach (Cargo cargo in cargoArray)
		{
			DataGridViewRow obj = ((DataGridView)InventoryGridView).Rows[num2];
			obj.Cells[0].Value = cargo.CargoObjectName;
			obj.Cells[1].Value = Cargo.DisplayValueMass(cargo.RequiredMass, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo).ToString("N");
			obj.Cells[2].Value = Cargo.DisplayValueArea(cargo.RequiredArea, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo).ToString("N");
			obj.Cells[3].Value = cargo.RequiredCrewSpace.ToString();
			((DataGridViewBand)obj).Tag = cargo;
			num2++;
		}
		if (((DataGridView)InventoryGridView).Rows.Count > 0 && num > -1)
		{
			((DataGridView)InventoryGridView).ClearSelection();
			if (num >= ((DataGridView)InventoryGridView).Rows.Count)
			{
				num = ((DataGridView)InventoryGridView).Rows.Count - 1;
			}
			((DataGridView)InventoryGridView).Rows[num].Selected = true;
		}
		((Control)InventoryGridView).Refresh();
		method_10(null, null);
	}

	private void method_5()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<Cargo> list2 = new List<Cargo>();
		if (SelectedActiveUnit != null)
		{
			ActiveUnit selectedActiveUnit = SelectedActiveUnit;
			Cargo[] onboardCargo = selectedActiveUnit.OnboardCargo;
			foreach (Cargo cargo in onboardCargo)
			{
				if (cargo.CargoObjectActiveUnit != null)
				{
					list2.Add(cargo);
				}
			}
			list.AddRange(EditCargoV2.GetActiveUnitsThatCanBeMovedIntoCargo(selectedActiveUnit));
			foreach (ActiveUnit item2 in list)
			{
				Cargo item = new Cargo(null, item2);
				list2.Add(item);
			}
		}
		CargoUICommon.PopulateGridViewCargoInventory(UnitsGridView, null, list2);
		if (icargoHost_0 != null)
		{
			float availableMass = CargoHostHelper.GetAvailableMass(icargoHost_0, icargoHost_0.CargoArray);
			float availableArea = CargoHostHelper.GetAvailableArea(icargoHost_0, icargoHost_0.CargoArray);
			float availableCrewSpace = CargoHostHelper.GetAvailableCrewSpace(icargoHost_0, icargoHost_0.CargoArray);
			method_6(UnitsGridView, icargoHost_0, availableMass, availableArea, availableCrewSpace);
		}
	}

	private void method_6(DarkDataGridView darkDataGridView_0, ICargoHost icargoHost_1, float float_4, float float_5, float float_6)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		int num = 1;
		int num2 = 2;
		int num3 = 3;
		int num4 = 4;
		int num5 = 5000;
		if (icargoHost_1 != null)
		{
			num5 = (int)icargoHost_1.GetCargo_Type();
		}
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)darkDataGridView_0).Rows)
		{
			DataGridViewRow val = item;
			if (icargoHost_1 != null)
			{
				if (!(((DataGridViewBand)val).Tag is ActiveUnit) && (((DataGridViewBand)val).Tag is Cargo || ((DataGridViewBand)val).Tag is CargoManifestItem))
				{
					if (Conversions.ToInteger(val.Cells[num].Tag) <= num5 && !(Conversions.ToSingle(val.Cells[num2].Value) > float_4) && !(Conversions.ToSingle(val.Cells[num3].Value) > float_5) && Conversions.ToSingle(val.Cells[num4].Value) <= float_6)
					{
						val.DefaultCellStyle.ForeColor = ((DataGridView)darkDataGridView_0).DefaultCellStyle.ForeColor;
						val.DefaultCellStyle.SelectionForeColor = ((DataGridView)darkDataGridView_0).DefaultCellStyle.SelectionForeColor;
					}
					else
					{
						val.DefaultCellStyle.ForeColor = Color.Red;
						val.DefaultCellStyle.SelectionForeColor = Color.Red;
					}
				}
			}
			else
			{
				val.DefaultCellStyle.ForeColor = ((DataGridView)darkDataGridView_0).DefaultCellStyle.ForeColor;
				val.DefaultCellStyle.SelectionForeColor = ((DataGridView)darkDataGridView_0).DefaultCellStyle.SelectionForeColor;
			}
		}
	}

	private bool method_7(DataGridViewRow dataGridViewRow_0, int int_0, float float_4, float float_5, float float_6)
	{
		if (Cargo.InputValueMass(Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Mass"].Value), SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) > float_4)
		{
			return false;
		}
		if (Cargo.InputValueArea(Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Area"].Value), SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) > float_5)
		{
			return false;
		}
		if (Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Crew"].Value) > float_6)
		{
			return false;
		}
		return true;
	}

	private void method_8()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		int int_ = 1;
		if (((Control)AddCounter).Enabled)
		{
			int_ = Convert.ToInt32(((NumericUpDown)AddCounter).Value);
		}
		method_2();
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DBGrid).Rows)
		{
			DataGridViewRow val = item;
			if (!method_7(val, int_, float_0, float_1, float_2))
			{
				val.DefaultCellStyle.ForeColor = Color.Red;
				val.DefaultCellStyle.SelectionForeColor = Color.Red;
			}
			else
			{
				val.DefaultCellStyle.ForeColor = ((DataGridView)DBGrid).DefaultCellStyle.ForeColor;
				val.DefaultCellStyle.SelectionForeColor = ((DataGridView)DBGrid).DefaultCellStyle.SelectionForeColor;
			}
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		int int_ = 1;
		if (((Control)AddCounter).Visible)
		{
			int_ = Convert.ToInt32(((NumericUpDown)AddCounter).Value);
		}
		AddButton.Enabled = false;
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
			while (!method_7(dataGridViewRow_, int_, float_0, float_1, float_2));
			AddButton.Enabled = true;
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
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		RemoveButton.Enabled = false;
		((Control)RemoveCounter).Visible = false;
		IEnumerator enumerator = ((BaseCollection)((DataGridView)InventoryGridView).SelectedRows).GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataGridViewRow val = (DataGridViewRow)enumerator.Current;
				RemoveButton.Enabled = true;
				if (((DataGridViewBand)val).Tag != null && ((DataGridViewBand)val).Tag is CargoManifestItem)
				{
					((Control)RemoveCounter).Visible = true;
					((NumericUpDown)RemoveCounter).Maximum = new decimal(((CargoManifestItem)((DataGridViewBand)val).Tag).quantity);
				}
			}
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

	private void method_11()
	{
		if (SelectedContainer == null || SelectedContainer.ContainerType != CargoContainer.CargoContainerType.Tank)
		{
			return;
		}
		bool flag = false;
		int maximum = (int)Math.Round(Cargo.DisplayValueLiquidVolume(1000f * SelectedContainer.PayloadVolume, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo));
		((Label)FuelVolumeMinLabel).Text = "0";
		((Label)FuelVolumeMaxLabel).Text = maximum.ToString();
		FuelTrackBar.Maximum = maximum;
		if (SelectedContainer.OnboardCargo.Count() > 0)
		{
			CargoContainerContent cargoObjectContainerContents = SelectedContainer.OnboardCargo[0].CargoObjectContainerContents;
			if (cargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.LiquidFuel)
			{
				CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoObjectContainerContents;
				int num = ((ComboBox)FuelTypeComboBox).Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (((Class1)((ComboBox)FuelTypeComboBox).Items[i]).ID == (int)cargoLiquidFuel.FuelType)
					{
						((ComboBox)FuelTypeComboBox).SelectedIndex = i;
						break;
					}
				}
				FuelTrackBar.Value = (int)Math.Round(Cargo.DisplayValueLiquidVolume(cargoLiquidFuel.CurrentQuantity, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo));
				flag = true;
			}
		}
		if (!flag)
		{
			((ComboBox)FuelTypeComboBox).SelectedIndex = 0;
			FuelTrackBar.Value = 0;
			((Label)FuelVolumeLabel).Text = "0";
			((Label)FuelMassLabel).Text = "0";
		}
	}

	private void method_12()
	{
		if (SelectedContainer != null)
		{
			cargoContainerContent_0.Name = UserContentNameTextBox.Text;
			if (!float.TryParse(UserContentMassTextbox.Text, out cargoContainerContent_0.Mass))
			{
				cargoContainerContent_0.Mass = 1f;
				UserContentMassTextbox.Text = "1";
			}
			if (!float.TryParse(UserContentLengthTextbox.Text, out var result))
			{
				result = 1f;
				UserContentLengthTextbox.Text = "1";
			}
			if (!float.TryParse(UserContentWidthTextBox.Text, out var result2))
			{
				result2 = 1f;
				UserContentWidthTextBox.Text = "1";
			}
			if (!float.TryParse(UserContentHeightTextBox.Text, out var result3))
			{
				result3 = 1f;
				UserContentHeightTextBox.Text = "1";
			}
			if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
			{
				cargoContainerContent_0.Mass = Cargo.InputValueSmallMass(cargoContainerContent_0.Mass, USUnits: true);
				result = Cargo.InputValueDistance(result, USUnits: true);
				result2 = Cargo.InputValueDistance(result2, USUnits: true);
				result3 = Cargo.InputValueDistance(result3, USUnits: true);
			}
			cargoContainerContent_0.Mass /= 1000f;
			cargoContainerContent_0.Area = result * result2;
			cargoContainerContent_0.Volume = cargoContainerContent_0.Area * result3;
			cargoContainerContent_0.Size = DBFunctions.GetCargoTypeCategory(result, result2, result3);
			switch (cargoContainerContent_0.Size)
			{
			case CargoType.SmallCargo:
				((Label)UserContentCargoSizeLabel).Text = CargoUICommon.c2000;
				break;
			case CargoType.Personnel:
				((Label)UserContentCargoSizeLabel).Text = CargoUICommon.c1000;
				break;
			case CargoType.NoCargo:
				((Label)UserContentCargoSizeLabel).Text = CargoUICommon.c0000;
				break;
			case CargoType.const_5:
				((Label)UserContentCargoSizeLabel).Text = CargoUICommon.c5000;
				break;
			case CargoType.LargeCargo:
				((Label)UserContentCargoSizeLabel).Text = CargoUICommon.c4000;
				break;
			case CargoType.MediumCargo:
				((Label)UserContentCargoSizeLabel).Text = CargoUICommon.c3000;
				break;
			}
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		if (bool_2 != SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			((DataGridView)DBGrid).DataSource = null;
			bool_2 = SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo;
		}
		switch (((TabControl)ContentsSourceTabControl).SelectedIndex)
		{
		case 0:
			((Control)AddCounter).Visible = true;
			if (SelectedActiveUnit != null && ((DataGridView)DBGrid).DataSource == null)
			{
				DataTable dataTable = null;
				try
				{
					SQLiteConnection sqliteConnection_ = SelectedActiveUnit.ParentScen.DBConnection;
					dataTable = DBFunctions.GetAllCargoWeapons(ref sqliteConnection_);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					DarkMessageBox.ShowError("Unable to use currently loaded database for cargo related tasks. Please upgrade scenario to latest database.", "Error");
					((Form)this).Close();
					ProjectData.ClearProjectError();
					break;
				}
				DataTable dataTable2 = dataTable.Clone();
				dataTable2.Columns.Remove("Deprecated");
				dataTable2.Columns["Cargo_Type"].DataType = typeof(string);
				foreach (DataRow row in dataTable.Rows)
				{
					dataTable2.ImportRow(row);
				}
				icargoHost_0.GetCargo_Type();
				foreach (DataRow row2 in dataTable2.Rows)
				{
					int sizeValue = int.Parse(Conversions.ToString(row2["Cargo_Type"]));
					row2["Cargo_Type"] = CargoUICommon.GetSizeString(sizeValue);
				}
				((DataGridView)DBGrid).DataSource = new DataView(dataTable2);
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
			}
			method_8();
			((Control)DBGrid).Refresh();
			AddButton.Text = "Load Selected";
			break;
		case 1:
			method_11();
			AddButton.Text = "Set Fuel Content";
			AddButton.Enabled = true;
			break;
		case 2:
			method_12();
			AddButton.Enabled = true;
			((Control)AddCounter).Visible = true;
			AddButton.Text = "Load Selected";
			break;
		case 3:
			method_5();
			((Control)AddCounter).Visible = false;
			AddButton.Text = "Load Selected";
			AddButton.Enabled = true;
			break;
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		List<Cargo> list = new List<Cargo>();
		List<Cargo> list2 = new List<Cargo>();
		int num = 0;
		int num2 = 0;
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)InventoryGridView).SelectedRows)
		{
			DataGridViewRow val = item;
			if (!(((DataGridViewBand)val).Tag is CargoManifestItem))
			{
				Cargo cargo = (Cargo)((DataGridViewBand)val).Tag;
				Cargo.CargoObjectType currentType = cargo.CurrentType;
				if ((uint)(currentType - 4) <= 1u)
				{
					list2.Add(cargo);
				}
				else
				{
					list.Add(cargo);
				}
				continue;
			}
			CargoManifestItem cargoManifestItem = (CargoManifestItem)((DataGridViewBand)val).Tag;
			int num3;
			if (!((Control)RemoveCounter).Visible)
			{
				num = 1;
				num3 = 0;
			}
			else
			{
				num = Convert.ToInt32(((NumericUpDown)RemoveCounter).Value);
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
			for (num2 = num3; num2 < SelectedContainer.CargoArray.Count(); num2++)
			{
				if (num <= 0)
				{
					break;
				}
				if (SelectedContainer.CargoArray[num2].CurrentType == cargoManifestItem.objectType && SelectedContainer.CargoArray[num2].CargoObjectDBID == cargoManifestItem.DBID)
				{
					list2.Add(SelectedContainer.CargoArray[num2]);
					num--;
				}
			}
		}
		if (list.Count > 0)
		{
			List<Cargo> list3 = new List<Cargo>();
			foreach (Cargo item2 in list)
			{
				if (item2.CargoObjectActiveUnit != null)
				{
					ICargoHost cargoHost = (ICargoHost)SelectedActiveUnit;
					if (cargoHost != null && cargoHost.CanLoad(item2.GetCargoClient))
					{
						SelectedContainer.Remove(item2);
						cargoHost.Add(item2);
						continue;
					}
				}
				list3.Clear();
				string cargoObjectID = item2.CargoObjectID;
				if (SelectedActiveUnit.ParentScen.ActiveUnits.TryGetValue(cargoObjectID, out var value))
				{
					list3.Add(item2);
					double latitude_old = value.Latitude_old;
					double longitude_old = value.Longitude_old;
					ActiveUnit selectedActiveUnit = SelectedActiveUnit;
					CargoContainer selectedContainer;
					Cargo[] CargoList = (selectedContainer = SelectedContainer).CargoArray;
					Cargo.UnloadCargoAtLocation(selectedActiveUnit, ref CargoList, list3, latitude_old, longitude_old, SelectedActiveUnit.ParentScen, SelectedActiveUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false, ByUser: true);
					selectedContainer.CargoArray = CargoList;
				}
			}
		}
		if (list2.Count > 0)
		{
			foreach (Cargo item3 in list2)
			{
				SelectedContainer.Remove(item3);
			}
		}
		method_2();
		RefreshForm();
		if (((Control)MyProject.Forms.EditCargoV2).Visible)
		{
			MyProject.Forms.EditCargoV2.RefreshForm();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		new List<Cargo>();
		int num = 1;
		method_2();
		string text = AddButton.Text;
		AddButton.Enabled = false;
		AddButton.Text = "Working...";
		if (((Control)AddCounter).Visible)
		{
			num = Convert.ToInt32(((NumericUpDown)AddCounter).Value);
		}
		switch (((TabControl)ContentsSourceTabControl).SelectedIndex)
		{
		case 0:
			foreach (DataGridViewRow item in (BaseCollection)((DataGridView)DBGrid).SelectedRows)
			{
				int dbid = Conversions.ToInteger(item.Cells["ID"].Value);
				CargoAmmunition cargoAmmunition = new CargoAmmunition(dbid, num, SelectedActiveUnit.ParentScen);
				if (SelectedContainer.CanLoad(cargoAmmunition))
				{
					Cargo c2 = new Cargo(SelectedActiveUnit, cargoAmmunition, SelectedContainer);
					SelectedContainer.Add(c2);
					continue;
				}
				DarkMessageBox.ShowWarning("Unable to add " + cargoAmmunition.Name + " to this container - maximum capacity exceeded.", "Out of space!");
				break;
			}
			break;
		case 1:
		{
			CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel();
			float currentQuantity = Cargo.InputValueLiquidVolume(FuelTrackBar.Value, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			cargoLiquidFuel.FuelType = (FuelRec._FuelType)((Class1)((ComboBox)FuelTypeComboBox).SelectedItem).ID;
			cargoLiquidFuel.CurrentQuantity = currentQuantity;
			Cargo cargo2 = null;
			if (SelectedContainer.CargoArray.Count() > 0)
			{
				cargo2 = SelectedContainer.CargoArray[0];
				SelectedContainer.Remove(cargo2);
			}
			if (!SelectedContainer.CanLoad(cargoLiquidFuel))
			{
				DarkMessageBox.ShowWarning("Unable to add " + cargoLiquidFuel.Name + " to this container - check maximum capacity and current fuel type.", "Out of space!");
				if (cargo2 != null)
				{
					SelectedContainer.Add(cargo2);
				}
			}
			else if (cargoLiquidFuel.CurrentQuantity > 0f)
			{
				Cargo c3 = new Cargo(SelectedActiveUnit, cargoLiquidFuel, SelectedContainer);
				SelectedContainer.Add(c3);
			}
			break;
		}
		case 2:
		{
			method_12();
			int num2 = num;
			for (int i = 1; i <= num2; i++)
			{
				CargoContainerContent cargoContainerContent = new CargoContainerContent();
				cargoContainerContent.Name = cargoContainerContent_0.Name;
				cargoContainerContent.Mass = cargoContainerContent_0.Mass;
				cargoContainerContent.Area = cargoContainerContent_0.Area;
				cargoContainerContent.Volume = cargoContainerContent_0.Volume;
				cargoContainerContent.Size = cargoContainerContent_0.Size;
				if (SelectedContainer.CanLoad(cargoContainerContent))
				{
					Cargo c = new Cargo(SelectedActiveUnit, cargoContainerContent, SelectedContainer);
					SelectedContainer.Add(c);
					continue;
				}
				DarkMessageBox.ShowWarning("Unable to add all requested " + cargoContainerContent.Name + " to this container - maximum capacity exceeded.", "Out of space!");
				break;
			}
			break;
		}
		case 3:
			foreach (DataGridViewRow item2 in (BaseCollection)((DataGridView)UnitsGridView).SelectedRows)
			{
				DataGridViewRow val = item2;
				ActiveUnit activeUnit = null;
				Cargo cargo = null;
				if (((DataGridViewBand)val).Tag is Cargo)
				{
					activeUnit = ((Cargo)((DataGridViewBand)val).Tag).CargoObjectActiveUnit;
					cargo = (Cargo)((DataGridViewBand)val).Tag;
				}
				if (activeUnit != null && cargo != null)
				{
					ICargoClient potentialCargo = (ICargoClient)activeUnit;
					if (!SelectedContainer.CanLoad(potentialCargo))
					{
						DarkMessageBox.ShowWarning("Unable to add " + activeUnit.Name + " to this container - maximum capacity exceeded.", "Out of space!");
						break;
					}
					if (SelectedActiveUnit != null && SelectedActiveUnit.OnboardCargo.Contains(cargo))
					{
						((ICargoHost)SelectedActiveUnit).Remove(cargo);
					}
					else
					{
						activeUnit.DockingOps.LoadIntoCargo(SelectedActiveUnit);
					}
					SelectedContainer.Add(cargo);
				}
			}
			break;
		}
		AddButton.Text = text;
		AddButton.Enabled = true;
		method_2();
		RefreshForm();
		if (((Control)MyProject.Forms.EditCargoV2).Visible)
		{
			MyProject.Forms.EditCargoV2.RefreshForm();
		}
	}

	private void method_16()
	{
		CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel();
		int selectedIndex = ((ComboBox)FuelTypeComboBox).SelectedIndex;
		string text = "";
		float num = 0f;
		if (selectedIndex >= 0)
		{
			float currentQuantity = Cargo.InputValueLiquidVolume(FuelTrackBar.Value, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			cargoLiquidFuel.FuelType = (FuelRec._FuelType)((Class1)((ComboBox)FuelTypeComboBox).Items[selectedIndex]).ID;
			cargoLiquidFuel.CurrentQuantity = currentQuantity;
			float num2 = cargoLiquidFuel.GetRequiredMass();
			if (SelectedContainer.CargoArray.Count() > 0 && SelectedContainer.CargoArray[0].CargoObjectContainerContents != null && SelectedContainer.CargoArray[0].CargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.LiquidFuel)
			{
				num = ((CargoLiquidFuel)SelectedContainer.CargoArray[0].CargoObjectContainerContents).GetRequiredMass();
			}
			float num3 = ((ICargoHost)SelectedActiveUnit).GetCargo_MassAvailable() + num;
			if (num3 > SelectedContainer.GetCargo_Mass())
			{
				num3 = SelectedContainer.GetCargo_Mass();
				text = "Quantity constrained by container weight limit!";
			}
			else
			{
				text = "Quantity constrained by transporting unit's weight limit!";
			}
			if (num2 > num3)
			{
				num2 = num3;
				cargoLiquidFuel.CurrentQuantity = cargoLiquidFuel.GetVolumeForMass(1000f * num2);
				FuelTrackBar.Value = (int)Math.Round(Cargo.DisplayValueLiquidVolume(cargoLiquidFuel.CurrentQuantity, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo));
				((Label)FuelWarningLabel).Text = text;
			}
			else
			{
				((Label)FuelWarningLabel).Text = "";
			}
			((Label)FuelVolumeLabel).Text = Cargo.DisplayValueLiquidVolume(cargoLiquidFuel.CurrentQuantity, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo).ToString("N2");
			((Label)FuelMassLabel).Text = Cargo.DisplayValueSmallMass(1000f * num2, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo).ToString("N2");
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		method_16();
	}

	private void method_18(object sender, EventArgs e)
	{
		method_16();
	}

	private void method_19(object sender, EventArgs e)
	{
		method_12();
	}

	private void method_20(object sender, EventArgs e)
	{
		method_12();
	}

	private void method_21(object sender, EventArgs e)
	{
		method_12();
	}

	private void method_22(object sender, EventArgs e)
	{
		method_8();
	}

	static EditCargoContainer()
	{
		Class72.smethod_20();
	}
}

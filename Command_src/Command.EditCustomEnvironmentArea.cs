using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditCustomEnvironmentArea : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("txtCZInterval")]
	private DarkUITextBox _txtCZInterval;

	[CompilerGenerated]
	[AccessedThroughProperty("cmbTerrainType")]
	private DarkUIComboBox _cmbTerrainType;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_FUR")]
	private TrackBar _TrackBar_FUR;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_Rainfall")]
	private TrackBar _TrackBar_Rainfall;

	[AccessedThroughProperty("TrackBar_AverageTemp")]
	[CompilerGenerated]
	private TrackBar _TrackBar_AverageTemp;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_SeaState")]
	private TrackBar _TrackBar_SeaState;

	[CompilerGenerated]
	[AccessedThroughProperty("ColorDialog1")]
	private ColorDialog colorDialog_0;

	[AccessedThroughProperty("txtTerrainHeight")]
	[CompilerGenerated]
	private DarkUITextBox _txtTerrainHeight;

	[CompilerGenerated]
	[AccessedThroughProperty("ChkCustomTerrainHeight")]
	private DarkUICheckBox _ChkCustomTerrainHeight;

	[CompilerGenerated]
	[AccessedThroughProperty("txtThermalLayerCeiling")]
	private DarkUITextBox _txtThermalLayerCeiling;

	[CompilerGenerated]
	[AccessedThroughProperty("txtThermalLayerFloor")]
	private DarkUITextBox _txtThermalLayerFloor;

	[CompilerGenerated]
	[AccessedThroughProperty("txtLayerStrenght")]
	private DarkUITextBox _txtLayerStrenght;

	[CompilerGenerated]
	[AccessedThroughProperty("DayNightTempInput")]
	private DarkUITextBox _DayNightTempInput;

	[CompilerGenerated]
	[AccessedThroughProperty("GeneralTooltip")]
	private ToolTip toolTip_0;

	private CustomEnvironmentZone customEnvironmentZone_0;

	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal virtual ToolStripLabel ToolStripLabel1 { get; set; }

	[field: AccessedThroughProperty("TSDD_WeatherLevel")]
	internal virtual ToolStripDropDownButton TSDD_WeatherLevel { get; set; }

	[field: AccessedThroughProperty("TC_WeatherLevel")]
	internal virtual DarkUITabControl TC_WeatherLevel { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3 { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	internal virtual DarkUITextBox txtCZInterval
	{
		[CompilerGenerated]
		get
		{
			return _txtCZInterval;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_16;
			DarkUITextBox darkUITextBox = _txtCZInterval;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_txtCZInterval = value;
			darkUITextBox = _txtCZInterval;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUIComboBox cmbTerrainType
	{
		[CompilerGenerated]
		get
		{
			return _cmbTerrainType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIComboBox darkUIComboBox = _cmbTerrainType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_cmbTerrainType = value;
			darkUIComboBox = _cmbTerrainType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("lblName")]
	internal virtual DarkLabel lblName { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual TrackBar TrackBar_FUR
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_FUR;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			TrackBar val = _TrackBar_FUR;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_FUR = value;
			val = _TrackBar_FUR;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	internal virtual TrackBar TrackBar_Rainfall
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_Rainfall;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			TrackBar val = _TrackBar_Rainfall;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_Rainfall = value;
			val = _TrackBar_Rainfall;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	internal virtual TrackBar TrackBar_AverageTemp
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_AverageTemp;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			TrackBar val = _TrackBar_AverageTemp;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_AverageTemp = value;
			val = _TrackBar_AverageTemp;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_AverageTemp")]
	internal virtual DarkLabel Label_AverageTemp { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	internal virtual TrackBar TrackBar_SeaState
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_SeaState;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			TrackBar val = _TrackBar_SeaState;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_SeaState = value;
			val = _TrackBar_SeaState;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label10")]
	internal virtual DarkLabel Label10 { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	internal virtual ColorDialog ColorDialog1
	{
		[CompilerGenerated]
		get
		{
			return colorDialog_0;
		}
		[CompilerGenerated]
		set
		{
			colorDialog_0 = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7 { get; set; }

	internal virtual DarkUITextBox txtTerrainHeight
	{
		[CompilerGenerated]
		get
		{
			return _txtTerrainHeight;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_18;
			DarkUITextBox darkUITextBox = _txtTerrainHeight;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_txtTerrainHeight = value;
			darkUITextBox = _txtTerrainHeight;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUICheckBox ChkCustomTerrainHeight
	{
		[CompilerGenerated]
		get
		{
			return _ChkCustomTerrainHeight;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUICheckBox darkUICheckBox = _ChkCustomTerrainHeight;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_ChkCustomTerrainHeight = value;
			darkUICheckBox = _ChkCustomTerrainHeight;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("lblWarning")]
	internal virtual DarkLabel lblWarning { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("lblElevation")]
	internal virtual DarkLabel lblElevation { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	internal virtual DarkUITextBox txtThermalLayerCeiling
	{
		[CompilerGenerated]
		get
		{
			return _txtThermalLayerCeiling;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_13;
			DarkUITextBox darkUITextBox = _txtThermalLayerCeiling;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_txtThermalLayerCeiling = value;
			darkUITextBox = _txtThermalLayerCeiling;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUITextBox txtThermalLayerFloor
	{
		[CompilerGenerated]
		get
		{
			return _txtThermalLayerFloor;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_14;
			DarkUITextBox darkUITextBox = _txtThermalLayerFloor;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_txtThermalLayerFloor = value;
			darkUITextBox = _txtThermalLayerFloor;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LblElevText")]
	internal virtual DarkLabel LblElevText { get; set; }

	internal virtual DarkUITextBox txtLayerStrenght
	{
		[CompilerGenerated]
		get
		{
			return _txtLayerStrenght;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_15;
			DarkUITextBox darkUITextBox = _txtLayerStrenght;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_txtLayerStrenght = value;
			darkUITextBox = _txtLayerStrenght;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	[field: AccessedThroughProperty("DayNightLabel")]
	internal virtual DarkLabel DayNightLabel { get; set; }

	internal virtual DarkUITextBox DayNightTempInput
	{
		[CompilerGenerated]
		get
		{
			return _DayNightTempInput;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_20;
			DarkUITextBox darkUITextBox = _DayNightTempInput;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_DayNightTempInput = value;
			darkUITextBox = _DayNightTempInput;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual ToolTip GeneralTooltip
	{
		[CompilerGenerated]
		get
		{
			return toolTip_0;
		}
		[CompilerGenerated]
		set
		{
			toolTip_0 = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	[field: AccessedThroughProperty("lblAreaName")]
	internal virtual DarkLabel lblAreaName { get; set; }

	public bool IsLoaded
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public EditCustomEnvironmentArea()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += EditCustomEnvironmentArea_Load;
		((Control)this).KeyDown += new KeyEventHandler(EditCustomEnvironmentArea_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(EditCustomEnvironmentArea_FormClosing);
		IsLoaded = false;
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Expected O, but got Unknown
		//IL_084c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0856: Expected O, but got Unknown
		//IL_0e8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Expected O, but got Unknown
		//IL_1940: Unknown result type (might be due to invalid IL or missing references)
		//IL_194a: Expected O, but got Unknown
		//IL_19d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e3: Expected O, but got Unknown
		//IL_1a79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a83: Expected O, but got Unknown
		//IL_1b1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b26: Expected O, but got Unknown
		//IL_1c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca7: Expected O, but got Unknown
		//IL_1d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d48: Expected O, but got Unknown
		//IL_1de2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dec: Expected O, but got Unknown
		//IL_1e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8d: Expected O, but got Unknown
		//IL_1fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbb: Expected O, but got Unknown
		//IL_2055: Unknown result type (might be due to invalid IL or missing references)
		//IL_205f: Expected O, but got Unknown
		//IL_216c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2176: Expected O, but got Unknown
		//IL_2210: Unknown result type (might be due to invalid IL or missing references)
		//IL_221a: Expected O, but got Unknown
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(EditCustomEnvironmentArea));
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TSDD_WeatherLevel = new ToolStripDropDownButton();
		TC_WeatherLevel = new DarkUITabControl();
		TabPage1 = new TabPage();
		DarkLabel6 = new DarkLabel();
		DayNightLabel = new DarkLabel();
		DayNightTempInput = new DarkUITextBox();
		lblAreaName = new DarkLabel();
		DarkGroupBox3 = new DarkGroupBox();
		ChkCustomTerrainHeight = new DarkUICheckBox();
		DarkLabel7 = new DarkLabel();
		txtTerrainHeight = new DarkUITextBox();
		DarkLabel4 = new DarkLabel();
		cmbTerrainType = new DarkUIComboBox();
		DarkGroupBox1 = new DarkGroupBox();
		lblWarning = new DarkLabel();
		DarkGroupBox2 = new DarkGroupBox();
		lblElevation = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		txtThermalLayerCeiling = new DarkUITextBox();
		DarkLabel1 = new DarkLabel();
		txtThermalLayerFloor = new DarkUITextBox();
		LblElevText = new DarkLabel();
		txtLayerStrenght = new DarkUITextBox();
		DarkLabel3 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		txtCZInterval = new DarkUITextBox();
		Label3 = new DarkLabel();
		lblName = new DarkLabel();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		TrackBar_FUR = new TrackBar();
		TrackBar_Rainfall = new TrackBar();
		Label4 = new DarkLabel();
		Label5 = new DarkLabel();
		Label6 = new DarkLabel();
		Label7 = new DarkLabel();
		TrackBar_AverageTemp = new TrackBar();
		Label_AverageTemp = new DarkLabel();
		Label8 = new DarkLabel();
		TrackBar_SeaState = new TrackBar();
		Label10 = new DarkLabel();
		Label9 = new DarkLabel();
		ColorDialog1 = new ColorDialog();
		GeneralTooltip = new ToolTip(icontainer_1);
		((Control)ToolStrip1).SuspendLayout();
		((Control)TC_WeatherLevel).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)DarkGroupBox3).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((ISupportInitialize)TrackBar_FUR).BeginInit();
		((ISupportInitialize)TrackBar_Rainfall).BeginInit();
		((ISupportInitialize)TrackBar_AverageTemp).BeginInit();
		((ISupportInitialize)TrackBar_SeaState).BeginInit();
		((Control)this).SuspendLayout();
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)ToolStripLabel1,
			(ToolStripItem)TSDD_WeatherLevel
		});
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(609, 25);
		((Control)ToolStrip1).TabIndex = 0;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)ToolStripLabel1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel1).Name = "ToolStripLabel1";
		((ToolStripItem)ToolStripLabel1).Size = new Size(138, 22);
		((ToolStripItem)ToolStripLabel1).Text = "Weather modelling level:";
		((ToolStripItem)TSDD_WeatherLevel).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSDD_WeatherLevel).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSDD_WeatherLevel).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSDD_WeatherLevel).Image = (Image)componentResourceManager.GetObject("TSDD_WeatherLevel.Image");
		((ToolStripItem)TSDD_WeatherLevel).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSDD_WeatherLevel).Name = "TSDD_WeatherLevel";
		((ToolStripItem)TSDD_WeatherLevel).Size = new Size(56, 22);
		((ToolStripItem)TSDD_WeatherLevel).Text = "Level 0";
		((Control)TC_WeatherLevel).Controls.Add((Control)(object)TabPage1);
		((Control)TC_WeatherLevel).Cursor = Cursors.Hand;
		((Control)TC_WeatherLevel).Dock = (DockStyle)5;
		((TabControl)TC_WeatherLevel).ItemSize = new Size(80, 20);
		((Control)TC_WeatherLevel).Location = new Point(0, 25);
		((TabControl)TC_WeatherLevel).Multiline = true;
		((Control)TC_WeatherLevel).Name = "TC_WeatherLevel";
		((TabControl)TC_WeatherLevel).SelectedIndex = 0;
		((Control)TC_WeatherLevel).Size = new Size(609, 416);
		((Control)TC_WeatherLevel).TabIndex = 19;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)DarkLabel6);
		((Control)TabPage1).Controls.Add((Control)(object)DayNightLabel);
		((Control)TabPage1).Controls.Add((Control)(object)DayNightTempInput);
		((Control)TabPage1).Controls.Add((Control)(object)lblAreaName);
		((Control)TabPage1).Controls.Add((Control)(object)DarkGroupBox3);
		((Control)TabPage1).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)TabPage1).Controls.Add((Control)(object)Label3);
		((Control)TabPage1).Controls.Add((Control)(object)lblName);
		((Control)TabPage1).Controls.Add((Control)(object)Label1);
		((Control)TabPage1).Controls.Add((Control)(object)Label2);
		((Control)TabPage1).Controls.Add((Control)(object)TrackBar_FUR);
		((Control)TabPage1).Controls.Add((Control)(object)TrackBar_Rainfall);
		((Control)TabPage1).Controls.Add((Control)(object)Label4);
		((Control)TabPage1).Controls.Add((Control)(object)Label5);
		((Control)TabPage1).Controls.Add((Control)(object)Label6);
		((Control)TabPage1).Controls.Add((Control)(object)Label7);
		((Control)TabPage1).Controls.Add((Control)(object)TrackBar_AverageTemp);
		((Control)TabPage1).Controls.Add((Control)(object)Label_AverageTemp);
		((Control)TabPage1).Controls.Add((Control)(object)Label8);
		((Control)TabPage1).Controls.Add((Control)(object)TrackBar_SeaState);
		((Control)TabPage1).Controls.Add((Control)(object)Label10);
		((Control)TabPage1).Controls.Add((Control)(object)Label9);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(601, 388);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Level 0";
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(552, 24);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(21, 13);
		((Control)DarkLabel6).TabIndex = 64;
		((Label)DarkLabel6).Text = "° C";
		DayNightLabel.AutoSize = true;
		((Control)DayNightLabel).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)DayNightLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DayNightLabel).Location = new Point(390, 24);
		((Control)DayNightLabel).Name = "DayNightLabel";
		((Control)DayNightLabel).Size = new Size(111, 13);
		((Control)DayNightLabel).TabIndex = 63;
		((Label)DayNightLabel).Text = "Day-Night modifier:";
		GeneralTooltip.SetToolTip((Control)(object)DayNightLabel, "Adjusts average temperature depending on time of day.\r\nDaytime adds this value,\r\nTwilight keeps it unchanged,\r\nNighttime subtracts it.");
		DayNightTempInput.AutoCompleteCustomSource = null;
		DayNightTempInput.AutoCompleteMode = (AutoCompleteMode)0;
		DayNightTempInput.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)DayNightTempInput).BackColor = Color.Transparent;
		((Control)DayNightTempInput).ForeColor = Color.FromArgb(189, 189, 189);
		DayNightTempInput.Image = null;
		DayNightTempInput.Lines = null;
		((Control)DayNightTempInput).Location = new Point(507, 21);
		DayNightTempInput.MaxLength = 6;
		DayNightTempInput.Multiline = false;
		((Control)DayNightTempInput).Name = "DayNightTempInput";
		DayNightTempInput.ReadOnly = false;
		DayNightTempInput.ScrollBars = (ScrollBars)0;
		DayNightTempInput.SelectionStart = 0;
		((Control)DayNightTempInput).Size = new Size(39, 19);
		((Control)DayNightTempInput).TabIndex = 61;
		DayNightTempInput.TextAlign = (HorizontalAlignment)2;
		GeneralTooltip.SetToolTip((Control)(object)DayNightTempInput, "Adjusts average temperature depending on time of day.\r\nDaytime adds this value,\r\nTwilight keeps it unchanged,\r\nNighttime subtracts it.");
		DayNightTempInput.UseSystemPasswordChar = false;
		DayNightTempInput.WatermarkText = "";
		DayNightTempInput.WordWrap = false;
		lblAreaName.AutoSize = true;
		((Control)lblAreaName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblAreaName).Location = new Point(179, 20);
		((Control)lblAreaName).Name = "lblAreaName";
		((Control)lblAreaName).Size = new Size(0, 15);
		((Control)lblAreaName).TabIndex = 60;
		((Control)DarkGroupBox3).Controls.Add((Control)(object)ChkCustomTerrainHeight);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)DarkLabel7);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)txtTerrainHeight);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)DarkLabel4);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)cmbTerrainType);
		((Control)DarkGroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox3).Location = new Point(305, 181);
		((Control)DarkGroupBox3).Name = "DarkGroupBox3";
		((Control)DarkGroupBox3).Size = new Size(285, 201);
		((Control)DarkGroupBox3).TabIndex = 59;
		((GroupBox)DarkGroupBox3).TabStop = false;
		((GroupBox)DarkGroupBox3).Text = "Land Cover";
		((ButtonBase)ChkCustomTerrainHeight).BackColor = Color.Transparent;
		((Control)ChkCustomTerrainHeight).Cursor = Cursors.Hand;
		((Control)ChkCustomTerrainHeight).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)ChkCustomTerrainHeight).Location = new Point(17, 50);
		((Control)ChkCustomTerrainHeight).Name = "ChkCustomTerrainHeight";
		((Control)ChkCustomTerrainHeight).Size = new Size(129, 18);
		((Control)ChkCustomTerrainHeight).TabIndex = 36;
		((ButtonBase)ChkCustomTerrainHeight).Text = "Set Custom Height:";
		DarkLabel7.AutoSize = true;
		((Control)DarkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel7).Location = new Point(204, 53);
		((Control)DarkLabel7).Name = "DarkLabel7";
		((Control)DarkLabel7).Size = new Size(43, 15);
		((Control)DarkLabel7).TabIndex = 35;
		((Label)DarkLabel7).Text = "meters";
		txtTerrainHeight.AutoCompleteCustomSource = null;
		txtTerrainHeight.AutoCompleteMode = (AutoCompleteMode)0;
		txtTerrainHeight.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txtTerrainHeight).BackColor = Color.Transparent;
		((Control)txtTerrainHeight).ForeColor = Color.FromArgb(189, 189, 189);
		txtTerrainHeight.Image = null;
		txtTerrainHeight.Lines = null;
		((Control)txtTerrainHeight).Location = new Point(159, 48);
		txtTerrainHeight.MaxLength = 6;
		txtTerrainHeight.Multiline = false;
		((Control)txtTerrainHeight).Name = "txtTerrainHeight";
		txtTerrainHeight.ReadOnly = false;
		txtTerrainHeight.ScrollBars = (ScrollBars)0;
		txtTerrainHeight.SelectionStart = 0;
		((Control)txtTerrainHeight).Size = new Size(39, 24);
		((Control)txtTerrainHeight).TabIndex = 34;
		txtTerrainHeight.TextAlign = (HorizontalAlignment)0;
		txtTerrainHeight.UseSystemPasswordChar = false;
		txtTerrainHeight.WatermarkText = "";
		txtTerrainHeight.WordWrap = false;
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(14, 21);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(66, 15);
		((Control)DarkLabel4).TabIndex = 32;
		((Label)DarkLabel4).Text = "Cover Type";
		((ComboBox)cmbTerrainType).BackColor = Color.Transparent;
		((ComboBox)cmbTerrainType).DrawMode = (DrawMode)1;
		((ComboBox)cmbTerrainType).DropDownStyle = (ComboBoxStyle)2;
		((Control)cmbTerrainType).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)cmbTerrainType).FormattingEnabled = true;
		((Control)cmbTerrainType).Location = new Point(85, 18);
		((Control)cmbTerrainType).Name = "cmbTerrainType";
		((Control)cmbTerrainType).Size = new Size(174, 21);
		((Control)cmbTerrainType).TabIndex = 31;
		((Control)DarkGroupBox1).Controls.Add((Control)(object)lblWarning);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)DarkLabel2);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)txtCZInterval);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(3, 181);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(296, 201);
		((Control)DarkGroupBox1).TabIndex = 57;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Sonar Conditions";
		lblWarning.AutoSize = true;
		((Control)lblWarning).ForeColor = Color.Red;
		((Control)lblWarning).Location = new Point(49, 18);
		((Control)lblWarning).Name = "lblWarning";
		((Control)lblWarning).Size = new Size(201, 15);
		((Control)lblWarning).TabIndex = 48;
		((Label)lblWarning).Text = "WARNING OVERLAND RP DETECTED";
		((Control)DarkGroupBox2).Controls.Add((Control)(object)lblElevation);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel5);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)txtThermalLayerCeiling);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel1);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)txtThermalLayerFloor);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)LblElevText);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)txtLayerStrenght);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel3);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(8, 35);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(282, 121);
		((Control)DarkGroupBox2).TabIndex = 39;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Thermal Layer";
		lblElevation.AutoSize = true;
		((Control)lblElevation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblElevation).Location = new Point(134, 57);
		((Control)lblElevation).Name = "lblElevation";
		((Control)lblElevation).Size = new Size(59, 15);
		((Control)lblElevation).TabIndex = 45;
		((Label)lblElevation).Text = "Min value";
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(24, 54);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(34, 15);
		((Control)DarkLabel5).TabIndex = 43;
		((Label)DarkLabel5).Text = "Floor";
		txtThermalLayerCeiling.AutoCompleteCustomSource = null;
		txtThermalLayerCeiling.AutoCompleteMode = (AutoCompleteMode)0;
		txtThermalLayerCeiling.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txtThermalLayerCeiling).BackColor = Color.Transparent;
		((Control)txtThermalLayerCeiling).ForeColor = Color.FromArgb(189, 189, 189);
		txtThermalLayerCeiling.Image = null;
		txtThermalLayerCeiling.Lines = null;
		((Control)txtThermalLayerCeiling).Location = new Point(62, 24);
		txtThermalLayerCeiling.MaxLength = 32767;
		txtThermalLayerCeiling.Multiline = false;
		((Control)txtThermalLayerCeiling).Name = "txtThermalLayerCeiling";
		txtThermalLayerCeiling.ReadOnly = false;
		txtThermalLayerCeiling.ScrollBars = (ScrollBars)0;
		txtThermalLayerCeiling.SelectionStart = 0;
		((Control)txtThermalLayerCeiling).Size = new Size(66, 24);
		((Control)txtThermalLayerCeiling).TabIndex = 39;
		txtThermalLayerCeiling.TextAlign = (HorizontalAlignment)0;
		txtThermalLayerCeiling.UseSystemPasswordChar = false;
		txtThermalLayerCeiling.WatermarkText = "";
		txtThermalLayerCeiling.WordWrap = false;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(14, 25);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(44, 15);
		((Control)DarkLabel1).TabIndex = 41;
		((Label)DarkLabel1).Text = "Ceiling";
		txtThermalLayerFloor.AutoCompleteCustomSource = null;
		txtThermalLayerFloor.AutoCompleteMode = (AutoCompleteMode)0;
		txtThermalLayerFloor.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txtThermalLayerFloor).BackColor = Color.Transparent;
		((Control)txtThermalLayerFloor).ForeColor = Color.FromArgb(189, 189, 189);
		txtThermalLayerFloor.Image = null;
		txtThermalLayerFloor.Lines = null;
		((Control)txtThermalLayerFloor).Location = new Point(62, 53);
		txtThermalLayerFloor.MaxLength = 32767;
		txtThermalLayerFloor.Multiline = false;
		((Control)txtThermalLayerFloor).Name = "txtThermalLayerFloor";
		txtThermalLayerFloor.ReadOnly = false;
		txtThermalLayerFloor.ScrollBars = (ScrollBars)0;
		txtThermalLayerFloor.SelectionStart = 0;
		((Control)txtThermalLayerFloor).Size = new Size(66, 24);
		((Control)txtThermalLayerFloor).TabIndex = 44;
		txtThermalLayerFloor.TextAlign = (HorizontalAlignment)0;
		txtThermalLayerFloor.UseSystemPasswordChar = false;
		txtThermalLayerFloor.WatermarkText = "";
		txtThermalLayerFloor.WordWrap = false;
		LblElevText.AutoSize = true;
		((Control)LblElevText).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LblElevText).Location = new Point(199, 57);
		((Control)LblElevText).Name = "LblElevText";
		((Control)LblElevText).Size = new Size(79, 15);
		((Control)LblElevText).TabIndex = 46;
		((Label)LblElevText).Text = "Elevation Text";
		txtLayerStrenght.AutoCompleteCustomSource = null;
		txtLayerStrenght.AutoCompleteMode = (AutoCompleteMode)0;
		txtLayerStrenght.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txtLayerStrenght).BackColor = Color.Transparent;
		((Control)txtLayerStrenght).ForeColor = Color.FromArgb(189, 189, 189);
		txtLayerStrenght.Image = null;
		txtLayerStrenght.Lines = null;
		((Control)txtLayerStrenght).Location = new Point(61, 83);
		txtLayerStrenght.MaxLength = 32767;
		txtLayerStrenght.Multiline = false;
		((Control)txtLayerStrenght).Name = "txtLayerStrenght";
		txtLayerStrenght.ReadOnly = false;
		txtLayerStrenght.ScrollBars = (ScrollBars)0;
		txtLayerStrenght.SelectionStart = 0;
		((Control)txtLayerStrenght).Size = new Size(67, 24);
		((Control)txtLayerStrenght).TabIndex = 40;
		txtLayerStrenght.TextAlign = (HorizontalAlignment)0;
		txtLayerStrenght.UseSystemPasswordChar = false;
		txtLayerStrenght.WatermarkText = "";
		txtLayerStrenght.WordWrap = false;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(6, 86);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(52, 15);
		((Control)DarkLabel3).TabIndex = 42;
		((Label)DarkLabel3).Text = "Strength";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(2, 167);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(64, 15);
		((Control)DarkLabel2).TabIndex = 28;
		((Label)DarkLabel2).Text = "CZ Interval";
		txtCZInterval.AutoCompleteCustomSource = null;
		txtCZInterval.AutoCompleteMode = (AutoCompleteMode)0;
		txtCZInterval.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txtCZInterval).BackColor = Color.Transparent;
		((Control)txtCZInterval).ForeColor = Color.FromArgb(189, 189, 189);
		txtCZInterval.Image = null;
		txtCZInterval.Lines = null;
		((Control)txtCZInterval).Location = new Point(70, 162);
		txtCZInterval.MaxLength = 32767;
		txtCZInterval.Multiline = false;
		((Control)txtCZInterval).Name = "txtCZInterval";
		txtCZInterval.ReadOnly = false;
		txtCZInterval.ScrollBars = (ScrollBars)0;
		txtCZInterval.SelectionStart = 0;
		((Control)txtCZInterval).Size = new Size(174, 24);
		((Control)txtCZInterval).TabIndex = 29;
		txtCZInterval.TextAlign = (HorizontalAlignment)0;
		txtCZInterval.UseSystemPasswordChar = false;
		txtCZInterval.WatermarkText = "";
		txtCZInterval.WordWrap = false;
		Label3.AutoSize = true;
		((Control)Label3).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(4, 112);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(80, 21);
		((Control)Label3).TabIndex = 40;
		((Label)Label3).Text = "The sky is:";
		lblName.AutoSize = true;
		((Control)lblName).Font = new Font("Segoe UI", 14f);
		((Control)lblName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblName).Location = new Point(3, 12);
		((Control)lblName).Name = "lblName";
		((Control)lblName).Size = new Size(106, 25);
		((Control)lblName).TabIndex = 56;
		((Label)lblName).Text = "Area Name";
		Label1.AutoSize = true;
		((Control)Label1).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(4, 50);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(160, 21);
		((Control)Label1).TabIndex = 38;
		((Label)Label1).Text = "Average temperature:";
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(4, 81);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(96, 21);
		((Control)Label2).TabIndex = 39;
		((Label)Label2).Text = "Rainfall rate:";
		TrackBar_FUR.AutoSize = false;
		TrackBar_FUR.LargeChange = 10;
		((Control)TrackBar_FUR).Location = new Point(173, 115);
		((Control)TrackBar_FUR).Name = "TrackBar_FUR";
		((Control)TrackBar_FUR).Size = new Size(239, 31);
		((Control)TrackBar_FUR).TabIndex = 41;
		TrackBar_Rainfall.AutoSize = false;
		TrackBar_Rainfall.LargeChange = 10;
		((Control)TrackBar_Rainfall).Location = new Point(173, 81);
		TrackBar_Rainfall.Maximum = 50;
		((Control)TrackBar_Rainfall).Name = "TrackBar_Rainfall";
		((Control)TrackBar_Rainfall).Size = new Size(239, 31);
		TrackBar_Rainfall.SmallChange = 5;
		((Control)TrackBar_Rainfall).TabIndex = 42;
		Label4.AutoSize = true;
		((Control)Label4).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(116, 86);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(46, 13);
		((Control)Label4).TabIndex = 43;
		((Label)Label4).Text = "No rain";
		Label5.AutoSize = true;
		((Control)Label5).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(436, 87);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(72, 13);
		((Control)Label5).TabIndex = 44;
		((Label)Label5).Text = "Heavy storm";
		Label6.AutoSize = true;
		((Control)Label6).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(127, 117);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(33, 13);
		((Control)Label6).TabIndex = 45;
		((Label)Label6).Text = "Clear";
		Label7.AutoSize = true;
		((Control)Label7).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(436, 118);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(117, 13);
		((Control)Label7).TabIndex = 46;
		((Label)Label7).Text = "Full with thick clouds";
		TrackBar_AverageTemp.AutoSize = false;
		TrackBar_AverageTemp.LargeChange = 10;
		((Control)TrackBar_AverageTemp).Location = new Point(173, 50);
		TrackBar_AverageTemp.Maximum = 50;
		TrackBar_AverageTemp.Minimum = -50;
		((Control)TrackBar_AverageTemp).Name = "TrackBar_AverageTemp";
		((Control)TrackBar_AverageTemp).Size = new Size(239, 31);
		TrackBar_AverageTemp.SmallChange = 5;
		((Control)TrackBar_AverageTemp).TabIndex = 47;
		Label_AverageTemp.AutoSize = true;
		((Control)Label_AverageTemp).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label_AverageTemp).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AverageTemp).Location = new Point(436, 56);
		((Control)Label_AverageTemp).Name = "Label_AverageTemp";
		((Control)Label_AverageTemp).Size = new Size(21, 13);
		((Control)Label_AverageTemp).TabIndex = 48;
		((Label)Label_AverageTemp).Text = "° C";
		Label8.AutoSize = true;
		((Control)Label8).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(3, 144);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(126, 21);
		((Control)Label8).TabIndex = 49;
		((Label)Label8).Text = "Wind / Sea state:";
		TrackBar_SeaState.AutoSize = false;
		TrackBar_SeaState.LargeChange = 10;
		((Control)TrackBar_SeaState).Location = new Point(173, 144);
		TrackBar_SeaState.Maximum = 9;
		((Control)TrackBar_SeaState).Name = "TrackBar_SeaState";
		((Control)TrackBar_SeaState).Size = new Size(239, 31);
		((Control)TrackBar_SeaState).TabIndex = 50;
		Label10.AutoSize = true;
		((Control)Label10).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label10).Location = new Point(126, 149);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(33, 13);
		((Control)Label10).TabIndex = 51;
		((Label)Label10).Text = "Calm";
		Label9.AutoSize = true;
		((Control)Label9).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(436, 149);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(57, 13);
		((Control)Label9).TabIndex = 52;
		((Label)Label9).Text = "Hurricane";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(609, 441);
		((Control)this).Controls.Add((Control)(object)TC_WeatherLevel);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MaximumSize = new Size(625, 480);
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(625, 480);
		((Control)this).Name = "EditCustomEnvironmentArea";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Custom Environment Area Editor";
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)TC_WeatherLevel).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((Control)DarkGroupBox3).ResumeLayout(false);
		((Control)DarkGroupBox3).PerformLayout();
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox1).PerformLayout();
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox2).PerformLayout();
		((ISupportInitialize)TrackBar_FUR).EndInit();
		((ISupportInitialize)TrackBar_Rainfall).EndInit();
		((ISupportInitialize)TrackBar_AverageTemp).EndInit();
		((ISupportInitialize)TrackBar_SeaState).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void EditCustomEnvironmentArea_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		method_2();
	}

	private void method_2()
	{
		IsLoaded = false;
		method_10();
		method_4(Client.CurrentScenario);
		IsLoaded = true;
	}

	private void method_3()
	{
		if (!customEnvironmentZone_0.HasCustomTerrainHeight)
		{
			((CheckBox)ChkCustomTerrainHeight).Checked = false;
			((Control)txtTerrainHeight).Enabled = false;
		}
		else
		{
			((CheckBox)ChkCustomTerrainHeight).Checked = true;
			((Control)txtTerrainHeight).Enabled = true;
		}
	}

	private void method_4(Scenario scenario_0)
	{
		((Label)lblAreaName).Text = customEnvironmentZone_0.Description;
		TrackBar_AverageTemp.Value = (int)Math.Round(customEnvironmentZone_0.Weather.AverageTemp);
		((Label)Label_AverageTemp).Text = Conversions.ToString(customEnvironmentZone_0.Weather.AverageTemp) + " °C";
		TrackBar_Rainfall.Value = (int)Math.Round(customEnvironmentZone_0.Weather.RainfallRate);
		TrackBar_FUR.Value = (int)Math.Round(customEnvironmentZone_0.Weather.FractionUnderRain * 10f);
		TrackBar_SeaState.Value = customEnvironmentZone_0.Weather.SeaState;
		DayNightTempInput.Text = customEnvironmentZone_0.Weather.DayNightTempModifier.ToString();
		txtCZInterval.Text = customEnvironmentZone_0.CZInterval.ToString();
		txtLayerStrenght.Text = customEnvironmentZone_0.LayerStrength.ToString();
		txtThermalLayerCeiling.Text = customEnvironmentZone_0.ThermalLayerCeiling.ToString();
		txtThermalLayerFloor.Text = customEnvironmentZone_0.ThermalLayerFloor.ToString();
		((ComboBox)cmbTerrainType).SelectedItem = customEnvironmentZone_0.TerrainType;
		method_3();
		txtTerrainHeight.Text = customEnvironmentZone_0.TerrainHeight.ToString();
		method_5(scenario_0);
	}

	private void method_5(Scenario scenario_0)
	{
		int num = int.MaxValue;
		foreach (ReferencePoint item in customEnvironmentZone_0.Area)
		{
			short elevation = Terrain.GetElevation(item.Latitude, item.Longitude, RequestIsFromGUI: false, scenario_0);
			if (num > elevation)
			{
				num = elevation;
			}
		}
		if (num > 0)
		{
			((Control)lblWarning).Visible = true;
		}
		else
		{
			((Control)lblWarning).Visible = false;
		}
		((Label)LblElevText).Text = num.ToString();
	}

	private void method_6(object sender, EventArgs e)
	{
		customEnvironmentZone_0.Weather.AverageTemp = TrackBar_AverageTemp.Value;
		((Label)Label_AverageTemp).Text = Conversions.ToString(customEnvironmentZone_0.Weather.AverageTemp) + " °C";
	}

	private void method_7(object sender, EventArgs e)
	{
		customEnvironmentZone_0.Weather.RainfallRate = TrackBar_Rainfall.Value;
	}

	private void method_8(object sender, EventArgs e)
	{
		customEnvironmentZone_0.Weather.FractionUnderRain = (float)((double)TrackBar_FUR.Value * 0.1);
	}

	private void method_9(object sender, EventArgs e)
	{
		customEnvironmentZone_0.Weather.SeaState = TrackBar_SeaState.Value;
	}

	private void EditCustomEnvironmentArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void EditCustomEnvironmentArea_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!method_12())
		{
			((CancelEventArgs)(object)e).Cancel = true;
		}
		else
		{
			((Control)MyProject.Forms.MainForm).BringToFront();
		}
	}

	private void method_10()
	{
		bool_2 = true;
		((ComboBox)cmbTerrainType).DataSource = null;
		((ComboBox)cmbTerrainType).DataSource = Enum.GetValues(typeof(LandCover.LandCoverType));
		bool_2 = false;
	}

	private void method_11(object sender, EventArgs e)
	{
		if (!bool_2)
		{
			customEnvironmentZone_0.TerrainType = (LandCover.LandCoverType)((ComboBox)cmbTerrainType).SelectedItem;
			if (!customEnvironmentZone_0.HasCustomTerrain)
			{
				customEnvironmentZone_0.RemoveCustomTerrainHeight();
			}
			method_3();
			if (!customEnvironmentZone_0.HasCustomTerrainHeight)
			{
				txtTerrainHeight.Text = customEnvironmentZone_0.TerrainHeight.ToString();
			}
		}
	}

	private bool method_12()
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		if (customEnvironmentZone_0.ThermalLayerCeiling < customEnvironmentZone_0.ThermalLayerFloor)
		{
			text = "Thermal Layer Ceiling must be higher then Thermal Layer Floor";
		}
		if ((customEnvironmentZone_0.ThermalLayerCeiling > 0) | (customEnvironmentZone_0.ThermalLayerFloor > 0))
		{
			text = text + Environment.NewLine + "Thermal Layer Ceiling and Thermal Layer Floor must be below 0";
		}
		if ((customEnvironmentZone_0.LayerStrength < 0f) | (customEnvironmentZone_0.LayerStrength > 100f))
		{
			text = text + Environment.NewLine + "Thermal Layer Strength is a percentage value must be between 0 and 100";
		}
		if (Operators.CompareString(text, "", true) != 0)
		{
			DarkMessageBox.ShowError(text, "Validation Error");
		}
		return Operators.CompareString(text, "", true) == 0;
	}

	private void method_13(object object_0)
	{
		if (int.TryParse(txtThermalLayerCeiling.Text, out var result))
		{
			customEnvironmentZone_0.ThermalLayerCeiling = result;
		}
	}

	private void method_14(object object_0)
	{
		if (int.TryParse(txtThermalLayerFloor.Text, out var result))
		{
			customEnvironmentZone_0.ThermalLayerFloor = result;
		}
	}

	private void method_15(object object_0)
	{
		if (float.TryParse(txtLayerStrenght.Text.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			customEnvironmentZone_0.LayerStrength = result;
		}
	}

	private void method_16(object object_0)
	{
		if (float.TryParse(txtCZInterval.Text.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			customEnvironmentZone_0.CZInterval = result;
		}
	}

	private void method_17(DarkUITextBox darkUITextBox_0, ref int int_0)
	{
		string text = darkUITextBox_0.Text;
		bool flag = false;
		if (Operators.CompareString(Conversions.ToString(text[0]), "-", true) == 0)
		{
			flag = true;
		}
		if (int.TryParse(text, out var result))
		{
			int_0 = result;
			if (flag & (int_0 > 0))
			{
				int_0 = -int_0;
			}
			try
			{
				txtTerrainHeight.TextChanged -= method_18;
				darkUITextBox_0.Text = int_0.ToString();
				return;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return;
			}
			finally
			{
				txtTerrainHeight.TextChanged += method_18;
			}
		}
		try
		{
			txtTerrainHeight.TextChanged -= method_18;
			if (flag)
			{
				darkUITextBox_0.Text = "-";
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		finally
		{
			txtTerrainHeight.TextChanged += method_18;
		}
	}

	private void method_18(object object_0)
	{
		if (((CheckBox)ChkCustomTerrainHeight).Checked && Operators.CompareString(txtTerrainHeight.Text, "", true) != 0)
		{
			DarkUITextBox darkUITextBox_ = txtTerrainHeight;
			CustomEnvironmentZone customEnvironmentZone;
			int int_ = (customEnvironmentZone = customEnvironmentZone_0).TerrainHeight;
			method_17(darkUITextBox_, ref int_);
			customEnvironmentZone.TerrainHeight = int_;
		}
	}

	internal void SetWorkingCEZ(ref CustomEnvironmentZone selectedCustomEnvironmentZone)
	{
		customEnvironmentZone_0 = selectedCustomEnvironmentZone;
	}

	private void method_19(object sender, EventArgs e)
	{
		if (((CheckBox)ChkCustomTerrainHeight).Checked)
		{
			((Control)txtTerrainHeight).Enabled = true;
			return;
		}
		((Control)txtTerrainHeight).Enabled = false;
		if (customEnvironmentZone_0 != null && customEnvironmentZone_0.HasCustomTerrainHeight)
		{
			customEnvironmentZone_0.RemoveCustomTerrainHeight();
		}
	}

	private void method_20(object object_0)
	{
		if (int.TryParse(DayNightTempInput.Text, out var result))
		{
			customEnvironmentZone_0.DayNightTemperatureModifier = result;
			customEnvironmentZone_0.Weather.DayNightTempModifier = result;
		}
	}

	static EditCustomEnvironmentArea()
	{
		Class72.smethod_20();
	}
}

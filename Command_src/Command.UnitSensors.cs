using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Collections.Pooled;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitSensors : DarkSecondaryFormBase, GInterface0
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ObeyEMCON")]
	private DarkCheckBox _CB_ObeyEMCON;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ECM")]
	private DarkCheckBox _CB_ECM;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_radar")]
	private DarkCheckBox _CB_radar;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Sonar")]
	private DarkCheckBox _CB_Sonar;

	[AccessedThroughProperty("TSB_AddSensor")]
	[CompilerGenerated]
	private ToolStripButton _TSB_AddSensor;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveSensor")]
	private ToolStripButton _TSB_RemoveSensor;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveMCM")]
	private ToolStripButton _TSB_RemoveMCM;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer_Refresh")]
	private Timer timer_0;

	[AccessedThroughProperty("DGV_Sensors")]
	[CompilerGenerated]
	private DarkDataGridView _DGV_Sensors;

	[AccessedThroughProperty("Status")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn QINLGIGVQRD;

	[AccessedThroughProperty("btn_relink_decoy")]
	[CompilerGenerated]
	private DarkUIButton _btn_relink_decoy;

	[CompilerGenerated]
	private bool bool_2;

	private DataTable dataTable_0;

	private List<Sensor> list_0;

	private List<Sensor> list_1;

	private List<Sensor> OECM;

	private bool bool_3;

	private string string_0;

	private ActiveUnit activeUnit_0;

	private bool bool_4;

	private Keys[] keys_0;

	internal virtual DarkCheckBox CB_ObeyEMCON
	{
		[CompilerGenerated]
		get
		{
			return _CB_ObeyEMCON;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkCheckBox darkCheckBox = _CB_ObeyEMCON;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ObeyEMCON = value;
			darkCheckBox = _CB_ObeyEMCON;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_ECM
	{
		[CompilerGenerated]
		get
		{
			return _CB_ECM;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkCheckBox darkCheckBox = _CB_ECM;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ECM = value;
			darkCheckBox = _CB_ECM;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_radar
	{
		[CompilerGenerated]
		get
		{
			return _CB_radar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkCheckBox darkCheckBox = _CB_radar;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_radar = value;
			darkCheckBox = _CB_radar;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_Sonar
	{
		[CompilerGenerated]
		get
		{
			return _CB_Sonar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkCheckBox darkCheckBox = _CB_Sonar;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_Sonar = value;
			darkCheckBox = _CB_Sonar;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TS_Edit")]
	internal virtual DarkToolStrip TS_Edit { get; set; }

	internal virtual ToolStripButton TSB_AddSensor
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AddSensor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			ToolStripButton val = _TSB_AddSensor;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_AddSensor = value;
			val = _TSB_AddSensor;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_RemoveSensor
	{
		[CompilerGenerated]
		get
		{
			return _TSB_RemoveSensor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			ToolStripButton val = _TSB_RemoveSensor;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_RemoveSensor = value;
			val = _TSB_RemoveSensor;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_RemoveMCM
	{
		[CompilerGenerated]
		get
		{
			return _TSB_RemoveMCM;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			ToolStripButton val = _TSB_RemoveMCM;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_RemoveMCM = value;
			val = _TSB_RemoveMCM;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual Timer Timer_Refresh
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
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

	internal virtual DarkDataGridView DGV_Sensors
	{
		[CompilerGenerated]
		get
		{
			return _DGV_Sensors;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_6);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_7);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(method_8);
			DataGridViewCellPaintingEventHandler val4 = new DataGridViewCellPaintingEventHandler(method_15);
			EventHandler eventHandler = method_16;
			EventHandler eventHandler2 = method_17;
			DarkDataGridView darkDataGridView = _DGV_Sensors;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick -= val;
				((DataGridView)darkDataGridView).CellContentClick -= val2;
				((DataGridView)darkDataGridView).CellContentDoubleClick -= val3;
				((DataGridView)darkDataGridView).CellPainting -= val4;
				((DataGridView)darkDataGridView).ReadOnlyChanged -= eventHandler;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler2;
			}
			_DGV_Sensors = value;
			darkDataGridView = _DGV_Sensors;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick += val;
				((DataGridView)darkDataGridView).CellContentClick += val2;
				((DataGridView)darkDataGridView).CellContentDoubleClick += val3;
				((DataGridView)darkDataGridView).CellPainting += val4;
				((DataGridView)darkDataGridView).ReadOnlyChanged += eventHandler;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("ObjectID")]
	internal virtual DataGridViewTextBoxColumn ObjectID { get; set; }

	[field: AccessedThroughProperty("SensorColumn")]
	internal virtual DataGridViewTextBoxColumn SensorColumn { get; set; }

	[field: AccessedThroughProperty("SensorType")]
	internal virtual DataGridViewTextBoxColumn SensorType { get; set; }

	[field: AccessedThroughProperty("Active")]
	internal virtual DataGridViewCheckBoxColumn Active { get; set; }

	internal virtual DataGridViewTextBoxColumn Status
	{
		[CompilerGenerated]
		get
		{
			return QINLGIGVQRD;
		}
		[CompilerGenerated]
		set
		{
			QINLGIGVQRD = value;
		}
	}

	[field: AccessedThroughProperty("lbl_decoy_emitter")]
	internal virtual DarkLabel lbl_decoy_emitter { get; set; }

	internal virtual DarkUIButton btn_relink_decoy
	{
		[CompilerGenerated]
		get
		{
			return _btn_relink_decoy;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkUIButton darkUIButton = _btn_relink_decoy;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btn_relink_decoy = value;
			darkUIButton = _btn_relink_decoy;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("cmb_relink_decoy")]
	internal virtual DarkUIComboBox cmb_relink_decoy { get; set; }

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

	public UnitSensors()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(UnitSensors_FormClosing);
		((Form)this).Load += UnitSensors_Load;
		((Form)this).Shown += UnitSensors_Shown;
		((Control)this).SizeChanged += UnitSensors_SizeChanged;
		((Control)this).KeyDown += new KeyEventHandler(UnitSensors_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(UnitSensors_FormClosed);
		RTMPEnabled = true;
		dataTable_0 = new DataTable();
		list_0 = new List<Sensor>();
		list_1 = new List<Sensor>();
		OECM = new List<Sensor>();
		bool_4 = false;
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)120,
			(Keys)27
		};
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Expected O, but got Unknown
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Expected O, but got Unknown
		//IL_087c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Expected O, but got Unknown
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Expected O, but got Unknown
		//IL_0c06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c99: Expected O, but got Unknown
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UnitSensors));
		Timer_Refresh = new Timer(icontainer_1);
		DGV_Sensors = new DarkDataGridView();
		ObjectID = new DataGridViewTextBoxColumn();
		SensorColumn = new DataGridViewTextBoxColumn();
		SensorType = new DataGridViewTextBoxColumn();
		Active = new DataGridViewCheckBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		TS_Edit = new DarkToolStrip();
		TSB_AddSensor = new ToolStripButton();
		TSB_RemoveSensor = new ToolStripButton();
		TSB_RemoveMCM = new ToolStripButton();
		Label1 = new DarkLabel();
		CB_ECM = new DarkCheckBox();
		CB_radar = new DarkCheckBox();
		CB_Sonar = new DarkCheckBox();
		CB_ObeyEMCON = new DarkCheckBox();
		lbl_decoy_emitter = new DarkLabel();
		btn_relink_decoy = new DarkUIButton();
		cmb_relink_decoy = new DarkUIComboBox();
		((ISupportInitialize)(object)DGV_Sensors).BeginInit();
		((Control)TS_Edit).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridView)DGV_Sensors).AllowUserToAddRows = false;
		((DataGridView)DGV_Sensors).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Sensors).AllowUserToOrderColumns = true;
		((Control)DGV_Sensors).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_Sensors).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		((DataGridView)DGV_Sensors).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		((DataGridView)DGV_Sensors).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Sensors).BorderStyle = (BorderStyle)2;
		((Control)DGV_Sensors).CausesValidation = false;
		((DataGridView)DGV_Sensors).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Sensors).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Sensors).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_Sensors).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_Sensors).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)ObjectID,
			(DataGridViewColumn)SensorColumn,
			(DataGridViewColumn)SensorType,
			(DataGridViewColumn)Active,
			(DataGridViewColumn)Status
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.LightGray;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Sensors).DefaultCellStyle = val2;
		((DataGridView)DGV_Sensors).EnableHeadersVisualStyles = false;
		((Control)DGV_Sensors).Location = new Point(0, 50);
		((DataGridView)DGV_Sensors).MultiSelect = false;
		((Control)DGV_Sensors).Name = "DGV_Sensors";
		((DataGridView)DGV_Sensors).RowHeadersVisible = false;
		((DataGridView)DGV_Sensors).RowHeadersWidth = 4;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(60, 63, 65);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Sensors).RowsDefaultCellStyle = val3;
		((DataGridView)DGV_Sensors).RowTemplate.Height = 20;
		((DataGridView)DGV_Sensors).RowTemplate.Resizable = (DataGridViewTriState)2;
		((DataGridView)DGV_Sensors).ScrollBars = (ScrollBars)2;
		((DataGridView)DGV_Sensors).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_Sensors).Size = new Size(681, 223);
		((Control)DGV_Sensors).TabIndex = 8;
		((DataGridViewColumn)ObjectID).DataPropertyName = "ObjectID";
		((DataGridViewColumn)ObjectID).HeaderText = "ObjectID";
		((DataGridViewColumn)ObjectID).MinimumWidth = 8;
		((DataGridViewColumn)ObjectID).Name = "ObjectID";
		((DataGridViewColumn)ObjectID).ReadOnly = true;
		((DataGridViewColumn)ObjectID).Visible = false;
		((DataGridViewColumn)SensorColumn).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)SensorColumn).DataPropertyName = "Sensor";
		((DataGridViewColumn)SensorColumn).FillWeight = 92.72417f;
		((DataGridViewColumn)SensorColumn).HeaderText = "Sensor";
		((DataGridViewColumn)SensorColumn).MinimumWidth = 8;
		((DataGridViewColumn)SensorColumn).Name = "SensorColumn";
		SensorColumn.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)SensorColumn).ToolTipText = "Click name of sensor to access DB VIewer";
		((DataGridViewColumn)SensorType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)SensorType).DataPropertyName = "SensorType";
		((DataGridViewColumn)SensorType).FillWeight = 92.72417f;
		((DataGridViewColumn)SensorType).HeaderText = "Sensor Type";
		((DataGridViewColumn)SensorType).MinimumWidth = 8;
		((DataGridViewColumn)SensorType).Name = "SensorType";
		SensorType.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Active).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)Active).DataPropertyName = "Active";
		((DataGridViewColumn)Active).FillWeight = 121.8274f;
		((DataGridViewColumn)Active).HeaderText = "Active";
		((DataGridViewColumn)Active).MinimumWidth = 60;
		((DataGridViewColumn)Active).Name = "Active";
		((DataGridViewColumn)Active).Width = 60;
		((DataGridViewColumn)Status).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Status).DataPropertyName = "Status";
		((DataGridViewColumn)Status).FillWeight = 92.72417f;
		((DataGridViewColumn)Status).HeaderText = "Status";
		((DataGridViewColumn)Status).MinimumWidth = 8;
		((DataGridViewColumn)Status).Name = "Status";
		((DataGridViewColumn)Status).Resizable = (DataGridViewTriState)1;
		Status.SortMode = (DataGridViewColumnSortMode)0;
		((ToolStrip)TS_Edit).AutoSize = false;
		((ToolStrip)TS_Edit).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)TS_Edit).Dock = (DockStyle)2;
		((ToolStrip)TS_Edit).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)TS_Edit).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)TS_Edit).ImageScalingSize = new Size(24, 24);
		((ToolStrip)TS_Edit).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[3]
		{
			(ToolStripItem)TSB_AddSensor,
			(ToolStripItem)TSB_RemoveSensor,
			(ToolStripItem)TSB_RemoveMCM
		});
		((Control)TS_Edit).Location = new Point(0, 313);
		((Control)TS_Edit).Name = "TS_Edit";
		((Control)TS_Edit).Padding = new Padding(5, 0, 1, 0);
		((Control)TS_Edit).Size = new Size(681, 25);
		((Control)TS_Edit).TabIndex = 14;
		((Control)TS_Edit).Text = "ToolStrip1";
		((ToolStripItem)TSB_AddSensor).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AddSensor).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AddSensor).Image = (Image)componentResourceManager.GetObject("TSB_AddSensor.Image");
		((ToolStripItem)TSB_AddSensor).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AddSensor).Name = "TSB_AddSensor";
		((ToolStripItem)TSB_AddSensor).Padding = new Padding(0, 0, 0, 20);
		((ToolStripItem)TSB_AddSensor).Size = new Size(133, 20);
		((ToolStripItem)TSB_AddSensor).Text = "Add Sensor";
		((ToolStripItem)TSB_RemoveSensor).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_RemoveSensor).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_RemoveSensor).Image = (Image)componentResourceManager.GetObject("TSB_RemoveSensor.Image");
		((ToolStripItem)TSB_RemoveSensor).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_RemoveSensor).Name = "TSB_RemoveSensor";
		((ToolStripItem)TSB_RemoveSensor).Size = new Size(163, 20);
		((ToolStripItem)TSB_RemoveSensor).Text = "Remove Sensor";
		((ToolStripItem)TSB_RemoveMCM).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_RemoveMCM).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_RemoveMCM).Image = (Image)componentResourceManager.GetObject("TSB_RemoveMCM.Image");
		((ToolStripItem)TSB_RemoveMCM).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_RemoveMCM).Name = "TSB_RemoveMCM";
		((ToolStripItem)TSB_RemoveMCM).Size = new Size(152, 20);
		((ToolStripItem)TSB_RemoveMCM).Text = "Remove MCM";
		((Control)Label1).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(3, 27);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(99, 13);
		((Control)Label1).TabIndex = 13;
		((Label)Label1).Text = "Quick selection:";
		((ButtonBase)CB_ECM).AutoSize = true;
		((CheckBox)CB_ECM).CheckAlign = (ContentAlignment)1024;
		((Control)CB_ECM).Location = new Point(279, 26);
		((Control)CB_ECM).Name = "CB_ECM";
		((Control)CB_ECM).RightToLeft = (RightToLeft)1;
		((Control)CB_ECM).Size = new Size(154, 29);
		((Control)CB_ECM).TabIndex = 12;
		((ButtonBase)CB_ECM).Text = "Offensive ECM";
		((ButtonBase)CB_radar).AutoSize = true;
		((CheckBox)CB_radar).CheckAlign = (ContentAlignment)1024;
		((Control)CB_radar).Location = new Point(116, 26);
		((Control)CB_radar).Name = "CB_radar";
		((Control)CB_radar).RightToLeft = (RightToLeft)1;
		((Control)CB_radar).Size = new Size(92, 29);
		((Control)CB_radar).TabIndex = 10;
		((ButtonBase)CB_radar).Text = "Radars";
		((ButtonBase)CB_Sonar).AutoSize = true;
		((CheckBox)CB_Sonar).CheckAlign = (ContentAlignment)1024;
		((Control)CB_Sonar).Location = new Point(200, 26);
		((Control)CB_Sonar).Name = "CB_Sonar";
		((Control)CB_Sonar).RightToLeft = (RightToLeft)1;
		((Control)CB_Sonar).Size = new Size(92, 29);
		((Control)CB_Sonar).TabIndex = 11;
		((ButtonBase)CB_Sonar).Text = "Sonars";
		((Control)CB_ObeyEMCON).Location = new Point(3, 2);
		((Control)CB_ObeyEMCON).Name = "CB_ObeyEMCON";
		((Control)CB_ObeyEMCON).Size = new Size(300, 17);
		((Control)CB_ObeyEMCON).TabIndex = 9;
		((ButtonBase)CB_ObeyEMCON).Text = "Unit obeys EMCON (disables manual sensor control)";
		lbl_decoy_emitter.AutoSize = true;
		((Control)lbl_decoy_emitter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lbl_decoy_emitter).Location = new Point(7, 280);
		((Control)lbl_decoy_emitter).Name = "lbl_decoy_emitter";
		((Control)lbl_decoy_emitter).Size = new Size(123, 25);
		((Control)lbl_decoy_emitter).TabIndex = 15;
		((Label)lbl_decoy_emitter).Text = "Decoy Emitter";
		((ButtonBase)btn_relink_decoy).BackColor = Color.Transparent;
		((Control)btn_relink_decoy).ForeColor = SystemColors.Control;
		((Control)btn_relink_decoy).Location = new Point(531, 285);
		((Control)btn_relink_decoy).Name = "btn_relink_decoy";
		((Control)btn_relink_decoy).Padding = new Padding(5);
		btn_relink_decoy.RoundRadius = 0;
		((Control)btn_relink_decoy).Size = new Size(139, 25);
		((Control)btn_relink_decoy).TabIndex = 16;
		btn_relink_decoy.Text = "Relink Decoy";
		((ComboBox)cmb_relink_decoy).BackColor = Color.Transparent;
		((ComboBox)cmb_relink_decoy).DrawMode = (DrawMode)1;
		((ComboBox)cmb_relink_decoy).DropDownStyle = (ComboBoxStyle)2;
		((Control)cmb_relink_decoy).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)cmb_relink_decoy).FormattingEnabled = true;
		((Control)cmb_relink_decoy).Location = new Point(137, 285);
		((Control)cmb_relink_decoy).Name = "cmb_relink_decoy";
		((Control)cmb_relink_decoy).Size = new Size(388, 27);
		((Control)cmb_relink_decoy).TabIndex = 17;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(681, 338);
		((Control)this).Controls.Add((Control)(object)cmb_relink_decoy);
		((Control)this).Controls.Add((Control)(object)btn_relink_decoy);
		((Control)this).Controls.Add((Control)(object)lbl_decoy_emitter);
		((Control)this).Controls.Add((Control)(object)DGV_Sensors);
		((Control)this).Controls.Add((Control)(object)TS_Edit);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)CB_ECM);
		((Control)this).Controls.Add((Control)(object)CB_radar);
		((Control)this).Controls.Add((Control)(object)CB_Sonar);
		((Control)this).Controls.Add((Control)(object)CB_ObeyEMCON);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(200, 200);
		((Control)this).Name = "UnitSensors";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Sensors for: ";
		((ISupportInitialize)(object)DGV_Sensors).EndInit();
		((Control)TS_Edit).ResumeLayout(false);
		((Control)TS_Edit).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	internal bool IsReferenceUnit(string ObjectID)
	{
		int result;
		if (activeUnit_0 != null)
		{
			if (Operators.CompareString(activeUnit_0.ObjectID, ObjectID, true) == 0)
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
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

	private void UnitSensors_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
		if (((Control)MyProject.Forms.AddSensor).Visible)
		{
			((Form)MyProject.Forms.AddSensor).Close();
		}
	}

	private void UnitSensors_Load(object sender, EventArgs e)
	{
		bool_4 = Client.Realtime;
		Doctrine.EmconChanged += method_3;
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Control)lbl_decoy_emitter).Visible = false;
		((Control)btn_relink_decoy).Visible = false;
		((Control)cmb_relink_decoy).Visible = false;
		if (Client.SelectedUnit.IsActiveUnit)
		{
			activeUnit_0 = (ActiveUnit)Client.SelectedUnit;
			if (((ActiveUnit)Client.SelectedUnit).IsDecoy)
			{
				((Control)lbl_decoy_emitter).Visible = true;
				((Control)btn_relink_decoy).Visible = true;
				((Control)cmb_relink_decoy).Visible = true;
				((Label)lbl_decoy_emitter).Text = ((ActiveUnit)Client.SelectedUnit).UnitType_String;
				method_2();
			}
		}
		((Form)this).Text = "Sensors for: " + Client.SelectedUnit.Name;
		Client.SelectedUnitChanged += method_4;
	}

	private void method_2()
	{
		DataTable dataTable = new DataTable();
		switch (((ActiveUnit)Client.SelectedUnit).UnitType)
		{
		default:
			return;
		case GlobalVariables.ActiveUnitType.Aircraft:
			dataTable = Client.CurrentScenario.Cache_Aircraft_DT;
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			dataTable = Client.CurrentScenario.Cache_Ships_DT;
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			dataTable = Client.CurrentScenario.Cache_Subs_DT;
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			dataTable = Client.CurrentScenario.Cache_Facilities_DT;
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			dataTable = Client.CurrentScenario.Cache_GroundUnits_DT;
			break;
		case GlobalVariables.ActiveUnitType.Aimpoint:
		case GlobalVariables.ActiveUnitType.Weapon:
		case GlobalVariables.ActiveUnitType.Satellite:
			return;
		}
		((ComboBox)cmb_relink_decoy).DataSource = dataTable;
		((ListControl)cmb_relink_decoy).DisplayMember = "LongName";
	}

	private void UnitSensors_Shown(object sender, EventArgs e)
	{
		if (!((DataGridView)DGV_Sensors).ReadOnly)
		{
			((DataGridView)DGV_Sensors).ForeColor = Color.Black;
			((DataGridView)DGV_Sensors).RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		else
		{
			((DataGridView)DGV_Sensors).ForeColor = Color.Gray;
			((DataGridView)DGV_Sensors).RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		BuildForm();
		BuildForm();
	}

	private void UnitSensors_SizeChanged(object sender, EventArgs e)
	{
		BuildForm();
	}

	private void method_3(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_5, bool bool_6, bool bool_7, bool bool_8)
	{
		if (!bool_8 && scenarioObject_0 != null && scenarioObject_0.IsActiveUnit && (!bool_5 || scenarioObject_0 == Client.SelectedUnit) && nullable_0.HasValue && ((Control)this).Visible && scenarioObject_0.IsActiveUnit && scenarioObject_0 == activeUnit_0)
		{
			BuildForm();
		}
	}

	private void method_4(Module_Unit.Unit unit_0)
	{
		if (((Control)this).Visible && unit_0 != null && unit_0.IsActiveUnit)
		{
			if (bool_4 && activeUnit_0 != null && activeUnit_0 != unit_0 && Operators.CompareString(unit_0.ObjectID, activeUnit_0.ObjectID, true) == 0)
			{
				activeUnit_0 = (ActiveUnit)unit_0;
				return;
			}
			activeUnit_0 = (ActiveUnit)unit_0;
			BuildForm();
		}
	}

	public void BuildForm()
	{
		BuildForm_Detailed();
		method_5();
	}

	private void method_5()
	{
		if (Information.IsNothing((object)activeUnit_0))
		{
			return;
		}
		list_0.Clear();
		list_1.Clear();
		OECM.Clear();
		if (!activeUnit_0.IsActiveUnit)
		{
			return;
		}
		ActiveUnit activeUnit = activeUnit_0;
		Sensor[] array = activeUnit.Sensors_ReadOnly();
		foreach (Sensor sensor in array)
		{
			if (sensor.Type == Sensor.Sensor_Type.Radar)
			{
				list_0.Add(sensor);
			}
		}
		IEnumerable<Sensor> source = list_0.Where([SpecialName] (Sensor theS) => theS.IsActive());
		if (source.Count() == 0)
		{
			((CheckBox)CB_radar).Checked = false;
		}
		else if (source.Count() == list_0.Count)
		{
			((CheckBox)CB_radar).Checked = true;
		}
		else
		{
			((CheckBox)CB_radar).CheckState = (CheckState)2;
		}
		Sensor[] array2 = activeUnit.Sensors_ReadOnly();
		foreach (Sensor sensor2 in array2)
		{
			if (sensor2.IsSonar)
			{
				list_1.Add(sensor2);
			}
		}
		IEnumerable<Sensor> source2 = list_1.Where([SpecialName] (Sensor theS) => theS.IsActive());
		if (source2.Count() != 0)
		{
			if (source2.Count() == list_1.Count)
			{
				((CheckBox)CB_Sonar).Checked = true;
			}
			else
			{
				((CheckBox)CB_Sonar).CheckState = (CheckState)2;
			}
		}
		else
		{
			((CheckBox)CB_Sonar).Checked = false;
		}
		Sensor[] array3 = activeUnit.Sensors_ReadOnly();
		foreach (Sensor sensor3 in array3)
		{
			if (sensor3.IsOECM)
			{
				OECM.Add(sensor3);
			}
		}
		IEnumerable<Sensor> source3 = OECM.Where([SpecialName] (Sensor theS) => theS.IsActive());
		if (source3.Count() != 0)
		{
			if (source3.Count() == OECM.Count)
			{
				((CheckBox)CB_ECM).Checked = true;
			}
			else
			{
				((CheckBox)CB_ECM).CheckState = (CheckState)2;
			}
		}
		else
		{
			((CheckBox)CB_ECM).Checked = false;
		}
		((Control)CB_radar).Enabled = !((DataGridView)DGV_Sensors).ReadOnly;
		((Control)CB_Sonar).Enabled = !((DataGridView)DGV_Sensors).ReadOnly;
		((Control)CB_ECM).Enabled = !((DataGridView)DGV_Sensors).ReadOnly;
		if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
		{
			if (!((ActiveUnit)Client.SelectedUnit).HasRadarSensor && Client.SelectedUnit.IsActiveUnit)
			{
				((Control)CB_radar).Enabled = false;
			}
			if (!((ActiveUnit)Client.SelectedUnit).HasSonarSensor)
			{
				((Control)CB_Sonar).Enabled = false;
			}
			if (!((ActiveUnit)Client.SelectedUnit).HasOECMSensor)
			{
				((Control)CB_ECM).Enabled = false;
			}
		}
	}

	public void BuildForm_Detailed()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		try
		{
			if (!((Control)this).Visible)
			{
				return;
			}
			((Control)TS_Edit).Visible = Client.AllowEditModeActions;
			if (activeUnit_0 == null || !activeUnit_0.IsActiveUnit)
			{
				return;
			}
			List<Sensor> list = activeUnit_0.Sensors_ReadOnly().ToList();
			List<Sensor> list2 = activeUnit_0.MineCountermeasures.ToList();
			if (list == null || list2 == null)
			{
				return;
			}
			method_9(list, list2);
			((Form)this).Text = "Sensors for: " + activeUnit_0.Name;
			((DataGridView)DGV_Sensors).DataSource = dataTable_0;
			foreach (DataGridViewColumn item in (BaseCollection)((DataGridView)DGV_Sensors).Columns)
			{
				item.SortMode = (DataGridViewColumnSortMode)0;
			}
			if (((DataGridView)DGV_Sensors).Columns["CanBeActive"] != null)
			{
				((DataGridView)DGV_Sensors).Columns["CanBeActive"].Visible = false;
			}
			if (((DataGridView)DGV_Sensors).Columns["Order#"] != null)
			{
				((DataGridView)DGV_Sensors).Columns["Order#"].Visible = false;
			}
			((DataGridView)DGV_Sensors).Columns["ObjectID"].Visible = false;
			((DataGridView)DGV_Sensors).Columns["MCM"].Visible = false;
			((DataGridView)DGV_Sensors).Columns["POD"].Visible = false;
			foreach (DataGridViewRow item2 in (IEnumerable)((DataGridView)DGV_Sensors).Rows)
			{
				DataGridViewRow val = item2;
				if (!Conversions.ToBoolean(val.Cells["MCM"].Value))
				{
					if (!list[Conversions.ToInteger(val.Cells["Order#"].Value)].CanBeActive)
					{
						val.ReadOnly = true;
					}
				}
				else if (!list2[Conversions.ToInteger(val.Cells["Order#"].Value)].CanBeActive)
				{
					val.ReadOnly = true;
				}
				Conversions.ToBoolean(val.Cells["POD"].Value);
			}
			((DataGridView)DGV_Sensors).Columns["Active"].Width = 40;
			((DataGridView)DGV_Sensors).Columns["SensorType"].HeaderText = "Sensor Type";
			method_10(list, list2);
			((CheckBox)CB_ObeyEMCON).Checked = activeUnit_0.Sensory.ObeysEMCON;
			((DataGridView)DGV_Sensors).ReadOnly = activeUnit_0.Sensory.ObeysEMCON;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200107B", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshForm()
	{
		if (bool_3)
		{
			return;
		}
		bool_3 = true;
		try
		{
			if (!Information.IsNothing((object)activeUnit_0))
			{
				if (activeUnit_0.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
				{
					BuildForm();
				}
				else
				{
					((DataGridView)DGV_Sensors).Columns.Clear();
				}
			}
			else
			{
				((DataGridView)DGV_Sensors).Columns.Clear();
			}
			((Control)TS_Edit).Visible = Client.AllowEditModeActions;
			if (bool_4)
			{
				method_5();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200107", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		bool_3 = false;
	}

	private void method_6(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			DataGridViewColumn val = ((DataGridView)DGV_Sensors).Columns[e.ColumnIndex];
			if (e.RowIndex == -1 || e.ColumnIndex == -1 || ((DataGridView)DGV_Sensors).ReadOnly || ((DataGridView)DGV_Sensors).Rows.Count == 0)
			{
				return;
			}
			DataGridViewRow val2 = ((DataGridView)DGV_Sensors).Rows[e.RowIndex];
			Sensor sensor = null;
			sensor = (Conversions.ToBoolean(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["MCM"].Value) ? activeUnit_0.MineCountermeasures[Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value)] : activeUnit_0.Sensors_ReadOnly()[Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value)]);
			if (sensor.Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				val2.Selected = false;
			}
			List<Sensor> list = null;
			if (bool_4)
			{
				list = new List<Sensor>();
			}
			sensor = ((!Conversions.ToBoolean(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["MCM"].Value)) ? activeUnit_0.Sensors_ReadOnly()[Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value)] : activeUnit_0.MineCountermeasures[Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value)]);
			if (sensor.Status != PlatformComponent._ComponentStatus.Operational)
			{
				return;
			}
			if (Operators.CompareString(val.Name, "Active", true) == 0)
			{
				int num = Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value);
				if (!activeUnit_0.Sensors_ReadOnly()[num].CanBeActive || !sensor.CanBeActive)
				{
					return;
				}
				if (!Conversions.ToBoolean(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value) && !sensor.IsActive())
				{
					sensor.GoActive();
					((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value = true;
					if (bool_4)
					{
						list.Add(sensor);
						RTMPPendingUIEvent = Client.RealtimeTerminal.SendSensorActivation(activeUnit_0, list, activate: true);
					}
				}
				else if (Conversions.ToBoolean(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value) && sensor.IsActive())
				{
					sensor.GoPassive();
					((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value = false;
					if (bool_4)
					{
						list.Add(sensor);
						RTMPPendingUIEvent = Client.RealtimeTerminal.SendSensorActivation(activeUnit_0, list, activate: false);
					}
				}
			}
			else if (Conversions.ToBoolean(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value) && sensor.IsActive())
			{
				sensor.GoPassive();
				((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value = false;
				if (bool_4)
				{
					list.Add(sensor);
					RTMPPendingUIEvent = Client.RealtimeTerminal.SendSensorActivation(activeUnit_0, list, activate: false);
				}
			}
			if (activeUnit_0.IsAircraft)
			{
				int num2 = Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value);
				Sensor[] array = activeUnit_0.Sensors_ReadOnly();
				string objectID = array[num2].ObjectID;
				for (int i = array.Length - 1; i >= 0; i += -1)
				{
					sensor = array[i];
					if (Operators.CompareString(sensor.ObjectID, objectID, true) == 0)
					{
						((DataGridView)DGV_Sensors).Rows[i].Cells["Active"].Value = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value);
					}
				}
			}
			int mustRefreshMainForm;
			if (bool_4)
			{
				if ((long)RTMPPendingUIEvent == 0L)
				{
					mustRefreshMainForm = 1;
				}
				else
				{
					Timer_Refresh.Start();
					mustRefreshMainForm = 1;
				}
			}
			else
			{
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200108", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_7(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			_ = ((DataGridView)DGV_Sensors).Columns[e.ColumnIndex];
			_ = ((DataGridView)DGV_Sensors).Rows[e.RowIndex];
			Sensor sensor = null;
			if (e.ColumnIndex != 0)
			{
				if (!((DataGridView)DGV_Sensors).ReadOnly)
				{
					_ = ((DataGridView)DGV_Sensors).Rows.Count;
				}
				return;
			}
			sensor = ((!Conversions.ToBoolean(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["MCM"].Value)) ? activeUnit_0.Sensors_ReadOnly()[Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value)] : activeUnit_0.MineCountermeasures[Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value)]);
			int dBID = sensor.DBID;
			if (dBID > 0)
			{
				Client.smethod_17("Sensor", dBID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200109", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8(object sender, DataGridViewCellEventArgs e)
	{
		BuildForm();
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
	}

	private void method_9(List<Sensor> list_2, List<Sensor> list_3)
	{
		if (list_2 == null || list_3 == null)
		{
			return;
		}
		((DataGridView)DGV_Sensors).DataSource = null;
		((DataGridView)DGV_Sensors).Rows.Clear();
		dataTable_0.Columns.Clear();
		dataTable_0.Rows.Clear();
		dataTable_0.Columns.Add("Sensor", typeof(string));
		dataTable_0.Columns.Add("SensorType", typeof(string));
		dataTable_0.Columns.Add("Active", typeof(bool));
		dataTable_0.Columns.Add("Status", typeof(string));
		dataTable_0.Columns.Add("ObjectID", typeof(string));
		dataTable_0.Columns.Add("Order#", typeof(int));
		dataTable_0.Columns.Add("CanBeActive", typeof(bool));
		dataTable_0.Columns.Add("MCM", typeof(bool));
		dataTable_0.Columns.Add("POD", typeof(bool));
		int num = list_2.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor sensor = list_2[i];
			DataRow dataRow = dataTable_0.NewRow();
			dataRow["ObjectID"] = sensor.ObjectID;
			dataRow["Order#"] = i;
			dataRow["CanBeActive"] = sensor.CanBeActive;
			dataRow["Sensor"] = Misc.RemoveHiddenString(sensor.Name + (string)Interaction.IIf(sensor.IsSensorInMount, (object)"^", (object)""));
			dataRow["SensorType"] = sensor.RoleDescription;
			dataRow["Active"] = sensor.IsActive();
			if (sensor.Status == PlatformComponent._ComponentStatus.Operational && sensor.ReasonForInoperative.Response != PlatformComponent.BooleanResponse.ResponseTrue)
			{
				dataRow["Status"] = "Not operating (" + sensor.ReasonForInoperative.ResponseString + ")";
			}
			else
			{
				dataRow["Status"] = sensor.Status.ToString();
			}
			dataRow["MCM"] = false;
			dataRow["POD"] = false;
			if (!activeUnit_0.MineCountermeasures.Contains(sensor))
			{
				if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).Loadout != null && sensor.IsSensorInLoadout)
				{
					dataRow["SensorType"] = "^" + sensor.RoleDescription;
					dataRow["POD"] = true;
				}
				dataTable_0.Rows.Add(dataRow);
			}
		}
		if (list_3.Count <= 0)
		{
			return;
		}
		int num2 = list_3.Count - 1;
		for (int j = 0; j <= num2; j++)
		{
			Sensor sensor = list_3[j];
			DataRow dataRow = dataTable_0.NewRow();
			dataRow["ObjectID"] = sensor.ObjectID;
			dataRow["Order#"] = j;
			dataRow["CanBeActive"] = sensor.CanBeActive;
			dataRow["Sensor"] = Misc.RemoveHiddenString(sensor.Name);
			dataRow["SensorType"] = "*" + sensor.RoleDescription;
			dataRow["Active"] = sensor.IsActive();
			string text = sensor.Status.ToString();
			if (sensor.Status == PlatformComponent._ComponentStatus.Operational && sensor.ReasonForInoperative.Response != PlatformComponent.BooleanResponse.ResponseTrue)
			{
				text = "Not operating (" + sensor.ReasonForInoperative.ResponseString + ")";
			}
			else if (sensor.IsNeutralized == true)
			{
				text += " - JAMMED";
			}
			dataRow["Status"] = text;
			dataRow["MCM"] = true;
			dataRow["POD"] = false;
			if (activeUnit_0.IsAircraft && sensor.IsSensorInLoadout && sensor.IsSensorInLoadout)
			{
				dataRow["POD"] = true;
				dataRow["SensorType"] = "^*" + sensor.RoleDescription;
			}
			dataTable_0.Rows.Add(dataRow);
		}
	}

	private void method_10(List<Sensor> list_2, List<Sensor> list_3)
	{
		int num = ((DataGridView)DGV_Sensors).Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataGridViewRow val = ((DataGridView)DGV_Sensors).Rows[i];
			Sensor sensor = null;
			sensor = (Conversions.ToBoolean(val.Cells["MCM"].Value) ? list_3[Conversions.ToInteger(val.Cells["Order#"].Value)] : list_2[Conversions.ToInteger(val.Cells["Order#"].Value)]);
			if (sensor.Status == PlatformComponent._ComponentStatus.Operational)
			{
				val.DefaultCellStyle.ForeColor = Color.LightGray;
			}
			else
			{
				val.DefaultCellStyle.ForeColor = GetComponentDamageColor(sensor);
				val.ReadOnly = true;
			}
			DataGridViewCell val2 = ((DataGridView)DGV_Sensors).Rows[Conversions.ToInteger(val.Cells["Order#"].Value)].Cells["Active"];
			if (!sensor.CanBeActive)
			{
				val2.ReadOnly = true;
				val2.Value = false;
			}
			try
			{
				DataGridViewCell val3 = val.Cells[0];
				if (sensor.DBID > 0)
				{
					val3.Style.ForeColor = Color.LightBlue;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (bool_3)
		{
			return;
		}
		bool_3 = true;
		List<Sensor> list = null;
		if (bool_4)
		{
			list = new List<Sensor>();
		}
		bool flag;
		if (!(flag = ((CheckBox)CB_radar).Checked))
		{
			foreach (Sensor item in list_0)
			{
				if (!item.IsPureIlluminator && item.IsActive())
				{
					item.GoPassive();
					if (bool_4)
					{
						list.Add(item);
					}
				}
			}
		}
		else if (flag)
		{
			foreach (Sensor item2 in list_0)
			{
				if (!item2.IsPureIlluminator && !item2.IsActive())
				{
					item2.GoActive();
					if (bool_4)
					{
						list.Add(item2);
					}
				}
			}
		}
		if (bool_4)
		{
			RTMPPendingUIEvent = Client.RealtimeTerminal.SendSensorActivation(activeUnit_0, list, ((CheckBox)CB_radar).Checked);
		}
		BuildForm_Detailed();
		bool_3 = false;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
	}

	private void method_12(object sender, EventArgs e)
	{
		if (bool_3)
		{
			return;
		}
		bool_3 = true;
		List<Sensor> list = null;
		if (bool_4)
		{
			list = new List<Sensor>();
		}
		bool flag;
		if (!(flag = ((CheckBox)CB_Sonar).Checked))
		{
			foreach (Sensor item in list_1)
			{
				if (!item.IsPureIlluminator && item.IsActive())
				{
					item.GoPassive();
					if (bool_4)
					{
						list.Add(item);
					}
				}
			}
		}
		else if (flag)
		{
			foreach (Sensor item2 in list_1)
			{
				if (!item2.IsPureIlluminator && (!item2.IsActive() & item2.CanBeActive))
				{
					item2.GoActive();
					if (bool_4)
					{
						list.Add(item2);
					}
				}
			}
		}
		if (bool_4)
		{
			RTMPPendingUIEvent = Client.RealtimeTerminal.SendSensorActivation(activeUnit_0, list, ((CheckBox)CB_Sonar).Checked);
		}
		BuildForm_Detailed();
		bool_3 = false;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
	}

	private void method_13(object sender, EventArgs e)
	{
		if (bool_3)
		{
			return;
		}
		bool_3 = true;
		List<Sensor> list = null;
		if (bool_4)
		{
			list = new List<Sensor>();
		}
		bool flag;
		if (!(flag = ((CheckBox)CB_ECM).Checked))
		{
			foreach (Sensor item in OECM)
			{
				if (item.IsActive())
				{
					item.GoPassive();
					if (bool_4)
					{
						list.Add(item);
					}
				}
			}
		}
		else if (flag)
		{
			foreach (Sensor item2 in OECM)
			{
				if (!item2.IsActive())
				{
					item2.GoActive();
					if (bool_4)
					{
						list.Add(item2);
					}
				}
			}
		}
		if (bool_4)
		{
			RTMPPendingUIEvent = Client.RealtimeTerminal.SendSensorActivation(activeUnit_0, list, ((CheckBox)CB_ECM).Checked);
		}
		BuildForm_Detailed();
		bool_3 = false;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
	}

	private void method_14(object sender, EventArgs e)
	{
		MyProject.Forms.AddSensor.FormThatCalledMe = (Form)(object)this;
		((Control)MyProject.Forms.AddSensor).Show();
		Client.MustRefreshMainForm = true;
	}

	private void method_15(object sender, DataGridViewCellPaintingEventArgs e)
	{
		if (e.RowIndex > -1 && e.ColumnIndex == ((DataGridView)DGV_Sensors).Columns.IndexOf(((DataGridView)DGV_Sensors).Columns["Active"]))
		{
			if (!Conversions.ToBoolean(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["CanBeActive"].Value))
			{
				e.Paint(e.ClipBounds, (DataGridViewPaintParts)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
			else if (Operators.CompareString(Conversions.ToString(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Status"].Value), "Damaged", true) == 0 || Operators.CompareString(Conversions.ToString(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Status"].Value), "Destroyed", true) == 0)
			{
				e.Paint(e.ClipBounds, (DataGridViewPaintParts)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		if (((DataGridView)DGV_Sensors).ReadOnly)
		{
			((DataGridView)DGV_Sensors).ForeColor = Color.Gray;
			((DataGridView)DGV_Sensors).RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		else
		{
			((DataGridView)DGV_Sensors).ForeColor = Color.Black;
			((DataGridView)DGV_Sensors).RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Sensors).SelectedRows).Count <= 0)
		{
			return;
		}
		string_0 = Conversions.ToString(((DataGridView)DGV_Sensors).SelectedRows[0].Cells["ObjectID"].Value);
		if (Operators.CompareString(Conversions.ToString(((DataGridView)DGV_Sensors).SelectedRows[0].Cells["POD"].Value), "True", true) != 0)
		{
			if (Operators.CompareString(Conversions.ToString(((DataGridView)DGV_Sensors).SelectedRows[0].Cells["MCM"].Value), "True", true) != 0)
			{
				((ToolStripItem)TSB_RemoveMCM).Visible = false;
				((ToolStripItem)TSB_RemoveSensor).Visible = true;
			}
			else
			{
				((ToolStripItem)TSB_RemoveMCM).Visible = true;
				((ToolStripItem)TSB_RemoveSensor).Visible = false;
			}
		}
		else
		{
			((ToolStripItem)TSB_RemoveMCM).Visible = false;
			((ToolStripItem)TSB_RemoveSensor).Visible = false;
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(string_0) || !activeUnit_0.IsActiveUnit)
		{
			return;
		}
		ActiveUnit activeUnit = activeUnit_0;
		Sensor[] array = activeUnit.Sensors_ReadOnly();
		Sensor sensor2 = default(Sensor);
		foreach (Sensor sensor in array)
		{
			if (Operators.CompareString(sensor.ObjectID, string_0, true) == 0)
			{
				sensor2 = sensor;
				break;
			}
		}
		int mustRefreshMainForm;
		if (!Information.IsNothing((object)sensor2))
		{
			activeUnit.RemoveSensor(sensor2);
			BuildForm();
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void method_19(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(string_0) || !activeUnit_0.IsActiveUnit)
		{
			return;
		}
		ActiveUnit activeUnit = activeUnit_0;
		Sensor sensor = null;
		if (activeUnit.MineCountermeasures.Count > 0)
		{
			foreach (Sensor mineCountermeasure in activeUnit.MineCountermeasures)
			{
				if (Operators.CompareString(mineCountermeasure.ObjectID, string_0, true) == 0)
				{
					sensor = mineCountermeasure;
					break;
				}
			}
		}
		int mustRefreshMainForm;
		if (!Information.IsNothing((object)sensor))
		{
			activeUnit.RemoveSensor(sensor);
			BuildForm();
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void method_20(object sender, EventArgs e)
	{
		if (!bool_3)
		{
			bool_3 = true;
			activeUnit_0.Sensory.ObeysEMCON = ((CheckBox)CB_ObeyEMCON).Checked;
			((DataGridView)DGV_Sensors).ReadOnly = activeUnit_0.Sensory.ObeysEMCON;
			if (bool_4)
			{
				RTMPPendingUIEvent = Client.RealtimeTerminal.SendSensorEMCONUpdate(activeUnit_0, activeUnit_0.Sensory.ObeysEMCON);
			}
			MyProject.Forms.MainForm.RightColumn1.EmconControl1.RefreshPanel(v: true);
			BuildForm();
			if (bool_4 && (long)RTMPPendingUIEvent != 0L)
			{
				Timer_Refresh.Start();
			}
			bool_3 = false;
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		if (!bool_3)
		{
			RefreshForm();
			Timer_Refresh.Stop();
		}
	}

	private void UnitSensors_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 120 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 32))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void UnitSensors_FormClosed(object sender, FormClosedEventArgs e)
	{
		Client.SelectedUnitChanged -= method_4;
		Doctrine.EmconChanged -= method_3;
	}

	private void method_22(object sender, EventArgs e)
	{
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		using PooledList<ActiveUnit>.Enumerator enumerator = Client.SelectedUnit.get_UnitSide(SetSideOnly: false).Units.GetEnumerator();
		ActiveUnit current;
		do
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				continue;
			}
			return;
		}
		while (Operators.CompareString(current.ObjectID, Client.SelectedUnit.ObjectID, true) != 0);
		switch (current.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			try
			{
				Scenario theScen = Client.CurrentScenario;
				Aircraft theAircraft = (Aircraft)current;
				DBFunctions.GetAircraft(ref theScen, ref theAircraft, Conversions.ToInteger(((DataRowView)((ComboBox)cmb_relink_decoy).SelectedItem)[0]));
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				DarkMessageBox.ShowError("Error: " + ex10.Message, "Error");
				ProjectData.ClearProjectError();
			}
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			try
			{
				Scenario theScen = Client.CurrentScenario;
				Ship theShip = (Ship)current;
				DBFunctions.GetShip(ref theScen, ref theShip, Conversions.ToInteger(((DataRow)((ComboBox)cmb_relink_decoy).SelectedItem).ItemArray[0]));
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				DarkMessageBox.ShowError("Error: " + ex8.Message, "Error");
				ProjectData.ClearProjectError();
			}
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			try
			{
				Scenario theScen = Client.CurrentScenario;
				Submarine theSub = (Submarine)current;
				DBFunctions.GetSubmarine(ref theScen, ref theSub, Conversions.ToInteger(((DataRow)((ComboBox)cmb_relink_decoy).SelectedItem).ItemArray[0]));
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				DarkMessageBox.ShowError("Error: " + ex6.Message, "Error");
				ProjectData.ClearProjectError();
			}
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			try
			{
				Scenario theScen = Client.CurrentScenario;
				Facility theFac = (Facility)current;
				DBFunctions.GetFacility(ref theScen, ref theFac, Conversions.ToInteger(((DataRow)((ComboBox)cmb_relink_decoy).SelectedItem).ItemArray[0]));
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				DarkMessageBox.ShowError("Error: " + ex4.Message, "Error");
				ProjectData.ClearProjectError();
			}
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			try
			{
				Scenario theScen = Client.CurrentScenario;
				Vehicle theVehicle = (Vehicle)current;
				DBFunctions.GetVehicle(ref theScen, ref theVehicle, Conversions.ToInteger(((DataRow)((ComboBox)cmb_relink_decoy).SelectedItem).ItemArray[0]));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)0, (object)null);
				ProjectData.ClearProjectError();
			}
			break;
		}
		current.Weaponry.Disarm();
		current.Name = "DECOY " + ((DataRowView)((ComboBox)cmb_relink_decoy).SelectedItem)[2].ToString();
		activeUnit_0 = current;
		BuildForm();
	}

	static UnitSensors()
	{
		Class72.smethod_20();
	}
}

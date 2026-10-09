using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitComms : DarkSecondaryFormBase, GInterface0
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddSensor")]
	private ToolStripButton _TSB_AddSensor;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_JammCD")]
	private ToolStripButton _TSB_JammCD;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer_Refresh")]
	private Timer timer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_Comms")]
	private DarkDataGridView _DGV_Comms;

	[AccessedThroughProperty("BtnViewTransQueue")]
	[CompilerGenerated]
	private DarkUIButton _BtnViewTransQueue;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton2")]
	private ToolStripButton _ToolStripButton2;

	[CompilerGenerated]
	private bool bool_2;

	private DataTable dataTable_0;

	private bool bool_3;

	private string string_0;

	private ActiveUnit activeUnit_0;

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
			EventHandler eventHandler = method_7;
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

	internal virtual ToolStripButton TSB_JammCD
	{
		[CompilerGenerated]
		get
		{
			return _TSB_JammCD;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			ToolStripButton val = _TSB_JammCD;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_JammCD = value;
			val = _TSB_JammCD;
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
			EventHandler eventHandler = method_13;
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

	internal virtual DarkDataGridView DGV_Comms
	{
		[CompilerGenerated]
		get
		{
			return _DGV_Comms;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_3);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_4);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(method_5);
			EventHandler eventHandler = method_10;
			DarkDataGridView darkDataGridView = _DGV_Comms;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick -= val;
				((DataGridView)darkDataGridView).CellContentClick -= val2;
				((DataGridView)darkDataGridView).CellContentDoubleClick -= val3;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_DGV_Comms = value;
			darkDataGridView = _DGV_Comms;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick += val;
				((DataGridView)darkDataGridView).CellContentClick += val2;
				((DataGridView)darkDataGridView).CellContentDoubleClick += val3;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ObjectID")]
	internal virtual DataGridViewTextBoxColumn ObjectID { get; set; }

	[field: AccessedThroughProperty("SensorColumn")]
	internal virtual DataGridViewTextBoxColumn SensorColumn { get; set; }

	[field: AccessedThroughProperty("SensorType")]
	internal virtual DataGridViewTextBoxColumn SensorType { get; set; }

	[field: AccessedThroughProperty("Status")]
	internal virtual DataGridViewTextBoxColumn Status { get; set; }

	[field: AccessedThroughProperty("ToolStripButton1")]
	internal virtual ToolStripButton ToolStripButton1 { get; set; }

	internal virtual DarkUIButton BtnViewTransQueue
	{
		[CompilerGenerated]
		get
		{
			return _BtnViewTransQueue;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIButton darkUIButton = _BtnViewTransQueue;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnViewTransQueue = value;
			darkUIButton = _BtnViewTransQueue;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton2
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			ToolStripButton val = _ToolStripButton2;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton2 = value;
			val = _ToolStripButton2;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
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

	public ActiveUnit theSelectedUnit
	{
		get
		{
			return activeUnit_0;
		}
		set
		{
			bool flag = default(bool);
			if (value != null)
			{
				flag = value != activeUnit_0;
			}
			activeUnit_0 = value;
			if (flag && ((Control)this).Visible)
			{
				BuildForm();
			}
		}
	}

	public UnitComms()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(UnitComms_FormClosing);
		((Form)this).Load += UnitComms_Load;
		((Form)this).Shown += UnitComms_Shown;
		((Control)this).SizeChanged += UnitComms_SizeChanged;
		((Control)this).KeyDown += new KeyEventHandler(UnitComms_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(UnitComms_FormClosed);
		RTMPEnabled = true;
		dataTable_0 = new DataTable();
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
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
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
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Expected O, but got Unknown
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0708: Expected O, but got Unknown
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UnitComms));
		Timer_Refresh = new Timer(icontainer_1);
		DGV_Comms = new DarkDataGridView();
		ObjectID = new DataGridViewTextBoxColumn();
		SensorColumn = new DataGridViewTextBoxColumn();
		SensorType = new DataGridViewTextBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		TS_Edit = new DarkToolStrip();
		TSB_AddSensor = new ToolStripButton();
		ToolStripButton2 = new ToolStripButton();
		TSB_JammCD = new ToolStripButton();
		ToolStripButton1 = new ToolStripButton();
		BtnViewTransQueue = new DarkUIButton();
		((ISupportInitialize)(object)DGV_Comms).BeginInit();
		((Control)TS_Edit).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridView)DGV_Comms).AllowUserToAddRows = false;
		((DataGridView)DGV_Comms).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Comms).AllowUserToOrderColumns = true;
		((Control)DGV_Comms).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_Comms).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		((DataGridView)DGV_Comms).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		((DataGridView)DGV_Comms).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Comms).BorderStyle = (BorderStyle)2;
		((Control)DGV_Comms).CausesValidation = false;
		((DataGridView)DGV_Comms).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Comms).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Comms).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_Comms).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_Comms).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)ObjectID,
			(DataGridViewColumn)SensorColumn,
			(DataGridViewColumn)SensorType,
			(DataGridViewColumn)Status
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.LightGray;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Comms).DefaultCellStyle = val2;
		((DataGridView)DGV_Comms).EnableHeadersVisualStyles = false;
		((Control)DGV_Comms).Location = new Point(0, 44);
		((DataGridView)DGV_Comms).MultiSelect = false;
		((Control)DGV_Comms).Name = "DGV_Comms";
		((DataGridView)DGV_Comms).RowHeadersVisible = false;
		((DataGridView)DGV_Comms).RowHeadersWidth = 4;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(60, 63, 65);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Comms).RowsDefaultCellStyle = val3;
		((DataGridView)DGV_Comms).RowTemplate.Height = 20;
		((DataGridView)DGV_Comms).RowTemplate.Resizable = (DataGridViewTriState)2;
		((DataGridView)DGV_Comms).ScrollBars = (ScrollBars)2;
		((DataGridView)DGV_Comms).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_Comms).Size = new Size(681, 301);
		((Control)DGV_Comms).TabIndex = 8;
		((DataGridViewColumn)ObjectID).DataPropertyName = "ObjectID";
		((DataGridViewColumn)ObjectID).HeaderText = "ObjectID";
		((DataGridViewColumn)ObjectID).MinimumWidth = 8;
		((DataGridViewColumn)ObjectID).Name = "ObjectID";
		((DataGridViewColumn)ObjectID).ReadOnly = true;
		((DataGridViewColumn)ObjectID).Visible = false;
		((DataGridViewColumn)SensorColumn).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)SensorColumn).DataPropertyName = "Sensor";
		((DataGridViewColumn)SensorColumn).FillWeight = 92.72417f;
		((DataGridViewColumn)SensorColumn).HeaderText = "Device";
		((DataGridViewColumn)SensorColumn).MinimumWidth = 8;
		((DataGridViewColumn)SensorColumn).Name = "SensorColumn";
		SensorColumn.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)SensorType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)SensorType).DataPropertyName = "SensorType";
		((DataGridViewColumn)SensorType).FillWeight = 92.72417f;
		((DataGridViewColumn)SensorType).HeaderText = "Device Type";
		((DataGridViewColumn)SensorType).MinimumWidth = 8;
		((DataGridViewColumn)SensorType).Name = "SensorType";
		SensorType.SortMode = (DataGridViewColumnSortMode)0;
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
			(ToolStripItem)ToolStripButton2,
			(ToolStripItem)TSB_JammCD
		});
		((Control)TS_Edit).Location = new Point(0, 362);
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
		((ToolStripItem)TSB_AddSensor).Size = new Size(188, 20);
		((ToolStripItem)TSB_AddSensor).Text = "Add Comm device";
		((ToolStripItem)ToolStripButton2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton2).Image = (Image)componentResourceManager.GetObject("ToolStripButton2.Image");
		((ToolStripItem)ToolStripButton2).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton2).Name = "ToolStripButton2";
		((ToolStripItem)ToolStripButton2).Size = new Size(218, 20);
		((ToolStripItem)ToolStripButton2).Text = "Remove Comm device";
		((ToolStripItem)TSB_JammCD).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_JammCD).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_JammCD).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_JammCD).Name = "TSB_JammCD";
		((ToolStripItem)TSB_JammCD).Size = new Size(177, 20);
		((ToolStripItem)TSB_JammCD).Text = "Jamm Comm device";
		((ToolStripItem)ToolStripButton1).Name = "ToolStripButton1";
		((ToolStripItem)ToolStripButton1).Size = new Size(23, 23);
		((Control)BtnViewTransQueue).Anchor = (AnchorStyles)9;
		((Control)BtnViewTransQueue).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BtnViewTransQueue).Location = new Point(451, 6);
		((Control)BtnViewTransQueue).Name = "BtnViewTransQueue";
		((Control)BtnViewTransQueue).Padding = new Padding(5);
		BtnViewTransQueue.RoundRadius = 0;
		((Control)BtnViewTransQueue).Size = new Size(230, 32);
		((Control)BtnViewTransQueue).TabIndex = 19;
		BtnViewTransQueue.Text = "Comm Data";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(681, 387);
		((Control)this).Controls.Add((Control)(object)BtnViewTransQueue);
		((Control)this).Controls.Add((Control)(object)DGV_Comms);
		((Control)this).Controls.Add((Control)(object)TS_Edit);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(200, 200);
		((Control)this).Name = "UnitComms";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Comms for: ";
		((ISupportInitialize)(object)DGV_Comms).EndInit();
		((Control)TS_Edit).ResumeLayout(false);
		((Control)TS_Edit).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	private void UnitComms_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
		if (((Control)MyProject.Forms.AddComms).Visible)
		{
			((Form)MyProject.Forms.AddComms).Close();
		}
	}

	private void UnitComms_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (Client.SelectedUnit.IsActiveUnit)
		{
			activeUnit_0 = (ActiveUnit)Client.SelectedUnit;
		}
		((Form)this).Text = "Communication and Datalinks for: " + Client.SelectedUnit.Name;
		Client.SelectedUnitChanged += method_2;
		((Control)BtnViewTransQueue).Visible = GameGeneral.Beta_PlatformComms & Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm);
	}

	private void UnitComms_Shown(object sender, EventArgs e)
	{
		((DataGridView)DGV_Comms).ForeColor = Color.Black;
		((DataGridView)DGV_Comms).RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		BuildForm();
		BuildForm();
	}

	private void UnitComms_SizeChanged(object sender, EventArgs e)
	{
		BuildForm();
	}

	private void method_2(Module_Unit.Unit unit_0)
	{
		if (((Control)this).Visible && !Information.IsNothing((object)unit_0) && unit_0.IsActiveUnit)
		{
			activeUnit_0 = (ActiveUnit)unit_0;
			BuildForm();
		}
	}

	public void BuildForm()
	{
		BuildForm_Detailed();
	}

	public void BuildForm_Detailed()
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		((Control)TS_Edit).Visible = Client.AllowEditModeActions;
		if (Information.IsNothing((object)activeUnit_0) || !activeUnit_0.IsActiveUnit)
		{
			return;
		}
		method_6();
		if (Information.IsNothing((object)activeUnit_0) || !activeUnit_0.IsActiveUnit)
		{
			return;
		}
		((Form)this).Text = "Communication and Datalinks for: " + activeUnit_0.Name;
		((DataGridView)DGV_Comms).DataSource = dataTable_0;
		foreach (DataGridViewColumn item in (BaseCollection)((DataGridView)DGV_Comms).Columns)
		{
			item.SortMode = (DataGridViewColumnSortMode)0;
			item.ReadOnly = true;
		}
		((DataGridView)DGV_Comms).Columns["Order#"].Visible = false;
		((DataGridView)DGV_Comms).Columns["ObjectID"].Visible = false;
		if (Debugger.IsAttached && !(GameGeneral.Beta_PlatformComms & Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)))
		{
			((ToolStripItem)TSB_JammCD).Visible = true;
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
			if (Information.IsNothing((object)activeUnit_0))
			{
				((DataGridView)DGV_Comms).Columns.Clear();
			}
			else if (activeUnit_0.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
			{
				BuildForm();
			}
			else
			{
				((DataGridView)DGV_Comms).Columns.Clear();
			}
			((Control)TS_Edit).Visible = Client.AllowEditModeActions;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200107", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		bool_3 = false;
	}

	private void method_3(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex != -1 && e.ColumnIndex != -1 && !((DataGridView)DGV_Comms).ReadOnly && ((DataGridView)DGV_Comms).Rows.Count != 0)
			{
				DataGridViewRow val = ((DataGridView)DGV_Comms).Rows[e.RowIndex];
				if (activeUnit_0.Comms_ReadOnly[Conversions.ToInteger(((DataGridView)DGV_Comms).Rows[e.RowIndex].Cells["Order#"].Value)].Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					val.Selected = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200108", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex != -1 && !((DataGridView)DGV_Comms).ReadOnly && ((DataGridView)DGV_Comms).Rows.Count != 0)
			{
				_ = ((DataGridView)DGV_Comms).Columns[e.ColumnIndex];
				_ = activeUnit_0.Comms_ReadOnly[Conversions.ToInteger(((DataGridView)DGV_Comms).Rows[e.RowIndex].Cells["Order#"].Value)].Status;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200109", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_5(object sender, DataGridViewCellEventArgs e)
	{
		BuildForm();
		Client.MustRefreshMainForm = true;
		Client.MustRefreshMainForm = true;
	}

	private void method_6()
	{
		if (Information.IsNothing((object)activeUnit_0) || !activeUnit_0.IsActiveUnit)
		{
			return;
		}
		((DataGridView)DGV_Comms).DataSource = null;
		((DataGridView)DGV_Comms).Rows.Clear();
		dataTable_0.Columns.Clear();
		dataTable_0.Rows.Clear();
		dataTable_0.Columns.Add("Sensor", typeof(string));
		dataTable_0.Columns.Add("SensorType", typeof(string));
		dataTable_0.Columns.Add("Bandnwidth", typeof(string));
		dataTable_0.Columns.Add("Latency", typeof(string));
		dataTable_0.Columns.Add("Status", typeof(string));
		if (!(GameGeneral.Beta_PlatformComms & Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)))
		{
			dataTable_0.Columns.Add("Jammed", typeof(string));
		}
		dataTable_0.Columns.Add("ObjectID", typeof(string));
		dataTable_0.Columns.Add("Order#", typeof(int));
		CommDevice[] comms_ReadOnly = activeUnit_0.Comms_ReadOnly;
		int num = comms_ReadOnly.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			CommDevice commDevice = comms_ReadOnly[i];
			DataRow dataRow = dataTable_0.NewRow();
			dataRow["ObjectID"] = commDevice.ObjectID;
			dataRow["Order#"] = i;
			dataRow["Sensor"] = Misc.RemoveHiddenString(commDevice.Name + (string)Interaction.IIf(commDevice.IsCommsInMount, (object)"^", (object)""));
			dataRow["SensorType"] = DBFunctions.Description(commDevice.Type, Client.CurrentScenario);
			string text = commDevice.Status.ToString();
			if (commDevice.Status == PlatformComponent._ComponentStatus.Operational && commDevice.ReasonForInoperative.Response == PlatformComponent.BooleanResponse.ResponseFalse)
			{
				text = "Not operating (" + commDevice.ReasonForInoperative.ResponseString + ")";
			}
			else if (!(GameGeneral.Beta_PlatformComms & Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)) && commDevice.IsJammed)
			{
				text += " - JAMMED";
			}
			dataRow["Bandnwidth"] = commDevice.QualityGradeinfo.GetDescriptionASSlide();
			dataRow["Latency"] = commDevice.LatencyGradenfo.GetDescriptionASSlide();
			dataRow["Status"] = text;
			if (!(GameGeneral.Beta_PlatformComms & Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)))
			{
				string value = "Not Jammed";
				if (commDevice.IsJammed)
				{
					value = "Jammed";
				}
				dataRow["Jammed"] = value;
			}
			dataTable_0.Rows.Add(dataRow);
		}
	}

	private void qsiHsixXcQf()
	{
		int num = ((DataGridView)DGV_Comms).Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataGridViewRow val = ((DataGridView)DGV_Comms).Rows[i];
			CommDevice commDevice = null;
			commDevice = activeUnit_0.Comms_ReadOnly[Conversions.ToInteger(val.Cells["Order#"].Value)];
			if (commDevice.Status != PlatformComponent._ComponentStatus.Operational)
			{
				val.DefaultCellStyle.ForeColor = GetComponentDamageColor(commDevice);
				val.ReadOnly = true;
			}
			else
			{
				val.DefaultCellStyle.ForeColor = Color.LightGray;
			}
			_ = ((DataGridView)DGV_Comms).Rows[Conversions.ToInteger(val.Cells["Order#"].Value)].Cells["Active"];
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		MyProject.Forms.AddComms.FormThatCalledMe = (Form)(object)this;
		((Control)MyProject.Forms.AddComms).Show();
		Client.MustRefreshMainForm = true;
	}

	private void method_8(object sender, DataGridViewCellPaintingEventArgs e)
	{
		if (e.RowIndex <= -1 || e.ColumnIndex != ((DataGridView)DGV_Comms).Columns.IndexOf(((DataGridView)DGV_Comms).Columns["Active"]))
		{
			return;
		}
		if (Conversions.ToBoolean(((DataGridView)DGV_Comms).Rows[e.RowIndex].Cells["CanBeActive"].Value))
		{
			if (Operators.CompareString(Conversions.ToString(((DataGridView)DGV_Comms).Rows[e.RowIndex].Cells["Status"].Value), "Damaged", true) == 0 || Operators.CompareString(Conversions.ToString(((DataGridView)DGV_Comms).Rows[e.RowIndex].Cells["Status"].Value), "Destroyed", true) == 0 || Operators.CompareString(Conversions.ToString(((DataGridView)DGV_Comms).Rows[e.RowIndex].Cells["Jammed"].Value), "Jammed", true) == 0)
			{
				e.Paint(e.ClipBounds, (DataGridViewPaintParts)3);
				((HandledEventArgs)(object)e).Handled = true;
			}
		}
		else
		{
			e.Paint(e.ClipBounds, (DataGridViewPaintParts)3);
			((HandledEventArgs)(object)e).Handled = true;
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (!((DataGridView)DGV_Comms).ReadOnly)
		{
			((DataGridView)DGV_Comms).ForeColor = Color.Black;
			((DataGridView)DGV_Comms).RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		else
		{
			((DataGridView)DGV_Comms).ForeColor = Color.Gray;
			((DataGridView)DGV_Comms).RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Comms).SelectedRows).Count > 0)
		{
			string_0 = Conversions.ToString(((DataGridView)DGV_Comms).SelectedRows[0].Cells["ObjectID"].Value);
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(string_0) || !activeUnit_0.IsActiveUnit)
		{
			return;
		}
		ActiveUnit activeUnit = activeUnit_0;
		CommDevice commDevice = null;
		CommDevice[] comms_ReadOnly = activeUnit.Comms_ReadOnly;
		foreach (CommDevice commDevice2 in comms_ReadOnly)
		{
			if (Operators.CompareString(commDevice2.ObjectID, string_0, true) == 0)
			{
				commDevice = commDevice2;
				break;
			}
		}
		int mustRefreshMainForm;
		if (Information.IsNothing((object)commDevice))
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			activeUnit.RemoveCommDevice(commDevice);
			BuildForm();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void method_12(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(string_0) || !activeUnit_0.IsActiveUnit)
		{
			return;
		}
		ActiveUnit activeUnit = activeUnit_0;
		CommDevice commDevice = null;
		CommDevice[] comms_ReadOnly = activeUnit.Comms_ReadOnly;
		foreach (CommDevice commDevice2 in comms_ReadOnly)
		{
			if (Operators.CompareString(commDevice2.ObjectID, string_0, true) == 0)
			{
				commDevice = commDevice2;
				break;
			}
		}
		int mustRefreshMainForm;
		if (Information.IsNothing((object)commDevice))
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			commDevice.IsJammed = true;
			BuildForm();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void method_13(object sender, EventArgs e)
	{
		RefreshForm();
		Timer_Refresh.Stop();
	}

	private void UnitComms_KeyDown(object sender, KeyEventArgs e)
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

	private void UnitComms_FormClosed(object sender, FormClosedEventArgs e)
	{
		Client.SelectedUnitChanged -= method_2;
	}

	private void method_14(object sender, EventArgs e)
	{
		if (Client.CommDataWindow != null)
		{
			((Control)Client.CommDataWindow).Show();
		}
	}

	static UnitComms()
	{
		Class72.smethod_20();
	}
}

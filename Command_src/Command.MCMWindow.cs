using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MCMWindow : DarkSecondaryFormBase, GInterface0
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("DGV_Sensors")]
	[CompilerGenerated]
	private DarkDataGridView _DGV_Sensors;

	[CompilerGenerated]
	private bool bool_2;

	private DataTable dataTable_0;

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
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_3);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_4);
			DarkDataGridView darkDataGridView = _DGV_Sensors;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick -= val;
				((DataGridView)darkDataGridView).CellContentClick -= val2;
			}
			_DGV_Sensors = value;
			darkDataGridView = _DGV_Sensors;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick += val;
				((DataGridView)darkDataGridView).CellContentClick += val2;
			}
		}
	}

	[field: AccessedThroughProperty("Sensor")]
	internal virtual DataGridViewTextBoxColumn Sensor { get; set; }

	[field: AccessedThroughProperty("SensorType")]
	internal virtual DataGridViewTextBoxColumn SensorType { get; set; }

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

	public MCMWindow()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += MCMWindow_Load;
		((Control)this).KeyDown += new KeyEventHandler(MCMWindow_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(MCMWindow_FormClosing);
		RTMPEnabled = true;
		dataTable_0 = new DataTable();
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
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DGV_Sensors = new DarkDataGridView();
		Sensor = new DataGridViewTextBoxColumn();
		SensorType = new DataGridViewTextBoxColumn();
		((ISupportInitialize)(object)DGV_Sensors).BeginInit();
		((Control)this).SuspendLayout();
		((DataGridView)DGV_Sensors).AllowUserToAddRows = false;
		((DataGridView)DGV_Sensors).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Sensors).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)6;
		((DataGridView)DGV_Sensors).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
		((DataGridView)DGV_Sensors).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Sensors).BorderStyle = (BorderStyle)2;
		((Control)DGV_Sensors).CausesValidation = false;
		((DataGridView)DGV_Sensors).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Sensors).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Sensors).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_Sensors).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_Sensors).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[2]
		{
			(DataGridViewColumn)Sensor,
			(DataGridViewColumn)SensorType
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.LightGray;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Sensors).DefaultCellStyle = val2;
		((Control)DGV_Sensors).Dock = (DockStyle)5;
		((DataGridView)DGV_Sensors).EnableHeadersVisualStyles = false;
		((Control)DGV_Sensors).Location = new Point(0, 0);
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
		((DataGridView)DGV_Sensors).ScrollBars = (ScrollBars)2;
		((DataGridView)DGV_Sensors).RowTemplate.Resizable = (DataGridViewTriState)2;
		((DataGridView)DGV_Sensors).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_Sensors).Size = new Size(523, 205);
		((Control)DGV_Sensors).TabIndex = 9;
		((DataGridViewColumn)Sensor).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Sensor).DataPropertyName = "Sensor";
		((DataGridViewColumn)Sensor).HeaderText = "Sensor";
		((DataGridViewColumn)Sensor).Name = "Sensor";
		((DataGridViewColumn)SensorType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)SensorType).DataPropertyName = "SensorType";
		((DataGridViewColumn)SensorType).HeaderText = "Sensor Type";
		((DataGridViewColumn)SensorType).Name = "SensorType";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).AutoSize = true;
		((Form)this).ClientSize = new Size(523, 205);
		((Control)this).Controls.Add((Control)(object)DGV_Sensors);
		((Control)this).DoubleBuffered = true;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "MCMWindow";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Mine Countermeasures";
		((ISupportInitialize)(object)DGV_Sensors).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MCMWindow_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Form)this).Text = "MCM & Podded Equipment";
		BuildForm_Detailed();
	}

	public void BuildForm_Detailed()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		method_2();
		((DataGridView)DGV_Sensors).DataSource = dataTable_0;
		((DataGridView)DGV_Sensors).Columns["CanBeActive"].Visible = false;
		((DataGridView)DGV_Sensors).Columns["Order#"].Visible = false;
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_Sensors).Rows)
		{
			DataGridViewRow val = item;
			if (!((ActiveUnit)Client.SelectedUnit).MineCountermeasures[Conversions.ToInteger(val.Cells["Order#"].Value)].CanBeActive)
			{
				val.ReadOnly = true;
			}
		}
		foreach (DataGridViewColumn item2 in (BaseCollection)((DataGridView)DGV_Sensors).Columns)
		{
			_ = item2;
		}
	}

	private void method_2()
	{
		((DataGridView)DGV_Sensors).DataSource = null;
		((DataGridView)DGV_Sensors).Rows.Clear();
		dataTable_0.Columns.Clear();
		dataTable_0.Rows.Clear();
		dataTable_0.Columns.Add("Order#", typeof(int));
		dataTable_0.Columns.Add("CanBeActive", typeof(bool));
		dataTable_0.Columns.Add("Sensor", typeof(string));
		dataTable_0.Columns.Add("SensorType", typeof(string));
		dataTable_0.Columns.Add("Active", typeof(bool));
		dataTable_0.Columns.Add("Status", typeof(string));
		RefreshForm();
	}

	private void method_3(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1 && e.ColumnIndex != -1)
		{
			DataGridViewRow val = ((DataGridView)DGV_Sensors).Rows[e.RowIndex];
			if (((ActiveUnit)Client.SelectedUnit).MineCountermeasures[e.RowIndex].Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				val.Selected = false;
			}
		}
	}

	private void method_4(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
		{
			return;
		}
		DataGridViewColumn val = ((DataGridView)DGV_Sensors).Columns[e.ColumnIndex];
		if (((ActiveUnit)Client.SelectedUnit).MineCountermeasures[e.RowIndex].Status != PlatformComponent._ComponentStatus.Operational || Operators.CompareString(val.Name, "Active", true) != 0)
		{
			return;
		}
		int index = Conversions.ToInteger(((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Order#"].Value);
		Sensor sensor = ((ActiveUnit)Client.SelectedUnit).MineCountermeasures[index];
		if (!sensor.CanBeActive)
		{
			return;
		}
		int mustRefreshMainForm;
		if (sensor.IsActive())
		{
			sensor.GoPassive();
			((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value = false;
			if (!Client.Realtime)
			{
				mustRefreshMainForm = 1;
			}
			else
			{
				List<Sensor> list = new List<Sensor>();
				list.Add(sensor);
				Client.RealtimeTerminal.SendSensorActivation(Client.SelectedUnit, list, activate: false);
				mustRefreshMainForm = 1;
			}
		}
		else
		{
			sensor.GoActive();
			((DataGridView)DGV_Sensors).Rows[e.RowIndex].Cells["Active"].Value = true;
			if (Client.Realtime)
			{
				List<Sensor> list2 = new List<Sensor>();
				list2.Add(sensor);
				Client.RealtimeTerminal.SendSensorActivation(Client.SelectedUnit, list2, activate: true);
				mustRefreshMainForm = 1;
			}
			else
			{
				mustRefreshMainForm = 1;
			}
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		Client.MustRefreshMainForm = true;
	}

	private void MCMWindow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void MCMWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	public void RefreshForm()
	{
		dataTable_0.Rows.Clear();
		int num = ((ActiveUnit)Client.SelectedUnit).MineCountermeasures.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor sensor = ((ActiveUnit)Client.SelectedUnit).MineCountermeasures[i];
			DataRow dataRow = dataTable_0.NewRow();
			dataRow["Order#"] = i;
			dataRow["CanBeActive"] = sensor.CanBeActive;
			dataRow["Sensor"] = Misc.RemoveHiddenString(sensor.Name);
			dataRow["SensorType"] = sensor.RoleDescription;
			dataRow["Active"] = sensor.IsActive();
			dataRow["Status"] = sensor.Status.ToString();
			dataTable_0.Rows.Add(dataRow);
		}
	}

	static MCMWindow()
	{
		Class72.smethod_20();
	}
}

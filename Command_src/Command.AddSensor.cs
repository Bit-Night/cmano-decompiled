using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
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
public sealed class AddSensor : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _DataGridView1;

	[AccessedThroughProperty("BW1")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Find")]
	private DarkUITextBox _TB_Find;

	private DataTable dataTable_0;

	private DataView dataView_0;

	private bool bool_2;

	public Form FormThatCalledMe;

	internal virtual DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return _DataGridView1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_10);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_11);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellDoubleClick -= val;
				((DataGridView)darkDataGridView).CellContentClick -= val2;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellDoubleClick += val;
				((DataGridView)darkDataGridView).CellContentClick += val2;
			}
		}
	}

	internal virtual BackgroundWorker BW1
	{
		[CompilerGenerated]
		get
		{
			return backgroundWorker_0;
		}
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = method_3;
			RunWorkerCompletedEventHandler value3 = method_4;
			BackgroundWorker backgroundWorker = backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			backgroundWorker_0 = value;
			backgroundWorker = backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

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

	internal virtual DarkUITextBox TB_Find
	{
		[CompilerGenerated]
		get
		{
			return _TB_Find;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_5;
			EventHandler eventHandler = method_8;
			EventHandler eventHandler2 = method_9;
			DarkUITextBox darkUITextBox = _TB_Find;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TB_Find = value;
			darkUITextBox = _TB_Find;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("ArcControl_Illumination")]
	internal virtual PlatformComponentArcControl ArcControl_Illumination { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("ArcControl_Detection")]
	internal virtual PlatformComponentArcControl ArcControl_Detection { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("Description")]
	internal virtual DataGridViewTextBoxColumn Description { get; set; }

	public AddSensor()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += AddSensor_Load;
		((Control)this).KeyDown += new KeyEventHandler(AddSensor_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(AddSensor_FormClosing);
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
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		BW1 = new BackgroundWorker();
		Button1 = new DarkUIButton();
		TB_Find = new DarkUITextBox();
		Label1 = new DarkLabel();
		ArcControl_Illumination = new PlatformComponentArcControl();
		ArcControl_Detection = new PlatformComponentArcControl();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)this).SuspendLayout();
		((DataGridView)DataGridView1).AllowUserToOrderColumns = true;
		((Control)DataGridView1).Anchor = (AnchorStyles)15;
		((DataGridView)DataGridView1).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DataGridView1).BorderStyle = (BorderStyle)2;
		((DataGridView)DataGridView1).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)DataGridView1).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DataGridView1).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DataGridView1).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[2]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)Description
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DataGridView1).DefaultCellStyle = val2;
		((DataGridView)DataGridView1).EnableHeadersVisualStyles = false;
		((Control)DataGridView1).Location = new Point(0, 159);
		((DataGridView)DataGridView1).MultiSelect = false;
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((DataGridView)DataGridView1).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DataGridView1).Size = new Size(503, 355);
		((Control)DataGridView1).TabIndex = 1;
		((DataGridViewColumn)ID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Width = 41;
		((DataGridViewColumn)Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Description).DataPropertyName = "Name";
		((DataGridViewColumn)Description).HeaderText = "Name - Click name of sensor to access DB VIewer ";
		((DataGridViewColumn)Description).Name = "Description";
		((DataGridViewColumn)Description).ReadOnly = true;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(7, 5);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(89, 23);
		((Control)Button1).TabIndex = 3;
		Button1.Text = "Add Selected";
		((Control)TB_Find).Anchor = (AnchorStyles)13;
		TB_Find.AutoCompleteCustomSource = null;
		TB_Find.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Find.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Find).BackColor = Color.Transparent;
		TB_Find.Font = new Font("Segoe UI", 8f);
		((Control)TB_Find).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		((Control)TB_Find).Location = new Point(6, 134);
		TB_Find.MaxLength = 32767;
		TB_Find.Multiline = false;
		((Control)TB_Find).Name = "TB_Find";
		TB_Find.ReadOnly = false;
		TB_Find.ScrollBars = (ScrollBars)0;
		TB_Find.SelectionStart = 0;
		((Control)TB_Find).Size = new Size(386, 20);
		((Control)TB_Find).TabIndex = 12;
		TB_Find.TextAlign = (HorizontalAlignment)0;
		TB_Find.UseSystemPasswordChar = false;
		TB_Find.WordWrap = false;
		TB_Find.WatermarkText = "Search Sensor...";
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(309, 1);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(53, 13);
		((Control)Label1).TabIndex = 15;
		((Label)Label1).Text = "Detection";
		((UserControl)ArcControl_Illumination).AutoSize = true;
		((Control)ArcControl_Illumination).BackColor = Color.FromArgb(60, 63, 65);
		((Control)ArcControl_Illumination).Location = new Point(394, 13);
		((Control)ArcControl_Illumination).Name = "ArcControl_Illumination";
		((Control)ArcControl_Illumination).Size = new Size(103, 100);
		((Control)ArcControl_Illumination).TabIndex = 14;
		((UserControl)ArcControl_Detection).AutoSize = true;
		((Control)ArcControl_Detection).BackColor = Color.FromArgb(60, 63, 65);
		((Control)ArcControl_Detection).Location = new Point(288, 12);
		((Control)ArcControl_Detection).Name = "ArcControl_Detection";
		((Control)ArcControl_Detection).Size = new Size(103, 100);
		((Control)ArcControl_Detection).TabIndex = 16;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(386, 2);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(112, 13);
		((Control)Label2).TabIndex = 17;
		((Label)Label2).Text = "Tracking / Illumination";
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(271, 111);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(226, 13);
		((Control)Label3).TabIndex = 18;
		((Label)Label3).Text = "Tips: Double-click to select or deselect all arcs";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(503, 514);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)ArcControl_Detection);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)ArcControl_Illumination);
		((Control)this).Controls.Add((Control)(object)TB_Find);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddSensor";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Add Sensor";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void AddSensor_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		BW1.RunWorkerAsync();
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		if (!Information.IsNothing((object)Client.SelectedUnit) && Client.SelectedUnit.IsActiveUnit && (!ArcControl_Detection.NoArcsSelected || (int)DarkMessageBox.ShowWarning("You have defined no detection arcs for this sensor. Are you sure?", "No detection arcs defined!", DarkDialogButton.YesNo) != 7))
		{
			int int_ = Conversions.ToInteger(((DataGridView)DataGridView1).CurrentRow.Cells["ID"].Value);
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			Sensor sensor = DBFunctions.GetSensor(int_, ref sqliteConnection_);
			sensor.Coverage = ArcControl_Detection.theCoverage.Clone();
			sensor.Coverage_Illuminate = ArcControl_Illumination.theCoverage.Clone();
			((ActiveUnit)Client.SelectedUnit).AddSensor(sensor);
			sensor.ParentPlatform = (ActiveUnit)Client.SelectedUnit;
			if (!Information.IsNothing((object)Client.theSensorsWindow) && ((Control)Client.theSensorsWindow).Visible)
			{
				Client.theSensorsWindow.BuildForm();
			}
		}
	}

	private void method_3(object sender, DoWorkEventArgs e)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		dataTable_0 = DBFunctions.GetAllSensors(ref sqliteConnection_);
	}

	private void method_4(object sender, RunWorkerCompletedEventArgs e)
	{
		if (Operators.CompareString(TB_Find.Text, "", true) == 0)
		{
			method_7();
		}
		else
		{
			method_6();
		}
	}

	private void method_5(object object_0)
	{
		if (Operators.CompareString(TB_Find.Text, "", true) == 0)
		{
			method_7();
		}
		else
		{
			method_6();
		}
	}

	private void method_6()
	{
		string value = TB_Find.Text.ToLowerInvariant();
		DataTable dataTable = new DataTable();
		dataTable = dataTable_0.Clone();
		foreach (DataRow row in dataTable_0.Rows)
		{
			if (row["Name"].ToString().ToLowerInvariant().Contains(value))
			{
				dataTable.ImportRow(row);
			}
		}
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		((DataGridView)DataGridView1).DataSource = dataTable;
		((Control)DataGridView1).Refresh();
	}

	public void InjectFilterByKeyword(string name)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		dataTable_0 = DBFunctions.GetAllSensors(ref sqliteConnection_);
		TB_Find.Text = name;
	}

	private void method_7()
	{
		dataView_0 = new DataView(dataTable_0);
		dataView_0.Sort = "Name ASC";
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		((DataGridView)DataGridView1).DataSource = dataView_0;
	}

	private void AddSensor_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (bool_2 && ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (!bool_2 && (e.KeyValue != 32 || !((Control)this).Visible))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		bool_2 = true;
	}

	private void method_9(object sender, EventArgs e)
	{
		bool_2 = false;
	}

	private void AddSensor_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_10(object sender, DataGridViewCellEventArgs e)
	{
		method_2(RuntimeHelpers.GetObjectValue(sender), null);
	}

	private void method_11(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1 || ((DataGridView)DataGridView1).Rows.Count == 0)
			{
				return;
			}
			_ = ((DataGridView)DataGridView1).Columns[e.ColumnIndex];
			DataGridViewRow val = ((DataGridView)DataGridView1).Rows[e.RowIndex];
			if (e.ColumnIndex == 1)
			{
				int num = Conversions.ToInteger(val.Cells[0].Value);
				if (num > 0)
				{
					Client.smethod_17("Sensor", num);
				}
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

	static AddSensor()
	{
		Class72.smethod_20();
	}
}

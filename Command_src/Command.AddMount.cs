using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddMount : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _DataGridView1;

	[CompilerGenerated]
	[AccessedThroughProperty("BW1")]
	private BackgroundWorker backgroundWorker_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Find")]
	private DarkUITextBox _TB_Find;

	[CompilerGenerated]
	[AccessedThroughProperty("Description")]
	private DataGridViewTextBoxColumn opsSzGbKkiu;

	private DataTable dataTable_0;

	private DataView dataView_0;

	private bool bool_2;

	public Form FormThatCalledMe;

	public ActiveUnit targetUnit;

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
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_11);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellDoubleClick -= val;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellDoubleClick += val;
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

	[field: AccessedThroughProperty("ArcControl1")]
	internal virtual PlatformComponentArcControl ArcControl1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	internal virtual DataGridViewTextBoxColumn Description
	{
		[CompilerGenerated]
		get
		{
			return opsSzGbKkiu;
		}
		[CompilerGenerated]
		set
		{
			opsSzGbKkiu = value;
		}
	}

	public AddMount()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += AddMount_Load;
		((Control)this).KeyDown += new KeyEventHandler(AddMount_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(AddMount_FormClosing);
		targetUnit = null;
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
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		BW1 = new BackgroundWorker();
		Button1 = new DarkUIButton();
		TB_Find = new DarkUITextBox();
		ArcControl1 = new PlatformComponentArcControl();
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
		((Control)DataGridView1).Location = new Point(0, 110);
		((DataGridView)DataGridView1).MultiSelect = false;
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((DataGridView)DataGridView1).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DataGridView1).Size = new Size(503, 404);
		((Control)DataGridView1).TabIndex = 1;
		((DataGridViewColumn)ID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Width = 41;
		((DataGridViewColumn)Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Description).DataPropertyName = "Name";
		((DataGridViewColumn)Description).HeaderText = "Name";
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
		TB_Find.Font = new Font("Segoe UI", 10f);
		((Control)TB_Find).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		((Control)TB_Find).Location = new Point(7, 85);
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
		TB_Find.WatermarkText = "Search Weapon Mount...";
		((UserControl)ArcControl1).AutoSize = true;
		((Control)ArcControl1).BackColor = Color.FromArgb(60, 63, 65);
		((Control)ArcControl1).Location = new Point(399, 4);
		((Control)ArcControl1).Name = "ArcControl1";
		((Control)ArcControl1).Size = new Size(103, 100);
		((Control)ArcControl1).TabIndex = 14;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(179, 10);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(226, 13);
		((Control)Label3).TabIndex = 19;
		((Label)Label3).Text = "Tips: Double-click to select or deselect all arcs";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(503, 514);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)ArcControl1);
		((Control)this).Controls.Add((Control)(object)TB_Find);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddMount";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Add Weapon Mount";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void AddMount_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		BW1.RunWorkerAsync();
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Invalid comparison between Unknown and I4
		ActiveUnit activeUnit = null;
		if (targetUnit != null)
		{
			activeUnit = targetUnit;
		}
		else if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
		{
			activeUnit = (ActiveUnit)Client.SelectedUnit;
		}
		if (activeUnit == null)
		{
			return;
		}
		if (!ArcControl1.NoArcsSelected)
		{
			int int_ = Conversions.ToInteger(((DataGridView)DataGridView1).CurrentRow.Cells["ID"].Value);
			Scenario theScen = Client.CurrentScenario;
			Mount theMount = DBFunctions.GetMount(int_, ref theScen);
			theMount.Coverage = ArcControl1.theCoverage.Clone();
			activeUnit.Mounts.Add(theMount);
			theMount.ParentPlatform = activeUnit;
			Sensor[] sensors_ReadOnly = theMount.Sensors_ReadOnly;
			foreach (Sensor obj in sensors_ReadOnly)
			{
				obj.ParentPlatform = activeUnit;
				obj.Coverage = theMount.Coverage;
				obj.Coverage_Illuminate = theMount.Coverage;
			}
			bool flag = false;
			if (theMount.CompatibleDirectors.Count <= 0)
			{
				flag = true;
			}
			else
			{
				Sensor[] array = activeUnit.Sensors_ReadOnly();
				for (int j = 0; j < array.Length; j = checked(j + 1))
				{
					if (flag = array[j].CanDirectThisMount(ref theMount))
					{
						break;
					}
				}
			}
			if (!flag && theMount.CompatibleDirectors.Count > 0 && (int)DarkMessageBox.ShowWarning("The mount you have added misses a director, do you want to add one ?", "Director Needed", DarkDialogButton.YesNo) == 6)
			{
				Client.theSensorsWindow = new UnitSensors();
				((Control)Client.theSensorsWindow).Show();
				MyProject.Forms.AddSensor.FormThatCalledMe = (Form)(object)Client.theSensorsWindow;
				((Control)MyProject.Forms.AddSensor).Show();
				Client.MustRefreshMainForm = true;
				AddSensor addSensor = MyProject.Forms.AddSensor;
				int int_2 = theMount.CompatibleDirectors.ElementAtOrDefault(0);
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				addSensor.InjectFilterByKeyword(DBFunctions.GetSensor(int_2, ref sqliteConnection_).Name);
			}
		}
		else
		{
			DarkMessageBox.ShowError("You must select coverage arcs for this mount", "No coverage arcs selected!");
		}
	}

	private void method_3(object sender, DoWorkEventArgs e)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		dataTable_0 = DBFunctions.GetAllMounts(ref sqliteConnection_);
	}

	private void method_4(object sender, RunWorkerCompletedEventArgs e)
	{
		method_7();
	}

	private void method_5(object object_0)
	{
		if (Operators.CompareString(TB_Find.Text, "", true) != 0)
		{
			method_6();
		}
		else
		{
			method_7();
		}
	}

	private void method_6()
	{
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "Name ASC";
		dataView.RowFilter = "Name LIKE '%" + Misc.EscapeLikeValue(TB_Find.Text) + "%'";
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		((DataGridView)DataGridView1).DataSource = dataView;
		((Control)DataGridView1).Refresh();
	}

	private void method_7()
	{
		dataView_0 = new DataView(dataTable_0);
		dataView_0.Sort = "Name ASC";
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		((DataGridView)DataGridView1).DataSource = dataView_0;
	}

	private void AddMount_KeyDown(object sender, KeyEventArgs e)
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

	private void AddMount_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_10(object sender, DataGridViewCellEventArgs e)
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
				int int_ = Conversions.ToInteger(val.Cells[0].Value);
				Scenario theScen = Client.CurrentScenario;
				Mount mount = DBFunctions.GetMount(int_, ref theScen);
				if (mount.MountWeapons[0].int_3 > 0)
				{
					Client.smethod_17("Weapon", mount.MountWeapons[0].int_3);
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

	private void method_11(object sender, DataGridViewCellEventArgs e)
	{
		method_2(RuntimeHelpers.GetObjectValue(sender), null);
	}

	static AddMount()
	{
		Class72.smethod_20();
	}
}

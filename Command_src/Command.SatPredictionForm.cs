using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Collections;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SatPredictionForm : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__107-0
	{
		public DataGridViewRow $VB$Local_row;

		public DarkListItem $VB$Local_item;

		public SatPredictionForm $VB$Me;

		public _Closure$__107-0(_Closure$__107-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_row = arg0.$VB$Local_row;
				$VB$Local_item = arg0.$VB$Local_item;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			((DataGridView)$VB$Me.DataGridView1).Rows.Add($VB$Local_row);
			$VB$Me.ListView1.Items.Add($VB$Local_item);
			$VB$Me.DarkUIProgressBar1.Value = (int)Math.Round(100.0 * ((double)$VB$Me.int_2 / (double)$VB$Me.int_1));
		}

		static _Closure$__107-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ListView1")]
	private DarkListView _ListView1;

	[CompilerGenerated]
	[AccessedThroughProperty("NumericUpDown1")]
	private GClass9 _NumericUpDown1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUIProgressBar1")]
	private DarkUIProgressBar darkUIProgressBar_0;

	[CompilerGenerated]
	private bool bool_2;

	public double LocationLatitude;

	public double LocationLongitude;

	private int int_0;

	[CompilerGenerated]
	[AccessedThroughProperty("theBW")]
	private BackgroundWorker backgroundWorker_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CovRecords")]
	private ObservableList<Satellite_Kinematics.CoverageRecord> observableList_0;

	private bool bool_3;

	private int int_1;

	private int int_2;

	private int int_3;

	private Keys[] keys_0;

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual DarkUITabControl TabControl1 { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("DataGridView1")]
	internal virtual DarkDataGridView DataGridView1 { get; set; }

	internal virtual DarkListView ListView1
	{
		[CompilerGenerated]
		get
		{
			return _ListView1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = [SpecialName] (object sender, EventArgs e) =>
			{
				DrawListViewItem(RuntimeHelpers.GetObjectValue(sender), (DrawDarkListViewListItemEventArgs)e);
			};
			DarkListView darkListView = _ListView1;
			if (darkListView != null)
			{
				darkListView.DrawListItem -= value2;
			}
			_ListView1 = value;
			darkListView = _ListView1;
			if (darkListView != null)
			{
				darkListView.DrawListItem += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn3 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn4 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual GClass9 NumericUpDown1
	{
		[CompilerGenerated]
		get
		{
			return _NumericUpDown1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			EventHandler eventHandler2 = [SpecialName] (object sender, EventArgs e) =>
			{
				method_3();
			};
			GClass9 gClass = _NumericUpDown1;
			if (gClass != null)
			{
				((NumericUpDown)gClass).TextChanged -= eventHandler;
				((NumericUpDown)gClass).ValueChanged -= eventHandler2;
			}
			_NumericUpDown1 = value;
			gClass = _NumericUpDown1;
			if (gClass != null)
			{
				((NumericUpDown)gClass).TextChanged += eventHandler;
				((NumericUpDown)gClass).ValueChanged += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

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
			EventHandler eventHandler = method_4;
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

	[field: AccessedThroughProperty("Satellite")]
	internal virtual DataGridViewTextBoxColumn Satellite { get; set; }

	[field: AccessedThroughProperty("Side")]
	internal virtual DataGridViewTextBoxColumn Side { get; set; }

	[field: AccessedThroughProperty("CoverageStart")]
	internal virtual DataGridViewTextBoxColumn CoverageStart { get; set; }

	[field: AccessedThroughProperty("DwellTime")]
	internal virtual DataGridViewTextBoxColumn DwellTime { get; set; }

	internal virtual DarkUIProgressBar DarkUIProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return darkUIProgressBar_0;
		}
		[CompilerGenerated]
		set
		{
			darkUIProgressBar_0 = value;
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

	public SatPredictionForm()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Shown += SatPredictionForm_Shown;
		((Form)this).FormClosing += new FormClosingEventHandler(SatPredictionForm_FormClosing);
		((Form)this).Load += SatPredictionForm_Load;
		RTMPEnabled = true;
		bool_3 = false;
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Expected O, but got Unknown
		//IL_0949: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Expected O, but got Unknown
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		Satellite = new DataGridViewTextBoxColumn();
		Side = new DataGridViewTextBoxColumn();
		CoverageStart = new DataGridViewTextBoxColumn();
		DwellTime = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		ListView1 = new DarkListView();
		Label1 = new DarkLabel();
		NumericUpDown1 = new GClass9();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		DarkUIProgressBar1 = new DarkUIProgressBar();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)ListView1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TabControl1).Location = new Point(0, 44);
		((Control)TabControl1).Size = new Size(804, 440);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Anchor = (AnchorStyles)15;
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).TabIndex = 0;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)DataGridView1);
		TabPage1.Location = new Point(0, 0);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(804, 420);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Log";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)ListView1);
		TabPage2.Location = new Point(0, 0);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(804, 420);
		TabPage2.TabIndex = 0;
		TabPage2.Text = "Chart";
		((DataGridView)DataGridView1).AllowUserToAddRows = false;
		((DataGridView)DataGridView1).AllowUserToDeleteRows = false;
		((DataGridView)DataGridView1).AllowUserToOrderColumns = true;
		((Control)DataGridView1).Anchor = (AnchorStyles)15;
		((DataGridView)DataGridView1).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DataGridView1).BorderStyle = (BorderStyle)2;
		((DataGridView)DataGridView1).CellBorderStyle = (DataGridViewCellBorderStyle)8;
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
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)Satellite,
			(DataGridViewColumn)Side,
			(DataGridViewColumn)CoverageStart,
			(DataGridViewColumn)DwellTime
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
		((Control)DataGridView1).Location = new Point(0, 0);
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).ReadOnly = true;
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((Control)DataGridView1).Size = new Size(804, 420);
		((Control)DataGridView1).TabIndex = 0;
		((DataGridViewColumn)Satellite).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Satellite).HeaderText = "Satellite";
		((DataGridViewColumn)Satellite).Name = "Satellite";
		((DataGridViewColumn)Satellite).ReadOnly = true;
		((DataGridViewColumn)Satellite).Width = 71;
		((DataGridViewColumn)Side).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Side).HeaderText = "Side";
		((DataGridViewColumn)Side).Name = "Side";
		((DataGridViewColumn)Side).ReadOnly = true;
		((DataGridViewColumn)Side).Width = 52;
		((DataGridViewColumn)CoverageStart).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)CoverageStart).HeaderText = "Enters coverage at:";
		((DataGridViewColumn)CoverageStart).Name = "CoverageStart";
		((DataGridViewColumn)CoverageStart).ReadOnly = true;
		((DataGridViewColumn)CoverageStart).Width = 106;
		((DataGridViewColumn)DwellTime).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)DwellTime).HeaderText = "DwellTime";
		((DataGridViewColumn)DwellTime).Name = "DwellTime";
		((DataGridViewColumn)DwellTime).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "Satellite";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).HeaderText = "Side";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Name = "DataGridViewTextBoxColumn2";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).HeaderText = "Enters coverage at:";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Name = "DataGridViewTextBoxColumn3";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).HeaderText = "DwellTime";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Name = "DataGridViewTextBoxColumn4";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).ReadOnly = true;
		((Control)ListView1).Anchor = (AnchorStyles)7;
		((Control)ListView1).Dock = (DockStyle)5;
		((Control)ListView1).Location = new Point(0, 0);
		((Control)ListView1).Name = "ListView1";
		((Control)ListView1).Size = new Size(804, 420);
		ListView1.HideScrollBars = true;
		((Control)ListView1).TabIndex = 2;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(12, 17);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(107, 15);
		((Control)Label1).TabIndex = 1;
		((Label)Label1).Text = "Predict for the next";
		NumericUpDown1.BackColor = Color.Transparent;
		((Control)NumericUpDown1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)NumericUpDown1).Location = new Point(120, 12);
		((NumericUpDown)NumericUpDown1).Maximum = 30m;
		((NumericUpDown)NumericUpDown1).Minimum = 1m;
		((Control)NumericUpDown1).Name = "NumericUpDown1";
		((Control)NumericUpDown1).Size = new Size(58, 26);
		((Control)NumericUpDown1).TabIndex = 2;
		((NumericUpDown)NumericUpDown1).Value = 1m;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(194, 17);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(31, 15);
		((Control)Label2).TabIndex = 3;
		((Label)Label2).Text = "days";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(242, 12);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 26);
		((Control)Button1).TabIndex = 4;
		Button1.Text = "Recalculate";
		((Control)DarkUIProgressBar1).Anchor = (AnchorStyles)13;
		((Control)DarkUIProgressBar1).BackColor = Color.Transparent;
		((Control)DarkUIProgressBar1).Location = new Point(323, 12);
		DarkUIProgressBar1.Maximum = 100;
		((Control)DarkUIProgressBar1).Name = "DarkUIProgressBar1";
		DarkUIProgressBar1.ShowProgressLines = true;
		DarkUIProgressBar1.ShowProgressValue = true;
		((Control)DarkUIProgressBar1).Size = new Size(469, 26);
		((Control)DarkUIProgressBar1).TabIndex = 5;
		((Control)DarkUIProgressBar1).Text = "Calculating...";
		DarkUIProgressBar1.Value = 0;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(804, 492);
		((Control)this).Controls.Add((Control)(object)DarkUIProgressBar1);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)NumericUpDown1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "SatPredictionForm";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Satellite pass predictions";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage2).PerformLayout();
		((Control)ListView1).ResumeLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual BackgroundWorker vmethod_0()
	{
		return backgroundWorker_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(BackgroundWorker WithEventsValue)
	{
		DoWorkEventHandler value = method_5;
		RunWorkerCompletedEventHandler value2 = method_6;
		BackgroundWorker backgroundWorker = backgroundWorker_0;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		backgroundWorker_0 = WithEventsValue;
		backgroundWorker = backgroundWorker_0;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual ObservableList<Satellite_Kinematics.CoverageRecord> vmethod_2()
	{
		return observableList_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_3(ObservableList<Satellite_Kinematics.CoverageRecord> WithEventsValue)
	{
		EventHandler<ObservableListModified<Satellite_Kinematics.CoverageRecord>> value = method_7;
		ObservableList<Satellite_Kinematics.CoverageRecord> observableList = observableList_0;
		if (observableList != null)
		{
			observableList.ItemsAdded -= value;
		}
		observableList_0 = WithEventsValue;
		observableList = observableList_0;
		if (observableList != null)
		{
			observableList.ItemsAdded += value;
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

	public void DoPredictions()
	{
		if (!bool_3)
		{
			int_3 = int_0 * 24 * 60;
			Button1.Text = "Calculating...";
			Button1.Enabled = false;
			((Control)NumericUpDown1).Enabled = false;
			((DataGridView)DataGridView1).Rows.Clear();
			ListView1.Items.Clear();
			vmethod_1(new BackgroundWorker());
			vmethod_0().WorkerSupportsCancellation = true;
			vmethod_0().RunWorkerAsync();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		int_0 = Convert.ToInt32(((NumericUpDown)NumericUpDown1).Value);
	}

	private void method_3()
	{
		int_0 = Convert.ToInt32(((NumericUpDown)NumericUpDown1).Value);
	}

	private void method_4(object sender, EventArgs e)
	{
		DoPredictions();
	}

	private void SatPredictionForm_Shown(object sender, EventArgs e)
	{
		int_0 = 2;
		((NumericUpDown)NumericUpDown1).Value = new decimal(int_0);
		DoPredictions();
	}

	private void method_5(object sender, DoWorkEventArgs e)
	{
		try
		{
			bool_3 = true;
			Geopoint_Struct locationPoint = new Geopoint_Struct(LocationLongitude, LocationLatitude);
			new Module_Unit.Unit();
			vmethod_3(new ObservableList<Satellite_Kinematics.CoverageRecord>());
			DateTime time = Client.CurrentScenario.Time;
			DateTime endTime = time.AddSeconds(int_0 * 24 * 3600);
			List<ActiveUnit> list = Client.CurrentScenario.ActiveUnits_List.Where([SpecialName] (ActiveUnit theAU) => theAU.IsSatellite).ToList();
			int_1 = list.Count;
			int_2 = 0;
			foreach (ActiveUnit item in list)
			{
				if (vmethod_0().CancellationPending)
				{
					break;
				}
				if (!Information.IsNothing((object)item) && item.Sensors_Cached.Count() >= 1)
				{
					Satellite satellite = (Satellite)item;
					Sensor sensor = satellite.Sensors_Cached.OrderByDescending([SpecialName] (Sensor theS) => theS.maxRange).First();
					List<Satellite_Kinematics.CoverageRecord> collection = Satellite_Kinematics.PassPrediction(locationPoint, satellite, time, endTime, sensor.maxRange, 90f + sensor.MaxElevationAngle);
					vmethod_2().AddRange(collection);
					int_2++;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200403", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			bool_3 = false;
			ProjectData.ClearProjectError();
		}
	}

	private void method_6(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			Button1.Text = "Recalculate";
			Button1.Enabled = true;
			((Control)NumericUpDown1).Enabled = true;
			DarkUIProgressBar1.Value = 100;
			bool_3 = false;
			List<DarkListItem> list = ListView1.Items.OrderBy([SpecialName] (DarkListItem theItem) => ((Tuple<long, long>)theItem.Tag).Item2).ToList();
			ListView1.Items.Clear();
			foreach (DarkListItem item in list)
			{
				ListView1.Items.Add(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200404", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			bool_3 = false;
			ProjectData.ClearProjectError();
		}
	}

	private void SatPredictionForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		vmethod_0().CancelAsync();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void SatPredictionForm_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_7(object object_0, ObservableListModified<Satellite_Kinematics.CoverageRecord> observableListModified_0)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		_Closure$__107-0 closure$__107- = default(_Closure$__107-0);
		foreach (Satellite_Kinematics.CoverageRecord item in observableListModified_0.Items)
		{
			closure$__107- = new _Closure$__107-0(closure$__107-);
			closure$__107-.$VB$Me = this;
			long num = (long)Math.Round((item.StartOfCoverage - Client.CurrentScenario.Time).TotalSeconds);
			string text = Misc.TimeString(num);
			closure$__107-.$VB$Local_row = new DataGridViewRow();
			((DataGridViewBand)closure$__107-.$VB$Local_row).Tag = item.theSat;
			closure$__107-.$VB$Local_row.CreateCells((DataGridView)(object)DataGridView1);
			closure$__107-.$VB$Local_row.Cells[0].Value = item.theSat.Name + " (" + item.theSat.UnitClass + ")";
			closure$__107-.$VB$Local_row.Cells[1].Value = ((ActiveUnit)item.theSat).get_UnitSide(SetSideOnly: false).Name;
			if (DateTime.Compare(item.StartOfCoverage, Client.CurrentScenario.Time) <= 0)
			{
				closure$__107-.$VB$Local_row.Cells[2].Value = Strings.Format((object)item.StartOfCoverage, "yyyy/MM/dd HH:mm:ss") + " (NOW)";
			}
			else
			{
				closure$__107-.$VB$Local_row.Cells[2].Value = Strings.Format((object)item.StartOfCoverage, "yyyy/MM/dd HH:mm:ss") + " (" + text + " from now)";
			}
			closure$__107-.$VB$Local_row.Cells[3].Value = Misc.TimeString(item.DwellTime);
			closure$__107-.$VB$Local_item = new DarkListItem();
			if (num > 0L)
			{
				closure$__107-.$VB$Local_item.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(item.theSat.Name + " - dwell "), closure$__107-.$VB$Local_row.Cells[3].Value), (object)" (in "), (object)text), (object)")"));
			}
			else
			{
				closure$__107-.$VB$Local_item.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(closure$__107-.$VB$Local_row.Cells[0].Value, (object)" - dwell "), closure$__107-.$VB$Local_row.Cells[3].Value), (object)" (NOW)"));
			}
			closure$__107-.$VB$Local_item.TextColor = Client.get_ColorFromStance(Client.CurrentScenario.GetCurrentSide().get_ConsidersThisSideToBe(((ActiveUnit)item.theSat).get_UnitSide(SetSideOnly: false), (Scenario)null));
			closure$__107-.$VB$Local_item.Tag = Tuple.Create(item.DwellTime, num);
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__107-._Lambda$__0));
		}
	}

	public void DrawListViewItem(object sender, DrawDarkListViewListItemEventArgs e)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		if (bool_3 || e.m_item == null || e.m_item.Tag == null)
		{
			return;
		}
		Graphics graphics = e.m_graphics;
		Rectangle rect = e.m_rect;
		Tuple<long, long> tuple = (Tuple<long, long>)e.m_item.Tag;
		int num = Math.Max(1, (int)Math.Round(new TimeSpan(0, 0, (int)tuple.Item1).TotalMinutes * (double)rect.Width / (double)int_3));
		TimeSpan timeSpan = new TimeSpan(0, 0, (int)tuple.Item2);
		int num2 = rect.Left + Math.Max(0, (int)Math.Round(timeSpan.TotalMinutes * (double)rect.Width / (double)int_3));
		SolidBrush val = new SolidBrush(e.m_item.TextColor);
		graphics.FillRectangle((Brush)(object)val, num2, rect.Top, num, rect.Height);
		Brush val2 = Brushes.LightGray;
		int num3 = num2;
		int num4 = (int)Math.Round(1f + graphics.MeasureString(e.m_item.Text, ((Control)ListView1).Font).Width);
		if (num3 + num + num4 > rect.Width)
		{
			num3 = Math.Max(2, num3 - num4);
			int num5;
			if (num3 == 2 && (double)num > (double)num4 / 4.0 && (double)e.m_item.TextColor.GetBrightness() > 0.5)
			{
				val2 = Brushes.Black;
				num5 = 0;
			}
			else
			{
				num5 = 0;
			}
			num = num5;
		}
		graphics.DrawString(e.m_item.Text, ((Control)ListView1).Font, val2, (float)(num3 + num), (float)e.m_rect.Top);
	}

	static SatPredictionForm()
	{
		Class72.smethod_20();
	}
}

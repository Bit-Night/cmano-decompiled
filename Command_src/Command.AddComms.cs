using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddComms : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _DataGridView1;

	[AccessedThroughProperty("BW1")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddSelected")]
	private DarkUIButton _Button_AddSelected;

	[AccessedThroughProperty("TB_Find")]
	[CompilerGenerated]
	private DarkUITextBox _TB_Find;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Add10K")]
	private DarkUIButton darkUIButton_0;

	private DataTable dataTable_0;

	private DataView MfwHryxnibr;

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
			backgroundWorker_0 = value;
		}
	}

	internal virtual DarkUIButton Button_AddSelected
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_AddSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AddSelected = value;
			darkUIButton = _Button_AddSelected;
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
			EventHandler eventHandler = method_9;
			EventHandler eventHandler2 = method_10;
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

	internal virtual DarkUIButton Button_Add10K
	{
		[CompilerGenerated]
		get
		{
			return darkUIButton_0;
		}
		[CompilerGenerated]
		set
		{
			darkUIButton_0 = value;
		}
	}

	[field: AccessedThroughProperty("CB_Filter3")]
	internal virtual DarkCheckBox CB_Filter3 { get; set; }

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("Description")]
	internal virtual DataGridViewTextBoxColumn Description { get; set; }

	[field: AccessedThroughProperty("Type")]
	internal virtual DataGridViewTextBoxColumn Type { get; set; }

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	public AddComms()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += AddComms_Shown;
		((Control)this).KeyDown += new KeyEventHandler(AddComms_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(AddComms_FormClosing);
		((Form)this).Load += AddComms_Load;
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Expected O, but got Unknown
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Expected O, but got Unknown
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Expected O, but got Unknown
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a2: Expected O, but got Unknown
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07be: Expected O, but got Unknown
		//IL_07d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07da: Expected O, but got Unknown
		//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f6: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Type = new DataGridViewTextBoxColumn();
		BW1 = new BackgroundWorker();
		Button_AddSelected = new DarkUIButton();
		TB_Find = new DarkUITextBox();
		CB_Filter3 = new DarkCheckBox();
		TableLayoutPanel1 = new TableLayoutPanel();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridView)DataGridView1).AllowUserToDeleteRows = false;
		((DataGridView)DataGridView1).AllowUserToOrderColumns = true;
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
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)Description,
			(DataGridViewColumn)Type
		});
		TableLayoutPanel1.SetColumnSpan((Control)(object)DataGridView1, 3);
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DataGridView1).DefaultCellStyle = val2;
		((Control)DataGridView1).Dock = (DockStyle)5;
		((DataGridView)DataGridView1).EnableHeadersVisualStyles = false;
		((Control)DataGridView1).Location = new Point(3, 106);
		((DataGridView)DataGridView1).MultiSelect = false;
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).ReadOnly = true;
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		((DataGridView)DataGridView1).RowHeadersWidth = 62;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((DataGridView)DataGridView1).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DataGridView1).Size = new Size(1113, 397);
		((Control)DataGridView1).TabIndex = 1;
		((DataGridViewColumn)ID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).MinimumWidth = 8;
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Width = 64;
		((DataGridViewColumn)Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Description).DataPropertyName = "Name";
		((DataGridViewColumn)Description).HeaderText = "Description";
		((DataGridViewColumn)Description).MinimumWidth = 8;
		((DataGridViewColumn)Description).Name = "Description";
		((DataGridViewColumn)Description).ReadOnly = true;
		((DataGridViewColumn)Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Type).DataPropertyName = "Type";
		((DataGridViewColumn)Type).HeaderText = "Type";
		((DataGridViewColumn)Type).MinimumWidth = 8;
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).ReadOnly = true;
		((ButtonBase)Button_AddSelected).BackColor = Color.Transparent;
		((Control)Button_AddSelected).Dock = (DockStyle)5;
		((Control)Button_AddSelected).Font = new Font("Segoe UI", 10f);
		((Control)Button_AddSelected).ForeColor = SystemColors.Control;
		((Control)Button_AddSelected).Location = new Point(3, 3);
		((Control)Button_AddSelected).Name = "Button_AddSelected";
		((Control)Button_AddSelected).Padding = new Padding(5);
		Button_AddSelected.RoundRadius = 0;
		((Control)Button_AddSelected).Size = new Size(217, 29);
		((Control)Button_AddSelected).TabIndex = 3;
		Button_AddSelected.Text = "Add Selected";
		TB_Find.AutoCompleteCustomSource = null;
		TB_Find.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Find.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Find).BackColor = Color.Transparent;
		TableLayoutPanel1.SetColumnSpan((Control)(object)TB_Find, 2);
		((Control)TB_Find).Dock = (DockStyle)5;
		TB_Find.Font = new Font("Segoe UI", 8f);
		((Control)TB_Find).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		((Control)TB_Find).Location = new Point(3, 38);
		TB_Find.MaxLength = 32767;
		TB_Find.Multiline = false;
		((Control)TB_Find).Name = "TB_Find";
		TB_Find.ReadOnly = false;
		TB_Find.ScrollBars = (ScrollBars)0;
		TB_Find.SelectionStart = 0;
		((Control)TB_Find).Size = new Size(440, 29);
		((Control)TB_Find).TabIndex = 12;
		TB_Find.TextAlign = (HorizontalAlignment)0;
		TB_Find.UseSystemPasswordChar = false;
		TB_Find.WatermarkText = "Search Comms...";
		TB_Find.WordWrap = false;
		((ButtonBase)CB_Filter3).AutoSize = true;
		((Control)CB_Filter3).Location = new Point(3, 73);
		((Control)CB_Filter3).Name = "CB_Filter3";
		((Control)CB_Filter3).Size = new Size(145, 27);
		((Control)CB_Filter3).TabIndex = 15;
		((ButtonBase)CB_Filter3).Text = "Filter by type:";
		TableLayoutPanel1.ColumnCount = 3;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 20f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 20f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 60f));
		TableLayoutPanel1.Controls.Add((Control)(object)Button_AddSelected, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)DataGridView1, 0, 3);
		TableLayoutPanel1.Controls.Add((Control)(object)CB_Filter3, 0, 2);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_Find, 0, 1);
		((Control)TableLayoutPanel1).Dock = (DockStyle)5;
		((Control)TableLayoutPanel1).Location = new Point(0, 0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 4;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 6.988399f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 6.988399f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 6.708231f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 79.31497f));
		((Control)TableLayoutPanel1).Size = new Size(1119, 506);
		((Control)TableLayoutPanel1).TabIndex = 16;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1119, 506);
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddComms";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Add Comms device";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)TableLayoutPanel1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	private void method_2(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		if ((object)FormThatCalledMe == Client.theCommsWindow && Client.theCommsWindow.theSelectedUnit != null)
		{
			int commDeviceDBID = Conversions.ToInteger(((DataGridView)DataGridView1).CurrentRow.Cells["ID"].Value);
			UnitComms theCommsWindow;
			ActiveUnit theParentPlatform = (theCommsWindow = Client.theCommsWindow).theSelectedUnit;
			CommDevice commDevice = DBFunctions.GetCommDevice(commDeviceDBID, ref theParentPlatform);
			theCommsWindow.theSelectedUnit = theParentPlatform;
			CommDevice commDevice2 = commDevice;
			if (commDevice2 != null)
			{
				Client.theCommsWindow.theSelectedUnit.AddCommDevice(commDevice2);
			}
			if (((Control)Client.theCommsWindow).Visible)
			{
				Client.theCommsWindow.BuildForm();
			}
		}
	}

	private void method_4()
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		dataTable_0 = DBFunctions.GetAllCommDevices(ref sqliteConnection_, Client.CurrentScenario);
	}

	private void method_5(object object_0)
	{
		if (!(((CheckBox)CB_Filter3).Checked & (Operators.CompareString(TB_Find.Text, "", true) != 0)))
		{
			if (Operators.CompareString(TB_Find.Text, "", true) == 0)
			{
				method_8();
			}
			else
			{
				method_6();
			}
		}
		else
		{
			method_7();
		}
	}

	private void method_6()
	{
		DataView dataView = new DataView(dataTable_0);
		dataView.RowFilter = "Name LIKE '%" + Misc.EscapeLikeValue(TB_Find.Text) + "%'";
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		((DataGridView)DataGridView1).DataSource = dataView;
		((Control)DataGridView1).Refresh();
	}

	private void method_7()
	{
		DataView dataView = new DataView(dataTable_0);
		dataView.RowFilter = "Type LIKE '%" + Misc.EscapeLikeValue(TB_Find.Text) + "%'";
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		((DataGridView)DataGridView1).DataSource = dataView;
		((Control)DataGridView1).Refresh();
	}

	private void method_8()
	{
		dataTable_0 = null;
		if (dataTable_0 == null)
		{
			method_4();
		}
		((Control)this).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			MfwHryxnibr = new DataView(dataTable_0);
			MfwHryxnibr.Sort = "Name ASC";
			((DataGridView)DataGridView1).AutoGenerateColumns = true;
			((DataGridView)DataGridView1).Columns.Clear();
			((DataGridView)DataGridView1).DataSource = MfwHryxnibr;
			((Control)DataGridView1).Dock = (DockStyle)5;
			((DataGridView)DataGridView1).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
		}));
	}

	public void InjectFilterByKeyword(string name)
	{
		method_4();
		TB_Find.Text = name;
		method_6();
	}

	private void AddComms_Shown(object sender, EventArgs e)
	{
		Task.Factory.StartNew(method_8);
	}

	private void AddComms_KeyDown(object sender, KeyEventArgs e)
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

	private void method_9(object sender, EventArgs e)
	{
		bool_2 = true;
	}

	private void method_10(object sender, EventArgs e)
	{
		bool_2 = false;
	}

	private void AddComms_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void AddComms_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
	}

	private void method_11(object sender, DataGridViewCellEventArgs e)
	{
		method_3();
	}

	static AddComms()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command;

[DesignerGenerated]
public class GroupFilterManager : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SubType")]
	private DarkUIComboBox _CB_SubType;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Hypothetical")]
	private DarkUIComboBox _CB_Hypothetical;

	[AccessedThroughProperty("CB_Country")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Country;

	[AccessedThroughProperty("DGV_DBID")]
	[CompilerGenerated]
	private DarkDataGridView _DGV_DBID;

	[AccessedThroughProperty("Btn_ADD")]
	[CompilerGenerated]
	private DarkUIButton _Btn_ADD;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_Remove")]
	private DarkUIButton _Btn_Remove;

	[CompilerGenerated]
	[AccessedThroughProperty("btnExport")]
	private DarkUIButton _btnExport;

	[CompilerGenerated]
	[AccessedThroughProperty("btn_import")]
	private DarkUIButton _btn_import;

	[CompilerGenerated]
	[AccessedThroughProperty("btn_db")]
	private DarkUIButton _btn_db;

	[CompilerGenerated]
	[AccessedThroughProperty("btn_from_sel_base")]
	private DarkUIButton _btn_from_sel_base;

	private DataTable dataTable_0;

	private DataTable dataTable_1;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUIComboBox CB_SubType
	{
		[CompilerGenerated]
		get
		{
			return _CB_SubType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIComboBox darkUIComboBox = _CB_SubType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_SubType = value;
			darkUIComboBox = _CB_SubType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_Hypothetical
	{
		[CompilerGenerated]
		get
		{
			return _CB_Hypothetical;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIComboBox darkUIComboBox = _CB_Hypothetical;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_Hypothetical = value;
			darkUIComboBox = _CB_Hypothetical;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	internal virtual DarkUIComboBox CB_Country
	{
		[CompilerGenerated]
		get
		{
			return _CB_Country;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIComboBox darkUIComboBox = _CB_Country;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_Country = value;
			darkUIComboBox = _CB_Country;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("TB_Class")]
	internal virtual DarkUITextBox TB_Class { get; set; }

	internal virtual DarkDataGridView DGV_DBID
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DBID;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_7);
			DarkDataGridView darkDataGridView = _DGV_DBID;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick -= val;
			}
			_DGV_DBID = value;
			darkDataGridView = _DGV_DBID;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("FullName")]
	internal virtual DataGridViewLinkColumn FullName { get; set; }

	[field: AccessedThroughProperty("ShortName")]
	internal virtual DataGridViewTextBoxColumn ShortName { get; set; }

	[field: AccessedThroughProperty("Country")]
	internal virtual DataGridViewTextBoxColumn Country { get; set; }

	[field: AccessedThroughProperty("IOC")]
	internal virtual DataGridViewTextBoxColumn IOC { get; set; }

	[field: AccessedThroughProperty("Retired")]
	internal virtual DataGridViewTextBoxColumn Retired { get; set; }

	[field: AccessedThroughProperty("Hypothetical")]
	internal virtual DataGridViewCheckBoxColumn Hypothetical { get; set; }

	[field: AccessedThroughProperty("CountryNumber")]
	internal virtual DataGridViewTextBoxColumn CountryNumber { get; set; }

	[field: AccessedThroughProperty("DGV_Loadouts")]
	internal virtual DarkDataGridView DGV_Loadouts { get; set; }

	internal virtual DarkUIButton Btn_ADD
	{
		[CompilerGenerated]
		get
		{
			return _Btn_ADD;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _Btn_ADD;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_ADD = value;
			darkUIButton = _Btn_ADD;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Btn_Remove
	{
		[CompilerGenerated]
		get
		{
			return _Btn_Remove;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _Btn_Remove;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_Remove = value;
			darkUIButton = _Btn_Remove;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DGV_File")]
	internal virtual DarkDataGridView DGV_File { get; set; }

	internal virtual DarkUIButton btnExport
	{
		[CompilerGenerated]
		get
		{
			return _btnExport;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUIButton darkUIButton = _btnExport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnExport = value;
			darkUIButton = _btnExport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btn_import
	{
		[CompilerGenerated]
		get
		{
			return _btn_import;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIButton darkUIButton = _btn_import;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btn_import = value;
			darkUIButton = _btn_import;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btn_db
	{
		[CompilerGenerated]
		get
		{
			return _btn_db;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _btn_db;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btn_db = value;
			darkUIButton = _btn_db;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("UpDown_ID")]
	internal virtual NumericUpDown UpDown_ID { get; set; }

	internal virtual DarkUIButton btn_from_sel_base
	{
		[CompilerGenerated]
		get
		{
			return _btn_from_sel_base;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIButton darkUIButton = _btn_from_sel_base;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btn_from_sel_base = value;
			darkUIButton = _btn_from_sel_base;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public GroupFilterManager()
	{
		((Form)this).Shown += GroupFilterManager_Shown;
		dataTable_0 = new DataTable();
		dataTable_1 = new DataTable();
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
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Expected O, but got Unknown
		//IL_08f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Expected O, but got Unknown
		//IL_09d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Expected O, but got Unknown
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Expected O, but got Unknown
		//IL_0f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9d: Expected O, but got Unknown
		//IL_124f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1259: Expected O, but got Unknown
		//IL_12da: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e4: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		GroupBox1 = new DarkGroupBox();
		DarkLabel1 = new DarkLabel();
		CB_SubType = new DarkUIComboBox();
		CB_Hypothetical = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_Country = new DarkUIComboBox();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		TB_Class = new DarkUITextBox();
		DGV_DBID = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		FullName = new DataGridViewLinkColumn();
		ShortName = new DataGridViewTextBoxColumn();
		Country = new DataGridViewTextBoxColumn();
		IOC = new DataGridViewTextBoxColumn();
		Retired = new DataGridViewTextBoxColumn();
		Hypothetical = new DataGridViewCheckBoxColumn();
		CountryNumber = new DataGridViewTextBoxColumn();
		DGV_Loadouts = new DarkDataGridView();
		Btn_ADD = new DarkUIButton();
		Btn_Remove = new DarkUIButton();
		DGV_File = new DarkDataGridView();
		btnExport = new DarkUIButton();
		btn_import = new DarkUIButton();
		btn_db = new DarkUIButton();
		UpDown_ID = new NumericUpDown();
		btn_from_sel_base = new DarkUIButton();
		((Control)GroupBox1).SuspendLayout();
		((ISupportInitialize)(object)DGV_DBID).BeginInit();
		((ISupportInitialize)(object)DGV_Loadouts).BeginInit();
		((ISupportInitialize)(object)DGV_File).BeginInit();
		((ISupportInitialize)UpDown_ID).BeginInit();
		((Control)this).SuspendLayout();
		((Control)GroupBox1).Controls.Add((Control)(object)DarkLabel1);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_SubType);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Hypothetical);
		((Control)GroupBox1).Controls.Add((Control)(object)Label7);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Country);
		((Control)GroupBox1).Controls.Add((Control)(object)Label5);
		((Control)GroupBox1).Controls.Add((Control)(object)Label4);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Class);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(12, 12);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(457, 94);
		((Control)GroupBox1).TabIndex = 13;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Filter by...";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(7, 49);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(84, 25);
		((Control)DarkLabel1).TabIndex = 20;
		((Label)DarkLabel1).Text = "SubType:";
		((Control)CB_SubType).Anchor = (AnchorStyles)13;
		((ComboBox)CB_SubType).BackColor = Color.Transparent;
		((ComboBox)CB_SubType).DrawMode = (DrawMode)1;
		((ComboBox)CB_SubType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_SubType).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_SubType).FormattingEnabled = true;
		((Control)CB_SubType).Location = new Point(88, 43);
		((Control)CB_SubType).Name = "CB_SubType";
		((Control)CB_SubType).Size = new Size(201, 27);
		((Control)CB_SubType).TabIndex = 19;
		((Control)CB_Hypothetical).Anchor = (AnchorStyles)13;
		((ComboBox)CB_Hypothetical).BackColor = Color.Transparent;
		((ComboBox)CB_Hypothetical).DrawMode = (DrawMode)1;
		((ComboBox)CB_Hypothetical).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Hypothetical).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Hypothetical).FormattingEnabled = true;
		((ComboBox)CB_Hypothetical).Items.AddRange(new object[1] { "Aircraft" });
		((Control)CB_Hypothetical).Location = new Point(88, 67);
		((Control)CB_Hypothetical).Name = "CB_Hypothetical";
		((Control)CB_Hypothetical).Size = new Size(363, 27);
		((Control)CB_Hypothetical).TabIndex = 18;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(4, 73);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(116, 25);
		((Control)Label7).TabIndex = 17;
		((Label)Label7).Text = "Hypothetical:";
		((Control)CB_Country).Anchor = (AnchorStyles)13;
		((ComboBox)CB_Country).BackColor = Color.Transparent;
		((ComboBox)CB_Country).DrawMode = (DrawMode)1;
		((ComboBox)CB_Country).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Country).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Country).FormattingEnabled = true;
		((ComboBox)CB_Country).Items.AddRange(new object[1] { "Aircraft" });
		((Control)CB_Country).Location = new Point(278, 15);
		((Control)CB_Country).Name = "CB_Country";
		((Control)CB_Country).Size = new Size(173, 27);
		((Control)CB_Country).TabIndex = 13;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(226, 20);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(79, 25);
		((Control)Label5).TabIndex = 12;
		((Label)Label5).Text = "Country:";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(7, 20);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(56, 25);
		((Control)Label4).TabIndex = 11;
		((Label)Label4).Text = "Class:";
		((Control)TB_Class).Anchor = (AnchorStyles)13;
		TB_Class.AutoCompleteCustomSource = null;
		TB_Class.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Class.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Class).BackColor = Color.Transparent;
		TB_Class.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TB_Class).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Class.Image = null;
		TB_Class.Lines = null;
		((Control)TB_Class).Location = new Point(88, 15);
		TB_Class.MaxLength = 32767;
		TB_Class.Multiline = false;
		((Control)TB_Class).Name = "TB_Class";
		TB_Class.ReadOnly = false;
		TB_Class.ScrollBars = (ScrollBars)0;
		TB_Class.SelectionStart = 0;
		((Control)TB_Class).Size = new Size(132, 22);
		((Control)TB_Class).TabIndex = 10;
		TB_Class.TextAlign = (HorizontalAlignment)0;
		TB_Class.UseSystemPasswordChar = false;
		TB_Class.WatermarkText = "";
		((DataGridView)DGV_DBID).AllowUserToAddRows = false;
		((DataGridView)DGV_DBID).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DBID).AllowUserToOrderColumns = true;
		((DataGridView)DGV_DBID).AllowUserToResizeColumns = false;
		((DataGridView)DGV_DBID).AllowUserToResizeRows = false;
		((Control)DGV_DBID).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_DBID).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_DBID).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DBID).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_DBID).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DBID).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_DBID).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_DBID).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[8]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)FullName,
			(DataGridViewColumn)ShortName,
			(DataGridViewColumn)Country,
			(DataGridViewColumn)IOC,
			(DataGridViewColumn)Retired,
			(DataGridViewColumn)Hypothetical,
			(DataGridViewColumn)CountryNumber
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DBID).DefaultCellStyle = val2;
		((DataGridView)DGV_DBID).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_DBID).EnableHeadersVisualStyles = false;
		((Control)DGV_DBID).Location = new Point(12, 123);
		((DataGridView)DGV_DBID).MultiSelect = false;
		((Control)DGV_DBID).Name = "DGV_DBID";
		((DataGridView)DGV_DBID).ReadOnly = true;
		((DataGridView)DGV_DBID).RowHeadersVisible = false;
		((DataGridView)DGV_DBID).RowHeadersWidth = 62;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_DBID).RowsDefaultCellStyle = val3;
		((DataGridView)DGV_DBID).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_DBID).Size = new Size(604, 608);
		((Control)DGV_DBID).TabIndex = 14;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).MinimumWidth = 8;
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)ID).Width = 150;
		((DataGridViewColumn)FullName).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)FullName).DataPropertyName = "LongName";
		((DataGridViewColumn)FullName).HeaderText = "Platform";
		FullName.LinkColor = Color.LightBlue;
		((DataGridViewColumn)FullName).MinimumWidth = 8;
		((DataGridViewColumn)FullName).Name = "FullName";
		((DataGridViewColumn)FullName).ReadOnly = true;
		((DataGridViewColumn)FullName).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)FullName).SortMode = (DataGridViewColumnSortMode)1;
		((DataGridViewColumn)FullName).Width = 230;
		((DataGridViewColumn)ShortName).DataPropertyName = "Name";
		((DataGridViewColumn)ShortName).HeaderText = "ShortName";
		((DataGridViewColumn)ShortName).MinimumWidth = 8;
		((DataGridViewColumn)ShortName).Name = "ShortName";
		((DataGridViewColumn)ShortName).ReadOnly = true;
		((DataGridViewColumn)ShortName).Visible = false;
		((DataGridViewColumn)ShortName).Width = 150;
		((DataGridViewColumn)Country).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Country).DataPropertyName = "CountryString";
		((DataGridViewColumn)Country).HeaderText = "Country";
		((DataGridViewColumn)Country).MinimumWidth = 8;
		((DataGridViewColumn)Country).Name = "Country";
		((DataGridViewColumn)Country).ReadOnly = true;
		((DataGridViewColumn)Country).Width = 109;
		((DataGridViewColumn)IOC).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)IOC).DataPropertyName = "YearCommissioned";
		((DataGridViewColumn)IOC).HeaderText = "From";
		((DataGridViewColumn)IOC).MinimumWidth = 8;
		((DataGridViewColumn)IOC).Name = "IOC";
		((DataGridViewColumn)IOC).ReadOnly = true;
		((DataGridViewColumn)IOC).Width = 88;
		((DataGridViewColumn)Retired).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Retired).DataPropertyName = "YearDecommissioned";
		((DataGridViewColumn)Retired).HeaderText = "Until";
		((DataGridViewColumn)Retired).MinimumWidth = 8;
		((DataGridViewColumn)Retired).Name = "Retired";
		((DataGridViewColumn)Retired).ReadOnly = true;
		((DataGridViewColumn)Retired).Width = 82;
		((DataGridViewColumn)Hypothetical).AutoSizeMode = (DataGridViewAutoSizeColumnMode)2;
		((DataGridViewColumn)Hypothetical).DataPropertyName = "Hypothetical";
		Hypothetical.FalseValue = "False";
		((DataGridViewColumn)Hypothetical).HeaderText = "Hypo";
		((DataGridViewColumn)Hypothetical).MinimumWidth = 8;
		((DataGridViewColumn)Hypothetical).Name = "Hypothetical";
		((DataGridViewColumn)Hypothetical).ReadOnly = true;
		((DataGridViewColumn)Hypothetical).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)Hypothetical).SortMode = (DataGridViewColumnSortMode)1;
		Hypothetical.TrueValue = "True";
		((DataGridViewColumn)Hypothetical).Width = 90;
		((DataGridViewColumn)CountryNumber).DataPropertyName = "OperatorCountry";
		((DataGridViewColumn)CountryNumber).HeaderText = "Operator";
		((DataGridViewColumn)CountryNumber).MinimumWidth = 8;
		((DataGridViewColumn)CountryNumber).Name = "CountryNumber";
		((DataGridViewColumn)CountryNumber).ReadOnly = true;
		((DataGridViewColumn)CountryNumber).Visible = false;
		((DataGridViewColumn)CountryNumber).Width = 150;
		((DataGridView)DGV_Loadouts).AllowUserToAddRows = false;
		((DataGridView)DGV_Loadouts).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Loadouts).AllowUserToOrderColumns = true;
		((DataGridView)DGV_Loadouts).AllowUserToResizeColumns = false;
		((DataGridView)DGV_Loadouts).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Loadouts).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_Loadouts).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Loadouts).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Loadouts).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_Loadouts).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Loadouts).DefaultCellStyle = val5;
		((DataGridView)DGV_Loadouts).EnableHeadersVisualStyles = false;
		((Control)DGV_Loadouts).Location = new Point(655, 123);
		((Control)DGV_Loadouts).Name = "DGV_Loadouts";
		((DataGridView)DGV_Loadouts).RowHeadersWidth = 62;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Loadouts).RowsDefaultCellStyle = val6;
		((DataGridView)DGV_Loadouts).RowTemplate.Height = 28;
		((DataGridView)DGV_Loadouts).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_Loadouts).Size = new Size(726, 260);
		((Control)DGV_Loadouts).TabIndex = 15;
		((ButtonBase)Btn_ADD).BackColor = Color.Transparent;
		((Button)Btn_ADD).DialogResult = (DialogResult)0;
		((Control)Btn_ADD).ForeColor = SystemColors.Control;
		((Control)Btn_ADD).Location = new Point(799, 398);
		((Control)Btn_ADD).Name = "Btn_ADD";
		Btn_ADD.RoundRadius = 0;
		((Control)Btn_ADD).Size = new Size(100, 27);
		((Control)Btn_ADD).TabIndex = 16;
		Btn_ADD.Text = "Add ▼";
		((ButtonBase)Btn_Remove).BackColor = Color.Transparent;
		((Button)Btn_Remove).DialogResult = (DialogResult)0;
		((Control)Btn_Remove).ForeColor = SystemColors.Control;
		((Control)Btn_Remove).Location = new Point(915, 398);
		((Control)Btn_Remove).Name = "Btn_Remove";
		Btn_Remove.RoundRadius = 0;
		((Control)Btn_Remove).Size = new Size(100, 27);
		((Control)Btn_Remove).TabIndex = 17;
		Btn_Remove.Text = "Remove ▲";
		((DataGridView)DGV_File).AllowUserToOrderColumns = true;
		((DataGridView)DGV_File).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_File).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_File).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_File).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = Color.FromArgb(66, 77, 95);
		val7.Font = new Font("Segoe UI", 9f);
		val7.ForeColor = Color.LightGray;
		val7.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val7.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val7.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_File).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_File).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = Color.FromArgb(60, 63, 65);
		val8.Font = new Font("Segoe UI", 9f);
		val8.ForeColor = Color.LightGray;
		val8.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val8.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_File).DefaultCellStyle = val8;
		((DataGridView)DGV_File).EnableHeadersVisualStyles = false;
		((Control)DGV_File).Location = new Point(655, 431);
		((Control)DGV_File).Name = "DGV_File";
		((DataGridView)DGV_File).RowHeadersWidth = 62;
		val9.BackColor = Color.FromArgb(60, 63, 65);
		val9.ForeColor = Color.LightGray;
		val9.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val9.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_File).RowsDefaultCellStyle = val9;
		((DataGridView)DGV_File).RowTemplate.Height = 28;
		((DataGridView)DGV_File).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_File).Size = new Size(360, 300);
		((Control)DGV_File).TabIndex = 18;
		((ButtonBase)btnExport).BackColor = Color.Transparent;
		((Button)btnExport).DialogResult = (DialogResult)0;
		((Control)btnExport).ForeColor = SystemColors.Control;
		((Control)btnExport).Location = new Point(1030, 704);
		((Control)btnExport).Name = "btnExport";
		btnExport.RoundRadius = 0;
		((Control)btnExport).Size = new Size(100, 27);
		((Control)btnExport).TabIndex = 19;
		btnExport.Text = "Export";
		((ButtonBase)btn_import).BackColor = Color.Transparent;
		((Button)btn_import).DialogResult = (DialogResult)0;
		((Control)btn_import).ForeColor = SystemColors.Control;
		((Control)btn_import).Location = new Point(1030, 671);
		((Control)btn_import).Name = "btn_import";
		btn_import.RoundRadius = 0;
		((Control)btn_import).Size = new Size(100, 27);
		((Control)btn_import).TabIndex = 20;
		btn_import.Text = "Import";
		((ButtonBase)btn_db).BackColor = Color.Transparent;
		((Button)btn_db).DialogResult = (DialogResult)0;
		((Control)btn_db).ForeColor = SystemColors.Control;
		((Control)btn_db).Location = new Point(655, 85);
		((Control)btn_db).Name = "btn_db";
		btn_db.RoundRadius = 0;
		((Control)btn_db).Size = new Size(100, 25);
		((Control)btn_db).TabIndex = 21;
		btn_db.Text = "DB Viewer";
		((Control)UpDown_ID).Location = new Point(655, 394);
		((Control)UpDown_ID).Name = "UpDown_ID";
		((Control)UpDown_ID).Size = new Size(120, 31);
		((Control)UpDown_ID).TabIndex = 23;
		((ButtonBase)btn_from_sel_base).BackColor = Color.Transparent;
		((Button)btn_from_sel_base).DialogResult = (DialogResult)0;
		((Control)btn_from_sel_base).ForeColor = SystemColors.Control;
		((Control)btn_from_sel_base).Location = new Point(1030, 398);
		((Control)btn_from_sel_base).Name = "btn_from_sel_base";
		btn_from_sel_base.RoundRadius = 0;
		((Control)btn_from_sel_base).Size = new Size(201, 27);
		((Control)btn_from_sel_base).TabIndex = 24;
		btn_from_sel_base.Text = "From selected base";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(10f, 25f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1393, 743);
		((Control)this).Controls.Add((Control)(object)btn_from_sel_base);
		((Control)this).Controls.Add((Control)(object)UpDown_ID);
		((Control)this).Controls.Add((Control)(object)btn_db);
		((Control)this).Controls.Add((Control)(object)btn_import);
		((Control)this).Controls.Add((Control)(object)btnExport);
		((Control)this).Controls.Add((Control)(object)DGV_File);
		((Control)this).Controls.Add((Control)(object)Btn_Remove);
		((Control)this).Controls.Add((Control)(object)Btn_ADD);
		((Control)this).Controls.Add((Control)(object)DGV_Loadouts);
		((Control)this).Controls.Add((Control)(object)DGV_DBID);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Form)this).MinimumSize = new Size(1415, 799);
		((Control)this).Name = "GroupFilterManager";
		((Form)this).Text = "GroupFilterManager";
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((ISupportInitialize)(object)DGV_DBID).EndInit();
		((ISupportInitialize)(object)DGV_Loadouts).EndInit();
		((ISupportInitialize)(object)DGV_File).EndInit();
		((ISupportInitialize)UpDown_ID).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void GroupFilterManager_Shown(object sender, EventArgs e)
	{
		((DataGridView)DGV_DBID).AutoGenerateColumns = false;
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		((ComboBox)CB_Country).DataSource = cache_OperatorCountries_DT;
		((ListControl)CB_Country).DisplayMember = "Description";
		((ListControl)CB_Country).ValueMember = "ID";
		((ComboBox)CB_Country).SelectedIndex = 0;
		((ComboBox)CB_Hypothetical).Items.Clear();
		((ComboBox)CB_Hypothetical).Items.Add((object)"Show all platforms, both real-life and hypothetical");
		((ComboBox)CB_Hypothetical).Items.Add((object)"Show real-life platforms only");
		((ComboBox)CB_Hypothetical).Items.Add((object)"Show hypothetical platforms only");
		((ComboBox)CB_Hypothetical).SelectedIndex = 0;
		method_2();
		method_4();
		DataTable dataTable = new DataTable();
		DataColumn column = new DataColumn("ID", typeof(int));
		dataTable.Columns.Add(column);
		DataColumn column2 = new DataColumn("Aircraft", typeof(int));
		dataTable.Columns.Add(column2);
		DataColumn column3 = new DataColumn("Equipment", typeof(int));
		dataTable.Columns.Add(column3);
		((DataGridView)DGV_File).DataSource = dataTable;
	}

	private void method_2()
	{
		DataTable dataTable = new DataTable();
		if (!dataTable.Columns.Contains("ID"))
		{
			dataTable.Columns.Add("ID", typeof(int));
		}
		if (!dataTable.Columns.Contains("Description"))
		{
			dataTable.Columns.Add("Description", typeof(string));
		}
		dataTable.Rows.Clear();
		foreach (object value in Enum.GetValues(typeof(Aircraft._AircraftType)))
		{
			Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(value);
			string text = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
			if (!string.IsNullOrEmpty(Misc.Description(aircraftType, Client.CurrentScenario.DBConnection)))
			{
				dataTable.Rows.Add((int)aircraftType, text);
			}
			else
			{
				dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
			}
		}
		if (dataTable.Rows.Count <= 0)
		{
			dataTable.Rows.Add(0, "None");
			DarkUIComboBox cB_SubType = CB_SubType;
			((ComboBox)cB_SubType).DataSource = dataTable;
			((ListControl)cB_SubType).DisplayMember = "Description";
			((ListControl)cB_SubType).ValueMember = "ID";
			((ComboBox)cB_SubType).SelectedIndex = 0;
			((Control)cB_SubType).Enabled = false;
			((Control)cB_SubType).Visible = false;
		}
		else
		{
			DarkUIComboBox cB_SubType2 = CB_SubType;
			((ComboBox)cB_SubType2).DataSource = dataTable;
			((ListControl)cB_SubType2).DisplayMember = "Description";
			((ListControl)cB_SubType2).ValueMember = "ID";
			((ComboBox)cB_SubType2).SelectedIndex = 0;
			((Control)cB_SubType2).Enabled = true;
			((Control)cB_SubType2).Visible = true;
		}
		((ComboBox)CB_SubType).SelectedIndex = 0;
	}

	private void method_3(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_4()
	{
		dataTable_0 = Client.CurrentScenario.Cache_Aircraft_DT;
		if (dataTable_0.Rows.Count == 0)
		{
			return;
		}
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "LongName ASC";
		if (Operators.CompareString(TB_Class.Text, "", true) != 0 || ((ComboBox)CB_Country).SelectedIndex != 0 || ((ComboBox)CB_Hypothetical).SelectedIndex != 0 || ((ComboBox)CB_SubType).SelectedIndex != 0)
		{
			string text = "1=1 ";
			if (Operators.CompareString(TB_Class.Text, "", true) != 0)
			{
				string text2 = TB_Class.Text.Replace("'", "''");
				text = text + " AND LongName LIKE '%" + text2 + "%' ";
			}
			if (((ComboBox)CB_Country).SelectedIndex > 0)
			{
				text = text + " AND OperatorCountry=" + Conversions.ToString(Conversions.ToInteger(((ListControl)CB_Country).SelectedValue));
			}
			if (((ComboBox)CB_SubType).SelectedIndex > 0)
			{
				text = text + " AND type=" + ((ListControl)CB_SubType).SelectedValue.ToString();
			}
			if (((ComboBox)CB_Hypothetical).SelectedIndex == 1)
			{
				text += " AND Hypothetical=FALSE";
			}
			else if (((ComboBox)CB_Hypothetical).SelectedIndex == 2)
			{
				text += " AND Hypothetical=TRUE";
			}
			text = text.Replace("[", "[[");
			text = text.Replace("]", "]]");
			text = text.Replace("[[", "[[]");
			text = text.Replace("]]", "[]]");
			dataView.RowFilter = text;
		}
		((Control)DGV_DBID).SuspendLayout();
		((Control)DGV_DBID).Enabled = false;
		((DataGridView)DGV_DBID).DataSource = dataView;
		((DataGridView)DGV_DBID).Columns[1].AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((Control)DGV_DBID).Refresh();
		((Control)DGV_DBID).Enabled = true;
		((Control)DGV_DBID).ResumeLayout();
	}

	private void method_5(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_6(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_7(object sender, DataGridViewCellEventArgs e)
	{
		string s = ((DataGridView)DGV_DBID).SelectedRows[0].Cells[0].Value.ToString();
		method_8(int.Parse(s));
	}

	private void method_8(int int_0)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Scenario currentScenario = Client.CurrentScenario;
		bool UnlimitedAirWeapons = false;
		Scenario CurrentScenario = null;
		Aircraft SelectedAircraft = null;
		int int_1 = 0;
		bool ExcludeOptionalWeapons = false;
		dataTable_1 = DBFunctions.LoadoutsForThisAircraft_DT(int_0, null, ref sqliteConnection_, currentScenario, ref UnlimitedAirWeapons, ref CurrentScenario, ref SelectedAircraft, ref int_1, ref ExcludeOptionalWeapons);
		((DataGridView)DGV_Loadouts).DataSource = dataTable_1;
	}

	private void method_9(object sender, EventArgs e)
	{
		if (!((((DataGridView)DGV_DBID).SelectedRows == null) | (((DataGridView)DGV_Loadouts).SelectedRows == null)) && !((((BaseCollection)((DataGridView)DGV_DBID).SelectedRows).Count == 0) | (((BaseCollection)((DataGridView)DGV_Loadouts).SelectedRows).Count == 0)))
		{
			int num = 0;
			num = int.Parse(((DataGridView)DGV_DBID).SelectedRows[0].Cells[0].Value.ToString());
			int num2 = 0;
			num2 = int.Parse(((DataGridView)DGV_Loadouts).SelectedRows[0].Cells[0].Value.ToString());
			method_10(UpDown_ID.Value, num, num2);
		}
	}

	private void method_10(decimal decimal_0, int int_0, int int_1)
	{
		DataTable dataTable = (DataTable)((DataGridView)DGV_File).DataSource;
		foreach (DataRow row in dataTable.Rows)
		{
			if ((decimal.Compare(new decimal(Conversions.ToInteger(row.ItemArray[0])), decimal_0) == 0) & (Conversions.ToInteger(row.ItemArray[1]) == int_0) & (Conversions.ToInteger(row.ItemArray[2]) == int_1))
			{
				return;
			}
		}
		DataRow dataRow2 = dataTable.NewRow();
		dataRow2["ID"] = Convert.ToInt32(decimal_0);
		dataRow2["Aircraft"] = int_0;
		dataRow2["Equipment"] = int_1;
		dataTable.Rows.Add(dataRow2);
		MissionPlanner.AdvancedGroupFilters.Add(new AdvancedGroupFilter(Convert.ToInt32(decimal_0), int_0, int_1));
		((Control)DGV_File).Refresh();
	}

	private void method_11(object sender, EventArgs e)
	{
		if (((DataGridView)DGV_File).SelectedRows != null)
		{
			DataTable obj = (DataTable)((DataGridView)DGV_File).DataSource;
			int index = ((DataGridViewBand)((DataGridView)DGV_File).SelectedRows[0]).Index;
			AdvancedGroupFilter item = new AdvancedGroupFilter(Conversions.ToInteger(((DataGridView)DGV_File).SelectedRows[0].Cells[0].FormattedValue.ToString()), Conversions.ToInteger(((DataGridView)DGV_File).SelectedRows[0].Cells[1].FormattedValue.ToString()), Conversions.ToInteger(((DataGridView)DGV_File).SelectedRows[0].Cells[2].FormattedValue.ToString()));
			obj.Rows.RemoveAt(index);
			if (MissionPlanner.AdvancedGroupFilters.Contains(item))
			{
				MissionPlanner.AdvancedGroupFilters.Remove(item);
			}
			((Control)DGV_File).Refresh();
		}
	}

	private void method_12()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		SaveFileDialog val = new SaveFileDialog();
		((FileDialog)val).InitialDirectory = GameGeneral.ScenariosRootPath;
		((FileDialog)val).DefaultExt = "json";
		((DataTable)((DataGridView)DGV_File).DataSource).TableName = "GroupFilter";
		if ((int)((CommonDialog)val).ShowDialog() != 1)
		{
			return;
		}
		try
		{
			string contents = JsonConvert.SerializeObject(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_File).DataSource));
			File.WriteAllText(((FileDialog)val).FileName, contents);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101277", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		method_12();
	}

	private void method_14(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		OpenFileDialog val = new OpenFileDialog();
		((FileDialog)val).InitialDirectory = GameGeneral.ScenariosRootPath;
		((FileDialog)val).DefaultExt = "json";
		if ((int)((CommonDialog)val).ShowDialog() != 1)
		{
			return;
		}
		try
		{
			DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(File.ReadAllText(((FileDialog)val).FileName));
			((DataGridView)DGV_File).DataSource = dataTable;
			((Control)DGV_File).Refresh();
			MissionPlanner.AdvancedGroupFilters = new List<AdvancedGroupFilter>();
			foreach (DataRow row in dataTable.Rows)
			{
				MissionPlanner.AdvancedGroupFilters.Add(new AdvancedGroupFilter(Conversions.ToInteger(row.ItemArray[0]), Conversions.ToInteger(row.ItemArray[1]), Conversions.ToInteger(row.ItemArray[2])));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101276", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		DBViewer.OpenNewDatabaseWindow();
	}

	private void method_16(object sender, EventArgs e)
	{
		if (Client.SelectedUnit == null || !Client.SelectedUnit.IsActiveUnit)
		{
			return;
		}
		ActiveUnit activeUnit = (ActiveUnit)Client.SelectedUnit;
		if (activeUnit.AirOps == null || activeUnit.AirOps.EmbarkedAircraft_ReadOnly == null || activeUnit.AirOps.EmbarkedAircraft_ReadOnly.Count <= 0)
		{
			return;
		}
		foreach (Aircraft item in activeUnit.AirOps.EmbarkedAircraft_ReadOnly)
		{
			int dBID = item.DBID;
			int int32_ = item.LoadoutDBID;
			int value = Convert.ToInt32(UpDown_ID.Value);
			method_10(new decimal(value), dBID, int32_);
		}
	}

	static GroupFilterManager()
	{
		Class72.smethod_20();
	}
}

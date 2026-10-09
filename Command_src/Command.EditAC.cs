using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditAC : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__152-0
	{
		public int $VB$Local_theDBID;

		public _Closure$__152-0(_Closure$__152-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Aircraft AC)
		{
			return AC.DBID == $VB$Local_theDBID;
		}

		static _Closure$__152-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("ListView1")]
	[CompilerGenerated]
	private DarkListView _ListView1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[AccessedThroughProperty("Button_RemoveAC")]
	[CompilerGenerated]
	private DarkUIButton _Button_RemoveAC;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _DataGridView1;

	[AccessedThroughProperty("CB_Country")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Country;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Class")]
	private DarkUITextBox _TB_Class;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_FilterSizeAndTODLAD")]
	private DarkCheckBox _CB_FilterSizeAndTODLAD;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Hypothetical")]
	private DarkUIComboBox _CB_Hypothetical;

	[AccessedThroughProperty("CB_SubType")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_SubType;

	public ActiveUnit SelectedHost;

	private DataTable dataTable_0;

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
			EventHandler eventHandler = method_3;
			EventHandler value2 = method_4;
			EventHandler value3 = method_12;
			DarkListView darkListView = _ListView1;
			if (darkListView != null)
			{
				((Control)darkListView).DoubleClick -= eventHandler;
				darkListView.SelectedIndicesChanged -= value2;
				darkListView.SelectedIndicesChanged -= value3;
			}
			_ListView1 = value;
			darkListView = _ListView1;
			if (darkListView != null)
			{
				((Control)darkListView).DoubleClick += eventHandler;
				darkListView.SelectedIndicesChanged += value2;
				darkListView.SelectedIndicesChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("NUD1")]
	internal virtual DarkNumericUpDown NUD1 { get; set; }

	[field: AccessedThroughProperty("TB_Callsign")]
	internal virtual DarkUITextBox TB_Callsign { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

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
			EventHandler eventHandler = method_5;
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

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("TB_Quantity")]
	internal virtual DarkUITextBox TB_Quantity { get; set; }

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Quantity")]
	internal virtual DarkGroupBox Quantity { get; set; }

	internal virtual DarkUIButton Button_RemoveAC
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveAC;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button_RemoveAC;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RemoveAC = value;
			darkUIButton = _Button_RemoveAC;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

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
			KeyPressEventHandler val = new KeyPressEventHandler(method_8);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_17);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).KeyPress -= val;
				((DataGridView)darkDataGridView).CellContentDoubleClick -= val2;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).KeyPress += val;
				((DataGridView)darkDataGridView).CellContentDoubleClick += val2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

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
			EventHandler eventHandler = method_13;
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

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	internal virtual DarkUITextBox TB_Class
	{
		[CompilerGenerated]
		get
		{
			return _TB_Class;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_10;
			DarkUITextBox darkUITextBox = _TB_Class;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TB_Class = value;
			darkUITextBox = _TB_Class;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkCheckBox CB_FilterSizeAndTODLAD
	{
		[CompilerGenerated]
		get
		{
			return _CB_FilterSizeAndTODLAD;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkCheckBox darkCheckBox = _CB_FilterSizeAndTODLAD;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_FilterSizeAndTODLAD = value;
			darkCheckBox = _CB_FilterSizeAndTODLAD;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
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
			EventHandler eventHandler = method_14;
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
			EventHandler eventHandler = method_16;
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

	[field: AccessedThroughProperty("DBID")]
	internal virtual DataGridViewTextBoxColumn DBID { get; set; }

	[field: AccessedThroughProperty("LongName")]
	internal virtual DataGridViewTextBoxColumn LongName { get; set; }

	[field: AccessedThroughProperty("AcName")]
	internal virtual DataGridViewTextBoxColumn AcName { get; set; }

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

	[field: AccessedThroughProperty("Column2")]
	internal virtual DataGridViewTextBoxColumn Column2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("AcType")]
	internal virtual DataGridViewTextBoxColumn AcType { get; set; }

	[field: AccessedThroughProperty("AcSize")]
	internal virtual DataGridViewTextBoxColumn AcSize { get; set; }

	[field: AccessedThroughProperty("RunwaySizeNeeded")]
	internal virtual DataGridViewTextBoxColumn RunwaySizeNeeded { get; set; }

	[field: AccessedThroughProperty("Deprecated")]
	internal virtual DataGridViewTextBoxColumn Deprecated { get; set; }

	public EditAC()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(EditAC_FormClosing);
		((Form)this).Load += EditAC_Load;
		((Control)this).KeyDown += new KeyEventHandler(EditAC_KeyDown);
		((Form)this).Shown += EditAC_Shown;
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
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected O, but got Unknown
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_064b: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Expected O, but got Unknown
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Expected O, but got Unknown
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Expected O, but got Unknown
		//IL_0a79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b71: Expected O, but got Unknown
		//IL_0c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7a: Expected O, but got Unknown
		//IL_1505: Unknown result type (might be due to invalid IL or missing references)
		//IL_150f: Expected O, but got Unknown
		//IL_1673: Unknown result type (might be due to invalid IL or missing references)
		//IL_167d: Expected O, but got Unknown
		//IL_180d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1817: Expected O, but got Unknown
		//IL_1943: Unknown result type (might be due to invalid IL or missing references)
		//IL_194d: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ListView1 = new DarkListView();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		NUD1 = new DarkNumericUpDown();
		TB_Callsign = new DarkUITextBox();
		Label4 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label5 = new DarkLabel();
		TB_Quantity = new DarkUITextBox();
		Button2 = new DarkUIButton();
		Quantity = new DarkGroupBox();
		Button_RemoveAC = new DarkUIButton();
		DataGridView1 = new DarkDataGridView();
		DBID = new DataGridViewTextBoxColumn();
		LongName = new DataGridViewTextBoxColumn();
		AcName = new DataGridViewTextBoxColumn();
		Country = new DataGridViewTextBoxColumn();
		IOC = new DataGridViewTextBoxColumn();
		Retired = new DataGridViewTextBoxColumn();
		Hypothetical = new DataGridViewCheckBoxColumn();
		CountryNumber = new DataGridViewTextBoxColumn();
		AcType = new DataGridViewTextBoxColumn();
		AcSize = new DataGridViewTextBoxColumn();
		RunwaySizeNeeded = new DataGridViewTextBoxColumn();
		Deprecated = new DataGridViewTextBoxColumn();
		Column2 = new DataGridViewTextBoxColumn();
		GroupBox1 = new DarkGroupBox();
		DarkLabel1 = new DarkLabel();
		CB_Hypothetical = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_FilterSizeAndTODLAD = new DarkCheckBox();
		CB_Country = new DarkUIComboBox();
		Label3 = new DarkLabel();
		Label6 = new DarkLabel();
		TB_Class = new DarkUITextBox();
		CB_SubType = new DarkUIComboBox();
		((ISupportInitialize)NUD1).BeginInit();
		((Control)Quantity).SuspendLayout();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)GroupBox1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)ListView1).Anchor = (AnchorStyles)7;
		((Control)ListView1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ListView1).Location = new Point(12, 34);
		((Control)ListView1).Name = "ListView1";
		ListView1.RelatedInfos = null;
		((Control)ListView1).Size = new Size(278, 583);
		((Control)ListView1).TabIndex = 0;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(12, 15);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(276, 16);
		((Control)Label1).TabIndex = 1;
		((Label)Label1).Text = "Current inventory: Double click to view";
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(294, 15);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(111, 15);
		((Control)Label2).TabIndex = 8;
		((Label)Label2).Text = "Aircraft to add:";
		((UpDownBase)NUD1).BackColor = Color.FromArgb(69, 73, 74);
		((UpDownBase)NUD1).BorderStyle = (BorderStyle)1;
		((UpDownBase)NUD1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD1).Location = new Point(6, 15);
		((NumericUpDown)NUD1).Maximum = new decimal(new int[4] { 99999999, 0, 0, 0 });
		((Control)NUD1).Name = "NUD1";
		((Control)NUD1).Size = new Size(74, 27);
		((Control)NUD1).TabIndex = 10;
		((Control)TB_Callsign).Anchor = (AnchorStyles)6;
		TB_Callsign.AutoCompleteCustomSource = null;
		TB_Callsign.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Callsign.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Callsign).BackColor = Color.FromArgb(69, 73, 74);
		TB_Callsign.Font = new Font("Segoe UI", 8f);
		((Control)TB_Callsign).ForeColor = Color.FromArgb(220, 220, 220);
		TB_Callsign.Image = null;
		TB_Callsign.Lines = null;
		((Control)TB_Callsign).Location = new Point(423, 638);
		TB_Callsign.MaxLength = 32767;
		TB_Callsign.Multiline = false;
		((Control)TB_Callsign).Name = "TB_Callsign";
		TB_Callsign.ReadOnly = false;
		TB_Callsign.ScrollBars = (ScrollBars)0;
		TB_Callsign.SelectionStart = 0;
		((Control)TB_Callsign).Size = new Size(135, 20);
		((Control)TB_Callsign).TabIndex = 11;
		TB_Callsign.TextAlign = (HorizontalAlignment)0;
		TB_Callsign.UseSystemPasswordChar = false;
		TB_Callsign.WatermarkText = "";
		((Control)Label4).Anchor = (AnchorStyles)6;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(370, 641);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(64, 20);
		((Control)Label4).TabIndex = 12;
		((Label)Label4).Text = "Callsign:";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(844, 638);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(111, 22);
		((Control)Button1).TabIndex = 13;
		Button1.Text = "Add Selected";
		((Control)Label5).Anchor = (AnchorStyles)6;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(564, 642);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(83, 20);
		((Control)Label5).TabIndex = 14;
		((Label)Label5).Text = "How many:";
		((Control)TB_Quantity).Anchor = (AnchorStyles)6;
		TB_Quantity.AutoCompleteCustomSource = null;
		TB_Quantity.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Quantity.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Quantity).BackColor = Color.FromArgb(69, 73, 74);
		TB_Quantity.Font = new Font("Segoe UI", 8f);
		((Control)TB_Quantity).ForeColor = Color.FromArgb(220, 220, 220);
		TB_Quantity.Image = null;
		TB_Quantity.Lines = null;
		((Control)TB_Quantity).Location = new Point(632, 638);
		TB_Quantity.MaxLength = 32767;
		TB_Quantity.Multiline = false;
		((Control)TB_Quantity).Name = "TB_Quantity";
		TB_Quantity.ReadOnly = false;
		TB_Quantity.ScrollBars = (ScrollBars)0;
		TB_Quantity.SelectionStart = 0;
		((Control)TB_Quantity).Size = new Size(114, 20);
		((Control)TB_Quantity).TabIndex = 12;
		TB_Quantity.TextAlign = (HorizontalAlignment)0;
		TB_Quantity.UseSystemPasswordChar = false;
		TB_Quantity.WatermarkText = "";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(85, 15);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(65, 22);
		((Control)Button2).TabIndex = 16;
		Button2.Text = "Apply";
		((Control)Quantity).Anchor = (AnchorStyles)6;
		((Control)Quantity).Controls.Add((Control)(object)NUD1);
		((Control)Quantity).Controls.Add((Control)(object)Button2);
		((Control)Quantity).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Quantity).Location = new Point(12, 624);
		((Control)Quantity).Name = "Quantity";
		((Control)Quantity).Size = new Size(155, 41);
		((Control)Quantity).TabIndex = 17;
		((GroupBox)Quantity).TabStop = false;
		((GroupBox)Quantity).Text = "Quantity";
		((Control)Button_RemoveAC).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_RemoveAC).BackColor = Color.IndianRed;
		((Button)Button_RemoveAC).DialogResult = (DialogResult)0;
		((Control)Button_RemoveAC).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_RemoveAC).ForeColor = Color.IndianRed;
		((Control)Button_RemoveAC).Location = new Point(190, 638);
		((Control)Button_RemoveAC).Name = "Button_RemoveAC";
		((Control)Button_RemoveAC).Padding = new Padding(5);
		Button_RemoveAC.RoundRadius = 0;
		((Control)Button_RemoveAC).Size = new Size(100, 22);
		((Control)Button_RemoveAC).TabIndex = 18;
		Button_RemoveAC.Text = "Remove selected";
		((DataGridView)DataGridView1).AllowUserToAddRows = false;
		((DataGridView)DataGridView1).AllowUserToDeleteRows = false;
		((DataGridView)DataGridView1).AllowUserToOrderColumns = true;
		((DataGridView)DataGridView1).AllowUserToResizeColumns = false;
		((DataGridView)DataGridView1).AllowUserToResizeRows = false;
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
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[12]
		{
			(DataGridViewColumn)DBID,
			(DataGridViewColumn)LongName,
			(DataGridViewColumn)Country,
			(DataGridViewColumn)IOC,
			(DataGridViewColumn)Retired,
			(DataGridViewColumn)Hypothetical,
			(DataGridViewColumn)AcType,
			(DataGridViewColumn)AcSize,
			(DataGridViewColumn)RunwaySizeNeeded,
			(DataGridViewColumn)Deprecated,
			(DataGridViewColumn)AcName,
			(DataGridViewColumn)CountryNumber
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DataGridView1).DefaultCellStyle = val2;
		((DataGridView)DataGridView1).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DataGridView1).EnableHeadersVisualStyles = false;
		((Control)DataGridView1).Location = new Point(297, 131);
		((DataGridView)DataGridView1).MultiSelect = false;
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).ReadOnly = true;
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		((DataGridView)DataGridView1).RowHeadersWidth = 51;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((DataGridView)DataGridView1).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DataGridView1).Size = new Size(658, 486);
		((Control)DataGridView1).TabIndex = 21;
		((DataGridViewColumn)DBID).DataPropertyName = "ID";
		((DataGridViewColumn)DBID).HeaderText = "ID";
		((DataGridViewColumn)DBID).MinimumWidth = 6;
		((DataGridViewColumn)DBID).Name = "DBID";
		((DataGridViewColumn)DBID).ReadOnly = true;
		((DataGridViewColumn)DBID).Visible = false;
		((DataGridViewColumn)DBID).Width = 125;
		((DataGridViewColumn)AcName).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)AcName).DataPropertyName = "Name";
		((DataGridViewColumn)AcName).HeaderText = "Aircraft";
		((DataGridViewColumn)AcName).MinimumWidth = 6;
		((DataGridViewColumn)AcName).Name = "Name";
		((DataGridViewColumn)AcName).ReadOnly = true;
		((DataGridViewColumn)AcName).Visible = false;
		((DataGridViewColumn)LongName).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)LongName).DataPropertyName = "LongName";
		((DataGridViewColumn)LongName).HeaderText = "Aircraft";
		((DataGridViewColumn)LongName).MinimumWidth = 6;
		((DataGridViewColumn)LongName).Name = "LongName";
		((DataGridViewColumn)LongName).ReadOnly = true;
		((DataGridViewColumn)LongName).ToolTipText = "Double click to view selection";
		((DataGridViewColumn)Country).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Country).DataPropertyName = "CountryString";
		((DataGridViewColumn)Country).HeaderText = "Country";
		((DataGridViewColumn)Country).MinimumWidth = 6;
		((DataGridViewColumn)Country).Name = "Country";
		((DataGridViewColumn)Country).ReadOnly = true;
		((DataGridViewColumn)Country).Width = 87;
		((DataGridViewColumn)IOC).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)IOC).DataPropertyName = "YearCommissioned";
		((DataGridViewColumn)IOC).HeaderText = "From";
		((DataGridViewColumn)IOC).MinimumWidth = 6;
		((DataGridViewColumn)IOC).Name = "IOC";
		((DataGridViewColumn)IOC).ReadOnly = true;
		((DataGridViewColumn)IOC).Width = 70;
		((DataGridViewColumn)Retired).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Retired).DataPropertyName = "YearDecommissioned";
		((DataGridViewColumn)Retired).HeaderText = "Until";
		((DataGridViewColumn)Retired).MinimumWidth = 6;
		((DataGridViewColumn)Retired).Name = "Retired";
		((DataGridViewColumn)Retired).ReadOnly = true;
		((DataGridViewColumn)Retired).Width = 67;
		((DataGridViewColumn)AcType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)AcType).DataPropertyName = "Type";
		((DataGridViewColumn)AcType).HeaderText = "Type";
		((DataGridViewColumn)AcType).MinimumWidth = 6;
		((DataGridViewColumn)AcType).Name = "Type";
		((DataGridViewColumn)AcType).ReadOnly = true;
		((DataGridViewColumn)AcType).Width = 67;
		((DataGridViewColumn)AcType).Visible = false;
		((DataGridViewColumn)AcSize).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)AcSize).DataPropertyName = "Size";
		((DataGridViewColumn)AcSize).HeaderText = "Size";
		((DataGridViewColumn)AcSize).MinimumWidth = 6;
		((DataGridViewColumn)AcSize).Name = "Size";
		((DataGridViewColumn)AcSize).ReadOnly = true;
		((DataGridViewColumn)AcSize).Width = 67;
		((DataGridViewColumn)AcSize).Visible = false;
		((DataGridViewColumn)RunwaySizeNeeded).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)RunwaySizeNeeded).DataPropertyName = "RunwaySizeNeeded";
		((DataGridViewColumn)RunwaySizeNeeded).HeaderText = "Runway";
		((DataGridViewColumn)RunwaySizeNeeded).MinimumWidth = 6;
		((DataGridViewColumn)RunwaySizeNeeded).Name = "RunwaySizeNeeded";
		((DataGridViewColumn)RunwaySizeNeeded).ReadOnly = true;
		((DataGridViewColumn)RunwaySizeNeeded).Width = 67;
		((DataGridViewColumn)RunwaySizeNeeded).Visible = false;
		((DataGridViewColumn)Hypothetical).AutoSizeMode = (DataGridViewAutoSizeColumnMode)2;
		((DataGridViewColumn)Hypothetical).DataPropertyName = "Hypothetical";
		Hypothetical.FalseValue = "False";
		((DataGridViewColumn)Hypothetical).HeaderText = "Hypo";
		((DataGridViewColumn)Hypothetical).MinimumWidth = 6;
		((DataGridViewColumn)Hypothetical).Name = "Hypothetical";
		((DataGridViewColumn)Hypothetical).ReadOnly = true;
		Hypothetical.TrueValue = "True";
		((DataGridViewColumn)Hypothetical).Width = 49;
		((DataGridViewColumn)Hypothetical).Visible = false;
		((DataGridViewColumn)CountryNumber).DataPropertyName = "OperatorCountry";
		((DataGridViewColumn)CountryNumber).HeaderText = "Column1";
		((DataGridViewColumn)CountryNumber).MinimumWidth = 6;
		((DataGridViewColumn)CountryNumber).Name = "CountryNumber";
		((DataGridViewColumn)CountryNumber).ReadOnly = true;
		((DataGridViewColumn)CountryNumber).Visible = false;
		((DataGridViewColumn)CountryNumber).Width = 125;
		((DataGridViewColumn)Column2).DataPropertyName = "Name";
		((DataGridViewColumn)Column2).HeaderText = "Column2";
		((DataGridViewColumn)Column2).MinimumWidth = 6;
		((DataGridViewColumn)Column2).Name = "Column2";
		((DataGridViewColumn)Column2).ReadOnly = true;
		((DataGridViewColumn)Column2).Visible = false;
		((DataGridViewColumn)Column2).Width = 125;
		((DataGridViewColumn)Deprecated).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Deprecated).DataPropertyName = "Deprecated";
		((DataGridViewColumn)Deprecated).HeaderText = "Deprecated";
		((DataGridViewColumn)Deprecated).MinimumWidth = 6;
		((DataGridViewColumn)Deprecated).Name = "Deprecated";
		((DataGridViewColumn)Deprecated).ReadOnly = true;
		((DataGridViewColumn)Deprecated).Width = 67;
		((DataGridViewColumn)Deprecated).Visible = false;
		((Control)GroupBox1).Controls.Add((Control)(object)DarkLabel1);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Hypothetical);
		((Control)GroupBox1).Controls.Add((Control)(object)Label7);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_FilterSizeAndTODLAD);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Country);
		((Control)GroupBox1).Controls.Add((Control)(object)Label3);
		((Control)GroupBox1).Controls.Add((Control)(object)Label6);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Class);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_SubType);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(296, 34);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(659, 91);
		((Control)GroupBox1).TabIndex = 22;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Filter by...";
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(341, 53);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(61, 17);
		((Control)DarkLabel1).TabIndex = 20;
		((Label)DarkLabel1).Text = "SubType:";
		((Control)CB_Hypothetical).Anchor = (AnchorStyles)13;
		((ComboBox)CB_Hypothetical).BackColor = Color.Transparent;
		((ComboBox)CB_Hypothetical).DrawMode = (DrawMode)1;
		((ComboBox)CB_Hypothetical).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Hypothetical).Font = new Font("Segoe UI", 7f);
		((Control)CB_Hypothetical).Location = new Point(83, 41);
		((Control)CB_Hypothetical).Name = "CB_Hypothetical";
		((Control)CB_Hypothetical).Size = new Size(252, 24);
		((Control)CB_Hypothetical).TabIndex = 16;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(6, 45);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(85, 20);
		((Control)Label7).TabIndex = 15;
		((Label)Label7).Text = "Hypothetical:";
		((Control)CB_FilterSizeAndTODLAD).Location = new Point(10, 68);
		((Control)CB_FilterSizeAndTODLAD).Name = "CB_FilterSizeAndTODLAD";
		((Control)CB_FilterSizeAndTODLAD).Size = new Size(252, 18);
		((Control)CB_FilterSizeAndTODLAD).TabIndex = 14;
		((ButtonBase)CB_FilterSizeAndTODLAD).Text = "Only show aircraft able to take off / land here";
		((Control)CB_FilterSizeAndTODLAD).Visible = true;
		((Control)CB_Country).Anchor = (AnchorStyles)13;
		((ComboBox)CB_Country).BackColor = Color.Transparent;
		((ComboBox)CB_Country).DrawMode = (DrawMode)1;
		((ComboBox)CB_Country).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Country).Font = new Font("Segoe UI", 7f);
		((Control)CB_Country).Location = new Point(398, 16);
		((Control)CB_Country).Name = "CB_Country";
		((Control)CB_Country).Size = new Size(255, 24);
		((Control)CB_Country).TabIndex = 13;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(341, 20);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(61, 17);
		((Control)Label3).TabIndex = 12;
		((Label)Label3).Text = "Country:";
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(7, 20);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(41, 17);
		((Control)Label6).TabIndex = 11;
		((Label)Label6).Text = "Class:";
		((Control)TB_Class).Anchor = (AnchorStyles)13;
		TB_Class.AutoCompleteCustomSource = null;
		TB_Class.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Class.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Class).BackColor = Color.FromArgb(69, 73, 74);
		TB_Class.Font = new Font("Segoe UI", 8f);
		((Control)TB_Class).ForeColor = Color.FromArgb(220, 220, 220);
		TB_Class.Image = null;
		TB_Class.Lines = null;
		((Control)TB_Class).Location = new Point(83, 17);
		TB_Class.MaxLength = 32767;
		TB_Class.Multiline = false;
		((Control)TB_Class).Name = "TB_Class";
		TB_Class.ReadOnly = false;
		TB_Class.ScrollBars = (ScrollBars)0;
		TB_Class.SelectionStart = 0;
		((Control)TB_Class).Size = new Size(252, 20);
		((Control)TB_Class).TabIndex = 10;
		TB_Class.TextAlign = (HorizontalAlignment)0;
		TB_Class.UseSystemPasswordChar = false;
		TB_Class.WatermarkText = "";
		((Control)CB_SubType).Anchor = (AnchorStyles)13;
		((ComboBox)CB_SubType).BackColor = Color.Transparent;
		((ComboBox)CB_SubType).DrawMode = (DrawMode)1;
		((ComboBox)CB_SubType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_SubType).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_SubType).FormattingEnabled = true;
		((Control)CB_SubType).Location = new Point(452, 46);
		((Control)CB_SubType).Name = "CB_SubType";
		((Control)CB_SubType).Size = new Size(201, 24);
		((Control)CB_SubType).TabIndex = 19;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(967, 673);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Control)this).Controls.Add((Control)(object)Button_RemoveAC);
		((Control)this).Controls.Add((Control)(object)Quantity);
		((Control)this).Controls.Add((Control)(object)TB_Quantity);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)TB_Callsign);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)ListView1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditAC";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit Aircraft for:";
		((ISupportInitialize)NUD1).EndInit();
		((Control)Quantity).ResumeLayout(false);
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)GroupBox1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EditAC_FormClosing(object sender, FormClosingEventArgs e)
	{
		int mustRefreshMainForm;
		if (Client.CurrentGame.Status != Game._GameStatus.Paused)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void EditAC_Load(object sender, EventArgs e)
	{
		dataTable_0 = Client.CurrentScenario.Cache_Aircraft_DT.Copy();
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		((Control)CB_Country).SuspendLayout();
		((ComboBox)CB_Country).DataSource = cache_OperatorCountries_DT;
		((ListControl)CB_Country).DisplayMember = "Description";
		((ListControl)CB_Country).ValueMember = "ID";
		((ComboBox)CB_Country).SelectedIndex = 0;
		((Control)CB_Country).ResumeLayout();
		((ComboBox)CB_Hypothetical).Items.Clear();
		((ComboBox)CB_Hypothetical).Items.AddRange(new object[3] { "Both real-life and hypothetical", "Real-life platforms only", "Hypothetical platforms only" });
		((ComboBox)CB_Hypothetical).SelectedItem = RuntimeHelpers.GetObjectValue(((ComboBox)CB_Hypothetical).Items[0]);
		method_15();
	}

	private void method_2()
	{
		Client.MustRefreshMainForm = true;
		ListView1.Items.Clear();
		IEnumerable<int> enumerable = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Select([SpecialName] (Aircraft AC) => AC.DBID).Distinct();
		_Closure$__152-0 closure$__152- = default(_Closure$__152-0);
		foreach (int item in enumerable)
		{
			closure$__152- = new _Closure$__152-0(closure$__152-);
			closure$__152-.$VB$Local_theDBID = item;
			IEnumerable<Aircraft> source = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where(closure$__152-._Lambda$__1);
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Tag = closure$__152-.$VB$Local_theDBID;
			darkListItem.Text = Conversions.ToString(source.Count()) + "x " + source.ElementAtOrDefault(0).UnitClass;
			ListView1.Items.Add(darkListItem);
		}
		((Control)Button_RemoveAC).Visible = ListView1.SelectedIndices.Count > 0;
		Button_RemoveAC.Enabled = ((Control)Button_RemoveAC).Visible;
	}

	private void method_3(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count >= 1)
		{
			int num = Conversions.ToInteger(ListView1.SelectedItems[0].Tag.ToString());
			if (num != 10000 && num != 10001 && num != 10002)
			{
				Client.smethod_17("Aircraft", num);
			}
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0)
		{
			int value = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where([SpecialName] (Aircraft AC) => string.CompareOrdinal(Conversions.ToString(AC.DBID), ListView1.SelectedItems[0].Tag.ToString()) == 0).Count();
			((NumericUpDown)NUD1).Value = new decimal(value);
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Invalid comparison between Unknown and I4
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Invalid comparison between Unknown and I4
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
		{
			return;
		}
		int num = Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells[0].Value.ToString());
		if (num == 10000 || num == 10001 || num == 10002)
		{
			return;
		}
		string text = ((!string.IsNullOrEmpty(TB_Callsign.Text)) ? TB_Callsign.Text : Callsigns.FetchRandomCallsign_Unit());
		if (!Versioned.IsNumeric((object)TB_Quantity.Text))
		{
			return;
		}
		Button1.Text = "Working...";
		Button1.Enabled = false;
		bool flag = true;
		bool flag2 = true;
		int num2 = Conversions.ToInteger(TB_Quantity.Text);
		for (int i = 1; i <= num2; i++)
		{
			Aircraft aircraft = Client.CurrentScenario.AddNewAircraft(Client.CurrentSide, text + " #" + Conversions.ToString(i), SelectedHost.get_Longitude((GlobalVariables.BooleanObject)null), SelectedHost.get_Latitude((GlobalVariables.BooleanObject)null), num, 0, 0f);
			if (i == 1)
			{
				IEnumerable<AirFacility> source = (SelectedHost.IsGroup ? (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, TakeOff: true, IgnoreOtherAircraft: true, SelectedHost, aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac) : ((SelectedHost.get_ParentGroup(UsingMissionPlanner: false) != null) ? (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, TakeOff: true, IgnoreOtherAircraft: true, SelectedHost.get_ParentGroup(UsingMissionPlanner: false), aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac) : (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, TakeOff: true, IgnoreOtherAircraft: true, SelectedHost, aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac)));
				if (source.Count() < 1)
				{
					if ((int)DarkMessageBox.ShowWarning("Unable to take-off from this facility due to runway/access/launcher.", "Air ops restriction", DarkDialogButton.OkCancel) == 2)
					{
						break;
					}
				}
				else
				{
					flag2 = false;
				}
				source = (SelectedHost.IsGroup ? (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, TakeOff: false, IgnoreOtherAircraft: true, SelectedHost, aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac) : ((SelectedHost.get_ParentGroup(UsingMissionPlanner: false) == null) ? (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, TakeOff: false, IgnoreOtherAircraft: true, SelectedHost, aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac) : (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, TakeOff: false, IgnoreOtherAircraft: true, SelectedHost.get_ParentGroup(UsingMissionPlanner: false), aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac)));
				if (source.Count() < 1)
				{
					if ((int)DarkMessageBox.ShowWarning("Unable to land on this facility due to runway/access.", "Air ops restriction", DarkDialogButton.OkCancel) == 2)
					{
						break;
					}
				}
				else
				{
					flag = false;
				}
			}
			if (SelectedHost.AirOps.CanHostThisAircraft(aircraft) == AirOpsAttemptResult.Success)
			{
				SelectedHost.AirOps.AddThisAircraft(aircraft, GameIsRunning: false);
				continue;
			}
			Client.CurrentScenario.DeleteUnitImmediately(aircraft.ObjectID, ScenEditAction: true, "Aircraft deleted", null, RegisterAsLosses: false);
			if (!flag || !flag2)
			{
				DarkMessageBox.ShowWarning("Unable to add all aircraft to base - Exceeded maximum aircraft parking space.", "Out of space!");
			}
			break;
		}
		Button1.Text = "Add Selected";
		Button1.Enabled = true;
		method_2();
	}

	private void method_6(object sender, EventArgs e)
	{
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		if (ListView1.SelectedIndices.Count == 0)
		{
			return;
		}
		Button2.Text = "Working...";
		Button2.Enabled = false;
		IEnumerable<Aircraft> source = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where([SpecialName] (Aircraft AC) => AC.DBID == Conversions.ToInteger(ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString()));
		if (decimal.Compare(((NumericUpDown)NUD1).Value, new decimal(source.Count())) < 0)
		{
			int num = source.Count() - 1;
			int num2 = Convert.ToInt32(((NumericUpDown)NUD1).Value);
			for (int num3 = num; num3 >= num2; num3 += -1)
			{
				Client.CurrentScenario.DeleteUnitImmediately(source.ElementAtOrDefault(num3).ObjectID, ScenEditAction: true, "Aircraft deleted", null, RegisterAsLosses: false);
			}
		}
		if (decimal.Compare(((NumericUpDown)NUD1).Value, new decimal(source.Count())) > 0)
		{
			int aircraftDBID = source.Select([SpecialName] (Aircraft AC) => AC.DBID).ElementAtOrDefault(0);
			string text = Callsigns.FetchRandomCallsign_Unit();
			int num4 = source.Count() + 1;
			int num5 = Convert.ToInt32(((NumericUpDown)NUD1).Value);
			for (int num6 = num4; num6 <= num5; num6++)
			{
				Aircraft aircraft = Client.CurrentScenario.AddNewAircraft(Client.CurrentSide, text + " " + Conversions.ToString(num6), SelectedHost.get_Longitude((GlobalVariables.BooleanObject)null), SelectedHost.get_Latitude((GlobalVariables.BooleanObject)null), aircraftDBID, 0, 0f);
				if (SelectedHost.AirOps.CanHostThisAircraft(aircraft) == AirOpsAttemptResult.Success)
				{
					SelectedHost.AirOps.AddThisAircraft(aircraft, GameIsRunning: false);
					continue;
				}
				Client.CurrentScenario.DeleteUnitImmediately(aircraft.ObjectID, ScenEditAction: true, "Aircraft deleted", null, RegisterAsLosses: false);
				DarkMessageBox.ShowWarning("Unable to add all aircraft to base - Exceeded maximum aircraft parking space.", "Out of space!");
				break;
			}
		}
		Button2.Text = "Apply";
		Button2.Enabled = true;
		method_2();
	}

	private void method_7(object sender, EventArgs e)
	{
		IEnumerable<Aircraft> source = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where([SpecialName] (Aircraft AC) => AC.DBID == Conversions.ToInteger(ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString()));
		for (int num = source.Count() - 1; num >= 0; num += -1)
		{
			Client.CurrentScenario.DeleteUnitImmediately(source.ElementAtOrDefault(num).ObjectID, ScenEditAction: true, "Aircraft deleted", null, RegisterAsLosses: false);
		}
		method_2();
	}

	private void method_8(object sender, KeyPressEventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "Name ASC";
		dataView.RowFilter = "Name LIKE '" + Conversions.ToString(e.KeyChar) + "%'";
		if (dataView.Count <= 0)
		{
			return;
		}
		int num = Conversions.ToInteger(dataView[0][0]);
		int index = default(int);
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DataGridView1).Rows)
		{
			DataGridViewRow val = item;
			if (Conversions.ToInteger(val.Cells[0].Value) == num)
			{
				index = ((DataGridViewBand)val).Index;
				break;
			}
		}
		((DataGridView)DataGridView1).FirstDisplayedScrollingRowIndex = index;
	}

	private void method_9()
	{
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "Name ASC";
		((DataGridView)DataGridView1).DataSource = dataView;
	}

	private void method_10(object object_0)
	{
		if (Operators.CompareString(TB_Class.Text, "", true) != 0)
		{
			method_11();
		}
	}

	private void method_11()
	{
		if (((CheckBox)CB_FilterSizeAndTODLAD).Checked || ((ComboBox)CB_Hypothetical).SelectedIndex != 0 || ((ComboBox)CB_SubType).SelectedIndex > 0)
		{
			dataTable_0 = Client.CurrentScenario.Cache_Aircraft_DT.Copy();
		}
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "Name ASC";
		if (Operators.CompareString(TB_Class.Text, "", true) != 0 || ((ComboBox)CB_Country).SelectedIndex != 0 || ((ComboBox)CB_Hypothetical).SelectedIndex != 0 || ((ComboBox)CB_SubType).SelectedIndex != 0 || ((CheckBox)CB_FilterSizeAndTODLAD).Checked)
		{
			string text = "1=1 ";
			if (Operators.CompareString(TB_Class.Text, "", true) != 0)
			{
				string text2 = TB_Class.Text.Replace("'", "''");
				text = text + " AND Name LIKE '%" + text2 + "%' ";
			}
			if (((ComboBox)CB_Country).SelectedIndex > 0)
			{
				text = text + " AND OperatorCountry=" + Conversions.ToString(((ListControl)CB_Country).SelectedValue);
			}
			if (((ComboBox)CB_Hypothetical).SelectedIndex == 1)
			{
				text += " AND Hypothetical=FALSE";
			}
			else if (((ComboBox)CB_Hypothetical).SelectedIndex == 2)
			{
				text += " AND Hypothetical=TRUE";
			}
			if (((ComboBox)CB_SubType).SelectedIndex > 0)
			{
				text = text + " AND type=" + ((ListControl)CB_SubType).SelectedValue.ToString();
			}
			text = text.Replace("[", "[[");
			text = text.Replace("]", "]]");
			text = text.Replace("[[", "[[]");
			text = text.Replace("]]", "[]]");
			if (((CheckBox)CB_FilterSizeAndTODLAD).Checked && dataView.Table.Columns.Contains("Size") && dataView.Table.Columns.Contains("RunwaySizeNeeded"))
			{
				GlobalVariables.RunwayLengthClass longestRunwayLengthClass = SelectedHost.AirOps.LongestRunwayLengthClass;
				GlobalVariables.AircraftSizeClass largestAircraftSizeForTOL = SelectedHost.AirOps.LargestAircraftSizeForTOL;
				text = text + " AND Size >= " + Conversions.ToString((byte)largestAircraftSizeForTOL) + " AND RunwaySizeNeeded <= " + Conversions.ToString((int)longestRunwayLengthClass);
			}
			dataView.RowFilter = text;
		}
		((DataGridView)DataGridView1).DataSource = dataView;
		((Control)DataGridView1).Refresh();
	}

	private void EditAC_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (ListView1.SelectedIndices.Count > 0)
		{
			int value = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where([SpecialName] (Aircraft AC) => string.CompareOrdinal(Conversions.ToString(AC.DBID), ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString()) == 0).Count();
			((NumericUpDown)NUD1).Value = new decimal(value);
		}
		((Control)Button_RemoveAC).Visible = ListView1.SelectedIndices.Count > 0;
		Button_RemoveAC.Enabled = ((Control)Button_RemoveAC).Visible;
	}

	private void EditAC_Shown(object sender, EventArgs e)
	{
		((Form)this).Text = "Edit Aircraft for " + SelectedHost.Name;
		method_11();
		method_2();
	}

	private void method_13(object sender, EventArgs e)
	{
		if (((ComboBox)CB_Hypothetical).Items.Count != 0 && ((ComboBox)CB_Country).Items.Count != 0)
		{
			method_11();
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		if (((ComboBox)CB_Hypothetical).Items.Count != 0 && ((ComboBox)CB_Country).Items.Count != 0)
		{
			method_11();
		}
	}

	private void method_15()
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
			if (!(aircraftType >= (Aircraft._AircraftType)9000 && aircraftType <= (Aircraft._AircraftType)9009))
			{
				string text = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
				if (string.IsNullOrEmpty(Misc.Description(aircraftType, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)aircraftType, text);
				}
			}
		}
		if (dataTable.Rows.Count > 0)
		{
			DarkUIComboBox cB_SubType = CB_SubType;
			((ComboBox)cB_SubType).DataSource = dataTable;
			((ListControl)cB_SubType).DisplayMember = "Description";
			((ListControl)cB_SubType).ValueMember = "ID";
			((ComboBox)cB_SubType).SelectedIndex = 0;
			((Control)cB_SubType).Enabled = true;
			((Control)cB_SubType).Visible = true;
		}
		else
		{
			dataTable.Rows.Add(0, "None");
			DarkUIComboBox cB_SubType2 = CB_SubType;
			((ComboBox)cB_SubType2).DataSource = dataTable;
			((ListControl)cB_SubType2).DisplayMember = "Description";
			((ListControl)cB_SubType2).ValueMember = "ID";
			((ComboBox)cB_SubType2).SelectedIndex = 0;
			((Control)cB_SubType2).Enabled = false;
			((Control)cB_SubType2).Visible = false;
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		method_11();
	}

	private void method_17(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1)
		{
			int num = Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells[0].Value.ToString());
			if (num != 10000 && num != 10001 && num != 10002)
			{
				Client.smethod_17("Aircraft", num);
			}
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		method_11();
	}

	static EditAC()
	{
		Class72.smethod_20();
	}
}

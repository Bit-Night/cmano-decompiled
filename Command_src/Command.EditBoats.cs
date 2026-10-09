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
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditBoats : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__125-0
	{
		public int $VB$Local_theDBID;

		public _Closure$__125-0(_Closure$__125-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__6(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == $VB$Local_theDBID);
		}

		static _Closure$__125-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__125-1
	{
		public int $VB$Local_theDBID;

		public _Closure$__125-1(_Closure$__125-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__7(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == $VB$Local_theDBID);
		}

		static _Closure$__125-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__125-2
	{
		public int $VB$Local_theDBID;

		public _Closure$__125-2(_Closure$__125-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__8(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == $VB$Local_theDBID);
		}

		static _Closure$__125-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__129-0
	{
		public int $VB$Local_BoatDBID;

		public _Closure$__129-0(_Closure$__129-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_BoatDBID = arg0.$VB$Local_BoatDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == $VB$Local_BoatDBID);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == $VB$Local_BoatDBID);
		}

		[SpecialName]
		internal bool _Lambda$__2(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == $VB$Local_BoatDBID);
		}

		static _Closure$__129-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__130-0
	{
		public int $VB$Local_BoatDBID;

		public _Closure$__130-0(_Closure$__130-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_BoatDBID = arg0.$VB$Local_BoatDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == $VB$Local_BoatDBID);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == $VB$Local_BoatDBID);
		}

		[SpecialName]
		internal bool _Lambda$__2(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == $VB$Local_BoatDBID);
		}

		static _Closure$__130-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Country")]
	private DarkUIComboBox _CB_Country;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Class")]
	private DarkUITextBox _TB_Class;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _DataGridView1;

	[AccessedThroughProperty("Button_RemoveBoat")]
	[CompilerGenerated]
	private DarkUIButton _Button_RemoveBoat;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("ListView1")]
	private DarkListView _ListView1;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SubType")]
	private DarkUIComboBox _CB_SubType;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Hypothetical")]
	private DarkUIComboBox _CB_Hypothetical;

	public ActiveUnit SelectedHost;

	private DataTable dataTable_0;

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
			EventHandler eventHandler = method_15;
			DarkUIComboBox darkUIComboBox = _CB_Country;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_Country = value;
			darkUIComboBox = _CB_Country;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
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
			DarkUITextBox.TextChangedEventHandler value2 = method_12;
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
			KeyPressEventHandler val = new KeyPressEventHandler(method_10);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_19);
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

	internal virtual DarkUIButton Button_RemoveBoat
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveBoat;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _Button_RemoveBoat;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RemoveBoat = value;
			darkUIButton = _Button_RemoveBoat;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Quantity")]
	internal virtual DarkGroupBox Quantity { get; set; }

	[field: AccessedThroughProperty("NUD1")]
	internal virtual DarkNumericUpDown NUD1 { get; set; }

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
			EventHandler eventHandler = method_7;
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

	[field: AccessedThroughProperty("TB_Quantity")]
	internal virtual DarkUITextBox TB_Quantity { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

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
			EventHandler eventHandler = method_6;
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

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
			EventHandler value2 = method_4;
			EventHandler eventHandler = method_9;
			DarkListView darkListView = _ListView1;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
				((Control)darkListView).DoubleClick -= eventHandler;
			}
			_ListView1 = value;
			darkListView = _ListView1;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
				((Control)darkListView).DoubleClick += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2 { get; set; }

	[field: AccessedThroughProperty("Country")]
	internal virtual DataGridViewTextBoxColumn Country { get; set; }

	[field: AccessedThroughProperty("IOC")]
	internal virtual DataGridViewTextBoxColumn IOC { get; set; }

	[field: AccessedThroughProperty("Retired")]
	internal virtual DataGridViewTextBoxColumn Retired { get; set; }

	[field: AccessedThroughProperty("CountryNumber")]
	internal virtual DataGridViewTextBoxColumn CountryNumber { get; set; }

	[field: AccessedThroughProperty("Column2")]
	internal virtual DataGridViewTextBoxColumn Column2 { get; set; }

	internal virtual DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIComboBox darkUIComboBox = _ComboBox1;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox1 = value;
			darkUIComboBox = _ComboBox1;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

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
			EventHandler eventHandler = method_18;
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
			EventHandler eventHandler = method_16;
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

	[field: AccessedThroughProperty("Label11")]
	internal virtual DarkLabel Label11 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	public EditBoats()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += EditBoats_Load;
		((Form)this).FormClosing += new FormClosingEventHandler(EditBoats_FormClosing);
		((Control)this).KeyDown += new KeyEventHandler(EditBoats_KeyDown);
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
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
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
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Expected O, but got Unknown
		//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Expected O, but got Unknown
		//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d8: Expected O, but got Unknown
		//IL_09c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d1: Expected O, but got Unknown
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Expected O, but got Unknown
		//IL_0ebd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec7: Expected O, but got Unknown
		//IL_0f08: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Expected O, but got Unknown
		//IL_1115: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c0: Expected O, but got Unknown
		//IL_1381: Unknown result type (might be due to invalid IL or missing references)
		//IL_138b: Expected O, but got Unknown
		//IL_13cc: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		GroupBox1 = new DarkGroupBox();
		ComboBox1 = new DarkUIComboBox();
		Label4 = new DarkLabel();
		CB_Country = new DarkUIComboBox();
		Label3 = new DarkLabel();
		Label6 = new DarkLabel();
		TB_Class = new DarkUITextBox();
		Label7 = new DarkLabel();
		CB_SubType = new DarkUIComboBox();
		Label11 = new DarkLabel();
		CB_Hypothetical = new DarkUIComboBox();
		DataGridView1 = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		Country = new DataGridViewTextBoxColumn();
		IOC = new DataGridViewTextBoxColumn();
		Retired = new DataGridViewTextBoxColumn();
		CountryNumber = new DataGridViewTextBoxColumn();
		Column2 = new DataGridViewTextBoxColumn();
		Button_RemoveBoat = new DarkUIButton();
		Quantity = new DarkGroupBox();
		NUD1 = new DarkNumericUpDown();
		Button2 = new DarkUIButton();
		TB_Quantity = new DarkUITextBox();
		Label5 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		ListView1 = new DarkListView();
		((Control)GroupBox1).SuspendLayout();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)Quantity).SuspendLayout();
		((ISupportInitialize)NUD1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)GroupBox1).Controls.Add((Control)(object)ComboBox1);
		((Control)GroupBox1).Controls.Add((Control)(object)Label4);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Country);
		((Control)GroupBox1).Controls.Add((Control)(object)Label3);
		((Control)GroupBox1).Controls.Add((Control)(object)Label6);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Class);
		((Control)GroupBox1).Controls.Add((Control)(object)Label7);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_SubType);
		((Control)GroupBox1).Controls.Add((Control)(object)Label11);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Hypothetical);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(296, 29);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(604, 110);
		((Control)GroupBox1).TabIndex = 34;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Filter by...";
		((Control)ComboBox1).Anchor = (AnchorStyles)13;
		((ComboBox)ComboBox1).BackColor = Color.Transparent;
		((ComboBox)ComboBox1).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox1).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox1).Font = new Font("Segoe UI", 7f);
		((ComboBox)ComboBox1).Items.AddRange(new object[3] { "Ship", "Submarine", "Amphibious Vehicles" });
		((Control)ComboBox1).Location = new Point(111, 70);
		((Control)ComboBox1).Name = "ComboBox1";
		((Control)ComboBox1).Size = new Size(196, 24);
		((Control)ComboBox1).TabIndex = 15;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(7, 75);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(61, 19);
		((Control)Label4).TabIndex = 14;
		((Label)Label4).Text = "Type:";
		((Control)CB_Country).Anchor = (AnchorStyles)13;
		((ComboBox)CB_Country).BackColor = Color.Transparent;
		((ComboBox)CB_Country).DrawMode = (DrawMode)1;
		((ComboBox)CB_Country).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Country).Font = new Font("Segoe UI", 7f);
		((Control)CB_Country).Location = new Point(393, 14);
		((Control)CB_Country).Name = "CB_Country";
		((Control)CB_Country).Size = new Size(205, 24);
		((Control)CB_Country).TabIndex = 13;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(313, 20);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(74, 17);
		((Control)Label3).TabIndex = 12;
		((Label)Label3).Text = "Country:";
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(7, 20);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(61, 17);
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
		((Control)TB_Class).Location = new Point(111, 13);
		TB_Class.MaxLength = 32767;
		TB_Class.Multiline = false;
		((Control)TB_Class).Name = "TB_Class";
		TB_Class.ReadOnly = false;
		TB_Class.ScrollBars = (ScrollBars)0;
		TB_Class.SelectionStart = 0;
		((Control)TB_Class).Size = new Size(196, 24);
		((Control)TB_Class).TabIndex = 10;
		TB_Class.TextAlign = (HorizontalAlignment)0;
		TB_Class.UseSystemPasswordChar = false;
		TB_Class.WatermarkText = "";
		TB_Class.WordWrap = false;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(6, 45);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(104, 20);
		((Control)Label7).TabIndex = 15;
		((Label)Label7).Text = "Hypothetical:";
		((Control)CB_SubType).Anchor = (AnchorStyles)13;
		((ComboBox)CB_SubType).BackColor = Color.Transparent;
		((ComboBox)CB_SubType).DrawMode = (DrawMode)1;
		((ComboBox)CB_SubType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_SubType).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_SubType).FormattingEnabled = true;
		((Control)CB_SubType).Location = new Point(393, 44);
		((Control)CB_SubType).Name = "CB_SubType";
		((Control)CB_SubType).Size = new Size(205, 24);
		((Control)CB_SubType).TabIndex = 19;
		((Control)Label11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label11).Location = new Point(314, 48);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(73, 17);
		((Control)Label11).TabIndex = 20;
		((Label)Label11).Text = "SubType:";
		((Control)CB_Hypothetical).Anchor = (AnchorStyles)13;
		((ComboBox)CB_Hypothetical).BackColor = Color.Transparent;
		((ComboBox)CB_Hypothetical).DrawMode = (DrawMode)1;
		((ComboBox)CB_Hypothetical).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Hypothetical).Font = new Font("Segoe UI", 7f);
		((Control)CB_Hypothetical).Location = new Point(111, 41);
		((Control)CB_Hypothetical).Name = "CB_Hypothetical";
		((Control)CB_Hypothetical).Size = new Size(196, 24);
		((Control)CB_Hypothetical).TabIndex = 16;
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
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[7]
		{
			(DataGridViewColumn)DataGridViewTextBoxColumn1,
			(DataGridViewColumn)DataGridViewTextBoxColumn2,
			(DataGridViewColumn)Country,
			(DataGridViewColumn)IOC,
			(DataGridViewColumn)Retired,
			(DataGridViewColumn)CountryNumber,
			(DataGridViewColumn)Column2
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
		((Control)DataGridView1).Location = new Point(297, 145);
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
		((Control)DataGridView1).Size = new Size(603, 481);
		((Control)DataGridView1).TabIndex = 33;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).DataPropertyName = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Visible = false;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Width = 125;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).DataPropertyName = "LongName";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).HeaderText = "Class";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Name = "DataGridViewTextBoxColumn2";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).ToolTipText = "Double click to view selection";
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
		((Control)Button_RemoveBoat).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_RemoveBoat).BackColor = Color.IndianRed;
		((Control)Button_RemoveBoat).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button_RemoveBoat).ForeColor = SystemColors.ControlText;
		((Control)Button_RemoveBoat).Location = new Point(190, 647);
		((Control)Button_RemoveBoat).Name = "Button_RemoveBoat";
		((Control)Button_RemoveBoat).Padding = new Padding(5);
		Button_RemoveBoat.RoundRadius = 0;
		((Control)Button_RemoveBoat).Size = new Size(100, 22);
		((Control)Button_RemoveBoat).TabIndex = 32;
		Button_RemoveBoat.Text = "Remove selected";
		((Control)Quantity).Anchor = (AnchorStyles)6;
		((Control)Quantity).Controls.Add((Control)(object)NUD1);
		((Control)Quantity).Controls.Add((Control)(object)Button2);
		((Control)Quantity).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Quantity).Location = new Point(12, 632);
		((Control)Quantity).Name = "Quantity";
		((Control)Quantity).Size = new Size(155, 41);
		((Control)Quantity).TabIndex = 31;
		((GroupBox)Quantity).TabStop = false;
		((GroupBox)Quantity).Text = "Quantity";
		((UpDownBase)NUD1).BackColor = Color.FromArgb(69, 73, 74);
		((UpDownBase)NUD1).BorderStyle = (BorderStyle)1;
		((UpDownBase)NUD1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD1).Location = new Point(6, 16);
		((NumericUpDown)NUD1).Maximum = new decimal(new int[4] { 99999999, 0, 0, 0 });
		((Control)NUD1).Name = "NUD1";
		((Control)NUD1).Size = new Size(74, 27);
		((Control)NUD1).TabIndex = 10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(85, 15);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(65, 22);
		((Control)Button2).TabIndex = 16;
		Button2.Text = "Apply";
		((Control)TB_Quantity).Anchor = (AnchorStyles)6;
		TB_Quantity.AutoCompleteCustomSource = null;
		TB_Quantity.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Quantity.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Quantity).BackColor = Color.FromArgb(69, 73, 74);
		TB_Quantity.Font = new Font("Segoe UI", 8f);
		((Control)TB_Quantity).ForeColor = Color.FromArgb(220, 220, 220);
		TB_Quantity.Image = null;
		TB_Quantity.Lines = null;
		((Control)TB_Quantity).Location = new Point(630, 644);
		TB_Quantity.MaxLength = 32767;
		TB_Quantity.Multiline = false;
		((Control)TB_Quantity).Name = "TB_Quantity";
		TB_Quantity.ReadOnly = false;
		TB_Quantity.ScrollBars = (ScrollBars)0;
		TB_Quantity.SelectionStart = 0;
		((Control)TB_Quantity).Size = new Size(114, 20);
		((Control)TB_Quantity).TabIndex = 30;
		TB_Quantity.TextAlign = (HorizontalAlignment)0;
		TB_Quantity.UseSystemPasswordChar = false;
		TB_Quantity.WatermarkText = "";
		TB_Quantity.WordWrap = false;
		((Control)Label5).Anchor = (AnchorStyles)6;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(559, 646);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(83, 20);
		((Control)Label5).TabIndex = 29;
		((Label)Label5).Text = "How many:";
		((Label)Label5).TextAlign = (ContentAlignment)64;
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(769, 644);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(111, 20);
		((Control)Button1).TabIndex = 28;
		Button1.Text = "Add Selected";
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(294, 10);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(112, 13);
		((Control)Label2).TabIndex = 25;
		((Label)Label2).Text = "Boats to add:";
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(12, 10);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(276, 16);
		((Control)Label1).TabIndex = 24;
		((Label)Label1).Text = "Current inventory: Double click to view";
		((Control)ListView1).Anchor = (AnchorStyles)7;
		((Control)ListView1).Location = new Point(16, 29);
		((Control)ListView1).Name = "ListView1";
		ListView1.RelatedInfos = null;
		((Control)ListView1).Size = new Size(278, 597);
		((Control)ListView1).TabIndex = 23;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(912, 679);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Control)this).Controls.Add((Control)(object)Button_RemoveBoat);
		((Control)this).Controls.Add((Control)(object)Quantity);
		((Control)this).Controls.Add((Control)(object)TB_Quantity);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)ListView1);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditBoats";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit docked boats";
		((Control)GroupBox1).ResumeLayout(false);
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)Quantity).ResumeLayout(false);
		((ISupportInitialize)NUD1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EditBoats_Load(object sender, EventArgs e)
	{
		((ComboBox)ComboBox1).SelectedIndex = 0;
		method_2();
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		((ComboBox)CB_Country).DataSource = cache_OperatorCountries_DT;
		((ListControl)CB_Country).DisplayMember = "Description";
		((ListControl)CB_Country).ValueMember = "ID";
		((ComboBox)CB_Country).SelectedIndex = 0;
		((ComboBox)CB_Hypothetical).Items.Clear();
		((ComboBox)CB_Hypothetical).Items.Add((object)"Both real-life and hypothetical");
		((ComboBox)CB_Hypothetical).Items.Add((object)"Real-life platforms only");
		((ComboBox)CB_Hypothetical).Items.Add((object)"Hypothetical platforms only");
		((ComboBox)CB_Hypothetical).SelectedItem = RuntimeHelpers.GetObjectValue(((ComboBox)CB_Hypothetical).Items[0]);
		method_17();
		((Form)this).Text = "Edit docked boats for " + SelectedHost.Name;
		method_13();
		method_3();
	}

	private void method_2()
	{
		switch (((ComboBox)ComboBox1).SelectedIndex)
		{
		case 0:
			dataTable_0 = Client.CurrentScenario.Cache_Ships_DT.Copy();
			break;
		case 1:
			dataTable_0 = Client.CurrentScenario.Cache_Subs_DT.Copy();
			break;
		case 2:
			dataTable_0 = Client.CurrentScenario.Cache_GroundUnits_DT.Copy();
			break;
		}
		List<DataRow> list = new List<DataRow>();
		foreach (DataRow row in dataTable_0.Rows)
		{
			short num = Conversions.ToShort(row["Length"]);
			DockFacility.DockingPhysicalSize boatDockingClass;
			if (((ComboBox)ComboBox1).SelectedIndex == 2)
			{
				if (!DBFunctions.IsSeaworthyAmphibiousVehicle(Client.CurrentScenario, Conversions.ToInteger(row["ID"])))
				{
					list.Add(row);
					continue;
				}
				boatDockingClass = DBFunctions.GetAmphibiousVehicleDockingPhysicalSize(num);
			}
			else
			{
				boatDockingClass = (DockFacility.DockingPhysicalSize)Conversions.ToShort(row["PhysicalSizeCode"]);
			}
			if (SelectedHost.DockingOps.CanHostThisBoat(num, boatDockingClass) != DockingOpsAttemptResult.Success)
			{
				row["ID"].ToString();
				list.Add(row);
			}
		}
		foreach (DataRow item in list)
		{
			dataTable_0.Rows.Remove(item);
		}
		method_17();
		if (((ComboBox)CB_SubType).SelectedIndex > 0)
		{
			((ComboBox)CB_SubType).SelectedIndex = 0;
			method_13();
		}
	}

	private void EditBoats_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
		}
		((Control)MyProject.Forms.MainForm).BringToFront();
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
	}

	private void method_3()
	{
		Client.MustRefreshMainForm = true;
		ListView1.Items.Clear();
		IEnumerable<int> enumerable = (from theBoat in SelectedHost.DockingOps.EmbarkedBoats_ReadOnly
			where theBoat.IsShip
			select theBoat.DBID).Distinct();
		IEnumerable<int> enumerable2 = (from theBoat in SelectedHost.DockingOps.EmbarkedBoats_ReadOnly
			where theBoat.IsSubmarine
			select theBoat.DBID).Distinct();
		IEnumerable<int> enumerable3 = (from theBoat in SelectedHost.DockingOps.EmbarkedBoats_ReadOnly
			where theBoat.IsVehicle
			select theBoat.DBID).Distinct();
		_Closure$__125-0 closure$__125- = default(_Closure$__125-0);
		foreach (int item in enumerable)
		{
			closure$__125- = new _Closure$__125-0(closure$__125-);
			closure$__125-.$VB$Local_theDBID = item;
			IEnumerable<ActiveUnit> source = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where(closure$__125-._Lambda$__6);
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Tag = "Ship_" + Conversions.ToString(closure$__125-.$VB$Local_theDBID);
			darkListItem.Text = Conversions.ToString(source.Count()) + "x " + source.ElementAtOrDefault(0).UnitClass;
			ListView1.Items.Add(darkListItem);
		}
		_Closure$__125-1 closure$__125-2 = default(_Closure$__125-1);
		foreach (int item2 in enumerable2)
		{
			closure$__125-2 = new _Closure$__125-1(closure$__125-2);
			closure$__125-2.$VB$Local_theDBID = item2;
			IEnumerable<ActiveUnit> source2 = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where(closure$__125-2._Lambda$__7);
			DarkListItem darkListItem2 = new DarkListItem();
			darkListItem2.Tag = "Sub_" + Conversions.ToString(closure$__125-2.$VB$Local_theDBID);
			darkListItem2.Text = Conversions.ToString(source2.Count()) + "x " + source2.ElementAtOrDefault(0).UnitClass;
			ListView1.Items.Add(darkListItem2);
		}
		_Closure$__125-2 closure$__125-3 = default(_Closure$__125-2);
		foreach (int item3 in enumerable3)
		{
			closure$__125-3 = new _Closure$__125-2(closure$__125-3);
			closure$__125-3.$VB$Local_theDBID = item3;
			IEnumerable<ActiveUnit> source3 = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where(closure$__125-3._Lambda$__8);
			DarkListItem darkListItem3 = new DarkListItem();
			darkListItem3.Tag = "Amphib_" + Conversions.ToString(closure$__125-3.$VB$Local_theDBID);
			darkListItem3.Text = Conversions.ToString(source3.Count()) + "x " + source3.ElementAtOrDefault(0).UnitClass;
			ListView1.Items.Add(darkListItem3);
		}
		((Control)Button_RemoveBoat).Visible = ListView1.SelectedIndices.Count > 0;
		Button_RemoveBoat.Enabled = ((Control)Button_RemoveBoat).Visible;
	}

	private void method_4(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0)
		{
			string text = ListView1.SelectedItems[0].Tag.ToString();
			int num = Conversions.ToInteger(text.Split(Conversions.ToCharArrayRankOne("_"))[1]);
			string text2 = text.Split(Conversions.ToCharArrayRankOne("_"))[0];
			int value;
			if (Operators.CompareString(text2, "Ship", true) == 0)
			{
				value = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsShip & (theBoat.DBID == num)).Count();
			}
			else if (Operators.CompareString(text2, "Sub", true) == 0)
			{
				value = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsSubmarine & (theBoat.DBID == num)).Count();
			}
			else
			{
				if (Operators.CompareString(text2, "Amphib", true) != 0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				value = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsVehicle & (theBoat.DBID == num)).Count();
			}
			((NumericUpDown)NUD1).Value = new decimal(value);
		}
		((Control)Button_RemoveBoat).Visible = ListView1.SelectedItems.Count > 0;
		Button_RemoveBoat.Enabled = ((Control)Button_RemoveBoat).Visible;
	}

	private void method_5(int int_0, ref bool bool_2, string string_0 = null)
	{
		int selectedIndex = ((ComboBox)ComboBox1).SelectedIndex;
		DockFacility bestFacility;
		if (Operators.CompareString(string_0, "Ship", true) != 0)
		{
			if (Operators.CompareString(string_0, "Sub", true) == 0)
			{
				selectedIndex = 1;
			}
			else
			{
				if (Operators.CompareString(string_0, "Amphib", true) == 0)
				{
					selectedIndex = 2;
					goto IL_00fb;
				}
				switch (selectedIndex)
				{
				default:
					return;
				case 1:
					break;
				case 2:
					goto IL_00fb;
				case 0:
					goto IL_019f;
				}
			}
			Submarine submarine = Client.CurrentScenario.AddNewSubmarine(Client.CurrentSide, int_0, "", 0.0, 0.0);
			submarine.Name = submarine.UnitClass + " #" + Conversions.ToString(Client.CurrentScenario.UnitsAutoIncrement);
			ActiveUnit_DockingOps dockingOps = SelectedHost.DockingOps;
			bestFacility = null;
			if (!dockingOps.CanHostThisBoat(submarine, ref bestFacility))
			{
				Client.CurrentScenario.DeleteUnitImmediately(submarine.ObjectID, ScenEditAction: true, "Submarine deleted", null, RegisterAsLosses: false);
				bool_2 = true;
			}
			else
			{
				SelectedHost.DockingOps.AddThisBoat(submarine);
			}
			_ = Debugger.IsAttached;
			return;
		}
		selectedIndex = 0;
		goto IL_019f;
		IL_019f:
		Ship ship = Client.CurrentScenario.AddNewShip(Client.CurrentSide, int_0, "", 0.0, 0.0);
		ship.Name = ship.UnitClass + " #" + Conversions.ToString(Client.CurrentScenario.UnitsAutoIncrement);
		ActiveUnit_DockingOps dockingOps2 = SelectedHost.DockingOps;
		bestFacility = null;
		if (dockingOps2.CanHostThisBoat(ship, ref bestFacility))
		{
			SelectedHost.DockingOps.AddThisBoat(ship);
		}
		else
		{
			Client.CurrentScenario.DeleteUnitImmediately(ship.ObjectID, ScenEditAction: true, "Ship deleted", null, RegisterAsLosses: false);
			bool_2 = true;
		}
		_ = Debugger.IsAttached;
		return;
		IL_00fb:
		Vehicle vehicle = Client.CurrentScenario.AddNewVehicle(Client.CurrentSide, int_0, "", 0.0, 0.0);
		vehicle.Name = vehicle.UnitClass + " #" + Conversions.ToString(Client.CurrentScenario.UnitsAutoIncrement);
		ActiveUnit_DockingOps dockingOps3 = SelectedHost.DockingOps;
		bestFacility = null;
		if (dockingOps3.CanHostThisBoat(vehicle, ref bestFacility))
		{
			SelectedHost.DockingOps.AddThisBoat(vehicle);
		}
		else
		{
			Client.CurrentScenario.DeleteUnitImmediately(vehicle.ObjectID, ScenEditAction: true, "Amphibious Vehicle deleted", null, RegisterAsLosses: false);
			bool_2 = true;
		}
		_ = Debugger.IsAttached;
	}

	private void method_6(object sender, EventArgs e)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
		{
			return;
		}
		int num = Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells[0].Value.ToString());
		if (!(num == 10000 || num == 10001 || num == 10002) && Versioned.IsNumeric((object)TB_Quantity.Text))
		{
			Button1.Text = "Working...";
			Button1.Enabled = false;
			bool bool_ = false;
			int num2 = Conversions.ToInteger(TB_Quantity.Text);
			for (int i = 1; i <= num2; i++)
			{
				method_5(num, ref bool_);
			}
			if (bool_)
			{
				DarkMessageBox.ShowWarning("Unable to add all boats to host - Exceeded maximum docking space.", "Out of space!");
			}
			Button1.Text = "Add Selected";
			Button1.Enabled = true;
			method_3();
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		_Closure$__129-0 arg = default(_Closure$__129-0);
		_Closure$__129-0 CS$<>8__locals5 = new _Closure$__129-0(arg);
		if (ListView1.SelectedItems.Count == 0)
		{
			return;
		}
		Button2.Text = "Working...";
		Button2.Enabled = false;
		string text = ListView1.SelectedItems[0].Tag.ToString();
		CS$<>8__locals5.$VB$Local_BoatDBID = Conversions.ToInteger(text.Split(Conversions.ToCharArrayRankOne("_"))[1]);
		string text2 = text.Split(Conversions.ToCharArrayRankOne("_"))[0];
		string text3 = text2;
		IEnumerable<ActiveUnit> source;
		if (Operators.CompareString(text3, "Ship", true) != 0)
		{
			if (Operators.CompareString(text3, "Sub", true) != 0)
			{
				if (Operators.CompareString(text3, "Amphib", true) != 0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				source = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsVehicle & (theBoat.DBID == CS$<>8__locals5.$VB$Local_BoatDBID));
			}
			else
			{
				source = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsSubmarine & (theBoat.DBID == CS$<>8__locals5.$VB$Local_BoatDBID));
			}
		}
		else
		{
			source = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsShip & (theBoat.DBID == CS$<>8__locals5.$VB$Local_BoatDBID));
		}
		int num;
		if (decimal.Compare(((NumericUpDown)NUD1).Value, new decimal(source.Count())) >= 0)
		{
			num = 0;
		}
		else
		{
			int num2 = source.Count() - 1;
			int num3 = Convert.ToInt32(((NumericUpDown)NUD1).Value);
			for (int num4 = num2; num4 >= num3; num4 += -1)
			{
				Client.CurrentScenario.DeleteUnitImmediately(source.ElementAtOrDefault(num4).ObjectID, ScenEditAction: true, "Unit deleted", null, RegisterAsLosses: false);
			}
			num = 0;
		}
		bool bool_ = (byte)num != 0;
		if (decimal.Compare(((NumericUpDown)NUD1).Value, new decimal(source.Count())) > 0)
		{
			source.Select([SpecialName] (ActiveUnit theBoat) => theBoat.DBID).ElementAtOrDefault(0);
			int num5 = source.Count() + 1;
			int num6 = Convert.ToInt32(((NumericUpDown)NUD1).Value);
			for (int num7 = num5; num7 <= num6; num7++)
			{
				method_5(CS$<>8__locals5.$VB$Local_BoatDBID, ref bool_, text2);
			}
		}
		if (bool_)
		{
			DarkMessageBox.ShowWarning("Unable to add all boats to host - Exceeded maximum docking space.", "Out of space!");
		}
		Button2.Text = "Apply";
		Button2.Enabled = true;
		method_3();
	}

	private void method_8(object sender, EventArgs e)
	{
		_Closure$__130-0 arg = default(_Closure$__130-0);
		_Closure$__130-0 CS$<>8__locals4 = new _Closure$__130-0(arg);
		string text = ListView1.SelectedItems[0].Tag.ToString();
		CS$<>8__locals4.$VB$Local_BoatDBID = Conversions.ToInteger(text.Split(new char[1] { '_' })[1]);
		string text2 = text.Split(new char[1] { '_' })[0];
		IEnumerable<ActiveUnit> source;
		if (Operators.CompareString(text2, "Ship", true) == 0)
		{
			source = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsShip & (theBoat.DBID == CS$<>8__locals4.$VB$Local_BoatDBID));
		}
		else if (Operators.CompareString(text2, "Sub", true) != 0)
		{
			if (Operators.CompareString(text2, "Amphib", true) != 0)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			source = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsVehicle & (theBoat.DBID == CS$<>8__locals4.$VB$Local_BoatDBID));
		}
		else
		{
			source = SelectedHost.DockingOps.EmbarkedBoats_ReadOnly.Where([SpecialName] (ActiveUnit theBoat) => theBoat.IsSubmarine & (theBoat.DBID == CS$<>8__locals4.$VB$Local_BoatDBID));
		}
		for (int num = source.Count() - 1; num >= 0; num += -1)
		{
			Client.CurrentScenario.DeleteUnitImmediately(source.ElementAtOrDefault(num).ObjectID, ScenEditAction: true, "Unit deleted", null, RegisterAsLosses: false);
		}
		((ComboBox)ComboBox1).SelectedIndex = 0;
		method_17();
		method_13();
		method_2();
		method_3();
	}

	private void method_9(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count < 1)
		{
			return;
		}
		string? text = ListView1.SelectedItems[0].Tag.ToString();
		int num = Conversions.ToInteger(text.Split(Conversions.ToCharArrayRankOne("_"))[1]);
		string text2 = text.Split(Conversions.ToCharArrayRankOne("_"))[0];
		if (num == 10000 || num == 10001 || num == 10002)
		{
			return;
		}
		string text3 = text2;
		if (Operators.CompareString(text3, "Ship", true) != 0)
		{
			if (Operators.CompareString(text3, "Sub", true) == 0)
			{
				Client.smethod_17("Submarine", num);
			}
			else if (Operators.CompareString(text3, "Amphib", true) != 0)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				Client.smethod_17("Ground Unit", num);
			}
		}
		else
		{
			Client.smethod_17("Ship", num);
		}
	}

	private void method_10(object sender, KeyPressEventArgs e)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
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

	private void method_11()
	{
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "Name ASC";
		((DataGridView)DataGridView1).DataSource = dataView;
	}

	private void method_12(object object_0)
	{
		if (Operators.CompareString(TB_Class.Text, "", true) != 0)
		{
			method_13();
		}
	}

	private void method_13()
	{
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "Name ASC";
		if (Operators.CompareString(TB_Class.Text, "", true) != 0 || ((ComboBox)CB_Country).SelectedIndex != 0 || ((ComboBox)CB_Hypothetical).SelectedIndex != 0 || ((ComboBox)CB_SubType).SelectedIndex != 0)
		{
			string text = "1=1 ";
			if (Operators.CompareString(TB_Class.Text, "", true) != 0)
			{
				string text2 = TB_Class.Text.Replace("'", "''");
				text = text + " AND Name LIKE '%" + text2 + "%' ";
			}
			if (((ComboBox)CB_Country).SelectedIndex > 0)
			{
				text = text + " AND OperatorCountry=" + ((ListControl)CB_Country).SelectedValue.ToString();
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
			dataView.RowFilter = text;
		}
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		((DataGridView)DataGridView1).DataSource = dataView;
		((Control)DataGridView1).Refresh();
	}

	private void method_14(object sender, EventArgs e)
	{
		method_2();
		method_13();
	}

	private void EditBoats_KeyDown(object sender, KeyEventArgs e)
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

	private void method_15(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_16(object sender, EventArgs e)
	{
		if (((ComboBox)CB_Hypothetical).Items.Count != 0 && ((ComboBox)CB_Country).Items.Count != 0)
		{
			method_13();
		}
	}

	private void method_17()
	{
		int num = 9;
		int num2 = default(int);
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			DataTable dataTable = new DataTable();
			while (true)
			{
				IL_00f3:
				if (!dataTable.Columns.Contains("ID"))
				{
					goto IL_00c3;
				}
				goto IL_00de;
				IL_00de:
				while (true)
				{
					IL_00de_2:
					if (dataTable.Columns.Contains("Description"))
					{
						goto IL_0099;
					}
					goto IL_00a6;
					IL_00a6:
					dataTable.Columns.Add("Description", typeof(string));
					goto IL_0099;
					IL_0099:
					while (true)
					{
						dataTable.Rows.Clear();
						while (true)
						{
							int selectedIndex = ((ComboBox)ComboBox1).SelectedIndex;
							num = 29;
							while (true)
							{
								if (num != 29)
								{
									if (num != 1010)
									{
										goto IL_021c;
									}
									switch (num)
									{
									case 20:
										goto end_IL_007b;
									case 2:
									case 15:
										goto end_IL_0087;
									case 6:
										goto end_IL_0099;
									case 12:
										goto end_IL_00de;
									case 10:
										goto IL_00de_2;
									case 8:
										goto IL_00f3;
									case 9:
										goto end_IL_00f3;
									case 14:
										goto IL_0137;
									case 22:
										goto IL_0139;
									case 0:
										goto IL_0219;
									case 11:
										goto IL_021c;
									case 3:
										goto IL_02ec;
									case 19:
										goto IL_02ef;
									case 5:
									case 18:
										goto IL_039d;
									case 13:
										goto IL_03ab;
									case 1:
										goto IL_03ce;
									case 4:
									case 17:
										return;
									case 16:
										goto IL_0406;
									case 7:
									case 21:
										return;
									}
									continue;
								}
								switch (selectedIndex)
								{
								case 0:
									break;
								case 1:
									goto IL_0219;
								case 2:
									goto IL_02ec;
								default:
									goto IL_039d;
								}
								goto IL_0137;
								IL_03ab:
								dataTable.Rows.Add(0, "None");
								goto IL_03ce;
								IL_0406:
								DarkUIComboBox cB_SubType = CB_SubType;
								((ComboBox)cB_SubType).DataSource = dataTable;
								((ListControl)cB_SubType).DisplayMember = "Description";
								((ListControl)cB_SubType).ValueMember = "ID";
								((ComboBox)cB_SubType).SelectedIndex = 0;
								((Control)cB_SubType).Enabled = true;
								((Control)cB_SubType).Visible = true;
								return;
								IL_03ce:
								DarkUIComboBox cB_SubType2 = CB_SubType;
								((ComboBox)cB_SubType2).DataSource = dataTable;
								((ListControl)cB_SubType2).DisplayMember = "Description";
								((ListControl)cB_SubType2).ValueMember = "ID";
								((ComboBox)cB_SubType2).SelectedIndex = 0;
								((Control)cB_SubType2).Enabled = false;
								((Control)cB_SubType2).Visible = false;
								return;
								IL_02ec:
								num2 = 0;
								goto IL_02ef;
								IL_02ef:
								foreach (object value in Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)))
								{
									IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(value);
									string text = Misc.ToEnglishString(mobileUnitCategory);
									if (!string.IsNullOrEmpty(text))
									{
										dataTable.Rows.Add((int)mobileUnitCategory, text);
									}
									else
									{
										dataTable.Rows.Add((int)mobileUnitCategory, mobileUnitCategory.ToString());
									}
									num2++;
								}
								goto IL_039d;
								IL_0219:
								num3 = 0;
								goto IL_021c;
								IL_021c:
								foreach (object value2 in Enum.GetValues(typeof(Submarine._SubmarineType)))
								{
									Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(value2);
									string text2 = Misc.Description(submarineType, Client.CurrentScenario.DBConnection);
									if (!string.IsNullOrEmpty(Misc.Description(submarineType, Client.CurrentScenario.DBConnection)))
									{
										dataTable.Rows.Add((int)submarineType, text2);
									}
									else
									{
										dataTable.Rows.Add((int)submarineType, submarineType.ToString());
									}
									num3++;
								}
								goto IL_039d;
								IL_0137:
								num4 = 0;
								goto IL_0139;
								IL_0139:
								foreach (object value3 in Enum.GetValues(typeof(Ship._ShipType)))
								{
									Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(value3);
									string text3 = Misc.Description(shipType, Client.CurrentScenario.DBConnection);
									Misc.Description(shipType, Client.CurrentScenario.DBConnection);
									if (string.IsNullOrEmpty(Misc.Description(shipType, Client.CurrentScenario.DBConnection)))
									{
										dataTable.Rows.Add((int)shipType, shipType.ToString());
									}
									else
									{
										dataTable.Rows.Add((int)shipType, text3);
									}
									num4++;
								}
								goto IL_039d;
								IL_039d:
								if (dataTable.Rows.Count <= 0)
								{
									goto IL_03ab;
								}
								goto IL_0406;
								continue;
								end_IL_007b:
								break;
							}
							continue;
							end_IL_0087:
							break;
						}
						continue;
						end_IL_0099:
						break;
					}
					goto IL_00a6;
					continue;
					end_IL_00de:
					break;
				}
				goto IL_00c3;
				IL_00c3:
				dataTable.Columns.Add("ID", typeof(int));
				goto IL_00de;
				continue;
				end_IL_00f3:
				break;
			}
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_19(object sender, DataGridViewCellEventArgs e)
	{
		int num = 5;
		while (e.RowIndex != -1)
		{
			while (true)
			{
				IL_0080:
				int num2 = Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells[0].Value.ToString());
				int selectedIndex;
				while (true)
				{
					IL_0075:
					if (num2 == 10000)
					{
						return;
					}
					while (true)
					{
						IL_0067:
						if (num2 == 10001)
						{
							return;
						}
						while (true)
						{
							IL_0059:
							if (num2 == 10002)
							{
								return;
							}
							while (true)
							{
								IL_0048:
								selectedIndex = ((ComboBox)ComboBox1).SelectedIndex;
								num = 16;
								while (num != 16)
								{
									if (num != 997)
									{
										goto IL_0048;
									}
									switch (num)
									{
									case 3:
										goto IL_0048;
									case 0:
										goto IL_0059;
									case 1:
										goto IL_0067;
									case 9:
										goto IL_0075;
									case 4:
										goto IL_0080;
									case 5:
										goto end_IL_0080;
									case 6:
										return;
									case 2:
										return;
									case 7:
										return;
									case 8:
										return;
									}
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				switch (selectedIndex)
				{
				case 0:
					Client.smethod_17("Ship", num2);
					break;
				case 1:
					Client.smethod_17("Submarine", num2);
					break;
				case 2:
					Client.smethod_17("Ground Unit", num2);
					break;
				}
				return;
				continue;
				end_IL_0080:
				break;
			}
		}
	}

	static EditBoats()
	{
		Class72.smethod_20();
	}
}

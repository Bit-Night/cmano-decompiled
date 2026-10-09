using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
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
public sealed class AddUnit : DarkSecondaryFormBase
{
	public delegate void theAddedUnitChangedEventHandler(ActiveUnit theAddedUnit);

	private IContainer icontainer_1;

	[AccessedThroughProperty("CB_Type")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Type;

	[AccessedThroughProperty("BtnOK")]
	[CompilerGenerated]
	private DarkUIButton _BtnOK;

	[AccessedThroughProperty("BtnCancel")]
	[CompilerGenerated]
	private DarkUIButton _BtnCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _DataGridView1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton _Button3;

	[AccessedThroughProperty("CB_Country")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Country;

	[CompilerGenerated]
	[AccessedThroughProperty("txt_name")]
	private DarkUITextBox _txt_name;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Hypothetical")]
	private DarkUIComboBox _CB_Hypothetical;

	[AccessedThroughProperty("Column_Name")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Name2")]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	[AccessedThroughProperty("Name3")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	[AccessedThroughProperty("CB_SubType")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_SubType;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Decoy_Unarmed")]
	private DarkUICheckBox _CB_Decoy_Unarmed;

	private DataTable dataTable_0;

	private DateTime dateTime_0;

	public string string_0;

	public static bool Unarmed;

	public int SelectedDBID;

	public GlobalVariables.ActiveUnitType SelectedUnitType;

	[CompilerGenerated]
	private static theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler_0;

	private static ActiveUnit activeUnit_0;

	[CompilerGenerated]
	private static bool bool_2;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUIComboBox CB_Type
	{
		[CompilerGenerated]
		get
		{
			return _CB_Type;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIComboBox darkUIComboBox = _CB_Type;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_Type = value;
			darkUIComboBox = _CB_Type;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUIButton BtnOK
	{
		[CompilerGenerated]
		get
		{
			return _BtnOK;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _BtnOK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnOK = value;
			darkUIButton = _BtnOK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton BtnCancel
	{
		[CompilerGenerated]
		get
		{
			return _BtnCancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _BtnCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnCancel = value;
			darkUIButton = _BtnCancel;
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
			//IL_000e: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			KeyPressEventHandler val = new KeyPressEventHandler(method_6);
			EventHandler eventHandler = method_9;
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(method_14);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).KeyPress -= val;
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellContentClick -= val2;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).KeyPress += val;
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellContentClick += val2;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("CB_Sides")]
	internal virtual DarkUIComboBox CB_Sides { get; set; }

	internal virtual DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button3 = value;
			darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TB_Class")]
	internal virtual DarkUITextBox TB_Class { get; set; }

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

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

	internal virtual DarkUITextBox txt_name
	{
		[CompilerGenerated]
		get
		{
			return _txt_name;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_3;
			DarkUITextBox darkUITextBox = _txt_name;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_txt_name = value;
			darkUITextBox = _txt_name;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
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
			EventHandler eventHandler = method_15;
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

	internal virtual DataGridViewTextBoxColumn Column_Name
	{
		[CompilerGenerated]
		get
		{
			return dataGridViewTextBoxColumn_0;
		}
		[CompilerGenerated]
		set
		{
			dataGridViewTextBoxColumn_0 = value;
		}
	}

	[field: AccessedThroughProperty("TB_CustomGUID")]
	internal virtual DarkUITextBox TB_CustomGUID { get; set; }

	internal virtual DataGridViewTextBoxColumn Name2
	{
		[CompilerGenerated]
		get
		{
			return dataGridViewTextBoxColumn_1;
		}
		[CompilerGenerated]
		set
		{
			dataGridViewTextBoxColumn_1 = value;
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	internal virtual DataGridViewTextBoxColumn Name3
	{
		[CompilerGenerated]
		get
		{
			return dataGridViewTextBoxColumn_2;
		}
		[CompilerGenerated]
		set
		{
			dataGridViewTextBoxColumn_2 = value;
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
			EventHandler eventHandler = method_12;
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

	internal virtual DarkUICheckBox CB_Decoy_Unarmed
	{
		[CompilerGenerated]
		get
		{
			return _CB_Decoy_Unarmed;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUICheckBox darkUICheckBox = _CB_Decoy_Unarmed;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_Decoy_Unarmed = value;
			darkUICheckBox = _CB_Decoy_Unarmed;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_decoy_Immobile")]
	internal virtual DarkUICheckBox CB_decoy_Immobile { get; set; }

	public static ActiveUnit theAddedUnit
	{
		get
		{
			return activeUnit_0;
		}
		set
		{
			activeUnit_0 = value;
			theAddedUnitChangedEventHandler_0?.Invoke(activeUnit_0);
		}
	}

	public static bool CalledFromAirOps
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

	public static event theAddedUnitChangedEventHandler theAddedUnitChanged
	{
		[CompilerGenerated]
		add
		{
			theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler = theAddedUnitChangedEventHandler_0;
			theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler2;
			do
			{
				theAddedUnitChangedEventHandler2 = theAddedUnitChangedEventHandler;
				theAddedUnitChangedEventHandler value2 = (theAddedUnitChangedEventHandler)Delegate.Combine(theAddedUnitChangedEventHandler2, value);
				theAddedUnitChangedEventHandler = Interlocked.CompareExchange(ref theAddedUnitChangedEventHandler_0, value2, theAddedUnitChangedEventHandler2);
			}
			while ((object)theAddedUnitChangedEventHandler != theAddedUnitChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler = theAddedUnitChangedEventHandler_0;
			theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler2;
			do
			{
				theAddedUnitChangedEventHandler2 = theAddedUnitChangedEventHandler;
				theAddedUnitChangedEventHandler value2 = (theAddedUnitChangedEventHandler)Delegate.Remove(theAddedUnitChangedEventHandler2, value);
				theAddedUnitChangedEventHandler = Interlocked.CompareExchange(ref theAddedUnitChangedEventHandler_0, value2, theAddedUnitChangedEventHandler2);
			}
			while ((object)theAddedUnitChangedEventHandler != theAddedUnitChangedEventHandler2);
		}
	}

	static AddUnit()
	{
		Class72.smethod_20();
		Unarmed = false;
		CalledFromAirOps = false;
	}

	public AddUnit()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(AddUnit_FormClosing);
		((Form)this).Shown += AddUnit_Shown;
		((Control)this).KeyDown += new KeyEventHandler(AddUnit_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(AddUnit_FormClosed);
		((Form)this).Load += AddUnit_Load;
		dataTable_0 = new DataTable();
		dateTime_0 = default(DateTime);
		string_0 = null;
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
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
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Expected O, but got Unknown
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Expected O, but got Unknown
		//IL_0bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbd: Expected O, but got Unknown
		//IL_0c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c58: Expected O, but got Unknown
		//IL_0c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d43: Expected O, but got Unknown
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_102b: Expected O, but got Unknown
		//IL_10c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ce: Expected O, but got Unknown
		//IL_1204: Unknown result type (might be due to invalid IL or missing references)
		//IL_120e: Expected O, but got Unknown
		//IL_13d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13de: Expected O, but got Unknown
		//IL_1596: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a0: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		Label1 = new DarkLabel();
		CB_Type = new DarkUIComboBox();
		Label2 = new DarkLabel();
		BtnOK = new DarkUIButton();
		BtnCancel = new DarkUIButton();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		FullName = new DataGridViewLinkColumn();
		ShortName = new DataGridViewTextBoxColumn();
		Country = new DataGridViewTextBoxColumn();
		IOC = new DataGridViewTextBoxColumn();
		Retired = new DataGridViewTextBoxColumn();
		Hypothetical = new DataGridViewCheckBoxColumn();
		CountryNumber = new DataGridViewTextBoxColumn();
		Label3 = new DarkLabel();
		CB_Sides = new DarkUIComboBox();
		Button3 = new DarkUIButton();
		TB_Class = new DarkUITextBox();
		GroupBox1 = new DarkGroupBox();
		DarkLabel1 = new DarkLabel();
		CB_SubType = new DarkUIComboBox();
		CB_Hypothetical = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_Country = new DarkUIComboBox();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		txt_name = new DarkUITextBox();
		Label6 = new DarkLabel();
		TB_CustomGUID = new DarkUITextBox();
		CB_Decoy_Unarmed = new DarkUICheckBox();
		CB_decoy_Immobile = new DarkUICheckBox();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)GroupBox1).SuspendLayout();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(9, 15);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(35, 15);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Type:";
		((ComboBox)CB_Type).BackColor = Color.Transparent;
		((ComboBox)CB_Type).DrawMode = (DrawMode)1;
		((ComboBox)CB_Type).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Type).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Type).FormattingEnabled = true;
		((ComboBox)CB_Type).Items.AddRange(new object[4] { "Aircraft", "Surface Ship", "Submarine", "Facility" });
		((Control)CB_Type).Location = new Point(54, 13);
		((Control)CB_Type).Name = "CB_Type";
		((Control)CB_Type).Size = new Size(326, 21);
		((Control)CB_Type).TabIndex = 1;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(9, 67);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(42, 15);
		((Control)Label2).TabIndex = 2;
		((Label)Label2).Text = "Name:";
		((Control)BtnOK).Anchor = (AnchorStyles)6;
		((ButtonBase)BtnOK).BackColor = Color.Transparent;
		((Control)BtnOK).Font = new Font("Segoe UI", 10f);
		((Control)BtnOK).ForeColor = SystemColors.Control;
		((Control)BtnOK).Location = new Point(12, 585);
		((Control)BtnOK).Name = "BtnOK";
		((Control)BtnOK).Padding = new Padding(5);
		BtnOK.RoundRadius = 0;
		((Control)BtnOK).Size = new Size(75, 23);
		((Control)BtnOK).TabIndex = 4;
		BtnOK.Text = "OK";
		((Control)BtnCancel).Anchor = (AnchorStyles)10;
		((ButtonBase)BtnCancel).BackColor = Color.Transparent;
		((Control)BtnCancel).Font = new Font("Segoe UI", 10f);
		((Control)BtnCancel).ForeColor = SystemColors.Control;
		((Control)BtnCancel).Location = new Point(678, 585);
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Padding = new Padding(5);
		BtnCancel.RoundRadius = 0;
		((Control)BtnCancel).Size = new Size(75, 23);
		((Control)BtnCancel).TabIndex = 5;
		BtnCancel.Text = "Cancel";
		((DataGridView)DataGridView1).AllowUserToAddRows = false;
		((DataGridView)DataGridView1).AllowUserToDeleteRows = false;
		((DataGridView)DataGridView1).AllowUserToOrderColumns = true;
		((DataGridView)DataGridView1).AllowUserToResizeColumns = false;
		((DataGridView)DataGridView1).AllowUserToResizeRows = false;
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
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[8]
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
		((DataGridView)DataGridView1).DefaultCellStyle = val2;
		((DataGridView)DataGridView1).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DataGridView1).EnableHeadersVisualStyles = false;
		((Control)DataGridView1).Location = new Point(12, 223);
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
		((Control)DataGridView1).Size = new Size(741, 356);
		((Control)DataGridView1).TabIndex = 6;
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
		((DataGridViewColumn)Country).Width = 73;
		((DataGridViewColumn)IOC).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)IOC).DataPropertyName = "YearCommissioned";
		((DataGridViewColumn)IOC).HeaderText = "From";
		((DataGridViewColumn)IOC).MinimumWidth = 8;
		((DataGridViewColumn)IOC).Name = "IOC";
		((DataGridViewColumn)IOC).ReadOnly = true;
		((DataGridViewColumn)IOC).Width = 58;
		((DataGridViewColumn)Retired).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Retired).DataPropertyName = "YearDecommissioned";
		((DataGridViewColumn)Retired).HeaderText = "Until";
		((DataGridViewColumn)Retired).MinimumWidth = 8;
		((DataGridViewColumn)Retired).Name = "Retired";
		((DataGridViewColumn)Retired).ReadOnly = true;
		((DataGridViewColumn)Retired).Width = 55;
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
		((DataGridViewColumn)Hypothetical).Width = 59;
		((DataGridViewColumn)CountryNumber).DataPropertyName = "OperatorCountry";
		((DataGridViewColumn)CountryNumber).HeaderText = "Operator";
		((DataGridViewColumn)CountryNumber).MinimumWidth = 8;
		((DataGridViewColumn)CountryNumber).Name = "CountryNumber";
		((DataGridViewColumn)CountryNumber).ReadOnly = true;
		((DataGridViewColumn)CountryNumber).Visible = false;
		((DataGridViewColumn)CountryNumber).Width = 150;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(9, 43);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(32, 15);
		((Control)Label3).TabIndex = 7;
		((Label)Label3).Text = "Side:";
		((ComboBox)CB_Sides).BackColor = Color.Transparent;
		((ComboBox)CB_Sides).DrawMode = (DrawMode)1;
		((ComboBox)CB_Sides).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Sides).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Sides).FormattingEnabled = true;
		((ComboBox)CB_Sides).Items.AddRange(new object[1] { "Aircraft" });
		((Control)CB_Sides).Location = new Point(54, 38);
		((Control)CB_Sides).Name = "CB_Sides";
		((Control)CB_Sides).Size = new Size(326, 21);
		((Control)CB_Sides).TabIndex = 8;
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Control)Button3).Font = new Font("Segoe UI", 10f);
		((Control)Button3).ForeColor = SystemColors.Control;
		((Control)Button3).Location = new Point(386, 38);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(83, 21);
		((Control)Button3).TabIndex = 9;
		Button3.Text = "Edit sides...";
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
		((Control)GroupBox1).Controls.Add((Control)(object)DarkLabel1);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_SubType);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Hypothetical);
		((Control)GroupBox1).Controls.Add((Control)(object)Label7);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Country);
		((Control)GroupBox1).Controls.Add((Control)(object)Label5);
		((Control)GroupBox1).Controls.Add((Control)(object)Label4);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Class);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(12, 89);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(457, 94);
		((Control)GroupBox1).TabIndex = 12;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Filter by...";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(7, 44);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(55, 15);
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
		((Control)CB_SubType).Size = new Size(201, 21);
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
		((Control)CB_Hypothetical).Size = new Size(363, 21);
		((Control)CB_Hypothetical).TabIndex = 18;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(4, 73);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(78, 15);
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
		((Control)CB_Country).Size = new Size(173, 21);
		((Control)CB_Country).TabIndex = 13;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(226, 20);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(53, 15);
		((Control)Label5).TabIndex = 12;
		((Label)Label5).Text = "Country:";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(7, 21);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(37, 15);
		((Control)Label4).TabIndex = 11;
		((Label)Label4).Text = "Class:";
		txt_name.AutoCompleteCustomSource = null;
		txt_name.AutoCompleteMode = (AutoCompleteMode)0;
		txt_name.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txt_name).BackColor = Color.Transparent;
		txt_name.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)txt_name).ForeColor = Color.FromArgb(189, 189, 189);
		txt_name.Image = null;
		txt_name.Lines = null;
		((Control)txt_name).Location = new Point(54, 64);
		txt_name.MaxLength = 32767;
		txt_name.Multiline = false;
		((Control)txt_name).Name = "txt_name";
		txt_name.ReadOnly = false;
		txt_name.ScrollBars = (ScrollBars)0;
		txt_name.SelectionStart = 0;
		((Control)txt_name).Size = new Size(415, 24);
		((Control)txt_name).TabIndex = 3;
		txt_name.TextAlign = (HorizontalAlignment)0;
		txt_name.UseSystemPasswordChar = false;
		txt_name.WatermarkText = "";
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(9, 196);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(82, 15);
		((Control)Label6).TabIndex = 13;
		((Label)Label6).Text = "Custom GUID:";
		TB_CustomGUID.AutoCompleteCustomSource = null;
		TB_CustomGUID.AutoCompleteMode = (AutoCompleteMode)0;
		TB_CustomGUID.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_CustomGUID).BackColor = Color.Transparent;
		TB_CustomGUID.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TB_CustomGUID).ForeColor = Color.FromArgb(189, 189, 189);
		TB_CustomGUID.Image = null;
		TB_CustomGUID.Lines = null;
		((Control)TB_CustomGUID).Location = new Point(94, 189);
		TB_CustomGUID.MaxLength = 32767;
		TB_CustomGUID.Multiline = false;
		((Control)TB_CustomGUID).Name = "TB_CustomGUID";
		TB_CustomGUID.ReadOnly = false;
		TB_CustomGUID.ScrollBars = (ScrollBars)0;
		TB_CustomGUID.SelectionStart = 0;
		((Control)TB_CustomGUID).Size = new Size(369, 22);
		((Control)TB_CustomGUID).TabIndex = 14;
		TB_CustomGUID.TextAlign = (HorizontalAlignment)0;
		TB_CustomGUID.UseSystemPasswordChar = false;
		TB_CustomGUID.WatermarkText = "";
		((ButtonBase)CB_Decoy_Unarmed).BackColor = Color.Transparent;
		((Control)CB_Decoy_Unarmed).Cursor = Cursors.Hand;
		((Control)CB_Decoy_Unarmed).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_Decoy_Unarmed).Location = new Point(554, 43);
		((Control)CB_Decoy_Unarmed).Name = "CB_Decoy_Unarmed";
		((Control)CB_Decoy_Unarmed).Size = new Size(129, 18);
		((Control)CB_Decoy_Unarmed).TabIndex = 16;
		((ButtonBase)CB_Decoy_Unarmed).Text = "Unarmed";
		((ButtonBase)CB_decoy_Immobile).BackColor = Color.Transparent;
		((Control)CB_decoy_Immobile).Cursor = Cursors.Hand;
		((Control)CB_decoy_Immobile).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)CB_decoy_Immobile).Location = new Point(554, 67);
		((Control)CB_decoy_Immobile).Name = "CB_decoy_Immobile";
		((Control)CB_decoy_Immobile).Size = new Size(129, 18);
		((Control)CB_decoy_Immobile).TabIndex = 17;
		((ButtonBase)CB_decoy_Immobile).Text = "Immobile";
		((Control)CB_decoy_Immobile).Visible = false;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(765, 620);
		((Control)this).Controls.Add((Control)(object)CB_decoy_Immobile);
		((Control)this).Controls.Add((Control)(object)CB_Decoy_Unarmed);
		((Control)this).Controls.Add((Control)(object)TB_CustomGUID);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)Button3);
		((Control)this).Controls.Add((Control)(object)CB_Sides);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)DataGridView1);
		((Control)this).Controls.Add((Control)(object)BtnCancel);
		((Control)this).Controls.Add((Control)(object)BtnOK);
		((Control)this).Controls.Add((Control)(object)txt_name);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)CB_Type);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddUnit";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Add new unit";
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		switch (Client.CurrentUserAction)
		{
		case Client.UserAction.AddingAggregateUnit:
		case Client.UserAction.EditingAggregateUnit:
			SelectedDBID = Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString());
			switch (((ComboBox)CB_Type).SelectedIndex)
			{
			default:
				DarkMessageBox.ShowError("Selected unit type is not suitable for aggregate unit! Aborting.", "Unsuitable unit type");
				return;
			case 4:
				SelectedUnitType = GlobalVariables.ActiveUnitType.Vehicle;
				break;
			case 3:
				SelectedUnitType = GlobalVariables.ActiveUnitType.Facility;
				break;
			}
			goto default;
		case Client.UserAction.AddingPlatform:
			if (Operators.CompareString(txt_name.Text, "", true) != 0)
			{
				if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count == 0)
				{
					break;
				}
				if (!string.IsNullOrEmpty(TB_CustomGUID.Text))
				{
					if (Misc.ContainsChar(TB_CustomGUID.Text, ' '))
					{
						TB_CustomGUID.Text = TB_CustomGUID.Text.Replace(" ", "-");
					}
					string_0 = TB_CustomGUID.Text;
				}
				Geopoint_Struct mapClickWorldPoint = MyProject.Forms.MainForm.MapClickWorldPoint;
				switch (((ComboBox)CB_Type).SelectedIndex)
				{
				case 0:
				{
					new DataTable();
					int aircraftID = Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString());
					SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
					Scenario currentScenario = Client.CurrentScenario;
					bool UnlimitedAirWeapons = false;
					Scenario CurrentScenario = null;
					Aircraft SelectedAircraft = null;
					int int_ = 0;
					bool ExcludeOptionalWeapons = false;
					if (DBFunctions.LoadoutsForThisAircraft_DT(aircraftID, null, ref sqliteConnection_, currentScenario, ref UnlimitedAirWeapons, ref CurrentScenario, ref SelectedAircraft, ref int_, ref ExcludeOptionalWeapons).Rows.Count != 0)
					{
						MyProject.Forms.SelectLoadout.AircraftName = txt_name.Text;
						MyProject.Forms.SelectLoadout.AircraftID = Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString());
						MyProject.Forms.SelectLoadout.AircraftSide = Client.CurrentScenario.Sides_ReadOnly[((ComboBox)CB_Sides).SelectedIndex];
						((Control)MyProject.Forms.SelectLoadout).Show();
					}
					else
					{
						theAddedUnit = Client.CurrentScenario.AddNewAircraft(Client.CurrentScenario.Sides_ReadOnly[((ComboBox)CB_Sides).SelectedIndex], txt_name.Text, mapClickWorldPoint.Longitude, mapClickWorldPoint.Latitude, Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString()), 0, 1000f, (Module_Unit.Unit.RemoteSimEntityTypeEnum)Conversions.ToShort(string_0));
						((Form)this).Close();
					}
					return;
				}
				case 1:
					try
					{
						theAddedUnit = Client.CurrentScenario.AddNewShip(Client.CurrentScenario.Sides_ReadOnly[((ComboBox)CB_Sides).SelectedIndex], Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString()), txt_name.Text, mapClickWorldPoint.Longitude, mapClickWorldPoint.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
					}
					catch (Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						Exception ex10 = ex9;
						DarkMessageBox.ShowError("Error: " + ex10.Message, "Error");
						ProjectData.ClearProjectError();
						return;
					}
					break;
				case 2:
					try
					{
						theAddedUnit = Client.CurrentScenario.AddNewSubmarine(Client.CurrentScenario.Sides_ReadOnly[((ComboBox)CB_Sides).SelectedIndex], Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString()), txt_name.Text, mapClickWorldPoint.Longitude, mapClickWorldPoint.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						DarkMessageBox.ShowError("Error: " + ex8.Message, "Error");
						ProjectData.ClearProjectError();
						return;
					}
					break;
				case 3:
					try
					{
						theAddedUnit = Client.CurrentScenario.AddNewFacility(Client.CurrentScenario.Sides_ReadOnly[((ComboBox)CB_Sides).SelectedIndex], Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString()), txt_name.Text, mapClickWorldPoint.Longitude, mapClickWorldPoint.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						DarkMessageBox.ShowError("Error: " + ex6.Message, "Error");
						ProjectData.ClearProjectError();
						return;
					}
					break;
				case 4:
					try
					{
						theAddedUnit = Client.CurrentScenario.AddNewVehicle(Client.CurrentScenario.Sides_ReadOnly[((ComboBox)CB_Sides).SelectedIndex], Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString()), txt_name.Text, mapClickWorldPoint.Longitude, mapClickWorldPoint.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						Interaction.MsgBox((object)("Error: " + ex4.Message), (MsgBoxStyle)0, (object)null);
						ProjectData.ClearProjectError();
						return;
					}
					break;
				case 5:
					try
					{
						theAddedUnit = Client.CurrentScenario.method_3(Client.CurrentScenario.Sides_ReadOnly[((ComboBox)CB_Sides).SelectedIndex], ((DataGridView)DataGridView1).SelectedRows[0].Cells[1].Value.ToString(), txt_name.Text, mapClickWorldPoint.Longitude, mapClickWorldPoint.Latitude, IgnoreElevationCheck: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)0, (object)null);
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				if (Client.CurrentScenario.Sides_ReadOnly.Length == 1)
				{
					Client.CurrentSide = Client.CurrentScenario.Sides_ReadOnly[0];
				}
				goto default;
			}
			DarkMessageBox.ShowWarning("You need to provide a name for the new unit.", "No name?");
			break;
		default:
			((Form)this).DialogResult = (DialogResult)1;
			((Form)this).Close();
			break;
		}
	}

	private void AddUnit_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (Client.CurrentUserAction == Client.UserAction.AddingPlatform)
		{
			Client.CurrentUserAction = Client.UserAction.None;
		}
		((Control)MyProject.Forms.MainForm).Enabled = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_3(object object_0)
	{
		BtnOK.Enabled = Operators.CompareString(txt_name.Text, "", true) != 0;
	}

	private void method_4(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_5(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.Sides).Show();
	}

	public void RefreshSides()
	{
		((ComboBox)CB_Sides).Items.Clear();
		((ComboBox)CB_Sides).BeginUpdate();
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			((ComboBox)CB_Sides).Items.Add((object)side.Name);
		}
		((ComboBox)CB_Sides).EndUpdate();
		if (((ComboBox)CB_Sides).Items.Count > 0)
		{
			((ComboBox)CB_Sides).SelectedIndex = Array.IndexOf(Client.CurrentScenario.Sides_ReadOnly, Client.CurrentSide);
		}
		BtnOK.Enabled = (((ComboBox)CB_Sides).Items.Count > 0) & !Information.IsNothing((object)((ComboBox)CB_Sides).SelectedIndex);
	}

	private void method_6(object sender, KeyPressEventArgs e)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		DataView dataView = new DataView(dataTable_0);
		dataView.Sort = "LongName ASC";
		dataView.RowFilter = "LongName LIKE '" + Conversions.ToString(e.KeyChar) + "%'";
		if (dataView.Count <= 0)
		{
			return;
		}
		int num = Conversions.ToInteger(dataView[0][0].ToString());
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

	private void method_7(object object_0)
	{
		method_8();
	}

	private void method_8()
	{
		Client.AddUnit_LastUsedType = (byte)((ComboBox)CB_Type).SelectedIndex;
		Client.AddUnit_LastUsedCountry = Conversions.ToInteger(((ListControl)CB_Country).SelectedValue);
		Client.AddUnit_LastUsedKeyword = TB_Class.Text.Replace("'", "''");
		switch (((ComboBox)CB_Type).SelectedIndex)
		{
		default:
			return;
		case 0:
			dataTable_0 = Client.CurrentScenario.Cache_Aircraft_DT;
			break;
		case 1:
			dataTable_0 = Client.CurrentScenario.Cache_Ships_DT;
			break;
		case 2:
			dataTable_0 = Client.CurrentScenario.Cache_Subs_DT;
			break;
		case 3:
			dataTable_0 = Client.CurrentScenario.Cache_Facilities_DT;
			break;
		case 4:
			dataTable_0 = Client.CurrentScenario.Cache_GroundUnits_DT;
			break;
		case 5:
			dataTable_0 = AGU_DATABASE.DataTable;
			break;
		}
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
				text2 = text2.Replace("%", "");
				text2 = text2.Replace("*", "");
				text2 = text2.Replace("?", "");
				TB_Class.Text = TB_Class.Text.Replace("%", "");
				TB_Class.Text = TB_Class.Text.Replace("*", "");
				TB_Class.Text = TB_Class.Text.Replace("?", "");
				text = text + " AND LongName LIKE '%" + text2 + "%' ";
			}
			if (((ComboBox)CB_Country).SelectedIndex > 0)
			{
				text = text + " AND OperatorCountry=" + Conversions.ToString(Conversions.ToInteger(((ListControl)CB_Country).SelectedValue));
			}
			if (((ComboBox)CB_SubType).SelectedIndex > 0 && ((ComboBox)CB_SubType).SelectedIndex > 0)
			{
				text = ((((ComboBox)CB_Type).SelectedIndex == 3) ? (text + " AND category=" + ((ListControl)CB_SubType).SelectedValue.ToString()) : ((((ComboBox)CB_Type).SelectedIndex != 4) ? (text + " AND type=" + ((ListControl)CB_SubType).SelectedValue.ToString()) : (text + " AND category=" + ((ListControl)CB_SubType).SelectedValue.ToString())));
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
		((Control)DataGridView1).SuspendLayout();
		((Control)DataGridView1).Enabled = false;
		((DataGridView)DataGridView1).DataSource = dataView;
		((DataGridView)DataGridView1).Columns[1].AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((Control)DataGridView1).Refresh();
		((Control)DataGridView1).Enabled = true;
		((Control)DataGridView1).ResumeLayout();
	}

	private void method_9(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DataGridView1).SelectedRows).Count > 0)
		{
			txt_name.Text = Misc.RemoveHiddenString(Conversions.ToString(((DataGridView)DataGridView1).SelectedRows[0].Cells[2].Value));
		}
	}

	private void AddUnit_Shown(object sender, EventArgs e)
	{
		dateTime_0 = DateTime.UtcNow;
		TB_Class.TextChanged += method_7;
		((DataGridView)DataGridView1).AutoGenerateColumns = false;
		if (Client.CurrentScenario.Cache_GroundUnits_DT.Rows.Count > 0)
		{
			((ComboBox)CB_Type).Items.Add((object)"Ground Unit");
		}
		if (AGU_CONFIG.Instance.Enabled && AGU_DATABASE.DB.Count > 0)
		{
			((ComboBox)CB_Type).Items.Add((object)"Aggregate Ground Unit");
		}
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		((ComboBox)CB_Country).DataSource = cache_OperatorCountries_DT;
		((ListControl)CB_Country).DisplayMember = "Description";
		((ListControl)CB_Country).ValueMember = "ID";
		((ComboBox)CB_Country).SelectedIndex = 0;
		((ComboBox)CB_Hypothetical).Items.Clear();
		((ComboBox)CB_Hypothetical).Items.AddRange(new object[3] { "Show all platforms, both real-life and hypothetical", "Show real-life platforms only", "Show hypothetical platforms only" });
		((ComboBox)CB_Hypothetical).SelectedIndex = 0;
		BtnOK.Enabled = Operators.CompareString(txt_name.Text, "", true) != 0;
		((ComboBox)CB_Type).SelectedIndex = 0;
		BtnOK.Enabled = false;
		RefreshSides();
		if (Client.AddUnit_LastUsedCountry.HasValue | !string.IsNullOrEmpty(Client.AddUnit_LastUsedKeyword) | Client.AddUnit_LastUsedType.HasValue)
		{
			if (Client.AddUnit_LastUsedCountry.HasValue)
			{
				((ListControl)CB_Country).SelectedValue = Client.AddUnit_LastUsedCountry;
			}
			if (Client.AddUnit_LastUsedType.HasValue)
			{
				try
				{
					((ComboBox)CB_Type).SelectedIndex = Client.AddUnit_LastUsedType.Value;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					((ComboBox)CB_Type).SelectedIndex = 0;
					ProjectData.ClearProjectError();
				}
			}
			if (!string.IsNullOrEmpty(Client.AddUnit_LastUsedKeyword))
			{
				TB_Class.Text = Client.AddUnit_LastUsedKeyword;
			}
		}
		method_10();
		method_8();
	}

	private void method_10()
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
		switch (((ComboBox)CB_Type).SelectedIndex)
		{
		default:
			return;
		case 0:
			foreach (object value in Enum.GetValues(typeof(Aircraft._AircraftType)))
			{
				Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(value);
				string text5 = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
				if (string.IsNullOrEmpty(Misc.Description(aircraftType, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)aircraftType, text5);
				}
			}
			break;
		case 1:
			foreach (object value2 in Enum.GetValues(typeof(Ship._ShipType)))
			{
				Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(value2);
				string text4 = Misc.Description(shipType, Client.CurrentScenario.DBConnection);
				if (!string.IsNullOrEmpty(Misc.Description(shipType, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)shipType, text4);
				}
				else
				{
					dataTable.Rows.Add((int)shipType, shipType.ToString());
				}
			}
			break;
		case 2:
			foreach (object value3 in Enum.GetValues(typeof(Submarine._SubmarineType)))
			{
				Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(value3);
				string text3 = Misc.Description(submarineType, Client.CurrentScenario.DBConnection);
				if (!string.IsNullOrEmpty(Misc.Description(submarineType, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)submarineType, text3);
				}
				else
				{
					dataTable.Rows.Add((int)submarineType, submarineType.ToString());
				}
			}
			break;
		case 3:
			foreach (object value4 in Enum.GetValues(typeof(Facility._FacilityCategory)))
			{
				Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(value4);
				string text2 = Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection);
				if (string.IsNullOrEmpty(Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)facilityCategory, facilityCategory.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)facilityCategory, text2);
				}
			}
			break;
		case 4:
			foreach (object value5 in Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)))
			{
				IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(value5);
				string text = Misc.ToEnglishString(mobileUnitCategory);
				if (string.IsNullOrEmpty(text))
				{
					dataTable.Rows.Add((int)mobileUnitCategory, mobileUnitCategory.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)mobileUnitCategory, text);
				}
			}
			break;
		case 5:
			break;
		}
		DataTable dataTable2 = new DataTable();
		dataTable2.Columns.Add("ID", typeof(int));
		dataTable2.Columns.Add("Description", typeof(string));
		if (dataTable.Rows.Count > 0)
		{
			DataView dataView = new DataView(dataTable);
			dataView.Sort = "Description ASC";
			dataTable2.Rows.Add(0, "None");
			foreach (DataRowView item in dataView)
			{
				if (Conversions.ToInteger(item["ID"]) != 0)
				{
					dataTable2.ImportRow(item.Row);
				}
			}
			DarkUIComboBox cB_SubType = CB_SubType;
			((ComboBox)cB_SubType).DataSource = dataTable2;
			((ListControl)cB_SubType).DisplayMember = "Description";
			((ListControl)cB_SubType).ValueMember = "ID";
			((ComboBox)cB_SubType).SelectedIndex = 0;
			((Control)cB_SubType).Enabled = true;
			((Control)cB_SubType).Visible = true;
		}
		else
		{
			dataTable2.Rows.Add(0, "None");
			DarkUIComboBox cB_SubType2 = CB_SubType;
			((ComboBox)cB_SubType2).DataSource = dataTable2;
			((ListControl)cB_SubType2).DisplayMember = "Description";
			((ListControl)cB_SubType2).ValueMember = "ID";
			((ComboBox)cB_SubType2).SelectedIndex = 0;
			((Control)cB_SubType2).Enabled = false;
			((Control)cB_SubType2).Visible = false;
		}
		((ComboBox)CB_SubType).SelectedIndex = 0;
	}

	private void method_11(object sender, EventArgs e)
	{
		TB_Class.Clear();
		method_10();
		method_8();
	}

	private void method_12(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_13(object sender, EventArgs e)
	{
		method_8();
	}

	private void AddUnit_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
	}

	private void method_14(object sender, DataGridViewCellEventArgs e)
	{
		if (!(DateTime.UtcNow - dateTime_0 < TimeSpan.FromMilliseconds(500.0)) && e.RowIndex != -1 && (object)((DataGridView)DataGridView1).Columns[e.ColumnIndex].CellType == typeof(DataGridViewLinkCell))
		{
			int selectedObjectID = Conversions.ToInteger(((DataGridView)DataGridView1).SelectedRows[0].Cells["ID"].Value.ToString());
			string selectedObjectType = default(string);
			switch (((ComboBox)CB_Type).SelectedIndex)
			{
			case 0:
				selectedObjectType = "Aircraft";
				break;
			case 1:
				selectedObjectType = "Ship";
				break;
			case 2:
				selectedObjectType = "Submarine";
				break;
			case 3:
				selectedObjectType = "Facility";
				break;
			case 4:
				selectedObjectType = "GroundUnit";
				break;
			case 5:
				selectedObjectType = "AGU";
				break;
			}
			Client.smethod_17(selectedObjectType, selectedObjectID);
		}
	}

	private void AddUnit_FormClosed(object sender, FormClosedEventArgs e)
	{
		TB_Class.TextChanged -= method_7;
		CalledFromAirOps = false;
	}

	private void method_15(object sender, EventArgs e)
	{
		method_8();
	}

	private void AddUnit_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (!Client.AddingDecoyPlatform)
		{
			((Control)CB_Decoy_Unarmed).Visible = false;
			Unarmed = false;
			return;
		}
		((Form)this).Text = "Add new Decoy";
		((Control)CB_Decoy_Unarmed).Visible = true;
		((CheckBox)CB_Decoy_Unarmed).Checked = true;
		Unarmed = true;
	}

	private void method_16(object sender, EventArgs e)
	{
		Unarmed = ((CheckBox)CB_Decoy_Unarmed).Checked;
	}
}

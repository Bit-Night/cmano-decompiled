using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class PriorityTargetForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("CB_TargetUnitClass")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_TargetUnitClass;

	[AccessedThroughProperty("CB_TargetSubtype")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_TargetSubtype;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TargetType")]
	private DarkUIComboBox _CB_TargetType;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton _Button_Cancel;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OK")]
	private DarkUIButton _Button_OK;

	[CompilerGenerated]
	[AccessedThroughProperty("Check_ExistingTypes")]
	private DarkCheckBox _Check_ExistingTypes;

	public Doctrine ParentDoctrine;

	public DoctrineForm MainDoctrineForm;

	public int InsertIndex;

	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	internal virtual DarkUIComboBox CB_TargetUnitClass
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetUnitClass;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUIComboBox darkUIComboBox = _CB_TargetUnitClass;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_TargetUnitClass = value;
			darkUIComboBox = _CB_TargetUnitClass;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_TargetSubtype
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetSubtype;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIComboBox darkUIComboBox = _CB_TargetSubtype;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_TargetSubtype = value;
			darkUIComboBox = _CB_TargetSubtype;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_TargetType
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIComboBox darkUIComboBox = _CB_TargetType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_TargetType = value;
			darkUIComboBox = _CB_TargetType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Cancel = value;
			darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return _Button_OK;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OK = value;
			darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox Check_ExistingTypes
	{
		[CompilerGenerated]
		get
		{
			return _Check_ExistingTypes;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkCheckBox darkCheckBox = _Check_ExistingTypes;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_Check_ExistingTypes = value;
			darkCheckBox = _Check_ExistingTypes;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public PriorityTargetForm()
	{
		((Form)this).Load += [SpecialName] (object sender, EventArgs e) =>
		{
			PriorityTargetForm_Load();
		};
		InsertIndex = -1;
		bool_2 = false;
		RTMPEnabled = true;
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
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected O, but got Unknown
		Label4 = new DarkLabel();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		Button_Cancel = new DarkUIButton();
		Button_OK = new DarkUIButton();
		CB_TargetUnitClass = new DarkUIComboBox();
		CB_TargetSubtype = new DarkUIComboBox();
		CB_TargetType = new DarkUIComboBox();
		Check_ExistingTypes = new DarkCheckBox();
		((Control)this).SuspendLayout();
		((Control)Label4).Anchor = (AnchorStyles)4;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(18, 106);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(70, 15);
		((Control)Label4).TabIndex = 11;
		((Label)Label4).Text = "Target class:";
		((Control)Label3).Anchor = (AnchorStyles)4;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(18, 74);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(87, 15);
		((Control)Label3).TabIndex = 10;
		((Label)Label3).Text = "Target subtype:";
		((Control)Label2).Anchor = (AnchorStyles)4;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(18, 43);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 15);
		((Control)Label2).TabIndex = 9;
		((Label)Label2).Text = "Target type:";
		((Control)Button_Cancel).Anchor = (AnchorStyles)2;
		((ButtonBase)Button_Cancel).BackColor = Color.Transparent;
		((Button)Button_Cancel).DialogResult = (DialogResult)0;
		((Control)Button_Cancel).Font = new Font("Segoe UI", 10f);
		((Control)Button_Cancel).ForeColor = SystemColors.Control;
		((Control)Button_Cancel).Location = new Point(388, 165);
		((Control)Button_Cancel).Name = "Button_Cancel";
		Button_Cancel.RoundRadius = 0;
		((Control)Button_Cancel).Size = new Size(104, 23);
		((Control)Button_Cancel).TabIndex = 16;
		Button_Cancel.Text = "Cancel";
		((Control)Button_OK).Anchor = (AnchorStyles)2;
		((ButtonBase)Button_OK).BackColor = Color.Transparent;
		((Button)Button_OK).DialogResult = (DialogResult)0;
		((Control)Button_OK).Font = new Font("Segoe UI", 10f);
		((Control)Button_OK).ForeColor = SystemColors.Control;
		((Control)Button_OK).Location = new Point(213, 165);
		((Control)Button_OK).Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		((Control)Button_OK).Size = new Size(95, 23);
		((Control)Button_OK).TabIndex = 15;
		Button_OK.Text = "Add";
		((Control)CB_TargetUnitClass).Anchor = (AnchorStyles)12;
		((ComboBox)CB_TargetUnitClass).BackColor = Color.Transparent;
		((ComboBox)CB_TargetUnitClass).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetUnitClass).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetUnitClass).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_TargetUnitClass).FormattingEnabled = true;
		((Control)CB_TargetUnitClass).Location = new Point(107, 103);
		((Control)CB_TargetUnitClass).Name = "CB_TargetUnitClass";
		((Control)CB_TargetUnitClass).Size = new Size(571, 21);
		((Control)CB_TargetUnitClass).TabIndex = 14;
		((Control)CB_TargetSubtype).Anchor = (AnchorStyles)12;
		((ComboBox)CB_TargetSubtype).BackColor = Color.Transparent;
		((ComboBox)CB_TargetSubtype).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetSubtype).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetSubtype).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_TargetSubtype).FormattingEnabled = true;
		((Control)CB_TargetSubtype).Location = new Point(107, 71);
		((Control)CB_TargetSubtype).Name = "CB_TargetSubtype";
		((Control)CB_TargetSubtype).Size = new Size(571, 21);
		((Control)CB_TargetSubtype).TabIndex = 13;
		((Control)CB_TargetType).Anchor = (AnchorStyles)12;
		((ComboBox)CB_TargetType).BackColor = Color.Transparent;
		((ComboBox)CB_TargetType).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetType).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_TargetType).FormattingEnabled = true;
		((ComboBox)CB_TargetType).Items.AddRange(new object[8] { "None", "Aircraft", "Surface Ship", "Submarine", "Land facility", "-------", "Weapon", "Satellite" });
		((Control)CB_TargetType).Location = new Point(107, 40);
		((Control)CB_TargetType).Name = "CB_TargetType";
		((Control)CB_TargetType).Size = new Size(571, 21);
		((Control)CB_TargetType).TabIndex = 12;
		((Control)Check_ExistingTypes).Anchor = (AnchorStyles)4;
		((Control)Check_ExistingTypes).Location = new Point(107, 133);
		((Control)Check_ExistingTypes).Name = "Check_ExistingTypes";
		((Control)Check_ExistingTypes).Size = new Size(337, 17);
		((Control)Check_ExistingTypes).TabIndex = 17;
		((ButtonBase)Check_ExistingTypes).Text = "Limit subtypes and classes to those present in this scenario";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(704, 201);
		((Control)this).Controls.Add((Control)(object)Check_ExistingTypes);
		((Control)this).Controls.Add((Control)(object)Button_Cancel);
		((Control)this).Controls.Add((Control)(object)Button_OK);
		((Control)this).Controls.Add((Control)(object)CB_TargetUnitClass);
		((Control)this).Controls.Add((Control)(object)CB_TargetSubtype);
		((Control)this).Controls.Add((Control)(object)CB_TargetType);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(480, 240);
		((Control)this).Name = "PriorityTargetForm";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Add Priority Target Entry";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void PriorityTargetForm_Load()
	{
		if (ParentDoctrine == null)
		{
			((Form)this).Close();
			return;
		}
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit && Client.CurrentGame.GameMode != Game._GameMode.MultiplayerScenEdit)
		{
			((Control)Check_ExistingTypes).Visible = false;
			bool_2 = false;
		}
		else
		{
			((Control)Check_ExistingTypes).Visible = true;
		}
		((CheckBox)Check_ExistingTypes).Checked = bool_2;
		RefreshForm();
	}

	private void method_2()
	{
		Doctrine.PriorityTargetEntry.PopulateUnitTypeList((ComboBox)(object)CB_TargetType);
		((ComboBox)CB_TargetType).SelectedIndex = 0;
	}

	private GlobalVariables.ActiveUnitType method_3()
	{
		int result;
		if (((ComboBox)CB_TargetType).SelectedIndex < 0)
		{
			result = 0;
		}
		else
		{
			if (((ComboBox)CB_TargetType).DataSource != null)
			{
				return (GlobalVariables.ActiveUnitType)Conversions.ToByte(((DataTable)((ComboBox)CB_TargetType).DataSource).Rows[((ComboBox)CB_TargetType).SelectedIndex][0]);
			}
			result = 0;
		}
		return (GlobalVariables.ActiveUnitType)result;
	}

	private int method_4()
	{
		int result;
		if (((ComboBox)CB_TargetSubtype).SelectedIndex < 0)
		{
			result = 0;
		}
		else
		{
			if (((ComboBox)CB_TargetSubtype).DataSource != null)
			{
				return Conversions.ToInteger(((DataTable)((ComboBox)CB_TargetSubtype).DataSource).Rows[((ComboBox)CB_TargetSubtype).SelectedIndex][0]);
			}
			result = 0;
		}
		return result;
	}

	private int method_5()
	{
		if (((ComboBox)CB_TargetUnitClass).SelectedIndex > 0 && ((ComboBox)CB_TargetUnitClass).DataSource != null)
		{
			return Conversions.ToInteger(((DataTable)((ComboBox)CB_TargetUnitClass).DataSource).Rows[((ComboBox)CB_TargetUnitClass).SelectedIndex][0]);
		}
		return 0;
	}

	private void method_6()
	{
		GlobalVariables.ActiveUnitType theType = method_3();
		Doctrine.PriorityTargetEntry.PopulateUnitSubTypeList((ComboBox)(object)CB_TargetSubtype, theType, Client.CurrentScenario, ((CheckBox)Check_ExistingTypes).Checked);
		((ComboBox)CB_TargetSubtype).SelectedIndex = 0;
	}

	private void method_7()
	{
		GlobalVariables.ActiveUnitType theType = method_3();
		int theSubType = method_4();
		Doctrine.PriorityTargetEntry.PopulateDBIDList((ComboBox)(object)CB_TargetUnitClass, theType, theSubType, Client.CurrentScenario, ((CheckBox)Check_ExistingTypes).Checked);
		((ComboBox)CB_TargetUnitClass).SelectedIndex = 0;
	}

	public void RefreshForm()
	{
		method_2();
	}

	private void method_8(object sender, EventArgs e)
	{
		GlobalVariables.ActiveUnitType theType = method_3();
		int theSubType = method_4();
		int theDBID = method_5();
		ParentDoctrine.AddPriorityTargetListEntry(theType, theSubType, theDBID, InsertIndex);
		MainDoctrineForm.RefreshPriorityTargetList(ParentDoctrine, InsertIndex);
		((Form)this).Close();
	}

	private void method_9(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_10(object sender, EventArgs e)
	{
		method_6();
	}

	private void method_11(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_12(object sender, EventArgs e)
	{
	}

	private void method_13(object sender, EventArgs e)
	{
		if (((CheckBox)Check_ExistingTypes).Checked)
		{
			if (!bool_2)
			{
				bool_2 = true;
				RefreshForm();
			}
		}
		else if (bool_2)
		{
			bool_2 = false;
			RefreshForm();
		}
	}

	static PriorityTargetForm()
	{
		Class72.smethod_20();
	}
}

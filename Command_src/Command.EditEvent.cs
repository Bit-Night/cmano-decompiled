using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditEvent : DarkSecondaryFormBase
{
	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox _TextBox1;

	[AccessedThroughProperty("DGV_Triggers")]
	[CompilerGenerated]
	private DarkDataGridView _DGV_Triggers;

	[AccessedThroughProperty("DGV_Conditions")]
	[CompilerGenerated]
	private DarkDataGridView _DGV_Conditions;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_Actions")]
	private DarkDataGridView _DGV_Actions;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton _Button3;

	[AccessedThroughProperty("Button4")]
	[CompilerGenerated]
	private DarkUIButton _Button4;

	[AccessedThroughProperty("Button5")]
	[CompilerGenerated]
	private DarkUIButton _Button5;

	[CompilerGenerated]
	[AccessedThroughProperty("Button6")]
	private DarkUIButton _Button6;

	[CompilerGenerated]
	[AccessedThroughProperty("Button7")]
	private DarkUIButton _Button7;

	[CompilerGenerated]
	[AccessedThroughProperty("Button8")]
	private DarkUIButton _Button8;

	[AccessedThroughProperty("CheckBox_IsRepeatable")]
	[CompilerGenerated]
	private DarkCheckBox _CheckBox_IsRepeatable;

	[AccessedThroughProperty("CheckBox_IsActive")]
	[CompilerGenerated]
	private DarkCheckBox _CheckBox_IsActive;

	[AccessedThroughProperty("NUD_Probability")]
	[CompilerGenerated]
	private DarkUITextBox _NUD_Probability;

	[AccessedThroughProperty("Button_EditTriggers")]
	[CompilerGenerated]
	private DarkUIButton _Button_EditTriggers;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditActions")]
	private DarkUIButton _Button_EditActions;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditConditions")]
	private DarkUIButton _Button_EditConditions;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox_IsShown")]
	private DarkCheckBox _CheckBox_IsShown;

	private SimEvent simEvent_0;

	public _FormAction Action;

	internal virtual DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _TextBox1;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_12;
			DarkUITextBox darkUITextBox = _TextBox1;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TextBox1 = value;
			darkUITextBox = _TextBox1;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkDataGridView DGV_Triggers
	{
		[CompilerGenerated]
		get
		{
			return _DGV_Triggers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkDataGridView darkDataGridView = _DGV_Triggers;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).DoubleClick -= eventHandler;
			}
			_DGV_Triggers = value;
			darkDataGridView = _DGV_Triggers;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual DarkDataGridView DGV_Conditions
	{
		[CompilerGenerated]
		get
		{
			return _DGV_Conditions;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkDataGridView darkDataGridView = _DGV_Conditions;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).DoubleClick -= eventHandler;
			}
			_DGV_Conditions = value;
			darkDataGridView = _DGV_Conditions;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).DoubleClick += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	internal virtual DarkDataGridView DGV_Actions
	{
		[CompilerGenerated]
		get
		{
			return _DGV_Actions;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkDataGridView darkDataGridView = _DGV_Actions;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).DoubleClick -= eventHandler;
			}
			_DGV_Actions = value;
			darkDataGridView = _DGV_Actions;
			if (darkDataGridView != null)
			{
				((Control)darkDataGridView).DoubleClick += eventHandler;
			}
		}
	}

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

	[field: AccessedThroughProperty("CB_Triggers")]
	internal virtual DarkUIComboBox CB_Triggers { get; set; }

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
			EventHandler eventHandler = method_8;
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
			EventHandler eventHandler = method_13;
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

	[field: AccessedThroughProperty("CB_Conditions")]
	internal virtual DarkUIComboBox CB_Conditions { get; set; }

	internal virtual DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return _Button4;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIButton darkUIButton = _Button4;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button4 = value;
			darkUIButton = _Button4;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button5
	{
		[CompilerGenerated]
		get
		{
			return _Button5;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _Button5;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button5 = value;
			darkUIButton = _Button5;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_Actions")]
	internal virtual DarkUIComboBox CB_Actions { get; set; }

	internal virtual DarkUIButton Button6
	{
		[CompilerGenerated]
		get
		{
			return _Button6;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button6;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button6 = value;
			darkUIButton = _Button6;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button7
	{
		[CompilerGenerated]
		get
		{
			return _Button7;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _Button7;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button7 = value;
			darkUIButton = _Button7;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button8
	{
		[CompilerGenerated]
		get
		{
			return _Button8;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIButton darkUIButton = _Button8;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button8 = value;
			darkUIButton = _Button8;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CheckBox_IsRepeatable
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox_IsRepeatable;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkCheckBox darkCheckBox = _CheckBox_IsRepeatable;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CheckBox_IsRepeatable = value;
			darkCheckBox = _CheckBox_IsRepeatable;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CheckBox_IsActive
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox_IsActive;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkCheckBox darkCheckBox = _CheckBox_IsActive;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CheckBox_IsActive = value;
			darkCheckBox = _CheckBox_IsActive;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	internal virtual DarkUITextBox NUD_Probability
	{
		[CompilerGenerated]
		get
		{
			return _NUD_Probability;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUITextBox darkUITextBox = _NUD_Probability;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave -= eventHandler;
			}
			_NUD_Probability = value;
			darkUITextBox = _NUD_Probability;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_EditTriggers
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditTriggers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIButton darkUIButton = _Button_EditTriggers;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditTriggers = value;
			darkUIButton = _Button_EditTriggers;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_EditActions
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditActions;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _Button_EditActions;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditActions = value;
			darkUIButton = _Button_EditActions;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_EditConditions
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditConditions;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUIButton darkUIButton = _Button_EditConditions;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditConditions = value;
			darkUIButton = _Button_EditConditions;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CheckBox_IsShown
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox_IsShown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkCheckBox darkCheckBox = _CheckBox_IsShown;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CheckBox_IsShown = value;
			darkCheckBox = _CheckBox_IsShown;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("Description")]
	internal virtual DataGridViewTextBoxColumn Description { get; set; }

	[field: AccessedThroughProperty("DGV_Trigger_Type")]
	internal virtual DataGridViewTextBoxColumn DGV_Trigger_Type { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2 { get; set; }

	[field: AccessedThroughProperty("DGV_Condition_Type")]
	internal virtual DataGridViewTextBoxColumn DGV_Condition_Type { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn3 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn4 { get; set; }

	[field: AccessedThroughProperty("DGV_Action_Type")]
	internal virtual DataGridViewTextBoxColumn DGV_Action_Type { get; set; }

	public SimEvent theEvent
	{
		get
		{
			return simEvent_0;
		}
		set
		{
			simEvent_0 = value;
			TextBox1.Text = theEvent.Description;
			method_2();
			RefreshCombos();
			((CheckBox)CheckBox_IsRepeatable).Checked = simEvent_0.IsRepeatable;
			((CheckBox)CheckBox_IsActive).Checked = simEvent_0.IsActive;
			((CheckBox)CheckBox_IsShown).Checked = simEvent_0.IsShown;
			NUD_Probability.Text = Conversions.ToString((int)simEvent_0.Probability);
		}
	}

	public EditEvent()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(EditEvent_FormClosing);
		((Form)this).Load += EditEvent_Load;
		((Control)this).KeyDown += new KeyEventHandler(EditEvent_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(EditEvent_FormClosed);
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
		//IL_0019: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected O, but got Unknown
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected O, but got Unknown
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Expected O, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Expected O, but got Unknown
		//IL_0b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8d: Expected O, but got Unknown
		//IL_0c7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c86: Expected O, but got Unknown
		//IL_0d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d42: Expected O, but got Unknown
		//IL_0faa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb4: Expected O, but got Unknown
		//IL_1056: Unknown result type (might be due to invalid IL or missing references)
		//IL_1060: Expected O, but got Unknown
		//IL_110b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1115: Expected O, but got Unknown
		//IL_1198: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a2: Expected O, but got Unknown
		//IL_1248: Unknown result type (might be due to invalid IL or missing references)
		//IL_1252: Expected O, but got Unknown
		//IL_1304: Unknown result type (might be due to invalid IL or missing references)
		//IL_130e: Expected O, but got Unknown
		//IL_1391: Unknown result type (might be due to invalid IL or missing references)
		//IL_139b: Expected O, but got Unknown
		//IL_143a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1444: Expected O, but got Unknown
		//IL_14f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1500: Expected O, but got Unknown
		//IL_1583: Unknown result type (might be due to invalid IL or missing references)
		//IL_158d: Expected O, but got Unknown
		//IL_162c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1636: Expected O, but got Unknown
		//IL_16d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e3: Expected O, but got Unknown
		//IL_18d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e3: Expected O, but got Unknown
		//IL_1a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0c: Expected O, but got Unknown
		//IL_1aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab9: Expected O, but got Unknown
		//IL_1b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b66: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		TextBox1 = new DarkUITextBox();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		DGV_Triggers = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		DGV_Trigger_Type = new DataGridViewTextBoxColumn();
		DGV_Conditions = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DGV_Condition_Type = new DataGridViewTextBoxColumn();
		Label3 = new DarkLabel();
		DGV_Actions = new DarkDataGridView();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		DGV_Action_Type = new DataGridViewTextBoxColumn();
		Label4 = new DarkLabel();
		Button1 = new DarkUIButton();
		CB_Triggers = new DarkUIComboBox();
		Button2 = new DarkUIButton();
		Button3 = new DarkUIButton();
		CB_Conditions = new DarkUIComboBox();
		Button4 = new DarkUIButton();
		Button5 = new DarkUIButton();
		CB_Actions = new DarkUIComboBox();
		Button6 = new DarkUIButton();
		Button7 = new DarkUIButton();
		Button8 = new DarkUIButton();
		CheckBox_IsRepeatable = new DarkCheckBox();
		CheckBox_IsActive = new DarkCheckBox();
		Label5 = new DarkLabel();
		NUD_Probability = new DarkUITextBox();
		Button_EditTriggers = new DarkUIButton();
		Button_EditActions = new DarkUIButton();
		Button_EditConditions = new DarkUIButton();
		CheckBox_IsShown = new DarkCheckBox();
		((ISupportInitialize)(object)DGV_Triggers).BeginInit();
		((ISupportInitialize)(object)DGV_Conditions).BeginInit();
		((ISupportInitialize)(object)DGV_Actions).BeginInit();
		((Control)this).SuspendLayout();
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(91, 3);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(691, 20);
		((Control)TextBox1).TabIndex = 8;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(5, 7);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(69, 13);
		((Control)Label2).TabIndex = 7;
		((Label)Label2).Text = "Description:";
		Label1.AutoSize = true;
		((Control)Label1).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(5, 67);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(51, 13);
		((Control)Label1).TabIndex = 9;
		((Label)Label1).Text = "Triggers:";
		((DataGridView)DGV_Triggers).AllowUserToAddRows = false;
		((DataGridView)DGV_Triggers).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Triggers).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Triggers).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_Triggers).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Triggers).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Triggers).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_Triggers).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_Triggers).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)Description,
			(DataGridViewColumn)DGV_Trigger_Type
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Triggers).DefaultCellStyle = val2;
		((DataGridView)DGV_Triggers).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_Triggers).EnableHeadersVisualStyles = false;
		((Control)DGV_Triggers).Location = new Point(8, 83);
		((DataGridView)DGV_Triggers).MultiSelect = false;
		((Control)DGV_Triggers).Name = "DGV_Triggers";
		((DataGridView)DGV_Triggers).ReadOnly = true;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Triggers).RowsDefaultCellStyle = val3;
		((DataGridView)DGV_Triggers).SelectionMode = (DataGridViewSelectionMode)1;
		((DataGridView)DGV_Triggers).ShowCellToolTips = false;
		((DataGridView)DGV_Triggers).ShowEditingIcon = false;
		((DataGridView)DGV_Triggers).ShowRowErrors = false;
		((Control)DGV_Triggers).Size = new Size(766, 100);
		((Control)DGV_Triggers).TabIndex = 10;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)ID).Width = 10;
		((DataGridViewColumn)Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Description).DataPropertyName = "Description";
		((DataGridViewColumn)Description).HeaderText = "Description";
		((DataGridViewColumn)Description).Name = "Description";
		((DataGridViewColumn)Description).ReadOnly = true;
		((DataGridViewColumn)DGV_Trigger_Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)10;
		((DataGridViewColumn)DGV_Trigger_Type).DataPropertyName = "Type";
		((DataGridViewColumn)DGV_Trigger_Type).HeaderText = "Type";
		((DataGridViewColumn)DGV_Trigger_Type).MinimumWidth = 50;
		((DataGridViewColumn)DGV_Trigger_Type).Name = "DGV_Trigger_Type";
		((DataGridViewColumn)DGV_Trigger_Type).ReadOnly = true;
		((DataGridViewColumn)DGV_Trigger_Type).Width = 54;
		((DataGridView)DGV_Conditions).AllowUserToAddRows = false;
		((DataGridView)DGV_Conditions).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Conditions).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Conditions).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_Conditions).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Conditions).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Conditions).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_Conditions).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_Conditions).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)DataGridViewTextBoxColumn1,
			(DataGridViewColumn)DataGridViewTextBoxColumn2,
			(DataGridViewColumn)DGV_Condition_Type
		});
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Conditions).DefaultCellStyle = val5;
		((DataGridView)DGV_Conditions).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_Conditions).EnableHeadersVisualStyles = false;
		((Control)DGV_Conditions).Location = new Point(8, 241);
		((DataGridView)DGV_Conditions).MultiSelect = false;
		((Control)DGV_Conditions).Name = "DGV_Conditions";
		((DataGridView)DGV_Conditions).ReadOnly = true;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Conditions).RowsDefaultCellStyle = val6;
		((DataGridView)DGV_Conditions).SelectionMode = (DataGridViewSelectionMode)1;
		((DataGridView)DGV_Conditions).ShowCellToolTips = false;
		((DataGridView)DGV_Conditions).ShowEditingIcon = false;
		((DataGridView)DGV_Conditions).ShowRowErrors = false;
		((Control)DGV_Conditions).Size = new Size(766, 100);
		((Control)DGV_Conditions).TabIndex = 12;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).DataPropertyName = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Visible = false;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Width = 10;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).DataPropertyName = "Description";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).HeaderText = "Description";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Name = "DataGridViewTextBoxColumn2";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)DGV_Condition_Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)10;
		((DataGridViewColumn)DGV_Condition_Type).DataPropertyName = "Type";
		((DataGridViewColumn)DGV_Condition_Type).HeaderText = "Type";
		((DataGridViewColumn)DGV_Condition_Type).MinimumWidth = 50;
		((DataGridViewColumn)DGV_Condition_Type).Name = "DGV_Condition_Type";
		((DataGridViewColumn)DGV_Condition_Type).ReadOnly = true;
		((DataGridViewColumn)DGV_Condition_Type).Width = 54;
		Label3.AutoSize = true;
		((Control)Label3).Enabled = false;
		((Control)Label3).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(5, 225);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(67, 13);
		((Control)Label3).TabIndex = 11;
		((Label)Label3).Text = "Conditions:";
		((DataGridView)DGV_Actions).AllowUserToAddRows = false;
		((DataGridView)DGV_Actions).AllowUserToDeleteRows = false;
		((DataGridView)DGV_Actions).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_Actions).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_Actions).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_Actions).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = Color.FromArgb(66, 77, 95);
		val7.Font = new Font("Segoe UI", 9f);
		val7.ForeColor = Color.LightGray;
		val7.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val7.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val7.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_Actions).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_Actions).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_Actions).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)DataGridViewTextBoxColumn3,
			(DataGridViewColumn)DataGridViewTextBoxColumn4,
			(DataGridViewColumn)DGV_Action_Type
		});
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = Color.FromArgb(60, 63, 65);
		val8.Font = new Font("Segoe UI", 9f);
		val8.ForeColor = Color.LightGray;
		val8.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val8.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_Actions).DefaultCellStyle = val8;
		((DataGridView)DGV_Actions).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_Actions).EnableHeadersVisualStyles = false;
		((Control)DGV_Actions).Location = new Point(8, 399);
		((DataGridView)DGV_Actions).MultiSelect = false;
		((Control)DGV_Actions).Name = "DGV_Actions";
		((DataGridView)DGV_Actions).ReadOnly = true;
		val9.BackColor = Color.FromArgb(60, 63, 65);
		val9.ForeColor = Color.LightGray;
		val9.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val9.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_Actions).RowsDefaultCellStyle = val9;
		((DataGridView)DGV_Actions).SelectionMode = (DataGridViewSelectionMode)1;
		((DataGridView)DGV_Actions).ShowCellToolTips = false;
		((DataGridView)DGV_Actions).ShowEditingIcon = false;
		((DataGridView)DGV_Actions).ShowRowErrors = false;
		((Control)DGV_Actions).Size = new Size(766, 100);
		((Control)DGV_Actions).TabIndex = 14;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).DataPropertyName = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).HeaderText = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Name = "DataGridViewTextBoxColumn3";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Visible = false;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Width = 10;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).DataPropertyName = "Description";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).HeaderText = "Description";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Name = "DataGridViewTextBoxColumn4";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).ReadOnly = true;
		((DataGridViewColumn)DGV_Action_Type).AutoSizeMode = (DataGridViewAutoSizeColumnMode)10;
		((DataGridViewColumn)DGV_Action_Type).DataPropertyName = "Type";
		((DataGridViewColumn)DGV_Action_Type).HeaderText = "Type";
		((DataGridViewColumn)DGV_Action_Type).MinimumWidth = 50;
		((DataGridViewColumn)DGV_Action_Type).Name = "DGV_Action_Type";
		((DataGridViewColumn)DGV_Action_Type).ReadOnly = true;
		((DataGridViewColumn)DGV_Action_Type).Width = 54;
		Label4.AutoSize = true;
		((Control)Label4).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(5, 383);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(49, 13);
		((Control)Label4).TabIndex = 13;
		((Label)Label4).Text = "Actions:";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 9f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(8, 190);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(93, 21);
		((Control)Button1).TabIndex = 15;
		Button1.Text = "Add trigger:";
		((ComboBox)CB_Triggers).BackColor = Color.Transparent;
		((ComboBox)CB_Triggers).DrawMode = (DrawMode)1;
		((ComboBox)CB_Triggers).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Triggers).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Triggers).FormattingEnabled = true;
		((Control)CB_Triggers).Location = new Point(107, 189);
		((Control)CB_Triggers).Name = "CB_Triggers";
		((Control)CB_Triggers).Size = new Size(424, 21);
		((Control)CB_Triggers).TabIndex = 16;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 9f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(638, 190);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(144, 21);
		((Control)Button2).TabIndex = 17;
		Button2.Text = "Remove selected";
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Button)Button3).DialogResult = (DialogResult)0;
		((Control)Button3).Font = new Font("Segoe UI", 9f);
		((Control)Button3).ForeColor = SystemColors.Control;
		((Control)Button3).Location = new Point(638, 348);
		((Control)Button3).Name = "Button3";
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(144, 21);
		((Control)Button3).TabIndex = 20;
		Button3.Text = "Remove selected";
		((ComboBox)CB_Conditions).BackColor = Color.Transparent;
		((ComboBox)CB_Conditions).DrawMode = (DrawMode)1;
		((ComboBox)CB_Conditions).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Conditions).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Conditions).FormattingEnabled = true;
		((Control)CB_Conditions).Location = new Point(107, 348);
		((Control)CB_Conditions).Name = "CB_Conditions";
		((Control)CB_Conditions).Size = new Size(424, 21);
		((Control)CB_Conditions).TabIndex = 19;
		((ButtonBase)Button4).BackColor = Color.Transparent;
		((Button)Button4).DialogResult = (DialogResult)0;
		((Control)Button4).Font = new Font("Segoe UI", 9f);
		((Control)Button4).ForeColor = SystemColors.Control;
		((Control)Button4).Location = new Point(8, 348);
		((Control)Button4).Name = "Button4";
		Button4.RoundRadius = 0;
		((Control)Button4).Size = new Size(93, 21);
		((Control)Button4).TabIndex = 18;
		Button4.Text = "Add condition:";
		((ButtonBase)Button5).BackColor = Color.Transparent;
		((Button)Button5).DialogResult = (DialogResult)0;
		((Control)Button5).Font = new Font("Segoe UI", 9f);
		((Control)Button5).ForeColor = SystemColors.Control;
		((Control)Button5).Location = new Point(638, 506);
		((Control)Button5).Name = "Button5";
		Button5.RoundRadius = 0;
		((Control)Button5).Size = new Size(144, 21);
		((Control)Button5).TabIndex = 23;
		Button5.Text = "Remove selected";
		((ComboBox)CB_Actions).BackColor = Color.Transparent;
		((ComboBox)CB_Actions).DrawMode = (DrawMode)1;
		((ComboBox)CB_Actions).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Actions).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Actions).FormattingEnabled = true;
		((Control)CB_Actions).Location = new Point(107, 506);
		((Control)CB_Actions).Name = "CB_Actions";
		((Control)CB_Actions).Size = new Size(424, 21);
		((Control)CB_Actions).TabIndex = 22;
		((ButtonBase)Button6).BackColor = Color.Transparent;
		((Button)Button6).DialogResult = (DialogResult)0;
		((Control)Button6).Font = new Font("Segoe UI", 9f);
		((Control)Button6).ForeColor = SystemColors.Control;
		((Control)Button6).Location = new Point(8, 506);
		((Control)Button6).Name = "Button6";
		Button6.RoundRadius = 0;
		((Control)Button6).Size = new Size(93, 21);
		((Control)Button6).TabIndex = 21;
		Button6.Text = "Add action:";
		((ButtonBase)Button7).BackColor = Color.Transparent;
		((Button)Button7).DialogResult = (DialogResult)0;
		((Control)Button7).Font = new Font("Segoe UI", 10f);
		((Control)Button7).ForeColor = SystemColors.Control;
		((Control)Button7).Location = new Point(707, 556);
		((Control)Button7).Name = "Button7";
		Button7.RoundRadius = 0;
		((Control)Button7).Size = new Size(75, 23);
		((Control)Button7).TabIndex = 25;
		Button7.Text = "Cancel";
		((ButtonBase)Button8).BackColor = Color.Transparent;
		((Button)Button8).DialogResult = (DialogResult)0;
		((Control)Button8).Font = new Font("Segoe UI", 10f);
		((Control)Button8).ForeColor = SystemColors.Control;
		((Control)Button8).Location = new Point(8, 556);
		((Control)Button8).Name = "Button8";
		Button8.RoundRadius = 0;
		((Control)Button8).Size = new Size(75, 23);
		((Control)Button8).TabIndex = 24;
		Button8.Text = "OK";
		((ButtonBase)CheckBox_IsRepeatable).AutoSize = true;
		((Control)CheckBox_IsRepeatable).Location = new Point(8, 39);
		((Control)CheckBox_IsRepeatable).Name = "CheckBox_IsRepeatable";
		((Control)CheckBox_IsRepeatable).Size = new Size(124, 19);
		((Control)CheckBox_IsRepeatable).TabIndex = 26;
		((ButtonBase)CheckBox_IsRepeatable).Text = "Event is repeatable";
		((ButtonBase)CheckBox_IsActive).AutoSize = true;
		((Control)CheckBox_IsActive).Location = new Point(131, 39);
		((Control)CheckBox_IsActive).Name = "CheckBox_IsActive";
		((Control)CheckBox_IsActive).Size = new Size(100, 19);
		((Control)CheckBox_IsActive).TabIndex = 27;
		((ButtonBase)CheckBox_IsActive).Text = "Event is active";
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(456, 43);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(75, 13);
		((Control)Label5).TabIndex = 28;
		((Label)Label5).Text = "Probability (%):";
		NUD_Probability.AutoCompleteCustomSource = null;
		NUD_Probability.AutoCompleteMode = (AutoCompleteMode)0;
		NUD_Probability.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)NUD_Probability).BackColor = Color.Transparent;
		NUD_Probability.Font = new Font("Segoe UI", 10f);
		((Control)NUD_Probability).ForeColor = Color.FromArgb(189, 189, 189);
		NUD_Probability.Image = null;
		NUD_Probability.Lines = null;
		((Control)NUD_Probability).Location = new Point(532, 37);
		NUD_Probability.MaxLength = 3;
		NUD_Probability.Multiline = false;
		((Control)NUD_Probability).Name = "NUD_Probability";
		NUD_Probability.ReadOnly = false;
		NUD_Probability.ScrollBars = (ScrollBars)0;
		NUD_Probability.SelectionStart = 0;
		((Control)NUD_Probability).Size = new Size(53, 26);
		((Control)NUD_Probability).TabIndex = 29;
		NUD_Probability.Text = "100";
		NUD_Probability.TextAlign = (HorizontalAlignment)0;
		NUD_Probability.UseSystemPasswordChar = false;
		NUD_Probability.WatermarkText = "";
		((ButtonBase)Button_EditTriggers).BackColor = Color.Transparent;
		((Button)Button_EditTriggers).DialogResult = (DialogResult)0;
		((Control)Button_EditTriggers).Font = new Font("Segoe UI", 9f);
		((Control)Button_EditTriggers).ForeColor = SystemColors.Control;
		((Control)Button_EditTriggers).Location = new Point(537, 190);
		((Control)Button_EditTriggers).Name = "Button_EditTriggers";
		Button_EditTriggers.RoundRadius = 0;
		((Control)Button_EditTriggers).Size = new Size(93, 21);
		((Control)Button_EditTriggers).TabIndex = 30;
		Button_EditTriggers.Text = "Edit triggers";
		((ButtonBase)Button_EditActions).BackColor = Color.Transparent;
		((Button)Button_EditActions).DialogResult = (DialogResult)0;
		((Control)Button_EditActions).Font = new Font("Segoe UI", 9f);
		((Control)Button_EditActions).ForeColor = SystemColors.Control;
		((Control)Button_EditActions).Location = new Point(537, 506);
		((Control)Button_EditActions).Name = "Button_EditActions";
		Button_EditActions.RoundRadius = 0;
		((Control)Button_EditActions).Size = new Size(95, 21);
		((Control)Button_EditActions).TabIndex = 31;
		Button_EditActions.Text = "Edit actions";
		((ButtonBase)Button_EditConditions).BackColor = Color.Transparent;
		((Button)Button_EditConditions).DialogResult = (DialogResult)0;
		((Control)Button_EditConditions).Font = new Font("Segoe UI", 9f);
		((Control)Button_EditConditions).ForeColor = SystemColors.Control;
		((Control)Button_EditConditions).Location = new Point(537, 348);
		((Control)Button_EditConditions).Name = "Button_EditConditions";
		Button_EditConditions.RoundRadius = 0;
		((Control)Button_EditConditions).Size = new Size(95, 21);
		((Control)Button_EditConditions).TabIndex = 32;
		Button_EditConditions.Text = "Edit conditions";
		((ButtonBase)CheckBox_IsShown).AutoSize = true;
		((Control)CheckBox_IsShown).Location = new Point(233, 39);
		((Control)CheckBox_IsShown).Name = "CheckBox_IsShown";
		((Control)CheckBox_IsShown).Size = new Size(140, 19);
		((Control)CheckBox_IsShown).TabIndex = 33;
		((ButtonBase)CheckBox_IsShown).Text = "Event is shown in Log";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(786, 580);
		((Control)this).Controls.Add((Control)(object)CheckBox_IsShown);
		((Control)this).Controls.Add((Control)(object)Button_EditConditions);
		((Control)this).Controls.Add((Control)(object)Button_EditActions);
		((Control)this).Controls.Add((Control)(object)Button_EditTriggers);
		((Control)this).Controls.Add((Control)(object)NUD_Probability);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)CheckBox_IsActive);
		((Control)this).Controls.Add((Control)(object)CheckBox_IsRepeatable);
		((Control)this).Controls.Add((Control)(object)Button7);
		((Control)this).Controls.Add((Control)(object)Button8);
		((Control)this).Controls.Add((Control)(object)Button5);
		((Control)this).Controls.Add((Control)(object)CB_Actions);
		((Control)this).Controls.Add((Control)(object)Button6);
		((Control)this).Controls.Add((Control)(object)Button3);
		((Control)this).Controls.Add((Control)(object)CB_Conditions);
		((Control)this).Controls.Add((Control)(object)Button4);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)CB_Triggers);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)DGV_Actions);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)DGV_Conditions);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)DGV_Triggers);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditEvent";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit Event";
		((ISupportInitialize)(object)DGV_Triggers).EndInit();
		((ISupportInitialize)(object)DGV_Conditions).EndInit();
		((ISupportInitialize)(object)DGV_Actions).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			simEvent_0 = null;
			((ComboBox)CB_Triggers).Items.Clear();
			((ComboBox)CB_Conditions).Items.Clear();
			((ComboBox)CB_Actions).Items.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void EditEvent_FormClosing(object sender, FormClosingEventArgs e)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (Action == _FormAction.EditExisting)
		{
			if (theEvent.Triggers.Count == 0)
			{
				DarkMessageBox.ShowError("The event should have at least one trigger assigned.", "No trigger assigned!");
				((CancelEventArgs)(object)e).Cancel = true;
				return;
			}
			if (theEvent.Actions.Count == 0)
			{
				DarkMessageBox.ShowError("The event should have at least one actions assigned.", "No actions assigned!");
				((CancelEventArgs)(object)e).Cancel = true;
				return;
			}
		}
		method_18(RuntimeHelpers.GetObjectValue(sender), (EventArgs)(object)e);
		MyProject.Forms.ListEvents.RefreshGrid();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void EditEvent_Load(object sender, EventArgs e)
	{
		Scenario.EventTriggersChanged += HandleCollectionsChanged;
		Scenario.EventConditionsChanged += HandleCollectionsChanged;
		Scenario.EventActionsChanged += HandleCollectionsChanged;
		EditTrigger.EventTriggersChanged += HandleCollectionsChanged;
		EditCondition.EventConditionsChanged += HandleCollectionsChanged;
		EditAction.EventActionsChanged += HandleCollectionsChanged;
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (Information.IsNothing((object)theEvent))
		{
			((Form)this).Close();
		}
	}

	internal void HandleCollectionsChanged(Scenario theScen)
	{
		if (theScen == Client.CurrentScenario)
		{
			method_2();
			RefreshCombos();
		}
	}

	private void method_2()
	{
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		if (!((Control)DGV_Triggers).InvokeRequired)
		{
			((Control)DGV_Triggers).SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("Type", typeof(string));
			foreach (EventTrigger trigger in theEvent.Triggers)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = trigger.ObjectID;
				dataRow["Description"] = trigger.Description;
				dataRow["Type"] = trigger.Type.ToString();
				dataTable.Rows.Add(dataRow);
			}
			((DataGridView)DGV_Triggers).DataSource = dataTable;
			((Control)DGV_Triggers).ResumeLayout();
			((Control)DGV_Conditions).SuspendLayout();
			dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("Type", typeof(string));
			foreach (EventCondition condition in theEvent.Conditions)
			{
				DataRow dataRow2 = dataTable.NewRow();
				dataRow2["ID"] = condition.ObjectID;
				dataRow2["Description"] = condition.Description;
				dataRow2["Type"] = condition.Type.ToString();
				dataTable.Rows.Add(dataRow2);
			}
			((DataGridView)DGV_Conditions).DataSource = dataTable;
			((Control)DGV_Conditions).ResumeLayout();
			((Control)DGV_Actions).SuspendLayout();
			dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("Type", typeof(string));
			foreach (EventAction action in theEvent.Actions)
			{
				DataRow dataRow3 = dataTable.NewRow();
				dataRow3["ID"] = action.ObjectID;
				dataRow3["Description"] = action.Description;
				dataRow3["Type"] = action.Type.ToString();
				dataTable.Rows.Add(dataRow3);
			}
			((DataGridView)DGV_Actions).DataSource = dataTable;
			((Control)DGV_Actions).ResumeLayout();
		}
		else
		{
			((Control)DGV_Triggers).BeginInvoke((Delegate)new MethodInvoker(method_2));
		}
	}

	public void RefreshCombos()
	{
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		if (!((Control)CB_Triggers).InvokeRequired)
		{
			if (((Control)CB_Conditions).InvokeRequired)
			{
				((Control)CB_Conditions).BeginInvoke((Delegate)new MethodInvoker(RefreshCombos));
			}
			else if (!((Control)CB_Actions).InvokeRequired)
			{
				((ComboBox)CB_Triggers).Items.Clear();
				((ListControl)CB_Triggers).DisplayMember = "Content";
				List<object> list = new List<object>();
				foreach (EventTrigger item in Client.CurrentScenario.EventTriggers.Values.OrderBy([SpecialName] (EventTrigger theT) => theT.Description))
				{
					ComboBoxItem val = new ComboBoxItem();
					((ContentControl)val).Content = item.Description;
					((FrameworkElement)val).Tag = item;
					list.Add(val);
				}
				((ComboBox)CB_Triggers).Items.AddRange(list.ToArray());
				((ComboBox)CB_Conditions).Items.Clear();
				((ListControl)CB_Conditions).DisplayMember = "Content";
				List<object> list2 = new List<object>();
				foreach (EventCondition item2 in Client.CurrentScenario.EventConditions.Values.OrderBy([SpecialName] (EventCondition theT) => theT.Description))
				{
					ComboBoxItem val2 = new ComboBoxItem();
					((ContentControl)val2).Content = item2.Description;
					((FrameworkElement)val2).Tag = item2;
					list2.Add(val2);
				}
				((ComboBox)CB_Conditions).Items.AddRange(list2.ToArray());
				((ComboBox)CB_Actions).Items.Clear();
				((ListControl)CB_Actions).DisplayMember = "Content";
				List<object> list3 = new List<object>();
				foreach (EventAction item3 in Client.CurrentScenario.EventActions.Values.OrderBy([SpecialName] (EventAction theT) => theT.Description))
				{
					ComboBoxItem val3 = new ComboBoxItem();
					((ContentControl)val3).Content = item3.Description;
					((FrameworkElement)val3).Tag = item3;
					if (item3.Type != EventAction.EventActionType.LuaScript || ((EventAction_LuaScript)item3).ScriptForType == EventAction_LuaScript.EventAction_LuaScript_Type.EventAction)
					{
						list3.Add(val3);
					}
				}
				((ComboBox)CB_Actions).Items.AddRange(list3.ToArray());
			}
			else
			{
				((Control)CB_Actions).BeginInvoke((Delegate)new MethodInvoker(RefreshCombos));
			}
		}
		else
		{
			((Control)CB_Triggers).BeginInvoke((Delegate)new MethodInvoker(RefreshCombos));
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		theEvent.IsRepeatable = ((CheckBox)CheckBox_IsRepeatable).Checked;
	}

	private void method_4(object sender, EventArgs e)
	{
		theEvent.IsActive = ((CheckBox)CheckBox_IsActive).Checked;
	}

	private void method_5(object sender, EventArgs e)
	{
		theEvent.IsShown = ((CheckBox)CheckBox_IsShown).Checked;
	}

	private void method_6(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (((ComboBox)CB_Triggers).SelectedIndex < 0)
		{
			return;
		}
		EventTrigger eventTrigger = (EventTrigger)((FrameworkElement)(ComboBoxItem)((ComboBox)CB_Triggers).SelectedItem).Tag;
		if (!theEvent.Triggers.Contains(eventTrigger))
		{
			theEvent.Triggers.Add(eventTrigger);
			if (eventTrigger.Type == EventTrigger.EventTriggerType.UnitBaseStatus)
			{
				CMANO.LuaTriggers.AddOpsHandler();
			}
			method_2();
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (((ComboBox)CB_Actions).SelectedIndex >= 0)
		{
			EventAction item = (EventAction)((FrameworkElement)(ComboBoxItem)((ComboBox)CB_Actions).SelectedItem).Tag;
			if (!theEvent.Actions.Contains(item))
			{
				theEvent.Actions.Add(item);
				method_2();
			}
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Triggers).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DGV_Triggers).SelectedRows[0].Cells[0].Value);
			EventTrigger item = Client.CurrentScenario.EventTriggers[key];
			theEvent.Triggers.Remove(item);
			method_2();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Actions).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DGV_Actions).SelectedRows[0].Cells[0].Value);
			EventAction item = Client.CurrentScenario.EventActions[key];
			theEvent.Actions.Remove(item);
			method_2();
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		if (theEvent.Triggers.Count == 0)
		{
			DarkMessageBox.ShowError("The event should have at least one trigger assigned.", "No trigger assigned!");
		}
		else if (theEvent.Actions.Count != 0)
		{
			switch (Action)
			{
			case _FormAction.AddNew:
				Client.CurrentScenario.SimEvents.TryAdd(theEvent.ObjectID, theEvent);
				break;
			}
			((Form)this).Close();
		}
		else
		{
			DarkMessageBox.ShowError("The event should have at least one actions assigned.", "No actions assigned!");
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_12(object object_0)
	{
		theEvent.Description = TextBox1.Text;
	}

	private void method_13(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Conditions).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DGV_Conditions).SelectedRows[0].Cells[0].Value);
			EventCondition item = Client.CurrentScenario.EventConditions[key];
			theEvent.Conditions.Remove(item);
			method_2();
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.ListTriggers).Show();
	}

	private void method_15(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.ListActions).Show();
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (((ComboBox)CB_Conditions).SelectedIndex >= 0)
		{
			EventCondition item = (EventCondition)((FrameworkElement)(ComboBoxItem)((ComboBox)CB_Conditions).SelectedItem).Tag;
			if (!theEvent.Conditions.Contains(item))
			{
				theEvent.Conditions.Add(item);
				method_2();
			}
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.ListConditions).Show();
	}

	private void EditEvent_KeyDown(object sender, KeyEventArgs e)
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

	private void EditEvent_FormClosed(object sender, FormClosedEventArgs e)
	{
		Scenario.EventTriggersChanged -= HandleCollectionsChanged;
		Scenario.EventConditionsChanged -= HandleCollectionsChanged;
		Scenario.EventActionsChanged -= HandleCollectionsChanged;
		EditTrigger.EventTriggersChanged -= HandleCollectionsChanged;
		EditCondition.EventConditionsChanged -= HandleCollectionsChanged;
		EditAction.EventActionsChanged -= HandleCollectionsChanged;
	}

	private void method_18(object sender, EventArgs e)
	{
		if (theEvent != null)
		{
			if (Versioned.IsNumeric((object)NUD_Probability.Text) && Conversions.ToDouble(NUD_Probability.Text) > 1.0 && Conversions.ToDouble(NUD_Probability.Text) <= 100.0)
			{
				theEvent.Probability = Conversions.ToShort(NUD_Probability.Text);
			}
			else
			{
				NUD_Probability.Text = Conversions.ToString((int)theEvent.Probability);
			}
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Triggers).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DGV_Triggers).SelectedRows[0].Cells[0].Value);
			EventTrigger theTr = Client.CurrentScenario.EventTriggers[key];
			MyProject.Forms.ListTriggers.ShowEditTrigger(theTr);
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Conditions).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DGV_Conditions).SelectedRows[0].Cells[0].Value);
			EventCondition theEC = Client.CurrentScenario.EventConditions[key];
			MyProject.Forms.ListConditions.ShowEditTrigger(theEC);
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_Actions).SelectedRows).Count != 0)
		{
			string key = Conversions.ToString(((DataGridView)DGV_Actions).SelectedRows[0].Cells[0].Value);
			EventAction theEA = Client.CurrentScenario.EventActions[key];
			MyProject.Forms.ListActions.ShowEditTrigger(theEA);
		}
	}

	static EditEvent()
	{
		Class72.smethod_20();
	}
}

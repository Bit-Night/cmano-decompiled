using System;
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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class NewMission : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_Name")]
	private DarkUITextBox _TextBox_Name;

	[AccessedThroughProperty("CB_MissionClass")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_MissionClass;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton hteSurEjyTS;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Category")]
	private DarkUIComboBox _CB_Category;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Clear_ActivationTime")]
	private DarkUIButton _Button_Clear_ActivationTime;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_ActivationTime")]
	private DarkMaskedTextBox _DateTimePicker_ActivationTime;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_ActivationDate")]
	private DarkMaskedTextBox _DateTimePicker_ActivationDate;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox_DeleteMission")]
	private DarkCheckBox YihSuJrFslE;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Clear_DeactivationTime")]
	private DarkUIButton _Button_Clear_DeactivationTime;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_DeactivationTime")]
	private DarkMaskedTextBox _DateTimePicker_DeactivationTime;

	[AccessedThroughProperty("Label112")]
	[CompilerGenerated]
	private DarkLabel jOaSuUwNxuN;

	[AccessedThroughProperty("DateTimePicker_DeactivationDate")]
	[CompilerGenerated]
	private DarkMaskedTextBox _DateTimePicker_DeactivationDate;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_TakeOffTime")]
	private DarkMaskedTextBox _DateTimePicker_TakeOffTime;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_TakeOffDate")]
	private DarkMaskedTextBox _DateTimePicker_TakeOffDate;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_TimeOnTargetTime")]
	private DarkMaskedTextBox _DateTimePicker_TimeOnTargetTime;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_TimeOnTargetDate")]
	private DarkMaskedTextBox _DateTimePicker_TimeOnTargetDate;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Clear_TakeOffTime")]
	private DarkUIButton _Button_Clear_TakeOffTime;

	[AccessedThroughProperty("Button_Clear_TimeOnTarget")]
	[CompilerGenerated]
	private DarkUIButton _Button_Clear_TimeOnTarget;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_OpenMissionEditor")]
	private DarkCheckBox _CB_OpenMissionEditor;

	[CompilerGenerated]
	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private DateTime? nullable_0;

	private DateTime? nullable_1;

	private DateTime? nullable_2;

	private DateTime? nullable_3;

	private bool bool_8;

	private Keys[] keys_0;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUITextBox TextBox_Name
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_Name;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_2;
			DarkUITextBox darkUITextBox = _TextBox_Name;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TextBox_Name = value;
			darkUITextBox = _TextBox_Name;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUIComboBox CB_MissionClass
	{
		[CompilerGenerated]
		get
		{
			return _CB_MissionClass;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIComboBox darkUIComboBox = _CB_MissionClass;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_MissionClass = value;
			darkUIComboBox = _CB_MissionClass;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_MissionClass")]
	internal virtual DarkLabel Label_MissionClass { get; set; }

	[field: AccessedThroughProperty("Label_MissionType")]
	internal virtual DarkLabel Label_MissionType { get; set; }

	[field: AccessedThroughProperty("CB_MissionType")]
	internal virtual DarkUIComboBox CB_MissionType { get; set; }

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

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return hteSurEjyTS;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = hteSurEjyTS;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			hteSurEjyTS = value;
			darkUIButton = hteSurEjyTS;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_MissionStatus")]
	internal virtual DarkUIComboBox CB_MissionStatus { get; set; }

	[field: AccessedThroughProperty("Label_MissionStatus")]
	internal virtual DarkLabel Label_MissionStatus { get; set; }

	[field: AccessedThroughProperty("Label_Category")]
	internal virtual DarkLabel Label_Category { get; set; }

	internal virtual DarkUIComboBox CB_Category
	{
		[CompilerGenerated]
		get
		{
			return _CB_Category;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIComboBox darkUIComboBox = _CB_Category;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_Category = value;
			darkUIComboBox = _CB_Category;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("GroupBox_ActivationTime")]
	internal virtual DarkGroupBox GroupBox_ActivationTime { get; set; }

	internal virtual DarkUIButton Button_Clear_ActivationTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_Clear_ActivationTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_35;
			DarkUIButton darkUIButton = _Button_Clear_ActivationTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Clear_ActivationTime = value;
			darkUIButton = _Button_Clear_ActivationTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_ActivationTime
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_ActivationTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			EventHandler eventHandler2 = method_15;
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_ActivationTime;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
			}
			_DateTimePicker_ActivationTime = value;
			darkMaskedTextBox = _DateTimePicker_ActivationTime;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_ActivationDate
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_ActivationDate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			EventHandler eventHandler2 = method_13;
			EventHandler eventHandler3 = method_39;
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_ActivationDate;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).Leave -= eventHandler3;
			}
			_DateTimePicker_ActivationDate = value;
			darkMaskedTextBox = _DateTimePicker_ActivationDate;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).Leave += eventHandler3;
			}
		}
	}

	[field: AccessedThroughProperty("Label101")]
	internal virtual DarkLabel Label101 { get; set; }

	[field: AccessedThroughProperty("Label102")]
	internal virtual DarkLabel Label102 { get; set; }

	[field: AccessedThroughProperty("GroupBox_DeactivationTime")]
	internal virtual DarkGroupBox GroupBox_DeactivationTime { get; set; }

	internal virtual DarkCheckBox CheckBox_DeleteMission
	{
		[CompilerGenerated]
		get
		{
			return YihSuJrFslE;
		}
		[CompilerGenerated]
		set
		{
			YihSuJrFslE = value;
		}
	}

	[field: AccessedThroughProperty("CheckBox_OrderRTB")]
	internal virtual DarkCheckBox CheckBox_OrderRTB { get; set; }

	[field: AccessedThroughProperty("CheckBox_UnassignUnits")]
	internal virtual DarkCheckBox CheckBox_UnassignUnits { get; set; }

	internal virtual DarkUIButton Button_Clear_DeactivationTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_Clear_DeactivationTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_36;
			DarkUIButton darkUIButton = _Button_Clear_DeactivationTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Clear_DeactivationTime = value;
			darkUIButton = _Button_Clear_DeactivationTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_DeactivationTime
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_DeactivationTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			EventHandler eventHandler2 = method_19;
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_DeactivationTime;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
			}
			_DateTimePicker_DeactivationTime = value;
			darkMaskedTextBox = _DateTimePicker_DeactivationTime;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkLabel Label112
	{
		[CompilerGenerated]
		get
		{
			return jOaSuUwNxuN;
		}
		[CompilerGenerated]
		set
		{
			jOaSuUwNxuN = value;
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_DeactivationDate
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_DeactivationDate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			EventHandler eventHandler2 = method_17;
			EventHandler eventHandler3 = method_40;
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_DeactivationDate;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).Leave -= eventHandler3;
			}
			_DateTimePicker_DeactivationDate = value;
			darkMaskedTextBox = _DateTimePicker_DeactivationDate;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).Leave += eventHandler3;
			}
		}
	}

	[field: AccessedThroughProperty("Label114")]
	internal virtual DarkLabel Label114 { get; set; }

	[field: AccessedThroughProperty("GroupBox_TakeOffTime")]
	internal virtual DarkGroupBox GroupBox_TakeOffTime { get; set; }

	internal virtual DarkMaskedTextBox DateTimePicker_TakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_TakeOffTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			EventHandler eventHandler2 = fNsSujNuLfi;
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_TakeOffTime;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
			}
			_DateTimePicker_TakeOffTime = value;
			darkMaskedTextBox = _DateTimePicker_TakeOffTime;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_TakeOffDate
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_TakeOffDate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			EventHandler eventHandler2 = method_21;
			EventHandler eventHandler3 = method_41;
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_TakeOffDate;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).Leave -= eventHandler3;
			}
			_DateTimePicker_TakeOffDate = value;
			darkMaskedTextBox = _DateTimePicker_TakeOffDate;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).Leave += eventHandler3;
			}
		}
	}

	[field: AccessedThroughProperty("Label162")]
	internal virtual DarkLabel Label162 { get; set; }

	[field: AccessedThroughProperty("Label169")]
	internal virtual DarkLabel Label169 { get; set; }

	[field: AccessedThroughProperty("GroupBox_TimeOnTarget")]
	internal virtual DarkGroupBox GroupBox_TimeOnTarget { get; set; }

	internal virtual DarkMaskedTextBox DateTimePicker_TimeOnTargetTime
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_TimeOnTargetTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			EventHandler eventHandler2 = method_26;
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_TimeOnTargetTime;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
			}
			_DateTimePicker_TimeOnTargetTime = value;
			darkMaskedTextBox = _DateTimePicker_TimeOnTargetTime;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkMaskedTextBox DateTimePicker_TimeOnTargetDate
	{
		[CompilerGenerated]
		get
		{
			return _DateTimePicker_TimeOnTargetDate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			EventHandler eventHandler2 = method_24;
			EventHandler eventHandler3 = method_42;
			DarkMaskedTextBox darkMaskedTextBox = _DateTimePicker_TimeOnTargetDate;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter -= eventHandler;
				((Control)darkMaskedTextBox).Leave -= eventHandler2;
				((Control)darkMaskedTextBox).Leave -= eventHandler3;
			}
			_DateTimePicker_TimeOnTargetDate = value;
			darkMaskedTextBox = _DateTimePicker_TimeOnTargetDate;
			if (darkMaskedTextBox != null)
			{
				((Control)darkMaskedTextBox).Enter += eventHandler;
				((Control)darkMaskedTextBox).Leave += eventHandler2;
				((Control)darkMaskedTextBox).Leave += eventHandler3;
			}
		}
	}

	[field: AccessedThroughProperty("Label170")]
	internal virtual DarkLabel Label170 { get; set; }

	[field: AccessedThroughProperty("Label171")]
	internal virtual DarkLabel Label171 { get; set; }

	internal virtual DarkUIButton Button_Clear_TakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return _Button_Clear_TakeOffTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_37;
			DarkUIButton darkUIButton = _Button_Clear_TakeOffTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Clear_TakeOffTime = value;
			darkUIButton = _Button_Clear_TakeOffTime;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Clear_TimeOnTarget
	{
		[CompilerGenerated]
		get
		{
			return _Button_Clear_TimeOnTarget;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_38;
			DarkUIButton darkUIButton = _Button_Clear_TimeOnTarget;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Clear_TimeOnTarget = value;
			darkUIButton = _Button_Clear_TimeOnTarget;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_ParentPool")]
	internal virtual DarkUIComboBox CB_ParentPool { get; set; }

	[field: AccessedThroughProperty("Label_ParentPool")]
	internal virtual DarkLabel Label_ParentPool { get; set; }

	internal virtual DarkCheckBox CB_OpenMissionEditor
	{
		[CompilerGenerated]
		get
		{
			return _CB_OpenMissionEditor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkCheckBox darkCheckBox = _CB_OpenMissionEditor;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_OpenMissionEditor = value;
			darkCheckBox = _CB_OpenMissionEditor;
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
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
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
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ba: Expected O, but got Unknown
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_0643: Expected O, but got Unknown
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06eb: Expected O, but got Unknown
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Expected O, but got Unknown
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Expected O, but got Unknown
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c31: Expected O, but got Unknown
		//IL_1117: Unknown result type (might be due to invalid IL or missing references)
		//IL_1121: Expected O, but got Unknown
		//IL_14a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b2: Expected O, but got Unknown
		//IL_1836: Unknown result type (might be due to invalid IL or missing references)
		//IL_1840: Expected O, but got Unknown
		//IL_1ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ada: Expected O, but got Unknown
		Label1 = new DarkLabel();
		TextBox_Name = new DarkUITextBox();
		CB_MissionClass = new DarkUIComboBox();
		Label_MissionClass = new DarkLabel();
		Label_MissionType = new DarkLabel();
		CB_MissionType = new DarkUIComboBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		CB_OpenMissionEditor = new DarkCheckBox();
		CB_MissionStatus = new DarkUIComboBox();
		Label_MissionStatus = new DarkLabel();
		Label_Category = new DarkLabel();
		CB_Category = new DarkUIComboBox();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		GroupBox_ActivationTime = new DarkGroupBox();
		Button_Clear_ActivationTime = new DarkUIButton();
		DateTimePicker_ActivationTime = new DarkMaskedTextBox();
		DateTimePicker_ActivationDate = new DarkMaskedTextBox();
		Label101 = new DarkLabel();
		Label102 = new DarkLabel();
		GroupBox_DeactivationTime = new DarkGroupBox();
		CheckBox_DeleteMission = new DarkCheckBox();
		CheckBox_OrderRTB = new DarkCheckBox();
		CheckBox_UnassignUnits = new DarkCheckBox();
		Button_Clear_DeactivationTime = new DarkUIButton();
		DateTimePicker_DeactivationTime = new DarkMaskedTextBox();
		Label112 = new DarkLabel();
		DateTimePicker_DeactivationDate = new DarkMaskedTextBox();
		Label114 = new DarkLabel();
		GroupBox_TakeOffTime = new DarkGroupBox();
		Button_Clear_TakeOffTime = new DarkUIButton();
		DateTimePicker_TakeOffTime = new DarkMaskedTextBox();
		DateTimePicker_TakeOffDate = new DarkMaskedTextBox();
		Label162 = new DarkLabel();
		Label169 = new DarkLabel();
		GroupBox_TimeOnTarget = new DarkGroupBox();
		Button_Clear_TimeOnTarget = new DarkUIButton();
		DateTimePicker_TimeOnTargetTime = new DarkMaskedTextBox();
		DateTimePicker_TimeOnTargetDate = new DarkMaskedTextBox();
		Label170 = new DarkLabel();
		Label171 = new DarkLabel();
		CB_ParentPool = new DarkUIComboBox();
		Label_ParentPool = new DarkLabel();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)GroupBox_ActivationTime).SuspendLayout();
		((Control)GroupBox_DeactivationTime).SuspendLayout();
		((Control)GroupBox_TakeOffTime).SuspendLayout();
		((Control)GroupBox_TimeOnTarget).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(2, 42);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(56, 23);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Name:";
		((Control)TextBox_Name).Anchor = (AnchorStyles)13;
		TextBox_Name.AutoCompleteCustomSource = null;
		TextBox_Name.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_Name.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_Name).BackColor = Color.Transparent;
		TextBox_Name.Font = new Font("Segoe UI", 10f);
		((Control)TextBox_Name).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_Name.Image = null;
		TextBox_Name.Lines = null;
		((Control)TextBox_Name).Location = new Point(78, 38);
		TextBox_Name.MaxLength = 32767;
		TextBox_Name.Multiline = false;
		((Control)TextBox_Name).Name = "TextBox_Name";
		TextBox_Name.ReadOnly = false;
		TextBox_Name.ScrollBars = (ScrollBars)0;
		TextBox_Name.SelectionStart = 0;
		((Control)TextBox_Name).Size = new Size(266, 20);
		((Control)TextBox_Name).TabIndex = 1;
		TextBox_Name.TextAlign = (HorizontalAlignment)0;
		TextBox_Name.UseSystemPasswordChar = false;
		TextBox_Name.WatermarkText = "";
		((Control)CB_MissionClass).Anchor = (AnchorStyles)13;
		((ComboBox)CB_MissionClass).BackColor = Color.Transparent;
		((ComboBox)CB_MissionClass).DrawMode = (DrawMode)1;
		((ComboBox)CB_MissionClass).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MissionClass).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MissionClass).FormattingEnabled = true;
		((Control)CB_MissionClass).Location = new Point(78, 64);
		((Control)CB_MissionClass).Name = "CB_MissionClass";
		((Control)CB_MissionClass).Size = new Size(266, 21);
		((Control)CB_MissionClass).TabIndex = 2;
		Label_MissionClass.AutoSize = true;
		((Control)Label_MissionClass).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MissionClass).Location = new Point(2, 68);
		((Control)Label_MissionClass).Name = "Label_MissionClass";
		((Control)Label_MissionClass).Size = new Size(37, 15);
		((Control)Label_MissionClass).TabIndex = 3;
		((Label)Label_MissionClass).Text = "Class:";
		Label_MissionType.AutoSize = true;
		((Control)Label_MissionType).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MissionType).Location = new Point(1, 97);
		((Control)Label_MissionType).Name = "Label_MissionType";
		((Control)Label_MissionType).Size = new Size(34, 15);
		((Control)Label_MissionType).TabIndex = 4;
		((Label)Label_MissionType).Text = "Type:";
		((Control)CB_MissionType).Anchor = (AnchorStyles)13;
		((ComboBox)CB_MissionType).BackColor = Color.Transparent;
		((ComboBox)CB_MissionType).DrawMode = (DrawMode)1;
		((ComboBox)CB_MissionType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MissionType).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MissionType).FormattingEnabled = true;
		((Control)CB_MissionType).Location = new Point(78, 93);
		((Control)CB_MissionType).Name = "CB_MissionType";
		((Control)CB_MissionType).Size = new Size(266, 21);
		((Control)CB_MissionType).TabIndex = 5;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(5, 200);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 6;
		Button1.Text = "OK";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(461, 202);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 7;
		Button2.Text = "Cancel";
		((ButtonBase)CB_OpenMissionEditor).AutoSize = true;
		((Control)CB_OpenMissionEditor).Location = new Point(5, 179);
		((Control)CB_OpenMissionEditor).Name = "CB_OpenMissionEditor";
		((Control)CB_OpenMissionEditor).Size = new Size(178, 19);
		((Control)CB_OpenMissionEditor).TabIndex = 8;
		((ButtonBase)CB_OpenMissionEditor).Text = "Open Mission Editor window";
		((Control)CB_MissionStatus).Anchor = (AnchorStyles)13;
		((ComboBox)CB_MissionStatus).BackColor = Color.Transparent;
		((ComboBox)CB_MissionStatus).DrawMode = (DrawMode)1;
		((ComboBox)CB_MissionStatus).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MissionStatus).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MissionStatus).FormattingEnabled = true;
		((ComboBox)CB_MissionStatus).Items.AddRange(new object[2] { "Active", "Inactive" });
		((Control)CB_MissionStatus).Location = new Point(78, 123);
		((Control)CB_MissionStatus).Name = "CB_MissionStatus";
		((Control)CB_MissionStatus).Size = new Size(266, 21);
		((Control)CB_MissionStatus).TabIndex = 30;
		((Control)Label_MissionStatus).Anchor = (AnchorStyles)13;
		Label_MissionStatus.AutoSize = true;
		((Control)Label_MissionStatus).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MissionStatus).Location = new Point(1, 127);
		((Control)Label_MissionStatus).Name = "Label_MissionStatus";
		((Control)Label_MissionStatus).Size = new Size(42, 15);
		((Control)Label_MissionStatus).TabIndex = 29;
		((Label)Label_MissionStatus).Text = "Status:";
		Label_Category.AutoSize = true;
		((Control)Label_Category).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Category).Location = new Point(2, 12);
		((Control)Label_Category).Name = "Label_Category";
		((Control)Label_Category).Size = new Size(58, 15);
		((Control)Label_Category).TabIndex = 32;
		((Label)Label_Category).Text = "Category:";
		((Control)CB_Category).Anchor = (AnchorStyles)13;
		((ComboBox)CB_Category).BackColor = Color.Transparent;
		((ComboBox)CB_Category).DrawMode = (DrawMode)1;
		((ComboBox)CB_Category).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Category).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Category).FormattingEnabled = true;
		((Control)CB_Category).Location = new Point(78, 8);
		((Control)CB_Category).Name = "CB_Category";
		((Control)CB_Category).Size = new Size(266, 21);
		((Control)CB_Category).TabIndex = 31;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)GroupBox_ActivationTime);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)GroupBox_DeactivationTime);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)GroupBox_TakeOffTime);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)GroupBox_TimeOnTarget);
		((Control)FlowLayoutPanel1).Location = new Point(347, 8);
		((Control)FlowLayoutPanel1).Margin = new Padding(0);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(188, 195);
		((Control)FlowLayoutPanel1).TabIndex = 47;
		((Control)GroupBox_ActivationTime).Anchor = (AnchorStyles)13;
		((Control)GroupBox_ActivationTime).Controls.Add((Control)(object)Button_Clear_ActivationTime);
		((Control)GroupBox_ActivationTime).Controls.Add((Control)(object)DateTimePicker_ActivationTime);
		((Control)GroupBox_ActivationTime).Controls.Add((Control)(object)DateTimePicker_ActivationDate);
		((Control)GroupBox_ActivationTime).Controls.Add((Control)(object)Label101);
		((Control)GroupBox_ActivationTime).Controls.Add((Control)(object)Label102);
		((Control)GroupBox_ActivationTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_ActivationTime).Location = new Point(3, 3);
		((Control)GroupBox_ActivationTime).Name = "GroupBox_ActivationTime";
		((Control)GroupBox_ActivationTime).Size = new Size(183, 61);
		((Control)GroupBox_ActivationTime).TabIndex = 45;
		((GroupBox)GroupBox_ActivationTime).TabStop = false;
		((GroupBox)GroupBox_ActivationTime).Text = "Activation Time";
		((Control)Button_Clear_ActivationTime).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_Clear_ActivationTime).BackColor = Color.Transparent;
		((Button)Button_Clear_ActivationTime).DialogResult = (DialogResult)0;
		((Control)Button_Clear_ActivationTime).Font = new Font("Segoe UI", 10f);
		((Control)Button_Clear_ActivationTime).ForeColor = SystemColors.Control;
		((Control)Button_Clear_ActivationTime).Location = new Point(133, 14);
		((Control)Button_Clear_ActivationTime).Name = "Button_Clear_ActivationTime";
		Button_Clear_ActivationTime.RoundRadius = 0;
		((Control)Button_Clear_ActivationTime).Size = new Size(47, 22);
		((Control)Button_Clear_ActivationTime).TabIndex = 43;
		Button_Clear_ActivationTime.Text = "Clear";
		((Control)DateTimePicker_ActivationTime).Anchor = (AnchorStyles)13;
		((TextBoxBase)DateTimePicker_ActivationTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_ActivationTime).ForeColor = Color.DimGray;
		((Control)DateTimePicker_ActivationTime).Location = new Point(39, 36);
		((Control)DateTimePicker_ActivationTime).Name = "DateTimePicker_ActivationTime";
		((Control)DateTimePicker_ActivationTime).Size = new Size(88, 23);
		((Control)DateTimePicker_ActivationTime).TabIndex = 37;
		((Control)DateTimePicker_ActivationDate).Anchor = (AnchorStyles)13;
		((TextBoxBase)DateTimePicker_ActivationDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_ActivationDate).ForeColor = Color.DimGray;
		((Control)DateTimePicker_ActivationDate).Location = new Point(39, 15);
		((Control)DateTimePicker_ActivationDate).Name = "DateTimePicker_ActivationDate";
		((Control)DateTimePicker_ActivationDate).Size = new Size(88, 23);
		((Control)DateTimePicker_ActivationDate).TabIndex = 36;
		Label101.AutoSize = true;
		((Control)Label101).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label101).Location = new Point(4, 19);
		((Control)Label101).Name = "Label101";
		((Control)Label101).Size = new Size(34, 15);
		((Control)Label101).TabIndex = 38;
		((Label)Label101).Text = "Date:";
		Label102.AutoSize = true;
		((Control)Label102).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label102).Location = new Point(4, 39);
		((Control)Label102).Name = "Label102";
		((Control)Label102).Size = new Size(36, 15);
		((Control)Label102).TabIndex = 38;
		((Label)Label102).Text = "Time:";
		((Control)GroupBox_DeactivationTime).Anchor = (AnchorStyles)13;
		((Control)GroupBox_DeactivationTime).Controls.Add((Control)(object)CheckBox_DeleteMission);
		((Control)GroupBox_DeactivationTime).Controls.Add((Control)(object)CheckBox_OrderRTB);
		((Control)GroupBox_DeactivationTime).Controls.Add((Control)(object)CheckBox_UnassignUnits);
		((Control)GroupBox_DeactivationTime).Controls.Add((Control)(object)Button_Clear_DeactivationTime);
		((Control)GroupBox_DeactivationTime).Controls.Add((Control)(object)DateTimePicker_DeactivationTime);
		((Control)GroupBox_DeactivationTime).Controls.Add((Control)(object)Label112);
		((Control)GroupBox_DeactivationTime).Controls.Add((Control)(object)DateTimePicker_DeactivationDate);
		((Control)GroupBox_DeactivationTime).Controls.Add((Control)(object)Label114);
		((Control)GroupBox_DeactivationTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_DeactivationTime).Location = new Point(3, 70);
		((Control)GroupBox_DeactivationTime).Name = "GroupBox_DeactivationTime";
		((Control)GroupBox_DeactivationTime).Size = new Size(183, 119);
		((Control)GroupBox_DeactivationTime).TabIndex = 44;
		((GroupBox)GroupBox_DeactivationTime).TabStop = false;
		((GroupBox)GroupBox_DeactivationTime).Text = "Deactivation Time";
		((ButtonBase)CheckBox_DeleteMission).AutoSize = true;
		((Control)CheckBox_DeleteMission).Location = new Point(8, 98);
		((Control)CheckBox_DeleteMission).Name = "CheckBox_DeleteMission";
		((Control)CheckBox_DeleteMission).Size = new Size(103, 19);
		((Control)CheckBox_DeleteMission).TabIndex = 46;
		((ButtonBase)CheckBox_DeleteMission).Text = "Delete Mission";
		((ButtonBase)CheckBox_OrderRTB).AutoSize = true;
		((Control)CheckBox_OrderRTB).Location = new Point(8, 79);
		((Control)CheckBox_OrderRTB).Name = "CheckBox_OrderRTB";
		((Control)CheckBox_OrderRTB).Size = new Size(78, 19);
		((Control)CheckBox_OrderRTB).TabIndex = 45;
		((ButtonBase)CheckBox_OrderRTB).Text = "Order RTB";
		((ButtonBase)CheckBox_UnassignUnits).AutoSize = true;
		((Control)CheckBox_UnassignUnits).Location = new Point(8, 60);
		((Control)CheckBox_UnassignUnits).Name = "CheckBox_UnassignUnits";
		((Control)CheckBox_UnassignUnits).Size = new Size(104, 19);
		((Control)CheckBox_UnassignUnits).TabIndex = 44;
		((ButtonBase)CheckBox_UnassignUnits).Text = "Unassign Units";
		((Control)Button_Clear_DeactivationTime).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_Clear_DeactivationTime).BackColor = Color.Transparent;
		((Button)Button_Clear_DeactivationTime).DialogResult = (DialogResult)0;
		((Control)Button_Clear_DeactivationTime).Font = new Font("Segoe UI", 10f);
		((Control)Button_Clear_DeactivationTime).ForeColor = SystemColors.Control;
		((Control)Button_Clear_DeactivationTime).Location = new Point(133, 14);
		((Control)Button_Clear_DeactivationTime).Name = "Button_Clear_DeactivationTime";
		Button_Clear_DeactivationTime.RoundRadius = 0;
		((Control)Button_Clear_DeactivationTime).Size = new Size(45, 22);
		((Control)Button_Clear_DeactivationTime).TabIndex = 43;
		Button_Clear_DeactivationTime.Text = "Clear";
		((Control)DateTimePicker_DeactivationTime).Anchor = (AnchorStyles)13;
		((TextBoxBase)DateTimePicker_DeactivationTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_DeactivationTime).ForeColor = Color.DimGray;
		((Control)DateTimePicker_DeactivationTime).Location = new Point(39, 36);
		((Control)DateTimePicker_DeactivationTime).Name = "DateTimePicker_DeactivationTime";
		((Control)DateTimePicker_DeactivationTime).Size = new Size(88, 23);
		((Control)DateTimePicker_DeactivationTime).TabIndex = 40;
		Label112.AutoSize = true;
		((Control)Label112).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label112).Location = new Point(4, 40);
		((Control)Label112).Name = "Label112";
		((Control)Label112).Size = new Size(36, 15);
		((Control)Label112).TabIndex = 41;
		((Label)Label112).Text = "Time:";
		((Control)DateTimePicker_DeactivationDate).Anchor = (AnchorStyles)13;
		((TextBoxBase)DateTimePicker_DeactivationDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_DeactivationDate).ForeColor = Color.DimGray;
		((Control)DateTimePicker_DeactivationDate).Location = new Point(39, 15);
		((Control)DateTimePicker_DeactivationDate).Name = "DateTimePicker_DeactivationDate";
		((Control)DateTimePicker_DeactivationDate).Size = new Size(88, 23);
		((Control)DateTimePicker_DeactivationDate).TabIndex = 39;
		Label114.AutoSize = true;
		((Control)Label114).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label114).Location = new Point(4, 19);
		((Control)Label114).Name = "Label114";
		((Control)Label114).Size = new Size(34, 15);
		((Control)Label114).TabIndex = 42;
		((Label)Label114).Text = "Date:";
		((Control)GroupBox_TakeOffTime).Anchor = (AnchorStyles)13;
		((Control)GroupBox_TakeOffTime).Controls.Add((Control)(object)Button_Clear_TakeOffTime);
		((Control)GroupBox_TakeOffTime).Controls.Add((Control)(object)DateTimePicker_TakeOffTime);
		((Control)GroupBox_TakeOffTime).Controls.Add((Control)(object)DateTimePicker_TakeOffDate);
		((Control)GroupBox_TakeOffTime).Controls.Add((Control)(object)Label162);
		((Control)GroupBox_TakeOffTime).Controls.Add((Control)(object)Label169);
		((Control)GroupBox_TakeOffTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_TakeOffTime).Location = new Point(3, 195);
		((Control)GroupBox_TakeOffTime).Name = "GroupBox_TakeOffTime";
		((Control)GroupBox_TakeOffTime).Size = new Size(183, 61);
		((Control)GroupBox_TakeOffTime).TabIndex = 46;
		((GroupBox)GroupBox_TakeOffTime).TabStop = false;
		((GroupBox)GroupBox_TakeOffTime).Text = "Take-Off Time";
		((Control)Button_Clear_TakeOffTime).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_Clear_TakeOffTime).BackColor = Color.Transparent;
		((Button)Button_Clear_TakeOffTime).DialogResult = (DialogResult)0;
		((Control)Button_Clear_TakeOffTime).Font = new Font("Segoe UI", 10f);
		((Control)Button_Clear_TakeOffTime).ForeColor = SystemColors.Control;
		((Control)Button_Clear_TakeOffTime).Location = new Point(118, 14);
		((Control)Button_Clear_TakeOffTime).Name = "Button_Clear_TakeOffTime";
		Button_Clear_TakeOffTime.RoundRadius = 0;
		((Control)Button_Clear_TakeOffTime).Size = new Size(60, 22);
		((Control)Button_Clear_TakeOffTime).TabIndex = 44;
		Button_Clear_TakeOffTime.Text = "Clear";
		((Control)DateTimePicker_TakeOffTime).Anchor = (AnchorStyles)13;
		((TextBoxBase)DateTimePicker_TakeOffTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_TakeOffTime).ForeColor = Color.DimGray;
		((Control)DateTimePicker_TakeOffTime).Location = new Point(39, 36);
		((Control)DateTimePicker_TakeOffTime).Name = "DateTimePicker_TakeOffTime";
		((Control)DateTimePicker_TakeOffTime).Size = new Size(79, 23);
		((Control)DateTimePicker_TakeOffTime).TabIndex = 37;
		((Control)DateTimePicker_TakeOffDate).Anchor = (AnchorStyles)13;
		((TextBoxBase)DateTimePicker_TakeOffDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_TakeOffDate).ForeColor = Color.DimGray;
		((Control)DateTimePicker_TakeOffDate).Location = new Point(39, 15);
		((Control)DateTimePicker_TakeOffDate).Name = "DateTimePicker_TakeOffDate";
		((Control)DateTimePicker_TakeOffDate).Size = new Size(79, 23);
		((Control)DateTimePicker_TakeOffDate).TabIndex = 36;
		Label162.AutoSize = true;
		((Control)Label162).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label162).Location = new Point(4, 19);
		((Control)Label162).Name = "Label162";
		((Control)Label162).Size = new Size(34, 15);
		((Control)Label162).TabIndex = 38;
		((Label)Label162).Text = "Date:";
		Label169.AutoSize = true;
		((Control)Label169).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label169).Location = new Point(4, 39);
		((Control)Label169).Name = "Label169";
		((Control)Label169).Size = new Size(36, 15);
		((Control)Label169).TabIndex = 38;
		((Label)Label169).Text = "Time:";
		((Control)GroupBox_TimeOnTarget).Anchor = (AnchorStyles)13;
		((Control)GroupBox_TimeOnTarget).Controls.Add((Control)(object)Button_Clear_TimeOnTarget);
		((Control)GroupBox_TimeOnTarget).Controls.Add((Control)(object)DateTimePicker_TimeOnTargetTime);
		((Control)GroupBox_TimeOnTarget).Controls.Add((Control)(object)DateTimePicker_TimeOnTargetDate);
		((Control)GroupBox_TimeOnTarget).Controls.Add((Control)(object)Label170);
		((Control)GroupBox_TimeOnTarget).Controls.Add((Control)(object)Label171);
		((Control)GroupBox_TimeOnTarget).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_TimeOnTarget).Location = new Point(3, 262);
		((Control)GroupBox_TimeOnTarget).Name = "GroupBox_TimeOnTarget";
		((Control)GroupBox_TimeOnTarget).Size = new Size(183, 61);
		((Control)GroupBox_TimeOnTarget).TabIndex = 47;
		((GroupBox)GroupBox_TimeOnTarget).TabStop = false;
		((GroupBox)GroupBox_TimeOnTarget).Text = "Time On Target (ToT)";
		((Control)Button_Clear_TimeOnTarget).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_Clear_TimeOnTarget).BackColor = Color.Transparent;
		((Button)Button_Clear_TimeOnTarget).DialogResult = (DialogResult)0;
		((Control)Button_Clear_TimeOnTarget).Font = new Font("Segoe UI", 10f);
		((Control)Button_Clear_TimeOnTarget).ForeColor = SystemColors.Control;
		((Control)Button_Clear_TimeOnTarget).Location = new Point(118, 14);
		((Control)Button_Clear_TimeOnTarget).Name = "Button_Clear_TimeOnTarget";
		Button_Clear_TimeOnTarget.RoundRadius = 0;
		((Control)Button_Clear_TimeOnTarget).Size = new Size(60, 22);
		((Control)Button_Clear_TimeOnTarget).TabIndex = 44;
		Button_Clear_TimeOnTarget.Text = "Clear";
		((Control)DateTimePicker_TimeOnTargetTime).Anchor = (AnchorStyles)13;
		((TextBoxBase)DateTimePicker_TimeOnTargetTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_TimeOnTargetTime).ForeColor = Color.DimGray;
		((Control)DateTimePicker_TimeOnTargetTime).Location = new Point(39, 36);
		((Control)DateTimePicker_TimeOnTargetTime).Name = "DateTimePicker_TimeOnTargetTime";
		((Control)DateTimePicker_TimeOnTargetTime).Size = new Size(79, 23);
		((Control)DateTimePicker_TimeOnTargetTime).TabIndex = 37;
		((Control)DateTimePicker_TimeOnTargetDate).Anchor = (AnchorStyles)13;
		((TextBoxBase)DateTimePicker_TimeOnTargetDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DateTimePicker_TimeOnTargetDate).ForeColor = Color.DimGray;
		((Control)DateTimePicker_TimeOnTargetDate).Location = new Point(39, 15);
		((Control)DateTimePicker_TimeOnTargetDate).Name = "DateTimePicker_TimeOnTargetDate";
		((Control)DateTimePicker_TimeOnTargetDate).Size = new Size(79, 23);
		((Control)DateTimePicker_TimeOnTargetDate).TabIndex = 36;
		Label170.AutoSize = true;
		((Control)Label170).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label170).Location = new Point(4, 19);
		((Control)Label170).Name = "Label170";
		((Control)Label170).Size = new Size(34, 15);
		((Control)Label170).TabIndex = 38;
		((Label)Label170).Text = "Date:";
		Label171.AutoSize = true;
		((Control)Label171).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label171).Location = new Point(4, 39);
		((Control)Label171).Name = "Label171";
		((Control)Label171).Size = new Size(36, 15);
		((Control)Label171).TabIndex = 38;
		((Label)Label171).Text = "Time:";
		((Control)CB_ParentPool).Anchor = (AnchorStyles)13;
		((ComboBox)CB_ParentPool).BackColor = Color.Transparent;
		((ComboBox)CB_ParentPool).DrawMode = (DrawMode)1;
		((ComboBox)CB_ParentPool).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ParentPool).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_ParentPool).FormattingEnabled = true;
		((ComboBox)CB_ParentPool).Items.AddRange(new object[2] { "Active", "Inactive" });
		((Control)CB_ParentPool).Location = new Point(78, 153);
		((Control)CB_ParentPool).Name = "CB_ParentPool";
		((Control)CB_ParentPool).Size = new Size(266, 21);
		((Control)CB_ParentPool).TabIndex = 49;
		((Control)Label_ParentPool).Anchor = (AnchorStyles)13;
		Label_ParentPool.AutoSize = true;
		((Control)Label_ParentPool).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ParentPool).Location = new Point(1, 158);
		((Control)Label_ParentPool).Name = "Label_ParentPool";
		((Control)Label_ParentPool).Size = new Size(71, 15);
		((Control)Label_ParentPool).TabIndex = 48;
		((Label)Label_ParentPool).Text = "Parent pool:";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(541, 229);
		((Control)this).Controls.Add((Control)(object)CB_ParentPool);
		((Control)this).Controls.Add((Control)(object)Label_ParentPool);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)this).Controls.Add((Control)(object)Label_Category);
		((Control)this).Controls.Add((Control)(object)CB_Category);
		((Control)this).Controls.Add((Control)(object)CB_MissionStatus);
		((Control)this).Controls.Add((Control)(object)Label_MissionStatus);
		((Control)this).Controls.Add((Control)(object)CB_OpenMissionEditor);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)CB_MissionType);
		((Control)this).Controls.Add((Control)(object)Label_MissionType);
		((Control)this).Controls.Add((Control)(object)Label_MissionClass);
		((Control)this).Controls.Add((Control)(object)CB_MissionClass);
		((Control)this).Controls.Add((Control)(object)TextBox_Name);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "NewMission";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "New Mission / Task Pool / Package";
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)GroupBox_ActivationTime).ResumeLayout(false);
		((Control)GroupBox_ActivationTime).PerformLayout();
		((Control)GroupBox_DeactivationTime).ResumeLayout(false);
		((Control)GroupBox_DeactivationTime).PerformLayout();
		((Control)GroupBox_TakeOffTime).ResumeLayout(false);
		((Control)GroupBox_TakeOffTime).PerformLayout();
		((Control)GroupBox_TimeOnTarget).ResumeLayout(false);
		((Control)GroupBox_TimeOnTarget).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		foreach (Keys val in array)
		{
			if (keyData == val)
			{
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
		}
		return false;
	}

	public NewMission()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(NewMission_FormClosing);
		((Form)this).Load += NewMission_Load;
		((Control)this).VisibleChanged += NewMission_VisibleChanged;
		((Control)this).KeyDown += new KeyEventHandler(NewMission_KeyDown);
		RTMPEnabled = true;
		bool_3 = true;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)122,
			(Keys)27
		};
		InitializeComponent_1();
		ApplyStoredSizeSettings = false;
	}

	private void method_2(object object_0)
	{
		Button1.Enabled = Operators.CompareString(TextBox_Name.Text, "", true) != 0;
	}

	private void method_3(object sender, EventArgs e)
	{
		if (((ComboBox)CB_MissionClass).SelectedIndex == -1)
		{
			return;
		}
		switch (((ComboBox)CB_MissionClass).SelectedIndex)
		{
		case 0:
			((Control)CB_MissionType).Enabled = true;
			((Control)Label_MissionType).Enabled = true;
			((ComboBox)CB_MissionType).Items.Clear();
			((ComboBox)CB_MissionType).Items.AddRange(new object[4] { "Air Intercept", "Land Strike", "Naval ASuW Strike", "ASW Strike" });
			if (((ComboBox)CB_MissionType).Items.Count > 0 && ((ComboBox)CB_MissionType).SelectedIndex < 0)
			{
				((ComboBox)CB_MissionType).SelectedIndex = 0;
			}
			break;
		case 1:
			((Control)CB_MissionType).Enabled = true;
			((Control)Label_MissionType).Enabled = true;
			((ComboBox)CB_MissionType).Items.Clear();
			((ComboBox)CB_MissionType).Items.AddRange(new object[7] { "AAW Patrol", "ASuW Patrol (Naval)", "ASuW Patrol (Ground)", "ASuW Patrol (Mixed)", "ASW Patrol", "SEAD Patrol", "Sea Control Patrol" });
			if (((ComboBox)CB_MissionType).Items.Count > 0 && ((ComboBox)CB_MissionType).SelectedIndex < 0)
			{
				((ComboBox)CB_MissionType).SelectedIndex = 0;
			}
			break;
		case 6:
			((Control)CB_MissionType).Enabled = true;
			((Control)Label_MissionType).Enabled = true;
			((ComboBox)CB_MissionType).Items.Clear();
			((ComboBox)CB_MissionType).Items.AddRange(new object[2] { "Delivery", "Transfer" });
			if (!CargoMission.IsValidDestinationUnit(Client.SelectedUnit))
			{
				((ComboBox)CB_MissionType).SelectedIndex = 0;
			}
			else
			{
				((ComboBox)CB_MissionType).SelectedIndex = 1;
			}
			break;
		case 2:
		case 3:
		case 4:
		case 5:
		case 7:
			((ComboBox)CB_MissionType).Items.Clear();
			((Control)CB_MissionType).Enabled = false;
			((Control)Label_MissionType).Enabled = true;
			break;
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_5()
	{
		//IL_1bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_15df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ece: Unknown result type (might be due to invalid IL or missing references)
		//IL_1257: Unknown result type (might be due to invalid IL or missing references)
		//IL_125d: Invalid comparison between Unknown and I4
		//IL_17d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f23: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1098: Unknown result type (might be due to invalid IL or missing references)
		if (((ComboBox)CB_Category).SelectedIndex == -1)
		{
			return;
		}
		if (((ComboBox)CB_Category).SelectedIndex != 1 && ((ComboBox)CB_MissionClass).SelectedIndex == -1)
		{
			DarkMessageBox.ShowError("Please give the package a class type.", "No class type");
		}
		else if (Operators.CompareString(TextBox_Name.Text, "", true) != 0)
		{
			foreach (Mission mission3 in Client.CurrentSide.Missions)
			{
				if (Operators.CompareString(mission3.Name, TextBox_Name.Text, true) == 0)
				{
					DarkMessageBox.ShowError("A Mission with such name already exists", "Wrong name");
					return;
				}
			}
			method_28();
			method_30();
			method_32();
			CqpSugjtxue();
			string parentTaskPoolName = "";
			int mustRefreshMainForm;
			switch (((ComboBox)CB_Category).SelectedIndex)
			{
			default:
				mustRefreshMainForm = 1;
				goto IL_1ba3;
			case 1:
			{
				Side theSide = Client.CurrentSide;
				Scenario theScen = Client.CurrentScenario;
				TaskPool taskPool = new TaskPool(ref theSide, ref theScen, TextBox_Name.Text, Mission.MissionCategory.TaskPool);
				Client.CurrentSide = theSide;
				TaskPool taskPool2 = taskPool;
				if (!bool_8)
				{
					if (bool_3)
					{
						Client.MissionEditorWindow.SelectedMissionLink = taskPool2;
						if (((Control)Client.MissionEditorWindow).Visible)
						{
							Client.MissionEditorWindow.RefreshAll();
						}
						else
						{
							((Control)Client.MissionEditorWindow).Show();
						}
					}
				}
				else
				{
					Client.RealtimeTerminal.SendCreateMission(taskPool2, bool_3, parentTaskPoolName);
					theScen = Client.CurrentScenario;
					theSide = Client.CurrentSide;
					taskPool2.DeleteMission(ref theScen, ref theSide);
					Client.CurrentSide = theSide;
				}
				((Form)this).Close();
				mustRefreshMainForm = 1;
				goto IL_1ba3;
			}
			case 0:
			case 2:
				{
					Mission.MissionCategory theCategory;
					if (((ComboBox)CB_Category).SelectedIndex == 2)
					{
						if (((ComboBox)CB_ParentPool).Items.Count == 0 || ((ComboBox)CB_ParentPool).SelectedIndex < 0)
						{
							DarkMessageBox.ShowError("You must select a parent Aircraft Task Pool! If none exists, create one first.", "");
							break;
						}
						theCategory = Mission.MissionCategory.Package;
						parentTaskPoolName = ((ComboBox)CB_ParentPool).SelectedItem.ToString();
						Client.CurrentSide.GetNextPackageNumber();
					}
					else
					{
						theCategory = Mission.MissionCategory.Mission;
					}
					switch (((ComboBox)CB_MissionClass).SelectedIndex)
					{
					default:
						mustRefreshMainForm = 1;
						break;
					case 0:
						switch (((ComboBox)CB_MissionType).SelectedIndex)
						{
						default:
							DarkMessageBox.ShowError("Please select a type.", "No type selected");
							return;
						case 0:
						{
							Strike strike4 = new Strike(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, Strike.StrikeType.Air_Intercept);
							strike4.FlightSize = 2;
							if (strike4.Category == Mission.MissionCategory.Package)
							{
								CoreClientCode.AddNewPackageToParentPool_Core(strike4, Client.CurrentSide, parentTaskPoolName);
							}
							int selectedIndex4 = ((ComboBox)CB_MissionStatus).SelectedIndex;
							if (selectedIndex4 == 1)
							{
								((Mission)strike4).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
							}
							strike4.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
							strike4.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
							strike4.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
							if (strike4.Category != Mission.MissionCategory.Mission)
							{
								if (nullable_2.HasValue)
								{
									strike4.TakeOffTime = nullable_2;
								}
								if (nullable_3.HasValue)
								{
									strike4.TimeOnTarget = nullable_3;
								}
							}
							else
							{
								if (nullable_0.HasValue)
								{
									strike4.StartTime_Set(nullable_0, Client.CurrentScenario);
								}
								if (nullable_1.HasValue)
								{
									strike4.EndTime_Set(nullable_1, Client.CurrentScenario);
								}
							}
							method_6(strike4);
							if (!bool_8)
							{
								if (bool_3)
								{
									Client.MissionEditorWindow.SelectedMissionLink = strike4;
									if (((Control)Client.MissionEditorWindow).Visible)
									{
										Client.MissionEditorWindow.RefreshAll();
									}
									else
									{
										((Control)Client.MissionEditorWindow).Show();
									}
								}
							}
							else
							{
								Client.RealtimeTerminal.SendCreateMission(strike4, bool_3, parentTaskPoolName);
								Scenario theScen = Client.CurrentScenario;
								Side theSide = Client.CurrentSide;
								strike4.DeleteMission(ref theScen, ref theSide);
								Client.CurrentSide = theSide;
							}
							((Form)this).Close();
							mustRefreshMainForm = 1;
							break;
						}
						case 1:
						{
							Strike strike2 = new Strike(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, Strike.StrikeType.Land_Strike);
							strike2.FlightSize = 4;
							if (strike2.Category == Mission.MissionCategory.Package)
							{
								CoreClientCode.AddNewPackageToParentPool_Core(strike2, Client.CurrentSide, parentTaskPoolName);
							}
							int selectedIndex2 = ((ComboBox)CB_MissionStatus).SelectedIndex;
							if (selectedIndex2 == 1)
							{
								((Mission)strike2).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
							}
							method_6(strike2);
							if (strike2.TargetCount > 0)
							{
								List<Module_Unit.Unit> l2 = strike2.SpecificTargets.OrderBy([SpecialName] (Module_Unit.Unit theUnit) => theUnit.Name).ToList();
								strike2.ForceSpecificTargets(l2);
								strike2.RTB_When_Target_Destroyed = true;
							}
							strike2.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
							strike2.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
							strike2.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
							if (strike2.Category != Mission.MissionCategory.Mission)
							{
								if (nullable_2.HasValue)
								{
									strike2.TakeOffTime = nullable_2;
								}
								if (nullable_3.HasValue)
								{
									strike2.TimeOnTarget = nullable_3;
								}
							}
							else
							{
								if (nullable_0.HasValue)
								{
									strike2.StartTime_Set(nullable_0, Client.CurrentScenario);
								}
								if (nullable_1.HasValue)
								{
									strike2.EndTime_Set(nullable_1, Client.CurrentScenario);
								}
							}
							if (!bool_8)
							{
								if (bool_3)
								{
									Client.MissionEditorWindow.SelectedMissionLink = strike2;
									if (!((Control)Client.MissionEditorWindow).Visible)
									{
										((Control)Client.MissionEditorWindow).Show();
									}
									else
									{
										Client.MissionEditorWindow.RefreshAll();
									}
									((Control)Client.MissionEditorWindow).Show();
								}
							}
							else
							{
								Client.RealtimeTerminal.SendCreateMission(strike2, bool_3, parentTaskPoolName);
								Scenario theScen = Client.CurrentScenario;
								Side theSide = Client.CurrentSide;
								strike2.DeleteMission(ref theScen, ref theSide);
								Client.CurrentSide = theSide;
							}
							((Form)this).Close();
							mustRefreshMainForm = 1;
							break;
						}
						case 2:
						{
							Strike strike3 = new Strike(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, Strike.StrikeType.Maritime_Strike);
							strike3.FlightSize = 4;
							if (strike3.Category == Mission.MissionCategory.Package)
							{
								CoreClientCode.AddNewPackageToParentPool_Core(strike3, Client.CurrentSide, parentTaskPoolName);
							}
							int selectedIndex3 = ((ComboBox)CB_MissionStatus).SelectedIndex;
							if (selectedIndex3 == 1)
							{
								((Mission)strike3).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
							}
							foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
							{
								if (selectedUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide || Module_Side.IsAlliedWithThisSide(Client.CurrentSide, selectedUnit.get_UnitSide(SetSideOnly: false)))
								{
									continue;
								}
								if (selectedUnit.IsGroup)
								{
									foreach (ActiveUnit value3 in ((Group)selectedUnit).Units.Values)
									{
										strike3.AddToSpecificTargets(value3);
										if (strike3.IsActive && Client.CurrentSide.get_ConsidersThisSideToBe(value3.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
										{
											Client.CurrentSide.set_ConsidersThisSideToBe(value3.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
										}
									}
								}
								else if (!selectedUnit.IsActiveUnit)
								{
									Contact contact2 = (Contact)selectedUnit;
									if (contact2.ActualUnit == null)
									{
										continue;
									}
									if (Client.CurrentSide.BaseContacts.ContainsKey(contact2.ActualUnit.ObjectID))
									{
										foreach (ActiveUnit value4 in ((Group)contact2.ActualUnit).Units.Values)
										{
											if (!Client.CurrentSide.Contacts.ContainsKey(value4.ObjectID))
											{
												continue;
											}
											Client.CurrentSide.Contacts.TryGetValue(value4.ObjectID, out var value2);
											if (!Information.IsNothing((object)value2))
											{
												strike3.AddToSpecificTargets(value2);
												if (strike3.IsActive && contact2.get_Stance(Client.CurrentSide) != Misc.PostureStance.Hostile)
												{
													contact2.set_Stance(Client.CurrentSide, MarkManually: false, Misc.PostureStance.Hostile);
												}
											}
										}
									}
									else
									{
										strike3.AddToSpecificTargets(contact2);
										if (strike3.IsActive && contact2.get_Stance(Client.CurrentSide) != Misc.PostureStance.Hostile)
										{
											contact2.set_Stance(Client.CurrentSide, MarkManually: false, Misc.PostureStance.Hostile);
										}
									}
								}
								else
								{
									strike3.AddToSpecificTargets(selectedUnit);
									if (strike3.IsActive && Client.CurrentSide.get_ConsidersThisSideToBe(selectedUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
									{
										Client.CurrentSide.set_ConsidersThisSideToBe(selectedUnit.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
									}
								}
							}
							if (strike3.TargetCount > 0)
							{
								List<Module_Unit.Unit> l3 = strike3.SpecificTargets.OrderBy([SpecialName] (Module_Unit.Unit theUnit) => theUnit.Name).ToList();
								strike3.ForceSpecificTargets(l3);
								strike3.RTB_When_Target_Destroyed = true;
							}
							strike3.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
							strike3.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
							strike3.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
							if (strike3.Category != Mission.MissionCategory.Mission)
							{
								if (nullable_2.HasValue)
								{
									strike3.TakeOffTime = nullable_2;
								}
								if (nullable_3.HasValue)
								{
									strike3.TimeOnTarget = nullable_3;
								}
							}
							else
							{
								if (nullable_0.HasValue)
								{
									strike3.StartTime_Set(nullable_0, Client.CurrentScenario);
								}
								if (nullable_1.HasValue)
								{
									strike3.EndTime_Set(nullable_1, Client.CurrentScenario);
								}
							}
							if (bool_8)
							{
								Client.RealtimeTerminal.SendCreateMission(strike3, bool_3, parentTaskPoolName);
								Scenario theScen = Client.CurrentScenario;
								Side theSide = Client.CurrentSide;
								strike3.DeleteMission(ref theScen, ref theSide);
								Client.CurrentSide = theSide;
							}
							else if (bool_3)
							{
								Client.MissionEditorWindow.SelectedMissionLink = strike3;
								if (((Control)Client.MissionEditorWindow).Visible)
								{
									Client.MissionEditorWindow.RefreshAll();
								}
								else
								{
									((Control)Client.MissionEditorWindow).Show();
								}
								((Control)Client.MissionEditorWindow).Show();
							}
							((Form)this).Close();
							mustRefreshMainForm = 1;
							break;
						}
						case 3:
						{
							Strike strike = new Strike(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, Strike.StrikeType.Sub_Strike);
							strike.FlightSize = 1;
							if (strike.Category == Mission.MissionCategory.Package)
							{
								CoreClientCode.AddNewPackageToParentPool_Core(strike, Client.CurrentSide, parentTaskPoolName);
							}
							int selectedIndex = ((ComboBox)CB_MissionStatus).SelectedIndex;
							if (selectedIndex == 1)
							{
								((Mission)strike).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
							}
							foreach (Module_Unit.Unit selectedUnit2 in Client.CurrentSide.SelectedUnits)
							{
								if (selectedUnit2.get_UnitSide(SetSideOnly: false) == Client.CurrentSide || Module_Side.IsAlliedWithThisSide(Client.CurrentSide, selectedUnit2.get_UnitSide(SetSideOnly: false)))
								{
									continue;
								}
								if (selectedUnit2.IsGroup)
								{
									foreach (ActiveUnit value5 in ((Group)selectedUnit2).Units.Values)
									{
										strike.AddToSpecificTargets(value5);
										if (strike.IsActive && Client.CurrentSide.get_ConsidersThisSideToBe(value5.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
										{
											Client.CurrentSide.set_ConsidersThisSideToBe(value5.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
										}
									}
								}
								else if (!selectedUnit2.IsActiveUnit)
								{
									Contact contact = (Contact)selectedUnit2;
									if (Information.IsNothing((object)contact.ActualUnit))
									{
										continue;
									}
									if (Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
									{
										foreach (ActiveUnit value6 in ((Group)contact.ActualUnit).Units.Values)
										{
											if (!Client.CurrentSide.Contacts.ContainsKey(value6.ObjectID))
											{
												continue;
											}
											Client.CurrentSide.Contacts.TryGetValue(value6.ObjectID, out var value);
											if (!Information.IsNothing((object)value))
											{
												strike.AddToSpecificTargets(value);
												if (strike.IsActive && contact.get_Stance(Client.CurrentSide) != Misc.PostureStance.Hostile)
												{
													contact.set_Stance(Client.CurrentSide, MarkManually: false, Misc.PostureStance.Hostile);
												}
											}
										}
									}
									else
									{
										strike.AddToSpecificTargets(contact);
										if (strike.IsActive && contact.get_Stance(Client.CurrentSide) != Misc.PostureStance.Hostile)
										{
											contact.set_Stance(Client.CurrentSide, MarkManually: false, Misc.PostureStance.Hostile);
										}
									}
								}
								else
								{
									strike.AddToSpecificTargets(selectedUnit2);
									if (strike.IsActive && Client.CurrentSide.get_ConsidersThisSideToBe(selectedUnit2.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
									{
										Client.CurrentSide.set_ConsidersThisSideToBe(selectedUnit2.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
									}
								}
							}
							if (strike.TargetCount > 0)
							{
								List<Module_Unit.Unit> l = strike.SpecificTargets.OrderBy([SpecialName] (Module_Unit.Unit theUnit) => theUnit.Name).ToList();
								strike.ForceSpecificTargets(l);
								strike.RTB_When_Target_Destroyed = true;
							}
							strike.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
							strike.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
							strike.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
							if (strike.Category != Mission.MissionCategory.Mission)
							{
								if (nullable_2.HasValue)
								{
									strike.TakeOffTime = nullable_2;
								}
								if (nullable_3.HasValue)
								{
									strike.TimeOnTarget = nullable_3;
								}
							}
							else
							{
								if (nullable_0.HasValue)
								{
									strike.StartTime_Set(nullable_0, Client.CurrentScenario);
								}
								if (nullable_1.HasValue)
								{
									strike.EndTime_Set(nullable_1, Client.CurrentScenario);
								}
							}
							if (!bool_8)
							{
								if (bool_3)
								{
									Client.MissionEditorWindow.SelectedMissionLink = strike;
									if (!((Control)Client.MissionEditorWindow).Visible)
									{
										((Control)Client.MissionEditorWindow).Show();
									}
									else
									{
										Client.MissionEditorWindow.RefreshAll();
									}
									((Control)Client.MissionEditorWindow).Show();
								}
							}
							else
							{
								Client.RealtimeTerminal.SendCreateMission(strike, bool_3, parentTaskPoolName);
								Scenario theScen = Client.CurrentScenario;
								Side theSide = Client.CurrentSide;
								strike.DeleteMission(ref theScen, ref theSide);
								Client.CurrentSide = theSide;
							}
							((Form)this).Close();
							mustRefreshMainForm = 1;
							break;
						}
						}
						break;
					case 1:
					{
						IEnumerable<ReferencePoint> enumerable3 = Client.CurrentSide.RefPoints.Where([SpecialName] (ReferencePoint theRP) => theRP.IsHighlighted);
						if (enumerable3.Count() == 0)
						{
							DarkMessageBox.ShowError("You must select at least one reference point before creating a patrol mission.", "No reference points selected!");
							return;
						}
						List<ReferencePoint> list2 = new List<ReferencePoint>();
						list2.AddRange(enumerable3);
						Mission mission = null;
						switch (((ComboBox)CB_MissionType).SelectedIndex)
						{
						default:
							DarkMessageBox.ShowError("Please select a type.", "No type selected");
							return;
						case 0:
							mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list2, GlobalVariables.PatrolType.AAW, ValidateArea: true);
							mission.FlightSize = 2;
							break;
						case 1:
							mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list2, GlobalVariables.PatrolType.ASuW_Naval, ValidateArea: true);
							mission.FlightSize = 1;
							break;
						case 2:
							mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list2, GlobalVariables.PatrolType.ASuW_Land, ValidateArea: true);
							mission.FlightSize = 2;
							break;
						case 3:
							mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list2, GlobalVariables.PatrolType.ASuW_Mixed, ValidateArea: true);
							mission.FlightSize = 2;
							break;
						case 4:
							mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list2, GlobalVariables.PatrolType.ASW, ValidateArea: true);
							mission.FlightSize = 1;
							break;
						case 5:
							mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list2, GlobalVariables.PatrolType.SEAD, ValidateArea: true);
							mission.FlightSize = 2;
							break;
						case 6:
							mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list2, GlobalVariables.PatrolType.SeaControl, ValidateArea: true);
							mission.FlightSize = 1;
							break;
						}
						if (Information.IsNothing((object)mission))
						{
							DarkMessageBox.ShowError("Please select a patrol type.", "No patrol type selected!");
							mustRefreshMainForm = 1;
							break;
						}
						if (mission.Category == Mission.MissionCategory.Package)
						{
							CoreClientCode.AddNewPackageToParentPool_Core(mission, Client.CurrentSide, parentTaskPoolName);
						}
						int selectedIndex9 = ((ComboBox)CB_MissionStatus).SelectedIndex;
						if (selectedIndex9 == 1)
						{
							mission.set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
						}
						mission.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
						mission.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
						mission.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
						if (mission.Category == Mission.MissionCategory.Mission)
						{
							if (nullable_0.HasValue)
							{
								mission.StartTime_Set(nullable_0, Client.CurrentScenario);
							}
							if (nullable_1.HasValue)
							{
								mission.EndTime_Set(nullable_1, Client.CurrentScenario);
							}
						}
						else
						{
							if (nullable_2.HasValue)
							{
								mission.TakeOffTime = nullable_2;
							}
							if (nullable_3.HasValue)
							{
								mission.TimeOnTarget = nullable_3;
							}
						}
						if (bool_8)
						{
							Client.RealtimeTerminal.SendCreateMission(mission, bool_3, parentTaskPoolName);
							Mission mission2 = mission;
							Scenario theScen = Client.CurrentScenario;
							Side theSide = Client.CurrentSide;
							mission2.DeleteMission(ref theScen, ref theSide);
							Client.CurrentSide = theSide;
						}
						else if (bool_3)
						{
							Client.MissionEditorWindow.SelectedMissionLink = mission;
							if (((Control)Client.MissionEditorWindow).Visible)
							{
								Client.MissionEditorWindow.RefreshAll();
							}
							else
							{
								((Control)Client.MissionEditorWindow).Show();
							}
						}
						((Form)this).Close();
						mustRefreshMainForm = 1;
						break;
					}
					case 2:
					{
						IEnumerable<ReferencePoint> enumerable2 = Client.CurrentSide.RefPoints.Where([SpecialName] (ReferencePoint theRP) => theRP.IsHighlighted);
						if (enumerable2.Count() == 0 && (int)DarkMessageBox.ShowError("You should select at least one reference point before creating a support mission. Do you want to continue ?", "No reference points selected!", DarkDialogButton.YesNo) == 7)
						{
							return;
						}
						List<ReferencePoint> theCourse = new List<ReferencePoint>();
						theCourse.AddRange(enumerable2);
						Side theSide = Client.CurrentSide;
						Scenario theScen = Client.CurrentScenario;
						SupportMission supportMission = new SupportMission(ref theSide, ref theScen, TextBox_Name.Text, theCategory, ref theCourse, ValidateArea: true);
						Client.CurrentSide = theSide;
						SupportMission supportMission2 = supportMission;
						supportMission2.FlightSize = 1;
						if (supportMission2.Category == Mission.MissionCategory.Package)
						{
							CoreClientCode.AddNewPackageToParentPool_Core(supportMission2, Client.CurrentSide, parentTaskPoolName);
						}
						int selectedIndex8 = ((ComboBox)CB_MissionStatus).SelectedIndex;
						if (selectedIndex8 == 1)
						{
							((Mission)supportMission2).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
						}
						supportMission2.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
						supportMission2.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
						supportMission2.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
						if (supportMission2.Category != Mission.MissionCategory.Mission)
						{
							if (nullable_2.HasValue)
							{
								supportMission2.TakeOffTime = nullable_2;
							}
							if (nullable_3.HasValue)
							{
								supportMission2.TimeOnTarget = nullable_3;
							}
						}
						else
						{
							if (nullable_0.HasValue)
							{
								supportMission2.StartTime_Set(nullable_0, Client.CurrentScenario);
							}
							if (nullable_1.HasValue)
							{
								supportMission2.EndTime_Set(nullable_1, Client.CurrentScenario);
							}
						}
						if (bool_8)
						{
							Client.RealtimeTerminal.SendCreateMission(supportMission2, bool_3, parentTaskPoolName);
							theScen = Client.CurrentScenario;
							theSide = Client.CurrentSide;
							supportMission2.DeleteMission(ref theScen, ref theSide);
							Client.CurrentSide = theSide;
						}
						else if (bool_3)
						{
							Client.MissionEditorWindow.SelectedMissionLink = supportMission2;
							if (!((Control)Client.MissionEditorWindow).Visible)
							{
								((Control)Client.MissionEditorWindow).Show();
							}
							else
							{
								Client.MissionEditorWindow.RefreshAll();
							}
						}
						((Form)this).Close();
						mustRefreshMainForm = 1;
						break;
					}
					case 3:
						if (!Information.IsNothing((object)Client.SelectedUnit) && Client.SelectedUnit.IsActiveUnit)
						{
							FerryMission ferryMission = new FerryMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, (ActiveUnit)Client.SelectedUnit);
							ferryMission.FlightSize = 4;
							if (ferryMission.Category == Mission.MissionCategory.Package)
							{
								CoreClientCode.AddNewPackageToParentPool_Core(ferryMission, Client.CurrentSide, parentTaskPoolName);
							}
							int selectedIndex7 = ((ComboBox)CB_MissionStatus).SelectedIndex;
							if (selectedIndex7 == 1)
							{
								((Mission)ferryMission).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
							}
							ferryMission.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
							ferryMission.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
							ferryMission.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
							if (ferryMission.Category != Mission.MissionCategory.Mission)
							{
								if (nullable_2.HasValue)
								{
									ferryMission.TakeOffTime = nullable_2;
								}
								if (nullable_3.HasValue)
								{
									ferryMission.TimeOnTarget = nullable_3;
								}
							}
							else
							{
								if (nullable_0.HasValue)
								{
									ferryMission.StartTime_Set(nullable_0, Client.CurrentScenario);
								}
								if (nullable_1.HasValue)
								{
									ferryMission.EndTime_Set(nullable_1, Client.CurrentScenario);
								}
							}
							if (bool_8)
							{
								Client.RealtimeTerminal.SendCreateMission(ferryMission, bool_3, parentTaskPoolName);
								Scenario theScen = Client.CurrentScenario;
								Side theSide = Client.CurrentSide;
								ferryMission.DeleteMission(ref theScen, ref theSide);
								Client.CurrentSide = theSide;
							}
							else if (bool_3)
							{
								Client.MissionEditorWindow.SelectedMissionLink = ferryMission;
								if (!((Control)Client.MissionEditorWindow).Visible)
								{
									((Control)Client.MissionEditorWindow).Show();
								}
								else
								{
									Client.MissionEditorWindow.RefreshAll();
								}
							}
							((Form)this).Close();
							mustRefreshMainForm = 1;
							break;
						}
						DarkMessageBox.ShowError("You must select a valid destination before creating a ferry mission.", "No valid destination selected!");
						return;
					case 4:
					{
						IEnumerable<ReferencePoint> source = Client.CurrentSide.RefPoints.Where([SpecialName] (ReferencePoint theRP) => theRP.IsHighlighted);
						if (source.Count() >= 2)
						{
							List<ReferencePoint> theArea = source.ToList();
							MiningMission miningMission = new MiningMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, theArea, ValidateArea: true);
							miningMission.FlightSize = 4;
							if (miningMission.Category == Mission.MissionCategory.Package)
							{
								CoreClientCode.AddNewPackageToParentPool_Core(miningMission, Client.CurrentSide, parentTaskPoolName);
							}
							int selectedIndex5 = ((ComboBox)CB_MissionStatus).SelectedIndex;
							if (selectedIndex5 == 1)
							{
								((Mission)miningMission).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
							}
							miningMission.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
							miningMission.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
							miningMission.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
							if (miningMission.Category == Mission.MissionCategory.Mission)
							{
								if (nullable_0.HasValue)
								{
									miningMission.StartTime_Set(nullable_0, Client.CurrentScenario);
								}
								if (nullable_1.HasValue)
								{
									miningMission.EndTime_Set(nullable_1, Client.CurrentScenario);
								}
							}
							else
							{
								if (nullable_2.HasValue)
								{
									miningMission.TakeOffTime = nullable_2;
								}
								if (nullable_3.HasValue)
								{
									miningMission.TimeOnTarget = nullable_3;
								}
							}
							if (!bool_8)
							{
								if (bool_3)
								{
									Client.MissionEditorWindow.SelectedMissionLink = miningMission;
									if (((Control)Client.MissionEditorWindow).Visible)
									{
										Client.MissionEditorWindow.RefreshAll();
									}
									else
									{
										((Control)Client.MissionEditorWindow).Show();
									}
								}
							}
							else
							{
								Client.RealtimeTerminal.SendCreateMission(miningMission, bool_3, parentTaskPoolName);
								Scenario theScen = Client.CurrentScenario;
								Side theSide = Client.CurrentSide;
								miningMission.DeleteMission(ref theScen, ref theSide);
								Client.CurrentSide = theSide;
							}
							((Form)this).Close();
							mustRefreshMainForm = 1;
							break;
						}
						DarkMessageBox.ShowError("You must select at least two reference points before creating a mining mission.", "Not enough reference points selected!");
						return;
					}
					case 5:
					{
						IEnumerable<ReferencePoint> source2 = Client.CurrentSide.RefPoints.Where([SpecialName] (ReferencePoint theRP) => theRP.IsHighlighted);
						if (source2.Count() >= 2)
						{
							List<ReferencePoint> theArea2 = source2.ToList();
							MineClearingMission mineClearingMission = new MineClearingMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, theArea2, ValidateArea: true);
							mineClearingMission.FlightSize = 1;
							if (mineClearingMission.Category == Mission.MissionCategory.Package)
							{
								CoreClientCode.AddNewPackageToParentPool_Core(mineClearingMission, Client.CurrentSide, parentTaskPoolName);
							}
							int selectedIndex6 = ((ComboBox)CB_MissionStatus).SelectedIndex;
							if (selectedIndex6 == 1)
							{
								((Mission)mineClearingMission).set_Status(Client.CurrentScenario, Mission.MissionStatus.Inactive);
							}
							mineClearingMission.Deactivation_UnassignUnits = ((CheckBox)CheckBox_UnassignUnits).Checked;
							mineClearingMission.Deactivation_OrderRTB = ((CheckBox)CheckBox_OrderRTB).Checked;
							mineClearingMission.Deactivation_DeleteMission = ((CheckBox)CheckBox_DeleteMission).Checked;
							if (mineClearingMission.Category != Mission.MissionCategory.Mission)
							{
								if (nullable_2.HasValue)
								{
									mineClearingMission.TakeOffTime = nullable_2;
								}
								if (nullable_3.HasValue)
								{
									mineClearingMission.TimeOnTarget = nullable_3;
								}
							}
							else
							{
								if (nullable_0.HasValue)
								{
									mineClearingMission.StartTime_Set(nullable_0, Client.CurrentScenario);
								}
								if (nullable_1.HasValue)
								{
									mineClearingMission.EndTime_Set(nullable_1, Client.CurrentScenario);
								}
							}
							if (bool_8)
							{
								Client.RealtimeTerminal.SendCreateMission(mineClearingMission, bool_3, parentTaskPoolName);
								Scenario theScen = Client.CurrentScenario;
								Side theSide = Client.CurrentSide;
								mineClearingMission.DeleteMission(ref theScen, ref theSide);
								Client.CurrentSide = theSide;
							}
							else if (bool_3)
							{
								Client.MissionEditorWindow.SelectedMissionLink = mineClearingMission;
								if (((Control)Client.MissionEditorWindow).Visible)
								{
									Client.MissionEditorWindow.RefreshAll();
								}
								else
								{
									((Control)Client.MissionEditorWindow).Show();
								}
							}
							((Form)this).Close();
							mustRefreshMainForm = 1;
							break;
						}
						DarkMessageBox.ShowError("You must select at least two reference points before creating a mine-clearing mission.", "Not enough reference points selected!");
						return;
					}
					case 6:
					{
						CargoMission cargoMission = null;
						List<ReferencePoint> list = new List<ReferencePoint>();
						switch (((ComboBox)CB_MissionType).SelectedIndex)
						{
						case 1:
						{
							ActiveUnit activeUnit = null;
							if (CargoMission.IsValidDestinationUnit(Client.SelectedUnit))
							{
								activeUnit = (ActiveUnit)Client.SelectedUnit;
								cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list, ValidateArea: false, activeUnit);
								if (cargoMission.Category == Mission.MissionCategory.Package)
								{
									CoreClientCode.AddNewPackageToParentPool_Core(cargoMission, Client.CurrentSide, parentTaskPoolName);
								}
								break;
							}
							DarkMessageBox.ShowError("You must select a fixed facility unit, ship, airbase, or naval base that can host cargo before creating a cargo transfer mission.", "No valid destination selected!");
							return;
						}
						case 0:
						{
							IEnumerable<ReferencePoint> enumerable = Client.CurrentSide.RefPoints.Where([SpecialName] (ReferencePoint theRP) => theRP.IsHighlighted);
							if (enumerable != null && enumerable.Count() != 0)
							{
								list.AddRange(enumerable);
								cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, theCategory, list, ValidateArea: true);
								if (cargoMission.Category == Mission.MissionCategory.Package)
								{
									CoreClientCode.AddNewPackageToParentPool_Core(cargoMission, Client.CurrentSide, parentTaskPoolName);
								}
								break;
							}
							DarkMessageBox.ShowError("You must select one or more reference points before creating a cargo delivery mission.", "No valid destination selected!");
							return;
						}
						}
						if (Information.IsNothing((object)cargoMission))
						{
							DarkMessageBox.ShowError("Please select a cargo type.", "No cargo type selected!");
							mustRefreshMainForm = 1;
							break;
						}
						cargoMission.Name = TextBox_Name.Text;
						if (!bool_8)
						{
							if (bool_3)
							{
								Client.MissionEditorWindow.SelectedMissionLink = cargoMission;
								if (((Control)Client.MissionEditorWindow).Visible)
								{
									Client.MissionEditorWindow.RefreshAll();
								}
								else
								{
									((Control)Client.MissionEditorWindow).Show();
								}
							}
						}
						else
						{
							Client.RealtimeTerminal.SendCreateMission(cargoMission, bool_3, parentTaskPoolName);
							CargoMission cargoMission2 = cargoMission;
							Scenario theScen = Client.CurrentScenario;
							Side theSide = Client.CurrentSide;
							cargoMission2.DeleteMission(ref theScen, ref theSide);
							Client.CurrentSide = theSide;
						}
						((Form)this).Close();
						mustRefreshMainForm = 1;
						break;
					}
					case 7:
						DarkMessageBox.ShowError("Fire missions are not yet available.", "Not available");
						return;
					}
					goto IL_1ba3;
				}
				IL_1ba3:
				Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
				break;
			}
		}
		else
		{
			DarkMessageBox.ShowError("Please enter a name!", "No name");
		}
	}

	private void method_6(Strike strike_0)
	{
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide || Module_Side.IsAlliedWithThisSide(Client.CurrentSide, selectedUnit.get_UnitSide(SetSideOnly: false)))
			{
				continue;
			}
			if (selectedUnit.IsGroup)
			{
				foreach (ActiveUnit value2 in ((Group)selectedUnit).Units.Values)
				{
					strike_0.AddToSpecificTargets(value2);
					if (strike_0.IsActive && Client.CurrentSide.get_ConsidersThisSideToBe(value2.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
					{
						Client.CurrentSide.set_ConsidersThisSideToBe(value2.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
					}
				}
			}
			else if (!selectedUnit.IsActiveUnit)
			{
				Contact contact = (Contact)selectedUnit;
				if (contact.ActualUnit == null)
				{
					continue;
				}
				if (Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
				{
					foreach (ActiveUnit value3 in ((Group)contact.ActualUnit).Units.Values)
					{
						if (!Client.CurrentSide.Contacts.ContainsKey(value3.ObjectID))
						{
							continue;
						}
						Client.CurrentSide.Contacts.TryGetValue(value3.ObjectID, out var value);
						if (value != null)
						{
							strike_0.AddToSpecificTargets(value);
							if (strike_0.IsActive && contact.get_Stance(Client.CurrentSide) != Misc.PostureStance.Hostile)
							{
								contact.set_Stance(Client.CurrentSide, MarkManually: false, Misc.PostureStance.Hostile);
							}
						}
					}
				}
				else
				{
					strike_0.AddToSpecificTargets(contact);
					if (strike_0.IsActive && contact.get_Stance(Client.CurrentSide) != Misc.PostureStance.Hostile)
					{
						contact.set_Stance(Client.CurrentSide, MarkManually: false, Misc.PostureStance.Hostile);
					}
				}
			}
			else
			{
				strike_0.AddToSpecificTargets(selectedUnit);
				if (strike_0.IsActive && Client.CurrentSide.get_ConsidersThisSideToBe(selectedUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Hostile)
				{
					Client.CurrentSide.set_ConsidersThisSideToBe(selectedUnit.get_UnitSide(SetSideOnly: false), (Scenario)null, Misc.PostureStance.Hostile);
				}
			}
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void NewMission_FormClosing(object sender, FormClosingEventArgs e)
	{
		((TextBoxBase)DateTimePicker_ActivationDate).ForeColor = Color.DimGray;
		((TextBoxBase)DateTimePicker_ActivationTime).ForeColor = Color.DimGray;
		((TextBoxBase)DateTimePicker_DeactivationDate).ForeColor = Color.DimGray;
		((TextBoxBase)DateTimePicker_DeactivationTime).ForeColor = Color.DimGray;
		((TextBoxBase)DateTimePicker_TakeOffDate).ForeColor = Color.DimGray;
		((TextBoxBase)DateTimePicker_TakeOffTime).ForeColor = Color.DimGray;
		((TextBoxBase)DateTimePicker_TimeOnTargetDate).ForeColor = Color.DimGray;
		((TextBoxBase)DateTimePicker_TimeOnTargetTime).ForeColor = Color.DimGray;
		TextBox_Name.Focus();
		((CancelEventArgs)(object)e).Cancel = true;
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	public static void ComboBoxDataSource_Category(ref DataTable theComboBoxDataSource_Category)
	{
		if (!theComboBoxDataSource_Category.Columns.Contains("ID"))
		{
			theComboBoxDataSource_Category.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_Category.Columns.Contains("Description"))
		{
			theComboBoxDataSource_Category.Columns.Add("Description", typeof(string));
		}
		theComboBoxDataSource_Category.Rows.Add(0, "Mission");
		if (Module1.PoolsPackages_Visibility)
		{
			theComboBoxDataSource_Category.Rows.Add(1, "Task Pool");
			theComboBoxDataSource_Category.Rows.Add(2, "Package");
		}
	}

	private void NewMission_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		bool_8 = Client.Realtime;
		DataTable theComboBoxDataSource_Category = new DataTable();
		ComboBoxDataSource_Category(ref theComboBoxDataSource_Category);
		DarkUIComboBox cB_Category = CB_Category;
		((ComboBox)cB_Category).DataSource = theComboBoxDataSource_Category;
		((ComboBox)cB_Category).DropDownWidth = 500;
		((ListControl)cB_Category).DisplayMember = "Description";
		((ListControl)cB_Category).ValueMember = "ID";
		((Control)CB_ParentPool).Visible = true;
		((Control)CheckBox_UnassignUnits).Visible = true;
		((Control)CheckBox_OrderRTB).Visible = true;
		((Control)CheckBox_DeleteMission).Visible = true;
		((Control)Label_ParentPool).Visible = true;
		method_8();
		Button1.Enabled = Operators.CompareString(TextBox_Name.Text, "", true) != 0;
	}

	private void NewMission_VisibleChanged(object sender, EventArgs e)
	{
		if (((Control)this).Visible)
		{
			TextBox_Name.Text = "";
			method_8();
		}
	}

	private void method_8()
	{
		TextBox_Name.Text = "";
		nullable_0 = null;
		nullable_1 = null;
		nullable_2 = null;
		nullable_3 = null;
		if (((ComboBox)CB_Category).Items.Count > 0)
		{
			((ComboBox)CB_Category).SelectedIndex = 0;
		}
		method_11();
		if (((ComboBox)CB_MissionClass).Items.Count > 0)
		{
			((ComboBox)CB_MissionClass).SelectedIndex = 0;
		}
		if (((ComboBox)CB_MissionType).Items.Count > 0)
		{
			((ComboBox)CB_MissionType).SelectedIndex = 0;
		}
		((CheckBox)CB_OpenMissionEditor).Checked = bool_3;
		if (((ComboBox)CB_MissionStatus).Items.Count > 0)
		{
			((ComboBox)CB_MissionStatus).SelectedIndex = 0;
		}
		((Control)GroupBox_ActivationTime).Visible = true;
		((Control)GroupBox_DeactivationTime).Visible = true;
		((Control)GroupBox_TakeOffTime).Visible = false;
		((Control)GroupBox_TimeOnTarget).Visible = false;
		((MaskedTextBox)DateTimePicker_ActivationDate).Mask = "YYYY-MM-DD";
		((MaskedTextBox)DateTimePicker_ActivationTime).Mask = "hh:mm:ss";
		((MaskedTextBox)DateTimePicker_DeactivationDate).Mask = "YYYY-MM-DD";
		((MaskedTextBox)DateTimePicker_DeactivationTime).Mask = "hh:mm:ss";
		((MaskedTextBox)DateTimePicker_TakeOffDate).Mask = "YYYY-MM-DD";
		((MaskedTextBox)DateTimePicker_TakeOffTime).Mask = "hh:mm:ss";
		((MaskedTextBox)DateTimePicker_TimeOnTargetDate).Mask = "YYYY-MM-DD";
		((MaskedTextBox)DateTimePicker_TimeOnTargetTime).Mask = "hh:mm:ss";
		method_34();
	}

	private void NewMission_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Invalid comparison between Unknown and I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Invalid comparison between Unknown and I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Invalid comparison between Unknown and I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Invalid comparison between Unknown and I4
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Invalid comparison between Unknown and I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Invalid comparison between Unknown and I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if ((int)e.KeyCode == 122 && (int)e.Modifiers == 131072 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if ((int)e.KeyCode == 13 && ((Control)this).Visible && Button1.Enabled)
		{
			method_5();
		}
		if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		bool_3 = ((CheckBox)CB_OpenMissionEditor).Checked;
	}

	private void method_10(object sender, EventArgs e)
	{
		method_11();
		if (((ComboBox)CB_MissionClass).Items.Count > 0 && ((ComboBox)CB_MissionClass).SelectedIndex < 0)
		{
			((ComboBox)CB_MissionClass).SelectedIndex = 0;
		}
		if (((ComboBox)CB_MissionType).Items.Count > 0 && ((ComboBox)CB_MissionType).SelectedIndex < 0)
		{
			((ComboBox)CB_MissionType).SelectedIndex = 0;
		}
	}

	private void method_11()
	{
		if (((ComboBox)CB_Category).SelectedIndex == -1)
		{
			return;
		}
		switch (((ComboBox)CB_Category).SelectedIndex)
		{
		case 1:
			((Control)GroupBox_ActivationTime).Visible = false;
			((Control)GroupBox_DeactivationTime).Visible = false;
			((Control)GroupBox_TakeOffTime).Visible = false;
			((Control)GroupBox_TimeOnTarget).Visible = false;
			((Control)CB_ParentPool).Enabled = false;
			((Control)Label_ParentPool).Enabled = false;
			((ComboBox)CB_ParentPool).Items.Clear();
			((ComboBox)CB_MissionClass).Items.Clear();
			((Control)CB_MissionClass).Enabled = false;
			((Control)Label_MissionClass).Enabled = false;
			((ComboBox)CB_MissionType).Items.Clear();
			((Control)CB_MissionType).Enabled = false;
			((Control)Label_MissionType).Enabled = false;
			TextBox_Name.Text = "Task Pool: <name>";
			break;
		case 0:
		case 2:
			if (((ComboBox)CB_Category).SelectedIndex == 2)
			{
				TextBox_Name.Text = "Package " + Conversions.ToString(Client.CurrentSide.PackageID);
				((Control)GroupBox_ActivationTime).Visible = false;
				((Control)GroupBox_DeactivationTime).Visible = false;
				((Control)GroupBox_TakeOffTime).Visible = true;
				((Control)GroupBox_TimeOnTarget).Visible = true;
				((Control)CB_ParentPool).Enabled = true;
				((Control)Label_ParentPool).Enabled = true;
				((ComboBox)CB_ParentPool).BeginUpdate();
				((ComboBox)CB_ParentPool).Items.Clear();
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if (mission.Category == Mission.MissionCategory.TaskPool)
					{
						((ComboBox)CB_ParentPool).Items.Add((object)mission.Name);
					}
				}
				if (((ComboBox)CB_ParentPool).Items.Count > 0)
				{
					((ComboBox)CB_ParentPool).SelectedIndex = 0;
				}
				((ComboBox)CB_ParentPool).EndUpdate();
			}
			else
			{
				TextBox_Name.Text = "Mission: <name>";
				((Control)GroupBox_ActivationTime).Visible = true;
				((Control)GroupBox_DeactivationTime).Visible = true;
				((Control)GroupBox_TakeOffTime).Visible = false;
				((Control)GroupBox_TimeOnTarget).Visible = false;
				((Control)CB_ParentPool).Enabled = false;
				((Control)Label_ParentPool).Enabled = true;
				((ComboBox)CB_ParentPool).Items.Clear();
			}
			((ComboBox)CB_MissionType).Items.Clear();
			((Control)CB_MissionType).Enabled = false;
			((Control)Label_MissionType).Enabled = false;
			((Control)CB_MissionClass).Enabled = true;
			((Control)Label_MissionClass).Enabled = true;
			((ComboBox)CB_MissionClass).Items.Clear();
			((ComboBox)CB_MissionClass).Items.AddRange(new object[7] { "Strike (incl. Air Intercept)", "Patrol", "Support", "Ferry", "Mining", "Mine-clearing", "Cargo" });
			if (AGU_CONFIG.Instance.Enabled)
			{
				((ComboBox)CB_MissionClass).Items.Add((object)"Artillery Fire Mission");
			}
			break;
		}
		method_34();
	}

	private void method_12(object sender, EventArgs e)
	{
		bool_4 = true;
		method_27();
	}

	private void method_13(object sender, EventArgs e)
	{
		method_28();
	}

	private void method_14(object sender, EventArgs e)
	{
		bool_4 = true;
		method_27();
	}

	private void method_15(object sender, EventArgs e)
	{
		method_28();
	}

	private void method_16(object sender, EventArgs e)
	{
		bool_5 = true;
		method_29();
	}

	private void method_17(object sender, EventArgs e)
	{
		method_30();
	}

	private void method_18(object sender, EventArgs e)
	{
		bool_5 = true;
		method_29();
	}

	private void method_19(object sender, EventArgs e)
	{
		method_30();
	}

	private void method_20(object sender, EventArgs e)
	{
		bool_6 = true;
		method_31();
	}

	private void method_21(object sender, EventArgs e)
	{
		method_32();
	}

	private void method_22(object sender, EventArgs e)
	{
		bool_6 = true;
		method_31();
	}

	private void fNsSujNuLfi(object sender, EventArgs e)
	{
		method_32();
	}

	private void method_23(object sender, EventArgs e)
	{
		bool_7 = true;
		method_33();
	}

	private void method_24(object sender, EventArgs e)
	{
		CqpSugjtxue();
	}

	private void method_25(object sender, EventArgs e)
	{
		bool_7 = true;
		method_33();
	}

	private void method_26(object sender, EventArgs e)
	{
		CqpSugjtxue();
	}

	private void method_27()
	{
		if (Information.IsNothing((object)nullable_0))
		{
			((TextBoxBase)DateTimePicker_ActivationDate).ForeColor = Color.White;
			((TextBoxBase)DateTimePicker_ActivationTime).ForeColor = Color.White;
			((MaskedTextBox)DateTimePicker_ActivationDate).Mask = "0000-00-00";
			((MaskedTextBox)DateTimePicker_ActivationTime).Mask = "00:00:00";
			DateTime theDate = Client.CurrentScenario.Time;
			string theTimeString = "";
			string theDateString = "";
			GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
			GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: false);
			((MaskedTextBox)DateTimePicker_ActivationTime).Text = theTimeString;
			((MaskedTextBox)DateTimePicker_ActivationDate).Text = theDateString;
		}
	}

	private void method_28()
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!bool_4)
			{
				return;
			}
			DateTime dtOut = default(DateTime);
			int num = DateTimeHelper.ParseDateAndTime(((MaskedTextBox)DateTimePicker_ActivationDate).Text, ((MaskedTextBox)DateTimePicker_ActivationTime).Text, ref dtOut);
			if (num != 0)
			{
				Interaction.Beep();
				if (num == 1)
				{
					((Control)DateTimePicker_ActivationDate).Select();
				}
				else
				{
					((Control)DateTimePicker_ActivationTime).Select();
				}
			}
			else
			{
				nullable_0 = dtOut;
				bool_4 = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DarkMessageBox.ShowError("Time format must be hh:mm:ss", "ToT Date or format error");
			ProjectData.ClearProjectError();
		}
	}

	private void method_29()
	{
		if (Information.IsNothing((object)nullable_1))
		{
			((TextBoxBase)DateTimePicker_DeactivationDate).ForeColor = Color.White;
			((TextBoxBase)DateTimePicker_DeactivationTime).ForeColor = Color.White;
			((MaskedTextBox)DateTimePicker_DeactivationDate).Mask = "0000-00-00";
			((MaskedTextBox)DateTimePicker_DeactivationTime).Mask = "00:00:00";
			DateTime theDate = Client.CurrentScenario.Time.AddHours(3.0);
			string theTimeString = "";
			string theDateString = "";
			GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
			GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: false);
			((MaskedTextBox)DateTimePicker_DeactivationTime).Text = theTimeString;
			((MaskedTextBox)DateTimePicker_DeactivationDate).Text = theDateString;
		}
	}

	private void method_30()
	{
		if (!bool_5)
		{
			return;
		}
		DateTime dtOut = default(DateTime);
		int num = DateTimeHelper.ParseDateAndTime(((MaskedTextBox)DateTimePicker_DeactivationDate).Text, ((MaskedTextBox)DateTimePicker_DeactivationTime).Text, ref dtOut);
		if (num == 0)
		{
			nullable_1 = dtOut;
			bool_5 = false;
			return;
		}
		Interaction.Beep();
		if (num == 1)
		{
			((Control)DateTimePicker_DeactivationDate).Select();
		}
		else
		{
			((Control)DateTimePicker_DeactivationTime).Select();
		}
	}

	private void method_31()
	{
		if (Information.IsNothing((object)nullable_2))
		{
			((TextBoxBase)DateTimePicker_TakeOffDate).ForeColor = Color.White;
			((TextBoxBase)DateTimePicker_TakeOffTime).ForeColor = Color.White;
			((MaskedTextBox)DateTimePicker_TakeOffDate).Mask = "0000-00-00";
			((MaskedTextBox)DateTimePicker_TakeOffTime).Mask = "00:00:00";
			DateTime theDate = Client.CurrentScenario.Time.AddMinutes(30.0);
			string theTimeString = "";
			string theDateString = "";
			GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
			GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: false);
			((MaskedTextBox)DateTimePicker_TakeOffDate).Text = theDateString;
			((MaskedTextBox)DateTimePicker_TakeOffTime).Text = theTimeString;
		}
	}

	private void method_32()
	{
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!bool_6)
			{
				return;
			}
			((MaskedTextBox)DateTimePicker_TakeOffDate).Mask = "0000-00-00";
			((MaskedTextBox)DateTimePicker_TakeOffTime).Mask = "00:00:00";
			List<string> list = ((MaskedTextBox)DateTimePicker_TakeOffTime).Text.Split(new char[1] { ':' }).ToList();
			if (Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2]))
			{
				List<string> list2 = ((MaskedTextBox)DateTimePicker_TakeOffDate).Text.Split(new char[1] { '-' }).ToList();
				if (Versioned.IsNumeric((object)list2[0]) & Versioned.IsNumeric((object)list2[1]) & Versioned.IsNumeric((object)list2[2]))
				{
					nullable_2 = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
					method_34();
					bool_6 = false;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DarkMessageBox.ShowError("Date time format must be YYYY-MM-DD/ hh:mm:ss", "Take off  Date or format error");
			ProjectData.ClearProjectError();
		}
	}

	private void method_33()
	{
		if (Information.IsNothing((object)nullable_3))
		{
			((TextBoxBase)DateTimePicker_TimeOnTargetDate).ForeColor = Color.White;
			((TextBoxBase)DateTimePicker_TimeOnTargetTime).ForeColor = Color.White;
			((MaskedTextBox)DateTimePicker_TimeOnTargetDate).Mask = "0000-00-00";
			((MaskedTextBox)DateTimePicker_TimeOnTargetTime).Mask = "00:00:00";
			DateTime theDate = Client.CurrentScenario.Time.AddHours(3.0);
			string theTimeString = "";
			string theDateString = "";
			GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
			GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: false);
			((MaskedTextBox)DateTimePicker_TimeOnTargetDate).Text = theDateString;
			((MaskedTextBox)DateTimePicker_TimeOnTargetTime).Text = theTimeString;
		}
	}

	private void CqpSugjtxue()
	{
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!bool_7)
			{
				return;
			}
			((MaskedTextBox)DateTimePicker_TimeOnTargetDate).Mask = "0000-00-00";
			((MaskedTextBox)DateTimePicker_TimeOnTargetTime).Mask = "00:00:00";
			List<string> list = ((MaskedTextBox)DateTimePicker_TimeOnTargetTime).Text.Split(new char[1] { ':' }).ToList();
			if (Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2]))
			{
				List<string> list2 = ((MaskedTextBox)DateTimePicker_TimeOnTargetDate).Text.Split(new char[1] { '-' }).ToList();
				if (Versioned.IsNumeric((object)list2[0]) & Versioned.IsNumeric((object)list2[1]) & Versioned.IsNumeric((object)list2[2]))
				{
					nullable_3 = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
					method_34();
					bool_7 = false;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DarkMessageBox.ShowError("Date time format must be YYYY-MM-DD/ hh:mm:ss", "ToT Date or format error");
			ProjectData.ClearProjectError();
		}
	}

	private void method_34()
	{
		if (nullable_3.HasValue)
		{
			((Control)DateTimePicker_TakeOffDate).Enabled = false;
			((Control)DateTimePicker_TakeOffTime).Enabled = false;
			Button_Clear_TakeOffTime.Enabled = false;
			((Control)DateTimePicker_TimeOnTargetDate).Enabled = true;
			((Control)DateTimePicker_TimeOnTargetTime).Enabled = true;
			Button_Clear_TimeOnTarget.Enabled = true;
		}
		else if (nullable_2.HasValue)
		{
			((Control)DateTimePicker_TakeOffDate).Enabled = true;
			((Control)DateTimePicker_TakeOffTime).Enabled = true;
			Button_Clear_TakeOffTime.Enabled = true;
			((Control)DateTimePicker_TimeOnTargetDate).Enabled = false;
			((Control)DateTimePicker_TimeOnTargetTime).Enabled = false;
			Button_Clear_TimeOnTarget.Enabled = false;
		}
		else
		{
			((Control)DateTimePicker_TakeOffDate).Enabled = true;
			((Control)DateTimePicker_TakeOffTime).Enabled = true;
			Button_Clear_TakeOffTime.Enabled = true;
			((Control)DateTimePicker_TimeOnTargetDate).Enabled = true;
			((Control)DateTimePicker_TimeOnTargetTime).Enabled = true;
			Button_Clear_TimeOnTarget.Enabled = true;
		}
	}

	private void method_35(object sender, EventArgs e)
	{
		nullable_0 = null;
		((MaskedTextBox)DateTimePicker_ActivationDate).Mask = "";
		((MaskedTextBox)DateTimePicker_ActivationTime).Mask = "";
		((MaskedTextBox)DateTimePicker_ActivationDate).Text = "YYYY-MM-DD";
		((MaskedTextBox)DateTimePicker_ActivationTime).Text = "hh:mm:ss";
	}

	private void method_36(object sender, EventArgs e)
	{
		nullable_1 = null;
		((MaskedTextBox)DateTimePicker_DeactivationDate).Mask = "";
		((MaskedTextBox)DateTimePicker_DeactivationTime).Mask = "";
		((MaskedTextBox)DateTimePicker_DeactivationDate).Text = "YYYY-MM-DD";
		((MaskedTextBox)DateTimePicker_DeactivationTime).Text = "hh:mm:ss";
	}

	private void method_37(object sender, EventArgs e)
	{
		nullable_2 = null;
		((MaskedTextBox)DateTimePicker_TakeOffDate).Mask = "";
		((MaskedTextBox)DateTimePicker_TakeOffTime).Mask = "";
		((MaskedTextBox)DateTimePicker_TakeOffDate).Text = "YYYY-MM-DD";
		((MaskedTextBox)DateTimePicker_TakeOffTime).Text = "hh:mm:ss";
		method_34();
	}

	private void method_38(object sender, EventArgs e)
	{
		nullable_3 = null;
		((MaskedTextBox)DateTimePicker_TimeOnTargetDate).Mask = "";
		((MaskedTextBox)DateTimePicker_TimeOnTargetTime).Mask = "";
		((MaskedTextBox)DateTimePicker_TimeOnTargetDate).Text = "YYYY-MM-DD";
		((MaskedTextBox)DateTimePicker_TimeOnTargetTime).Text = "hh:mm:ss";
		method_34();
	}

	private void method_39(object sender, EventArgs e)
	{
		bool_4 = true;
		method_28();
	}

	private void method_40(object sender, EventArgs e)
	{
		bool_5 = true;
		method_30();
	}

	private void method_41(object sender, EventArgs e)
	{
		bool_6 = true;
		method_32();
	}

	private void method_42(object sender, EventArgs e)
	{
		bool_7 = true;
		CqpSugjtxue();
	}

	static NewMission()
	{
		Class72.smethod_20();
	}
}

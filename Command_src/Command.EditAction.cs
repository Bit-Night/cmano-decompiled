using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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
using MSDN.Html.Editor;
using ScintillaNET;

namespace Command;

[DesignerGenerated]
public sealed class EditAction : DarkSecondaryFormBase
{
	public delegate void EventActionsChangedEventHandler(Scenario theScen);

	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox _TextBox1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_Points")]
	private DarkNumericUpDown _NUD_Points;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Points_Sides")]
	private DarkUIComboBox _CB_Points_Sides;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Message_Side")]
	private DarkUIComboBox _CB_Message_Side;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MissionStatus_Mission")]
	private DarkUIComboBox _CB_MissionStatus_Mission;

	[AccessedThroughProperty("CB_MissionStatus_Side")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_MissionStatus_Side;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MissionStatus_Status")]
	private DarkUIComboBox _CB_MissionStatus_Status;

	[AccessedThroughProperty("Button_AddLuaScript")]
	[CompilerGenerated]
	private DarkUIButton _Button_AddLuaScript;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_LuaScript")]
	private GClass9 _NUD_LuaScript;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton _Button3;

	public EventAction theEA;

	public _FormAction Action;

	[CompilerGenerated]
	private static EventActionsChangedEventHandler eventActionsChangedEventHandler_0;

	private LuaConsole luaConsole_0;

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

	[field: AccessedThroughProperty("TC_ActionOptions")]
	internal virtual DarkUITabControl TC_ActionOptions { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

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
			EventHandler eventHandler = method_2;
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
			EventHandler eventHandler = method_3;
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

	internal virtual DarkNumericUpDown NUD_Points
	{
		[CompilerGenerated]
		get
		{
			return _NUD_Points;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkNumericUpDown darkNumericUpDown = _NUD_Points;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).TextChanged -= eventHandler;
			}
			_NUD_Points = value;
			darkNumericUpDown = _NUD_Points;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).TextChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_Points_Sides
	{
		[CompilerGenerated]
		get
		{
			return _CB_Points_Sides;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIComboBox darkUIComboBox = _CB_Points_Sides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_Points_Sides = value;
			darkUIComboBox = _CB_Points_Sides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	[field: AccessedThroughProperty("ListBox_UnitsToTeleport")]
	internal virtual DarkListView ListBox_UnitsToTeleport { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("AreaEditor1")]
	internal virtual AreaEditor AreaEditor1 { get; set; }

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4 { get; set; }

	internal virtual DarkUIComboBox CB_Message_Side
	{
		[CompilerGenerated]
		get
		{
			return _CB_Message_Side;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIComboBox darkUIComboBox = _CB_Message_Side;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_Message_Side = value;
			darkUIComboBox = _CB_Message_Side;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("TabPage5")]
	internal virtual TabPage TabPage5 { get; set; }

	[field: AccessedThroughProperty("Label11")]
	internal virtual DarkLabel Label11 { get; set; }

	internal virtual DarkUIComboBox CB_MissionStatus_Mission
	{
		[CompilerGenerated]
		get
		{
			return _CB_MissionStatus_Mission;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIComboBox darkUIComboBox = _CB_MissionStatus_Mission;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_MissionStatus_Mission = value;
			darkUIComboBox = _CB_MissionStatus_Mission;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_MissionStatus_Side
	{
		[CompilerGenerated]
		get
		{
			return _CB_MissionStatus_Side;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIComboBox darkUIComboBox = _CB_MissionStatus_Side;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_MissionStatus_Side = value;
			darkUIComboBox = _CB_MissionStatus_Side;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label10")]
	internal virtual DarkLabel Label10 { get; set; }

	internal virtual DarkUIComboBox CB_MissionStatus_Status
	{
		[CompilerGenerated]
		get
		{
			return _CB_MissionStatus_Status;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = aBmSmiBvuuA;
			DarkUIComboBox darkUIComboBox = _CB_MissionStatus_Status;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_MissionStatus_Status = value;
			darkUIComboBox = _CB_MissionStatus_Status;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Editor_Message_Text")]
	private virtual HtmlEditorControl Editor_Message_Text { get; set; }

	[field: AccessedThroughProperty("TabPage6")]
	internal virtual TabPage TabPage6 { get; set; }

	internal virtual DarkUIButton Button_AddLuaScript
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddLuaScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIButton darkUIButton = _Button_AddLuaScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AddLuaScript = value;
			darkUIButton = _Button_AddLuaScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_LuaTemplate")]
	internal virtual DarkUIComboBox CB_LuaTemplate { get; set; }

	[field: AccessedThroughProperty("Label12")]
	internal virtual DarkLabel Label12 { get; set; }

	[field: AccessedThroughProperty("TextPanel2")]
	internal virtual Panel TextPanel2 { get; set; }

	internal virtual GClass9 NUD_LuaScript
	{
		[CompilerGenerated]
		get
		{
			return _NUD_LuaScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			EventHandler eventHandler2 = method_14;
			GClass9 gClass = _NUD_LuaScript;
			if (gClass != null)
			{
				((NumericUpDown)gClass).TextChanged -= eventHandler;
				((Control)gClass).Click -= eventHandler2;
			}
			_NUD_LuaScript = value;
			gClass = _NUD_LuaScript;
			if (gClass != null)
			{
				((NumericUpDown)gClass).TextChanged += eventHandler;
				((Control)gClass).Click += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label13")]
	internal virtual DarkLabel Label13 { get; set; }

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
			EventHandler eventHandler = method_11;
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

	public static event EventActionsChangedEventHandler EventActionsChanged
	{
		[CompilerGenerated]
		add
		{
			EventActionsChangedEventHandler eventActionsChangedEventHandler = eventActionsChangedEventHandler_0;
			EventActionsChangedEventHandler eventActionsChangedEventHandler2;
			do
			{
				eventActionsChangedEventHandler2 = eventActionsChangedEventHandler;
				EventActionsChangedEventHandler value2 = (EventActionsChangedEventHandler)Delegate.Combine(eventActionsChangedEventHandler2, value);
				eventActionsChangedEventHandler = Interlocked.CompareExchange(ref eventActionsChangedEventHandler_0, value2, eventActionsChangedEventHandler2);
			}
			while ((object)eventActionsChangedEventHandler != eventActionsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventActionsChangedEventHandler eventActionsChangedEventHandler = eventActionsChangedEventHandler_0;
			EventActionsChangedEventHandler eventActionsChangedEventHandler2;
			do
			{
				eventActionsChangedEventHandler2 = eventActionsChangedEventHandler;
				EventActionsChangedEventHandler value2 = (EventActionsChangedEventHandler)Delegate.Remove(eventActionsChangedEventHandler2, value);
				eventActionsChangedEventHandler = Interlocked.CompareExchange(ref eventActionsChangedEventHandler_0, value2, eventActionsChangedEventHandler2);
			}
			while ((object)eventActionsChangedEventHandler != eventActionsChangedEventHandler2);
		}
	}

	public EditAction()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(EditAction_FormClosing);
		((Form)this).Load += EditAction_Load;
		((Control)this).KeyDown += new KeyEventHandler(EditAction_KeyDown);
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
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected O, but got Unknown
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected O, but got Unknown
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Expected O, but got Unknown
		//IL_0938: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c92: Expected O, but got Unknown
		//IL_0cd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e73: Expected O, but got Unknown
		//IL_10ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f9: Expected O, but got Unknown
		//IL_122b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1235: Expected O, but got Unknown
		//IL_12c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12cb: Expected O, but got Unknown
		//IL_14e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1555: Unknown result type (might be due to invalid IL or missing references)
		//IL_155f: Expected O, but got Unknown
		//IL_1666: Unknown result type (might be due to invalid IL or missing references)
		//IL_1670: Expected O, but got Unknown
		//IL_16ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_172c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1736: Expected O, but got Unknown
		//IL_1827: Unknown result type (might be due to invalid IL or missing references)
		//IL_1831: Expected O, but got Unknown
		//IL_189d: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a7: Expected O, but got Unknown
		//IL_194a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1954: Expected O, but got Unknown
		//IL_1995: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a12: Expected O, but got Unknown
		//IL_1a4f: Unknown result type (might be due to invalid IL or missing references)
		TextBox1 = new DarkUITextBox();
		Label2 = new DarkLabel();
		TC_ActionOptions = new DarkUITabControl();
		TabPage1 = new TabPage();
		Label5 = new DarkLabel();
		NUD_Points = new DarkNumericUpDown();
		CB_Points_Sides = new DarkUIComboBox();
		Label4 = new DarkLabel();
		Label1 = new DarkLabel();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		AreaEditor1 = new AreaEditor();
		ListBox_UnitsToTeleport = new DarkListView();
		Label6 = new DarkLabel();
		TabPage4 = new TabPage();
		Button3 = new DarkUIButton();
		Editor_Message_Text = new HtmlEditorControl();
		CB_Message_Side = new DarkUIComboBox();
		Label8 = new DarkLabel();
		Label9 = new DarkLabel();
		TabPage5 = new TabPage();
		CB_MissionStatus_Status = new DarkUIComboBox();
		Label11 = new DarkLabel();
		CB_MissionStatus_Mission = new DarkUIComboBox();
		CB_MissionStatus_Side = new DarkUIComboBox();
		Label7 = new DarkLabel();
		Label10 = new DarkLabel();
		TabPage6 = new TabPage();
		NUD_LuaScript = new GClass9();
		Label13 = new DarkLabel();
		Button_AddLuaScript = new DarkUIButton();
		CB_LuaTemplate = new DarkUIComboBox();
		Label12 = new DarkLabel();
		TextPanel2 = new Panel();
		Label3 = new DarkLabel();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		((Control)TC_ActionOptions).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((ISupportInitialize)NUD_Points).BeginInit();
		((Control)TabPage3).SuspendLayout();
		((Control)TabPage4).SuspendLayout();
		((Control)TabPage5).SuspendLayout();
		((Control)TabPage6).SuspendLayout();
		((ISupportInitialize)(object)NUD_LuaScript).BeginInit();
		((Control)this).SuspendLayout();
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.FromArgb(69, 73, 74);
		TextBox1.Font = new Font("Segoe UI", 10f);
		((Control)TextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(90, 12);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(632, 20);
		((Control)TextBox1).TabIndex = 6;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TextBox1.WordWrap = false;
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(4, 16);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(89, 19);
		((Control)Label2).TabIndex = 5;
		((Label)Label2).Text = "Description:";
		((Control)TC_ActionOptions).Anchor = (AnchorStyles)15;
		((Control)TC_ActionOptions).Controls.Add((Control)(object)TabPage1);
		((Control)TC_ActionOptions).Controls.Add((Control)(object)TabPage2);
		((Control)TC_ActionOptions).Controls.Add((Control)(object)TabPage3);
		((Control)TC_ActionOptions).Controls.Add((Control)(object)TabPage4);
		((Control)TC_ActionOptions).Controls.Add((Control)(object)TabPage5);
		((Control)TC_ActionOptions).Controls.Add((Control)(object)TabPage6);
		((Control)TC_ActionOptions).Cursor = Cursors.Hand;
		((Control)TC_ActionOptions).Font = new Font("Segoe UI", 8f);
		((TabControl)TC_ActionOptions).ItemSize = new Size(80, 20);
		((Control)TC_ActionOptions).Location = new Point(4, 64);
		((TabControl)TC_ActionOptions).Multiline = true;
		((Control)TC_ActionOptions).Name = "TC_ActionOptions";
		((TabControl)TC_ActionOptions).SelectedIndex = 0;
		((Control)TC_ActionOptions).Size = new Size(722, 382);
		((Control)TC_ActionOptions).TabIndex = 22;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)Label5);
		((Control)TabPage1).Controls.Add((Control)(object)NUD_Points);
		((Control)TabPage1).Controls.Add((Control)(object)CB_Points_Sides);
		((Control)TabPage1).Controls.Add((Control)(object)Label4);
		((Control)TabPage1).Controls.Add((Control)(object)Label1);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(714, 354);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Points";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(372, 120);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(140, 19);
		((Control)Label5).TabIndex = 4;
		((Label)Label5).Text = "(negative to subtract)";
		((UpDownBase)NUD_Points).BackColor = Color.FromArgb(35, 35, 35);
		((UpDownBase)NUD_Points).BorderStyle = (BorderStyle)1;
		((Control)NUD_Points).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((UpDownBase)NUD_Points).ForeColor = Color.White;
		((Control)NUD_Points).Location = new Point(174, 113);
		((NumericUpDown)NUD_Points).Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		((NumericUpDown)NUD_Points).Minimum = new decimal(new int[4] { 999999, 0, 0, -2147483648 });
		((Control)NUD_Points).Name = "NUD_Points";
		((Control)NUD_Points).Size = new Size(192, 34);
		((Control)NUD_Points).TabIndex = 3;
		((ComboBox)CB_Points_Sides).BackColor = Color.Transparent;
		((ComboBox)CB_Points_Sides).DrawMode = (DrawMode)1;
		((ComboBox)CB_Points_Sides).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Points_Sides).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Points_Sides).FormattingEnabled = true;
		((Control)CB_Points_Sides).Location = new Point(174, 85);
		((Control)CB_Points_Sides).Name = "CB_Points_Sides";
		((Control)CB_Points_Sides).Size = new Size(192, 24);
		((Control)CB_Points_Sides).TabIndex = 2;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(89, 121);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(94, 19);
		((Control)Label4).TabIndex = 1;
		((Label)Label4).Text = "Point Change:";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(137, 88);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(37, 19);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Side:";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(714, 354);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "End Scenario";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)AreaEditor1);
		((Control)TabPage3).Controls.Add((Control)(object)ListBox_UnitsToTeleport);
		((Control)TabPage3).Controls.Add((Control)(object)Label6);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Padding = new Padding(3);
		((Control)TabPage3).Size = new Size(714, 354);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Teleport in Area";
		((Control)AreaEditor1).BackColor = Color.FromArgb(60, 63, 65);
		((Control)AreaEditor1).Location = new Point(356, 7);
		((Control)AreaEditor1).Name = "AreaEditor1";
		((Control)AreaEditor1).Size = new Size(351, 124);
		((Control)AreaEditor1).TabIndex = 2;
		AreaEditor1.Title = "Edit teleport area";
		((Control)ListBox_UnitsToTeleport).Location = new Point(10, 23);
		ListBox_UnitsToTeleport.MultiSelect = true;
		((Control)ListBox_UnitsToTeleport).Name = "ListBox_UnitsToTeleport";
		ListBox_UnitsToTeleport.RelatedInfos = null;
		((Control)ListBox_UnitsToTeleport).Size = new Size(340, 316);
		((Control)ListBox_UnitsToTeleport).TabIndex = 1;
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(7, 7);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(179, 19);
		((Control)Label6).TabIndex = 0;
		((Label)Label6).Text = "Highlight unit(s) to teleport:";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage4).Controls.Add((Control)(object)Button3);
		((Control)TabPage4).Controls.Add((Control)(object)Editor_Message_Text);
		((Control)TabPage4).Controls.Add((Control)(object)CB_Message_Side);
		((Control)TabPage4).Controls.Add((Control)(object)Label8);
		((Control)TabPage4).Controls.Add((Control)(object)Label9);
		TabPage4.Location = new Point(4, 24);
		((Control)TabPage4).Name = "ComNetworkLog";
		((Control)TabPage4).Size = new Size(714, 354);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "Message";
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Control)Button3).Font = new Font("Segoe UI", 10f);
		((Control)Button3).ForeColor = SystemColors.Control;
		((Control)Button3).Location = new Point(616, 18);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(95, 23);
		((Control)Button3).TabIndex = 29;
		Button3.Text = "Edit HTML";
		((Control)Editor_Message_Text).Anchor = (AnchorStyles)15;
		Editor_Message_Text.BackColor = Color.FromArgb(69, 73, 74);
		Editor_Message_Text.BodyBackColor = Color.FromArgb(43, 43, 43);
		Editor_Message_Text.BodyFont = new HtmlFontProperty("Segoe UI", HtmlFontSize.Medium, bold: false, italic: false, underline: false, strikeout: false, subscript: false, superscript: false);
		Editor_Message_Text.BodyForeColor = Color.FromArgb(220, 220, 220);
		Editor_Message_Text.BorderSize = 0;
		((UserControl)Editor_Message_Text).BorderStyle = (BorderStyle)2;
		((Control)Editor_Message_Text).Enabled = false;
		((Control)Editor_Message_Text).ForeColor = Color.FromArgb(220, 220, 220);
		Editor_Message_Text.InnerText = null;
		((Control)Editor_Message_Text).Location = new Point(72, 47);
		((Control)Editor_Message_Text).Name = "Editor_Message_Text";
		((Control)Editor_Message_Text).Size = new Size(639, 307);
		((Control)Editor_Message_Text).TabIndex = 28;
		Editor_Message_Text.ToolbarDock = (DockStyle)1;
		((ComboBox)CB_Message_Side).BackColor = Color.Transparent;
		((ComboBox)CB_Message_Side).DrawMode = (DrawMode)1;
		((ComboBox)CB_Message_Side).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Message_Side).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Message_Side).FormattingEnabled = true;
		((Control)CB_Message_Side).Location = new Point(72, 20);
		((Control)CB_Message_Side).Name = "CB_Message_Side";
		((Control)CB_Message_Side).Size = new Size(231, 24);
		((Control)CB_Message_Side).TabIndex = 7;
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(13, 47);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(66, 19);
		((Control)Label8).TabIndex = 6;
		((Label)Label8).Text = "Message:";
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(13, 24);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(37, 19);
		((Control)Label9).TabIndex = 5;
		((Label)Label9).Text = "Side:";
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage5).Controls.Add((Control)(object)CB_MissionStatus_Status);
		((Control)TabPage5).Controls.Add((Control)(object)Label11);
		((Control)TabPage5).Controls.Add((Control)(object)CB_MissionStatus_Mission);
		((Control)TabPage5).Controls.Add((Control)(object)CB_MissionStatus_Side);
		((Control)TabPage5).Controls.Add((Control)(object)Label7);
		((Control)TabPage5).Controls.Add((Control)(object)Label10);
		TabPage5.Location = new Point(4, 24);
		((Control)TabPage5).Name = "TabPage5";
		((Control)TabPage5).Size = new Size(714, 354);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "Mission Status";
		((ComboBox)CB_MissionStatus_Status).BackColor = Color.Transparent;
		((ComboBox)CB_MissionStatus_Status).DrawMode = (DrawMode)1;
		((ComboBox)CB_MissionStatus_Status).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MissionStatus_Status).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MissionStatus_Status).FormattingEnabled = true;
		((ComboBox)CB_MissionStatus_Status).Items.AddRange(new object[2] { "Active", "Inactive" });
		((Control)CB_MissionStatus_Status).Location = new Point(73, 68);
		((Control)CB_MissionStatus_Status).Name = "CB_MissionStatus_Status";
		((Control)CB_MissionStatus_Status).Size = new Size(231, 24);
		((Control)CB_MissionStatus_Status).TabIndex = 14;
		Label11.AutoSize = true;
		((Control)Label11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label11).Location = new Point(13, 71);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(80, 19);
		((Control)Label11).TabIndex = 13;
		((Label)Label11).Text = "New status:";
		((ComboBox)CB_MissionStatus_Mission).BackColor = Color.Transparent;
		((ComboBox)CB_MissionStatus_Mission).DrawMode = (DrawMode)1;
		((ComboBox)CB_MissionStatus_Mission).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MissionStatus_Mission).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MissionStatus_Mission).FormattingEnabled = true;
		((Control)CB_MissionStatus_Mission).Location = new Point(73, 41);
		((Control)CB_MissionStatus_Mission).Name = "CB_MissionStatus_Mission";
		((Control)CB_MissionStatus_Mission).Size = new Size(231, 24);
		((Control)CB_MissionStatus_Mission).TabIndex = 12;
		((ComboBox)CB_MissionStatus_Side).BackColor = Color.Transparent;
		((ComboBox)CB_MissionStatus_Side).DrawMode = (DrawMode)1;
		((ComboBox)CB_MissionStatus_Side).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MissionStatus_Side).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MissionStatus_Side).FormattingEnabled = true;
		((Control)CB_MissionStatus_Side).Location = new Point(73, 14);
		((Control)CB_MissionStatus_Side).Name = "CB_MissionStatus_Side";
		((Control)CB_MissionStatus_Side).Size = new Size(231, 24);
		((Control)CB_MissionStatus_Side).TabIndex = 11;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(13, 44);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(59, 19);
		((Control)Label7).TabIndex = 10;
		((Label)Label7).Text = "Mission:";
		Label10.AutoSize = true;
		((Control)Label10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label10).Location = new Point(13, 17);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(37, 19);
		((Control)Label10).TabIndex = 9;
		((Label)Label10).Text = "Side:";
		TabPage6.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage6).Controls.Add((Control)(object)NUD_LuaScript);
		((Control)TabPage6).Controls.Add((Control)(object)Label13);
		((Control)TabPage6).Controls.Add((Control)(object)Button_AddLuaScript);
		((Control)TabPage6).Controls.Add((Control)(object)CB_LuaTemplate);
		((Control)TabPage6).Controls.Add((Control)(object)Label12);
		((Control)TabPage6).Controls.Add((Control)(object)TextPanel2);
		TabPage6.Location = new Point(4, 24);
		((Control)TabPage6).Name = "TabPage6";
		((Control)TabPage6).Padding = new Padding(3);
		((Control)TabPage6).Size = new Size(714, 354);
		TabPage6.TabIndex = 5;
		TabPage6.Text = "Lua script";
		NUD_LuaScript.BackColor = Color.FromArgb(69, 73, 74);
		((UpDownBase)NUD_LuaScript).BorderStyle = (BorderStyle)0;
		((Control)NUD_LuaScript).Font = new Font("Segoe UI", 10f);
		((UpDownBase)NUD_LuaScript).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD_LuaScript).Location = new Point(657, 7);
		((Control)NUD_LuaScript).Name = "NUD_LuaScript";
		((Control)NUD_LuaScript).Size = new Size(54, 26);
		((Control)NUD_LuaScript).TabIndex = 5;
		Label13.AutoSize = true;
		((Control)Label13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label13).Location = new Point(591, 9);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(63, 19);
		((Control)Label13).TabIndex = 4;
		((Label)Label13).Text = "Text Size:";
		((ButtonBase)Button_AddLuaScript).BackColor = Color.Transparent;
		((Control)Button_AddLuaScript).Font = new Font("Segoe UI", 10f);
		((Control)Button_AddLuaScript).ForeColor = SystemColors.Control;
		((Control)Button_AddLuaScript).Location = new Point(521, 9);
		((Control)Button_AddLuaScript).Name = "Button_AddLuaScript";
		((Control)Button_AddLuaScript).Padding = new Padding(5);
		Button_AddLuaScript.RoundRadius = 0;
		((Control)Button_AddLuaScript).Size = new Size(64, 21);
		((Control)Button_AddLuaScript).TabIndex = 3;
		Button_AddLuaScript.Text = "ADD";
		((ComboBox)CB_LuaTemplate).BackColor = Color.Transparent;
		((ComboBox)CB_LuaTemplate).DrawMode = (DrawMode)1;
		((ComboBox)CB_LuaTemplate).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_LuaTemplate).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_LuaTemplate).FormattingEnabled = true;
		((Control)CB_LuaTemplate).Location = new Point(109, 9);
		((Control)CB_LuaTemplate).Name = "CB_LuaTemplate";
		((Control)CB_LuaTemplate).Size = new Size(406, 24);
		((Control)CB_LuaTemplate).TabIndex = 2;
		Label12.AutoSize = true;
		((Control)Label12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label12).Location = new Point(6, 12);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(132, 19);
		((Control)Label12).TabIndex = 1;
		((Label)Label12).Text = "Add script template:";
		((Control)TextPanel2).Anchor = (AnchorStyles)15;
		((Control)TextPanel2).Font = new Font("Segoe UI", 10f);
		((Control)TextPanel2).Location = new Point(0, 37);
		((Control)TextPanel2).Name = "TextPanel2";
		((Control)TextPanel2).Size = new Size(714, 317);
		((Control)TextPanel2).TabIndex = 0;
		Label3.AutoSize = true;
		((Control)Label3).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(3, 48);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(131, 19);
		((Control)Label3).TabIndex = 21;
		((Label)Label3).Text = "Settings for action";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(651, 448);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 24;
		Button2.Text = "Cancel";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(4, 448);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 23;
		Button1.Text = "OK";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(727, 473);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TC_ActionOptions);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditAction";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit event action";
		((Control)TC_ActionOptions).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((ISupportInitialize)NUD_Points).EndInit();
		((Control)TabPage3).ResumeLayout(false);
		((Control)TabPage3).PerformLayout();
		((Control)TabPage4).ResumeLayout(false);
		((Control)TabPage4).PerformLayout();
		((Control)TabPage5).ResumeLayout(false);
		((Control)TabPage5).PerformLayout();
		((Control)TabPage6).ResumeLayout(false);
		((Control)TabPage6).PerformLayout();
		((ISupportInitialize)(object)NUD_LuaScript).EndInit();
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
			theEA = null;
			ListBox_UnitsToTeleport.Items.Clear();
			AreaEditor1.ReleaseReferences();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void EditAction_FormClosing(object sender, FormClosingEventArgs e)
	{
		eventActionsChangedEventHandler_0?.Invoke(Client.CurrentScenario);
		MyProject.Forms.ListActions.RefreshGrid();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void EditAction_Load(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_065e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Expected O, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Expected O, but got Unknown
		if (Information.IsNothing((object)theEA))
		{
			((Form)this).Close();
		}
		((TabControl)TC_ActionOptions).SizeMode = (TabSizeMode)0;
		TextBox1.Text = theEA.Description;
		((Control)Button1).Visible = true;
		((Control)Button2).Visible = ((Control)Button1).Visible;
		switch (theEA.Type)
		{
		case EventAction.EventActionType.Points:
		{
			((TabControl)TC_ActionOptions).SelectedIndex = 0;
			((ComboBox)CB_Points_Sides).BeginUpdate();
			((ComboBox)CB_Points_Sides).Items.Clear();
			((ListControl)CB_Points_Sides).DisplayMember = "Content";
			Side[] sides_ReadOnly2 = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly2)
			{
				ComboBoxItem val3 = new ComboBoxItem();
				((ContentControl)val3).Content = side2.Name;
				((FrameworkElement)val3).Tag = side2.ObjectID;
				((ComboBox)CB_Points_Sides).Items.Add((object)val3);
			}
			foreach (ComboBoxItem item in ((ComboBox)CB_Points_Sides).Items)
			{
				ComboBoxItem val4 = item;
				if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val4).Tag), ((EventAction_Points)theEA).SideID, true) == 0)
				{
					((ComboBox)CB_Points_Sides).SelectedItem = val4;
					break;
				}
			}
			((NumericUpDown)NUD_Points).Value = new decimal(((EventAction_Points)theEA).PointChange);
			((ComboBox)CB_Points_Sides).EndUpdate();
			goto default;
		}
		case EventAction.EventActionType.EndScenario:
			((TabControl)TC_ActionOptions).SelectedIndex = 1;
			goto default;
		case EventAction.EventActionType.TeleportInArea:
		{
			((TabControl)TC_ActionOptions).SelectedIndex = 2;
			ListBox_UnitsToTeleport.Items.Clear();
			DarkListItem darkListItem = new DarkListItem();
			List<int> list = new List<int>();
			List<ActiveUnit> list2 = Client.CurrentScenario.ActiveUnits_List.OrderBy([SpecialName] (ActiveUnit theAU) => theAU.Name, new NaturalSortComparer<string[]>()).ToList();
			foreach (ActiveUnit item2 in list2)
			{
				darkListItem = new DarkListItem(item2.Name + " [" + item2.ObjectID + "]");
				darkListItem.Tag = item2;
				ListBox_UnitsToTeleport.Items.Add(darkListItem);
				if (((EventAction_TeleportInArea)theEA).UnitIDs.Contains(item2.ObjectID))
				{
					list.Add(ListBox_UnitsToTeleport.Items.IndexOf(darkListItem));
				}
			}
			if (list.Count > 0)
			{
				ListBox_UnitsToTeleport.SelectItems(list);
			}
			AreaEditor1.AreaPoints = ((EventAction_TeleportInArea)theEA).Area;
			AreaEditor1.RefreshForm();
			goto default;
		}
		case EventAction.EventActionType.Message:
		{
			((TabControl)TC_ActionOptions).SelectedIndex = 3;
			((ComboBox)CB_Message_Side).BeginUpdate();
			((ComboBox)CB_Message_Side).Items.Clear();
			((ListControl)CB_Message_Side).DisplayMember = "Content";
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				ComboBoxItem val = new ComboBoxItem();
				((ContentControl)val).Content = side.Name;
				((FrameworkElement)val).Tag = side.ObjectID;
				((ComboBox)CB_Message_Side).Items.Add((object)val);
			}
			foreach (ComboBoxItem item3 in ((ComboBox)CB_Message_Side).Items)
			{
				ComboBoxItem val2 = item3;
				if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val2).Tag), ((EventAction_Message)theEA).SideID, true) == 0)
				{
					((ComboBox)CB_Message_Side).SelectedItem = val2;
					break;
				}
			}
			((ComboBox)CB_Message_Side).EndUpdate();
			if (!string.IsNullOrEmpty(((EventAction_Message)theEA).Text))
			{
				Editor_Message_Text.BodyHtml = ((EventAction_Message)theEA).Text;
			}
			goto default;
		}
		case EventAction.EventActionType.ChangeMissionStatus:
		{
			((TabControl)TC_ActionOptions).SelectedIndex = 4;
			if (Client.CurrentScenario.Sides_ReadOnly.Length == 0)
			{
				break;
			}
			Side side3 = Client.CurrentScenario.Sides_ReadOnly[0];
			((ComboBox)CB_MissionStatus_Side).Items.Clear();
			((ListControl)CB_MissionStatus_Side).DisplayMember = "Content";
			Side[] sides_ReadOnly3 = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side4 in sides_ReadOnly3)
			{
				ComboBoxItem val5 = new ComboBoxItem();
				((ContentControl)val5).Content = side4.Name;
				((FrameworkElement)val5).Tag = side4.ObjectID;
				((ComboBox)CB_MissionStatus_Side).Items.Add((object)val5);
			}
			Side[] sides_ReadOnly4 = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side5 in sides_ReadOnly4)
			{
				foreach (Mission mission2 in side5.Missions)
				{
					if (Operators.CompareString(mission2.ObjectID, ((EventAction_ChangeMissionStatus)theEA).MissionID, true) != 0)
					{
						continue;
					}
					foreach (ComboBoxItem item4 in ((ComboBox)CB_MissionStatus_Side).Items)
					{
						ComboBoxItem val6 = item4;
						if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val6).Tag), side5.ObjectID, true) == 0)
						{
							side3 = side5;
							((ComboBox)CB_MissionStatus_Side).SelectedItem = val6;
							break;
						}
					}
				}
			}
			if (Client.CurrentSide.Missions.Count != 0)
			{
				((ComboBox)CB_MissionStatus_Mission).BeginUpdate();
				((ComboBox)CB_MissionStatus_Mission).Items.Clear();
				((ListControl)CB_MissionStatus_Mission).DisplayMember = "Content";
				foreach (Mission mission3 in side3.Missions)
				{
					ComboBoxItem val7 = new ComboBoxItem();
					((ContentControl)val7).Content = mission3.Name;
					((FrameworkElement)val7).Tag = mission3.ObjectID;
					((ComboBox)CB_MissionStatus_Mission).Items.Add((object)val7);
				}
				if (side3.Missions.Count > 0)
				{
					Mission mission = side3.Missions[0];
					foreach (Mission mission4 in side3.Missions)
					{
						if (Operators.CompareString(mission4.ObjectID, ((EventAction_ChangeMissionStatus)theEA).MissionID, true) == 0)
						{
							mission = mission4;
							break;
						}
					}
					foreach (ComboBoxItem item5 in ((ComboBox)CB_MissionStatus_Mission).Items)
					{
						ComboBoxItem val8 = item5;
						if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val8).Tag), mission.ObjectID, true) == 0)
						{
							((ComboBox)CB_MissionStatus_Mission).SelectedItem = val8;
							break;
						}
					}
				}
				((ComboBox)CB_MissionStatus_Mission).EndUpdate();
				((ComboBox)CB_MissionStatus_Status).SelectedIndex = (int)((EventAction_ChangeMissionStatus)theEA).NewStatus;
			}
			goto default;
		}
		case EventAction.EventActionType.LuaScript:
			((TabControl)TC_ActionOptions).SelectedIndex = 5;
			luaConsole_0 = new LuaConsole(TextPanel2);
			luaConsole_0.TextArea.WrapMode = WrapMode.Word;
			if (!string.IsNullOrEmpty(((EventAction_LuaScript)theEA).ScriptText))
			{
				luaConsole_0.TextArea.Text = ((EventAction_LuaScript)theEA).ScriptText;
			}
			((NumericUpDown)NUD_LuaScript).Value = new decimal(luaConsole_0.TextArea.Font.Size);
			((ComboBox)CB_LuaTemplate).Items.AddRange((object[])LuaSandBox.LuaMethods.OrderBy([SpecialName] (string s) => s).ToArray());
			((ComboBox)CB_LuaTemplate).SelectedIndex = 0;
			goto default;
		default:
			TC_ActionOptions.HideNonSelectedTabs();
			break;
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		switch (theEA.Type)
		{
		case EventAction.EventActionType.TeleportInArea:
		{
			if (((EventAction_TeleportInArea)theEA).Area.Count < 3)
			{
				DarkMessageBox.ShowError("You must define at least 3 reference points for the teleport area.", "Not enough reference points!");
				return;
			}
			HashSet<string> hashSet = new HashSet<string>();
			foreach (DarkListItem selectedItem in ListBox_UnitsToTeleport.SelectedItems)
			{
				hashSet.Add(((ActiveUnit)selectedItem.Tag).ObjectID);
			}
			((EventAction_TeleportInArea)theEA).UnitIDs = hashSet;
			break;
		}
		case EventAction.EventActionType.Message:
			((EventAction_Message)theEA).Text = Editor_Message_Text.BodyHtml;
			break;
		case EventAction.EventActionType.LuaScript:
			((EventAction_LuaScript)theEA).ScriptText = luaConsole_0.TextArea.Text;
			break;
		}
		theEA.Description = TextBox1.Text;
		switch (Action)
		{
		case _FormAction.AddNew:
			Client.CurrentScenario.EventActions.TryAdd(theEA.ObjectID, theEA);
			break;
		}
		((Form)this).Close();
	}

	private void method_4(object sender, EventArgs e)
	{
		((EventAction_Points)theEA).SideID = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_Points_Sides).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
	}

	private void method_5(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_Points).Value))
		{
			((EventAction_Points)theEA).PointChange = Convert.ToInt32(((NumericUpDown)NUD_Points).Value);
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)theEA))
		{
			((EventAction_Message)theEA).SideID = Conversions.ToString(((FrameworkElement)(ComboBoxItem)((ComboBox)CB_Message_Side).SelectedItem).Tag);
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)theEA))
		{
			((EventAction_Message)theEA).Text = ((UserControl)Editor_Message_Text).Text;
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		if (Client.CurrentScenario.Sides_ReadOnly.Length == 0)
		{
			return;
		}
		Side side = Client.CurrentScenario.Sides_ReadOnly[0];
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side2 in sides_ReadOnly)
		{
			if (Operators.CompareString(side2.ObjectID, Conversions.ToString(((FrameworkElement)(ComboBoxItem)((ComboBox)CB_MissionStatus_Side).SelectedItem).Tag), true) == 0)
			{
				side = side2;
				break;
			}
		}
		((ComboBox)CB_MissionStatus_Mission).BeginUpdate();
		((ComboBox)CB_MissionStatus_Mission).Items.Clear();
		((ListControl)CB_MissionStatus_Mission).DisplayMember = "Content";
		foreach (Mission mission in side.Missions)
		{
			ComboBoxItem val = new ComboBoxItem();
			((ContentControl)val).Content = mission.Name;
			((FrameworkElement)val).Tag = mission.ObjectID;
			((ComboBox)CB_MissionStatus_Mission).Items.Add((object)val);
		}
		if (!Information.IsNothing((object)theEA) && !Information.IsNothing(RuntimeHelpers.GetObjectValue(((ComboBox)CB_MissionStatus_Mission).SelectedItem)))
		{
			((EventAction_ChangeMissionStatus)theEA).MissionID = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_MissionStatus_Mission).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			if (side.Missions.Count > 0)
			{
				((ComboBox)CB_MissionStatus_Status).SelectedIndex = (int)side.Missions[0].get_Status(Client.CurrentScenario);
			}
		}
		((ComboBox)CB_MissionStatus_Mission).EndUpdate();
	}

	private void method_9(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)theEA))
		{
			((EventAction_ChangeMissionStatus)theEA).MissionID = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_MissionStatus_Mission).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
	}

	private void aBmSmiBvuuA(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)theEA))
		{
			((EventAction_ChangeMissionStatus)theEA).NewStatus = (Mission.MissionStatus)((ComboBox)CB_MissionStatus_Status).SelectedIndex;
		}
	}

	private void EditAction_KeyDown(object sender, KeyEventArgs e)
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

	private void method_10(object sender, EventArgs e)
	{
		luaConsole_0.TextArea.Text = luaConsole_0.TextArea.Text.Insert(luaConsole_0.TextArea.SelectionStart, Conversions.ToString(((ComboBox)CB_LuaTemplate).SelectedItem));
	}

	private void method_11(object sender, EventArgs e)
	{
		Editor_Message_Text.HtmlContentsEdit();
	}

	private void method_12(object object_0)
	{
		theEA.Description = TextBox1.Text;
	}

	private void method_13(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_LuaScript).Value) && Convert.ToInt32(((NumericUpDown)NUD_LuaScript).Value) > 0)
		{
			luaConsole_0.TextArea.Zoom = (int)Math.Round((float)Convert.ToInt32(((NumericUpDown)NUD_LuaScript).Value) - luaConsole_0.TextArea.Font.Size);
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_LuaScript).Value) && Convert.ToInt32(((NumericUpDown)NUD_LuaScript).Value) > 0)
		{
			luaConsole_0.TextArea.Zoom = (int)Math.Round((float)Convert.ToInt32(((NumericUpDown)NUD_LuaScript).Value) - luaConsole_0.TextArea.Font.Size);
		}
	}

	static EditAction()
	{
		Class72.smethod_20();
	}
}

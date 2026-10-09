using System;
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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditCondition : DarkSecondaryFormBase
{
	public delegate void EventConditionsChangedEventHandler(Scenario theScen);

	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox _TextBox1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ObserverSides")]
	private DarkUIComboBox _CB_ObserverSides;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Postures")]
	private DarkUIComboBox _CB_Postures;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TargetSides")]
	private DarkUIComboBox _CB_TargetSides;

	[AccessedThroughProperty("CB_SidePosture_ModifierNOT")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SidePosture_ModifierNOT;

	[AccessedThroughProperty("CB_ScenHasStarted_ModifierNOT")]
	[CompilerGenerated]
	private DarkCheckBox _CB_ScenHasStarted_ModifierNOT;

	[AccessedThroughProperty("NUD_LuaScript")]
	[CompilerGenerated]
	private GClass9 _NUD_LuaScript;

	[AccessedThroughProperty("Button_AddLuaScript")]
	[CompilerGenerated]
	private DarkUIButton _Button_AddLuaScript;

	public EventCondition theEC;

	public _FormAction Action;

	[CompilerGenerated]
	private static EventConditionsChangedEventHandler eventConditionsChangedEventHandler_0;

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
			DarkUITextBox.TextChangedEventHandler value2 = method_7;
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

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	internal virtual DarkUIComboBox CB_ObserverSides
	{
		[CompilerGenerated]
		get
		{
			return _CB_ObserverSides;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIComboBox darkUIComboBox = _CB_ObserverSides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_ObserverSides = value;
			darkUIComboBox = _CB_ObserverSides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TC_ConditionOptions")]
	internal virtual DarkUITabControl TC_ConditionOptions { get; set; }

	internal virtual DarkUIComboBox CB_Postures
	{
		[CompilerGenerated]
		get
		{
			return _CB_Postures;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIComboBox darkUIComboBox = _CB_Postures;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_Postures = value;
			darkUIComboBox = _CB_Postures;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	internal virtual DarkUIComboBox CB_TargetSides
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetSides;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIComboBox darkUIComboBox = _CB_TargetSides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_TargetSides = value;
			darkUIComboBox = _CB_TargetSides;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	internal virtual DarkCheckBox CB_SidePosture_ModifierNOT
	{
		[CompilerGenerated]
		get
		{
			return _CB_SidePosture_ModifierNOT;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkCheckBox darkCheckBox = _CB_SidePosture_ModifierNOT;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SidePosture_ModifierNOT = value;
			darkCheckBox = _CB_SidePosture_ModifierNOT;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	internal virtual DarkCheckBox CB_ScenHasStarted_ModifierNOT
	{
		[CompilerGenerated]
		get
		{
			return _CB_ScenHasStarted_ModifierNOT;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkCheckBox darkCheckBox = _CB_ScenHasStarted_ModifierNOT;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ScenHasStarted_ModifierNOT = value;
			darkCheckBox = _CB_ScenHasStarted_ModifierNOT;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

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
			EventHandler eventHandler = method_11;
			EventHandler eventHandler2 = method_12;
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

	[field: AccessedThroughProperty("TextBox2")]
	internal virtual DarkUITextBox TextBox2 { get; set; }

	public static event EventConditionsChangedEventHandler EventConditionsChanged
	{
		[CompilerGenerated]
		add
		{
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler = eventConditionsChangedEventHandler_0;
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler2;
			do
			{
				eventConditionsChangedEventHandler2 = eventConditionsChangedEventHandler;
				EventConditionsChangedEventHandler value2 = (EventConditionsChangedEventHandler)Delegate.Combine(eventConditionsChangedEventHandler2, value);
				eventConditionsChangedEventHandler = Interlocked.CompareExchange(ref eventConditionsChangedEventHandler_0, value2, eventConditionsChangedEventHandler2);
			}
			while ((object)eventConditionsChangedEventHandler != eventConditionsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler = eventConditionsChangedEventHandler_0;
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler2;
			do
			{
				eventConditionsChangedEventHandler2 = eventConditionsChangedEventHandler;
				EventConditionsChangedEventHandler value2 = (EventConditionsChangedEventHandler)Delegate.Remove(eventConditionsChangedEventHandler2, value);
				eventConditionsChangedEventHandler = Interlocked.CompareExchange(ref eventConditionsChangedEventHandler_0, value2, eventConditionsChangedEventHandler2);
			}
			while ((object)eventConditionsChangedEventHandler != eventConditionsChangedEventHandler2);
		}
	}

	public EditCondition()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(EditCondition_FormClosing);
		((Form)this).Load += EditCondition_Load;
		((Control)this).KeyDown += new KeyEventHandler(EditCondition_KeyDown);
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
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Expected O, but got Unknown
		//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07db: Expected O, but got Unknown
		//IL_094c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0956: Expected O, but got Unknown
		//IL_0a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a95: Expected O, but got Unknown
		//IL_0cf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d02: Expected O, but got Unknown
		//IL_0e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2f: Expected O, but got Unknown
		//IL_0e6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef5: Expected O, but got Unknown
		//IL_1014: Unknown result type (might be due to invalid IL or missing references)
		//IL_101e: Expected O, but got Unknown
		TextBox1 = new DarkUITextBox();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		TabPage1 = new TabPage();
		CB_Postures = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_TargetSides = new DarkUIComboBox();
		Label6 = new DarkLabel();
		CB_SidePosture_ModifierNOT = new DarkCheckBox();
		CB_ObserverSides = new DarkUIComboBox();
		Label1 = new DarkLabel();
		TC_ConditionOptions = new DarkUITabControl();
		TabPage2 = new TabPage();
		CB_ScenHasStarted_ModifierNOT = new DarkCheckBox();
		TabPage3 = new TabPage();
		NUD_LuaScript = new GClass9();
		Label13 = new DarkLabel();
		Button_AddLuaScript = new DarkUIButton();
		CB_LuaTemplate = new DarkUIComboBox();
		Label12 = new DarkLabel();
		TextBox2 = new DarkUITextBox();
		((Control)TabPage1).SuspendLayout();
		((Control)TC_ConditionOptions).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)TabPage3).SuspendLayout();
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
		((Control)Label2).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(4, 16);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(75, 13);
		((Control)Label2).TabIndex = 5;
		((Label)Label2).Text = "Description:";
		Label3.AutoSize = true;
		((Control)Label3).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(3, 48);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(120, 13);
		((Control)Label3).TabIndex = 21;
		((Label)Label3).Text = "Settings for condition";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
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
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(4, 448);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 23;
		Button1.Text = "OK";
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)CB_Postures);
		((Control)TabPage1).Controls.Add((Control)(object)Label7);
		((Control)TabPage1).Controls.Add((Control)(object)CB_TargetSides);
		((Control)TabPage1).Controls.Add((Control)(object)Label6);
		((Control)TabPage1).Controls.Add((Control)(object)CB_SidePosture_ModifierNOT);
		((Control)TabPage1).Controls.Add((Control)(object)CB_ObserverSides);
		((Control)TabPage1).Controls.Add((Control)(object)Label1);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(714, 354);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Side Posture";
		((ComboBox)CB_Postures).BackColor = Color.Transparent;
		((ComboBox)CB_Postures).DrawMode = (DrawMode)1;
		((ComboBox)CB_Postures).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Postures).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Postures).FormattingEnabled = true;
		((ComboBox)CB_Postures).Items.AddRange(new object[5] { "Neutral", "Friendly", "Unfriendly", "Hostile", "Unknown" });
		((Control)CB_Postures).Location = new Point(557, 56);
		((Control)CB_Postures).Name = "CB_Postures";
		((Control)CB_Postures).Size = new Size(130, 21);
		((Control)CB_Postures).TabIndex = 13;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(530, 59);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(21, 13);
		((Control)Label7).TabIndex = 12;
		((Label)Label7).Text = "as:";
		((ComboBox)CB_TargetSides).BackColor = Color.Transparent;
		((ComboBox)CB_TargetSides).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetSides).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetSides).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_TargetSides).FormattingEnabled = true;
		((Control)CB_TargetSides).Location = new Point(332, 56);
		((Control)CB_TargetSides).Name = "CB_TargetSides";
		((Control)CB_TargetSides).Size = new Size(192, 21);
		((Control)CB_TargetSides).TabIndex = 11;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(249, 59);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(77, 13);
		((Control)Label6).TabIndex = 10;
		((Label)Label6).Text = "considers side:";
		((ButtonBase)CB_SidePosture_ModifierNOT).BackColor = Color.FromArgb(39, 39, 39);
		((Control)CB_SidePosture_ModifierNOT).Location = new Point(17, 24);
		((Control)CB_SidePosture_ModifierNOT).Name = "CB_SidePosture_ModifierNOT";
		((Control)CB_SidePosture_ModifierNOT).Size = new Size(92, 17);
		((Control)CB_SidePosture_ModifierNOT).TabIndex = 9;
		((ButtonBase)CB_SidePosture_ModifierNOT).Text = "Modifier: NOT";
		((ComboBox)CB_ObserverSides).BackColor = Color.Transparent;
		((ComboBox)CB_ObserverSides).DrawMode = (DrawMode)1;
		((ComboBox)CB_ObserverSides).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ObserverSides).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_ObserverSides).FormattingEnabled = true;
		((Control)CB_ObserverSides).Location = new Point(51, 56);
		((Control)CB_ObserverSides).Name = "CB_ObserverSides";
		((Control)CB_ObserverSides).Size = new Size(192, 21);
		((Control)CB_ObserverSides).TabIndex = 2;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(14, 59);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(31, 13);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Side:";
		((Control)TC_ConditionOptions).Anchor = (AnchorStyles)14;
		((Control)TC_ConditionOptions).Controls.Add((Control)(object)TabPage1);
		((Control)TC_ConditionOptions).Controls.Add((Control)(object)TabPage2);
		((Control)TC_ConditionOptions).Controls.Add((Control)(object)TabPage3);
		((Control)TC_ConditionOptions).Cursor = Cursors.Hand;
		((Control)TC_ConditionOptions).Font = new Font("Segoe UI", 8f);
		((TabControl)TC_ConditionOptions).ItemSize = new Size(80, 20);
		((Control)TC_ConditionOptions).Location = new Point(4, 64);
		((TabControl)TC_ConditionOptions).Multiline = true;
		((Control)TC_ConditionOptions).Name = "TC_ConditionOptions";
		((TabControl)TC_ConditionOptions).SelectedIndex = 0;
		((Control)TC_ConditionOptions).Size = new Size(722, 382);
		((Control)TC_ConditionOptions).TabIndex = 22;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)CB_ScenHasStarted_ModifierNOT);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Size = new Size(714, 354);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Scenario Has Started";
		((Control)CB_ScenHasStarted_ModifierNOT).Location = new Point(16, 14);
		((Control)CB_ScenHasStarted_ModifierNOT).Name = "CB_ScenHasStarted_ModifierNOT";
		((Control)CB_ScenHasStarted_ModifierNOT).Size = new Size(92, 17);
		((Control)CB_ScenHasStarted_ModifierNOT).TabIndex = 10;
		((ButtonBase)CB_ScenHasStarted_ModifierNOT).Text = "Modifier: NOT";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)NUD_LuaScript);
		((Control)TabPage3).Controls.Add((Control)(object)Label13);
		((Control)TabPage3).Controls.Add((Control)(object)Button_AddLuaScript);
		((Control)TabPage3).Controls.Add((Control)(object)CB_LuaTemplate);
		((Control)TabPage3).Controls.Add((Control)(object)Label12);
		((Control)TabPage3).Controls.Add((Control)(object)TextBox2);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Size = new Size(714, 354);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Lua Script";
		NUD_LuaScript.BackColor = Color.Transparent;
		((Control)NUD_LuaScript).Font = new Font("Segoe UI", 10f);
		((Control)NUD_LuaScript).Location = new Point(669, 4);
		((NumericUpDown)NUD_LuaScript).Maximum = 100m;
		((NumericUpDown)NUD_LuaScript).Minimum = 0m;
		((Control)NUD_LuaScript).Name = "NUD_LuaScript";
		((Control)NUD_LuaScript).Size = new Size(45, 26);
		((Control)NUD_LuaScript).TabIndex = 11;
		((NumericUpDown)NUD_LuaScript).Value = 0m;
		((Control)Label13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label13).Location = new Point(609, 10);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(54, 13);
		((Control)Label13).TabIndex = 10;
		((Label)Label13).Text = "Text Size:";
		((ButtonBase)Button_AddLuaScript).BackColor = Color.Transparent;
		((Button)Button_AddLuaScript).DialogResult = (DialogResult)0;
		((Control)Button_AddLuaScript).Font = new Font("Segoe UI", 10f);
		((Control)Button_AddLuaScript).ForeColor = SystemColors.Control;
		((Control)Button_AddLuaScript).Location = new Point(533, 6);
		((Control)Button_AddLuaScript).Name = "Button_AddLuaScript";
		((Control)Button_AddLuaScript).Padding = new Padding(5);
		Button_AddLuaScript.RoundRadius = 0;
		((Control)Button_AddLuaScript).Size = new Size(75, 24);
		((Control)Button_AddLuaScript).TabIndex = 9;
		Button_AddLuaScript.Text = "ADD";
		((ComboBox)CB_LuaTemplate).BackColor = Color.Transparent;
		((ComboBox)CB_LuaTemplate).DrawMode = (DrawMode)1;
		((ComboBox)CB_LuaTemplate).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_LuaTemplate).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_LuaTemplate).FormattingEnabled = true;
		((Control)CB_LuaTemplate).Location = new Point(110, 6);
		((Control)CB_LuaTemplate).Name = "CB_LuaTemplate";
		((Control)CB_LuaTemplate).Size = new Size(417, 21);
		((Control)CB_LuaTemplate).TabIndex = 8;
		((Control)Label12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label12).Location = new Point(7, 9);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(100, 13);
		((Control)Label12).TabIndex = 7;
		((Label)Label12).Text = "Add script template:";
		((Control)TextBox2).Anchor = (AnchorStyles)15;
		TextBox2.AutoCompleteCustomSource = null;
		TextBox2.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox2.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox2).BackColor = Color.FromArgb(69, 73, 74);
		TextBox2.Font = new Font("Segoe UI", 10f);
		((Control)TextBox2).ForeColor = Color.FromArgb(220, 220, 220);
		TextBox2.Image = null;
		TextBox2.Lines = null;
		((Control)TextBox2).Location = new Point(0, 36);
		TextBox2.MaxLength = 999999999;
		TextBox2.Multiline = true;
		((Control)TextBox2).Name = "TextBox2";
		TextBox2.ReadOnly = false;
		TextBox2.ScrollBars = (ScrollBars)2;
		TextBox2.SelectionStart = 0;
		((Control)TextBox2).Size = new Size(714, 318);
		((Control)TextBox2).TabIndex = 6;
		TextBox2.TextAlign = (HorizontalAlignment)0;
		TextBox2.UseSystemPasswordChar = false;
		TextBox2.WatermarkText = "";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(727, 473);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TC_ConditionOptions);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditCondition";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit event condition";
		((Control)TabPage1).ResumeLayout(false);
		((Control)TC_ConditionOptions).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage3).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EditCondition_FormClosing(object sender, FormClosingEventArgs e)
	{
		eventConditionsChangedEventHandler_0?.Invoke(Client.CurrentScenario);
		MyProject.Forms.ListConditions.RefreshGrid();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void EditCondition_Load(object sender, EventArgs e)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		if (Information.IsNothing((object)theEC))
		{
			((Form)this).Close();
		}
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		TextBox1.Text = theEC.Description;
		((Control)Button1).Visible = true;
		((Control)Button2).Visible = ((Control)Button1).Visible;
		switch (theEC.Type)
		{
		case EventCondition.EventConditionType.SidePosture:
		{
			((TabControl)TC_ConditionOptions).SelectedIndex = 0;
			((ComboBox)CB_ObserverSides).BeginUpdate();
			((ComboBox)CB_ObserverSides).Items.Clear();
			((ListControl)CB_ObserverSides).DisplayMember = "Content";
			((CheckBox)CB_SidePosture_ModifierNOT).Checked = ((EventCondition_SidePosture)theEC).Modifier_NOT;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				ComboBoxItem val = new ComboBoxItem();
				((ContentControl)val).Content = side.Name;
				((FrameworkElement)val).Tag = side.ObjectID;
				((ComboBox)CB_ObserverSides).Items.Add((object)val);
			}
			foreach (ComboBoxItem item in ((ComboBox)CB_ObserverSides).Items)
			{
				ComboBoxItem val2 = item;
				if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val2).Tag), ((EventCondition_SidePosture)theEC).ObserverSide_ID, true) == 0)
				{
					((ComboBox)CB_ObserverSides).SelectedItem = val2;
					break;
				}
			}
			((ComboBox)CB_ObserverSides).EndUpdate();
			((ComboBox)CB_TargetSides).BeginUpdate();
			((ComboBox)CB_TargetSides).Items.Clear();
			((ListControl)CB_TargetSides).DisplayMember = "Content";
			Side[] sides_ReadOnly2 = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly2)
			{
				ComboBoxItem val3 = new ComboBoxItem();
				((ContentControl)val3).Content = side2.Name;
				((FrameworkElement)val3).Tag = side2.ObjectID;
				((ComboBox)CB_TargetSides).Items.Add((object)val3);
			}
			foreach (ComboBoxItem item2 in ((ComboBox)CB_TargetSides).Items)
			{
				ComboBoxItem val4 = item2;
				if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val4).Tag), ((EventCondition_SidePosture)theEC).TargetSide_ID, true) == 0)
				{
					((ComboBox)CB_TargetSides).SelectedItem = val4;
					break;
				}
			}
			((ComboBox)CB_TargetSides).EndUpdate();
			((ComboBox)CB_Postures).SelectedIndex = (int)((EventCondition_SidePosture)theEC).TargetPosture;
			break;
		}
		case EventCondition.EventConditionType.ScenHasStarted:
			((TabControl)TC_ConditionOptions).SelectedIndex = 1;
			((CheckBox)CB_ScenHasStarted_ModifierNOT).Checked = ((EventCondition_ScenHasStarted)theEC).Modifier_NOT;
			break;
		case EventCondition.EventConditionType.LuaScript:
			((TabControl)TC_ConditionOptions).SelectedIndex = 2;
			((NumericUpDown)NUD_LuaScript).Value = new decimal((int)Math.Round(TextBox2.Font.Size));
			TextBox2.Text = ((EventCondition_LuaScript)theEC).ScriptText;
			((ComboBox)CB_LuaTemplate).Items.AddRange((object[])LuaSandBox.LuaMethods.OrderBy([SpecialName] (string s) => s).ToArray());
			((ComboBox)CB_LuaTemplate).SelectedIndex = 0;
			break;
		}
		TC_ConditionOptions.HideNonSelectedTabs();
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		EventCondition.EventConditionType type = theEC.Type;
		if (type == EventCondition.EventConditionType.LuaScript)
		{
			((EventCondition_LuaScript)theEC).ScriptText = TextBox2.Text;
		}
		switch (Action)
		{
		case _FormAction.AddNew:
			Client.CurrentScenario.EventConditions.TryAdd(theEC.ObjectID, theEC);
			break;
		}
		((Form)this).Close();
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		((EventCondition_SidePosture)theEC).ObserverSide_ID = Conversions.ToString(((FrameworkElement)(ComboBoxItem)((ComboBox)CB_ObserverSides).SelectedItem).Tag);
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		((EventCondition_SidePosture)theEC).TargetSide_ID = Conversions.ToString(((FrameworkElement)(ComboBoxItem)((ComboBox)CB_TargetSides).SelectedItem).Tag);
	}

	private void method_6(object sender, EventArgs e)
	{
		((EventCondition_SidePosture)theEC).TargetPosture = (Misc.PostureStance)((ComboBox)CB_Postures).SelectedIndex;
	}

	private void method_7(object object_0)
	{
		theEC.Description = TextBox1.Text;
	}

	private void EditCondition_KeyDown(object sender, KeyEventArgs e)
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

	private void method_8(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)theEC) && theEC.Type == EventCondition.EventConditionType.SidePosture)
		{
			((EventCondition_SidePosture)theEC).Modifier_NOT = ((CheckBox)CB_SidePosture_ModifierNOT).Checked;
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)theEC) && theEC.Type == EventCondition.EventConditionType.ScenHasStarted)
		{
			((EventCondition_ScenHasStarted)theEC).Modifier_NOT = ((CheckBox)CB_ScenHasStarted_ModifierNOT).Checked;
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		TextBox2.Text = TextBox2.Text.Insert(TextBox2.SelectionStart, Conversions.ToString(((ComboBox)CB_LuaTemplate).SelectedItem));
	}

	private void method_11(object sender, EventArgs e)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_LuaScript).Value))
		{
			TextBox2.Font = new Font(TextBox2.Font.FontFamily, Convert.ToSingle(((NumericUpDown)NUD_LuaScript).Value));
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_LuaScript).Value))
		{
			TextBox2.Font = new Font(TextBox2.Font.FontFamily, Convert.ToSingle(((NumericUpDown)NUD_LuaScript).Value));
		}
	}

	static EditCondition()
	{
		Class72.smethod_20();
	}
}

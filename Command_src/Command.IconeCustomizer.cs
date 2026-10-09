using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class IconeCustomizer : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_SelectedUnits")]
	private DarkListView _LV_SelectedUnits;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Confirm")]
	private DarkUIButton _Button_Confirm;

	[AccessedThroughProperty("ButtonRestoreDefault")]
	[CompilerGenerated]
	private DarkUIButton _ButtonRestoreDefault;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OpenFolder2")]
	private DarkUIButton _Button_OpenFolder2;

	[AccessedThroughProperty("Button_OpenFolder1")]
	[CompilerGenerated]
	private DarkUIButton _Button_OpenFolder1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Reload")]
	private DarkUIButton _Button_Reload;

	[AccessedThroughProperty("Button_Reload2")]
	[CompilerGenerated]
	private DarkUIButton _Button_Reload2;

	private string string_0;

	private string string_1;

	internal virtual DarkListView LV_SelectedUnits
	{
		[CompilerGenerated]
		get
		{
			return _LV_SelectedUnits;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_6;
			DarkListView darkListView = _LV_SelectedUnits;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LV_SelectedUnits = value;
			darkListView = _LV_SelectedUnits;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("IconContainer")]
	internal virtual FlowLayoutPanel IconContainer { get; set; }

	internal virtual DarkUIButton Button_Confirm
	{
		[CompilerGenerated]
		get
		{
			return _Button_Confirm;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_Confirm;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Confirm = value;
			darkUIButton = _Button_Confirm;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonRestoreDefault
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRestoreDefault;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _ButtonRestoreDefault;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonRestoreDefault = value;
			darkUIButton = _ButtonRestoreDefault;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Button4")]
	internal virtual Button Button4 { get; set; }

	[field: AccessedThroughProperty("Button1")]
	internal virtual Button Button1 { get; set; }

	[field: AccessedThroughProperty("Button2")]
	internal virtual Button Button2 { get; set; }

	[field: AccessedThroughProperty("Button3")]
	internal virtual Button Button3 { get; set; }

	[field: AccessedThroughProperty("Button6")]
	internal virtual Button Button6 { get; set; }

	[field: AccessedThroughProperty("Button7")]
	internal virtual Button Button7 { get; set; }

	[field: AccessedThroughProperty("Button11")]
	internal virtual Button Button11 { get; set; }

	[field: AccessedThroughProperty("Button12")]
	internal virtual Button Button12 { get; set; }

	[field: AccessedThroughProperty("Button13")]
	internal virtual Button Button13 { get; set; }

	[field: AccessedThroughProperty("Button14")]
	internal virtual Button Button14 { get; set; }

	[field: AccessedThroughProperty("Button15")]
	internal virtual Button Button15 { get; set; }

	[field: AccessedThroughProperty("Button16")]
	internal virtual Button Button16 { get; set; }

	[field: AccessedThroughProperty("Button18")]
	internal virtual Button Button18 { get; set; }

	[field: AccessedThroughProperty("Button19")]
	internal virtual Button Button19 { get; set; }

	[field: AccessedThroughProperty("Button20")]
	internal virtual Button Button20 { get; set; }

	[field: AccessedThroughProperty("Button21")]
	internal virtual Button Button21 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3 { get; set; }

	internal virtual DarkUIButton Button_OpenFolder2
	{
		[CompilerGenerated]
		get
		{
			return _Button_OpenFolder2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			DarkUIButton darkUIButton = _Button_OpenFolder2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OpenFolder2 = value;
			darkUIButton = _Button_OpenFolder2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox4")]
	internal virtual DarkGroupBox DarkGroupBox4 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox5")]
	internal virtual DarkGroupBox DarkGroupBox5 { get; set; }

	[field: AccessedThroughProperty("TB_Examples")]
	internal virtual RichTextBox TB_Examples { get; set; }

	internal virtual DarkUIButton Button_OpenFolder1
	{
		[CompilerGenerated]
		get
		{
			return _Button_OpenFolder1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			DarkUIButton darkUIButton = _Button_OpenFolder1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OpenFolder1 = value;
			darkUIButton = _Button_OpenFolder1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Button22")]
	internal virtual Button Button22 { get; set; }

	[field: AccessedThroughProperty("Button23")]
	internal virtual Button Button23 { get; set; }

	[field: AccessedThroughProperty("Button24")]
	internal virtual Button Button24 { get; set; }

	[field: AccessedThroughProperty("Button5")]
	internal virtual Button Button5 { get; set; }

	[field: AccessedThroughProperty("Button8")]
	internal virtual Button Button8 { get; set; }

	[field: AccessedThroughProperty("Button9")]
	internal virtual Button Button9 { get; set; }

	[field: AccessedThroughProperty("Button10")]
	internal virtual Button Button10 { get; set; }

	[field: AccessedThroughProperty("Button25")]
	internal virtual Button Button25 { get; set; }

	[field: AccessedThroughProperty("Button26")]
	internal virtual Button Button26 { get; set; }

	[field: AccessedThroughProperty("Button27")]
	internal virtual Button Button27 { get; set; }

	[field: AccessedThroughProperty("Button28")]
	internal virtual Button Button28 { get; set; }

	[field: AccessedThroughProperty("CurrentSelection")]
	internal virtual PictureBox CurrentSelection { get; set; }

	internal virtual DarkUIButton Button_Reload
	{
		[CompilerGenerated]
		get
		{
			return _Button_Reload;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button_Reload;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Reload = value;
			darkUIButton = _Button_Reload;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	[field: AccessedThroughProperty("TB_Structure")]
	internal virtual RichTextBox TB_Structure { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	[field: AccessedThroughProperty("TB_Synthax")]
	internal virtual RichTextBox TB_Synthax { get; set; }

	[field: AccessedThroughProperty("DarkUITabControl1")]
	internal virtual DarkUITabControl DarkUITabControl1 { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	internal virtual DarkUIButton Button_Reload2
	{
		[CompilerGenerated]
		get
		{
			return _Button_Reload2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button_Reload2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Reload2 = value;
			darkUIButton = _Button_Reload2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public string CurrentIconSelected
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			try
			{
				((Control)CurrentSelection).BackgroundImage = Image.FromFile(Client.GetCustomIconPath(string_0));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				((Control)CurrentSelection).BackgroundImage = null;
				ProjectData.ClearProjectError();
			}
		}
	}

	public IconeCustomizer()
	{
		((Form)this).Load += IconeCustomizer_Load;
		string_0 = "";
		string_1 = "";
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_0bb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc1: Expected O, but got Unknown
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Expected O, but got Unknown
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d04: Expected O, but got Unknown
		//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da6: Expected O, but got Unknown
		//IL_0e41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4b: Expected O, but got Unknown
		//IL_0ee6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef0: Expected O, but got Unknown
		//IL_0f89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f93: Expected O, but got Unknown
		//IL_102d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1037: Expected O, but got Unknown
		//IL_10d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10db: Expected O, but got Unknown
		//IL_1178: Unknown result type (might be due to invalid IL or missing references)
		//IL_1182: Expected O, but got Unknown
		//IL_121f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1229: Expected O, but got Unknown
		//IL_12c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12cc: Expected O, but got Unknown
		//IL_1366: Unknown result type (might be due to invalid IL or missing references)
		//IL_1370: Expected O, but got Unknown
		//IL_140a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1414: Expected O, but got Unknown
		//IL_14b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bb: Expected O, but got Unknown
		//IL_1558: Unknown result type (might be due to invalid IL or missing references)
		//IL_1562: Expected O, but got Unknown
		//IL_15fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1608: Expected O, but got Unknown
		//IL_16a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16af: Expected O, but got Unknown
		//IL_174c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1756: Expected O, but got Unknown
		//IL_17f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1800: Expected O, but got Unknown
		//IL_18a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18aa: Expected O, but got Unknown
		//IL_1946: Unknown result type (might be due to invalid IL or missing references)
		//IL_1950: Expected O, but got Unknown
		//IL_19ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f7: Expected O, but got Unknown
		//IL_1a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9e: Expected O, but got Unknown
		//IL_1b3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b48: Expected O, but got Unknown
		//IL_1be8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf2: Expected O, but got Unknown
		//IL_1c8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c98: Expected O, but got Unknown
		//IL_1fc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_216c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2176: Expected O, but got Unknown
		//IL_228b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2295: Expected O, but got Unknown
		//IL_232b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2335: Expected O, but got Unknown
		//IL_23bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c5: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(IconeCustomizer));
		DarkUITabControl1 = new DarkUITabControl();
		TabPage3 = new TabPage();
		DarkGroupBox4 = new DarkGroupBox();
		Button_OpenFolder2 = new DarkUIButton();
		Button_Reload2 = new DarkUIButton();
		DarkLabel2 = new DarkLabel();
		DarkGroupBox1 = new DarkGroupBox();
		LV_SelectedUnits = new DarkListView();
		DarkGroupBox2 = new DarkGroupBox();
		IconContainer = new FlowLayoutPanel();
		Button4 = new Button();
		Button1 = new Button();
		Button2 = new Button();
		Button3 = new Button();
		Button6 = new Button();
		Button7 = new Button();
		Button11 = new Button();
		Button12 = new Button();
		Button13 = new Button();
		Button14 = new Button();
		Button15 = new Button();
		Button16 = new Button();
		Button18 = new Button();
		Button19 = new Button();
		Button20 = new Button();
		Button21 = new Button();
		Button22 = new Button();
		Button23 = new Button();
		Button24 = new Button();
		Button5 = new Button();
		Button8 = new Button();
		Button9 = new Button();
		Button10 = new Button();
		Button25 = new Button();
		Button26 = new Button();
		Button27 = new Button();
		Button28 = new Button();
		Button_Confirm = new DarkUIButton();
		DarkGroupBox3 = new DarkGroupBox();
		CurrentSelection = new PictureBox();
		ButtonRestoreDefault = new DarkUIButton();
		TabPage1 = new TabPage();
		DarkGroupBox5 = new DarkGroupBox();
		DarkLabel6 = new DarkLabel();
		TB_Structure = new RichTextBox();
		DarkLabel5 = new DarkLabel();
		DarkLabel4 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		TB_Synthax = new RichTextBox();
		Button_Reload = new DarkUIButton();
		Button_OpenFolder1 = new DarkUIButton();
		TB_Examples = new RichTextBox();
		((Control)DarkUITabControl1).SuspendLayout();
		((Control)TabPage3).SuspendLayout();
		((Control)DarkGroupBox4).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)IconContainer).SuspendLayout();
		((Control)DarkGroupBox3).SuspendLayout();
		((ISupportInitialize)CurrentSelection).BeginInit();
		((Control)TabPage1).SuspendLayout();
		((Control)DarkGroupBox5).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)DarkUITabControl1).Controls.Add((Control)(object)TabPage3);
		((Control)DarkUITabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)DarkUITabControl1).Cursor = Cursors.Hand;
		((TabControl)DarkUITabControl1).ItemSize = new Size(80, 20);
		((Control)DarkUITabControl1).Location = new Point(12, 12);
		((Control)DarkUITabControl1).Name = "DarkUITabControl1";
		((TabControl)DarkUITabControl1).SelectedIndex = 0;
		((Control)DarkUITabControl1).Size = new Size(676, 515);
		((Control)DarkUITabControl1).TabIndex = 23;
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)DarkGroupBox4);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Padding = new Padding(3);
		((Control)TabPage3).Size = new Size(668, 487);
		TabPage3.TabIndex = 1;
		TabPage3.Text = "Scenario Unit";
		((Control)DarkGroupBox4).Controls.Add((Control)(object)Button_OpenFolder2);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)Button_Reload2);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)DarkLabel2);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)Button_Confirm);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)DarkGroupBox3);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)ButtonRestoreDefault);
		((Control)DarkGroupBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox4).Location = new Point(6, 6);
		((Control)DarkGroupBox4).Name = "DarkGroupBox4";
		((Control)DarkGroupBox4).Size = new Size(656, 475);
		((Control)DarkGroupBox4).TabIndex = 19;
		((GroupBox)DarkGroupBox4).TabStop = false;
		((GroupBox)DarkGroupBox4).Text = "Custom Icon [Scenario Unit]";
		((Control)Button_OpenFolder2).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_OpenFolder2).BackColor = Color.Transparent;
		((Button)Button_OpenFolder2).DialogResult = (DialogResult)0;
		((Control)Button_OpenFolder2).ForeColor = SystemColors.Control;
		((Control)Button_OpenFolder2).Location = new Point(555, 15);
		((Control)Button_OpenFolder2).Name = "Button_OpenFolder2";
		Button_OpenFolder2.RoundRadius = 0;
		((Control)Button_OpenFolder2).Size = new Size(96, 20);
		((Control)Button_OpenFolder2).TabIndex = 19;
		Button_OpenFolder2.Text = "Open folder";
		((Control)Button_Reload2).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_Reload2).BackColor = Color.Transparent;
		((Button)Button_Reload2).DialogResult = (DialogResult)0;
		((Control)Button_Reload2).ForeColor = SystemColors.Control;
		((Control)Button_Reload2).Location = new Point(470, 15);
		((Control)Button_Reload2).Name = "Button_Reload2";
		Button_Reload2.RoundRadius = 0;
		((Control)Button_Reload2).Size = new Size(79, 20);
		((Control)Button_Reload2).TabIndex = 22;
		Button_Reload2.Text = "Reload";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel2).ForeColor = Color.White;
		((Control)DarkLabel2).Location = new Point(9, 18);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(308, 13);
		((Control)DarkLabel2).TabIndex = 18;
		((Label)DarkLabel2).Text = "Customize the icon of one or more units in a scenario";
		((Control)DarkGroupBox1).Anchor = (AnchorStyles)14;
		((Control)DarkGroupBox1).Controls.Add((Control)(object)LV_SelectedUnits);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(6, 38);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(379, 430);
		((Control)DarkGroupBox1).TabIndex = 1;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Current Unit Selection";
		((Control)LV_SelectedUnits).Anchor = (AnchorStyles)15;
		((Control)LV_SelectedUnits).BackColor = Color.FromArgb(40, 43, 45);
		((Control)LV_SelectedUnits).Location = new Point(6, 19);
		LV_SelectedUnits.MultiSelect = true;
		((Control)LV_SelectedUnits).Name = "LV_SelectedUnits";
		LV_SelectedUnits.RelatedInfos = null;
		((Control)LV_SelectedUnits).Size = new Size(367, 404);
		((Control)LV_SelectedUnits).TabIndex = 0;
		((Control)LV_SelectedUnits).Text = "LV_SelectedUnits";
		((Control)DarkGroupBox2).Anchor = (AnchorStyles)9;
		((Control)DarkGroupBox2).Controls.Add((Control)(object)IconContainer);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(391, 38);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(261, 324);
		((Control)DarkGroupBox2).TabIndex = 2;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Available Icons";
		((Control)IconContainer).Anchor = (AnchorStyles)15;
		((ScrollableControl)IconContainer).AutoScroll = true;
		((Control)IconContainer).Controls.Add((Control)(object)Button4);
		((Control)IconContainer).Controls.Add((Control)(object)Button1);
		((Control)IconContainer).Controls.Add((Control)(object)Button2);
		((Control)IconContainer).Controls.Add((Control)(object)Button3);
		((Control)IconContainer).Controls.Add((Control)(object)Button6);
		((Control)IconContainer).Controls.Add((Control)(object)Button7);
		((Control)IconContainer).Controls.Add((Control)(object)Button11);
		((Control)IconContainer).Controls.Add((Control)(object)Button12);
		((Control)IconContainer).Controls.Add((Control)(object)Button13);
		((Control)IconContainer).Controls.Add((Control)(object)Button14);
		((Control)IconContainer).Controls.Add((Control)(object)Button15);
		((Control)IconContainer).Controls.Add((Control)(object)Button16);
		((Control)IconContainer).Controls.Add((Control)(object)Button18);
		((Control)IconContainer).Controls.Add((Control)(object)Button19);
		((Control)IconContainer).Controls.Add((Control)(object)Button20);
		((Control)IconContainer).Controls.Add((Control)(object)Button21);
		((Control)IconContainer).Controls.Add((Control)(object)Button22);
		((Control)IconContainer).Controls.Add((Control)(object)Button23);
		((Control)IconContainer).Controls.Add((Control)(object)Button24);
		((Control)IconContainer).Controls.Add((Control)(object)Button5);
		((Control)IconContainer).Controls.Add((Control)(object)Button8);
		((Control)IconContainer).Controls.Add((Control)(object)Button9);
		((Control)IconContainer).Controls.Add((Control)(object)Button10);
		((Control)IconContainer).Controls.Add((Control)(object)Button25);
		((Control)IconContainer).Controls.Add((Control)(object)Button26);
		((Control)IconContainer).Controls.Add((Control)(object)Button27);
		((Control)IconContainer).Controls.Add((Control)(object)Button28);
		((Control)IconContainer).Location = new Point(6, 19);
		((Control)IconContainer).Name = "IconContainer";
		((Control)IconContainer).Size = new Size(249, 299);
		((Control)IconContainer).TabIndex = 0;
		((ButtonBase)Button4).BackColor = Color.Transparent;
		((Control)Button4).BackgroundImage = (Image)componentResourceManager.GetObject("Button4.BackgroundImage");
		((Control)Button4).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button4).FlatStyle = (FlatStyle)0;
		((Control)Button4).ForeColor = Color.DarkGray;
		((Control)Button4).Location = new Point(3, 3);
		((Control)Button4).Name = "Button4";
		((Control)Button4).Size = new Size(40, 40);
		((Control)Button4).TabIndex = 3;
		((ButtonBase)Button4).UseVisualStyleBackColor = false;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).BackgroundImage = (Image)componentResourceManager.GetObject("Button1.BackgroundImage");
		((Control)Button1).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button1).FlatStyle = (FlatStyle)0;
		((Control)Button1).ForeColor = Color.DarkGray;
		((Control)Button1).Location = new Point(49, 3);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Size = new Size(40, 40);
		((Control)Button1).TabIndex = 4;
		((ButtonBase)Button1).UseVisualStyleBackColor = false;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).BackgroundImage = (Image)componentResourceManager.GetObject("Button2.BackgroundImage");
		((Control)Button2).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button2).FlatStyle = (FlatStyle)0;
		((Control)Button2).ForeColor = Color.DarkGray;
		((Control)Button2).Location = new Point(95, 3);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Size = new Size(40, 40);
		((Control)Button2).TabIndex = 5;
		((ButtonBase)Button2).UseVisualStyleBackColor = false;
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Control)Button3).BackgroundImage = (Image)componentResourceManager.GetObject("Button3.BackgroundImage");
		((Control)Button3).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button3).FlatStyle = (FlatStyle)0;
		((Control)Button3).ForeColor = Color.DarkGray;
		((Control)Button3).Location = new Point(141, 3);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Size = new Size(40, 40);
		((Control)Button3).TabIndex = 6;
		((ButtonBase)Button3).UseVisualStyleBackColor = false;
		((ButtonBase)Button6).BackColor = Color.Transparent;
		((Control)Button6).BackgroundImage = (Image)componentResourceManager.GetObject("Button6.BackgroundImage");
		((Control)Button6).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button6).FlatStyle = (FlatStyle)0;
		((Control)Button6).ForeColor = Color.DarkGray;
		((Control)Button6).Location = new Point(187, 3);
		((Control)Button6).Name = "Button6";
		((Control)Button6).Size = new Size(40, 40);
		((Control)Button6).TabIndex = 8;
		((ButtonBase)Button6).UseVisualStyleBackColor = false;
		((ButtonBase)Button7).BackColor = Color.Transparent;
		((Control)Button7).BackgroundImage = (Image)componentResourceManager.GetObject("Button7.BackgroundImage");
		((Control)Button7).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button7).FlatStyle = (FlatStyle)0;
		((Control)Button7).ForeColor = Color.DarkGray;
		((Control)Button7).Location = new Point(3, 49);
		((Control)Button7).Name = "Button7";
		((Control)Button7).Size = new Size(40, 40);
		((Control)Button7).TabIndex = 9;
		((ButtonBase)Button7).UseVisualStyleBackColor = false;
		((ButtonBase)Button11).BackColor = Color.Transparent;
		((Control)Button11).BackgroundImage = (Image)componentResourceManager.GetObject("Button11.BackgroundImage");
		((Control)Button11).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button11).FlatStyle = (FlatStyle)0;
		((Control)Button11).ForeColor = Color.DarkGray;
		((Control)Button11).Location = new Point(49, 49);
		((Control)Button11).Name = "Button11";
		((Control)Button11).Size = new Size(40, 40);
		((Control)Button11).TabIndex = 13;
		((ButtonBase)Button11).UseVisualStyleBackColor = false;
		((ButtonBase)Button12).BackColor = Color.Transparent;
		((Control)Button12).BackgroundImage = (Image)componentResourceManager.GetObject("Button12.BackgroundImage");
		((Control)Button12).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button12).FlatStyle = (FlatStyle)0;
		((Control)Button12).ForeColor = Color.DarkGray;
		((Control)Button12).Location = new Point(95, 49);
		((Control)Button12).Name = "Button12";
		((Control)Button12).Size = new Size(40, 40);
		((Control)Button12).TabIndex = 14;
		((ButtonBase)Button12).UseVisualStyleBackColor = false;
		((ButtonBase)Button13).BackColor = Color.Transparent;
		((Control)Button13).BackgroundImage = (Image)componentResourceManager.GetObject("Button13.BackgroundImage");
		((Control)Button13).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button13).FlatStyle = (FlatStyle)0;
		((Control)Button13).ForeColor = Color.DarkGray;
		((Control)Button13).Location = new Point(141, 49);
		((Control)Button13).Name = "Button13";
		((Control)Button13).Size = new Size(40, 40);
		((Control)Button13).TabIndex = 15;
		((ButtonBase)Button13).UseVisualStyleBackColor = false;
		((ButtonBase)Button14).BackColor = Color.Transparent;
		((Control)Button14).BackgroundImage = (Image)componentResourceManager.GetObject("Button14.BackgroundImage");
		((Control)Button14).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button14).FlatStyle = (FlatStyle)0;
		((Control)Button14).ForeColor = Color.DarkGray;
		((Control)Button14).Location = new Point(187, 49);
		((Control)Button14).Name = "Button14";
		((Control)Button14).Size = new Size(40, 40);
		((Control)Button14).TabIndex = 16;
		((ButtonBase)Button14).UseVisualStyleBackColor = false;
		((ButtonBase)Button15).BackColor = Color.Transparent;
		((Control)Button15).BackgroundImage = (Image)componentResourceManager.GetObject("Button15.BackgroundImage");
		((Control)Button15).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button15).FlatStyle = (FlatStyle)0;
		((Control)Button15).ForeColor = Color.DarkGray;
		((Control)Button15).Location = new Point(3, 95);
		((Control)Button15).Name = "Button15";
		((Control)Button15).Size = new Size(40, 40);
		((Control)Button15).TabIndex = 17;
		((ButtonBase)Button15).UseVisualStyleBackColor = false;
		((ButtonBase)Button16).BackColor = Color.Transparent;
		((Control)Button16).BackgroundImage = (Image)componentResourceManager.GetObject("Button16.BackgroundImage");
		((Control)Button16).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button16).FlatStyle = (FlatStyle)0;
		((Control)Button16).ForeColor = Color.DarkGray;
		((Control)Button16).Location = new Point(49, 95);
		((Control)Button16).Name = "Button16";
		((Control)Button16).Size = new Size(40, 40);
		((Control)Button16).TabIndex = 18;
		((ButtonBase)Button16).UseVisualStyleBackColor = false;
		((ButtonBase)Button18).BackColor = Color.Transparent;
		((Control)Button18).BackgroundImage = (Image)componentResourceManager.GetObject("Button18.BackgroundImage");
		((Control)Button18).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button18).FlatStyle = (FlatStyle)0;
		((Control)Button18).ForeColor = Color.DarkGray;
		((Control)Button18).Location = new Point(95, 95);
		((Control)Button18).Name = "Button18";
		((Control)Button18).Size = new Size(40, 40);
		((Control)Button18).TabIndex = 19;
		((ButtonBase)Button18).UseVisualStyleBackColor = false;
		((ButtonBase)Button19).BackColor = Color.Transparent;
		((Control)Button19).BackgroundImage = (Image)componentResourceManager.GetObject("Button19.BackgroundImage");
		((Control)Button19).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button19).FlatStyle = (FlatStyle)0;
		((Control)Button19).ForeColor = Color.DarkGray;
		((Control)Button19).Location = new Point(141, 95);
		((Control)Button19).Name = "Button19";
		((Control)Button19).Size = new Size(40, 40);
		((Control)Button19).TabIndex = 20;
		((ButtonBase)Button19).UseVisualStyleBackColor = false;
		((ButtonBase)Button20).BackColor = Color.Transparent;
		((Control)Button20).BackgroundImage = (Image)componentResourceManager.GetObject("Button20.BackgroundImage");
		((Control)Button20).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button20).FlatStyle = (FlatStyle)0;
		((Control)Button20).ForeColor = Color.DarkGray;
		((Control)Button20).Location = new Point(187, 95);
		((Control)Button20).Name = "Button20";
		((Control)Button20).Size = new Size(40, 40);
		((Control)Button20).TabIndex = 21;
		((ButtonBase)Button20).UseVisualStyleBackColor = false;
		((ButtonBase)Button21).BackColor = Color.Transparent;
		((Control)Button21).BackgroundImage = (Image)componentResourceManager.GetObject("Button21.BackgroundImage");
		((Control)Button21).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button21).FlatStyle = (FlatStyle)0;
		((Control)Button21).ForeColor = Color.DarkGray;
		((Control)Button21).Location = new Point(3, 141);
		((Control)Button21).Name = "Button21";
		((Control)Button21).Size = new Size(40, 40);
		((Control)Button21).TabIndex = 22;
		((ButtonBase)Button21).UseVisualStyleBackColor = false;
		((ButtonBase)Button22).BackColor = Color.Transparent;
		((Control)Button22).BackgroundImage = (Image)componentResourceManager.GetObject("Button22.BackgroundImage");
		((Control)Button22).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button22).FlatStyle = (FlatStyle)0;
		((Control)Button22).ForeColor = Color.DarkGray;
		((Control)Button22).Location = new Point(49, 141);
		((Control)Button22).Name = "Button22";
		((Control)Button22).Size = new Size(40, 40);
		((Control)Button22).TabIndex = 23;
		((ButtonBase)Button22).UseVisualStyleBackColor = false;
		((ButtonBase)Button23).BackColor = Color.Transparent;
		((Control)Button23).BackgroundImage = (Image)componentResourceManager.GetObject("Button23.BackgroundImage");
		((Control)Button23).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button23).FlatStyle = (FlatStyle)0;
		((Control)Button23).ForeColor = Color.DarkGray;
		((Control)Button23).Location = new Point(95, 141);
		((Control)Button23).Name = "Button23";
		((Control)Button23).Size = new Size(40, 40);
		((Control)Button23).TabIndex = 24;
		((ButtonBase)Button23).UseVisualStyleBackColor = false;
		((ButtonBase)Button24).BackColor = Color.Transparent;
		((Control)Button24).BackgroundImage = (Image)componentResourceManager.GetObject("Button24.BackgroundImage");
		((Control)Button24).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button24).FlatStyle = (FlatStyle)0;
		((Control)Button24).ForeColor = Color.DarkGray;
		((Control)Button24).Location = new Point(141, 141);
		((Control)Button24).Name = "Button24";
		((Control)Button24).Size = new Size(40, 40);
		((Control)Button24).TabIndex = 25;
		((ButtonBase)Button24).UseVisualStyleBackColor = false;
		((ButtonBase)Button5).BackColor = Color.Transparent;
		((Control)Button5).BackgroundImage = (Image)componentResourceManager.GetObject("Button5.BackgroundImage");
		((Control)Button5).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button5).FlatStyle = (FlatStyle)0;
		((Control)Button5).ForeColor = Color.DarkGray;
		((Control)Button5).Location = new Point(187, 141);
		((Control)Button5).Name = "Button5";
		((Control)Button5).Size = new Size(40, 40);
		((Control)Button5).TabIndex = 26;
		((ButtonBase)Button5).UseVisualStyleBackColor = false;
		((ButtonBase)Button8).BackColor = Color.Transparent;
		((Control)Button8).BackgroundImage = (Image)componentResourceManager.GetObject("Button8.BackgroundImage");
		((Control)Button8).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button8).FlatStyle = (FlatStyle)0;
		((Control)Button8).ForeColor = Color.DarkGray;
		((Control)Button8).Location = new Point(3, 187);
		((Control)Button8).Name = "Button8";
		((Control)Button8).Size = new Size(40, 40);
		((Control)Button8).TabIndex = 27;
		((ButtonBase)Button8).UseVisualStyleBackColor = false;
		((ButtonBase)Button9).BackColor = Color.Transparent;
		((Control)Button9).BackgroundImage = (Image)componentResourceManager.GetObject("Button9.BackgroundImage");
		((Control)Button9).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button9).FlatStyle = (FlatStyle)0;
		((Control)Button9).ForeColor = Color.DarkGray;
		((Control)Button9).Location = new Point(49, 187);
		((Control)Button9).Name = "Button9";
		((Control)Button9).Size = new Size(40, 40);
		((Control)Button9).TabIndex = 28;
		((ButtonBase)Button9).UseVisualStyleBackColor = false;
		((ButtonBase)Button10).BackColor = Color.Transparent;
		((Control)Button10).BackgroundImage = (Image)componentResourceManager.GetObject("Button10.BackgroundImage");
		((Control)Button10).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button10).FlatStyle = (FlatStyle)0;
		((Control)Button10).ForeColor = Color.DarkGray;
		((Control)Button10).Location = new Point(95, 187);
		((Control)Button10).Name = "Button10";
		((Control)Button10).Size = new Size(40, 40);
		((Control)Button10).TabIndex = 29;
		((ButtonBase)Button10).UseVisualStyleBackColor = false;
		((ButtonBase)Button25).BackColor = Color.Transparent;
		((Control)Button25).BackgroundImage = (Image)componentResourceManager.GetObject("Button25.BackgroundImage");
		((Control)Button25).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button25).FlatStyle = (FlatStyle)0;
		((Control)Button25).ForeColor = Color.DarkGray;
		((Control)Button25).Location = new Point(141, 187);
		((Control)Button25).Name = "Button25";
		((Control)Button25).Size = new Size(40, 40);
		((Control)Button25).TabIndex = 30;
		((ButtonBase)Button25).UseVisualStyleBackColor = false;
		((ButtonBase)Button26).BackColor = Color.Transparent;
		((Control)Button26).BackgroundImage = (Image)componentResourceManager.GetObject("Button26.BackgroundImage");
		((Control)Button26).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button26).FlatStyle = (FlatStyle)0;
		((Control)Button26).ForeColor = Color.DarkGray;
		((Control)Button26).Location = new Point(187, 187);
		((Control)Button26).Name = "Button26";
		((Control)Button26).Size = new Size(40, 40);
		((Control)Button26).TabIndex = 31;
		((ButtonBase)Button26).UseVisualStyleBackColor = false;
		((ButtonBase)Button27).BackColor = Color.Transparent;
		((Control)Button27).BackgroundImage = (Image)componentResourceManager.GetObject("Button27.BackgroundImage");
		((Control)Button27).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button27).FlatStyle = (FlatStyle)0;
		((Control)Button27).ForeColor = Color.DarkGray;
		((Control)Button27).Location = new Point(3, 233);
		((Control)Button27).Name = "Button27";
		((Control)Button27).Size = new Size(40, 40);
		((Control)Button27).TabIndex = 32;
		((ButtonBase)Button27).UseVisualStyleBackColor = false;
		((ButtonBase)Button28).BackColor = Color.Transparent;
		((Control)Button28).BackgroundImage = (Image)componentResourceManager.GetObject("Button28.BackgroundImage");
		((Control)Button28).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button28).FlatStyle = (FlatStyle)0;
		((Control)Button28).ForeColor = Color.DarkGray;
		((Control)Button28).Location = new Point(49, 233);
		((Control)Button28).Name = "Button28";
		((Control)Button28).Size = new Size(40, 40);
		((Control)Button28).TabIndex = 33;
		((ButtonBase)Button28).UseVisualStyleBackColor = false;
		((Control)Button_Confirm).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_Confirm).BackColor = Color.Transparent;
		((Button)Button_Confirm).DialogResult = (DialogResult)0;
		((Control)Button_Confirm).ForeColor = SystemColors.Control;
		((Control)Button_Confirm).Location = new Point(513, 410);
		((Control)Button_Confirm).Name = "Button_Confirm";
		Button_Confirm.RoundRadius = 0;
		((Control)Button_Confirm).Size = new Size(138, 58);
		((Control)Button_Confirm).TabIndex = 3;
		Button_Confirm.Text = "Confirm";
		((Control)DarkGroupBox3).Anchor = (AnchorStyles)10;
		((Control)DarkGroupBox3).BackColor = Color.Transparent;
		((Control)DarkGroupBox3).Controls.Add((Control)(object)CurrentSelection);
		((Control)DarkGroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox3).Location = new Point(391, 368);
		((Control)DarkGroupBox3).Name = "DarkGroupBox3";
		((Control)DarkGroupBox3).Size = new Size(116, 100);
		((Control)DarkGroupBox3).TabIndex = 17;
		((GroupBox)DarkGroupBox3).TabStop = false;
		((GroupBox)DarkGroupBox3).Text = "Selected";
		((Control)CurrentSelection).BackgroundImageLayout = (ImageLayout)3;
		((Control)CurrentSelection).Location = new Point(21, 19);
		((Control)CurrentSelection).Name = "CurrentSelection";
		((Control)CurrentSelection).Size = new Size(74, 74);
		CurrentSelection.TabIndex = 0;
		CurrentSelection.TabStop = false;
		((Control)ButtonRestoreDefault).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonRestoreDefault).BackColor = Color.Transparent;
		((Button)ButtonRestoreDefault).DialogResult = (DialogResult)0;
		((Control)ButtonRestoreDefault).ForeColor = SystemColors.Control;
		((Control)ButtonRestoreDefault).Location = new Point(513, 374);
		((Control)ButtonRestoreDefault).Name = "ButtonRestoreDefault";
		ButtonRestoreDefault.RoundRadius = 0;
		((Control)ButtonRestoreDefault).Size = new Size(139, 30);
		((Control)ButtonRestoreDefault).TabIndex = 4;
		ButtonRestoreDefault.Text = "Restore default icon";
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)DarkGroupBox5);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(668, 487);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "DBID and Type";
		((Control)DarkGroupBox5).Controls.Add((Control)(object)DarkLabel6);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)TB_Structure);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)DarkLabel5);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)DarkLabel4);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)DarkLabel3);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)TB_Synthax);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)Button_Reload);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)Button_OpenFolder1);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)TB_Examples);
		((Control)DarkGroupBox5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox5).Location = new Point(3, 6);
		((Control)DarkGroupBox5).Name = "DarkGroupBox5";
		((Control)DarkGroupBox5).Size = new Size(662, 478);
		((Control)DarkGroupBox5).TabIndex = 20;
		((GroupBox)DarkGroupBox5).TabStop = false;
		((GroupBox)DarkGroupBox5).Text = "Custom Icon [DBID and Type]";
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).Font = new Font("Microsoft Sans Serif", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel6).ForeColor = Color.White;
		((Control)DarkLabel6).Location = new Point(3, 32);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(65, 15);
		((Control)DarkLabel6).TabIndex = 27;
		((Label)DarkLabel6).Text = "Structure";
		((TextBoxBase)TB_Structure).BackColor = Color.FromArgb(40, 43, 45);
		TB_Structure.ForeColor = SystemColors.Info;
		((Control)TB_Structure).Location = new Point(6, 50);
		((Control)TB_Structure).Name = "TB_Structure";
		((TextBoxBase)TB_Structure).ReadOnly = true;
		((Control)TB_Structure).Size = new Size(650, 138);
		((Control)TB_Structure).TabIndex = 26;
		TB_Structure.Text = componentResourceManager.GetString("TB_Structure.Text");
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(42, 19);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(583, 13);
		((Control)DarkLabel5).TabIndex = 25;
		((Label)DarkLabel5).Text = "Customize the appearance, size and orientation of an icon specific to the DBID or the type of an unit.";
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).Font = new Font("Microsoft Sans Serif", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel4).ForeColor = Color.White;
		((Control)DarkLabel4).Location = new Point(6, 274);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(70, 15);
		((Control)DarkLabel4).TabIndex = 24;
		((Label)DarkLabel4).Text = "Examples";
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).Font = new Font("Microsoft Sans Serif", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel3).ForeColor = Color.White;
		((Control)DarkLabel3).Location = new Point(6, 191);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(57, 15);
		((Control)DarkLabel3).TabIndex = 23;
		((Label)DarkLabel3).Text = "Synthax";
		((TextBoxBase)TB_Synthax).BackColor = Color.FromArgb(40, 43, 45);
		TB_Synthax.ForeColor = SystemColors.Info;
		((Control)TB_Synthax).Location = new Point(6, 209);
		((Control)TB_Synthax).Name = "TB_Synthax";
		((TextBoxBase)TB_Synthax).ReadOnly = true;
		((Control)TB_Synthax).Size = new Size(650, 62);
		((Control)TB_Synthax).TabIndex = 22;
		TB_Synthax.Text = componentResourceManager.GetString("TB_Synthax.Text");
		((Control)Button_Reload).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_Reload).BackColor = Color.Transparent;
		((Button)Button_Reload).DialogResult = (DialogResult)0;
		((Control)Button_Reload).ForeColor = SystemColors.Control;
		((Control)Button_Reload).Location = new Point(517, 0);
		((Control)Button_Reload).Name = "Button_Reload";
		Button_Reload.RoundRadius = 0;
		((Control)Button_Reload).Size = new Size(128, 16);
		((Control)Button_Reload).TabIndex = 21;
		Button_Reload.Text = "Reload";
		((Control)Button_OpenFolder1).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_OpenFolder1).BackColor = Color.Transparent;
		((Button)Button_OpenFolder1).DialogResult = (DialogResult)0;
		((Control)Button_OpenFolder1).ForeColor = SystemColors.Control;
		((Control)Button_OpenFolder1).Location = new Point(374, 0);
		((Control)Button_OpenFolder1).Name = "Button_OpenFolder1";
		Button_OpenFolder1.RoundRadius = 0;
		((Control)Button_OpenFolder1).Size = new Size(137, 16);
		((Control)Button_OpenFolder1).TabIndex = 20;
		Button_OpenFolder1.Text = "Open folder";
		((TextBoxBase)TB_Examples).BackColor = Color.FromArgb(40, 43, 45);
		TB_Examples.ForeColor = SystemColors.Info;
		((Control)TB_Examples).Location = new Point(6, 292);
		((Control)TB_Examples).Name = "TB_Examples";
		((TextBoxBase)TB_Examples).ReadOnly = true;
		((Control)TB_Examples).Size = new Size(650, 180);
		((Control)TB_Examples).TabIndex = 1;
		TB_Examples.Text = componentResourceManager.GetString("TB_Examples.Text");
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(700, 539);
		((Control)this).Controls.Add((Control)(object)DarkUITabControl1);
		((Control)this).Name = "IconeCustomizer";
		((Form)this).Text = "Icon Customizer";
		((Control)DarkUITabControl1).ResumeLayout(false);
		((Control)TabPage3).ResumeLayout(false);
		((Control)DarkGroupBox4).ResumeLayout(false);
		((Control)DarkGroupBox4).PerformLayout();
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)IconContainer).ResumeLayout(false);
		((Control)DarkGroupBox3).ResumeLayout(false);
		((ISupportInitialize)CurrentSelection).EndInit();
		((Control)TabPage1).ResumeLayout(false);
		((Control)DarkGroupBox5).ResumeLayout(false);
		((Control)DarkGroupBox5).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	private void IconeCustomizer_Load(object sender, EventArgs e)
	{
		refresh();
	}

	public void refresh()
	{
		new List<string>();
		LV_SelectedUnits.Items.Clear();
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (string.IsNullOrEmpty(selectedUnit.CustomIcon))
			{
				LV_SelectedUnits.Items.Add(new DarkListItem(selectedUnit.Name + " (" + selectedUnit.UnitClass + ")"));
			}
			else
			{
				LV_SelectedUnits.Items.Add(new DarkListItem("[" + Path.GetFileNameWithoutExtension(selectedUnit.CustomIcon) + "] " + selectedUnit.Name + " (" + selectedUnit.UnitClass + ")"));
			}
			LV_SelectedUnits.Items.ElementAt(LV_SelectedUnits.Items.Count - 1).Tag = selectedUnit;
		}
		if (LV_SelectedUnits.Items.Count > 0)
		{
			LV_SelectedUnits.SelectItems(0, LV_SelectedUnits.Items.Count - 1);
		}
		((Control)IconContainer).Controls.Clear();
		string[] files = Directory.GetFiles(Application.StartupPath + "\\Symbols\\Custom");
		foreach (string path in files)
		{
			if (Operators.CompareString(Path.GetExtension(path).ToLower(), ".png", true) == 0)
			{
				AddNewIconItem(Path.GetFileName(path));
			}
		}
	}

	public void AddNewIconItem(string File)
	{
		IconItem iconItem = new IconItem();
		iconItem.Refresh(File, this);
		((Control)IconContainer).Controls.Add((Control)(object)iconItem);
	}

	private void method_0(object sender, EventArgs e)
	{
		Process.Start(Application.StartupPath + "\\Symbols\\Custom");
	}

	private void method_1(object sender, EventArgs e)
	{
		Process.Start(Application.StartupPath + "\\Symbols\\Custom");
	}

	private void method_2(object sender, EventArgs e)
	{
		foreach (Module_Unit.Unit item in method_4())
		{
			item.CustomIcon = "";
		}
		refresh();
	}

	private void method_3(object sender, EventArgs e)
	{
		foreach (Module_Unit.Unit item in method_4())
		{
			item.CustomIcon = CurrentIconSelected;
		}
	}

	private List<Module_Unit.Unit> method_4()
	{
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		foreach (DarkListItem selectedItem in LV_SelectedUnits.SelectedItems)
		{
			list.Add((Module_Unit.Unit)selectedItem.Tag);
		}
		return list;
	}

	private void method_5(object sender, EventArgs e)
	{
		Client.ParseCustomICons();
	}

	private void method_6(object sender, EventArgs e)
	{
		List<Module_Unit.Unit> list = method_4();
		if (list.Count == 0)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (Module_Unit.Unit item in list)
		{
			if (!hashSet.Contains(item.CustomIcon))
			{
				hashSet.Add(item.CustomIcon);
			}
		}
		if (hashSet.Count == 1)
		{
			CurrentIconSelected = hashSet.ElementAt(0);
		}
		else
		{
			CurrentIconSelected = "";
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		Client.ParseCustomICons();
		refresh();
	}

	static IconeCustomizer()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
public sealed class Sides : DarkSecondaryFormBase, GInterface0
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("LB_Sides")]
	private DarkListView _LB_Sides;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton _Button3;

	[AccessedThroughProperty("CB_AIOnly")]
	[CompilerGenerated]
	private DarkCheckBox _CB_AIOnly;

	[CompilerGenerated]
	[AccessedThroughProperty("Button4")]
	private DarkUIButton _Button4;

	[CompilerGenerated]
	[AccessedThroughProperty("Button5")]
	private DarkUIButton _Button5;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Awareness")]
	private DarkUIComboBox _CB_Awareness;

	[AccessedThroughProperty("CB_CollRespons")]
	[CompilerGenerated]
	private DarkCheckBox _CB_CollRespons;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_Proficiency")]
	private TrackBar _TrackBar_Proficiency;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AutoTrackCivs")]
	private DarkCheckBox _CB_AutoTrackCivs;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SideBriefing")]
	private DarkUIButton _Button_SideBriefing;

	[CompilerGenerated]
	[AccessedThroughProperty("check_FixedSideColor")]
	private CheckBox _check_FixedSideColor;

	[AccessedThroughProperty("Button_ChangeColor")]
	[CompilerGenerated]
	private DarkUIButton _Button_ChangeColor;

	[CompilerGenerated]
	[AccessedThroughProperty("btnNature")]
	private DarkUIButton _btnNature;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SideEnablers")]
	private DarkUIButton _Button_SideEnablers;

	[AccessedThroughProperty("btnAddSide")]
	[CompilerGenerated]
	private DarkUIButton _btnAddSide;

	private Side side_0;

	private bool bool_2;

	private int[] int_0;

	internal virtual DarkListView LB_Sides
	{
		[CompilerGenerated]
		get
		{
			return _LB_Sides;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_3);
			EventHandler value2 = method_4;
			DarkListView darkListView = _LB_Sides;
			if (darkListView != null)
			{
				((Control)darkListView).MouseDoubleClick -= val;
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LB_Sides = value;
			darkListView = _LB_Sides;
			if (darkListView != null)
			{
				((Control)darkListView).MouseDoubleClick += val;
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

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
			EventHandler eventHandler = method_5;
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
			EventHandler eventHandler = method_6;
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

	internal virtual DarkCheckBox CB_AIOnly
	{
		[CompilerGenerated]
		get
		{
			return _CB_AIOnly;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkCheckBox darkCheckBox = _CB_AIOnly;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_AIOnly = value;
			darkCheckBox = _CB_AIOnly;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

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
			EventHandler eventHandler = method_8;
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

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUIComboBox CB_Awareness
	{
		[CompilerGenerated]
		get
		{
			return _CB_Awareness;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			EventHandler eventHandler2 = method_13;
			EventHandler eventHandler3 = method_14;
			DarkUIComboBox darkUIComboBox = _CB_Awareness;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
				((Control)darkUIComboBox).Enter -= eventHandler2;
				((Control)darkUIComboBox).Leave -= eventHandler3;
			}
			_CB_Awareness = value;
			darkUIComboBox = _CB_Awareness;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
				((Control)darkUIComboBox).Enter += eventHandler2;
				((Control)darkUIComboBox).Leave += eventHandler3;
			}
		}
	}

	internal virtual DarkCheckBox CB_CollRespons
	{
		[CompilerGenerated]
		get
		{
			return _CB_CollRespons;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkCheckBox darkCheckBox = _CB_CollRespons;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_CollRespons = value;
			darkCheckBox = _CB_CollRespons;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_Proficiency")]
	internal virtual DarkLabel Label_Proficiency { get; set; }

	internal virtual TrackBar TrackBar_Proficiency
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_Proficiency;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			TrackBar val = _TrackBar_Proficiency;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_Proficiency = value;
			val = _TrackBar_Proficiency;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_AutoTrackCivs
	{
		[CompilerGenerated]
		get
		{
			return _CB_AutoTrackCivs;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkCheckBox darkCheckBox = _CB_AutoTrackCivs;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_AutoTrackCivs = value;
			darkCheckBox = _CB_AutoTrackCivs;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkToolStrip1")]
	internal virtual DarkToolStrip DarkToolStrip1 { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal virtual ToolStripLabel ToolStripLabel1 { get; set; }

	internal virtual DarkUIButton Button_SideBriefing
	{
		[CompilerGenerated]
		get
		{
			return _Button_SideBriefing;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIButton darkUIButton = _Button_SideBriefing;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_SideBriefing = value;
			darkUIButton = _Button_SideBriefing;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Panel_SideColor")]
	internal virtual Panel Panel_SideColor { get; set; }

	internal virtual CheckBox check_FixedSideColor
	{
		[CompilerGenerated]
		get
		{
			return _check_FixedSideColor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			CheckBox val = _check_FixedSideColor;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_check_FixedSideColor = value;
			val = _check_FixedSideColor;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ChangeColor
	{
		[CompilerGenerated]
		get
		{
			return _Button_ChangeColor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIButton darkUIButton = _Button_ChangeColor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ChangeColor = value;
			darkUIButton = _Button_ChangeColor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btnNature
	{
		[CompilerGenerated]
		get
		{
			return _btnNature;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIButton darkUIButton = _btnNature;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnNature = value;
			darkUIButton = _btnNature;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_SideEnablers
	{
		[CompilerGenerated]
		get
		{
			return _Button_SideEnablers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _Button_SideEnablers;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_SideEnablers = value;
			darkUIButton = _Button_SideEnablers;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public virtual DarkUIButton btnAddSide
	{
		[CompilerGenerated]
		get
		{
			return _btnAddSide;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _btnAddSide;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnAddSide = value;
			darkUIButton = _btnAddSide;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public Sides()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(Sides_FormClosing);
		((Form)this).Load += Sides_Load;
		((Control)this).KeyDown += new KeyEventHandler(Sides_KeyDown);
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
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Expected O, but got Unknown
		//IL_090e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e2: Expected O, but got Unknown
		//IL_0a20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b75: Expected O, but got Unknown
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Expected O, but got Unknown
		//IL_0c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdc: Expected O, but got Unknown
		//IL_0d1d: Unknown result type (might be due to invalid IL or missing references)
		LB_Sides = new DarkListView();
		btnAddSide = new DarkUIButton();
		Button2 = new DarkUIButton();
		Button3 = new DarkUIButton();
		CB_AIOnly = new DarkCheckBox();
		Button4 = new DarkUIButton();
		Button5 = new DarkUIButton();
		Label1 = new DarkLabel();
		CB_Awareness = new DarkUIComboBox();
		CB_CollRespons = new DarkCheckBox();
		Label_Proficiency = new DarkLabel();
		TrackBar_Proficiency = new TrackBar();
		CB_AutoTrackCivs = new DarkCheckBox();
		DarkToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		Button_SideBriefing = new DarkUIButton();
		Panel_SideColor = new Panel();
		check_FixedSideColor = new CheckBox();
		Button_ChangeColor = new DarkUIButton();
		btnNature = new DarkUIButton();
		Button_SideEnablers = new DarkUIButton();
		((ISupportInitialize)TrackBar_Proficiency).BeginInit();
		((Control)DarkToolStrip1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)LB_Sides).Anchor = (AnchorStyles)7;
		((Control)LB_Sides).Location = new Point(1, 9);
		((Control)LB_Sides).Name = "LB_Sides";
		LB_Sides.RelatedInfos = null;
		((Control)LB_Sides).Size = new Size(213, 483);
		((Control)LB_Sides).TabIndex = 0;
		((ButtonBase)btnAddSide).BackColor = Color.Transparent;
		((Control)btnAddSide).Font = new Font("Segoe UI", 10f);
		((Control)btnAddSide).ForeColor = SystemColors.Control;
		((Control)btnAddSide).Location = new Point(220, 9);
		((Control)btnAddSide).Name = "btnAddSide";
		((Control)btnAddSide).Padding = new Padding(5);
		btnAddSide.RoundRadius = 0;
		((Control)btnAddSide).Size = new Size(133, 23);
		((Control)btnAddSide).TabIndex = 1;
		btnAddSide.Text = "Add";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(220, 38);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(133, 23);
		((Control)Button2).TabIndex = 2;
		Button2.Text = "Remove";
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Control)Button3).Font = new Font("Segoe UI", 10f);
		((Control)Button3).ForeColor = SystemColors.Control;
		((Control)Button3).Location = new Point(220, 154);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(133, 23);
		((Control)Button3).TabIndex = 3;
		Button3.Text = "Postures";
		((ButtonBase)CB_AIOnly).AutoSize = true;
		((Control)CB_AIOnly).Enabled = false;
		((Control)CB_AIOnly).Location = new Point(221, 264);
		((Control)CB_AIOnly).Name = "CB_AIOnly";
		((Control)CB_AIOnly).Size = new Size(212, 29);
		((Control)CB_AIOnly).TabIndex = 4;
		((ButtonBase)CB_AIOnly).Text = "Side is computer-only";
		((ButtonBase)Button4).BackColor = Color.Transparent;
		((Control)Button4).Font = new Font("Segoe UI", 10f);
		((Control)Button4).ForeColor = SystemColors.Control;
		((Control)Button4).Location = new Point(220, 96);
		((Control)Button4).Name = "Button4";
		((Control)Button4).Padding = new Padding(5);
		Button4.RoundRadius = 0;
		((Control)Button4).Size = new Size(133, 23);
		((Control)Button4).TabIndex = 5;
		Button4.Text = "Rename";
		((ButtonBase)Button5).BackColor = Color.Transparent;
		((Control)Button5).Font = new Font("Segoe UI", 10f);
		((Control)Button5).ForeColor = SystemColors.Control;
		((Control)Button5).Location = new Point(220, 183);
		((Control)Button5).Name = "Button5";
		((Control)Button5).Padding = new Padding(5);
		Button5.RoundRadius = 0;
		((Control)Button5).Size = new Size(133, 23);
		((Control)Button5).TabIndex = 6;
		Button5.Text = "Doctrine - ROE";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(217, 327);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(144, 25);
		((Control)Label1).TabIndex = 8;
		((Label)Label1).Text = "Awareness Level:";
		((ComboBox)CB_Awareness).BackColor = Color.Transparent;
		((ComboBox)CB_Awareness).DrawMode = (DrawMode)1;
		((ComboBox)CB_Awareness).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Awareness).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Awareness).FormattingEnabled = true;
		((ComboBox)CB_Awareness).Items.AddRange(new object[5] { "Blind", "Normal", "AutoSideID", "AutoSideAndUnitID", "Omniscient" });
		((Control)CB_Awareness).Location = new Point(220, 343);
		((Control)CB_Awareness).Name = "CB_Awareness";
		((Control)CB_Awareness).Size = new Size(133, 27);
		((Control)CB_Awareness).TabIndex = 9;
		((Control)CB_CollRespons).Location = new Point(221, 284);
		((Control)CB_CollRespons).Name = "CB_CollRespons";
		((Control)CB_CollRespons).Size = new Size(150, 17);
		((Control)CB_CollRespons).TabIndex = 10;
		((ButtonBase)CB_CollRespons).Text = "Collective responsibility";
		Label_Proficiency.AutoSize = true;
		((Control)Label_Proficiency).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Proficiency).Location = new Point(219, 374);
		((Control)Label_Proficiency).Name = "Label_Proficiency";
		((Control)Label_Proficiency).Size = new Size(101, 25);
		((Control)Label_Proficiency).TabIndex = 11;
		((Label)Label_Proficiency).Text = "Proficiency:";
		((Control)TrackBar_Proficiency).Location = new Point(220, 390);
		TrackBar_Proficiency.Maximum = 4;
		((Control)TrackBar_Proficiency).Name = "TrackBar_Proficiency";
		((Control)TrackBar_Proficiency).Size = new Size(133, 69);
		((Control)TrackBar_Proficiency).TabIndex = 12;
		((Control)CB_AutoTrackCivs).Location = new Point(221, 303);
		((Control)CB_AutoTrackCivs).Name = "CB_AutoTrackCivs";
		((Control)CB_AutoTrackCivs).Size = new Size(150, 17);
		((Control)CB_AutoTrackCivs).TabIndex = 13;
		((ButtonBase)CB_AutoTrackCivs).Text = "Can auto-track civilians";
		((ToolStrip)DarkToolStrip1).AutoSize = false;
		((ToolStrip)DarkToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)DarkToolStrip1).Dock = (DockStyle)2;
		((ToolStrip)DarkToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)DarkToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)DarkToolStrip1).ImageScalingSize = new Size(24, 24);
		((ToolStrip)DarkToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)ToolStripLabel1 });
		((Control)DarkToolStrip1).Location = new Point(0, 486);
		((Control)DarkToolStrip1).Name = "DarkToolStrip1";
		((Control)DarkToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)DarkToolStrip1).Size = new Size(368, 28);
		((Control)DarkToolStrip1).TabIndex = 14;
		((Control)DarkToolStrip1).Text = "DarkToolStrip1";
		((ToolStripItem)ToolStripLabel1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel1).Name = "ToolStripLabel1";
		((ToolStripItem)ToolStripLabel1).Size = new Size(472, 25);
		((ToolStripItem)ToolStripLabel1).Text = "Double-clicking on a side selects it and closes this window";
		((ButtonBase)Button_SideBriefing).BackColor = Color.Transparent;
		((Control)Button_SideBriefing).Font = new Font("Segoe UI", 10f);
		((Control)Button_SideBriefing).ForeColor = SystemColors.Control;
		((Control)Button_SideBriefing).Location = new Point(220, 125);
		((Control)Button_SideBriefing).Name = "Button_SideBriefing";
		((Control)Button_SideBriefing).Padding = new Padding(5);
		Button_SideBriefing.RoundRadius = 0;
		((Control)Button_SideBriefing).Size = new Size(133, 23);
		((Control)Button_SideBriefing).TabIndex = 15;
		Button_SideBriefing.Text = "Briefing";
		((Control)Panel_SideColor).BackColor = SystemColors.Control;
		Panel_SideColor.BorderStyle = (BorderStyle)1;
		((Control)Panel_SideColor).Location = new Point(306, 425);
		((Control)Panel_SideColor).Name = "Panel_SideColor";
		((Control)Panel_SideColor).Size = new Size(54, 19);
		((Control)Panel_SideColor).TabIndex = 17;
		((ButtonBase)check_FixedSideColor).AutoSize = true;
		((Control)check_FixedSideColor).ForeColor = SystemColors.ButtonHighlight;
		((Control)check_FixedSideColor).Location = new Point(217, 425);
		((Control)check_FixedSideColor).Name = "check_FixedSideColor";
		((Control)check_FixedSideColor).Size = new Size(131, 29);
		((Control)check_FixedSideColor).TabIndex = 15;
		((ButtonBase)check_FixedSideColor).Text = "Fixed Color:";
		((ButtonBase)Button_ChangeColor).BackColor = Color.Transparent;
		((Control)Button_ChangeColor).Font = new Font("Segoe UI", 10f);
		((Control)Button_ChangeColor).ForeColor = SystemColors.Control;
		((Control)Button_ChangeColor).Location = new Point(222, 450);
		((Control)Button_ChangeColor).Name = "Button_ChangeColor";
		((Control)Button_ChangeColor).Padding = new Padding(5);
		Button_ChangeColor.RoundRadius = 0;
		((Control)Button_ChangeColor).Size = new Size(133, 23);
		((Control)Button_ChangeColor).TabIndex = 18;
		Button_ChangeColor.Text = "Change Color";
		((ButtonBase)btnNature).BackColor = Color.Transparent;
		((Control)btnNature).Font = new Font("Segoe UI", 8f);
		((Control)btnNature).ForeColor = SystemColors.Control;
		((Control)btnNature).Location = new Point(220, 67);
		((Control)btnNature).Name = "btnNature";
		((Control)btnNature).Padding = new Padding(5);
		btnNature.RoundRadius = 0;
		((Control)btnNature).Size = new Size(133, 23);
		((Control)btnNature).TabIndex = 19;
		btnNature.Text = "Add Nature Side";
		((ButtonBase)Button_SideEnablers).BackColor = Color.Transparent;
		((Control)Button_SideEnablers).Font = new Font("Segoe UI", 10f);
		((Control)Button_SideEnablers).ForeColor = SystemColors.Control;
		((Control)Button_SideEnablers).Location = new Point(220, 212);
		((Control)Button_SideEnablers).Name = "Button_SideEnablers";
		((Control)Button_SideEnablers).Padding = new Padding(5);
		Button_SideEnablers.RoundRadius = 0;
		((Control)Button_SideEnablers).Size = new Size(133, 23);
		((Control)Button_SideEnablers).TabIndex = 20;
		Button_SideEnablers.Text = "Enablers";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).AutoSize = true;
		((Form)this).ClientSize = new Size(368, 514);
		((Control)this).Controls.Add((Control)(object)Button_SideEnablers);
		((Control)this).Controls.Add((Control)(object)btnNature);
		((Control)this).Controls.Add((Control)(object)Button_ChangeColor);
		((Control)this).Controls.Add((Control)(object)check_FixedSideColor);
		((Control)this).Controls.Add((Control)(object)Panel_SideColor);
		((Control)this).Controls.Add((Control)(object)Button_SideBriefing);
		((Control)this).Controls.Add((Control)(object)CB_AutoTrackCivs);
		((Control)this).Controls.Add((Control)(object)TrackBar_Proficiency);
		((Control)this).Controls.Add((Control)(object)Label_Proficiency);
		((Control)this).Controls.Add((Control)(object)CB_CollRespons);
		((Control)this).Controls.Add((Control)(object)CB_Awareness);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Button5);
		((Control)this).Controls.Add((Control)(object)Button4);
		((Control)this).Controls.Add((Control)(object)CB_AIOnly);
		((Control)this).Controls.Add((Control)(object)Button3);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)btnAddSide);
		((Control)this).Controls.Add((Control)(object)LB_Sides);
		((Control)this).Controls.Add((Control)(object)DarkToolStrip1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Sides";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit Sides";
		((ISupportInitialize)TrackBar_Proficiency).EndInit();
		((Control)DarkToolStrip1).ResumeLayout(false);
		((Control)DarkToolStrip1).PerformLayout();
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
			side_0 = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void Sides_FormClosing(object sender, FormClosingEventArgs e)
	{
		side_0 = null;
		if (!((Control)MyProject.Forms.AddUnit).Visible)
		{
			((Control)MyProject.Forms.MainForm).Enabled = true;
		}
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void Sides_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		RefreshForm();
	}

	private void method_2(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.AddSide).Show();
	}

	public void RefreshSideColorControls()
	{
		((Control)Panel_SideColor).Visible = false;
		((Control)Button_ChangeColor).Visible = false;
		((Control)check_FixedSideColor).Visible = false;
	}

	public void RefreshForm()
	{
		LB_Sides.Items.Clear();
		foreach (Side item in Client.CurrentScenario.Sides_ReadOnly.OrderBy([SpecialName] (Side theS) => theS.Name))
		{
			LB_Sides.Items.Add(new DarkListItem(item.Name));
		}
		Button2.Enabled = LB_Sides.Items.Count > 0 && LB_Sides.SelectedIndices.Count > 0;
		Button3.Enabled = LB_Sides.Items.Count > 0 && LB_Sides.SelectedIndices.Count > 0;
		((Control)Label_Proficiency).Visible = LB_Sides.Items.Count > 0 && LB_Sides.SelectedIndices.Count > 0;
		((Control)TrackBar_Proficiency).Visible = LB_Sides.Items.Count > 0 && LB_Sides.SelectedIndices.Count > 0;
		Button_SideEnablers.Enabled = LB_Sides.Items.Count > 0 && LB_Sides.SelectedIndices.Count > 0;
		RefreshSideColorControls();
		if (((Control)MyProject.Forms.AddUnit).Visible)
		{
			MyProject.Forms.AddUnit.RefreshSides();
		}
	}

	private void method_3(object sender, MouseEventArgs e)
	{
		if (LB_Sides.SelectedIndices.Count == 0)
		{
			return;
		}
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (Operators.CompareString(side.Name, LB_Sides.SelectedItems[0].Text, true) == 0)
			{
				Client.CurrentSide = side;
				if (Client.Realtime)
				{
					Client.CurrentScenario.SetCurrentSide(side);
					Client.RealtimeTerminal.SendSideChange(side, Client.CurrentMapProfile, ByPlayer: true);
				}
				break;
			}
		}
		((Form)this).Close();
	}

	private void method_4(object sender, EventArgs e)
	{
		if (LB_Sides.SelectedIndices.Count == 0)
		{
			return;
		}
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (Operators.CompareString(side.Name, LB_Sides.SelectedItems[0].Text, true) == 0)
			{
				side_0 = side;
				break;
			}
		}
		Button2.Enabled = LB_Sides.Items.Count > 0;
		Button3.Enabled = LB_Sides.Items.Count > 0;
		Button_SideEnablers.Enabled = LB_Sides.Items.Count > 0;
		((Control)CB_AIOnly).Enabled = LB_Sides.Items.Count > 0;
		((Control)CB_CollRespons).Enabled = LB_Sides.Items.Count > 0;
		((CheckBox)CB_AIOnly).Checked = side_0.IsAIOnly;
		((CheckBox)CB_CollRespons).Checked = side_0.AssignsCollectiveResponsibility;
		((CheckBox)CB_AutoTrackCivs).Checked = side_0.CanAutoTrackCivs;
		switch (side_0.AwarenessLevel)
		{
		case Side.AwarenessLevel_Enum.Blind:
			((ComboBox)CB_Awareness).SelectedIndex = 0;
			break;
		case Side.AwarenessLevel_Enum.Normal:
			((ComboBox)CB_Awareness).SelectedIndex = 1;
			break;
		case Side.AwarenessLevel_Enum.AutoSideID:
			((ComboBox)CB_Awareness).SelectedIndex = 2;
			break;
		case Side.AwarenessLevel_Enum.AutoSideAndUnitID:
			((ComboBox)CB_Awareness).SelectedIndex = 3;
			break;
		case Side.AwarenessLevel_Enum.Omniscient:
			((ComboBox)CB_Awareness).SelectedIndex = 4;
			break;
		}
		((Control)Label_Proficiency).Visible = true;
		((Control)TrackBar_Proficiency).Visible = true;
		((Label)Label_Proficiency).Text = "Proficiency: " + Misc.ToEnglishString(side_0.Proficiency);
		TrackBar_Proficiency.Value = (int)side_0.Proficiency;
		RefreshSideColorControls();
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		if ((int)DarkMessageBox.ShowWarning("Are you sure? All units, missions and any other object of that side will be deleted!", "Remove Side: " + side_0.Name, DarkDialogButton.OkCancel) != 1)
		{
			return;
		}
		Collection<ActiveUnit> collection = new Collection<ActiveUnit>();
		foreach (ActiveUnit unit in side_0.Units)
		{
			collection.Add(unit);
		}
		foreach (ActiveUnit item in collection)
		{
			Client.CurrentScenario.DeleteUnitImmediately(item.ObjectID, ScenEditAction: true, "Unit deleted", null, RegisterAsLosses: false);
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, UnguidedWeapon> unguidedWeapon in Client.CurrentScenario.UnguidedWeapons)
		{
			if (unguidedWeapon.Value.get_UnitSide(SetSideOnly: false) == side_0)
			{
				list.Add(unguidedWeapon.Key);
			}
		}
		UnguidedWeapon value = null;
		foreach (string item2 in list)
		{
			string theWeapon_ObjectID = item2;
			Client.CurrentScenario.UnguidedWeapons.TryRemove(theWeapon_ObjectID, out value);
			Side side = side_0;
			Scenario theScen = Client.CurrentScenario;
			side.RemoveWeaponFromSalvos(ref theScen, ref theWeapon_ObjectID);
		}
		Client.CurrentScenario.RemoveSide(side_0);
		Client.MustRefreshMainForm = true;
		RefreshForm();
	}

	private void method_6(object sender, EventArgs e)
	{
		MyProject.Forms.Postures.SelectedSide = side_0;
		MyProject.Forms.Postures.Mode = 0;
		((Control)MyProject.Forms.Postures).Show();
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)side_0))
		{
			side_0.IsAIOnly = ((CheckBox)CB_AIOnly).Checked;
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		if (side_0 != null)
		{
			((Control)new RenameSide
			{
				SelectedSide = side_0
			}).Show();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)side_0))
		{
			((Control)new DoctrineForm
			{
				Subject = side_0
			}).Show();
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)side_0))
		{
			switch (((ComboBox)CB_Awareness).SelectedIndex)
			{
			case 0:
				side_0.AwarenessLevel = Side.AwarenessLevel_Enum.Blind;
				break;
			case 1:
				side_0.AwarenessLevel = Side.AwarenessLevel_Enum.Normal;
				break;
			case 2:
				side_0.AwarenessLevel = Side.AwarenessLevel_Enum.AutoSideID;
				break;
			case 3:
				side_0.AwarenessLevel = Side.AwarenessLevel_Enum.AutoSideAndUnitID;
				break;
			case 4:
				side_0.AwarenessLevel = Side.AwarenessLevel_Enum.Omniscient;
				break;
			}
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)side_0))
		{
			side_0.AssignsCollectiveResponsibility = ((CheckBox)CB_CollRespons).Checked;
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)side_0))
		{
			side_0.Proficiency = (GlobalVariables.ProficiencyLevel)TrackBar_Proficiency.Value;
			((Label)Label_Proficiency).Text = "Proficiency: " + Misc.ToEnglishString(side_0.Proficiency);
		}
	}

	private void Sides_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Invalid comparison between Unknown and I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (bool_2)
		{
			if (e.KeyValue == 13 && ((Control)this).Visible)
			{
				((Control)CB_CollRespons).Select();
				return;
			}
			if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!bool_2 && (e.KeyValue != 32 || !((Control)this).Visible))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		bool_2 = true;
	}

	private void method_14(object sender, EventArgs e)
	{
		bool_2 = false;
		((Control)CB_CollRespons).Select();
	}

	private void method_15(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)side_0))
		{
			side_0.CanAutoTrackCivs = ((CheckBox)CB_AutoTrackCivs).Checked;
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)side_0))
		{
			try
			{
				MyProject.Forms.EditBriefing.theSelectedSide = side_0;
				((Control)MyProject.Forms.EditBriefing).Show();
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200202", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		DarkMessageBox.ShowError("You must have a side selected before you can edit its briefing", "No side selected!");
	}

	private void method_17(object sender, EventArgs e)
	{
		if (!check_FixedSideColor.Checked)
		{
			((Control)Panel_SideColor).BackColor = Color.Gray;
			((Control)Panel_SideColor).Visible = false;
			((Control)Button_ChangeColor).Visible = false;
			side_0.AssignedFixedColor = null;
		}
		else
		{
			((Control)Panel_SideColor).Visible = true;
			((Control)Button_ChangeColor).Visible = true;
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		ColorDialog val = new ColorDialog();
		val.AllowFullOpen = true;
		val.AnyColor = true;
		val.Color = ((Control)Panel_SideColor).BackColor;
		val.CustomColors = int_0;
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			((Control)Panel_SideColor).BackColor = val.Color;
			side_0.AssignedFixedColor = val.Color;
			int_0 = val.CustomColors;
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		Client.CurrentScenario.CreateNatureSideIfNeeded();
		RefreshForm();
	}

	private void method_20(object sender, EventArgs e)
	{
		MyProject.Forms.EnablersForm.SelectedSide = side_0;
		((Control)MyProject.Forms.EnablersForm).Show();
	}

	static Sides()
	{
		Class72.smethod_20();
	}
}

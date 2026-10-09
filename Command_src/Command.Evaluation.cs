using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using AGaugeApp;
using Command_Core;
using Command_Core.Lua;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using LiveCharts;
using LiveCharts.Configurations;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Evaluation : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__88-0
	{
		public List<string> $VB$Local_ScoringLog;

		public DateTime $VB$Local_ScenTime;

		public int $VB$Local_TotalScore;

		public Evaluation $VB$Me;

		public _Closure$__88-0(_Closure$__88-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ScoringLog = arg0.$VB$Local_ScoringLog;
				$VB$Local_ScenTime = arg0.$VB$Local_ScenTime;
				$VB$Local_TotalScore = arg0.$VB$Local_TotalScore;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Me.method_2($VB$Local_ScoringLog, $VB$Local_ScenTime, $VB$Local_TotalScore, bool_4: false);
		}

		static _Closure$__88-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__92-0
	{
		public DateTime $VB$Local_min_t;

		public _Closure$__92-0(_Closure$__92-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_min_t = arg0.$VB$Local_min_t;
			}
		}

		[SpecialName]
		internal double _Lambda$__1(ScoringDatapointViewModel F)
		{
			return (double)(F.DateTime - $VB$Local_min_t).Ticks / 10000000.0;
		}

		static _Closure$__92-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ContinueCampaign")]
	private DarkUIButton _Button_ContinueCampaign;

	[AccessedThroughProperty("Button_ClearScoringLog")]
	[CompilerGenerated]
	private DarkUIButton _Button_ClearScoringLog;

	internal ScoringGraphControl ScoringGraphControl1;

	[AccessedThroughProperty("Button_RestartScenario")]
	[CompilerGenerated]
	private DarkUIButton _Button_RestartScenario;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RestartFromSave")]
	private DarkUIButton _Button_RestartFromSave;

	public bool EvaluationInProgress;

	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[field: AccessedThroughProperty("Label_Evaluation")]
	internal virtual DarkLabel Label_Evaluation { get; set; }

	[field: AccessedThroughProperty("Label_Score")]
	internal virtual DarkLabel Label_Score { get; set; }

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual DarkUITabControl TabControl1 { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

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

	internal virtual DarkUIButton Button_ContinueCampaign
	{
		[CompilerGenerated]
		get
		{
			return _Button_ContinueCampaign;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button_ContinueCampaign;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ContinueCampaign = value;
			darkUIButton = _Button_ContinueCampaign;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_PassScoreReached")]
	internal virtual DarkLabel Label_PassScoreReached { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	[field: AccessedThroughProperty("TextBox_ScoringLog")]
	internal virtual DarkUITextBox TextBox_ScoringLog { get; set; }

	internal virtual DarkUIButton Button_ClearScoringLog
	{
		[CompilerGenerated]
		get
		{
			return _Button_ClearScoringLog;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _Button_ClearScoringLog;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ClearScoringLog = value;
			darkUIButton = _Button_ClearScoringLog;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("AGauge1")]
	internal virtual AGauge AGauge1 { get; set; }

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4 { get; set; }

	[field: AccessedThroughProperty("ElementHost1")]
	internal virtual ElementHost ElementHost1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	internal virtual DarkUIButton Button_RestartScenario
	{
		[CompilerGenerated]
		get
		{
			return _Button_RestartScenario;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _Button_RestartScenario;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RestartScenario = value;
			darkUIButton = _Button_RestartScenario;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	internal virtual DarkUIButton Button_RestartFromSave
	{
		[CompilerGenerated]
		get
		{
			return _Button_RestartFromSave;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIButton darkUIButton = _Button_RestartFromSave;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RestartFromSave = value;
			darkUIButton = _Button_RestartFromSave;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
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

	public Evaluation()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += Evaluation_Load;
		((Control)this).KeyDown += new KeyEventHandler(Evaluation_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(Evaluation_FormClosing);
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
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Expected O, but got Unknown
		//IL_0b2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_107d: Unknown result type (might be due to invalid IL or missing references)
		//IL_120e: Unknown result type (might be due to invalid IL or missing references)
		Label_Evaluation = new DarkLabel();
		Label_Score = new DarkLabel();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		Button_RestartScenario = new DarkUIButton();
		Label1 = new Label();
		AGauge1 = new AGauge();
		Label_PassScoreReached = new DarkLabel();
		Button_ContinueCampaign = new DarkUIButton();
		Button1 = new DarkUIButton();
		TabPage2 = new TabPage();
		TextBox1 = new DarkUITextBox();
		TabPage3 = new TabPage();
		Button_ClearScoringLog = new DarkUIButton();
		TextBox_ScoringLog = new DarkUITextBox();
		TabPage4 = new TabPage();
		ElementHost1 = new ElementHost();
		ScoringGraphControl1 = new ScoringGraphControl();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Button_RestartFromSave = new DarkUIButton();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)TabPage3).SuspendLayout();
		((Control)TabPage4).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)Label_Evaluation).Anchor = (AnchorStyles)9;
		Label_Evaluation.AutoSize = true;
		((Control)Label_Evaluation).Font = new Font("Segoe UI", 20f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label_Evaluation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Evaluation).Location = new Point(3, 267);
		((Control)Label_Evaluation).Name = "Label_Evaluation";
		((Control)Label_Evaluation).Size = new Size(216, 37);
		((Control)Label_Evaluation).TabIndex = 0;
		((Label)Label_Evaluation).Text = "Label_Evaluation";
		((Label)Label_Evaluation).TextAlign = (ContentAlignment)32;
		Label_Score.AutoSize = true;
		((Control)Label_Score).Font = new Font("Segoe UI", 16f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label_Score).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Score).Location = new Point(8, 319);
		((Control)Label_Score).Name = "Label_Score";
		((Control)Label_Score).Size = new Size(128, 30);
		((Control)Label_Score).TabIndex = 1;
		((Label)Label_Score).Text = "Label_Score";
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage3);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage4);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Dock = (DockStyle)5;
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(0, 0);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(707, 422);
		((Control)TabControl1).TabIndex = 2;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)Button1);
		((Control)TabPage1).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)TabPage1).Controls.Add((Control)(object)Label1);
		((Control)TabPage1).Controls.Add((Control)(object)AGauge1);
		((Control)TabPage1).Controls.Add((Control)(object)Label_PassScoreReached);
		((Control)TabPage1).Controls.Add((Control)(object)Label_Evaluation);
		((Control)TabPage1).Controls.Add((Control)(object)Label_Score);
		((Control)TabPage1).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(699, 394);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Evaluation";
		((ButtonBase)Button_RestartScenario).BackColor = Color.Transparent;
		((Control)Button_RestartScenario).ForeColor = SystemColors.Control;
		((Control)Button_RestartScenario).Location = new Point(159, 3);
		((Control)Button_RestartScenario).Name = "Button_RestartScenario";
		((Control)Button_RestartScenario).Padding = new Padding(5);
		Button_RestartScenario.RoundRadius = 0;
		((Control)Button_RestartScenario).Size = new Size(150, 28);
		((Control)Button_RestartScenario).TabIndex = 7;
		Button_RestartScenario.Text = "Restart Scenario";
		Label1.BorderStyle = (BorderStyle)2;
		((Control)Label1).ForeColor = Color.White;
		((Control)Label1).Location = new Point(10, 310);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(683, 2);
		((Control)Label1).TabIndex = 6;
		AGauge1.BaseArcColor = Color.Gray;
		AGauge1.BaseArcRadius = 120;
		AGauge1.BaseArcStart = 135;
		AGauge1.BaseArcSweep = 270;
		AGauge1.BaseArcWidth = 1;
		AGauge1.Cap_Idx = 1;
		AGauge1.CapColors = new Color[5]
		{
			Color.Black,
			Color.Black,
			Color.Black,
			Color.Black,
			Color.Black
		};
		AGauge1.CapPosition = new Point(10, 10);
		AGauge1.CapsPosition = new Point[5]
		{
			new Point(10, 10),
			new Point(10, 10),
			new Point(10, 10),
			new Point(10, 10),
			new Point(10, 10)
		};
		AGauge1.CapsText = new string[5] { "", "", "", "", "" };
		AGauge1.CapText = "";
		AGauge1.Center = new Point(125, 125);
		AGauge1.Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)AGauge1).Location = new Point(210, 24);
		AGauge1.MaxValue = 400f;
		AGauge1.MinValue = -100f;
		((Control)AGauge1).Name = "AGauge1";
		AGauge1.NeedleColor1 = AGauge.NeedleColorEnum.Gray;
		AGauge1.NeedleColor2 = Color.DimGray;
		AGauge1.NeedleRadius = 80;
		AGauge1.NeedleType = 0;
		AGauge1.NeedleWidth = 4;
		AGauge1.Range_Idx = 2;
		AGauge1.RangeColor = Color.Blue;
		AGauge1.RangeEnabled = true;
		AGauge1.RangeEndValue = 0f;
		AGauge1.RangeInnerRadius = 70;
		AGauge1.RangeOuterRadius = 80;
		AGauge1.RangesColor = new Color[5]
		{
			Color.Red,
			Color.LightGray,
			Color.Blue,
			SystemColors.Control,
			SystemColors.Control
		};
		AGauge1.RangesEnabled = new bool[5] { true, true, true, false, false };
		AGauge1.RangesEndValue = new float[5] { 300f, 400f, 0f, 0f, 0f };
		AGauge1.RangesInnerRadius = new int[5] { 70, 70, 70, 70, 70 };
		AGauge1.RangesOuterRadius = new int[5] { 80, 80, 80, 80, 80 };
		AGauge1.RangesStartValue = new float[5] { -100f, 300f, 0f, 0f, 0f };
		AGauge1.RangeStartValue = 0f;
		AGauge1.ScaleLinesInterColor = Color.Transparent;
		AGauge1.ScaleLinesInterInnerRadius = 73;
		AGauge1.ScaleLinesInterOuterRadius = 80;
		AGauge1.ScaleLinesInterWidth = 0;
		AGauge1.ScaleLinesMajorColor = Color.Black;
		AGauge1.ScaleLinesMajorInnerRadius = 70;
		AGauge1.ScaleLinesMajorOuterRadius = 80;
		AGauge1.ScaleLinesMajorStepValue = 50f;
		AGauge1.ScaleLinesMajorWidth = 0;
		AGauge1.ScaleLinesMinorColor = Color.Gray;
		AGauge1.ScaleLinesMinorInnerRadius = 75;
		AGauge1.ScaleLinesMinorNumOf = 0;
		AGauge1.ScaleLinesMinorOuterRadius = 80;
		AGauge1.ScaleLinesMinorWidth = 1;
		AGauge1.ScaleNumbersColor = Color.LightGray;
		AGauge1.ScaleNumbersFormat = "F0";
		AGauge1.ScaleNumbersRadius = 95;
		AGauge1.ScaleNumbersRotation = 0;
		AGauge1.ScaleNumbersStartScaleLine = 0;
		AGauge1.ScaleNumbersStepScaleLines = 1;
		((Control)AGauge1).Size = new Size(257, 235);
		((Control)AGauge1).TabIndex = 5;
		((Control)AGauge1).Text = "AGauge1";
		AGauge1.Value = 0f;
		Label_PassScoreReached.AutoSize = true;
		((Control)Label_PassScoreReached).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_PassScoreReached).Location = new Point(10, 364);
		((Control)Label_PassScoreReached).Name = "Label_PassScoreReached";
		((Control)Label_PassScoreReached).Size = new Size(135, 13);
		((Control)Label_PassScoreReached).TabIndex = 4;
		((Label)Label_PassScoreReached).Text = "Label_PassScoreReached";
		((Control)Button_ContinueCampaign).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_ContinueCampaign).BackColor = Color.Transparent;
		((Control)Button_ContinueCampaign).ForeColor = SystemColors.Control;
		((Control)Button_ContinueCampaign).Location = new Point(3, 4);
		((Control)Button_ContinueCampaign).Name = "Button_ContinueCampaign";
		((Control)Button_ContinueCampaign).Padding = new Padding(5);
		Button_ContinueCampaign.RoundRadius = 0;
		((Control)Button_ContinueCampaign).Size = new Size(150, 27);
		((Control)Button_ContinueCampaign).TabIndex = 3;
		Button_ContinueCampaign.Text = "Continue Campaign";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(539, 359);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(150, 28);
		((Control)Button1).TabIndex = 2;
		Button1.Text = "Quit Scenario";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)TextBox1);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(699, 394);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Losses & Expenditures";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		((Control)TextBox1).Dock = (DockStyle)5;
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(3, 3);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)2;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(693, 388);
		((Control)TextBox1).TabIndex = 0;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)Button_ClearScoringLog);
		((Control)TabPage3).Controls.Add((Control)(object)TextBox_ScoringLog);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Size = new Size(699, 394);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Scoring Log";
		((ButtonBase)Button_ClearScoringLog).BackColor = Color.Transparent;
		((Control)Button_ClearScoringLog).ForeColor = SystemColors.Control;
		((Control)Button_ClearScoringLog).Location = new Point(3, 3);
		((Control)Button_ClearScoringLog).Name = "Button_ClearScoringLog";
		((Control)Button_ClearScoringLog).Padding = new Padding(5);
		Button_ClearScoringLog.RoundRadius = 0;
		((Control)Button_ClearScoringLog).Size = new Size(75, 23);
		((Control)Button_ClearScoringLog).TabIndex = 2;
		Button_ClearScoringLog.Text = "Clear Log";
		((Control)TextBox_ScoringLog).Anchor = (AnchorStyles)15;
		TextBox_ScoringLog.AutoCompleteCustomSource = null;
		TextBox_ScoringLog.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_ScoringLog.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_ScoringLog).BackColor = Color.Transparent;
		((Control)TextBox_ScoringLog).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_ScoringLog.Image = null;
		TextBox_ScoringLog.Lines = null;
		((Control)TextBox_ScoringLog).Location = new Point(0, 29);
		TextBox_ScoringLog.MaxLength = 32767;
		TextBox_ScoringLog.Multiline = true;
		((Control)TextBox_ScoringLog).Name = "TextBox_ScoringLog";
		TextBox_ScoringLog.ReadOnly = false;
		TextBox_ScoringLog.ScrollBars = (ScrollBars)2;
		TextBox_ScoringLog.SelectionStart = 0;
		((Control)TextBox_ScoringLog).Size = new Size(699, 367);
		((Control)TextBox_ScoringLog).TabIndex = 1;
		TextBox_ScoringLog.TextAlign = (HorizontalAlignment)0;
		TextBox_ScoringLog.UseSystemPasswordChar = false;
		TextBox_ScoringLog.WatermarkText = "";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage4).Controls.Add((Control)(object)ElementHost1);
		TabPage4.Location = new Point(4, 24);
		((Control)TabPage4).Name = "ComNetworkLog";
		((Control)TabPage4).Padding = new Padding(3);
		((Control)TabPage4).Size = new Size(699, 394);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "Scoring Graph";
		((Control)ElementHost1).Dock = (DockStyle)5;
		((Control)ElementHost1).Location = new Point(3, 3);
		((Control)ElementHost1).Name = "ElementHost1";
		((Control)ElementHost1).Size = new Size(693, 388);
		((Control)ElementHost1).TabIndex = 0;
		((Control)ElementHost1).Text = "ElementHost1";
		ElementHost1.Child = (UIElement)(object)ScoringGraphControl1;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Button_ContinueCampaign);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Button_RestartScenario);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Button_RestartFromSave);
		((Control)FlowLayoutPanel1).Location = new Point(224, 319);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(469, 34);
		((Control)FlowLayoutPanel1).TabIndex = 8;
		((ButtonBase)Button_RestartFromSave).BackColor = Color.Transparent;
		((Control)Button_RestartFromSave).ForeColor = SystemColors.Control;
		((Control)Button_RestartFromSave).Location = new Point(315, 3);
		((Control)Button_RestartFromSave).Name = "Button_RestartFromSave";
		((Control)Button_RestartFromSave).Padding = new Padding(5);
		Button_RestartFromSave.RoundRadius = 0;
		((Control)Button_RestartFromSave).Size = new Size(150, 28);
		((Control)Button_RestartFromSave).TabIndex = 8;
		Button_RestartFromSave.Text = "Restart From Save";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(707, 422);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Evaluation";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Player Evaluation";
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage3).ResumeLayout(false);
		((Control)TabPage4).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public void ShowLossesFromString(string theLosses)
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				TextBox1.Text = theLosses;
			}));
		}
		else
		{
			TextBox1.Text = theLosses;
		}
	}

	public void ShowScoringFromString(string theScoring)
	{
		_Closure$__88-0 arg = default(_Closure$__88-0);
		_Closure$__88-0 CS$<>8__locals14 = new _Closure$__88-0(arg);
		CS$<>8__locals14.$VB$Me = this;
		CS$<>8__locals14.$VB$Local_ScenTime = Client.CurrentScenario.Time;
		CS$<>8__locals14.$VB$Local_TotalScore = 0;
		CS$<>8__locals14.$VB$Local_ScoringLog = new List<string>();
		if (!string.IsNullOrEmpty(theScoring))
		{
			string[] array = theScoring.Split(new char[1] { '\r' });
			if (array.Count() > 0)
			{
				CS$<>8__locals14.$VB$Local_ScenTime = Conversions.ToDate(array[0]);
				if (array.Count() > 1)
				{
					CS$<>8__locals14.$VB$Local_TotalScore = Conversions.ToInteger(array[1]);
					if (array.Count() > 2)
					{
						int num = array.Count() - 1;
						for (int i = 2; i <= num; i++)
						{
							CS$<>8__locals14.$VB$Local_ScoringLog.Add(array[i]);
						}
					}
				}
			}
		}
		if (((Control)this).InvokeRequired)
		{
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				CS$<>8__locals14.$VB$Me.method_2(CS$<>8__locals14.$VB$Local_ScoringLog, CS$<>8__locals14.$VB$Local_ScenTime, CS$<>8__locals14.$VB$Local_TotalScore, bool_4: false);
			}));
		}
		else
		{
			method_2(CS$<>8__locals14.$VB$Local_ScoringLog, CS$<>8__locals14.$VB$Local_ScenTime, CS$<>8__locals14.$VB$Local_TotalScore, bool_4: false);
		}
	}

	private void Evaluation_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (!Client.CurrentSide.Scoring_Disaster.HasValue && !Client.CurrentSide.Scoring_Triumph.HasValue)
		{
			bool_2 = true;
		}
		((Control)Button_RestartFromSave).Visible = method_13(".save");
		((Control)Button_RestartScenario).Visible = true;
		method_2(Client.CurrentSide.ScoringLog, Client.CurrentScenario.Time, Client.CurrentSide.get_TotalScore((Scenario)null, (string)null));
		if (Client.Realtime && Client.RealtimeTerminal.LastGameSpeed > 0)
		{
			((Control)Button_RestartFromSave).Visible = false;
			((Control)Button_RestartScenario).Visible = false;
			Client.RealtimeTerminal.SendLossesUpdateRequest();
			Client.RealtimeTerminal.SendScoringUpdateRequest();
		}
	}

	private void method_2(List<string> list_0, DateTime dateTime_0, int int_0, bool bool_4 = true)
	{
		EvaluationInProgress = true;
		if (Client.CurrentScenario.HasEnded)
		{
			method_10(0);
		}
		((Label)Label_Evaluation).Text = (bool_2 ? "No thresholds have been defined" : Client.EvaluateScoring());
		method_4(list_0, dateTime_0, int_0);
		method_5(int_0);
		((Control)Button1).Visible = !Client.CurrentScenario.HasEnded;
		if (!Client.CurrentScenario.IsRunningInCampaignMode)
		{
			((Control)Label_PassScoreReached).Visible = false;
			((Control)Button_ContinueCampaign).Visible = false;
		}
		else
		{
			((Control)Label_PassScoreReached).Visible = true;
			((Control)Button_ContinueCampaign).Visible = true;
			int? campaignScenarioPassScore = Campaign.GetCampaignScenarioPassScore(Client.CurrentScenario);
			if (campaignScenarioPassScore.HasValue && ((!campaignScenarioPassScore.HasValue) ? ((bool?)null) : new bool?(int_0 >= campaignScenarioPassScore.GetValueOrDefault())) == true)
			{
				((Label)Label_PassScoreReached).Text = "You have reached the pass-score for this campaign scenario!";
				Button_ContinueCampaign.Enabled = true;
			}
			else
			{
				((Label)Label_PassScoreReached).Text = "Your current scenario score (" + Conversions.ToString(int_0) + ") is still below the pass-score for this campaign scenario (" + ((!campaignScenarioPassScore.HasValue) ? null : Conversions.ToString(campaignScenarioPassScore.GetValueOrDefault())) + ")";
				Button_ContinueCampaign.Enabled = false;
			}
		}
		if (!Information.IsNothing((object)Client.CurrentSide))
		{
			if (!Client.CurrentScenario.HasEnded)
			{
				((Label)Label_Score).Text = "Current score: " + Conversions.ToString(int_0);
			}
			else
			{
				((Label)Label_Score).Text = "Final score: " + Conversions.ToString(int_0);
			}
			method_3(list_0);
		}
		if (bool_4)
		{
			TextBox1.Text = "AS OF: " + Conversions.ToString(dateTime_0) + "\r\n\r\n" + GameGeneral.GetAllSideLosses_AsString(Client.CurrentScenario);
		}
		EvaluationInProgress = false;
	}

	private void method_3(List<string> list_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in list_0)
		{
			stringBuilder.Append(item).Append("\r\n").Append("\r\n");
		}
		TextBox_ScoringLog.Text = stringBuilder.ToString();
	}

	private void method_4(List<string> list_0, DateTime dateTime_0, int int_0)
	{
		_Closure$__92-0 arg = default(_Closure$__92-0);
		_Closure$__92-0 CS$<>8__locals2 = new _Closure$__92-0(arg);
		if (list_0.Count != 0)
		{
			((UIElement)ScoringGraphControl1).Visibility = (Visibility)0;
			Regex regex = new Regex("^(\\d\\d)[./-](\\d\\d)[./-](\\d\\d\\d\\d) (\\d\\d):(\\d\\d): Score changed from (.+) to (.+)\\. Reason: (.+)$");
			List<(DateTime, int, string)> list = new List<(DateTime, int, string)>(list_0.Count * 2 + 1);
			list.Add((Client.CurrentScenario.StartTime, 0, "Initial Score"));
			foreach (string item3 in list_0)
			{
				Match match = regex.Match(item3);
				if (match.Success)
				{
					DateTime item = new DateTime(int.Parse(match.Groups[3].Value), int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value), 0);
					int.Parse(match.Groups[6].Value);
					int item2 = int.Parse(match.Groups[7].Value);
					string value = match.Groups[8].Value;
					list.Add((item, item2, value));
				}
			}
			list.Add((dateTime_0, int_0, "Current Score"));
			CS$<>8__locals2.$VB$Local_min_t = list.Min([SpecialName] ((DateTime, int, string) F) => F.Item1);
			ChartValues<ScoringDatapointViewModel> chartValues = new ChartValues<ScoringDatapointViewModel>();
			foreach (var item4 in list)
			{
				ScoringDatapointViewModel scoringDatapointViewModel = new ScoringDatapointViewModel();
				(scoringDatapointViewModel.DateTime, scoringDatapointViewModel.ScoreValue, scoringDatapointViewModel.Reason) = item4;
				chartValues.Add(scoringDatapointViewModel);
			}
			Charting.For<ScoringDatapointViewModel>(Mappers.Xy<ScoringDatapointViewModel>().X([SpecialName] (ScoringDatapointViewModel F) => (double)(F.DateTime - CS$<>8__locals2.$VB$Local_min_t).Ticks / 10000000.0).Y([SpecialName] (ScoringDatapointViewModel F) => F.ScoreValue));
			ScoringGraphControlViewModel scoringGraphControlViewModel = new ScoringGraphControlViewModel();
			scoringGraphControlViewModel.PlayerScore = chartValues;
			((FrameworkElement)ScoringGraphControl1).DataContext = scoringGraphControlViewModel;
		}
		else
		{
			((UIElement)ScoringGraphControl1).Visibility = (Visibility)1;
		}
	}

	private void method_5(int int_0)
	{
		AGauge1.MinValue = Math.Min(int_0, Client.CurrentSide.Scoring_Disaster.HasValue ? Client.CurrentSide.Scoring_Disaster.Value : 0);
		AGauge1.MaxValue = Math.Max(int_0, Client.CurrentSide.Scoring_Triumph.HasValue ? Client.CurrentSide.Scoring_Triumph.Value : 0);
		AGauge1.MinValue = (Client.CurrentSide.Scoring_Disaster.HasValue ? Client.CurrentSide.Scoring_Disaster.Value : (-100));
		AGauge1.MaxValue = (Client.CurrentSide.Scoring_Triumph.HasValue ? Client.CurrentSide.Scoring_Triumph.Value : 100);
		AGauge1.Value = int_0;
		int scoring_MinorDefeat = Client.CurrentSide.Scoring_MinorDefeat;
		int scoring_MajorVictory = Client.CurrentSide.Scoring_MajorVictory;
		AGauge1.ScaleLinesMajorStepValue = (float)((double)(Math.Abs(AGauge1.MaxValue) + Math.Abs(AGauge1.MinValue)) / 10.0);
		AGauge1.Range_Idx = 0;
		AGauge1.RangeStartValue = AGauge1.MinValue;
		AGauge1.RangeEndValue = scoring_MinorDefeat;
		AGauge1.Range_Idx = 1;
		AGauge1.RangeStartValue = scoring_MinorDefeat;
		AGauge1.RangeEndValue = scoring_MajorVictory;
		AGauge1.Range_Idx = 2;
		AGauge1.RangeStartValue = scoring_MajorVictory;
		AGauge1.RangeEndValue = AGauge1.MaxValue;
	}

	private void method_6(object sender, EventArgs e)
	{
		if (Client.Realtime && !Client.RealtimeAC)
		{
			((Form)this).Close();
			MyProject.Forms.MainForm.Realtime_Shutdown();
		}
		else
		{
			method_10(1);
			Client.CurrentScenario.EndScenario();
			method_2(Client.CurrentSide.ScoringLog, Client.CurrentScenario.Time, Client.CurrentSide.get_TotalScore((Scenario)null, (string)null));
		}
	}

	private void Evaluation_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Invalid comparison between Unknown and I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Invalid comparison between Unknown and I4
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Invalid comparison between Unknown and I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Invalid comparison between Unknown and I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Invalid comparison between Unknown and I4
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36 && (int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 107 && (int)e.KeyCode != 109 && ((int)e.KeyCode != 67 || (int)e.Modifiers != 131072) && ((int)e.KeyCode != 88 || (int)e.Modifiers != 131072)))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void Evaluation_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!Client.CurrentScenario.IsRunningInCampaignMode)
		{
			return;
		}
		List<string> list = new List<string>();
		Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		using List<string>.Enumerator enumerator = list.GetEnumerator();
		string current;
		Campaign campaign;
		do
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				campaign = Campaign.ReadFromFile(current);
				continue;
			}
			return;
		}
		while (Operators.CompareString(campaign.ID, Client.CurrentScenario.CampaignID, true) != 0);
		Campaign.UpdateHistory(current, campaign, Client.CurrentScenario);
		method_10(2);
		using List<Campaign.CampaignItem>.Enumerator enumerator2 = campaign.CampaignItems.GetEnumerator();
		while (true)
		{
			if (!enumerator2.MoveNext())
			{
				return;
			}
			Campaign.CampaignItem current2 = enumerator2.Current;
			if ((object)current2.GetType() != typeof(Campaign.ScenarioRecord) || Operators.CompareString(((Campaign.ScenarioRecord)current2).ID, Client.CurrentScenario.ObjectID, true) != 0)
			{
				continue;
			}
			int num = campaign.CampaignItems.IndexOf(current2);
			if (num == campaign.CampaignItems.Count - 1)
			{
				break;
			}
			Campaign.CampaignItem campaignItem = campaign.CampaignItems[num + 1];
			Type type = campaignItem.GetType();
			if (!(type == typeof(Campaign.ScenarioRecord)))
			{
				if (type == typeof(Campaign.AttachmentRecord))
				{
					method_8(campaignItem, campaign, current);
					if (campaignItem == campaign.CampaignItems.Last())
					{
						method_9(campaign);
					}
					else
					{
						method_8(campaign.CampaignItems[num + 2], campaign, current);
					}
					return;
				}
				continue;
			}
			method_8(campaignItem, campaign, current);
			return;
		}
		method_9(campaign);
	}

	private void method_8(Campaign.CampaignItem campaignItem_0, Campaign campaign_0, string string_0)
	{
		Type type = campaignItem_0.GetType();
		if (type == typeof(Campaign.ScenarioRecord))
		{
			string scenFileName = Path.GetDirectoryName(string_0) + "\\" + ((Campaign.ScenarioRecord)campaignItem_0).FileName;
			MyProject.Forms.CampaignScenarioWindow.SelectedCampaign = campaign_0;
			MyProject.Forms.CampaignScenarioWindow.ScenFileName = scenFileName;
			MyProject.Forms.CampaignScenarioWindow.CampaignSessionID = Client.CurrentScenario.CampaignSessionID;
			MyProject.Forms.CampaignScenarioWindow.CampaignScore = Client.CurrentScenario.CampaignScore + Client.CurrentSide.get_TotalScore(Client.CurrentScenario, (string)null);
			MyProject.Forms.CampaignScenarioWindow.LuaXml = Client.CurrentScenario.LuaXmlPassed;
			((Control)MyProject.Forms.CampaignScenarioWindow).Show();
			((Form)this).Close();
		}
		else if (type == typeof(Campaign.AttachmentRecord))
		{
			LuaSAO.ScenEdit_UseAttachment(((Campaign.AttachmentRecord)campaignItem_0).ID, null);
		}
	}

	private void method_9(Campaign campaign_0)
	{
		MyProject.Forms.CampaignEnd.theCampaign = campaign_0;
		((Control)MyProject.Forms.CampaignEnd).Show();
	}

	private bool method_10(int int_0)
	{
		List<string> list = new List<string>();
		bool result = false;
		string[] array = new string[3] { "Setup", "Quit", "Continue" };
		foreach (EventTrigger value in Client.CurrentScenario.EventTriggers.Values)
		{
			if (value.Type != EventTrigger.EventTriggerType.ScenEnded || !((EventTrigger_ScenEnded)value).get_IsFulfilled(Client.CurrentScenario))
			{
				continue;
			}
			foreach (SimEvent value2 in Client.CurrentScenario.SimEvents.Values)
			{
				if (!value2.IsActive || !value2.Triggers.Contains(value))
				{
					continue;
				}
				if (value2.get_ConditionsAreMet(Client.CurrentScenario))
				{
					if (value2.IsShown)
					{
						Client.CurrentScenario.AddMessage("Event: '" + value2.Description + "(" + array[int_0] + ")' has been fired.", null, LoggedMessage.MessageType.EventEngine, 1, "");
					}
					LuaSandBox.Singleton().SB_Lua()["stage"] = "none";
					foreach (EventAction action in value2.Actions)
					{
						LuaSandBox.Singleton().SB_Lua()["stage"] = int_0;
						action.Execute(Client.CurrentScenario, value2);
						string text = null;
						try
						{
							text = LuaSandBox.Singleton().SB_Lua().GetString("answer");
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						int num;
						if (text == null)
						{
							num = 1;
						}
						else
						{
							list.Add(text);
							num = 1;
						}
						result = (byte)num != 0;
					}
				}
				else if (value2.IsShown)
				{
					Client.CurrentScenario.AddMessage("Event: '" + value2.Description + "' was triggered but did NOT fire (at least one condition failed).", null, LoggedMessage.MessageType.EventEngine, 1, "");
				}
			}
		}
		return result;
	}

	private void method_11(object sender, EventArgs e)
	{
		Client.CurrentSide.ScoringLog.Clear();
		TextBox_ScoringLog.Clear();
	}

	private bool method_12(string string_0)
	{
		int result;
		if (!method_13(string_0))
		{
			result = 0;
		}
		else
		{
			if (File.Exists(Client.CurrentScenario.FullFilePath))
			{
				MyProject.Forms.ResumeFromSave.SelectedFilename = Client.CurrentScenario.FullFilePath;
				MyProject.Forms.ResumeFromSave.CampaignSessionID = Client.CurrentScenario.CampaignSessionID;
				((Control)MyProject.Forms.ResumeFromSave).Show();
				((Form)this).Close();
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool method_13(string string_0)
	{
		if (!string.IsNullOrEmpty(Client.CurrentScenario.FullFilePath))
		{
			return Operators.CompareString(Path.GetExtension(Client.CurrentScenario.FullFilePath), string_0, true) == 0;
		}
		return false;
	}

	private void method_14(object sender, EventArgs e)
	{
		method_12(".save");
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		if (method_12(".scen"))
		{
			return;
		}
		HashSet<string> hashSet = Directory.GetFiles(GameGeneral.ScenariosRootPath, "*.scen", SearchOption.AllDirectories).ToHashSet();
		try
		{
			if (!string.IsNullOrEmpty(Client.CurrentScenario.FileNamePath) && Directory.Exists(Client.CurrentScenario.FileNamePath))
			{
				string[] files = Directory.GetFiles(GameGeneral.ScenariosRootPath, "*.scen", SearchOption.TopDirectoryOnly);
				foreach (string item in files)
				{
					if (!hashSet.Contains(item))
					{
						hashSet.Add(item);
					}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		string text = "";
		DateTime t = DateTime.MaxValue;
		foreach (string item2 in hashSet)
		{
			if (Path.GetFileName(item2).StartsWith("Autosave"))
			{
				continue;
			}
			try
			{
				if (Operators.CompareString(ScenContainer.LoadFromFile(item2).ScenTitle, Client.CurrentScenario.Title, true) == 0)
				{
					DateTime lastWriteTime = File.GetLastWriteTime(item2);
					if (DateTime.Compare(lastWriteTime, t) < 0 || string.IsNullOrEmpty(text))
					{
						text = item2;
						t = lastWriteTime;
					}
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			DarkMessageBox.ShowInformation("Unable to automatically locate the starting scenario. Please make sure the original .scen file is present in Command's scenario folder or located in savefile's folder.", "Original scenario not found");
			MyProject.Forms.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
			((Control)MyProject.Forms.LoadScenario).Show();
			((Form)this).Close();
		}
		else
		{
			MyProject.Forms.ResumeFromSave.SelectedFilename = text;
			MyProject.Forms.ResumeFromSave.CampaignSessionID = Client.CurrentScenario.CampaignSessionID;
			((Control)MyProject.Forms.ResumeFromSave).Show();
			((Form)this).Close();
		}
	}

	static Evaluation()
	{
		Class72.smethod_20();
	}
}

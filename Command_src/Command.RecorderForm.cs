using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
public sealed class RecorderForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("TB_Snapshots")]
	[CompilerGenerated]
	private TrackBar _TB_Snapshots;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_LoadRecording")]
	private ToolStripButton _TSB_LoadRecording;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_GoToStart")]
	private ToolStripButton _TSB_GoToStart;

	[AccessedThroughProperty("TSB_StepBack")]
	[CompilerGenerated]
	private ToolStripButton _TSB_StepBack;

	[AccessedThroughProperty("TSB_Play")]
	[CompilerGenerated]
	private ToolStripButton _TSB_Play;

	[AccessedThroughProperty("TSB_StepForward")]
	[CompilerGenerated]
	private ToolStripButton _TSB_StepForward;

	[AccessedThroughProperty("TSB_GoToEnd")]
	[CompilerGenerated]
	private ToolStripButton _TSB_GoToEnd;

	[AccessedThroughProperty("TSB_LoadMostRecent")]
	[CompilerGenerated]
	private ToolStripButton _TSB_LoadMostRecent;

	[CompilerGenerated]
	[AccessedThroughProperty("OpenFileDialog1")]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	[AccessedThroughProperty("Timer2")]
	[CompilerGenerated]
	private Timer timer_1;

	private RecorderTape recorderTape_0;

	private int int_0;

	private Side side_0;

	[AccessedThroughProperty("BW1")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	private double double_0;

	private Scenario scenario_0;

	private bool bool_2;

	private string string_0;

	internal virtual TrackBar TB_Snapshots
	{
		[CompilerGenerated]
		get
		{
			return _TB_Snapshots;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_10);
			MouseEventHandler val2 = new MouseEventHandler(method_15);
			TrackBar val3 = _TB_Snapshots;
			if (val3 != null)
			{
				((Control)val3).MouseMove -= val;
				((Control)val3).MouseUp -= val2;
			}
			_TB_Snapshots = value;
			val3 = _TB_Snapshots;
			if (val3 != null)
			{
				((Control)val3).MouseMove += val;
				((Control)val3).MouseUp += val2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	internal virtual ToolStripButton TSB_LoadRecording
	{
		[CompilerGenerated]
		get
		{
			return _TSB_LoadRecording;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			ToolStripButton val = _TSB_LoadRecording;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_LoadRecording = value;
			val = _TSB_LoadRecording;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal virtual ToolStripSeparator ToolStripSeparator1 { get; set; }

	internal virtual ToolStripButton TSB_GoToStart
	{
		[CompilerGenerated]
		get
		{
			return _TSB_GoToStart;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			ToolStripButton val = _TSB_GoToStart;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_GoToStart = value;
			val = _TSB_GoToStart;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_StepBack
	{
		[CompilerGenerated]
		get
		{
			return _TSB_StepBack;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			ToolStripButton val = _TSB_StepBack;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_StepBack = value;
			val = _TSB_StepBack;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_Play
	{
		[CompilerGenerated]
		get
		{
			return _TSB_Play;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			ToolStripButton val = _TSB_Play;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_TSB_Play = value;
			val = _TSB_Play;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_StepForward
	{
		[CompilerGenerated]
		get
		{
			return _TSB_StepForward;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			ToolStripButton val = _TSB_StepForward;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_StepForward = value;
			val = _TSB_StepForward;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_GoToEnd
	{
		[CompilerGenerated]
		get
		{
			return _TSB_GoToEnd;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			ToolStripButton val = _TSB_GoToEnd;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_GoToEnd = value;
			val = _TSB_GoToEnd;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_LoadMostRecent
	{
		[CompilerGenerated]
		get
		{
			return _TSB_LoadMostRecent;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			ToolStripButton val = _TSB_LoadMostRecent;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_LoadMostRecent = value;
			val = _TSB_LoadMostRecent;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_0 = value;
		}
	}

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			Timer val = timer_0;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_0 = value;
			val = timer_0;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	internal virtual Timer Timer2
	{
		[CompilerGenerated]
		get
		{
			return timer_1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			Timer val = timer_1;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_1 = value;
			val = timer_1;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkToolStrip1")]
	internal virtual DarkToolStrip DarkToolStrip1 { get; set; }

	[field: AccessedThroughProperty("TSL1")]
	internal virtual ToolStripLabel TSL1 { get; set; }

	[field: AccessedThroughProperty("TSSL_BadFrame")]
	internal virtual ToolStripLabel TSSL_BadFrame { get; set; }

	private virtual BackgroundWorker BW1
	{
		[CompilerGenerated]
		get
		{
			return backgroundWorker_0;
		}
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = method_17;
			RunWorkerCompletedEventHandler value3 = method_19;
			BackgroundWorker backgroundWorker = backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			backgroundWorker_0 = value;
			backgroundWorker = backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	public RecorderForm()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += RecorderForm_Load;
		((Control)this).KeyDown += new KeyEventHandler(RecorderForm_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(RecorderForm_FormClosing);
		((Form)this).Closing += RecorderForm_Closing;
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
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected O, but got Unknown
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Expected O, but got Unknown
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_0721: Expected O, but got Unknown
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_093c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0946: Expected O, but got Unknown
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RecorderForm));
		TB_Snapshots = new TrackBar();
		ToolStrip1 = new DarkToolStrip();
		TSB_LoadRecording = new ToolStripButton();
		TSB_LoadMostRecent = new ToolStripButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		TSB_GoToStart = new ToolStripButton();
		TSB_StepBack = new ToolStripButton();
		TSB_Play = new ToolStripButton();
		TSB_StepForward = new ToolStripButton();
		TSB_GoToEnd = new ToolStripButton();
		OpenFileDialog1 = new OpenFileDialog();
		Timer1 = new Timer(icontainer_1);
		Timer2 = new Timer(icontainer_1);
		DarkToolStrip1 = new DarkToolStrip();
		TSL1 = new ToolStripLabel();
		TSSL_BadFrame = new ToolStripLabel();
		((ISupportInitialize)TB_Snapshots).BeginInit();
		((Control)ToolStrip1).SuspendLayout();
		((Control)DarkToolStrip1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TB_Snapshots).Anchor = (AnchorStyles)13;
		((Control)TB_Snapshots).Location = new Point(0, 28);
		((Control)TB_Snapshots).Name = "TB_Snapshots";
		((Control)TB_Snapshots).Size = new Size(464, 45);
		((Control)TB_Snapshots).TabIndex = 0;
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[8]
		{
			(ToolStripItem)TSB_LoadRecording,
			(ToolStripItem)TSB_LoadMostRecent,
			(ToolStripItem)ToolStripSeparator1,
			(ToolStripItem)TSB_GoToStart,
			(ToolStripItem)TSB_StepBack,
			(ToolStripItem)TSB_Play,
			(ToolStripItem)TSB_StepForward,
			(ToolStripItem)TSB_GoToEnd
		});
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(464, 25);
		((Control)ToolStrip1).TabIndex = 1;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)TSB_LoadRecording).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_LoadRecording).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_LoadRecording).Image = (Image)componentResourceManager.GetObject("TSB_LoadRecording.Image");
		((ToolStripItem)TSB_LoadRecording).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_LoadRecording).Name = "TSB_LoadRecording";
		((ToolStripItem)TSB_LoadRecording).Size = new Size(53, 22);
		((ToolStripItem)TSB_LoadRecording).Text = "Load";
		((ToolStripItem)TSB_LoadMostRecent).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_LoadMostRecent).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_LoadMostRecent).Image = (Image)componentResourceManager.GetObject("TSB_LoadMostRecent.Image");
		((ToolStripItem)TSB_LoadMostRecent).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_LoadMostRecent).Name = "TSB_LoadMostRecent";
		((ToolStripItem)TSB_LoadMostRecent).Size = new Size(119, 22);
		((ToolStripItem)TSB_LoadMostRecent).Text = "Load most recent";
		((ToolStripItem)ToolStripSeparator1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripSeparator1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripSeparator1).Margin = new Padding(0, 0, 2, 0);
		((ToolStripItem)ToolStripSeparator1).Name = "ToolStripSeparator1";
		((ToolStripItem)ToolStripSeparator1).Size = new Size(6, 25);
		((ToolStripItem)TSB_GoToStart).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_GoToStart).DisplayStyle = (ToolStripItemDisplayStyle)2;
		((ToolStripItem)TSB_GoToStart).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_GoToStart).Image = (Image)componentResourceManager.GetObject("TSB_GoToStart.Image");
		((ToolStripItem)TSB_GoToStart).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_GoToStart).Name = "TSB_GoToStart";
		((ToolStripItem)TSB_GoToStart).Size = new Size(23, 22);
		((ToolStripItem)TSB_GoToStart).Text = "TSB_GoToStart";
		((ToolStripItem)TSB_GoToStart).ToolTipText = "Jump to start of recording";
		((ToolStripItem)TSB_StepBack).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_StepBack).DisplayStyle = (ToolStripItemDisplayStyle)2;
		((ToolStripItem)TSB_StepBack).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_StepBack).Image = (Image)componentResourceManager.GetObject("TSB_StepBack.Image");
		((ToolStripItem)TSB_StepBack).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_StepBack).Name = "TSB_StepBack";
		((ToolStripItem)TSB_StepBack).Size = new Size(23, 22);
		((ToolStripItem)TSB_StepBack).Text = "TSB_Reverse";
		((ToolStripItem)TSB_StepBack).ToolTipText = "Step Back";
		((ToolStripItem)TSB_Play).BackColor = Color.FromArgb(60, 63, 65);
		TSB_Play.CheckOnClick = true;
		((ToolStripItem)TSB_Play).DisplayStyle = (ToolStripItemDisplayStyle)2;
		((ToolStripItem)TSB_Play).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Play).Image = (Image)componentResourceManager.GetObject("TSB_Play.Image");
		((ToolStripItem)TSB_Play).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Play).Name = "TSB_Play";
		((ToolStripItem)TSB_Play).Size = new Size(23, 22);
		((ToolStripItem)TSB_Play).Text = "Play/Pause";
		((ToolStripItem)TSB_Play).ToolTipText = "Pause";
		((ToolStripItem)TSB_StepForward).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_StepForward).DisplayStyle = (ToolStripItemDisplayStyle)2;
		((ToolStripItem)TSB_StepForward).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_StepForward).Image = (Image)componentResourceManager.GetObject("TSB_StepForward.Image");
		((ToolStripItem)TSB_StepForward).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_StepForward).Name = "TSB_StepForward";
		((ToolStripItem)TSB_StepForward).Size = new Size(23, 22);
		((ToolStripItem)TSB_StepForward).Text = "TSB_Play";
		((ToolStripItem)TSB_StepForward).ToolTipText = "Step Forward";
		((ToolStripItem)TSB_GoToEnd).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_GoToEnd).DisplayStyle = (ToolStripItemDisplayStyle)2;
		((ToolStripItem)TSB_GoToEnd).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_GoToEnd).Image = (Image)componentResourceManager.GetObject("TSB_GoToEnd.Image");
		((ToolStripItem)TSB_GoToEnd).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_GoToEnd).Name = "TSB_GoToEnd";
		((ToolStripItem)TSB_GoToEnd).Size = new Size(23, 22);
		((ToolStripItem)TSB_GoToEnd).Text = "TSB_GoToEnd";
		((ToolStripItem)TSB_GoToEnd).ToolTipText = "Jump to end of recording";
		((FileDialog)OpenFileDialog1).FileName = "OpenFileDialog1";
		Timer1.Interval = 500;
		Timer2.Interval = 50;
		((ToolStrip)DarkToolStrip1).AutoSize = false;
		((ToolStrip)DarkToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)DarkToolStrip1).Dock = (DockStyle)2;
		((ToolStrip)DarkToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)DarkToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)DarkToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)TSL1,
			(ToolStripItem)TSSL_BadFrame
		});
		((Control)DarkToolStrip1).Location = new Point(0, 57);
		((Control)DarkToolStrip1).Name = "DarkToolStrip1";
		((Control)DarkToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)DarkToolStrip1).Size = new Size(464, 28);
		((Control)DarkToolStrip1).TabIndex = 2;
		((Control)DarkToolStrip1).Text = "DarkToolStrip1";
		((ToolStripItem)TSL1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL1).Name = "TSL1";
		((ToolStripItem)TSL1).Size = new Size(32, 25);
		((ToolStripItem)TSL1).Text = "TSL1";
		((ToolStripItem)TSSL_BadFrame).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSSL_BadFrame).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSSL_BadFrame).Image = (Image)componentResourceManager.GetObject("TSSL_BadFrame.Image");
		((ToolStripItem)TSSL_BadFrame).Name = "TSSL_BadFrame";
		((ToolStripItem)TSSL_BadFrame).Size = new Size(106, 25);
		((ToolStripItem)TSSL_BadFrame).Text = "TSSL_BadFrame";
		((ToolStripItem)TSSL_BadFrame).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(464, 85);
		((Control)this).Controls.Add((Control)(object)DarkToolStrip1);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Control)this).Controls.Add((Control)(object)TB_Snapshots);
		((Control)this).DoubleBuffered = true;
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "RecorderForm";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Replay Viewer";
		((Form)this).TopMost = true;
		((ISupportInitialize)TB_Snapshots).EndInit();
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)DarkToolStrip1).ResumeLayout(false);
		((Control)DarkToolStrip1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[SpecialName]
	private int method_2()
	{
		return int_0;
	}

	[SpecialName]
	private void method_3(int int_1)
	{
		int_0 = int_1;
		side_0 = Client.CurrentScenario.GetCurrentSide();
		while (BW1.IsBusy)
		{
			Application.DoEvents();
		}
		BW1.RunWorkerAsync();
		double_0 = 0.0;
		((ToolStripItem)TSL1).Visible = true;
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		((FileDialog)OpenFileDialog1).InitialDirectory = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Recordings" + Conversions.ToString(Path.DirectorySeparatorChar);
		if ((int)((CommonDialog)OpenFileDialog1).ShowDialog() == 1)
		{
			string fileName = ((FileDialog)OpenFileDialog1).FileName;
			method_6(fileName);
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		string text = Recorder.FilenameOfMostRecentTape();
		if (string.IsNullOrEmpty(text))
		{
			DarkMessageBox.ShowError("No VCR files can be found.", "No files present!");
		}
		else
		{
			method_6(text);
		}
	}

	private void method_6(string string_1)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		recorderTape_0 = Recorder.GetTape(string_1);
		if (recorderTape_0.SnapshotList.Count == 0)
		{
			DarkMessageBox.ShowError("This recording does not have any saved snapshots! Please load another recording.", "Error");
			recorderTape_0 = null;
			return;
		}
		TB_Snapshots.Maximum = recorderTape_0.SnapshotList.Count - 1;
		TB_Snapshots.Value = 0;
		string_0 = "TapeLoad";
		method_3(recorderTape_0.SnapshotList[0].Item1);
		((ToolStripItem)TSB_GoToEnd).Enabled = true;
		((ToolStripItem)TSB_GoToStart).Enabled = true;
		((ToolStripItem)TSB_Play).Enabled = true;
		((ToolStripItem)TSB_StepBack).Enabled = true;
		((ToolStripItem)TSB_StepForward).Enabled = true;
		((Control)TB_Snapshots).Enabled = true;
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!TSB_Play.Checked)
		{
			if (BW1.IsBusy)
			{
				BW1.CancelAsync();
			}
			TSB_Play.Checked = false;
			((ToolStripItem)TSB_Play).Image = Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Menu\\Run.gif");
			Timer1.Stop();
		}
		else
		{
			TSB_Play.Checked = true;
			((ToolStripItem)TSB_Play).Image = Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Menu\\Pause.gif");
			Timer1.Start();
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		if (BW1.IsBusy)
		{
			BW1.CancelAsync();
		}
		string_0 = "TapeStep";
		method_3(recorderTape_0.SnapshotList[0].Item1);
	}

	private void method_9(object sender, EventArgs e)
	{
		if (BW1.IsBusy)
		{
			BW1.CancelAsync();
		}
		string_0 = "TapeStep";
		method_3(recorderTape_0.SnapshotList[recorderTape_0.SnapshotList.Count - 1].Item1);
	}

	private void method_10(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)e.Button == 1048576)
		{
			TSB_Play.Checked = false;
			((Form)this).Text = "Scenario time: " + recorderTape_0.SnapshotList[TB_Snapshots.Value].Item2.ToShortDateString() + " " + recorderTape_0.SnapshotList[TB_Snapshots.Value].Item2.ToShortTimeString() + " GMT - Release mouse button to load!";
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		method_14();
	}

	private void method_12(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_13()
	{
		if (TB_Snapshots.Value != TB_Snapshots.Maximum - 1)
		{
			if (BW1.IsBusy)
			{
				BW1.CancelAsync();
			}
			TB_Snapshots.Value = Math.Min(TB_Snapshots.Maximum, TB_Snapshots.Value + 1);
			string_0 = "TapeStep";
			method_3(recorderTape_0.SnapshotList[TB_Snapshots.Value].Item1);
		}
	}

	private void method_14()
	{
		if (TB_Snapshots.Value != 0)
		{
			if (BW1.IsBusy)
			{
				BW1.CancelAsync();
			}
			TB_Snapshots.Value = Math.Max(TB_Snapshots.Minimum, TB_Snapshots.Value - 1);
			string_0 = "TapeStep";
			method_3(recorderTape_0.SnapshotList[TB_Snapshots.Value].Item1);
		}
	}

	private void method_15(object sender, MouseEventArgs e)
	{
		((Form)this).Text = "Replay Viewer";
		method_3(recorderTape_0.SnapshotList[TB_Snapshots.Value].Item1);
	}

	private void RecorderForm_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		BW1 = new BackgroundWorker();
		BW1.WorkerSupportsCancellation = true;
		Timer2.Start();
		((ToolStripItem)TSB_GoToEnd).Enabled = false;
		((ToolStripItem)TSB_GoToStart).Enabled = false;
		((ToolStripItem)TSB_Play).Enabled = false;
		((ToolStripItem)TSB_StepBack).Enabled = false;
		((ToolStripItem)TSB_StepForward).Enabled = false;
		((Control)TB_Snapshots).Enabled = false;
	}

	private void method_16(object sender, EventArgs e)
	{
		if (!Client.VCRPlaybackInProgress && TB_Snapshots.Value != TB_Snapshots.Maximum)
		{
			TB_Snapshots.Value += 1;
			string_0 = "TapeStep";
			method_3(recorderTape_0.SnapshotList[TB_Snapshots.Value].Item1);
		}
	}

	private void method_17(object sender, DoWorkEventArgs e)
	{
		Client.VCRPlaybackInProgress = true;
		try
		{
			scenario_0 = recorderTape_0.GetSnapshot(method_2(), [SpecialName] (double d) =>
			{
				double_0 = d;
			});
			bool_2 = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			bool_2 = true;
			ProjectData.ClearProjectError();
		}
	}

	private void method_18()
	{
		if (TSB_Play.Checked | TSB_StepForward.Checked)
		{
			method_13();
		}
		if (TSB_StepBack.Checked)
		{
			method_14();
		}
	}

	private void method_19(object sender, RunWorkerCompletedEventArgs e)
	{
		if (!bool_2)
		{
			((ToolStripItem)TSSL_BadFrame).Visible = false;
			if (!Information.IsNothing((object)side_0))
			{
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (Operators.CompareString(side.ObjectID, side_0.ObjectID, true) == 0)
					{
						scenario_0.SetCurrentSide(side);
						break;
					}
				}
			}
			((ToolStripItem)TSL1).Visible = false;
			Client.SetCurrentScenario(scenario_0, bool_10: true);
			Client.VCRPlaybackInProgress = false;
			if (Operators.CompareString(string_0, "TapeLoad", true) == 0 && !Information.IsNothing((object)side_0) && Operators.CompareString(side_0.ObjectID, Client.CurrentSide.ObjectID, true) != 0)
			{
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, Client.CurrentScenario.GetCurrentSide().MapCenter);
				MyProject.Forms.MainForm.CameraAltitude = (int)Math.Round(Client.CurrentScenario.GetCurrentSide().CameraAlt);
			}
		}
		else
		{
			((ToolStripItem)TSSL_BadFrame).Visible = true;
			method_18();
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		((ToolStripItem)TSL1).Text = "Loading frame..." + Conversions.ToString((int)Math.Round(double_0 * 100.0)) + "%";
	}

	private void RecorderForm_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void RecorderForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void RecorderForm_Closing(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
		((Control)this).Hide();
	}

	static RecorderForm()
	{
		Class72.smethod_20();
	}
}

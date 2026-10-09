using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditWeather : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("TrackBar_Rainfall")]
	[CompilerGenerated]
	private TrackBar _TrackBar_Rainfall;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_FUR")]
	private TrackBar _TrackBar_FUR;

	[AccessedThroughProperty("TrackBar_AverageTemp")]
	[CompilerGenerated]
	private TrackBar _TrackBar_AverageTemp;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_SeaState")]
	private TrackBar _TrackBar_SeaState;

	[AccessedThroughProperty("DayNightInput")]
	[CompilerGenerated]
	private DarkTextBox _DayNightInput;

	[AccessedThroughProperty("GeneralToolTip")]
	[CompilerGenerated]
	private ToolTip toolTip_0;

	private Weather.WeatherProfile weatherProfile_0;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal virtual ToolStripLabel ToolStripLabel1 { get; set; }

	[field: AccessedThroughProperty("TSDD_WeatherLevel")]
	internal virtual ToolStripDropDownButton TSDD_WeatherLevel { get; set; }

	[field: AccessedThroughProperty("TC_WeatherLevel")]
	internal virtual DarkUITabControl TC_WeatherLevel { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	internal virtual TrackBar TrackBar_Rainfall
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_Rainfall;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			TrackBar val = _TrackBar_Rainfall;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_Rainfall = value;
			val = _TrackBar_Rainfall;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	internal virtual TrackBar TrackBar_FUR
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_FUR;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			TrackBar val = _TrackBar_FUR;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_FUR = value;
			val = _TrackBar_FUR;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_AverageTemp")]
	internal virtual DarkLabel Label_AverageTemp { get; set; }

	internal virtual TrackBar TrackBar_AverageTemp
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_AverageTemp;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			TrackBar val = _TrackBar_AverageTemp;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_AverageTemp = value;
			val = _TrackBar_AverageTemp;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("Label10")]
	internal virtual DarkLabel Label10 { get; set; }

	internal virtual TrackBar TrackBar_SeaState
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_SeaState;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			TrackBar val = _TrackBar_SeaState;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_SeaState = value;
			val = _TrackBar_SeaState;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	internal virtual DarkTextBox DayNightInput
	{
		[CompilerGenerated]
		get
		{
			return _DayNightInput;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkTextBox darkTextBox = _DayNightInput;
			if (darkTextBox != null)
			{
				((Control)darkTextBox).TextChanged -= eventHandler;
			}
			_DayNightInput = value;
			darkTextBox = _DayNightInput;
			if (darkTextBox != null)
			{
				((Control)darkTextBox).TextChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DayNightLabel")]
	internal virtual DarkLabel DayNightLabel { get; set; }

	internal virtual ToolTip GeneralToolTip
	{
		[CompilerGenerated]
		get
		{
			return toolTip_0;
		}
		[CompilerGenerated]
		set
		{
			toolTip_0 = value;
		}
	}

	public EditWeather()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += EditWeather_Load;
		((Control)this).KeyDown += new KeyEventHandler(EditWeather_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(EditWeather_FormClosing);
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a4: Expected O, but got Unknown
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0848: Expected O, but got Unknown
		//IL_0953: Unknown result type (might be due to invalid IL or missing references)
		//IL_095d: Expected O, but got Unknown
		//IL_09f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fd: Expected O, but got Unknown
		//IL_0b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2b: Expected O, but got Unknown
		//IL_0bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bce: Expected O, but got Unknown
		//IL_0c67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c71: Expected O, but got Unknown
		//IL_0d0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d14: Expected O, but got Unknown
		//IL_0e8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Expected O, but got Unknown
		//IL_0f2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f35: Expected O, but got Unknown
		//IL_0fca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd4: Expected O, but got Unknown
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(EditWeather));
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TSDD_WeatherLevel = new ToolStripDropDownButton();
		TC_WeatherLevel = new DarkUITabControl();
		TabPage1 = new TabPage();
		DayNightLabel = new DarkLabel();
		DayNightInput = new DarkTextBox();
		Label9 = new DarkLabel();
		Label10 = new DarkLabel();
		TrackBar_SeaState = new TrackBar();
		Label8 = new DarkLabel();
		Label_AverageTemp = new DarkLabel();
		TrackBar_AverageTemp = new TrackBar();
		Label7 = new DarkLabel();
		Label6 = new DarkLabel();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		TrackBar_Rainfall = new TrackBar();
		TrackBar_FUR = new TrackBar();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		GeneralToolTip = new ToolTip(icontainer_1);
		((Control)ToolStrip1).SuspendLayout();
		((Control)TC_WeatherLevel).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((ISupportInitialize)TrackBar_SeaState).BeginInit();
		((ISupportInitialize)TrackBar_AverageTemp).BeginInit();
		((ISupportInitialize)TrackBar_Rainfall).BeginInit();
		((ISupportInitialize)TrackBar_FUR).BeginInit();
		((Control)this).SuspendLayout();
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)ToolStripLabel1,
			(ToolStripItem)TSDD_WeatherLevel
		});
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(563, 25);
		((Control)ToolStrip1).TabIndex = 0;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)ToolStripLabel1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel1).Name = "ToolStripLabel1";
		((ToolStripItem)ToolStripLabel1).Size = new Size(138, 22);
		((ToolStripItem)ToolStripLabel1).Text = "Weather modelling level:";
		((ToolStripItem)TSDD_WeatherLevel).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSDD_WeatherLevel).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSDD_WeatherLevel).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSDD_WeatherLevel).Image = (Image)componentResourceManager.GetObject("TSDD_WeatherLevel.Image");
		((ToolStripItem)TSDD_WeatherLevel).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSDD_WeatherLevel).Name = "TSDD_WeatherLevel";
		((ToolStripItem)TSDD_WeatherLevel).Size = new Size(56, 22);
		((ToolStripItem)TSDD_WeatherLevel).Text = "Level 0";
		((Control)TC_WeatherLevel).Controls.Add((Control)(object)TabPage1);
		((Control)TC_WeatherLevel).Cursor = Cursors.Hand;
		((Control)TC_WeatherLevel).Dock = (DockStyle)5;
		((TabControl)TC_WeatherLevel).ItemSize = new Size(80, 20);
		((Control)TC_WeatherLevel).Location = new Point(0, 25);
		((TabControl)TC_WeatherLevel).Multiline = true;
		((Control)TC_WeatherLevel).Name = "TC_WeatherLevel";
		((TabControl)TC_WeatherLevel).SelectedIndex = 0;
		((Control)TC_WeatherLevel).Size = new Size(563, 196);
		((Control)TC_WeatherLevel).TabIndex = 19;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)DayNightLabel);
		((Control)TabPage1).Controls.Add((Control)(object)DayNightInput);
		((Control)TabPage1).Controls.Add((Control)(object)Label9);
		((Control)TabPage1).Controls.Add((Control)(object)Label10);
		((Control)TabPage1).Controls.Add((Control)(object)TrackBar_SeaState);
		((Control)TabPage1).Controls.Add((Control)(object)Label8);
		((Control)TabPage1).Controls.Add((Control)(object)Label_AverageTemp);
		((Control)TabPage1).Controls.Add((Control)(object)TrackBar_AverageTemp);
		((Control)TabPage1).Controls.Add((Control)(object)Label7);
		((Control)TabPage1).Controls.Add((Control)(object)Label6);
		((Control)TabPage1).Controls.Add((Control)(object)Label5);
		((Control)TabPage1).Controls.Add((Control)(object)Label4);
		((Control)TabPage1).Controls.Add((Control)(object)TrackBar_Rainfall);
		((Control)TabPage1).Controls.Add((Control)(object)TrackBar_FUR);
		((Control)TabPage1).Controls.Add((Control)(object)Label3);
		((Control)TabPage1).Controls.Add((Control)(object)Label2);
		((Control)TabPage1).Controls.Add((Control)(object)Label1);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(555, 168);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Level 0";
		DayNightLabel.AutoSize = true;
		((Control)DayNightLabel).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)DayNightLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DayNightLabel).Location = new Point(8, 139);
		((Control)DayNightLabel).Name = "DayNightLabel";
		((Control)DayNightLabel).Size = new Size(238, 21);
		((Control)DayNightLabel).TabIndex = 21;
		((Label)DayNightLabel).Text = "Day-Night temperature modifier:";
		GeneralToolTip.SetToolTip((Control)(object)DayNightLabel, "Adjusts average temperature depending on time of day.\r\nDaytime adds this value,\r\nTwilight keeps it unchanged,\r\nNighttime subtracts it.");
		((TextBoxBase)DayNightInput).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)DayNightInput).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DayNightInput).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DayNightInput).Location = new Point(261, 139);
		((Control)DayNightInput).MaximumSize = new Size(40, 20);
		((Control)DayNightInput).Name = "DayNightInput";
		((Control)DayNightInput).Size = new Size(40, 20);
		((Control)DayNightInput).TabIndex = 20;
		((TextBox)DayNightInput).TextAlign = (HorizontalAlignment)2;
		GeneralToolTip.SetToolTip((Control)(object)DayNightInput, "Adjusts average temperature depending on time of day.\r\nDaytime adds this value,\r\nTwilight keeps it unchanged,\r\nNighttime subtracts it.");
		Label9.AutoSize = true;
		((Control)Label9).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(410, 113);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(57, 13);
		((Control)Label9).TabIndex = 14;
		((Label)Label9).Text = "Hurricane";
		Label10.AutoSize = true;
		((Control)Label10).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label10).Location = new Point(144, 111);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(33, 13);
		((Control)Label10).TabIndex = 13;
		((Label)Label10).Text = "Calm";
		TrackBar_SeaState.AutoSize = false;
		TrackBar_SeaState.LargeChange = 10;
		((Control)TrackBar_SeaState).Location = new Point(177, 109);
		TrackBar_SeaState.Maximum = 9;
		((Control)TrackBar_SeaState).Name = "TrackBar_SeaState";
		((Control)TrackBar_SeaState).Size = new Size(239, 31);
		((Control)TrackBar_SeaState).TabIndex = 12;
		Label8.AutoSize = true;
		((Control)Label8).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(8, 109);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(126, 21);
		((Control)Label8).TabIndex = 11;
		((Label)Label8).Text = "Wind / Sea state:";
		Label_AverageTemp.AutoSize = true;
		((Control)Label_AverageTemp).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label_AverageTemp).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AverageTemp).Location = new Point(410, 20);
		((Control)Label_AverageTemp).Name = "Label_AverageTemp";
		((Control)Label_AverageTemp).Size = new Size(21, 13);
		((Control)Label_AverageTemp).TabIndex = 10;
		((Label)Label_AverageTemp).Text = "° C";
		TrackBar_AverageTemp.AutoSize = false;
		TrackBar_AverageTemp.LargeChange = 10;
		((Control)TrackBar_AverageTemp).Location = new Point(177, 15);
		TrackBar_AverageTemp.Maximum = 50;
		TrackBar_AverageTemp.Minimum = -50;
		((Control)TrackBar_AverageTemp).Name = "TrackBar_AverageTemp";
		((Control)TrackBar_AverageTemp).Size = new Size(239, 31);
		TrackBar_AverageTemp.SmallChange = 5;
		((Control)TrackBar_AverageTemp).TabIndex = 9;
		Label7.AutoSize = true;
		((Control)Label7).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(410, 82);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(117, 13);
		((Control)Label7).TabIndex = 8;
		((Label)Label7).Text = "Full with thick clouds";
		Label6.AutoSize = true;
		((Control)Label6).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(142, 82);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(33, 13);
		((Control)Label6).TabIndex = 7;
		((Label)Label6).Text = "Clear";
		Label5.AutoSize = true;
		((Control)Label5).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(410, 51);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(72, 13);
		((Control)Label5).TabIndex = 6;
		((Label)Label5).Text = "Heavy storm";
		Label4.AutoSize = true;
		((Control)Label4).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(130, 49);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(46, 13);
		((Control)Label4).TabIndex = 5;
		((Label)Label4).Text = "No rain";
		TrackBar_Rainfall.AutoSize = false;
		TrackBar_Rainfall.LargeChange = 10;
		((Control)TrackBar_Rainfall).Location = new Point(177, 46);
		TrackBar_Rainfall.Maximum = 50;
		((Control)TrackBar_Rainfall).Name = "TrackBar_Rainfall";
		((Control)TrackBar_Rainfall).Size = new Size(239, 31);
		TrackBar_Rainfall.SmallChange = 5;
		((Control)TrackBar_Rainfall).TabIndex = 4;
		TrackBar_FUR.AutoSize = false;
		TrackBar_FUR.LargeChange = 10;
		((Control)TrackBar_FUR).Location = new Point(177, 80);
		((Control)TrackBar_FUR).Name = "TrackBar_FUR";
		((Control)TrackBar_FUR).Size = new Size(239, 31);
		((Control)TrackBar_FUR).TabIndex = 3;
		Label3.AutoSize = true;
		((Control)Label3).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(8, 77);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(80, 21);
		((Control)Label3).TabIndex = 2;
		((Label)Label3).Text = "The sky is:";
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(8, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(96, 21);
		((Control)Label2).TabIndex = 1;
		((Label)Label2).Text = "Rainfall rate:";
		Label1.AutoSize = true;
		((Control)Label1).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(8, 15);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(160, 21);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Average temperature:";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(563, 221);
		((Control)this).Controls.Add((Control)(object)TC_WeatherLevel);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MaximumSize = new Size(579, 260);
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(579, 236);
		((Control)this).Name = "EditWeather";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Weather editor";
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)TC_WeatherLevel).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((ISupportInitialize)TrackBar_SeaState).EndInit();
		((ISupportInitialize)TrackBar_AverageTemp).EndInit();
		((ISupportInitialize)TrackBar_Rainfall).EndInit();
		((ISupportInitialize)TrackBar_FUR).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void EditWeather_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		weatherProfile_0 = Client.CurrentScenario.GlobalWeather;
		((TextBox)DayNightInput).Text = weatherProfile_0.DayNightTempModifier.ToString();
		TrackBar_AverageTemp.Value = (int)Math.Round(weatherProfile_0.AverageTemp);
		((Label)Label_AverageTemp).Text = Conversions.ToString(weatherProfile_0.AverageTemp) + " °C";
		TrackBar_Rainfall.Value = (int)Math.Round(weatherProfile_0.RainfallRate);
		TrackBar_FUR.Value = (int)Math.Round(weatherProfile_0.FractionUnderRain * 10f);
		TrackBar_SeaState.Value = weatherProfile_0.SeaState;
	}

	private void method_2(object sender, EventArgs e)
	{
		Client.CurrentScenario.GlobalWeather.AverageTemp = TrackBar_AverageTemp.Value;
		((Label)Label_AverageTemp).Text = Conversions.ToString(Client.CurrentScenario.GlobalWeather.AverageTemp) + " °C";
	}

	private void method_3(object sender, EventArgs e)
	{
		Client.CurrentScenario.GlobalWeather.RainfallRate = TrackBar_Rainfall.Value;
	}

	private void method_4(object sender, EventArgs e)
	{
		Client.CurrentScenario.GlobalWeather.FractionUnderRain = (float)((double)TrackBar_FUR.Value * 0.1);
	}

	private void method_5(object sender, EventArgs e)
	{
		Client.CurrentScenario.GlobalWeather.SeaState = TrackBar_SeaState.Value;
	}

	private void EditWeather_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void EditWeather_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_6(object sender, EventArgs e)
	{
		if (int.TryParse(((TextBox)DayNightInput).Text, out var result))
		{
			Client.CurrentScenario.GlobalWeather.DayNightTempModifier = result;
		}
	}

	static EditWeather()
	{
		Class72.smethod_20();
	}
}

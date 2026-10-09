using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class LOSTool : DarkSecondaryFormBase
{
	private enum Enum1 : short
	{
		Radar,
		Visual
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("TB_MaxRange")]
	[CompilerGenerated]
	private DarkUITextBox _TB_MaxRange;

	[AccessedThroughProperty("TB_TargetAlt")]
	[CompilerGenerated]
	private DarkUITextBox _TB_TargetAlt;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton EuudoCufPH;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	[AccessedThroughProperty("CB_HorizonType")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_HorizonType;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ShadeColor")]
	private DarkUIButton _Button_ShadeColor;

	[CompilerGenerated]
	[AccessedThroughProperty("ColorDialog_Shade")]
	private ColorDialog colorDialog_0;

	private double double_0;

	private double double_1;

	private float float_0;

	private bool bool_2;

	private ConcurrentQueue<Terrain.TerrainGridCell> concurrentQueue_0;

	private Enum1 enum1_0;

	private int int_0;

	private float float_1;

	private Task task_0;

	private CancellationTokenSource cancellationTokenSource_0;

	private Keys[] keys_0;

	[CompilerGenerated]
	private bool bool_3;

	private int int_1;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual DarkUITabControl TabControl1 { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	internal virtual DarkUITextBox TB_MaxRange
	{
		[CompilerGenerated]
		get
		{
			return _TB_MaxRange;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUITextBox.TextChangedEventHandler value2 = method_12;
			DarkUITextBox darkUITextBox = _TB_MaxRange;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave -= eventHandler;
				darkUITextBox.TextChanged -= value2;
			}
			_TB_MaxRange = value;
			darkUITextBox = _TB_MaxRange;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave += eventHandler;
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUITextBox TB_TargetAlt
	{
		[CompilerGenerated]
		get
		{
			return _TB_TargetAlt;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUITextBox.TextChangedEventHandler value2 = method_11;
			DarkUITextBox darkUITextBox = _TB_TargetAlt;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave -= eventHandler;
				darkUITextBox.TextChanged -= value2;
			}
			_TB_TargetAlt = value;
			darkUITextBox = _TB_TargetAlt;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave += eventHandler;
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return EuudoCufPH;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = EuudoCufPH;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			EuudoCufPH = value;
			darkUIButton = EuudoCufPH;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
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
			EventHandler eventHandler = method_3;
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUIComboBox CB_HorizonType
	{
		[CompilerGenerated]
		get
		{
			return _CB_HorizonType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIComboBox darkUIComboBox = _CB_HorizonType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_HorizonType = value;
			darkUIComboBox = _CB_HorizonType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_AltitudeSameAsObserver")]
	internal virtual DarkCheckBox CB_AltitudeSameAsObserver { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	internal virtual DarkUIButton Button_ShadeColor
	{
		[CompilerGenerated]
		get
		{
			return _Button_ShadeColor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _Button_ShadeColor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ShadeColor = value;
			darkUIButton = _Button_ShadeColor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual ColorDialog ColorDialog_Shade
	{
		[CompilerGenerated]
		get
		{
			return colorDialog_0;
		}
		[CompilerGenerated]
		set
		{
			colorDialog_0 = value;
		}
	}

	[field: AccessedThroughProperty("Label_SelectedUnitName")]
	internal virtual DarkLabel Label_SelectedUnitName { get; set; }

	[field: AccessedThroughProperty("TrackBar_HowManyThreads")]
	internal virtual TrackBar TrackBar_HowManyThreads { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

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

	public LOSTool()
	{
		((Form)this).Shown += LOSTool_Shown;
		((Form)this).Closing += LOSTool_Closing;
		((Form)this).Load += LOSTool_Load;
		((Control)this).Resize += LOSTool_Resize;
		bool_2 = false;
		task_0 = null;
		cancellationTokenSource_0 = null;
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
		RTMPEnabled = true;
		int_1 = 0;
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
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Expected O, but got Unknown
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c2: Expected O, but got Unknown
		icontainer_1 = new Container();
		Label1 = new DarkLabel();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		Label_SelectedUnitName = new DarkLabel();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		TB_MaxRange = new DarkUITextBox();
		TB_TargetAlt = new DarkUITextBox();
		CB_AltitudeSameAsObserver = new DarkCheckBox();
		Button1 = new DarkUIButton();
		Timer1 = new Timer(icontainer_1);
		Label2 = new DarkLabel();
		CB_HorizonType = new DarkUIComboBox();
		Label5 = new DarkLabel();
		Button_ShadeColor = new DarkUIButton();
		ColorDialog_Shade = new ColorDialog();
		TrackBar_HowManyThreads = new TrackBar();
		DarkLabel1 = new DarkLabel();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((ISupportInitialize)TrackBar_HowManyThreads).BeginInit();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(4, 11);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(103, 15);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Observation from:";
		((Control)TabControl1).Anchor = (AnchorStyles)13;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(3, 27);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(405, 52);
		((Control)TabControl1).TabIndex = 1;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)Label_SelectedUnitName);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(397, 24);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Selected Unit";
		Label_SelectedUnitName.AutoSize = true;
		((Control)Label_SelectedUnitName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_SelectedUnitName).Location = new Point(6, 3);
		((Control)Label_SelectedUnitName).Name = "Label_SelectedUnitName";
		((Control)Label_SelectedUnitName).Size = new Size(76, 15);
		((Control)Label_SelectedUnitName).TabIndex = 0;
		((Label)Label_SelectedUnitName).Text = "Selected Unit";
		((Control)Label3).Anchor = (AnchorStyles)6;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(4, 86);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(112, 15);
		((Control)Label3).TabIndex = 2;
		((Label)Label3).Text = "Max Distance (NM):";
		((Control)Label4).Anchor = (AnchorStyles)6;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(4, 108);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(107, 15);
		((Control)Label4).TabIndex = 3;
		((Label)Label4).Text = "Target Alt (m AGL):";
		((Control)TB_MaxRange).Anchor = (AnchorStyles)6;
		TB_MaxRange.AutoCompleteCustomSource = null;
		TB_MaxRange.AutoCompleteMode = (AutoCompleteMode)0;
		TB_MaxRange.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_MaxRange).BackColor = Color.Transparent;
		((Control)TB_MaxRange).ForeColor = Color.FromArgb(189, 189, 189);
		TB_MaxRange.Image = null;
		TB_MaxRange.Lines = null;
		((Control)TB_MaxRange).Location = new Point(111, 85);
		TB_MaxRange.MaxLength = 32767;
		TB_MaxRange.Multiline = false;
		((Control)TB_MaxRange).Name = "TB_MaxRange";
		TB_MaxRange.ReadOnly = false;
		TB_MaxRange.ScrollBars = (ScrollBars)0;
		TB_MaxRange.SelectionStart = 0;
		((Control)TB_MaxRange).Size = new Size(100, 20);
		((Control)TB_MaxRange).TabIndex = 4;
		TB_MaxRange.Text = "100";
		TB_MaxRange.TextAlign = (HorizontalAlignment)0;
		TB_MaxRange.UseSystemPasswordChar = false;
		TB_MaxRange.WatermarkText = "";
		((Control)TB_TargetAlt).Anchor = (AnchorStyles)6;
		TB_TargetAlt.AutoCompleteCustomSource = null;
		TB_TargetAlt.AutoCompleteMode = (AutoCompleteMode)0;
		TB_TargetAlt.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_TargetAlt).BackColor = Color.Transparent;
		((Control)TB_TargetAlt).ForeColor = Color.FromArgb(189, 189, 189);
		TB_TargetAlt.Image = null;
		TB_TargetAlt.Lines = null;
		((Control)TB_TargetAlt).Location = new Point(111, 108);
		TB_TargetAlt.MaxLength = 32767;
		TB_TargetAlt.Multiline = false;
		((Control)TB_TargetAlt).Name = "TB_TargetAlt";
		TB_TargetAlt.ReadOnly = false;
		TB_TargetAlt.ScrollBars = (ScrollBars)0;
		TB_TargetAlt.SelectionStart = 0;
		((Control)TB_TargetAlt).Size = new Size(58, 20);
		((Control)TB_TargetAlt).TabIndex = 5;
		TB_TargetAlt.Text = "10";
		TB_TargetAlt.TextAlign = (HorizontalAlignment)0;
		TB_TargetAlt.UseSystemPasswordChar = false;
		TB_TargetAlt.WatermarkText = "";
		((Control)CB_AltitudeSameAsObserver).Anchor = (AnchorStyles)6;
		((ButtonBase)CB_AltitudeSameAsObserver).AutoSize = true;
		((Control)CB_AltitudeSameAsObserver).Location = new Point(112, 127);
		((Control)CB_AltitudeSameAsObserver).Name = "CB_AltitudeSameAsObserver";
		((Control)CB_AltitudeSameAsObserver).Size = new Size(117, 19);
		((Control)CB_AltitudeSameAsObserver).TabIndex = 6;
		((ButtonBase)CB_AltitudeSameAsObserver).Text = "Same as observer";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(329, 174);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 7;
		Button1.Text = "REFRESH";
		Timer1.Interval = 50;
		((Control)Label2).Anchor = (AnchorStyles)6;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(222, 87);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(52, 15);
		((Control)Label2).TabIndex = 8;
		((Label)Label2).Text = "Horizon:";
		((Control)CB_HorizonType).Anchor = (AnchorStyles)6;
		((ComboBox)CB_HorizonType).BackColor = Color.Transparent;
		((ComboBox)CB_HorizonType).DrawMode = (DrawMode)1;
		((ComboBox)CB_HorizonType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_HorizonType).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_HorizonType).FormattingEnabled = true;
		((ComboBox)CB_HorizonType).Items.AddRange(new object[3] { "Radar", "Visual/EO/Laser", "ESM" });
		((Control)CB_HorizonType).Location = new Point(278, 86);
		((Control)CB_HorizonType).Name = "CB_HorizonType";
		((Control)CB_HorizonType).Size = new Size(127, 21);
		((Control)CB_HorizonType).TabIndex = 9;
		((Control)Label5).Anchor = (AnchorStyles)6;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(4, 179);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(74, 15);
		((Control)Label5).TabIndex = 10;
		((Label)Label5).Text = "Shade Color:";
		((Control)Button_ShadeColor).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_ShadeColor).BackColor = Color.Transparent;
		((Button)Button_ShadeColor).DialogResult = (DialogResult)0;
		((Control)Button_ShadeColor).ForeColor = SystemColors.Control;
		((Control)Button_ShadeColor).Location = new Point(124, 174);
		((Control)Button_ShadeColor).Name = "Button_ShadeColor";
		Button_ShadeColor.RoundRadius = 0;
		((Control)Button_ShadeColor).Size = new Size(75, 23);
		((Control)Button_ShadeColor).TabIndex = 11;
		Button_ShadeColor.Text = "CHANGE";
		((Control)TrackBar_HowManyThreads).Anchor = (AnchorStyles)10;
		((Control)TrackBar_HowManyThreads).Location = new Point(320, 113);
		((Control)TrackBar_HowManyThreads).Name = "TrackBar_HowManyThreads";
		((Control)TrackBar_HowManyThreads).Size = new Size(88, 45);
		((Control)TrackBar_HowManyThreads).TabIndex = 12;
		((Control)DarkLabel1).Anchor = (AnchorStyles)6;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(250, 119);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(75, 15);
		((Control)DarkLabel1).TabIndex = 13;
		((Label)DarkLabel1).Text = "CPU threads:";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(411, 201);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)TrackBar_HowManyThreads);
		((Control)this).Controls.Add((Control)(object)Button_ShadeColor);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)CB_HorizonType);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)CB_AltitudeSameAsObserver);
		((Control)this).Controls.Add((Control)(object)TB_TargetAlt);
		((Control)this).Controls.Add((Control)(object)TB_MaxRange);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).MaximumSize = new Size(427, 240);
		((Form)this).MinimumSize = new Size(427, 240);
		((Control)this).Name = "LOSTool";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Line-of-sight Tool";
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((ISupportInitialize)TrackBar_HowManyThreads).EndInit();
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
				if (((Control)this).Visible)
				{
					((Form)this).Close();
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	private void method_2(object sender, EventArgs e)
	{
		method_5();
	}

	private void Recalculate(CancellationToken CancelToken)
	{
		if (Client.SelectedUnit == null || CancelToken.IsCancellationRequested)
		{
			return;
		}
		CancellationToken cancellationToken = CancelToken;
		try
		{
			bool_2 = true;
			float num = float_1;
			Module_Unit.Unit unit = Client.SelectedUnit;
			if (Client.SelectedUnit.IsContact())
			{
				Contact contact = (Contact)Client.SelectedUnit;
				if (contact.ActualUnit != null)
				{
					unit = contact.ActualUnit;
				}
			}
			float num2 = default(float);
			float num3 = default(float);
			switch (enum1_0)
			{
			case Enum1.Radar:
				num2 = unit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)unit.get_MastHeight_Radar((Sensor)null);
				num3 = Horizon.RadarHorizonNM(num2, int_0);
				break;
			case Enum1.Visual:
				num2 = unit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)unit.get_MastHeight_Visual((Sensor)null);
				num3 = Horizon.VisualHorizonNM(num2, int_0);
				break;
			case (Enum1)2:
				num2 = unit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)unit.get_MastHeight_Radar((Sensor)null);
				num3 = Horizon.ESMHorizonNM(num2, int_0);
				break;
			}
			if (num > num3)
			{
				num = num3;
			}
			if (!cancellationToken.IsCancellationRequested)
			{
				concurrentQueue_0 = Terrain.GetCellsWithLOS(Client.SelectedUnit.get_Latitude((GlobalVariables.BooleanObject)null), Client.SelectedUnit.get_Longitude((GlobalVariables.BooleanObject)null), num2, int_0, num, Client.CurrentScenario);
			}
			List<Geopoint_Struct[]> list = new List<Geopoint_Struct[]>(concurrentQueue_0.Count);
			Terrain.TerrainGridCell result;
			while (concurrentQueue_0.TryDequeue(out result) && !cancellationToken.IsCancellationRequested)
			{
				list.Add(new Geopoint_Struct[4] { result.NorthWesternCorner, result.NorthEasternCorner, result.SouthEasternCorner, result.SouthWesternCorner });
			}
			while (!cancellationToken.IsCancellationRequested)
			{
				int count = list.Count;
				list = Math2.GetAreasUnions_Clipper(list);
				if (list.Count == count)
				{
					break;
				}
			}
			if (!cancellationToken.IsCancellationRequested)
			{
				Client.LOS_ShadedArea = list;
			}
			bool_2 = false;
			if (!cancellationToken.IsCancellationRequested)
			{
				Client.MustRefreshMainForm = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void LOSTool_Shown(object sender, EventArgs e)
	{
		((ButtonBase)Button_ShadeColor).BackColor = Client.Color_LOSShade;
		Timer1.Start();
		((ComboBox)CB_HorizonType).SelectedIndex = 0;
	}

	private void method_3(object sender, EventArgs e)
	{
		string text = "(No Unit Selected)";
		if (Client.SelectedUnit == null)
		{
			((Label)Label_SelectedUnitName).Text = text;
			return;
		}
		text = Client.SelectedUnit.Name;
		if (!bool_2)
		{
			int_1 = 0;
		}
		else
		{
			text += " (Calculating LOS";
			text += Strings.StrDup(int_1 % 4, ".");
			text += Strings.StrDup(3 - int_1 % 4, " ");
			text += ")";
			int_1++;
		}
		((Label)Label_SelectedUnitName).Text = text;
		if (((CheckBox)CB_AltitudeSameAsObserver).Checked)
		{
			((Control)TB_TargetAlt).Enabled = false;
			TB_TargetAlt.Text = string.Format("{0:0.0}", Client.SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 1);
		}
		else
		{
			((Control)TB_TargetAlt).Enabled = true;
		}
		if (!bool_2 && !Information.IsNothing((object)Client.SelectedUnit))
		{
			bool flag = false;
			if (double_0 != Client.SelectedUnit.get_Latitude((GlobalVariables.BooleanObject)null))
			{
				flag = true;
			}
			if (double_1 != Client.SelectedUnit.get_Longitude((GlobalVariables.BooleanObject)null))
			{
				flag = true;
			}
			if ((int)Math.Round(float_0) != (int)Math.Round(Client.SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
			{
				flag = true;
			}
			if (Versioned.IsNumeric((object)TB_MaxRange.Text) && Versioned.IsNumeric((object)TB_TargetAlt.Text) && (flag & !bool_2))
			{
				method_5();
			}
		}
	}

	private void method_4()
	{
		if (cancellationTokenSource_0 != null && task_0 != null && !task_0.IsCompleted)
		{
			cancellationTokenSource_0.Cancel();
		}
		Client.LOS_ShadedArea = null;
		bool_2 = false;
	}

	private void method_5()
	{
		method_4();
		if (Client.SelectedUnit == null)
		{
			return;
		}
		double_0 = Client.SelectedUnit.get_Latitude((GlobalVariables.BooleanObject)null);
		double_1 = Client.SelectedUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		float_0 = Client.SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		bool flag = true;
		bool flag2 = true;
		if (Versioned.IsNumeric((object)TB_MaxRange.Text))
		{
			float num = Conversions.ToSingle(TB_MaxRange.Text);
			if (num > 0f)
			{
				float_1 = num;
				flag = false;
			}
		}
		if (Versioned.IsNumeric((object)TB_TargetAlt.Text))
		{
			int num2 = Conversions.ToInteger(TB_TargetAlt.Text);
			if (num2 >= 0)
			{
				int_0 = (int)Math.Round(SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (0.3048f * (float)num2) : ((float)num2));
				((Label)Label4).Text = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? "Target Alt (m AGL):" : "Target Alt (ft AGL):");
				flag2 = false;
			}
		}
		if (flag)
		{
			TB_MaxRange.Text = float_1.ToString();
		}
		if (flag2)
		{
			TB_TargetAlt.Text = int_0.ToString();
		}
		cancellationTokenSource_0 = new CancellationTokenSource();
		CancellationToken token = cancellationTokenSource_0.Token;
		task_0 = Task.Factory.StartNew([SpecialName] () =>
		{
			Recalculate(token);
		}, token);
	}

	private void method_6(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (!Versioned.IsNumeric((object)TB_MaxRange.Text))
		{
			DarkMessageBox.ShowWarning("The max range value must be a valid number", "Invalid value");
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (!Versioned.IsNumeric((object)TB_TargetAlt.Text))
		{
			DarkMessageBox.ShowWarning("The target altitude value must be a valid number", "Invalid value");
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		enum1_0 = (Enum1)((ComboBox)CB_HorizonType).SelectedIndex;
	}

	private void LOSTool_Closing(object sender, CancelEventArgs e)
	{
		method_4();
		Client.SelectedUnitChanged -= method_10;
		Client.LOS_ShadedArea = null;
	}

	private void method_9(object sender, EventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		ColorDialog_Shade.Color = Client.Color_LOSShade;
		((CommonDialog)ColorDialog_Shade).ShowDialog();
		Client.Color_LOSShade = Color.FromArgb(75, ColorDialog_Shade.Color);
		((ButtonBase)Button_ShadeColor).BackColor = Client.Color_LOSShade;
		Client.MustRefreshMainForm = true;
	}

	private void LOSTool_Load(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)Client.SelectedUnit))
		{
			((Label)Label_SelectedUnitName).Text = Client.SelectedUnit.Name;
		}
		Client.SelectedUnitChanged += method_10;
	}

	private void method_10(Module_Unit.Unit unit_0)
	{
		if (!Information.IsNothing((object)Client.SelectedUnit))
		{
			((Label)Label_SelectedUnitName).Text = Client.SelectedUnit.Name;
		}
		else
		{
			((Label)Label_SelectedUnitName).Text = string.Empty;
		}
		method_5();
	}

	private void method_11(object object_0)
	{
		((Label)Label4).Text = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? "Target Alt (m AGL):" : "Target Alt (ft AGL):");
		if (Versioned.IsNumeric((object)TB_TargetAlt.Text))
		{
			int_0 = Conversions.ToInteger(TB_TargetAlt.Text);
		}
	}

	private void method_12(object object_0)
	{
		if (Versioned.IsNumeric((object)TB_MaxRange.Text))
		{
			float_1 = Conversions.ToSingle(TB_MaxRange.Text);
		}
	}

	private void LOSTool_Resize(object sender, EventArgs e)
	{
		((Control)this).Height = 209;
	}

	static LOSTool()
	{
		Class72.smethod_20();
	}
}

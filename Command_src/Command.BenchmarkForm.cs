using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using baileysoft.Wmi;
using Command_Core;
using Command.My;
using CSMaterial;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

namespace Command;

[DesignerGenerated]
public sealed class BenchmarkForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Run")]
	private DarkUIButton _Button_Run;

	[CompilerGenerated]
	[AccessedThroughProperty("OpenFileDialog1")]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("FolderBrowserDialog1")]
	[CompilerGenerated]
	private FolderBrowserDialog folderBrowserDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("BackgroundWorker1")]
	private BackgroundWorker backgroundWorker_0;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	[AccessedThroughProperty("Button_Abort")]
	[CompilerGenerated]
	private DarkUIButton _Button_Abort;

	[AccessedThroughProperty("Button_ScenarioFile")]
	[CompilerGenerated]
	private DarkUIButton _Button_ScenarioFile;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_PulseTimeInfo")]
	private DarkLabel uiZjperDqK;

	private int int_0;

	private int int_1;

	private string string_0;

	private Scenario scenario_0;

	private bool bool_2;

	private bool bool_3;

	private DateTime dateTime_0;

	private float float_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private double double_0;

	private double double_1;

	private DateTime dateTime_1;

	private DateTime dateTime_2;

	private DateTime dateTime_3;

	private long long_0;

	internal virtual DarkUIButton Button_Run
	{
		[CompilerGenerated]
		get
		{
			return _Button_Run;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_Run;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Run = value;
			darkUIButton = _Button_Run;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
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

	internal virtual FolderBrowserDialog FolderBrowserDialog1
	{
		[CompilerGenerated]
		get
		{
			return folderBrowserDialog_0;
		}
		[CompilerGenerated]
		set
		{
			folderBrowserDialog_0 = value;
		}
	}

	internal virtual BackgroundWorker BackgroundWorker1
	{
		[CompilerGenerated]
		get
		{
			return backgroundWorker_0;
		}
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = method_4;
			RunWorkerCompletedEventHandler value3 = method_6;
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

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

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
			EventHandler eventHandler = method_5;
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

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label_EventQueues")]
	internal virtual DarkLabel Label_EventQueues { get; set; }

	internal virtual DarkUIButton Button_Abort
	{
		[CompilerGenerated]
		get
		{
			return _Button_Abort;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button_Abort;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Abort = value;
			darkUIButton = _Button_Abort;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ScenarioFile
	{
		[CompilerGenerated]
		get
		{
			return _Button_ScenarioFile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_ScenarioFile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ScenarioFile = value;
			darkUIButton = _Button_ScenarioFile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("NumericUpDown1")]
	internal virtual GClass9 NumericUpDown1 { get; set; }

	[field: AccessedThroughProperty("Label_Specs")]
	internal virtual DarkLabel Label_Specs { get; set; }

	internal virtual DarkLabel Label_PulseTimeInfo
	{
		[CompilerGenerated]
		get
		{
			return uiZjperDqK;
		}
		[CompilerGenerated]
		set
		{
			uiZjperDqK = value;
		}
	}

	[field: AccessedThroughProperty("ComboBox_Fidelity")]
	internal virtual DarkUIComboBox ComboBox_Fidelity { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	public BenchmarkForm()
	{
		((Form)this).Shown += BenchmarkForm_Shown;
		((Form)this).Closing += BenchmarkForm_Closing;
		bool_2 = false;
		bool_3 = false;
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Expected O, but got Unknown
		//IL_0814: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected O, but got Unknown
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Expected O, but got Unknown
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1d: Expected O, but got Unknown
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BenchmarkForm));
		OpenFileDialog1 = new OpenFileDialog();
		FolderBrowserDialog1 = new FolderBrowserDialog();
		BackgroundWorker1 = new BackgroundWorker();
		Timer1 = new Timer(icontainer_1);
		Label_PulseTimeInfo = new DarkLabel();
		Label_Specs = new DarkLabel();
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button_Abort = new DarkUIButton();
		Button_ScenarioFile = new DarkUIButton();
		Label_EventQueues = new DarkLabel();
		NumericUpDown1 = new GClass9();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		Label3 = new DarkLabel();
		Button_Run = new DarkUIButton();
		ComboBox_Fidelity = new DarkUIComboBox();
		DarkLabel1 = new DarkLabel();
		((Control)this).SuspendLayout();
		((FileDialog)OpenFileDialog1).DefaultExt = "scen";
		((FileDialog)OpenFileDialog1).FileName = "OpenFileDialog1";
		Timer1.Interval = 1000;
		Label_PulseTimeInfo.AutoSize = true;
		((Control)Label_PulseTimeInfo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_PulseTimeInfo).Location = new Point(12, 201);
		((Control)Label_PulseTimeInfo).Name = "Label_PulseTimeInfo";
		((Control)Label_PulseTimeInfo).Size = new Size(16, 15);
		((Control)Label_PulseTimeInfo).TabIndex = 15;
		((Label)Label_PulseTimeInfo).Text = "...";
		Label_Specs.AutoSize = true;
		((Control)Label_Specs).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Specs).Location = new Point(12, 11);
		((Control)Label_Specs).Name = "Label_Specs";
		((Control)Label_Specs).Size = new Size(127, 15);
		((Control)Label_Specs).TabIndex = 14;
		((Label)Label_Specs).Text = "Getting system specs...";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(12, 84);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(55, 15);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Scenario:";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(77, 81);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(506, 20);
		((Control)TextBox1).TabIndex = 1;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		((ButtonBase)Button_Abort).BackColor = Color.Transparent;
		((Button)Button_Abort).DialogResult = (DialogResult)0;
		Button_Abort.Enabled = false;
		((Control)Button_Abort).Font = new Font("Microsoft Sans Serif", 16f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button_Abort).ForeColor = Color.IndianRed;
		((Control)Button_Abort).Location = new Point(507, 185);
		((Control)Button_Abort).Name = "Button_Abort";
		Button_Abort.RoundRadius = 0;
		((Control)Button_Abort).Size = new Size(157, 54);
		((Control)Button_Abort).TabIndex = 13;
		Button_Abort.Text = "Abort";
		((ButtonBase)Button_ScenarioFile).BackColor = Color.Transparent;
		((Button)Button_ScenarioFile).DialogResult = (DialogResult)0;
		((Control)Button_ScenarioFile).ForeColor = SystemColors.Control;
		((Control)Button_ScenarioFile).Location = new Point(589, 81);
		((Control)Button_ScenarioFile).Name = "Button_ScenarioFile";
		Button_ScenarioFile.RoundRadius = 0;
		((Control)Button_ScenarioFile).Size = new Size(75, 20);
		((Control)Button_ScenarioFile).TabIndex = 2;
		Button_ScenarioFile.Text = "Select...";
		Label_EventQueues.AutoSize = true;
		((Control)Label_EventQueues).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((Control)Label_EventQueues).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_EventQueues).Location = new Point(12, 186);
		((Control)Label_EventQueues).MaximumSize = new Size(300, 0);
		((Control)Label_EventQueues).Name = "Label_EventQueues";
		((Control)Label_EventQueues).Size = new Size(168, 15);
		((Control)Label_EventQueues).TabIndex = 12;
		((Label)Label_EventQueues).Text = "Pulse Times (lower is better):";
		NumericUpDown1.BackColor = Color.Transparent;
		((Control)NumericUpDown1).Location = new Point(77, 110);
		((NumericUpDown)NumericUpDown1).Maximum = 10000m;
		((NumericUpDown)NumericUpDown1).Minimum = 1m;
		((Control)NumericUpDown1).Name = "NumericUpDown1";
		((Control)NumericUpDown1).Size = new Size(60, 26);
		((Control)NumericUpDown1).TabIndex = 7;
		((NumericUpDown)NumericUpDown1).Value = 10m;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(12, 148);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(57, 15);
		((Control)Label5).TabIndex = 10;
		((Label)Label5).Text = "Iteration: ";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(12, 164);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 15);
		((Control)Label4).TabIndex = 9;
		((Label)Label4).Text = "Scen Time: ";
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(12, 114);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(59, 15);
		((Control)Label3).TabIndex = 6;
		((Label)Label3).Text = "Iterations:";
		((ButtonBase)Button_Run).BackColor = Color.Transparent;
		((Button)Button_Run).DialogResult = (DialogResult)0;
		((Control)Button_Run).Font = new Font("Microsoft Sans Serif", 16f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button_Run).ForeColor = Color.Green;
		((Control)Button_Run).Location = new Point(344, 185);
		((Control)Button_Run).Name = "Button_Run";
		Button_Run.RoundRadius = 0;
		((Control)Button_Run).Size = new Size(157, 54);
		((Control)Button_Run).TabIndex = 8;
		Button_Run.Text = "Start";
		((ComboBox)ComboBox_Fidelity).BackColor = Color.Transparent;
		((ComboBox)ComboBox_Fidelity).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_Fidelity).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_Fidelity).Font = new Font("Segoe UI", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_Fidelity).FormattingEnabled = true;
		((ComboBox)ComboBox_Fidelity).Items.AddRange(new object[3] { "Very Coarse (5-sec pulse)", "Coarse (1-sec pulse)", "Finegrained (0.1-sec pulse)" });
		((Control)ComboBox_Fidelity).Location = new Point(210, 110);
		((Control)ComboBox_Fidelity).Name = "ComboBox_Fidelity";
		((Control)ComboBox_Fidelity).Size = new Size(189, 24);
		((Control)ComboBox_Fidelity).TabIndex = 16;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(156, 114);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(48, 15);
		((Control)DarkLabel1).TabIndex = 17;
		((Label)DarkLabel1).Text = "Fidelity:";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(676, 249);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)ComboBox_Fidelity);
		((Control)this).Controls.Add((Control)(object)Label_PulseTimeInfo);
		((Control)this).Controls.Add((Control)(object)Label_Specs);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Button_Abort);
		((Control)this).Controls.Add((Control)(object)Button_ScenarioFile);
		((Control)this).Controls.Add((Control)(object)Label_EventQueues);
		((Control)this).Controls.Add((Control)(object)NumericUpDown1);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Button_Run);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "BenchmarkForm";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Benchmark";
		((Form)this).TopMost = true;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BenchmarkForm_Shown(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Hide();
		((ComboBox)ComboBox_Fidelity).SelectedIndex = 0;
		Task.Factory.StartNew([SpecialName] () =>
		{
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			string text = "CPU: N/A";
			string text2 = "RAM: N/A";
			string text3 = "OS: N/A";
			try
			{
				Connection wMIConnection = new Connection();
				Win32_Processor win32_Processor = new Win32_Processor(wMIConnection);
				text = "CPU " + (from theStr in win32_Processor.GetPropertyValues()
					where theStr.StartsWith("Name:")
					select theStr).FirstOrDefault();
				Win32_MemoryDevice win32_MemoryDevice = new Win32_MemoryDevice(wMIConnection);
				text2 = "RAM: " + Conversions.ToString((int)Math.Round((double)Conversions.ToInteger((from theStr in win32_MemoryDevice.GetPropertyValues()
					where theStr.StartsWith("EndingAddress:")
					select theStr).LastOrDefault().Split(new char[1] { ':' })[1]) / 1024.0)) + " MB";
				text3 = "OS: " + OSVersionInfo.Name + " (" + OSVersionInfo.OSBits.ToString() + ")";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					text2 = text2 + "RAM: " + ((double)((ServerComputer)MyProject.Computer).Info.TotalPhysicalMemory / 1000000.0).ToString("#.#") + "MB";
					text3 = text3 + "OS: " + ((ServerComputer)MyProject.Computer).Info.OSFullName;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					Interaction.MsgBox((object)("Error: " + ex2.Message + "\r\nStackTrace: " + ex4.StackTrace), (MsgBoxStyle)0, (object)null);
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
			}
			((Control)Label_Specs).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				((Label)Label_Specs).Text = GameGeneral.ProgramTitle + "\r\n" + text + "\r\n" + text2 + "\r\n" + text3;
			}));
		});
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		((FileDialog)OpenFileDialog1).DefaultExt = "*.scen";
		((FileDialog)OpenFileDialog1).FileName = "*.scen";
		if ((int)((CommonDialog)OpenFileDialog1).ShowDialog() == 1)
		{
			string_0 = ((FileDialog)OpenFileDialog1).FileName;
			TextBox1.Text = Path.GetFileName(((FileDialog)OpenFileDialog1).FileName);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(TextBox1.Text))
		{
			DarkMessageBox.ShowError("No scenario selected!", "Error");
			return;
		}
		int_0 = Convert.ToInt32(((NumericUpDown)NumericUpDown1).Value);
		Button_Run.Enabled = false;
		Button_ScenarioFile.Enabled = false;
		((Control)ComboBox_Fidelity).Enabled = false;
		((Control)NumericUpDown1).Enabled = false;
		((Control)TextBox1).Enabled = false;
		Button_Abort.Enabled = true;
		((Form)this).Text = "Running...";
		dateTime_0 = DateTime.Now;
		switch (((ComboBox)ComboBox_Fidelity).SelectedIndex)
		{
		case 0:
			GameGeneral.Global_PulseResolution = 5f;
			break;
		case 1:
			GameGeneral.Global_PulseResolution = 1f;
			break;
		case 2:
			GameGeneral.Global_PulseResolution = 0.1f;
			break;
		}
		Timer1.Start();
		BackgroundWorker1.RunWorkerAsync();
	}

	private void method_4(object sender, DoWorkEventArgs e)
	{
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		bool_2 = true;
		try
		{
			float_0 = 0f;
			int_2 = 0;
			int_3 = 0;
			int_4 = int.MaxValue;
			long_0 = 0L;
			double_0 = 0.0;
			double_1 = 0.0;
			ScenContainer scenContainer = ScenContainer.LoadFromFile(string_0);
			float global_PulseResolution = GameGeneral.Global_PulseResolution;
			Stopwatch stopwatch = new Stopwatch();
			int num = int_0;
			int_1 = 1;
			while (int_1 <= num)
			{
				scenario_0 = null;
				if (!bool_3)
				{
					string ErrorFeedback = null;
					scenario_0 = scenContainer.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
					scenario_0.GameResolution = global_PulseResolution;
					scenario_0.RunningHeadless = true;
					scenario_0.BranchToNewTimeline();
					scenario_0.Scenario_LuaSandbox.RefreshStats(scenario_0);
					bool flag = true;
					dateTime_1 = scenario_0.Time;
					dateTime_3 = DateTime.UtcNow;
					while (!scenario_0.HasEnded)
					{
						if (!bool_3)
						{
							stopwatch.Reset();
							stopwatch.Start();
							GameGeneral.MainGameLoop(ref scenario_0);
							stopwatch.Stop();
							if (flag)
							{
								flag = false;
							}
							else
							{
								int_2 = (int)stopwatch.ElapsedMilliseconds;
								int_3 = Math.Max(int_3, int_2);
								int_4 = Math.Min(int_4, int_2);
								float_0 = (float_0 * (float)long_0 + (float)int_2) / (float)(long_0 + 1L);
								long_0++;
								int num2 = (int)Math.Ceiling((scenario_0.Time - dateTime_1).TotalSeconds);
								int num3 = (int)Math.Ceiling((DateTime.UtcNow - dateTime_3).TotalSeconds);
								double_0 = (double)num2 / (double)num3;
								double_1 = Math.Max(double_1, double_0);
							}
							GameGeneral.ProcessAndTruncateMessageLog(scenario_0, WriteToLog: false, string.Empty);
							continue;
						}
						bool_2 = false;
						return;
					}
					GameGeneral.DestroyPreviousScenario(ref scenario_0, ClearLuaSandbox: true);
					int_1++;
					continue;
				}
				bool_2 = false;
				return;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occured: " + ex2.Message + "\r\n\r\nThe benchmark run has been forced to stop. This does not affect the results gathered so far.", "Error during benchmark");
			ProjectData.ClearProjectError();
		}
		bool_2 = false;
	}

	private void method_5(object sender, EventArgs e)
	{
		if (scenario_0 != null)
		{
			TimeSpan timeSpan = scenario_0.StartTime.Add(scenario_0.Duration) - scenario_0.Time;
			((Label)Label4).Text = "Scen Time: " + scenario_0.Time.ToString() + ((timeSpan.TotalSeconds >= 0.0) ? (" (To Go: " + Command_Core.Misc.TimeString((long)Math.Round(timeSpan.TotalSeconds)) + ")") : string.Empty) + " - Time accel: x" + Conversions.ToString(Math.Round(double_0, 1)) + " (Max: x" + Conversions.ToString(Math.Round(double_1, 1)) + ")";
			((Label)Label5).Text = "Iteration: " + Conversions.ToString(int_1);
			((Label)Label_PulseTimeInfo).Text = "Highest: " + Conversions.ToString(int_3) + " ms\r\nLowest: " + Conversions.ToString(int_4) + " ms\r\nAverage: " + Conversions.ToString(Math.Round(float_0, 1)) + " ms";
		}
	}

	private void method_6(object sender, RunWorkerCompletedEventArgs e)
	{
		string text = Command_Core.Misc.TimeString((long)Math.Round((DateTime.Now - dateTime_0).TotalSeconds));
		Button_Run.Enabled = true;
		Button_ScenarioFile.Enabled = true;
		((Control)ComboBox_Fidelity).Enabled = true;
		((Control)NumericUpDown1).Enabled = true;
		((Control)TextBox1).Enabled = true;
		Button_Abort.Enabled = false;
		Timer1.Stop();
		if (!bool_3)
		{
			((Form)this).Text = "Benchmark run complete. Elapsed Time: " + text;
			return;
		}
		bool_3 = false;
		((Form)this).Text = "Benchmark run aborted. Elapsed Time: " + text;
	}

	private void method_7(object sender, EventArgs e)
	{
		bool_3 = true;
		Button_Abort.Enabled = false;
	}

	private void BenchmarkForm_Closing(object sender, CancelEventArgs e)
	{
		bool_3 = true;
		((Control)MyProject.Forms.MainForm).Show();
	}

	static BenchmarkForm()
	{
		Class72.smethod_20();
	}
}

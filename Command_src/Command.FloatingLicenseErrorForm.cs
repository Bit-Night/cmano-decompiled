using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FloatingLicenseErrorForm : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("BackgroundWorker1")]
	private BackgroundWorker backgroundWorker_0;

	public string ErrorReason;

	public Scenario ScenarioToSave;

	[field: AccessedThroughProperty("Panel1")]
	internal virtual Panel Panel1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			Button val = _Button1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Button1 = value;
			val = _Button1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
			DoWorkEventHandler value2 = method_0;
			RunWorkerCompletedEventHandler value3 = method_1;
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

	public FloatingLicenseErrorForm()
	{
		((Form)this).Shown += FloatingLicenseErrorForm_Shown;
		((Form)this).Closed += FloatingLicenseErrorForm_Closed;
		((Form)this).Closing += FloatingLicenseErrorForm_Closing;
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FloatingLicenseErrorForm));
		Panel1 = new Panel();
		Label1 = new Label();
		Button1 = new Button();
		BackgroundWorker1 = new BackgroundWorker();
		((Control)Panel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)Panel1).Anchor = (AnchorStyles)15;
		((Control)Panel1).Controls.Add((Control)(object)Label1);
		((Control)Panel1).Location = new Point(12, 12);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(400, 112);
		((Control)Panel1).TabIndex = 1;
		Label1.AutoSize = true;
		((Control)Label1).Dock = (DockStyle)5;
		((Control)Label1).Location = new Point(0, 0);
		((Control)Label1).MaximumSize = new Size(400, 0);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(399, 52);
		((Control)Label1).TabIndex = 0;
		Label1.Text = componentResourceManager.GetString("Label1.Text");
		((Control)Button1).Anchor = (AnchorStyles)14;
		((Control)Button1).Location = new Point(166, 139);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Size = new Size(77, 23);
		((Control)Button1).TabIndex = 2;
		((ButtonBase)Button1).Text = "OK";
		((ButtonBase)Button1).UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).AutoSize = true;
		((Form)this).ClientSize = new Size(424, 165);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "FloatingLicenseErrorForm";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Error in validating floating license!";
		((Form)this).TopMost = true;
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	private void FloatingLicenseErrorForm_Shown(object sender, EventArgs e)
	{
		Client.CurrentGame.Pause();
		((Control)MyProject.Forms.MainForm).Enabled = false;
		string text = "There has been a problem in validating your floating license. The error message is: " + ErrorReason + "\r\n\r\nCommand is now saving the current state of your scenario to Autosave.scen...";
		Label1.Text = text;
		((Control)Button1).Enabled = false;
		BackgroundWorker1.RunWorkerAsync();
	}

	private void method_0(object sender, DoWorkEventArgs e)
	{
		if (ScenarioToSave != null)
		{
			while (ScenarioToSave.ExecutionInProgress)
			{
				Thread.Sleep(10);
			}
			Client.PerformAutosave(ScenarioToSave);
		}
	}

	private void method_1(object sender, RunWorkerCompletedEventArgs e)
	{
		string text = "There has been a problem in validating your floating license. The error message is: \r\n\r\n";
		if (ScenarioToSave != null)
		{
			text += "Command saved the current state of your scenario to Autosave.scen.";
		}
		text += "Please click on 'OK' or close this window to exit the application.";
		Label1.Text = text;
		((Control)Button1).Enabled = true;
	}

	private void FloatingLicenseErrorForm_Closed(object sender, EventArgs e)
	{
		Startup.PerformShutdown();
	}

	private void FloatingLicenseErrorForm_Closing(object sender, CancelEventArgs e)
	{
		if (BackgroundWorker1.IsBusy)
		{
			e.Cancel = true;
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	static FloatingLicenseErrorForm()
	{
		Class72.smethod_20();
	}
}

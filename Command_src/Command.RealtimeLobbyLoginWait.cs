using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealtimeLobbyLoginWait : DarkForm
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton _Button_Cancel;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Ok")]
	private DarkUIButton _Button_Ok;

	private Timer timer_0;

	[field: AccessedThroughProperty("Label_WaitStatus")]
	internal virtual DarkLabel Label_WaitStatus { get; set; }

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			DarkUIButton darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Cancel = value;
			darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Ok
	{
		[CompilerGenerated]
		get
		{
			return _Button_Ok;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			DarkUIButton darkUIButton = _Button_Ok;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Ok = value;
			darkUIButton = _Button_Ok;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public RealtimeLobbyLoginWait()
	{
		((Form)this).Load += RealtimeLobbyLoginWait_Load;
		((Form)this).Shown += RealtimeLobbyLoginWait_Shown;
		((Form)this).Closed += RealtimeLobbyLoginWait_Closed;
		timer_0 = null;
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
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		Label_WaitStatus = new DarkLabel();
		Button_Cancel = new DarkUIButton();
		Button_Ok = new DarkUIButton();
		((Control)this).SuspendLayout();
		((Control)Label_WaitStatus).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_WaitStatus).Location = new Point(4, 9);
		((Control)Label_WaitStatus).Name = "Label_WaitStatus";
		((Control)Label_WaitStatus).Size = new Size(252, 43);
		((Control)Label_WaitStatus).TabIndex = 0;
		((Label)Label_WaitStatus).Text = "Verifying Serial Number ...";
		((Label)Label_WaitStatus).TextAlign = (ContentAlignment)32;
		((Control)Button_Cancel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Cancel).Location = new Point(99, 55);
		((Control)Button_Cancel).Name = "Button_Cancel";
		((Control)Button_Cancel).Padding = new Padding(4);
		Button_Cancel.RoundRadius = 0;
		((Control)Button_Cancel).Size = new Size(64, 20);
		((Control)Button_Cancel).TabIndex = 1;
		Button_Cancel.Text = "Cancel";
		((Control)Button_Ok).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Ok).Location = new Point(63, 55);
		((Control)Button_Ok).Name = "Button_Ok";
		((Control)Button_Ok).Padding = new Padding(4);
		Button_Ok.RoundRadius = 0;
		((Control)Button_Ok).Size = new Size(64, 20);
		((Control)Button_Ok).TabIndex = 2;
		Button_Ok.Text = "Ok";
		((Control)Button_Ok).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(261, 95);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)Button_Ok);
		((Control)this).Controls.Add((Control)(object)Button_Cancel);
		((Control)this).Controls.Add((Control)(object)Label_WaitStatus);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "RealtimeLobbyLoginWait";
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)4;
		((Form)this).Text = "Please Wait";
		((Form)this).TopMost = true;
		((Control)this).ResumeLayout(false);
	}

	private void RealtimeLobbyLoginWait_Load(object sender, EventArgs e)
	{
		((Form)this).CenterToParent();
	}

	private void RealtimeLobbyLoginWait_Shown(object sender, EventArgs e)
	{
		if (timer_0 != null)
		{
			timer_0.Start();
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
		((Form)this).Close();
		if (((Control)MyProject.Forms.RealtimeLobbyLogin).Visible)
		{
			MyProject.Forms.RealtimeLobbyLogin.NotifyWaitCancel();
		}
		else if (((Control)MyProject.Forms.RealtimeLobby).Visible)
		{
			MyProject.Forms.RealtimeLobby.NotifyWaitCancel();
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)1;
		((Form)this).Close();
	}

	private void RealtimeLobbyLoginWait_Closed(object sender, EventArgs e)
	{
		if (((Control)Button_Ok).Visible)
		{
			((Control)Button_Ok).Visible = false;
			((Control)Button_Cancel).Left = 99;
		}
		if (timer_0 != null)
		{
			timer_0.Stop();
			timer_0.Tick -= timer_0_Tick;
			timer_0 = null;
		}
	}

	public void SetupOkCancelTimeout(int timeout_s)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		((Control)Button_Ok).Visible = true;
		((Control)Button_Cancel).Left = 133;
		timer_0 = new Timer();
		timer_0.Stop();
		timer_0.Interval = timeout_s * 1000;
		timer_0.Tick += timer_0_Tick;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Stop();
		method_0(RuntimeHelpers.GetObjectValue(sender), e);
	}

	static RealtimeLobbyLoginWait()
	{
		Class72.smethod_20();
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealtimePlayerConnect : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonCancel")]
	private DarkUIButton _ButtonCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonOk")]
	private DarkUIButton _ButtonOk;

	[CompilerGenerated]
	private bool bool_2;

	public string ErrorString;

	[field: AccessedThroughProperty("HostPortTextBox")]
	internal virtual DarkUITextBox HostPortTextBox { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("HostIPTextBox")]
	internal virtual DarkUITextBox HostIPTextBox { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUIButton ButtonCancel
	{
		[CompilerGenerated]
		get
		{
			return _ButtonCancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _ButtonCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonCancel = value;
			darkUIButton = _ButtonCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonOk
	{
		[CompilerGenerated]
		get
		{
			return _ButtonOk;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _ButtonOk;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonOk = value;
			darkUIButton = _ButtonOk;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ErrorLabel")]
	internal virtual DarkLabel ErrorLabel { get; set; }

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public RealtimePlayerConnect()
	{
		((Form)this).Load += RealtimePlayerConnect_Load;
		RTMPEnabled = true;
		ErrorString = "";
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
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected O, but got Unknown
		HostPortTextBox = new DarkUITextBox();
		DarkLabel4 = new DarkLabel();
		HostIPTextBox = new DarkUITextBox();
		DarkLabel1 = new DarkLabel();
		ButtonCancel = new DarkUIButton();
		ButtonOk = new DarkUIButton();
		ErrorLabel = new DarkLabel();
		((Control)this).SuspendLayout();
		HostPortTextBox.AutoCompleteCustomSource = null;
		HostPortTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		HostPortTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)HostPortTextBox).BackColor = Color.Transparent;
		((Control)HostPortTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		HostPortTextBox.Image = null;
		HostPortTextBox.Lines = null;
		((Control)HostPortTextBox).Location = new Point(134, 83);
		HostPortTextBox.MaxLength = 32767;
		HostPortTextBox.Multiline = false;
		((Control)HostPortTextBox).Name = "HostPortTextBox";
		HostPortTextBox.ReadOnly = false;
		HostPortTextBox.ScrollBars = (ScrollBars)0;
		HostPortTextBox.SelectionStart = 0;
		((Control)HostPortTextBox).Size = new Size(57, 18);
		((Control)HostPortTextBox).TabIndex = 53;
		HostPortTextBox.TextAlign = (HorizontalAlignment)0;
		HostPortTextBox.UseSystemPasswordChar = false;
		HostPortTextBox.WatermarkText = "";
		HostPortTextBox.WordWrap = false;
		((Control)DarkLabel4).ForeColor = Color.White;
		((Label)DarkLabel4).ImageAlign = (ContentAlignment)64;
		((Control)DarkLabel4).Location = new Point(4, 83);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(124, 20);
		((Control)DarkLabel4).TabIndex = 52;
		((Label)DarkLabel4).Text = "Host Port:";
		((Label)DarkLabel4).TextAlign = (ContentAlignment)64;
		HostIPTextBox.AutoCompleteCustomSource = null;
		HostIPTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		HostIPTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)HostIPTextBox).BackColor = Color.Transparent;
		((Control)HostIPTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		HostIPTextBox.Image = null;
		HostIPTextBox.Lines = null;
		((Control)HostIPTextBox).Location = new Point(134, 59);
		HostIPTextBox.MaxLength = 32767;
		HostIPTextBox.Multiline = false;
		((Control)HostIPTextBox).Name = "HostIPTextBox";
		HostIPTextBox.ReadOnly = false;
		HostIPTextBox.ScrollBars = (ScrollBars)0;
		HostIPTextBox.SelectionStart = 0;
		((Control)HostIPTextBox).Size = new Size(172, 18);
		((Control)HostIPTextBox).TabIndex = 51;
		HostIPTextBox.TextAlign = (HorizontalAlignment)0;
		HostIPTextBox.UseSystemPasswordChar = false;
		HostIPTextBox.WatermarkText = "";
		HostIPTextBox.WordWrap = false;
		((Control)DarkLabel1).ForeColor = Color.White;
		((Label)DarkLabel1).ImageAlign = (ContentAlignment)64;
		((Control)DarkLabel1).Location = new Point(4, 58);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(124, 20);
		((Control)DarkLabel1).TabIndex = 50;
		((Label)DarkLabel1).Text = "Host IP Address:";
		((Label)DarkLabel1).TextAlign = (ContentAlignment)64;
		((Control)ButtonCancel).Anchor = (AnchorStyles)2;
		((ButtonBase)ButtonCancel).BackColor = Color.Transparent;
		((Control)ButtonCancel).ForeColor = SystemColors.Control;
		((Control)ButtonCancel).Location = new Point(191, 129);
		((Control)ButtonCancel).Name = "ButtonCancel";
		((Control)ButtonCancel).Padding = new Padding(5);
		ButtonCancel.RoundRadius = 0;
		((Control)ButtonCancel).Size = new Size(91, 23);
		((Control)ButtonCancel).TabIndex = 49;
		ButtonCancel.Text = "Cancel";
		((Control)ButtonOk).Anchor = (AnchorStyles)2;
		((ButtonBase)ButtonOk).BackColor = Color.Transparent;
		((Control)ButtonOk).ForeColor = SystemColors.Control;
		((Control)ButtonOk).Location = new Point(75, 129);
		((Control)ButtonOk).Name = "ButtonOk";
		((Control)ButtonOk).Padding = new Padding(5);
		ButtonOk.RoundRadius = 0;
		((Control)ButtonOk).Size = new Size(91, 23);
		((Control)ButtonOk).TabIndex = 48;
		ButtonOk.Text = "Ok";
		((Control)ErrorLabel).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((Control)ErrorLabel).ForeColor = Color.Red;
		((Control)ErrorLabel).Location = new Point(2, 8);
		((Control)ErrorLabel).Name = "ErrorLabel";
		((Control)ErrorLabel).Size = new Size(350, 36);
		((Control)ErrorLabel).TabIndex = 54;
		((Label)ErrorLabel).TextAlign = (ContentAlignment)32;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(357, 163);
		((Control)this).Controls.Add((Control)(object)ErrorLabel);
		((Control)this).Controls.Add((Control)(object)HostPortTextBox);
		((Control)this).Controls.Add((Control)(object)DarkLabel4);
		((Control)this).Controls.Add((Control)(object)HostIPTextBox);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)ButtonCancel);
		((Control)this).Controls.Add((Control)(object)ButtonOk);
		((Form)this).Location = new Point(0, 0);
		((Control)this).Name = "RealtimePlayerConnect";
		((Form)this).Text = "Connect to Host";
		((Control)this).ResumeLayout(false);
	}

	private void RealtimePlayerConnect_Load(object sender, EventArgs e)
	{
		((Label)ErrorLabel).Text = ErrorString;
		if (Client.RealtimeTerminal == null)
		{
			HostIPTextBox.Text = "127.0.0.1";
			HostPortTextBox.Text = 9000.ToString();
		}
		else
		{
			HostIPTextBox.Text = Client.RealtimeTerminal.DefaultIP;
			HostPortTextBox.Text = Client.RealtimeTerminal.DefaultPort.ToString();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		if (Client.RealtimeTerminal != null)
		{
			Client.RealtimeTerminal.DefaultIP = HostIPTextBox.Text;
			if (int.TryParse(HostPortTextBox.Text, out var result) && result > 0 && result < 65536)
			{
				Client.RealtimeTerminal.DefaultPort = result;
			}
			((Form)this).DialogResult = (DialogResult)1;
		}
		else
		{
			((Label)ErrorLabel).Text = "Error: Realtime Terminal not initialized. Click 'Cancel' and retry.";
		}
		((Form)this).Close();
	}

	static RealtimePlayerConnect()
	{
		Class72.smethod_20();
	}
}

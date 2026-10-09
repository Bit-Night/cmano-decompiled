using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealtimeChatInputBar : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("SendButton")]
	private DarkUIButton _SendButton;

	[CompilerGenerated]
	private bool bool_2;

	private bool bool_3;

	internal virtual DarkUIButton SendButton
	{
		[CompilerGenerated]
		get
		{
			return _SendButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _SendButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_SendButton = value;
			darkUIButton = _SendButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("InputTextBox")]
	internal virtual DarkUITextBox InputTextBox { get; set; }

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

	public RealtimeChatInputBar()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Shown += [SpecialName] (object sender, EventArgs e) =>
		{
			method_2();
		};
		((Control)this).KeyDown += new KeyEventHandler(RealtimeChatInputBar_KeyDown);
		RTMPEnabled = true;
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RealtimeChatInputBar));
		SendButton = new DarkUIButton();
		InputTextBox = new DarkUITextBox();
		((Control)this).SuspendLayout();
		((Control)SendButton).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)SendButton).Location = new Point(495, 3);
		((Control)SendButton).Margin = new Padding(0);
		((Control)SendButton).Name = "SendButton";
		((Control)SendButton).Padding = new Padding(5);
		SendButton.RoundRadius = 0;
		((Control)SendButton).Size = new Size(24, 25);
		((Control)SendButton).TabIndex = 1;
		SendButton.Text = "<┘";
		InputTextBox.AutoCompleteCustomSource = null;
		InputTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		InputTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)InputTextBox).BackColor = Color.FromArgb(49, 51, 53);
		((Control)InputTextBox).ForeColor = Color.FromArgb(220, 220, 220);
		InputTextBox.Image = null;
		InputTextBox.Lines = null;
		((Control)InputTextBox).Location = new Point(4, 3);
		InputTextBox.MaxLength = 128;
		InputTextBox.Multiline = false;
		((Control)InputTextBox).Name = "InputTextBox";
		InputTextBox.ReadOnly = false;
		InputTextBox.ScrollBars = (ScrollBars)0;
		InputTextBox.SelectionStart = 0;
		((Control)InputTextBox).Size = new Size(488, 25);
		((Control)InputTextBox).TabIndex = 0;
		InputTextBox.TextAlign = (HorizontalAlignment)0;
		InputTextBox.UseSystemPasswordChar = false;
		InputTextBox.WatermarkText = "";
		InputTextBox.WordWrap = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(522, 31);
		((Control)this).Controls.Add((Control)(object)InputTextBox);
		((Control)this).Controls.Add((Control)(object)SendButton);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "RealtimeChatInputBar";
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)4;
		((Form)this).Text = "Chat Input";
		((Form)this).TopMost = true;
		((Control)this).ResumeLayout(false);
	}

	private void method_2()
	{
		if (!Client.Realtime)
		{
			((Form)this).Close();
		}
		MainForm mainForm = MyProject.Forms.MainForm;
		Point point = default(Point);
		int x = point.X;
		int y = point.Y;
		mainForm.GetChatMessageBarLocation(ref x, ref y);
		point.Y = y;
		point.X = x;
		point = ((Control)MyProject.Forms.MainForm).PointToScreen(point);
		((Control)this).Left = point.X - 4;
		((Control)this).Top = point.Y + 24;
		InputTextBox.Focus();
	}

	private void RealtimeChatInputBar_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Modifiers == 0)
		{
			switch (e.KeyValue)
			{
			case 27:
				((Form)this).Close();
				break;
			case 13:
				method_3(this, null);
				break;
			}
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		if (Client.Realtime)
		{
			string text = InputTextBox.Text;
			if (!string.IsNullOrEmpty(text))
			{
				Client.RealtimeTerminal.SendGlobalChat(text);
				InputTextBox.Text = "";
			}
		}
	}

	static RealtimeChatInputBar()
	{
		Class72.smethod_20();
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;

namespace DarkUI.Forms;

public class DarkMessageBox : DarkDialog
{
	private string string_0;

	private int int_1 = 350;

	private IContainer icontainer_0;

	private PictureBox picIcon;

	private DarkLabel lblText;

	[Description("Determines the maximum width of the message box when it autosizes around the displayed message.")]
	[DefaultValue(350)]
	public int MaximumWidth
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			method_4();
		}
	}

	public DarkMessageBox()
	{
		InitializeComponent_1();
	}

	public DarkMessageBox(string message, string title, DarkMessageBoxIcon icon, DarkDialogButton buttons)
		: this()
	{
		((Control)this).Text = title;
		string_0 = message;
		base.DialogButtons = buttons;
		method_3(icon);
	}

	public DarkMessageBox(string message)
		: this(message, "Command", DarkMessageBoxIcon.None, DarkDialogButton.Ok)
	{
	}

	public DarkMessageBox(string message, string title)
		: this(message, title, DarkMessageBoxIcon.None, DarkDialogButton.Ok)
	{
	}

	public DarkMessageBox(string message, string title, DarkDialogButton buttons)
		: this(message, title, DarkMessageBoxIcon.None, buttons)
	{
	}

	public DarkMessageBox(string message, string title, DarkMessageBoxIcon icon)
		: this(message, title, icon, DarkDialogButton.Ok)
	{
	}

	public static DialogResult ShowInformation(string message, string caption, DarkDialogButton buttons = DarkDialogButton.Ok)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return smethod_0(message, caption, DarkMessageBoxIcon.Information, buttons);
	}

	public static DialogResult ShowWarning(string message, string caption, DarkDialogButton buttons = DarkDialogButton.Ok)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return smethod_0(message, caption, DarkMessageBoxIcon.Warning, buttons);
	}

	public static DialogResult ShowWarningWithSkip(string message, string caption)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return smethod_0(message, caption, DarkMessageBoxIcon.Warning, DarkDialogButton.OKDoNotNotify);
	}

	public static DialogResult ShowError(string message, string caption, DarkDialogButton buttons = DarkDialogButton.Ok)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return smethod_0(message, caption, DarkMessageBoxIcon.Error, buttons);
	}

	private static DialogResult smethod_0(string string_1, string string_2, DarkMessageBoxIcon darkMessageBoxIcon_0, DarkDialogButton darkDialogButton_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		DarkMessageBox darkMessageBox = new DarkMessageBox(string_1, string_2, darkMessageBoxIcon_0, darkDialogButton_1);
		try
		{
			return ((Form)darkMessageBox).ShowDialog();
		}
		finally
		{
			((IDisposable)darkMessageBox)?.Dispose();
		}
	}

	private void method_3(DarkMessageBoxIcon darkMessageBoxIcon_0)
	{
		switch (darkMessageBoxIcon_0)
		{
		case DarkMessageBoxIcon.None:
			((Control)picIcon).Visible = false;
			((Control)lblText).Left = 10;
			break;
		case DarkMessageBoxIcon.Information:
			picIcon.Image = (Image)(object)MessageBoxIcons.info;
			break;
		case DarkMessageBoxIcon.Warning:
			picIcon.Image = (Image)(object)MessageBoxIcons.warning;
			break;
		case DarkMessageBoxIcon.Error:
			picIcon.Image = (Image)(object)MessageBoxIcons.error;
			break;
		}
	}

	private void method_4()
	{
		int num = 260;
		int num2 = 124;
		((Form)this).Size = new Size(260, 124);
		((Control)lblText).Text = string.Empty;
		lblText.AutoSize = true;
		((Control)lblText).Text = string_0;
		int num3 = Math.Max(260, base.TotalButtonSize + 15);
		int num4 = ((Control)lblText).Right + 25;
		num = ((num4 < int_1) ? num4 : int_1);
		int num5 = ((Control)this).Height - ((Control)picIcon).Height;
		lblText.AutoUpdateHeight = true;
		((Control)lblText).Width = num - ((Control)lblText).Left - 25;
		num2 = num5 + ((Control)lblText).Height;
		if (num < num3)
		{
			num = num3;
		}
		((Form)this).Size = new Size(num, num2);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		method_4();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		picIcon = new PictureBox();
		lblText = new DarkLabel();
		((ISupportInitialize)picIcon).BeginInit();
		((Control)this).SuspendLayout();
		((Control)picIcon).Location = new Point(10, 10);
		((Control)picIcon).Name = "picIcon";
		((Control)picIcon).Size = new Size(32, 32);
		picIcon.TabIndex = 3;
		picIcon.TabStop = false;
		lblText.AutoSize = true;
		((Control)lblText).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblText).Location = new Point(50, 9);
		((Control)lblText).Name = "lblText";
		((Control)lblText).Size = new Size(185, 15);
		((Control)lblText).TabIndex = 4;
		((Control)lblText).Text = "Something something something";
		((Form)this).ClientSize = new Size(244, 86);
		((Control)this).Controls.Add((Control)(object)lblText);
		((Control)this).Controls.Add((Control)(object)picIcon);
		((Control)this).Font = new Font("Segoe UI", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "DarkMessageBox";
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "Message box";
		((Form)this).TopMost = true;
		((Control)this).Controls.SetChildIndex((Control)(object)picIcon, 0);
		((Control)this).Controls.SetChildIndex((Control)(object)lblText, 0);
		((ISupportInitialize)picIcon).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static DarkMessageBox()
	{
		Class72.smethod_20();
	}
}

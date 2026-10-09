using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class NotifyConnecting : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	private bool bool_2;

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

	public NotifyConnecting()
	{
		((Form)this).Load += NotifyConnecting_Load;
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
		ErrorLabel = new DarkLabel();
		((Control)this).SuspendLayout();
		((Control)ErrorLabel).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((Control)ErrorLabel).ForeColor = Color.White;
		((Control)ErrorLabel).Location = new Point(12, 10);
		((Control)ErrorLabel).Name = "ErrorLabel";
		((Control)ErrorLabel).Size = new Size(155, 36);
		((Control)ErrorLabel).TabIndex = 34;
		((Label)ErrorLabel).Text = "Connecting...";
		((Label)ErrorLabel).TextAlign = (ContentAlignment)32;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).CausesValidation = false;
		((Form)this).ClientSize = new Size(182, 59);
		((Control)this).Controls.Add((Control)(object)ErrorLabel);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MaximumSize = new Size(198, 98);
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "NotifyConnecting";
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)4;
		((Form)this).Text = "Multiplayer";
		((Control)this).ResumeLayout(false);
	}

	private void NotifyConnecting_Load(object sender, EventArgs e)
	{
	}

	static NotifyConnecting()
	{
		Class72.smethod_20();
	}
}

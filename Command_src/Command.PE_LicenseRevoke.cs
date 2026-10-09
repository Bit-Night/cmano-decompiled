using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
internal class PE_LicenseRevoke : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[field: AccessedThroughProperty("LinkLabel1")]
	internal virtual LinkLabel LinkLabel1 { get; set; }

	[field: AccessedThroughProperty("Button1")]
	internal virtual DarkUIButton Button1 { get; set; }

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("LinkLabel2")]
	internal virtual LinkLabel LinkLabel2 { get; set; }

	public PE_LicenseRevoke()
	{
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		LinkLabel1 = new LinkLabel();
		Button1 = new DarkUIButton();
		TextBox1 = new DarkUITextBox();
		LinkLabel2 = new LinkLabel();
		((Control)this).SuspendLayout();
		((Label)LinkLabel1).AutoSize = true;
		((Control)LinkLabel1).Font = new Font("Segoe UI", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)LinkLabel1).ForeColor = SystemColors.Control;
		LinkLabel1.LinkArea = new LinkArea(90, 19);
		((Control)LinkLabel1).Location = new Point(12, 9);
		((Control)LinkLabel1).MaximumSize = new Size(350, 0);
		((Control)LinkLabel1).Name = "LinkLabel1";
		((Control)LinkLabel1).Size = new Size(126, 23);
		((Control)LinkLabel1).TabIndex = 0;
		LinkLabel1.Text = "Your revoke code is:";
		LinkLabel1.UseCompatibleTextRendering = true;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(144, 175);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 34);
		((Control)Button1).TabIndex = 1;
		Button1.Text = "OK";
		((Control)TextBox1).Anchor = (AnchorStyles)13;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f, (FontStyle)1);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(12, 35);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = true;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(360, 77);
		((Control)TextBox1).TabIndex = 2;
		TextBox1.Text = "XXXX-XXXX-XXXX-XXXX";
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		((Label)LinkLabel2).AutoSize = true;
		((Control)LinkLabel2).Font = new Font("Segoe UI", 10f);
		((Control)LinkLabel2).ForeColor = SystemColors.Control;
		LinkLabel2.LinkArea = new LinkArea(0, 0);
		LinkLabel2.LinkColor = Color.SkyBlue;
		((Control)LinkLabel2).Location = new Point(8, 115);
		((Control)LinkLabel2).MaximumSize = new Size(360, 0);
		((Control)LinkLabel2).Name = "LinkLabel2";
		((Control)LinkLabel2).Size = new Size(350, 57);
		((Control)LinkLabel2).TabIndex = 3;
		LinkLabel2.Text = "Navigate to https://www.matrixprosims.com/ and follow the steps detailed in the CPE manual for a replacement license. The program will now exit.";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(384, 221);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)LinkLabel2);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)LinkLabel1);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "PE_LicenseRevoke";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "License file missing!";
		((Form)this).TopMost = true;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static PE_LicenseRevoke()
	{
		Class72.smethod_20();
	}
}

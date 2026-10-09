using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
internal class PE_LicensingForm : DarkSecondaryFormBase
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

	public PE_LicensingForm()
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PE_LicensingForm));
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
		((Control)LinkLabel1).Size = new Size(180, 23);
		((Control)LinkLabel1).TabIndex = 0;
		LinkLabel1.Text = "Your system hardware UID is:";
		LinkLabel1.UseCompatibleTextRendering = true;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(144, 175);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
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
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = true;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(360, 25);
		((Control)TextBox1).TabIndex = 2;
		TextBox1.Text = "XXXX-XXXX-XXXX-XXXX-XXXX";
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TextBox1.WordWrap = false;
		((Label)LinkLabel2).AutoSize = true;
		((Control)LinkLabel2).Font = new Font("Segoe UI", 10f);
		((Control)LinkLabel2).ForeColor = SystemColors.Control;
		LinkLabel2.LinkArea = new LinkArea(0, 0);
		LinkLabel2.LinkColor = Color.SkyBlue;
		((Control)LinkLabel2).Location = new Point(12, 63);
		((Control)LinkLabel2).MaximumSize = new Size(360, 0);
		((Control)LinkLabel2).Name = "LinkLabel2";
		((Control)LinkLabel2).Size = new Size(350, 95);
		((Control)LinkLabel2).TabIndex = 3;
		LinkLabel2.Text = componentResourceManager.GetString("LinkLabel2.Text");
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(384, 221);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)LinkLabel2);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)LinkLabel1);
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "PE_LicensingForm";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "License file missing!";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static PE_LicensingForm()
	{
		Class72.smethod_20();
	}
}

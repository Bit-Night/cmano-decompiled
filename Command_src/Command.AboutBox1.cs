// Command.AboutBox1: whole-type decompilation failed; members decompiled one by one.
using System.ComponentModel;

private IContainer icontainer_1;

using System.Runtime.CompilerServices;
using DarkUI.Controls;

[AccessedThroughProperty("Label_version")]
[CompilerGenerated]
private DarkLabel _Label_version;

using System.Runtime.CompilerServices;

[AccessedThroughProperty("OKButton")]
[CompilerGenerated]
private DarkUIButton _OKButton;

using System.Runtime.CompilerServices;
using DarkUI.Controls;

[AccessedThroughProperty("Label1")]
[CompilerGenerated]
private DarkLabel _Label1;

using System.Runtime.CompilerServices;
using DarkUI.Controls;

[CompilerGenerated]
[AccessedThroughProperty("Label2")]
private DarkLabel _Label2;

using System.Runtime.CompilerServices;
using DarkUI.Controls;

[AccessedThroughProperty("Label3")]
[CompilerGenerated]
private DarkLabel AebHzthiyhu;

using System.Runtime.CompilerServices;
using DarkUI.Controls;

[AccessedThroughProperty("Label_Copyright")]
[CompilerGenerated]
private DarkLabel _Label_Copyright;

using System.Runtime.CompilerServices;
using System.Windows.Forms;

[CompilerGenerated]
[AccessedThroughProperty("PictureBox1")]
private PictureBox _PictureBox1;

using System.Runtime.CompilerServices;

[AccessedThroughProperty("TextBox1")]
[CompilerGenerated]
private DarkUITextBox _TextBox1;

using System.Runtime.CompilerServices;

[AccessedThroughProperty("TB_Licensing")]
[CompilerGenerated]
private DarkUITextBox _TB_Licensing;

using System.Runtime.CompilerServices;
using DarkUI.Controls;

[CompilerGenerated]
[AccessedThroughProperty("Label_License")]
private DarkLabel _Label_License;

using System.Runtime.CompilerServices;

[CompilerGenerated]
private bool bool_2;

using DarkUI.Controls;

internal virtual DarkLabel Label_version { get; set; }

using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal virtual DarkUIButton OKButton
{
	[CompilerGenerated]
	get
	{
		return _OKButton;
	}
	[CompilerGenerated]
	set
	{
		EventHandler eventHandler = method_2;
		DarkUIButton darkUIButton = _OKButton;
		if (darkUIButton != null)
		{
			((Control)darkUIButton).Click -= eventHandler;
		}
		_OKButton = value;
		darkUIButton = _OKButton;
		if (darkUIButton != null)
		{
			((Control)darkUIButton).Click += eventHandler;
		}
	}
}

using DarkUI.Controls;

internal virtual DarkLabel Label1 { get; set; }

using DarkUI.Controls;

internal virtual DarkLabel Label2 { get; set; }

using System.Runtime.CompilerServices;
using DarkUI.Controls;

internal virtual DarkLabel Label3
{
	[CompilerGenerated]
	get
	{
		return AebHzthiyhu;
	}
	[CompilerGenerated]
	set
	{
		AebHzthiyhu = value;
	}
}

using DarkUI.Controls;

internal virtual DarkLabel Label_Copyright { get; set; }

using System.Windows.Forms;

internal virtual PictureBox PictureBox1 { get; set; }

internal virtual DarkUITextBox TextBox1 { get; set; }

internal virtual DarkUITextBox TB_Licensing { get; set; }

using DarkUI.Controls;

internal virtual DarkLabel Label_License { get; set; }

using System.Runtime.CompilerServices;

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

using System.Windows.Forms;

public AboutBox1()
{
	//IL_0022: Unknown result type (might be due to invalid IL or missing references)
	//IL_002c: Expected O, but got Unknown
	//IL_0034: Unknown result type (might be due to invalid IL or missing references)
	//IL_003e: Expected O, but got Unknown
	((Form)this).Load += AboutBox1_Load;
	((Control)this).KeyDown += new KeyEventHandler(AboutBox1_KeyDown);
	((Form)this).FormClosing += new FormClosingEventHandler(AboutBox1_FormClosing);
	RTMPEnabled = true;
	InitializeComponent_1();
}

protected override void Dispose(bool disposing)
{
	if (disposing && icontainer_1 != null)
	{
		icontainer_1.Dispose();
	}
	base.Dispose(disposing);
}

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;

private void InitializeComponent_1()
{
	//IL_0053: Unknown result type (might be due to invalid IL or missing references)
	//IL_005d: Expected O, but got Unknown
	//IL_0180: Unknown result type (might be due to invalid IL or missing references)
	//IL_018a: Expected O, but got Unknown
	//IL_0295: Unknown result type (might be due to invalid IL or missing references)
	//IL_029f: Expected O, but got Unknown
	//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
	//IL_04bf: Expected O, but got Unknown
	//IL_0549: Unknown result type (might be due to invalid IL or missing references)
	//IL_0553: Expected O, but got Unknown
	//IL_061b: Unknown result type (might be due to invalid IL or missing references)
	//IL_0625: Expected O, but got Unknown
	//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
	//IL_06ed: Expected O, but got Unknown
	//IL_0894: Unknown result type (might be due to invalid IL or missing references)
	ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AboutBox1));
	Label_License = new DarkLabel();
	TextBox1 = new DarkUITextBox();
	Label3 = new DarkLabel();
	Label2 = new DarkLabel();
	Label1 = new DarkLabel();
	Label_Copyright = new DarkLabel();
	PictureBox1 = new PictureBox();
	Label_version = new DarkLabel();
	OKButton = new DarkUIButton();
	TB_Licensing = new DarkUITextBox();
	((ISupportInitialize)PictureBox1).BeginInit();
	((Control)this).SuspendLayout();
	Label_License.AutoSize = true;
	((Control)Label_License).BackColor = Color.Transparent;
	((Control)Label_License).ForeColor = Color.FromArgb(220, 220, 220);
	((Control)Label_License).Location = new Point(228, 41);
	((Control)Label_License).MaximumSize = new Size(400, 0);
	((Control)Label_License).Name = "Label_License";
	((Control)Label_License).Size = new Size(44, 13);
	((Control)Label_License).TabIndex = 9;
	((Label)Label_License).Text = "License";
	TextBox1.AutoCompleteCustomSource = null;
	TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
	TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
	((Control)TextBox1).BackColor = SystemColors.Control;
	TextBox1.Font = new Font("Segoe UI", 8f);
	((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
	TextBox1.Image = null;
	TextBox1.Lines = null;
	((Control)TextBox1).Location = new Point(13, 154);
	TextBox1.MaxLength = 32767;
	TextBox1.Multiline = true;
	((Control)TextBox1).Name = "TextBox1";
	TextBox1.ReadOnly = true;
	TextBox1.ScrollBars = (ScrollBars)0;
	TextBox1.SelectionStart = 0;
	((Control)TextBox1).Size = new Size(620, 255);
	((Control)TextBox1).TabIndex = 8;
	TextBox1.TextAlign = (HorizontalAlignment)0;
	TextBox1.UseSystemPasswordChar = false;
	TextBox1.WatermarkText = "";
	Label3.AutoSize = true;
	((Control)Label3).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
	((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
	((Control)Label3).Location = new Point(12, 138);
	((Control)Label3).Name = "Label3";
	((Control)Label3).Size = new Size(93, 30);
	((Control)Label3).TabIndex = 5;
	((Label)Label3).Text = "Credits:";
	Label2.AutoSize = true;
	((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
	((Control)Label2).Location = new Point(228, 120);
	((Control)Label2).Name = "Label2";
	((Control)Label2).Size = new Size(204, 13);
	((Control)Label2).TabIndex = 4;
	((Label)Label2).Text = "Copyright (c)2007-2025 MatrixGames";
	Label1.AutoSize = true;
	((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
	((Control)Label1).Location = new Point(228, 92);
	((Control)Label1).Name = "Label1";
	((Control)Label1).Size = new Size(405, 27);
	((Control)Label1).TabIndex = 3;
	((Label)Label1).Text = "Developed by MatrixGames";
	Label_Copyright.AutoSize = true;
	((Control)Label_Copyright).ForeColor = Color.FromArgb(220, 220, 220);
	((Control)Label_Copyright).Location = new Point(228, 120);
	((Control)Label_Copyright).Name = "Label_Copyright";
	((Control)Label_Copyright).Size = new Size(339, 32);
	((Control)Label_Copyright).TabIndex = 4;
	((Label)Label_Copyright).Text = "(c)2013-2021 MatrixGames";
	PictureBox1.Image = (Image)componentResourceManager.GetObject("PictureBox1.Image");
	((Control)PictureBox1).Location = new Point(13, 13);
	((Control)PictureBox1).Name = "PictureBox1";
	((Control)PictureBox1).Size = new Size(209, 120);
	PictureBox1.SizeMode = (PictureBoxSizeMode)1;
	PictureBox1.TabIndex = 2;
	PictureBox1.TabStop = false;
	((Label)Label_version).AutoEllipsis = true;
	Label_version.AutoSize = true;
	((Control)Label_version).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
	((Control)Label_version).ForeColor = Color.FromArgb(220, 220, 220);
	((Control)Label_version).Location = new Point(228, 13);
	((Control)Label_version).MaximumSize = new Size(400, 0);
	((Control)Label_version).Name = "Label_version";
	((Control)Label_version).Size = new Size(333, 60);
	((Control)Label_version).TabIndex = 0;
	((Label)Label_version).Text = "Command - Modern Air/Naval Operations Build x";
	((Control)OKButton).Anchor = (AnchorStyles)10;
	((ButtonBase)OKButton).BackColor = Color.Transparent;
	((Button)OKButton).DialogResult = (DialogResult)0;
	((Control)OKButton).Font = new Font("Segoe UI", 10f);
	((Control)OKButton).ForeColor = SystemColors.Control;
	((Control)OKButton).Location = new Point(558, 415);
	((Control)OKButton).Name = "OKButton";
	OKButton.RoundRadius = 0;
	((Control)OKButton).Size = new Size(75, 23);
	((Control)OKButton).TabIndex = 1;
	OKButton.Text = "OK";
	TB_Licensing.AutoCompleteCustomSource = null;
	TB_Licensing.AutoCompleteMode = (AutoCompleteMode)0;
	TB_Licensing.AutoCompleteSource = (AutoCompleteSource)128;
	((Control)TB_Licensing).BackColor = SystemColors.Control;
	TB_Licensing.Font = new Font("Segoe UI", 8f);
	((Control)TB_Licensing).ForeColor = Color.FromArgb(189, 189, 189);
	TB_Licensing.Image = null;
	TB_Licensing.Lines = null;
	((Control)TB_Licensing).Location = new Point(231, 29);
	TB_Licensing.MaxLength = 32767;
	TB_Licensing.Multiline = true;
	((Control)TB_Licensing).Name = "TB_Licensing";
	TB_Licensing.ReadOnly = true;
	TB_Licensing.ScrollBars = (ScrollBars)2;
	TB_Licensing.SelectionStart = 0;
	((Control)TB_Licensing).Size = new Size(402, 79);
	((Control)TB_Licensing).TabIndex = 9;
	TB_Licensing.TextAlign = (HorizontalAlignment)0;
	TB_Licensing.UseSystemPasswordChar = false;
	TB_Licensing.WatermarkText = "";
	((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
	((Form)this).ClientSize = new Size(638, 442);
	((Control)this).Controls.Add((Control)(object)TB_Licensing);
	((Control)this).Controls.Add((Control)(object)TextBox1);
	((Control)this).Controls.Add((Control)(object)Label3);
	((Control)this).Controls.Add((Control)(object)Label_Copyright);
	((Control)this).Controls.Add((Control)(object)PictureBox1);
	((Control)this).Controls.Add((Control)(object)Label_version);
	((Control)this).Controls.Add((Control)(object)OKButton);
	((Form)this).FormBorderStyle = (FormBorderStyle)5;
	((Form)this).KeyPreview = true;
	((Form)this).MaximizeBox = false;
	((Form)this).MinimizeBox = false;
	((Control)this).Name = "AboutBox1";
	((Control)this).Padding = new Padding(9);
	((Form)this).ShowIcon = false;
	((Form)this).Text = "About Command";
	((ISupportInitialize)PictureBox1).EndInit();
	((Control)this).ResumeLayout(false);
	((Control)this).PerformLayout();
}

// FAILED Command.AboutBox1.AboutBox1_Load (token 0x06003f8f): ArgumentNullException: Value cannot be null. (Parameter 'methodReference')
using System;
using System.Windows.Forms;

private void method_2(object sender, EventArgs e)
{
	((Form)this).Close();
}

using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;

private void AboutBox1_KeyDown(object sender, KeyEventArgs e)
{
	//IL_0001: Unknown result type (might be due to invalid IL or missing references)
	//IL_0008: Invalid comparison between Unknown and I4
	if ((int)e.KeyCode == 27 && ((Control)this).Visible)
	{
		((Form)this).Close();
	}
	else
	{
		MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
	}
}

using System.Windows.Forms;
using Command.My;

private void AboutBox1_FormClosing(object sender, FormClosingEventArgs e)
{
	((Control)MyProject.Forms.MainForm).BringToFront();
}

static AboutBox1()
{
	Class72.smethod_20();
}


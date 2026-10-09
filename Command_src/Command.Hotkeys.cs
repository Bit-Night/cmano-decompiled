using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Hotkeys : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	private bool bool_2;

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("RichTextBox7")]
	internal virtual DarkRichTextBox RichTextBox7 { get; set; }

	[field: AccessedThroughProperty("RichTextBox3")]
	internal virtual DarkRichTextBox RichTextBox3 { get; set; }

	[field: AccessedThroughProperty("RichTextBox5")]
	internal virtual DarkRichTextBox RichTextBox5 { get; set; }

	[field: AccessedThroughProperty("RichTextBox6")]
	internal virtual DarkRichTextBox RichTextBox6 { get; set; }

	[field: AccessedThroughProperty("RichTextBox4")]
	internal virtual DarkRichTextBox RichTextBox4 { get; set; }

	[field: AccessedThroughProperty("RichTextBox2")]
	internal virtual DarkRichTextBox RichTextBox2 { get; set; }

	[field: AccessedThroughProperty("RichTextBox1")]
	internal virtual DarkRichTextBox RichTextBox1 { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("RichTextBox8")]
	internal virtual DarkRichTextBox RichTextBox8 { get; set; }

	[field: AccessedThroughProperty("RichTextBoxL_AMP")]
	internal virtual DarkRichTextBox RichTextBoxL_AMP { get; set; }

	[field: AccessedThroughProperty("Label_AMP_Header")]
	internal virtual DarkLabel Label_AMP_Header { get; set; }

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

	public Hotkeys()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Control)this).KeyDown += new KeyEventHandler(Hotkeys_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(Hotkeys_FormClosing);
		((Form)this).Load += Hotkeys_Load;
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
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected O, but got Unknown
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Expected O, but got Unknown
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Expected O, but got Unknown
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d6: Expected O, but got Unknown
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Expected O, but got Unknown
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Expected O, but got Unknown
		//IL_0a2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a37: Expected O, but got Unknown
		//IL_0ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aee: Expected O, but got Unknown
		//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba4: Expected O, but got Unknown
		//IL_0c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4d: Expected O, but got Unknown
		//IL_0c90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1a: Expected O, but got Unknown
		//IL_0d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f49: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Hotkeys));
		Label3 = new DarkLabel();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		Label6 = new DarkLabel();
		Label2 = new DarkLabel();
		Label7 = new DarkLabel();
		Label1 = new DarkLabel();
		RichTextBox7 = new DarkRichTextBox();
		RichTextBox3 = new DarkRichTextBox();
		RichTextBox5 = new DarkRichTextBox();
		RichTextBox6 = new DarkRichTextBox();
		RichTextBox4 = new DarkRichTextBox();
		RichTextBox2 = new DarkRichTextBox();
		RichTextBox1 = new DarkRichTextBox();
		Label8 = new DarkLabel();
		RichTextBox8 = new DarkRichTextBox();
		Label_AMP_Header = new DarkLabel();
		RichTextBoxL_AMP = new DarkRichTextBox();
		((Control)this).SuspendLayout();
		Label3.AutoSize = true;
		((Control)Label3).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(15, 0);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(56, 25);
		((Control)Label3).TabIndex = 9;
		((Label)Label3).Text = "Basic";
		Label5.AutoSize = true;
		((Control)Label5).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(393, 661);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(89, 25);
		((Control)Label5).TabIndex = 12;
		((Label)Label5).Text = "Contacts";
		Label4.AutoSize = true;
		((Control)Label4).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(393, 302);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(104, 25);
		((Control)Label4).TabIndex = 11;
		((Label)Label4).Text = "Own Units";
		Label6.AutoSize = true;
		((Control)Label6).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(15, 581);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(148, 25);
		((Control)Label6).TabIndex = 10;
		((Label)Label6).Text = "Scenario Editor";
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(15, 112);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(121, 25);
		((Control)Label2).TabIndex = 15;
		((Label)Label2).Text = "Tactical Map";
		Label7.AutoSize = true;
		((Control)Label7).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(832, 4);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(220, 25);
		((Control)Label7).TabIndex = 14;
		((Label)Label7).Text = "Expert's Tricks and Tips";
		Label1.AutoSize = true;
		((Control)Label1).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(393, 2);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(136, 25);
		((Control)Label1).TabIndex = 13;
		((Label)Label1).Text = "Function Keys";
		((TextBoxBase)RichTextBox7).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBox7).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBox7).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBox7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox7).Location = new Point(835, 25);
		((Control)RichTextBox7).Name = "RichTextBox7";
		((TextBoxBase)RichTextBox7).ReadOnly = true;
		((Control)RichTextBox7).Size = new Size(414, 246);
		((Control)RichTextBox7).TabIndex = 4;
		((RichTextBox)RichTextBox7).Text = componentResourceManager.GetString("RichTextBox7.Text");
		((TextBoxBase)RichTextBox3).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBox3).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBox3).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox3).Location = new Point(18, 21);
		((Control)RichTextBox3).Name = "RichTextBox3";
		((TextBoxBase)RichTextBox3).ReadOnly = true;
		((Control)RichTextBox3).Size = new Size(380, 106);
		((Control)RichTextBox3).TabIndex = 5;
		((RichTextBox)RichTextBox3).Text = "Spacebar , Ctrl + Enter\tStart / Resume / Pause Game\n+ (plus)\t\t\tIncrease Time Compression\n- (minus)\t\tDecrease Time Compression\nEnter\t\t\tReal-time mode (1:1 sec)\nCtrl + S\t\t\tSave Scenario\n";
		((TextBoxBase)RichTextBox5).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBox5).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBox5).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBox5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox5).Location = new Point(396, 682);
		((Control)RichTextBox5).Name = "RichTextBox5";
		((TextBoxBase)RichTextBox5).ReadOnly = true;
		((Control)RichTextBox5).Size = new Size(367, 105);
		((Control)RichTextBox5).TabIndex = 2;
		((RichTextBox)RichTextBox5).Text = "P, PgDn , Num 3\t            Drop Contact(s)\nH\t\t\tMark Hostile\nCtrl + H\t\t\tMark Unfriendly\nN\t\t\tMark Neutral\nF\t\t\tMark Friendly\nR\t\t\tRename";
		((RichTextBox)RichTextBox6).AutoSize = true;
		((TextBoxBase)RichTextBox6).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBox6).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBox6).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBox6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox6).Location = new Point(18, 600);
		((Control)RichTextBox6).Name = "RichTextBox6";
		((TextBoxBase)RichTextBox6).ReadOnly = true;
		((Control)RichTextBox6).Size = new Size(380, 217);
		((Control)RichTextBox6).TabIndex = 3;
		((RichTextBox)RichTextBox6).Text = componentResourceManager.GetString("RichTextBox6.Text");
		((TextBoxBase)RichTextBox4).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBox4).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBox4).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox4).Location = new Point(396, 323);
		((Control)RichTextBox4).Name = "RichTextBox4";
		((TextBoxBase)RichTextBox4).ReadOnly = true;
		((Control)RichTextBox4).Size = new Size(561, 312);
		((Control)RichTextBox4).TabIndex = 8;
		((RichTextBox)RichTextBox4).Text = componentResourceManager.GetString("RichTextBox4.Text");
		((TextBoxBase)RichTextBox2).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBox2).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBox2).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox2).Location = new Point(18, 133);
		((Control)RichTextBox2).Name = "RichTextBox2";
		((TextBoxBase)RichTextBox2).ReadOnly = true;
		((Control)RichTextBox2).Size = new Size(380, 461);
		((Control)RichTextBox2).TabIndex = 7;
		((RichTextBox)RichTextBox2).Text = componentResourceManager.GetString("RichTextBox2.Text");
		((TextBoxBase)RichTextBox1).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBox1).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBox1).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox1).Location = new Point(396, 23);
		((Control)RichTextBox1).Name = "RichTextBox1";
		((TextBoxBase)RichTextBox1).ReadOnly = true;
		((Control)RichTextBox1).Size = new Size(433, 277);
		((Control)RichTextBox1).TabIndex = 6;
		((RichTextBox)RichTextBox1).Text = componentResourceManager.GetString("RichTextBox1.Text");
		Label8.AutoSize = true;
		((Control)Label8).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(832, 148);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(52, 25);
		((Control)Label8).TabIndex = 17;
		((Label)Label8).Text = "Misc";
		((TextBoxBase)RichTextBox8).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBox8).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBox8).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBox8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBox8).Location = new Point(835, 169);
		((Control)RichTextBox8).Name = "RichTextBox8";
		((Control)RichTextBox8).Size = new Size(391, 187);
		((Control)RichTextBox8).TabIndex = 16;
		((RichTextBox)RichTextBox8).Text = "Ctrl + Shift + C\tLua Script Console\nCtrl + C\t\tCopy Lua values of selected units to clipboard\nCtrl + Z\t\tCopy Lua values of highlighted RPs to clipboard";
		Label_AMP_Header.AutoSize = true;
		((Control)Label_AMP_Header).Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label_AMP_Header).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AMP_Header).Location = new Point(834, 239);
		((Control)Label_AMP_Header).Margin = new Padding(2, 0, 2, 0);
		((Control)Label_AMP_Header).Name = "Label_AMP_Header";
		((Control)Label_AMP_Header).Size = new Size(247, 25);
		((Control)Label_AMP_Header).TabIndex = 17;
		((Label)Label_AMP_Header).Text = "Advanced Mission Planner";
		((TextBoxBase)RichTextBoxL_AMP).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)RichTextBoxL_AMP).BorderStyle = (BorderStyle)0;
		((RichTextBox)RichTextBoxL_AMP).Font = new Font("Segoe UI", 10f);
		((RichTextBox)RichTextBoxL_AMP).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RichTextBoxL_AMP).Location = new Point(836, 254);
		((Control)RichTextBoxL_AMP).Margin = new Padding(2);
		((Control)RichTextBoxL_AMP).Name = "RichTextBoxL_AMP";
		((Control)RichTextBoxL_AMP).Size = new Size(390, 57);
		((Control)RichTextBoxL_AMP).TabIndex = 16;
		((RichTextBox)RichTextBoxL_AMP).Text = "Ctrl + Shift + F11\tAir Tasking Order (ATO)";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(8f, 20f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).AutoSize = true;
		((Form)this).ClientSize = new Size(1258, 817);
		((Control)this).Controls.Add((Control)(object)Label_AMP_Header);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)RichTextBoxL_AMP);
		((Control)this).Controls.Add((Control)(object)RichTextBox8);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)RichTextBox7);
		((Control)this).Controls.Add((Control)(object)RichTextBox3);
		((Control)this).Controls.Add((Control)(object)RichTextBox5);
		((Control)this).Controls.Add((Control)(object)RichTextBox6);
		((Control)this).Controls.Add((Control)(object)RichTextBox4);
		((Control)this).Controls.Add((Control)(object)RichTextBox2);
		((Control)this).Controls.Add((Control)(object)RichTextBox1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Hotkeys";
		((Control)this).Padding = new Padding(9);
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Hotkeys";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void Hotkeys_KeyDown(object sender, KeyEventArgs e)
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

	private void Hotkeys_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void Hotkeys_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Control)RichTextBoxL_AMP).Visible = true;
		((Control)Label_AMP_Header).Visible = true;
	}

	static Hotkeys()
	{
		Class72.smethod_20();
	}
}

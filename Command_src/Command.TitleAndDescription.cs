using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using MSDN.Html.Editor;

namespace Command;

[DesignerGenerated]
public sealed class TitleAndDescription : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditHTML")]
	private DarkUIButton _Button_EditHTML;

	public string Title;

	public string Description;

	[field: AccessedThroughProperty("Editor1")]
	private virtual HtmlEditorControl Editor1 { get; set; }

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button1
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
			DarkUIButton darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUIButton Button_EditHTML
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditHTML;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button_EditHTML;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditHTML = value;
			darkUIButton = _Button_EditHTML;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public TitleAndDescription()
	{
		((Form)this).Shown += TitleAndDescription_Shown;
		((Form)this).Load += TitleAndDescription_Load;
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
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Expected O, but got Unknown
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Expected O, but got Unknown
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		Editor1 = new HtmlEditorControl();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Label2 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Label1 = new DarkLabel();
		Button_EditHTML = new DarkUIButton();
		((Control)this).SuspendLayout();
		((Control)Editor1).Anchor = (AnchorStyles)15;
		Editor1.BackColor = Color.FromArgb(69, 73, 74);
		Editor1.BodyBackColor = Color.FromArgb(224, 224, 224);
		Editor1.BodyFont = new HtmlFontProperty("Segoe UI", HtmlFontSize.Medium, bold: false, italic: false, underline: false, strikeout: false, subscript: false, superscript: false);
		Editor1.BodyForeColor = Color.FromArgb(220, 220, 220);
		Editor1.BorderSize = 0;
		((UserControl)Editor1).BorderStyle = (BorderStyle)1;
		((Control)Editor1).Enabled = false;
		((Control)Editor1).ForeColor = Color.FromArgb(220, 220, 220);
		Editor1.InnerText = null;
		((Control)Editor1).Location = new Point(6, 67);
		((Control)Editor1).Name = "Editor1";
		((Control)Editor1).Size = new Size(869, 414);
		((Control)Editor1).TabIndex = 33;
		Editor1.ToolbarDock = (DockStyle)1;
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(800, 487);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 32;
		Button2.Text = "Cancel";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(6, 487);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 31;
		Button1.Text = "OK";
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(3, 50);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(78, 14);
		((Control)Label2).TabIndex = 30;
		((Label)Label2).Text = "Description:";
		((Control)TextBox1).Anchor = (AnchorStyles)13;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 8f);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(43, 12);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(832, 20);
		((Control)TextBox1).TabIndex = 29;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TextBox1.WordWrap = false;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(3, 15);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(30, 13);
		((Control)Label1).TabIndex = 28;
		((Label)Label1).Text = "Title:";
		((Control)Button_EditHTML).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_EditHTML).BackColor = Color.Transparent;
		((Control)Button_EditHTML).Font = new Font("Segoe UI", 10f);
		((Control)Button_EditHTML).ForeColor = SystemColors.Control;
		((Control)Button_EditHTML).Location = new Point(745, 41);
		((Control)Button_EditHTML).Name = "Button_EditHTML";
		((Control)Button_EditHTML).Padding = new Padding(5);
		Button_EditHTML.RoundRadius = 0;
		((Control)Button_EditHTML).Size = new Size(130, 23);
		((Control)Button_EditHTML).TabIndex = 34;
		Button_EditHTML.Text = "Edit HTML source";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(878, 513);
		((Control)this).Controls.Add((Control)(object)Button_EditHTML);
		((Control)this).Controls.Add((Control)(object)Editor1);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "TitleAndDescription";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Title And Description";
		((Control)this).ResumeLayout(false);
	}

	private void method_2(object sender, EventArgs e)
	{
		Title = TextBox1.Text;
		Description = Editor1.BodyHtml;
		((Form)this).DialogResult = (DialogResult)1;
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
		((Form)this).Close();
	}

	private void TitleAndDescription_Shown(object sender, EventArgs e)
	{
		TextBox1.Text = Title;
		if (!string.IsNullOrEmpty(Description))
		{
			Editor1.BodyHtml = Description;
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		Editor1.HtmlContentsEdit();
	}

	private void TitleAndDescription_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static TitleAndDescription()
	{
		Class72.smethod_20();
	}
}

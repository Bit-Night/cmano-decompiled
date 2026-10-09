using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class ErrorForm : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("buttonOK")]
	private DarkUIButton _buttonOK;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonOK_NONOTIF")]
	private DarkUIButton _ButtonOK_NONOTIF;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_TechnicalSupport")]
	private DarkUIButton _Button_TechnicalSupport;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OpenFolder_Exception")]
	private DarkUIButton _Button_OpenFolder_Exception;

	[AccessedThroughProperty("Button_OpenFolderScenario")]
	[CompilerGenerated]
	private DarkUIButton _Button_OpenFolderScenario;

	[field: AccessedThroughProperty("TB_Error")]
	internal virtual DarkRichTextBox TB_Error { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	internal virtual DarkUIButton buttonOK
	{
		[CompilerGenerated]
		get
		{
			return _buttonOK;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _buttonOK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_buttonOK = value;
			darkUIButton = _buttonOK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonOK_NONOTIF
	{
		[CompilerGenerated]
		get
		{
			return _ButtonOK_NONOTIF;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _ButtonOK_NONOTIF;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonOK_NONOTIF = value;
			darkUIButton = _ButtonOK_NONOTIF;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	internal virtual DarkUIButton Button_TechnicalSupport
	{
		[CompilerGenerated]
		get
		{
			return _Button_TechnicalSupport;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			DarkUIButton darkUIButton = _Button_TechnicalSupport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_TechnicalSupport = value;
			darkUIButton = _Button_TechnicalSupport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	internal virtual DarkUIButton Button_OpenFolder_Exception
	{
		[CompilerGenerated]
		get
		{
			return _Button_OpenFolder_Exception;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			DarkUIButton darkUIButton = _Button_OpenFolder_Exception;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OpenFolder_Exception = value;
			darkUIButton = _Button_OpenFolder_Exception;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	internal virtual DarkUIButton Button_OpenFolderScenario
	{
		[CompilerGenerated]
		get
		{
			return _Button_OpenFolderScenario;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_OpenFolderScenario;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OpenFolderScenario = value;
			darkUIButton = _Button_OpenFolderScenario;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7 { get; set; }

	[field: AccessedThroughProperty("Panel1")]
	internal virtual Panel Panel1 { get; set; }

	public ErrorForm()
	{
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		TB_Error = new DarkRichTextBox();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		DarkLabel1 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		DarkLabel4 = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		DarkLabel6 = new DarkLabel();
		DarkLabel7 = new DarkLabel();
		Panel1 = new Panel();
		Button_TechnicalSupport = new DarkUIButton();
		Button_OpenFolderScenario = new DarkUIButton();
		Button_OpenFolder_Exception = new DarkUIButton();
		buttonOK = new DarkUIButton();
		ButtonOK_NONOTIF = new DarkUIButton();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TB_Error).Anchor = (AnchorStyles)15;
		((TextBoxBase)TB_Error).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)TB_Error).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_Error).Location = new Point(12, 25);
		((Control)TB_Error).Name = "TB_Error";
		((Control)TB_Error).Size = new Size(257, 247);
		((Control)TB_Error).TabIndex = 0;
		((RichTextBox)TB_Error).Text = "";
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)buttonOK);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)ButtonOK_NONOTIF);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)1;
		((Control)FlowLayoutPanel1).Location = new Point(12, 278);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(492, 28);
		((Control)FlowLayoutPanel1).TabIndex = 1;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(12, 6);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(229, 13);
		((Control)DarkLabel1).TabIndex = 2;
		((Label)DarkLabel1).Text = "Command has encountered the following error :";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(35, 7);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(162, 20);
		((Control)DarkLabel2).TabIndex = 0;
		((Label)DarkLabel2).Text = "How to report a bug ?";
		((Label)DarkLabel2).TextAlign = (ContentAlignment)2;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(7, 30);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(208, 13);
		((Control)DarkLabel3).TabIndex = 0;
		((Label)DarkLabel3).Text = "Create a thread on technical support forum";
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(7, 87);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(29, 13);
		((Control)DarkLabel4).TabIndex = 4;
		((Label)DarkLabel4).Text = "With";
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(7, 107);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(139, 13);
		((Control)DarkLabel5).TabIndex = 5;
		((Label)DarkLabel5).Text = "1.The exception log located";
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(7, 126);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(116, 13);
		((Control)DarkLabel6).TabIndex = 7;
		((Label)DarkLabel6).Text = "2.The scenario located";
		DarkLabel7.AutoSize = true;
		((Control)DarkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel7).Location = new Point(7, 145);
		((Control)DarkLabel7).Name = "DarkLabel7";
		((Control)DarkLabel7).Size = new Size(194, 13);
		((Control)DarkLabel7).TabIndex = 9;
		((Label)DarkLabel7).Text = "3. Any factual details or any impressions";
		((Control)Panel1).BackColor = Color.FromArgb(40, 40, 40);
		((Control)Panel1).Controls.Add((Control)(object)Button_TechnicalSupport);
		((Control)Panel1).Controls.Add((Control)(object)DarkLabel7);
		((Control)Panel1).Controls.Add((Control)(object)DarkLabel2);
		((Control)Panel1).Controls.Add((Control)(object)Button_OpenFolderScenario);
		((Control)Panel1).Controls.Add((Control)(object)DarkLabel3);
		((Control)Panel1).Controls.Add((Control)(object)DarkLabel6);
		((Control)Panel1).Controls.Add((Control)(object)DarkLabel4);
		((Control)Panel1).Controls.Add((Control)(object)Button_OpenFolder_Exception);
		((Control)Panel1).Controls.Add((Control)(object)DarkLabel5);
		((Control)Panel1).Location = new Point(275, 25);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(229, 250);
		((Control)Panel1).TabIndex = 10;
		((ButtonBase)Button_TechnicalSupport).BackColor = Color.Transparent;
		((Button)Button_TechnicalSupport).DialogResult = (DialogResult)0;
		((Control)Button_TechnicalSupport).ForeColor = SystemColors.Control;
		((Control)Button_TechnicalSupport).Location = new Point(13, 46);
		((Control)Button_TechnicalSupport).Name = "Button_TechnicalSupport";
		Button_TechnicalSupport.RoundRadius = 0;
		((Control)Button_TechnicalSupport).Size = new Size(205, 33);
		((Control)Button_TechnicalSupport).TabIndex = 3;
		Button_TechnicalSupport.Text = "Technical Support";
		((ButtonBase)Button_OpenFolderScenario).BackColor = Color.Transparent;
		((Button)Button_OpenFolderScenario).DialogResult = (DialogResult)0;
		((Control)Button_OpenFolderScenario).ForeColor = SystemColors.Control;
		((Control)Button_OpenFolderScenario).Location = new Point(123, 124);
		((Control)Button_OpenFolderScenario).Name = "Button_OpenFolderScenario";
		Button_OpenFolderScenario.RoundRadius = 0;
		((Control)Button_OpenFolderScenario).Size = new Size(30, 19);
		((Control)Button_OpenFolderScenario).TabIndex = 8;
		Button_OpenFolderScenario.Text = "here";
		((ButtonBase)Button_OpenFolder_Exception).BackColor = Color.Transparent;
		((Button)Button_OpenFolder_Exception).DialogResult = (DialogResult)0;
		((Control)Button_OpenFolder_Exception).ForeColor = SystemColors.Control;
		((Control)Button_OpenFolder_Exception).Location = new Point(146, 104);
		((Control)Button_OpenFolder_Exception).Name = "Button_OpenFolder_Exception";
		Button_OpenFolder_Exception.RoundRadius = 0;
		((Control)Button_OpenFolder_Exception).Size = new Size(30, 19);
		((Control)Button_OpenFolder_Exception).TabIndex = 6;
		Button_OpenFolder_Exception.Text = "here";
		((ButtonBase)buttonOK).BackColor = Color.Transparent;
		((Button)buttonOK).DialogResult = (DialogResult)1;
		((Control)buttonOK).ForeColor = SystemColors.Control;
		((Control)buttonOK).Location = new Point(3, 3);
		((Control)buttonOK).Name = "buttonOK";
		buttonOK.RoundRadius = 0;
		((Control)buttonOK).Size = new Size(240, 23);
		((Control)buttonOK).TabIndex = 0;
		buttonOK.Text = "OK";
		((ButtonBase)ButtonOK_NONOTIF).BackColor = Color.Transparent;
		((Button)ButtonOK_NONOTIF).DialogResult = (DialogResult)5;
		((Control)ButtonOK_NONOTIF).ForeColor = SystemColors.Control;
		((Control)ButtonOK_NONOTIF).Location = new Point(249, 3);
		((Control)ButtonOK_NONOTIF).Name = "ButtonOK_NONOTIF";
		ButtonOK_NONOTIF.RoundRadius = 0;
		((Control)ButtonOK_NONOTIF).Size = new Size(240, 23);
		((Control)ButtonOK_NONOTIF).TabIndex = 1;
		ButtonOK_NONOTIF.Text = "OK (don't get notified again)";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 60, 60);
		((Form)this).ClientSize = new Size(516, 309);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)this).Controls.Add((Control)(object)TB_Error);
		((Form)this).MaximumSize = new Size(532, 348);
		((Control)this).Name = "ErrorForm";
		((Form)this).Text = "Error";
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public static void Open(ExceptionEntry entry, string CustomContent = "")
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		ErrorForm errorForm = new ErrorForm();
		if (!string.IsNullOrEmpty(CustomContent))
		{
			((RichTextBox)errorForm.TB_Error).Text = CustomContent;
		}
		else
		{
			((RichTextBox)errorForm.TB_Error).Text = entry.Content;
		}
		DialogResult val = ((Form)errorForm).ShowDialog();
		if ((int)val != 1 && (int)val == 5)
		{
			entry.UI_Ignored = true;
		}
	}

	public static bool Open(string entry, bool EnableFeedback = false)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		ErrorForm errorForm = new ErrorForm();
		((RichTextBox)errorForm.TB_Error).Text = entry;
		((Control)errorForm.ButtonOK_NONOTIF).Visible = EnableFeedback;
		DialogResult val = ((Form)errorForm).ShowDialog();
		if ((int)val == 1)
		{
			return true;
		}
		return false;
	}

	private void method_0(object sender, EventArgs e)
	{
		try
		{
			Process.Start("https://www.matrixgames.com/forums/viewforum.php?f=10230");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		try
		{
			Process.Start(GameGeneral.LogsPath);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		try
		{
			Process.Start(GameGeneral.ScenariosRootPath);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void method_4(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)5;
	}

	static ErrorForm()
	{
		Class72.smethod_20();
	}
}

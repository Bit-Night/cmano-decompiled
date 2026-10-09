using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class InputDialog : Form
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton _Button_Cancel;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private DarkUIButton _Button_OK;

	[field: AccessedThroughProperty("TB_Main")]
	internal virtual DarkUITextBox TB_Main { get; set; }

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			DarkUIButton darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Cancel = value;
			darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return _Button_OK;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			DarkUIButton darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OK = value;
			darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public InputDialog()
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
		TB_Main = new DarkUITextBox();
		Button_Cancel = new DarkUIButton();
		Button_OK = new DarkUIButton();
		((Control)this).SuspendLayout();
		TB_Main.AutoCompleteCustomSource = null;
		TB_Main.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Main.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Main).BackColor = Color.Transparent;
		((Control)TB_Main).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Main.Image = null;
		TB_Main.Lines = null;
		((Control)TB_Main).Location = new Point(12, 12);
		TB_Main.MaxLength = 32767;
		TB_Main.Multiline = false;
		((Control)TB_Main).Name = "TB_Main";
		TB_Main.ReadOnly = false;
		TB_Main.ScrollBars = (ScrollBars)0;
		TB_Main.SelectionStart = 0;
		((Control)TB_Main).Size = new Size(200, 24);
		((Control)TB_Main).TabIndex = 0;
		TB_Main.TextAlign = (HorizontalAlignment)0;
		TB_Main.UseSystemPasswordChar = false;
		TB_Main.WatermarkText = "Enter text . . .";
		((ButtonBase)Button_Cancel).BackColor = Color.Transparent;
		((Button)Button_Cancel).DialogResult = (DialogResult)2;
		((Control)Button_Cancel).ForeColor = SystemColors.Control;
		((Control)Button_Cancel).Location = new Point(294, 11);
		((Control)Button_Cancel).Name = "Button_Cancel";
		Button_Cancel.RoundRadius = 0;
		((Control)Button_Cancel).Size = new Size(70, 23);
		((Control)Button_Cancel).TabIndex = 1;
		Button_Cancel.Text = "Cancel";
		((ButtonBase)Button_OK).BackColor = Color.Transparent;
		((Button)Button_OK).DialogResult = (DialogResult)0;
		((Control)Button_OK).ForeColor = SystemColors.Control;
		((Control)Button_OK).Location = new Point(218, 11);
		((Control)Button_OK).Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		((Control)Button_OK).Size = new Size(70, 23);
		((Control)Button_OK).TabIndex = 2;
		Button_OK.Text = "OK";
		((Form)this).AcceptButton = (IButtonControl)(object)Button_OK;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).CancelButton = (IButtonControl)(object)Button_Cancel;
		((Form)this).ClientSize = new Size(373, 46);
		((Control)this).Controls.Add((Control)(object)Button_OK);
		((Control)this).Controls.Add((Control)(object)Button_Cancel);
		((Control)this).Controls.Add((Control)(object)TB_Main);
		((Control)this).Name = "InputDialog";
		((Form)this).Text = "InputDialog";
		((Control)this).ResumeLayout(false);
	}

	private void method_0(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void method_1(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	public static string CallDialog(string Title = "User input dialog", string Description = "Enter Text . . .", string CancelReturnValue = "")
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		InputDialog inputDialog = new InputDialog();
		inputDialog.TB_Main.WatermarkText = Description;
		((Form)inputDialog).Text = Title;
		if ((int)((Form)inputDialog).ShowDialog() == 1)
		{
			if (!string.IsNullOrEmpty(inputDialog.TB_Main.Text))
			{
				return inputDialog.TB_Main.Text;
			}
			return CancelReturnValue;
		}
		return CancelReturnValue;
	}

	static InputDialog()
	{
		Class72.smethod_20();
	}
}

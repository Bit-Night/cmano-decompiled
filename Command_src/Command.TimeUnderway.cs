using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TimeUnderway : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCancel")]
	private DarkUIButton _BtnCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOK")]
	private DarkUIButton _BtnOK;

	[AccessedThroughProperty("DaysUnderway_TextBox")]
	[CompilerGenerated]
	private DarkUITextBox _DaysUnderway_TextBox;

	[AccessedThroughProperty("HoursUnderway_TextBox")]
	[CompilerGenerated]
	private DarkUITextBox _HoursUnderway_TextBox;

	[CompilerGenerated]
	[AccessedThroughProperty("MinUnderway_TextBox")]
	private DarkUITextBox _MinUnderway_TextBox;

	[CompilerGenerated]
	[AccessedThroughProperty("SecUnderway_TextBox")]
	private DarkUITextBox _SecUnderway_TextBox;

	public ActiveUnit theAU;

	internal virtual DarkUIButton BtnCancel
	{
		[CompilerGenerated]
		get
		{
			return _BtnCancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _BtnCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnCancel = value;
			darkUIButton = _BtnCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton BtnOK
	{
		[CompilerGenerated]
		get
		{
			return _BtnOK;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _BtnOK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnOK = value;
			darkUIButton = _BtnOK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUITextBox DaysUnderway_TextBox
	{
		[CompilerGenerated]
		get
		{
			return _DaysUnderway_TextBox;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_4;
			DarkUITextBox darkUITextBox = _DaysUnderway_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_DaysUnderway_TextBox = value;
			darkUITextBox = _DaysUnderway_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUITextBox HoursUnderway_TextBox
	{
		[CompilerGenerated]
		get
		{
			return _HoursUnderway_TextBox;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_5;
			DarkUITextBox darkUITextBox = _HoursUnderway_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_HoursUnderway_TextBox = value;
			darkUITextBox = _HoursUnderway_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUITextBox MinUnderway_TextBox
	{
		[CompilerGenerated]
		get
		{
			return _MinUnderway_TextBox;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_6;
			DarkUITextBox darkUITextBox = _MinUnderway_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_MinUnderway_TextBox = value;
			darkUITextBox = _MinUnderway_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUITextBox SecUnderway_TextBox
	{
		[CompilerGenerated]
		get
		{
			return _SecUnderway_TextBox;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_7;
			DarkUITextBox darkUITextBox = _SecUnderway_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_SecUnderway_TextBox = value;
			darkUITextBox = _SecUnderway_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	[field: AccessedThroughProperty("lblsec")]
	internal virtual DarkLabel lblsec { get; set; }

	public TimeUnderway()
	{
		((Form)this).Shown += TimeUnderway_Shown;
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
		BtnCancel = new DarkUIButton();
		BtnOK = new DarkUIButton();
		Label1 = new DarkLabel();
		DaysUnderway_TextBox = new DarkUITextBox();
		HoursUnderway_TextBox = new DarkUITextBox();
		MinUnderway_TextBox = new DarkUITextBox();
		SecUnderway_TextBox = new DarkUITextBox();
		DarkLabel1 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		lblsec = new DarkLabel();
		((Control)this).SuspendLayout();
		((ButtonBase)BtnCancel).BackColor = Color.Transparent;
		((Button)BtnCancel).DialogResult = (DialogResult)2;
		((Control)BtnCancel).ForeColor = SystemColors.Control;
		((Control)BtnCancel).Location = new Point(267, 89);
		((Control)BtnCancel).Name = "BtnCancel";
		BtnCancel.RoundRadius = 0;
		((Control)BtnCancel).Size = new Size(75, 23);
		((Control)BtnCancel).TabIndex = 4;
		BtnCancel.Text = "Cancel";
		((ButtonBase)BtnOK).BackColor = Color.Transparent;
		((Button)BtnOK).DialogResult = (DialogResult)0;
		((Control)BtnOK).ForeColor = SystemColors.Control;
		((Control)BtnOK).Location = new Point(24, 89);
		((Control)BtnOK).Name = "BtnOK";
		BtnOK.RoundRadius = 0;
		((Control)BtnOK).Size = new Size(75, 23);
		((Control)BtnOK).TabIndex = 5;
		BtnOK.Text = "OK";
		((Control)Label1).Anchor = (AnchorStyles)13;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(19, 9);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(321, 25);
		((Control)Label1).TabIndex = 4;
		((Label)Label1).Text = "Set time underway for the selected unit";
		DaysUnderway_TextBox.AutoCompleteCustomSource = null;
		DaysUnderway_TextBox.AutoCompleteMode = (AutoCompleteMode)0;
		DaysUnderway_TextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)DaysUnderway_TextBox).BackColor = Color.Transparent;
		((Control)DaysUnderway_TextBox).ForeColor = Color.FromArgb(189, 189, 189);
		DaysUnderway_TextBox.Image = null;
		DaysUnderway_TextBox.Lines = null;
		((Control)DaysUnderway_TextBox).Location = new Point(24, 60);
		DaysUnderway_TextBox.MaxLength = 2;
		DaysUnderway_TextBox.Multiline = false;
		((Control)DaysUnderway_TextBox).Name = "DaysUnderway_TextBox";
		DaysUnderway_TextBox.ReadOnly = false;
		DaysUnderway_TextBox.ScrollBars = (ScrollBars)0;
		DaysUnderway_TextBox.SelectionStart = 0;
		((Control)DaysUnderway_TextBox).Size = new Size(57, 23);
		((Control)DaysUnderway_TextBox).TabIndex = 0;
		DaysUnderway_TextBox.Text = "0";
		DaysUnderway_TextBox.TextAlign = (HorizontalAlignment)2;
		DaysUnderway_TextBox.UseSystemPasswordChar = false;
		DaysUnderway_TextBox.WatermarkText = "";
		HoursUnderway_TextBox.AutoCompleteCustomSource = null;
		HoursUnderway_TextBox.AutoCompleteMode = (AutoCompleteMode)0;
		HoursUnderway_TextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)HoursUnderway_TextBox).BackColor = Color.Transparent;
		((Control)HoursUnderway_TextBox).ForeColor = Color.FromArgb(189, 189, 189);
		HoursUnderway_TextBox.Image = null;
		HoursUnderway_TextBox.Lines = null;
		((Control)HoursUnderway_TextBox).Location = new Point(108, 60);
		HoursUnderway_TextBox.MaxLength = 2;
		HoursUnderway_TextBox.Multiline = false;
		((Control)HoursUnderway_TextBox).Name = "HoursUnderway_TextBox";
		HoursUnderway_TextBox.ReadOnly = false;
		HoursUnderway_TextBox.ScrollBars = (ScrollBars)0;
		HoursUnderway_TextBox.SelectionStart = 0;
		((Control)HoursUnderway_TextBox).Size = new Size(57, 23);
		((Control)HoursUnderway_TextBox).TabIndex = 1;
		HoursUnderway_TextBox.Text = "0";
		HoursUnderway_TextBox.TextAlign = (HorizontalAlignment)2;
		HoursUnderway_TextBox.UseSystemPasswordChar = false;
		HoursUnderway_TextBox.WatermarkText = "";
		MinUnderway_TextBox.AutoCompleteCustomSource = null;
		MinUnderway_TextBox.AutoCompleteMode = (AutoCompleteMode)0;
		MinUnderway_TextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)MinUnderway_TextBox).BackColor = Color.Transparent;
		((Control)MinUnderway_TextBox).ForeColor = Color.FromArgb(189, 189, 189);
		MinUnderway_TextBox.Image = null;
		MinUnderway_TextBox.Lines = null;
		((Control)MinUnderway_TextBox).Location = new Point(194, 60);
		MinUnderway_TextBox.MaxLength = 2;
		MinUnderway_TextBox.Multiline = false;
		((Control)MinUnderway_TextBox).Name = "MinUnderway_TextBox";
		MinUnderway_TextBox.ReadOnly = false;
		MinUnderway_TextBox.ScrollBars = (ScrollBars)0;
		MinUnderway_TextBox.SelectionStart = 0;
		((Control)MinUnderway_TextBox).Size = new Size(57, 23);
		((Control)MinUnderway_TextBox).TabIndex = 2;
		MinUnderway_TextBox.Text = "0";
		MinUnderway_TextBox.TextAlign = (HorizontalAlignment)2;
		MinUnderway_TextBox.UseSystemPasswordChar = false;
		MinUnderway_TextBox.WatermarkText = "";
		SecUnderway_TextBox.AutoCompleteCustomSource = null;
		SecUnderway_TextBox.AutoCompleteMode = (AutoCompleteMode)0;
		SecUnderway_TextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)SecUnderway_TextBox).BackColor = Color.Transparent;
		((Control)SecUnderway_TextBox).ForeColor = Color.FromArgb(189, 189, 189);
		SecUnderway_TextBox.Image = null;
		SecUnderway_TextBox.Lines = null;
		((Control)SecUnderway_TextBox).Location = new Point(285, 60);
		SecUnderway_TextBox.MaxLength = 2;
		SecUnderway_TextBox.Multiline = false;
		((Control)SecUnderway_TextBox).Name = "SecUnderway_TextBox";
		SecUnderway_TextBox.ReadOnly = false;
		SecUnderway_TextBox.ScrollBars = (ScrollBars)0;
		SecUnderway_TextBox.SelectionStart = 0;
		((Control)SecUnderway_TextBox).Size = new Size(57, 23);
		((Control)SecUnderway_TextBox).TabIndex = 3;
		SecUnderway_TextBox.Text = "0";
		SecUnderway_TextBox.TextAlign = (HorizontalAlignment)2;
		SecUnderway_TextBox.UseSystemPasswordChar = false;
		SecUnderway_TextBox.WatermarkText = "";
		((Control)DarkLabel1).Anchor = (AnchorStyles)13;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(19, 34);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(51, 25);
		((Label)DarkLabel1).Text = "Days";
		((Control)DarkLabel2).Anchor = (AnchorStyles)13;
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(103, 34);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(60, 25);
		((Control)DarkLabel2).TabIndex = 2;
		((Label)DarkLabel2).Text = "Hours";
		((Control)DarkLabel3).Anchor = (AnchorStyles)13;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(189, 34);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(75, 25);
		((Control)DarkLabel3).TabIndex = 1;
		((Label)DarkLabel3).Text = "Minutes";
		((Control)lblsec).Anchor = (AnchorStyles)13;
		lblsec.AutoSize = true;
		((Control)lblsec).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblsec).Location = new Point(280, 34);
		((Control)lblsec).Name = "lblsec";
		((Control)lblsec).Size = new Size(79, 25);
		((Control)lblsec).TabIndex = 0;
		((Label)lblsec).Text = "Seconds";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(358, 122);
		((Control)this).Controls.Add((Control)(object)lblsec);
		((Control)this).Controls.Add((Control)(object)DarkLabel3);
		((Control)this).Controls.Add((Control)(object)DarkLabel2);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)SecUnderway_TextBox);
		((Control)this).Controls.Add((Control)(object)MinUnderway_TextBox);
		((Control)this).Controls.Add((Control)(object)HoursUnderway_TextBox);
		((Control)this).Controls.Add((Control)(object)DaysUnderway_TextBox);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)BtnCancel);
		((Control)this).Controls.Add((Control)(object)BtnOK);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).MaximizeBox = false;
		((Form)this).MaximumSize = new Size(358, 122);
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(358, 122);
		((Control)this).Name = "TimeUnderway";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Time Underway";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void TimeUnderway_Shown(object sender, EventArgs e)
	{
		if (theAU != null)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(theAU.TimeUnderway);
			string text = timeSpan.Days.ToString();
			string text2 = timeSpan.Hours.ToString();
			string text3 = timeSpan.Minutes.ToString();
			string text4 = timeSpan.Seconds.ToString();
			DaysUnderway_TextBox.Text = text;
			HoursUnderway_TextBox.Text = text2;
			MinUnderway_TextBox.Text = text3;
			SecUnderway_TextBox.Text = text4;
			((Control)DaysUnderway_TextBox).Select();
			((Control)this).SelectNextControl(((ContainerControl)this).ActiveControl, true, true, true, false);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Invalid comparison between Unknown and I4
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Invalid comparison between Unknown and I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Invalid comparison between Unknown and I4
		try
		{
			if (!int.TryParse(DaysUnderway_TextBox.Text, out var result) && (int)DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == 1)
			{
				DaysUnderway_TextBox.Text = "0";
				return;
			}
			if (!int.TryParse(HoursUnderway_TextBox.Text, out var result2) && (int)DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == 1)
			{
				HoursUnderway_TextBox.Text = "0";
				return;
			}
			if (!int.TryParse(MinUnderway_TextBox.Text, out var result3) && (int)DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == 1)
			{
				MinUnderway_TextBox.Text = "0";
				return;
			}
			if (!int.TryParse(SecUnderway_TextBox.Text, out var result4) && (int)DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == 1)
			{
				SecUnderway_TextBox.Text = "0";
				return;
			}
			result = Conversions.ToInteger(DaysUnderway_TextBox.Text) * 3600 * 24;
			result2 = Conversions.ToInteger(HoursUnderway_TextBox.Text) * 3600;
			result3 = Conversions.ToInteger(MinUnderway_TextBox.Text) * 60;
			result4 = Conversions.ToInteger(SecUnderway_TextBox.Text);
			float num = result + result2 + result3 + result4;
			if (theAU.GetType().Equals(typeof(Aircraft)))
			{
				((Aircraft)theAU).AirborneTime = num;
			}
			theAU.TimeUnderway = num;
			((Form)this).Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(object object_0)
	{
		if (int.TryParse(DaysUnderway_TextBox.Text, out var result) && result < 0)
		{
			result = 0;
		}
	}

	private void method_5(object object_0)
	{
		if (int.TryParse(HoursUnderway_TextBox.Text, out var result) && result < 0)
		{
			result = 0;
		}
	}

	private void method_6(object object_0)
	{
		if (int.TryParse(MinUnderway_TextBox.Text, out var result) && result < 0)
		{
			result = 0;
		}
	}

	private void method_7(object object_0)
	{
		if (int.TryParse(((Label)lblsec).Text, out var result) && result < 0)
		{
			result = 0;
		}
	}

	static TimeUnderway()
	{
		Class72.smethod_20();
	}
}

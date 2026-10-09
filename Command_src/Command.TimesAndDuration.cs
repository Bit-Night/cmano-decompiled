using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TimesAndDuration : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[AccessedThroughProperty("CB_DaylightSavingTime")]
	[CompilerGenerated]
	private DarkCheckBox _CB_DaylightSavingTime;

	[AccessedThroughProperty("Button_CopyFromCurrent")]
	[CompilerGenerated]
	private DarkUIButton _Button_CopyFromCurrent;

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("TB_Hours")]
	internal virtual DarkUITextBox TB_Hours { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("TB_Days")]
	internal virtual DarkUITextBox TB_Days { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("DTP_StartDate")]
	internal virtual DarkMaskedTextBox DTP_StartDate { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("TB_Mins")]
	internal virtual DarkUITextBox TB_Mins { get; set; }

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

	[field: AccessedThroughProperty("DTP_StartTime")]
	internal virtual DarkMaskedTextBox DTP_StartTime { get; set; }

	[field: AccessedThroughProperty("DTP_CurrentDate")]
	internal virtual DarkMaskedTextBox DTP_CurrentDate { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("DTP_CurrentTime")]
	internal virtual DarkMaskedTextBox DTP_CurrentTime { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("NUD_Complexity")]
	internal virtual GClass9 NUD_Complexity { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("NUD_Difficulty")]
	internal virtual GClass9 NUD_Difficulty { get; set; }

	internal virtual DarkCheckBox CB_DaylightSavingTime
	{
		[CompilerGenerated]
		get
		{
			return _CB_DaylightSavingTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkCheckBox darkCheckBox = _CB_DaylightSavingTime;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_DaylightSavingTime = value;
			darkCheckBox = _CB_DaylightSavingTime;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label10")]
	internal virtual DarkLabel Label10 { get; set; }

	[field: AccessedThroughProperty("Label11")]
	internal virtual DarkLabel Label11 { get; set; }

	[field: AccessedThroughProperty("TB_DaylightSavingTime_Start")]
	internal virtual MaskedTextBox TB_DaylightSavingTime_Start { get; set; }

	[field: AccessedThroughProperty("TB_DaylightSavingTime_End")]
	internal virtual MaskedTextBox TB_DaylightSavingTime_End { get; set; }

	internal virtual DarkUIButton Button_CopyFromCurrent
	{
		[CompilerGenerated]
		get
		{
			return _Button_CopyFromCurrent;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIButton darkUIButton = _Button_CopyFromCurrent;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_CopyFromCurrent = value;
			darkUIButton = _Button_CopyFromCurrent;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public TimesAndDuration()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += TimesAndDuration_Load;
		((Control)this).KeyDown += new KeyEventHandler(TimesAndDuration_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(TimesAndDuration_FormClosing);
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
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Expected O, but got Unknown
		//IL_0832: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Expected O, but got Unknown
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Expected O, but got Unknown
		//IL_0be2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bec: Expected O, but got Unknown
		//IL_0dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcf: Expected O, but got Unknown
		//IL_0ed7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee1: Expected O, but got Unknown
		//IL_1216: Unknown result type (might be due to invalid IL or missing references)
		//IL_1220: Expected O, but got Unknown
		Label4 = new DarkLabel();
		TB_Hours = new DarkUITextBox();
		Label3 = new DarkLabel();
		TB_Days = new DarkUITextBox();
		Label2 = new DarkLabel();
		DTP_StartDate = new DarkMaskedTextBox();
		Label1 = new DarkLabel();
		Label5 = new DarkLabel();
		TB_Mins = new DarkUITextBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		DTP_StartTime = new DarkMaskedTextBox();
		DTP_CurrentDate = new DarkMaskedTextBox();
		Label6 = new DarkLabel();
		DTP_CurrentTime = new DarkMaskedTextBox();
		Label7 = new DarkLabel();
		NUD_Complexity = new GClass9();
		Label8 = new DarkLabel();
		Label9 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		NUD_Difficulty = new GClass9();
		CB_DaylightSavingTime = new DarkCheckBox();
		Label10 = new DarkLabel();
		Label11 = new DarkLabel();
		TB_DaylightSavingTime_Start = new MaskedTextBox();
		TB_DaylightSavingTime_End = new MaskedTextBox();
		Button_CopyFromCurrent = new DarkUIButton();
		((Control)this).SuspendLayout();
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(211, 240);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(33, 15);
		((Control)Label4).TabIndex = 15;
		((Label)Label4).Text = "mins";
		TB_Hours.AutoCompleteCustomSource = null;
		TB_Hours.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Hours.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Hours).BackColor = Color.Transparent;
		TB_Hours.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TB_Hours).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Hours.Image = null;
		TB_Hours.Lines = null;
		((Control)TB_Hours).Location = new Point(83, 237);
		TB_Hours.MaxLength = 32767;
		TB_Hours.Multiline = false;
		((Control)TB_Hours).Name = "TB_Hours";
		TB_Hours.ReadOnly = false;
		TB_Hours.SelectionStart = 0;
		((Control)TB_Hours).Size = new Size(39, 24);
		((Control)TB_Hours).TabIndex = 14;
		TB_Hours.Text = "0";
		TB_Hours.TextAlign = (HorizontalAlignment)0;
		TB_Hours.UseSystemPasswordChar = false;
		TB_Hours.WatermarkText = "";
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(127, 240);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(37, 15);
		((Control)Label3).TabIndex = 13;
		((Label)Label3).Text = "hours";
		TB_Days.AutoCompleteCustomSource = null;
		TB_Days.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Days.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Days).BackColor = Color.Transparent;
		TB_Days.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TB_Days).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Days.Image = null;
		TB_Days.Lines = null;
		((Control)TB_Days).Location = new Point(12, 238);
		TB_Days.MaxLength = 32767;
		TB_Days.Multiline = false;
		((Control)TB_Days).Name = "TB_Days";
		TB_Days.ReadOnly = false;
		TB_Days.SelectionStart = 0;
		((Control)TB_Days).Size = new Size(35, 24);
		((Control)TB_Days).TabIndex = 12;
		TB_Days.Text = "0";
		TB_Days.TextAlign = (HorizontalAlignment)0;
		TB_Days.UseSystemPasswordChar = false;
		TB_Days.WatermarkText = "";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(48, 241);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(31, 15);
		((Control)Label2).TabIndex = 11;
		((Label)Label2).Text = "days";
		((TextBoxBase)DTP_StartDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_StartDate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_StartDate).Location = new Point(12, 167);
		((Control)DTP_StartDate).Name = "DTP_StartDate";
		((Control)DTP_StartDate).Size = new Size(305, 23);
		((Control)DTP_StartDate).TabIndex = 10;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(12, 151);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(103, 15);
		((Control)Label1).TabIndex = 16;
		((Label)Label1).Text = "Scenario starts on:";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(9, 222);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(76, 15);
		((Control)Label5).TabIndex = 17;
		((Label)Label5).Text = "And lasts for:";
		TB_Mins.AutoCompleteCustomSource = null;
		TB_Mins.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Mins.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Mins).BackColor = Color.Transparent;
		TB_Mins.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TB_Mins).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Mins.Image = null;
		TB_Mins.Lines = null;
		((Control)TB_Mins).Location = new Point(166, 237);
		TB_Mins.MaxLength = 32767;
		TB_Mins.Multiline = false;
		((Control)TB_Mins).Name = "TB_Mins";
		TB_Mins.ReadOnly = false;
		TB_Mins.SelectionStart = 0;
		((Control)TB_Mins).Size = new Size(39, 24);
		((Control)TB_Mins).TabIndex = 18;
		TB_Mins.Text = "0";
		TB_Mins.TextAlign = (HorizontalAlignment)0;
		TB_Mins.UseSystemPasswordChar = false;
		TB_Mins.WatermarkText = "";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(12, 345);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 19;
		Button1.Text = "OK";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(242, 345);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 20;
		Button2.Text = "Cancel";
		((TextBoxBase)DTP_StartTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_StartTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_StartTime).Location = new Point(12, 193);
		((Control)DTP_StartTime).Name = "DTP_StartTime";
		((Control)DTP_StartTime).Size = new Size(305, 23);
		((Control)DTP_StartTime).TabIndex = 21;
		((TextBoxBase)DTP_CurrentDate).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_CurrentDate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_CurrentDate).Location = new Point(12, 22);
		((Control)DTP_CurrentDate).Name = "DTP_CurrentDate";
		((Control)DTP_CurrentDate).Size = new Size(305, 23);
		((Control)DTP_CurrentDate).TabIndex = 22;
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(12, 6);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(123, 15);
		((Control)Label6).TabIndex = 23;
		((Label)Label6).Text = "Scenario current time:";
		((TextBoxBase)DTP_CurrentTime).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DTP_CurrentTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DTP_CurrentTime).Location = new Point(12, 48);
		((Control)DTP_CurrentTime).Name = "DTP_CurrentTime";
		((Control)DTP_CurrentTime).Size = new Size(305, 23);
		((Control)DTP_CurrentTime).TabIndex = 24;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(9, 290);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(70, 15);
		((Control)Label7).TabIndex = 25;
		((Label)Label7).Text = "Complexity:";
		NUD_Complexity.BackColor = Color.Transparent;
		((Control)NUD_Complexity).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)NUD_Complexity).Location = new Point(75, 284);
		((NumericUpDown)NUD_Complexity).Maximum = 5m;
		((NumericUpDown)NUD_Complexity).Minimum = 1m;
		((Control)NUD_Complexity).Name = "NUD_Complexity";
		((Control)NUD_Complexity).Size = new Size(47, 26);
		((Control)NUD_Complexity).TabIndex = 26;
		((NumericUpDown)NUD_Complexity).Value = 1m;
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(9, 316);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(58, 15);
		((Control)Label8).TabIndex = 27;
		((Label)Label8).Text = "Difficulty:";
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(143, 295);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(98, 15);
		((Control)Label9).TabIndex = 29;
		((Label)Label9).Text = "Location/Setting:";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(146, 311);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(171, 24);
		((Control)TextBox1).TabIndex = 30;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		NUD_Difficulty.BackColor = Color.Transparent;
		((Control)NUD_Difficulty).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)NUD_Difficulty).Location = new Point(75, 311);
		((NumericUpDown)NUD_Difficulty).Maximum = 5m;
		((NumericUpDown)NUD_Difficulty).Minimum = 1m;
		((Control)NUD_Difficulty).Name = "NUD_Difficulty";
		((Control)NUD_Difficulty).Size = new Size(47, 26);
		((Control)NUD_Difficulty).TabIndex = 31;
		((NumericUpDown)NUD_Difficulty).Value = 1m;
		((Control)CB_DaylightSavingTime).Location = new Point(12, 75);
		((Control)CB_DaylightSavingTime).Name = "CB_DaylightSavingTime";
		((Control)CB_DaylightSavingTime).Size = new Size(300, 17);
		((Control)CB_DaylightSavingTime).TabIndex = 32;
		((ButtonBase)CB_DaylightSavingTime).Text = "Use Daylight Saving Time (DST, or Summer Time)";
		Label10.AutoSize = true;
		((Control)Label10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label10).Location = new Point(11, 97);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(128, 15);
		((Control)Label10).TabIndex = 34;
		((Label)Label10).Text = "DST Start (Day.Month):";
		Label11.AutoSize = true;
		((Control)Label11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label11).Location = new Point(11, 120);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(124, 15);
		((Control)Label11).TabIndex = 35;
		((Label)Label11).Text = "DST End (Day.Month):";
		((TextBoxBase)TB_DaylightSavingTime_Start).BackColor = Color.Black;
		((TextBoxBase)TB_DaylightSavingTime_Start).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_DaylightSavingTime_Start).ForeColor = Color.FromArgb(189, 189, 189);
		((Control)TB_DaylightSavingTime_Start).Location = new Point(138, 94);
		TB_DaylightSavingTime_Start.Mask = "00.00";
		((Control)TB_DaylightSavingTime_Start).Name = "TB_DaylightSavingTime_Start";
		((Control)TB_DaylightSavingTime_Start).Size = new Size(47, 23);
		((Control)TB_DaylightSavingTime_Start).TabIndex = 36;
		((TextBoxBase)TB_DaylightSavingTime_End).BackColor = Color.Black;
		((TextBoxBase)TB_DaylightSavingTime_End).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_DaylightSavingTime_End).ForeColor = Color.FromArgb(189, 189, 189);
		((Control)TB_DaylightSavingTime_End).Location = new Point(138, 117);
		TB_DaylightSavingTime_End.Mask = "00.00";
		((Control)TB_DaylightSavingTime_End).Name = "TB_DaylightSavingTime_End";
		((Control)TB_DaylightSavingTime_End).Size = new Size(47, 23);
		((Control)TB_DaylightSavingTime_End).TabIndex = 36;
		((ButtonBase)Button_CopyFromCurrent).BackColor = Color.Transparent;
		((Button)Button_CopyFromCurrent).DialogResult = (DialogResult)0;
		((Control)Button_CopyFromCurrent).Font = new Font("Segoe UI", 6.75f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_CopyFromCurrent).ForeColor = SystemColors.Control;
		((Control)Button_CopyFromCurrent).Location = new Point(166, 143);
		((Control)Button_CopyFromCurrent).Name = "Button_CopyFromCurrent";
		Button_CopyFromCurrent.RoundRadius = 0;
		((Control)Button_CopyFromCurrent).Size = new Size(151, 21);
		((Control)Button_CopyFromCurrent).TabIndex = 37;
		Button_CopyFromCurrent.Text = "Copy from current date + time";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(329, 378);
		((Control)this).Controls.Add((Control)(object)Button_CopyFromCurrent);
		((Control)this).Controls.Add((Control)(object)TB_DaylightSavingTime_End);
		((Control)this).Controls.Add((Control)(object)TB_DaylightSavingTime_Start);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)CB_DaylightSavingTime);
		((Control)this).Controls.Add((Control)(object)NUD_Difficulty);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)NUD_Complexity);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)DTP_CurrentTime);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)DTP_CurrentDate);
		((Control)this).Controls.Add((Control)(object)DTP_StartTime);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TB_Mins);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)TB_Hours);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)TB_Days);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)DTP_StartDate);
		base.FlatBorder = true;
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "TimesAndDuration";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Time - Duration - General Info";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void TimesAndDuration_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((MaskedTextBox)DTP_CurrentDate).Mask = "0000-00-00";
		((MaskedTextBox)DTP_CurrentTime).Mask = "00:00:00";
		DateTime theDate = Client.CurrentScenario.Time;
		string theTimeString = default(string);
		GameGeneral.PaddedTimeString(ref theDate, ref theTimeString);
		string theDateString = default(string);
		GameGeneral.PaddedDateString(ref theDate, ref theDateString, AddComma: false);
		((MaskedTextBox)DTP_CurrentDate).Text = theDateString;
		((MaskedTextBox)DTP_CurrentTime).Text = theTimeString;
		if (!Information.IsNothing((object)Client.CurrentScenario.DST_Start) && Operators.CompareString(Client.CurrentScenario.DST_Start, "", true) != 0)
		{
			TB_DaylightSavingTime_Start.Text = Client.CurrentScenario.DST_Start;
		}
		else
		{
			TB_DaylightSavingTime_Start.Text = "00.00";
		}
		if (!Information.IsNothing((object)Client.CurrentScenario.DST_End) && Operators.CompareString(Client.CurrentScenario.DST_End, "", true) != 0)
		{
			TB_DaylightSavingTime_End.Text = Client.CurrentScenario.DST_End;
		}
		else
		{
			TB_DaylightSavingTime_End.Text = "00.00";
		}
		((CheckBox)CB_DaylightSavingTime).Checked = Client.CurrentScenario.Use_DST;
		((Control)TB_DaylightSavingTime_Start).Enabled = ((CheckBox)CB_DaylightSavingTime).Checked;
		((Control)TB_DaylightSavingTime_End).Enabled = ((CheckBox)CB_DaylightSavingTime).Checked;
		((MaskedTextBox)DTP_StartDate).Mask = "0000-00-00";
		((MaskedTextBox)DTP_StartTime).Mask = "00:00:00";
		DateTime theDate2 = Client.CurrentScenario.StartTime;
		string theTimeString2 = default(string);
		GameGeneral.PaddedTimeString(ref theDate2, ref theTimeString2);
		string theDateString2 = default(string);
		GameGeneral.PaddedDateString(ref theDate2, ref theDateString2, AddComma: false);
		((MaskedTextBox)DTP_StartDate).Text = theDateString2;
		((MaskedTextBox)DTP_StartTime).Text = theTimeString2;
		TB_Days.Text = Conversions.ToString(Client.CurrentScenario.Duration.Days);
		TB_Hours.Text = Conversions.ToString(Client.CurrentScenario.Duration.Hours);
		TB_Mins.Text = Conversions.ToString(Client.CurrentScenario.Duration.Minutes);
		((NumericUpDown)NUD_Complexity).Value = new decimal((Client.CurrentScenario.Meta_Complexity == 0) ? 1 : Client.CurrentScenario.Meta_Complexity);
		((NumericUpDown)NUD_Difficulty).Value = new decimal((Client.CurrentScenario.Meta_Difficulty == 0) ? 1 : Client.CurrentScenario.Meta_Difficulty);
		TextBox1.Text = Client.CurrentScenario.Meta_ScenSetting;
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		if (Versioned.IsNumeric((object)TB_Days.Text) & Versioned.IsNumeric((object)TB_Hours.Text) & Versioned.IsNumeric((object)TB_Mins.Text))
		{
			DateTime dtOut = default(DateTime);
			try
			{
				Client.CurrentScenario.Use_DST = ((CheckBox)CB_DaylightSavingTime).Checked;
				if (Client.CurrentScenario.Use_DST && (!method_4(TB_DaylightSavingTime_Start.Text.Replace(",", ".")) || !method_4(TB_DaylightSavingTime_End.Text.Replace(",", "."))))
				{
					DarkMessageBox.ShowError("Please enter a valid Daylight Saving Time start and end date!", "Illegal values entered!");
					return;
				}
				int num = DateTimeHelper.ParseDateAndTime(((MaskedTextBox)DTP_CurrentDate).Text, ((MaskedTextBox)DTP_CurrentTime).Text, ref dtOut);
				if (num != 0)
				{
					DarkMessageBox.ShowError("Unable to set current scenario date & time: invalid value entered.", "Error in setting scenario current time");
					if (num == 1)
					{
						((Control)DTP_CurrentDate).Select();
					}
					else
					{
						((Control)DTP_CurrentTime).Select();
					}
					return;
				}
				Client.CurrentScenario.set_Time(ManualChange: true, dtOut);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				DarkMessageBox.ShowError("Unable to set current scenario date & time: " + ex2.Message, "Error in setting scenario current time");
				ProjectData.ClearProjectError();
				return;
			}
			try
			{
				Client.CurrentScenario.DST_Start = TB_DaylightSavingTime_Start.Text.Replace(",", ".");
				Client.CurrentScenario.DST_End = TB_DaylightSavingTime_End.Text.Replace(",", ".");
				int num = DateTimeHelper.ParseDateAndTime(((MaskedTextBox)DTP_StartDate).Text, ((MaskedTextBox)DTP_StartTime).Text, ref dtOut);
				if (num != 0)
				{
					DarkMessageBox.ShowError("Unable to set scenario start date & time: invalid value entered.", "Error in setting scenario start time");
					if (num == 1)
					{
						((Control)DTP_StartDate).Select();
					}
					else
					{
						((Control)DTP_StartTime).Select();
					}
					return;
				}
				Client.CurrentScenario.StartTime = dtOut;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				DarkMessageBox.ShowError("Unable to set scenario start date & time: " + ex4.Message, "Error in setting scenario start time");
				ProjectData.ClearProjectError();
				return;
			}
			try
			{
				Client.CurrentScenario.Duration = new TimeSpan(Conversions.ToInteger(TB_Days.Text) * 24, Conversions.ToInteger(TB_Hours.Text) * 60, Conversions.ToInteger(TB_Mins.Text) * 60);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				DarkMessageBox.ShowError("Unable to set scenario duration: " + ex6.Message, "Error in setting scenario duration");
				ProjectData.ClearProjectError();
				return;
			}
			Client.CurrentScenario.Meta_Complexity = Convert.ToInt16(((NumericUpDown)NUD_Complexity).Value);
			Client.CurrentScenario.Meta_Difficulty = Convert.ToInt16(((NumericUpDown)NUD_Difficulty).Value);
			Client.CurrentScenario.Meta_ScenSetting = TextBox1.Text;
			Client.CurrentScenario.Cache_TimeOfDay = new Weather.TTimeOfDayType[360][];
			MyProject.Forms.MainForm.RefreshCaption();
			((Form)this).Close();
		}
		else
		{
			DarkMessageBox.ShowError("Please check that the duration day/hour/minute values are all numeric.", "Non-numeric values entered!");
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private bool method_4(string string_0)
	{
		List<string> list = string_0.Split(Conversions.ToCharArrayRankOne(".")).ToList();
		if (!(Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1])))
		{
			return false;
		}
		if (!((Conversions.ToInteger(list[0]) <= 0) | (Conversions.ToInteger(list[0]) > 31)))
		{
			if (!((Conversions.ToInteger(list[1]) <= 0) | (Conversions.ToInteger(list[1]) > 12)))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private void TimesAndDuration_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		((Control)TB_DaylightSavingTime_Start).Enabled = ((CheckBox)CB_DaylightSavingTime).Checked;
		((Control)TB_DaylightSavingTime_End).Enabled = ((CheckBox)CB_DaylightSavingTime).Checked;
	}

	private void TimesAndDuration_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_6(object sender, EventArgs e)
	{
		((MaskedTextBox)DTP_StartDate).Text = ((MaskedTextBox)DTP_CurrentDate).Text;
		((MaskedTextBox)DTP_StartTime).Text = ((MaskedTextBox)DTP_CurrentTime).Text;
	}

	static TimesAndDuration()
	{
		Class72.smethod_20();
	}
}

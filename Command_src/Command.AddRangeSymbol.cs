using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddRangeSymbol : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton _Button3;

	[CompilerGenerated]
	[AccessedThroughProperty("ColorDialog1")]
	private ColorDialog colorDialog_0;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	internal virtual DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIComboBox darkUIComboBox = _ComboBox1;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_ComboBox1 = value;
			darkUIComboBox = _ComboBox1;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("TextBox2")]
	internal virtual DarkUITextBox TextBox2 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

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

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("TextBox3")]
	internal virtual DarkUITextBox TextBox3 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("TextBox4")]
	internal virtual DarkUITextBox TextBox4 { get; set; }

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

	internal virtual DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button3 = value;
			darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual ColorDialog ColorDialog1
	{
		[CompilerGenerated]
		get
		{
			return colorDialog_0;
		}
		[CompilerGenerated]
		set
		{
			colorDialog_0 = value;
		}
	}

	public AddRangeSymbol()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(AddRangeSymbol_FormClosing);
		((Form)this).Load += AddRangeSymbol_Load;
		((Control)this).KeyDown += new KeyEventHandler(AddRangeSymbol_KeyDown);
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

	private void InitializeComponent_1()
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Expected O, but got Unknown
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected O, but got Unknown
		//IL_09c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cb: Expected O, but got Unknown
		//IL_0ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adc: Expected O, but got Unknown
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b86: Expected O, but got Unknown
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		ComboBox1 = new DarkUIComboBox();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		TextBox2 = new DarkUITextBox();
		Label4 = new DarkLabel();
		Label5 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label6 = new DarkLabel();
		TextBox3 = new DarkUITextBox();
		Label7 = new DarkLabel();
		Label8 = new DarkLabel();
		TextBox4 = new DarkUITextBox();
		Button2 = new DarkUIButton();
		Button3 = new DarkUIButton();
		ColorDialog1 = new ColorDialog();
		((Control)this).SuspendLayout();
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(12, 9);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(60, 13);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Description";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(86, 6);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(191, 24);
		((Control)TextBox1).TabIndex = 1;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		((ComboBox)ComboBox1).BackColor = Color.Transparent;
		((ComboBox)ComboBox1).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox1).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox1).Font = new Font("Segoe UI", 7f);
		((ListControl)ComboBox1).FormattingEnabled = true;
		((ComboBox)ComboBox1).Items.AddRange(new object[1] { "Circle" });
		((Control)ComboBox1).Location = new Point(86, 33);
		((Control)ComboBox1).Name = "ComboBox1";
		((Control)ComboBox1).Size = new Size(190, 21);
		((Control)ComboBox1).TabIndex = 2;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(12, 36);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 13);
		((Control)Label2).TabIndex = 3;
		((Label)Label2).Text = "Symbol Type";
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(12, 91);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(62, 13);
		((Control)Label3).TabIndex = 4;
		((Label)Label3).Text = "Range (nm)";
		TextBox2.AutoCompleteCustomSource = null;
		TextBox2.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox2.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox2).BackColor = Color.Transparent;
		TextBox2.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TextBox2).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox2.Image = null;
		TextBox2.Lines = null;
		((Control)TextBox2).Location = new Point(86, 88);
		TextBox2.MaxLength = 32767;
		TextBox2.Multiline = false;
		((Control)TextBox2).Name = "TextBox2";
		TextBox2.ReadOnly = false;
		TextBox2.SelectionStart = 0;
		((Control)TextBox2).Size = new Size(100, 24);
		((Control)TextBox2).TabIndex = 5;
		TextBox2.TextAlign = (HorizontalAlignment)0;
		TextBox2.UseSystemPasswordChar = false;
		TextBox2.WatermarkText = "";
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(12, 119);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(31, 13);
		((Control)Label4).TabIndex = 6;
		((Label)Label4).Text = "Color";
		((Control)Label5).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(83, 119);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(45, 13);
		((Control)Label5).TabIndex = 7;
		((Label)Label5).Text = "Label5";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(201, 114);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 8;
		Button1.Text = "Change...";
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(12, 62);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(28, 13);
		((Control)Label6).TabIndex = 9;
		((Label)Label6).Text = "Arcs";
		TextBox3.AutoCompleteCustomSource = null;
		TextBox3.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox3.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox3).BackColor = Color.Transparent;
		TextBox3.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TextBox3).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox3.Image = null;
		TextBox3.Lines = null;
		((Control)TextBox3).Location = new Point(134, 59);
		TextBox3.MaxLength = 32767;
		TextBox3.Multiline = false;
		((Control)TextBox3).Name = "TextBox3";
		TextBox3.ReadOnly = false;
		TextBox3.SelectionStart = 0;
		((Control)TextBox3).Size = new Size(42, 24);
		((Control)TextBox3).TabIndex = 10;
		TextBox3.TextAlign = (HorizontalAlignment)0;
		TextBox3.UseSystemPasswordChar = false;
		TextBox3.WatermarkText = "";
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(83, 62);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(48, 13);
		((Control)Label7).TabIndex = 11;
		((Label)Label7).Text = "LeftMost";
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(181, 64);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(55, 13);
		((Control)Label8).TabIndex = 12;
		((Label)Label8).Text = "RightMost";
		TextBox4.AutoCompleteCustomSource = null;
		TextBox4.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox4.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox4).BackColor = Color.Transparent;
		TextBox4.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TextBox4).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox4.Image = null;
		TextBox4.Lines = null;
		((Control)TextBox4).Location = new Point(235, 59);
		TextBox4.MaxLength = 32767;
		TextBox4.Multiline = false;
		((Control)TextBox4).Name = "TextBox4";
		TextBox4.ReadOnly = false;
		TextBox4.SelectionStart = 0;
		((Control)TextBox4).Size = new Size(42, 24);
		((Control)TextBox4).TabIndex = 13;
		TextBox4.TextAlign = (HorizontalAlignment)0;
		TextBox4.UseSystemPasswordChar = false;
		TextBox4.WatermarkText = "";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(15, 157);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 14;
		Button2.Text = "Add";
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Button)Button3).DialogResult = (DialogResult)0;
		((Control)Button3).Font = new Font("Segoe UI", 10f);
		((Control)Button3).ForeColor = SystemColors.Control;
		((Control)Button3).Location = new Point(201, 157);
		((Control)Button3).Name = "Button3";
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(75, 23);
		((Control)Button3).TabIndex = 15;
		Button3.Text = "Cancel";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(284, 196);
		((Control)this).Controls.Add((Control)(object)Button3);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)TextBox4);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)TextBox3);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)TextBox2);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)ComboBox1);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddRangeSymbol";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)4;
		((Form)this).Text = "Add Range Symbol";
		((Control)this).ResumeLayout(false);
	}

	private void AddRangeSymbol_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void AddRangeSymbol_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Control)Label5).ForeColor = Color.White;
		((Label)Label5).Text = ((Control)Label5).ForeColor.ToString();
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)ColorDialog1).ShowDialog() == 1)
		{
			((Label)Label5).Text = ColorDialog1.Color.ToString();
			((Control)Label5).ForeColor = ColorDialog1.Color;
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		RangeSymbol item = null;
		switch (((ComboBox)ComboBox1).SelectedIndex)
		{
		case 0:
			item = new RangeSymbol(RangeSymbol.SymbolType.Circle, TextBox1.Text, Conversions.ToDouble(TextBox2.Text), ((Control)Label5).ForeColor);
			break;
		case 1:
			item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, TextBox1.Text, Conversions.ToDouble(TextBox2.Text), Conversions.ToSingle(TextBox3.Text), Conversions.ToSingle(TextBox4.Text), ((Control)Label5).ForeColor);
			break;
		}
		Client.SelectedUnit.RangeSymbols.Add(item);
		Client.MustRefreshMainForm = true;
		Client.MustRefreshMainForm = true;
		((Form)this).Close();
	}

	private void method_4(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void AddRangeSymbol_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		((Control)TextBox3).Enabled = ((ComboBox)ComboBox1).SelectedIndex == 1;
		((Control)TextBox4).Enabled = ((Control)TextBox3).Enabled;
	}

	static AddRangeSymbol()
	{
		Class72.smethod_20();
	}
}

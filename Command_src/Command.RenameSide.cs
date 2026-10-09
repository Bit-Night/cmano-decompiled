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
public sealed class RenameSide : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox _TextBox1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	private bool bool_2;

	public Side SelectedSide;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _TextBox1;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_3;
			EventHandler eventHandler = method_5;
			EventHandler eventHandler2 = method_6;
			DarkUITextBox darkUITextBox = _TextBox1;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox1 = value;
			darkUITextBox = _TextBox1;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
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
			EventHandler eventHandler = method_4;
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

	public RenameSide()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Load += RenameSide_Load;
		((Control)this).KeyDown += new KeyEventHandler(RenameSide_KeyDown);
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
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		((Control)this).SuspendLayout();
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(13, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(61, 13);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "New name:";
		((Control)TextBox1).Anchor = (AnchorStyles)13;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(16, 30);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(298, 24);
		((Control)TextBox1).TabIndex = 1;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button1).Location = new Point(16, 66);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 2;
		Button1.Text = "OK";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button2).Location = new Point(239, 66);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 3;
		Button2.Text = "Cancel";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(326, 95);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "RenameSide";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Rename Side";
		((Control)this).ResumeLayout(false);
	}

	private void method_2(object sender, EventArgs e)
	{
		SelectedSide.Name = TextBox1.Text;
		if (((Control)MyProject.Forms.Sides).Visible)
		{
			MyProject.Forms.Sides.RefreshForm();
		}
		((Form)this).Close();
	}

	private void method_3(object object_0)
	{
		Button1.Enabled = Operators.CompareString(TextBox1.Text, "", true) != 0;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			if (string.Compare(sides_ReadOnly[i].Name, TextBox1.Text, ignoreCase: false) == 0)
			{
				Button1.Enabled = false;
			}
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RenameSide_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		TextBox1.Text = SelectedSide.Name;
	}

	private void RenameSide_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Invalid comparison between Unknown and I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (bool_2)
		{
			if (e.KeyValue == 13 && ((Control)this).Visible)
			{
				((Control)Label1).Select();
				return;
			}
			if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!bool_2 && (e.KeyValue != 32 || !((Control)this).Visible))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		bool_2 = true;
	}

	private void method_6(object sender, EventArgs e)
	{
		bool_2 = false;
		((Control)Label1).Select();
	}

	static RenameSide()
	{
		Class72.smethod_20();
	}
}

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
public sealed class ChanceOfAppearance : DarkSecondaryFormBase
{
	private IContainer VhoHsGiupFH;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("ChanceOfAppearance_TrackBar")]
	private TrackBar _ChanceOfAppearance_TrackBar;

	[CompilerGenerated]
	[AccessedThroughProperty("ChanceOfAppearance_TextBox")]
	private DarkUITextBox _ChanceOfAppearance_TextBox;

	public string SelectedUnitID;

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
			EventHandler eventHandler = method_2;
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
			EventHandler eventHandler = method_3;
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

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual TrackBar ChanceOfAppearance_TrackBar
	{
		[CompilerGenerated]
		get
		{
			return _ChanceOfAppearance_TrackBar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			TrackBar val = _ChanceOfAppearance_TrackBar;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_ChanceOfAppearance_TrackBar = value;
			val = _ChanceOfAppearance_TrackBar;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox ChanceOfAppearance_TextBox
	{
		[CompilerGenerated]
		get
		{
			return _ChanceOfAppearance_TextBox;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_5;
			DarkUITextBox darkUITextBox = _ChanceOfAppearance_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_ChanceOfAppearance_TextBox = value;
			darkUITextBox = _ChanceOfAppearance_TextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	public ChanceOfAppearance()
	{
		((Form)this).Shown += ChanceOfAppearance_Shown;
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && VhoHsGiupFH != null)
			{
				VhoHsGiupFH.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Label1 = new DarkLabel();
		ChanceOfAppearance_TrackBar = new TrackBar();
		ChanceOfAppearance_TextBox = new DarkUITextBox();
		((ISupportInitialize)ChanceOfAppearance_TrackBar).BeginInit();
		((Control)this).SuspendLayout();
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)2;
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(274, 89);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 5;
		Button2.Text = "Cancel";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(8, 89);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 4;
		Button1.Text = "OK";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(5, 6);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(344, 15);
		((Control)Label1).TabIndex = 7;
		((Label)Label1).Text = "Set probability (%) that the unit will be present on scenario load:";
		((Control)ChanceOfAppearance_TrackBar).Location = new Point(8, 38);
		ChanceOfAppearance_TrackBar.Maximum = 100;
		((Control)ChanceOfAppearance_TrackBar).Name = "ChanceOfAppearance_TrackBar";
		((Control)ChanceOfAppearance_TrackBar).Size = new Size(341, 45);
		((Control)ChanceOfAppearance_TrackBar).TabIndex = 8;
		ChanceOfAppearance_TrackBar.TickFrequency = 5;
		ChanceOfAppearance_TextBox.AutoCompleteCustomSource = null;
		ChanceOfAppearance_TextBox.AutoCompleteMode = (AutoCompleteMode)0;
		ChanceOfAppearance_TextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)ChanceOfAppearance_TextBox).BackColor = Color.Transparent;
		((Control)ChanceOfAppearance_TextBox).ForeColor = Color.FromArgb(189, 189, 189);
		ChanceOfAppearance_TextBox.Image = null;
		ChanceOfAppearance_TextBox.Lines = null;
		((Control)ChanceOfAppearance_TextBox).Location = new Point(164, 74);
		ChanceOfAppearance_TextBox.MaxLength = 2;
		ChanceOfAppearance_TextBox.Multiline = false;
		((Control)ChanceOfAppearance_TextBox).Name = "ChanceOfAppearance_TextBox";
		ChanceOfAppearance_TextBox.ReadOnly = false;
		ChanceOfAppearance_TextBox.ScrollBars = (ScrollBars)0;
		ChanceOfAppearance_TextBox.SelectionStart = 0;
		((Control)ChanceOfAppearance_TextBox).Size = new Size(35, 24);
		((Control)ChanceOfAppearance_TextBox).TabIndex = 9;
		ChanceOfAppearance_TextBox.Text = "0";
		ChanceOfAppearance_TextBox.TextAlign = (HorizontalAlignment)2;
		ChanceOfAppearance_TextBox.UseSystemPasswordChar = false;
		ChanceOfAppearance_TextBox.WatermarkText = "";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(358, 122);
		((Control)this).Controls.Add((Control)(object)ChanceOfAppearance_TextBox);
		((Control)this).Controls.Add((Control)(object)ChanceOfAppearance_TrackBar);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ChanceOfAppearance";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Chance Of Appearance";
		((ISupportInitialize)ChanceOfAppearance_TrackBar).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void ChanceOfAppearance_Shown(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(SelectedUnitID))
		{
			ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[SelectedUnitID];
			ChanceOfAppearance_TextBox.Text = Conversions.ToString(activeUnit.ChanceOfAppearance);
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		try
		{
			if (!int.TryParse(ChanceOfAppearance_TextBox.Text, out var result))
			{
				if ((int)DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == 1)
				{
					ChanceOfAppearance_TextBox.Text = "0";
					return;
				}
			}
			else
			{
				result = Conversions.ToInteger(ChanceOfAppearance_TextBox.Text);
				if (result == 0 && (int)DarkMessageBox.ShowWarning("Setting the chance of appearance to 0% will cause the unit to always appear, is this what you want?", "Warning") == 7)
				{
					return;
				}
			}
			Client.CurrentScenario.ActiveUnits[SelectedUnitID].ChanceOfAppearance = result;
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

	private void method_4(object sender, EventArgs e)
	{
		ChanceOfAppearance_TextBox.Text = Conversions.ToString(ChanceOfAppearance_TrackBar.Value);
	}

	private void method_5(object object_0)
	{
		if (int.TryParse(ChanceOfAppearance_TextBox.Text, out var result))
		{
			if (result > 100)
			{
				result = 100;
			}
			if (result < 0)
			{
				result = 0;
			}
			ChanceOfAppearance_TrackBar.Value = result;
		}
	}

	static ChanceOfAppearance()
	{
		Class72.smethod_20();
	}
}

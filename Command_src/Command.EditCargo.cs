using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditCargo : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	internal EditCargoControl EditCargoControl1;

	public ActiveUnit SelectedHost;

	private Keys[] keys_0;

	[field: AccessedThroughProperty("ElementHost1")]
	internal virtual ElementHost ElementHost1 { get; set; }

	public EditCargo()
	{
		((Form)this).Load += EditCargo_Load;
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		ElementHost1 = new ElementHost();
		EditCargoControl1 = new EditCargoControl();
		((Control)this).SuspendLayout();
		((Control)ElementHost1).Dock = (DockStyle)5;
		((Control)ElementHost1).Location = new Point(0, 0);
		((Control)ElementHost1).Name = "ElementHost1";
		((Control)ElementHost1).Size = new Size(746, 328);
		((Control)ElementHost1).TabIndex = 0;
		((Control)ElementHost1).Text = "ElementHost1";
		ElementHost1.Child = (UIElement)(object)EditCargoControl1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(746, 328);
		((Control)this).Controls.Add((Control)(object)ElementHost1);
		((Control)this).Name = "EditCargo";
		((Form)this).Text = "EditCargo";
		((Control)this).ResumeLayout(false);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		foreach (Keys val in array)
		{
			if (keyData == val)
			{
				int result;
				if (((Control)this).Visible)
				{
					((Form)this).Close();
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	private void EditCargo_Load(object sender, EventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (SelectedHost is Group)
		{
			DarkMessageBox.ShowError("Please choose an individual unit, not a group.", "Error");
			((Form)this).Close();
		}
		else
		{
			((FrameworkElement)(EditCargoControl)(object)ElementHost1.Child).DataContext = new EditCargoViewModel(this, (EditCargoControl)(object)ElementHost1.Child, SelectedHost);
		}
	}

	static EditCargo()
	{
		Class72.smethod_20();
	}
}

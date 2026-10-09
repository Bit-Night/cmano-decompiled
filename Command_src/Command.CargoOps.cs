using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class CargoOps : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	internal CargoOpsControl CargoOpsControl1;

	public ActiveUnit SelectedHost;

	public ActiveUnit SelectedTarget;

	[field: AccessedThroughProperty("ElementHost1")]
	internal virtual ElementHost ElementHost1 { get; set; }

	public CargoOps()
	{
		((Form)this).Load += CargoOps_Load;
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
		CargoOpsControl1 = new CargoOpsControl();
		((Control)this).SuspendLayout();
		((Control)ElementHost1).Dock = (DockStyle)5;
		((Control)ElementHost1).Location = new Point(0, 0);
		((Control)ElementHost1).Name = "ElementHost1";
		((Control)ElementHost1).Size = new Size(784, 261);
		((Control)ElementHost1).TabIndex = 0;
		((Control)ElementHost1).Text = "ElementHost1";
		ElementHost1.Child = (UIElement)(object)CargoOpsControl1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(784, 261);
		((Control)this).Controls.Add((Control)(object)ElementHost1);
		((Control)this).Name = "CargoOps";
		((Form)this).Text = "CargoDialog";
		((Control)this).ResumeLayout(false);
	}

	private void CargoOps_Load(object sender, EventArgs e)
	{
		((FrameworkElement)(CargoOpsControl)(object)ElementHost1.Child).DataContext = new CargoOpsViewModel(this, SelectedHost, SelectedTarget);
	}

	static CargoOps()
	{
		Class72.smethod_20();
	}
}

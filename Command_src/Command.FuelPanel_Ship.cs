using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanel_Ship : DarkUserControl
{
	private IContainer icontainer_1;

	private int ActualWidth;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("ProgressBar1")]
	internal virtual DarkUIProgressBar ProgressBar1 { get; set; }

	public FuelPanel_Ship()
	{
		((UserControl)this).Load += FuelPanel_Ship_Load;
		InitializeComponent();
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

	private void InitializeComponent()
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		Label1 = new DarkLabel();
		ProgressBar1 = new DarkUIProgressBar();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).Location = new Point(3, 26);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(39, 13);
		((Control)Label1).TabIndex = 4;
		((Label)Label1).Text = "Label1";
		((Control)ProgressBar1).Location = new Point(0, 0);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(231, 23);
		((Control)ProgressBar1).TabIndex = 3;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Margin = new Padding(0);
		((Control)this).Name = "FuelPanel_Ship";
		((Control)this).Size = new Size(232, 85);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void RefreshPanel(ActiveUnit theUnit)
	{
		if (Client.DPI_scale != 1f)
		{
			if (ActualWidth == 0)
			{
				ActualWidth = ((Control)this).Width;
			}
			if (ActualWidth == ((Control)this).Width)
			{
				((Control)this).Width = (int)Math.Round((float)((Control)this).Width * Client.DPI_scale);
			}
		}
		double TotalCurrent = default(double);
		double TotalMax = default(double);
		ProgressBar1.Value = (int)Math.Round(theUnit.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) * 100.0);
		long num = ((Ship)theUnit).get_FuelEndurance(theUnit.ThrottleSetting, (AltBand)null, (float?)(int)Math.Round(theUnit.DesiredSpeed), (float?)0f);
		HashSet<string> hashSet = new HashSet<string>();
		string text = "";
		foreach (FuelRec item in theUnit.Fuel_ReadOnly)
		{
			hashSet.Add(item.FuelType.ToString());
		}
		if (hashSet.Count > 0)
		{
			text = " (" + string.Join(", ", hashSet.ToArray()) + ")";
			if (hashSet.Count > 1)
			{
				text = "\r\n" + text;
			}
		}
		string text2 = string.Format("{0:0.0}", TotalCurrent, 0) + " fuel units remaining";
		if (!string.IsNullOrEmpty(text))
		{
			text2 += text;
		}
		string text3 = ((theUnit.ThrottleSetting == ActiveUnit.Throttle.FullStop) ? "Unit is at full stop" : (Misc.TimeString(num, 0, ReturnNo: false, ReturnZero: true) + ", " + string.Format("{0:0.0}", (float)num * theUnit.CurrentSpeed / 3600f, 0) + " nm"));
		((Label)Label1).Text = text2 + "\r\n" + text3;
	}

	private void FuelPanel_Ship_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static FuelPanel_Ship()
	{
		Class72.smethod_20();
	}
}

using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class Export_ImportFeedback : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[field: AccessedThroughProperty("LV_Main")]
	internal virtual DarkListView LV_Main { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	public Export_ImportFeedback()
	{
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
		LV_Main = new DarkListView();
		DarkLabel1 = new DarkLabel();
		((Control)this).SuspendLayout();
		((Control)LV_Main).Anchor = (AnchorStyles)15;
		((Control)LV_Main).BackColor = Color.FromArgb(50, 53, 55);
		((Control)LV_Main).Location = new Point(12, 40);
		((Control)LV_Main).Name = "LV_Main";
		LV_Main.RelatedInfos = null;
		((Control)LV_Main).Size = new Size(776, 398);
		((Control)LV_Main).TabIndex = 0;
		((Control)LV_Main).Text = "DarkListView1";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(13, 13);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(259, 13);
		((Control)DarkLabel1).TabIndex = 1;
		((Label)DarkLabel1).Text = "Your import attempt contains either warnings or errors.";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(800, 450);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)LV_Main);
		((Control)this).Name = "Export_ImportFeedback";
		((Form)this).Text = "Log";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static Export_ImportFeedback()
	{
		Class72.smethod_20();
	}
}

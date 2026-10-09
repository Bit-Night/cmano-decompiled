using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class WEGOMultiplayerTimings : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	[field: AccessedThroughProperty("Chart1")]
	internal virtual Chart Chart1 { get; set; }

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			timer_0 = value;
		}
	}

	public WEGOMultiplayerTimings()
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
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		icontainer_0 = new Container();
		ChartArea val = new ChartArea();
		Legend val2 = new Legend();
		Chart1 = new Chart();
		Timer1 = new Timer(icontainer_0);
		((ISupportInitialize)Chart1).BeginInit();
		((Control)this).SuspendLayout();
		val.Name = "ChartArea1";
		((Collection<ChartArea>)(object)Chart1.ChartAreas).Add(val);
		((Control)Chart1).Dock = (DockStyle)5;
		val2.Name = "Legend1";
		((Collection<Legend>)(object)Chart1.Legends).Add(val2);
		((Control)Chart1).Location = new Point(0, 0);
		((Control)Chart1).Name = "Chart1";
		Chart1.Size = new Size(213, 99);
		((Control)Chart1).TabIndex = 0;
		((Control)Chart1).Text = "Chart1";
		Timer1.Enabled = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(213, 99);
		((Control)this).Controls.Add((Control)(object)Chart1);
		((Control)this).Name = "WEGOMultiplayerTimings";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "WEGOMultiplayerTimings";
		((ISupportInitialize)Chart1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	static WEGOMultiplayerTimings()
	{
		Class72.smethod_20();
	}
}

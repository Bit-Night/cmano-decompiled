using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SatelliteCustomOrbit : CommandSecondaryFormBase
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private TextBox textBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private Button button_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private Button button_1;

	public string SatelliteObjectID;

	internal virtual TextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return textBox_0;
		}
		[CompilerGenerated]
		set
		{
			textBox_0 = value;
		}
	}

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return button_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			Button val = button_0;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			button_0 = value;
			val = button_0;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button Button2
	{
		[CompilerGenerated]
		get
		{
			return button_1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			Button val = button_1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			button_1 = value;
			val = button_1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public SatelliteCustomOrbit()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(SatelliteCustomOrbit_FormClosing);
		((Form)this).Load += SatelliteCustomOrbit_Load;
		((Control)this).KeyDown += new KeyEventHandler(SatelliteCustomOrbit_KeyDown);
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
		((Control)this).SuspendLayout();
		((Form)this).ClientSize = new Size(428, 352);
		((Control)this).Name = "SatelliteCustomOrbit";
		((Control)this).ResumeLayout(false);
	}

	private void SatelliteCustomOrbit_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		Client.MustRefreshMainForm = true;
		Client.MustRefreshMainForm = true;
		if (!Information.IsNothing((object)MyProject.Forms.AirOps) && ((Control)MyProject.Forms.AirOps).Visible)
		{
			MyProject.Forms.AirOps.RefreshForm();
		}
		((Control)MyProject.Forms.MainForm).BringToFront();
		if (((Control)MyProject.Forms.ScenAttachmentsWindow).Visible)
		{
			MyProject.Forms.ScenAttachmentsWindow.RefreshForm();
		}
	}

	private void SatelliteCustomOrbit_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Control)MyProject.Forms.MainForm).Enabled = false;
	}

	private void method_2(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void SatelliteCustomOrbit_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void method_4(object sender, EventArgs e)
	{
	}

	static SatelliteCustomOrbit()
	{
		Class72.smethod_20();
	}
}

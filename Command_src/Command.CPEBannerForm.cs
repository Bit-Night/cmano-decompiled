using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class CPEBannerForm : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private Button _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("CB_DontShow")]
	[CompilerGenerated]
	private CheckBox _CB_DontShow;

	[field: AccessedThroughProperty("PictureBox1")]
	internal virtual PictureBox PictureBox1 { get; set; }

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			Button val = _Button1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Button1 = value;
			val = _Button1;
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
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			Button val = _Button2;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Button2 = value;
			val = _Button2;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox CB_DontShow
	{
		[CompilerGenerated]
		get
		{
			return _CB_DontShow;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			CheckBox val = _CB_DontShow;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_CB_DontShow = value;
			val = _CB_DontShow;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	public CPEBannerForm()
	{
		((Form)this).Load += CPEBannerForm_Load;
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CPEBannerForm));
		PictureBox1 = new PictureBox();
		Button1 = new Button();
		Button2 = new Button();
		CB_DontShow = new CheckBox();
		((ISupportInitialize)PictureBox1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PictureBox1).Dock = (DockStyle)5;
		PictureBox1.Image = (Image)componentResourceManager.GetObject("PictureBox1.Image");
		((Control)PictureBox1).Location = new Point(0, 0);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(1008, 537);
		PictureBox1.SizeMode = (PictureBoxSizeMode)1;
		PictureBox1.TabIndex = 0;
		PictureBox1.TabStop = false;
		((ButtonBase)Button1).FlatStyle = (FlatStyle)0;
		((ButtonBase)Button1).Image = (Image)componentResourceManager.GetObject("Button1.Image");
		((Control)Button1).Location = new Point(290, 400);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Size = new Size(189, 45);
		((Control)Button1).TabIndex = 1;
		((ButtonBase)Button1).UseVisualStyleBackColor = true;
		((ButtonBase)Button2).FlatStyle = (FlatStyle)0;
		((ButtonBase)Button2).Image = (Image)componentResourceManager.GetObject("Button2.Image");
		((Control)Button2).Location = new Point(560, 400);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Size = new Size(160, 45);
		((Control)Button2).TabIndex = 2;
		((ButtonBase)Button2).UseVisualStyleBackColor = true;
		((ButtonBase)CB_DontShow).AutoSize = true;
		((ButtonBase)CB_DontShow).BackColor = Color.FromArgb(8, 25, 48);
		((ButtonBase)CB_DontShow).FlatStyle = (FlatStyle)0;
		((Control)CB_DontShow).Font = new Font("Segoe UI", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)CB_DontShow).ForeColor = Color.White;
		((Control)CB_DontShow).Location = new Point(428, 502);
		((Control)CB_DontShow).Name = "CB_DontShow";
		((Control)CB_DontShow).Size = new Size(172, 23);
		((Control)CB_DontShow).TabIndex = 3;
		((ButtonBase)CB_DontShow).Text = "Do not show on startup";
		((ButtonBase)CB_DontShow).UseVisualStyleBackColor = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1008, 537);
		((Control)this).Controls.Add((Control)(object)CB_DontShow);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).DoubleBuffered = true;
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Margin = new Padding(2);
		((Control)this).Name = "CPEBannerForm";
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "CPEBannerForm";
		((Form)this).TopMost = true;
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void CPEBannerForm_Load(object sender, EventArgs e)
	{
	}

	private void method_0(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_1(object sender, EventArgs e)
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = "https://www.matrixprosims.com/game/command-professional-edition",
			UseShellExecute = true
		});
		Environment.Exit(0);
	}

	private void method_2(object sender, EventArgs e)
	{
		SimConfiguration.DefaultGamePreferences.ShowProbanner = !CB_DontShow.Checked;
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
	}

	static CPEBannerForm()
	{
		Class72.smethod_20();
	}
}

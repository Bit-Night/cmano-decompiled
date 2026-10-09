using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class StartGame : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton _Button3;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton nepScsjIyRe;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button4")]
	private DarkUIButton _Button4;

	[AccessedThroughProperty("Button5")]
	[CompilerGenerated]
	private DarkUIButton _Button5;

	[CompilerGenerated]
	[AccessedThroughProperty("Button6")]
	private DarkUIButton _Button6;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Campaign")]
	private DarkUIButton _Button_Campaign;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_QuickBattle")]
	private DarkUIButton _Button_QuickBattle;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual DarkGroupBox GroupBox2 { get; set; }

	[field: AccessedThroughProperty("PictureBox1")]
	internal virtual PictureBox PictureBox1 { get; set; }

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
			EventHandler eventHandler = method_3;
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

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return nepScsjIyRe;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = nepScsjIyRe;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			nepScsjIyRe = value;
			darkUIButton = nepScsjIyRe;
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

	internal virtual DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return _Button4;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button4;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button4 = value;
			darkUIButton = _Button4;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button5
	{
		[CompilerGenerated]
		get
		{
			return _Button5;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIButton darkUIButton = _Button5;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button5 = value;
			darkUIButton = _Button5;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button6
	{
		[CompilerGenerated]
		get
		{
			return _Button6;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button6;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button6 = value;
			darkUIButton = _Button6;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Campaign
	{
		[CompilerGenerated]
		get
		{
			return _Button_Campaign;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _Button_Campaign;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Campaign = value;
			darkUIButton = _Button_Campaign;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_QuickBattle
	{
		[CompilerGenerated]
		get
		{
			return _Button_QuickBattle;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _Button_QuickBattle;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_QuickBattle = value;
			darkUIButton = _Button_QuickBattle;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
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
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected O, but got Unknown
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Expected O, but got Unknown
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Expected O, but got Unknown
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Expected O, but got Unknown
		//IL_0786: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(StartGame));
		GroupBox1 = new DarkGroupBox();
		Button_QuickBattle = new DarkUIButton();
		Button_Campaign = new DarkUIButton();
		Button6 = new DarkUIButton();
		Button4 = new DarkUIButton();
		Button3 = new DarkUIButton();
		GroupBox2 = new DarkGroupBox();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Button5 = new DarkUIButton();
		PictureBox1 = new PictureBox();
		((Control)GroupBox1).SuspendLayout();
		((Control)GroupBox2).SuspendLayout();
		((ISupportInitialize)PictureBox1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)GroupBox1).Controls.Add((Control)(object)Button_QuickBattle);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_Campaign);
		((Control)GroupBox1).Controls.Add((Control)(object)Button6);
		((Control)GroupBox1).Controls.Add((Control)(object)Button4);
		((Control)GroupBox1).Controls.Add((Control)(object)Button3);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(491, 3);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(211, 160);
		((Control)GroupBox1).TabIndex = 0;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Play game";
		((ButtonBase)Button_QuickBattle).BackColor = Color.Transparent;
		((Button)Button_QuickBattle).DialogResult = (DialogResult)0;
		((Control)Button_QuickBattle).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button_QuickBattle).Location = new Point(5, 15);
		((Control)Button_QuickBattle).Name = "Button_QuickBattle";
		Button_QuickBattle.RoundRadius = 0;
		((Control)Button_QuickBattle).Size = new Size(200, 23);
		((Control)Button_QuickBattle).TabIndex = 6;
		Button_QuickBattle.Text = "Quick Battle";
		((ButtonBase)Button_Campaign).BackColor = Color.Transparent;
		((Button)Button_Campaign).DialogResult = (DialogResult)0;
		((Control)Button_Campaign).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button_Campaign).Location = new Point(5, 43);
		((Control)Button_Campaign).Name = "Button_Campaign";
		((Control)Button_Campaign).Padding = new Padding(5);
		Button_Campaign.RoundRadius = 0;
		((Control)Button_Campaign).Size = new Size(200, 23);
		((Control)Button_Campaign).TabIndex = 5;
		Button_Campaign.Text = "Campaign";
		((ButtonBase)Button6).BackColor = Color.Transparent;
		((Button)Button6).DialogResult = (DialogResult)0;
		((Control)Button6).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button6).Location = new Point(5, 128);
		((Control)Button6).Name = "Button6";
		((Control)Button6).Padding = new Padding(5);
		Button6.RoundRadius = 0;
		((Control)Button6).Size = new Size(200, 25);
		((Control)Button6).TabIndex = 4;
		Button6.Text = "Resume from last autosave";
		((ButtonBase)Button4).BackColor = Color.Transparent;
		((Button)Button4).DialogResult = (DialogResult)0;
		((Control)Button4).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button4).Location = new Point(5, 98);
		((Control)Button4).Name = "Button4";
		((Control)Button4).Padding = new Padding(5);
		Button4.RoundRadius = 0;
		((Control)Button4).Size = new Size(200, 25);
		((Control)Button4).TabIndex = 3;
		Button4.Text = "Load a saved game";
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Button)Button3).DialogResult = (DialogResult)0;
		((Control)Button3).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button3).Location = new Point(5, 71);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(200, 23);
		((Control)Button3).TabIndex = 2;
		Button3.Text = "Start new scenario";
		((Control)GroupBox2).Controls.Add((Control)(object)Button2);
		((Control)GroupBox2).Controls.Add((Control)(object)Button1);
		((Control)GroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox2).Location = new Point(491, 169);
		((Control)GroupBox2).Name = "GroupBox2";
		((Control)GroupBox2).Size = new Size(211, 81);
		((Control)GroupBox2).TabIndex = 1;
		((GroupBox)GroupBox2).TabStop = false;
		((GroupBox)GroupBox2).Text = "Scenario Editor";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button2).Location = new Point(5, 50);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(200, 25);
		((Control)Button2).TabIndex = 2;
		Button2.Text = "Load existing scenario";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button1).Location = new Point(5, 20);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(200, 25);
		((Control)Button1).TabIndex = 0;
		Button1.Text = "Create new blank scenario";
		((Control)Button5).Anchor = (AnchorStyles)10;
		((ButtonBase)Button5).BackColor = Color.Transparent;
		((Button)Button5).DialogResult = (DialogResult)0;
		((Control)Button5).Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		((Control)Button5).Location = new Point(613, 263);
		((Control)Button5).Name = "Button5";
		((Control)Button5).Padding = new Padding(5);
		Button5.RoundRadius = 0;
		((Control)Button5).Size = new Size(89, 33);
		((Control)Button5).TabIndex = 2;
		Button5.Text = "EXIT GAME";
		((Control)PictureBox1).Anchor = (AnchorStyles)15;
		PictureBox1.Image = (Image)componentResourceManager.GetObject("PictureBox1.Image");
		((Control)PictureBox1).Location = new Point(3, 4);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(483, 292);
		PictureBox1.TabIndex = 3;
		PictureBox1.TabStop = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(704, 299);
		((Control)this).Controls.Add((Control)(object)GroupBox2);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)Button5);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "StartGame";
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Start menu";
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox2).ResumeLayout(false);
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public StartGame()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosed += new FormClosedEventHandler(StartGame_FormClosed);
		((Form)this).Load += StartGame_Load;
		((Control)this).KeyDown += new KeyEventHandler(StartGame_KeyDown);
		((Form)this).Shown += StartGame_Shown;
		InitializeComponent_1();
		ApplyStoredPositionSettings = false;
		ApplyStoredSizeSettings = false;
	}

	private void method_2(object sender, EventArgs e)
	{
		if (Licensing.get_ModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
		{
			Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
			Client.CreateNewScenario();
			((Form)this).Close();
		}
		else
		{
			MyProject.Forms.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleLicense.CommandFullVersion };
			((Control)MyProject.Forms.InsufficientLicenseWindow).Show();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		MyProject.Forms.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
		((Control)MyProject.Forms.LoadScenario).Show();
	}

	private void method_4(object sender, EventArgs e)
	{
		Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		MyProject.Forms.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadSavedGame;
		((Control)MyProject.Forms.LoadScenario).Show();
	}

	private void method_5(object sender, EventArgs e)
	{
		if (Licensing.get_ModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
		{
			Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
			MyProject.Forms.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
			((Control)MyProject.Forms.LoadScenario).Show();
		}
		else
		{
			MyProject.Forms.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleLicense.CommandFullVersion };
			((Control)MyProject.Forms.InsufficientLicenseWindow).Show();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		((Form)MyProject.Forms.MainForm).Close();
	}

	private void StartGame_FormClosed(object sender, FormClosedEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void StartGame_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		PictureBox1.Image = (Image)(object)Module1.SplashImage;
		((Control)Button_Campaign).Visible = true;
		((Control)MyProject.Forms.MainForm).Enabled = false;
		Client.CurrentGame.Pause();
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (FileExistsNative.FileExistsFast(GameGeneral.ScenariosRootPath + "\\Autosave.scen"))
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
			MyProject.Forms.ResumeFromSave.SelectedFilename = GameGeneral.ScenariosRootPath + "\\Autosave.scen";
			((Control)MyProject.Forms.ResumeFromSave).Show();
			((Form)this).Close();
		}
		else
		{
			DarkMessageBox.ShowError("No autosave file was found at the path \\Scenarios\\Autosave.scen", "No autosave found");
		}
	}

	private void StartGame_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
	}

	private void StartGame_Shown(object sender, EventArgs e)
	{
		if (SimConfiguration.DefaultGamePreferences.GameMusic)
		{
			Sound.StartMusic();
		}
		((Form)this).Close();
	}

	private void method_8(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.CampaignPlayWindow).Show();
		((Form)this).Close();
	}

	private void method_9(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.QuickBattle).Show();
		((Form)this).Close();
	}

	static StartGame()
	{
		Class72.smethod_20();
	}
}

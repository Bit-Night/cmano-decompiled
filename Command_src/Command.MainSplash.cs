using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace Command;

[DesignerGenerated]
public sealed class MainSplash : Form
{
	private IContainer icontainer_0;

	[field: AccessedThroughProperty("PictureBox1")]
	internal virtual PictureBox PictureBox1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	public MainSplash()
	{
		((Form)this).Load += MainSplash_Load;
		((Form)this).Shown += MainSplash_Shown;
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
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainSplash));
		PictureBox1 = new PictureBox();
		Label1 = new Label();
		((ISupportInitialize)PictureBox1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PictureBox1).Dock = (DockStyle)5;
		PictureBox1.Image = (Image)componentResourceManager.GetObject("PictureBox1.Image");
		((Control)PictureBox1).Location = new Point(0, 0);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(483, 292);
		PictureBox1.SizeMode = (PictureBoxSizeMode)4;
		PictureBox1.TabIndex = 6;
		PictureBox1.TabStop = false;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.Red;
		((Control)Label1).Location = new Point(12, 9);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(10, 13);
		((Control)Label1).TabIndex = 7;
		Label1.Text = " ";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(483, 292);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "MainSplash";
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Command - Modern Air/Naval Operations";
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MainSplash_Load(object sender, EventArgs e)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((Control)this).Visible = false;
		try
		{
			GameGeneral.WriteLogDebugInfoToFile("Discovering DPI");
			if (Client.DPI_scale == 0f)
			{
				GameGeneral.WriteLogDebugInfoToFile("DPI_scale = 0");
				Module1.smethod_5((Form)(object)this);
			}
			if (Client.DPI_scale == 1f)
			{
				((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
			}
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("Showing splash screen.");
			}
			if (Client.DPI_scale > 1f)
			{
				GameGeneral.WriteLogDebugInfoToFile("AdjustForHighDPI");
				AdjustForHighDPI();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			GameGeneral.WriteLogDebugInfoToFile("EXCEPTION during DPI");
			ProjectData.ClearProjectError();
		}
		((Control)Label1).Visible = false;
		try
		{
			GameGeneral.WriteLogDebugInfoToFile("Loading splash image");
			PictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Symbols\\splash.jpg"));
			Module1.SplashImage = (Bitmap)PictureBox1.Image;
			GameGeneral.WriteLogDebugInfoToFile("Splash image loaded");
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			GameGeneral.WriteLogDebugInfoToFile("EXCEPTION on SPLASH loading");
			ProjectData.ClearProjectError();
		}
		try
		{
			GameGeneral.WriteLogDebugInfoToFile("Client.Initalize");
			Client.Initialize();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			GameGeneral.WriteLogDebugInfoToFile("Client.Initalize FAILED");
			ProjectData.ClearProjectError();
		}
		Client.CurrentUserAction = Client.UserAction.None;
		((Control)this).Visible = true;
	}

	private void MainSplash_Shown(object sender, EventArgs e)
	{
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Wait for terrain to load.");
		}
		while (!Terrain.TerrainHasLoaded)
		{
			Thread.Sleep(100);
		}
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Terrain loaded.");
		}
	}

	public void AdjustForHighDPI()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		string text = Path.Combine(Application.StartupPath, Process.GetCurrentProcess().ProcessName + ".exe");
		if (!FileExistsNative.FileExistsFast(text))
		{
			DarkMessageBox.ShowError("File Command.exe not found on this folder. Please run this tool inside the same folder that Command.exe is located. Press any key to exit.", "File not found");
			Environment.Exit(0);
		}
		if (!method_0(Registry.CurrentUser, "Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers"))
		{
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers");
		}
		string text2 = Conversions.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, (object)string.Empty));
		if (text2.Contains("~ DPIUNAWARE"))
		{
			return;
		}
		bool flag = false;
		try
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, (object)(text2 + " ~ DPIUNAWARE"));
			text2 = Conversions.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, (object)string.Empty));
			flag = text2.Contains("~ DPIUNAWARE");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			flag = false;
			ProjectData.ClearProjectError();
		}
		if (!flag)
		{
			DarkMessageBox.ShowWarning("CAUTION! Your system appears to be using a high-DPI desktop setting (e.g. a 1440p or 4K monitor). We reccomend that you exit Command and run the 4KFix helper app (located on the same folder as Command.exe) to properly adjust Command for this environment. We apologize for the inconvenience!", "High-DPI settings detected");
			return;
		}
		string path = Path.Combine(GameGeneral.TempPath, "instance");
		if (Directory.Exists(path))
		{
			Directory.Delete(path, recursive: true);
		}
		try
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo(text);
			processStartInfo.CreateNoWindow = false;
			processStartInfo.UseShellExecute = false;
			Process process = new Process();
			process.StartInfo = processStartInfo;
			process.Start();
			Environment.Exit(0);
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
	}

	private bool method_0(RegistryKey registryKey_0, string string_0)
	{
		return registryKey_0.OpenSubKey(string_0) != null;
	}

	static MainSplash()
	{
		Class72.smethod_20();
	}
}

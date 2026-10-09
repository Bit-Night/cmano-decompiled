using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Command_Core;
using Command.My;
using Command.SmartAssembly.Attributes;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class StartGameMenuWindowViewModel : CommandViewModel
{
	private BitmapSource bitmapSource_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_1;

	[CompilerGenerated]
	private RelayCommand relayCommand_2;

	[CompilerGenerated]
	private RelayCommand relayCommand_3;

	[CompilerGenerated]
	private RelayCommand relayCommand_4;

	[CompilerGenerated]
	private RelayCommand relayCommand_5;

	[CompilerGenerated]
	private RelayCommand relayCommand_6;

	[CompilerGenerated]
	private RelayCommand relayCommand_7;

	[CompilerGenerated]
	private RelayCommand relayCommand_8;

	[CompilerGenerated]
	private RelayCommand relayCommand_9;

	[CompilerGenerated]
	private RelayCommand relayCommand_10;

	[CompilerGenerated]
	private RelayCommand relayCommand_11;

	private StartGameMenuWindow startGameMenuWindow_0;

	public BitmapSource BackgroundImage
	{
		get
		{
			return bitmapSource_0;
		}
		set
		{
			SetProperty(ref bitmapSource_0, value, "BackgroundImage");
		}
	}

	public RelayCommand StartNewCampaignCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_0;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_0 = value;
		}
	}

	public RelayCommand QuickBattleCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_1;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_1 = value;
		}
	}

	public RelayCommand NewGameCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_2;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_2 = value;
		}
	}

	public RelayCommand LoadGameCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_3;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_3 = value;
		}
	}

	public RelayCommand ResumeGameCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_4;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_4 = value;
		}
	}

	public RelayCommand CreateScenCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_5;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_5 = value;
		}
	}

	public RelayCommand WEGOMultiplayerCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_6;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_6 = value;
		}
	}

	public RelayCommand RTMPHostMultiplayerCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_7;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_7 = value;
		}
	}

	public RelayCommand RTMPJoinMultiplayerCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_8;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_8 = value;
		}
	}

	public RelayCommand StartRAMDBCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_9;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_9 = value;
		}
	}

	public RelayCommand LoadScenCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_10;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_10 = value;
		}
	}

	public RelayCommand ExitCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_11;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_11 = value;
		}
	}

	public void RTMPHostMultiplayerSubroutine(object obj)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			MyProject.Forms.MainForm.Realtime_StartHost();
		}));
		((Window)startGameMenuWindow_0).Close();
	}

	public void RTMPJoinMultiplayerSubroutine(object obj)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			MyProject.Forms.MainForm.Realtime_Connect();
		}));
		((Window)startGameMenuWindow_0).Close();
	}

	public void method_0(object obj)
	{
	}

	private void method_1(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			((Control)MyProject.Forms.WEGOMultiplayerForm).Show();
		}));
		((Window)startGameMenuWindow_0).Close();
	}

	private void method_2(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			((Control)MyProject.Forms.QuickBattle).Show();
		}));
		((Window)startGameMenuWindow_0).Close();
	}

	private void method_3(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			((Form)MyProject.Forms.MainForm).Close();
		}));
	}

	private void method_4(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
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
		}));
	}

	private void method_5(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			if (!Licensing.get_ModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
			{
				MyProject.Forms.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleLicense.CommandFullVersion };
				((Control)MyProject.Forms.InsufficientLicenseWindow).Show();
			}
			else
			{
				Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
				Client.CreateNewScenario();
			}
		}));
		((Window)startGameMenuWindow_0).Close();
	}

	private void method_6(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			string text = "";
			if (Directory.Exists(GameGeneral.ScenariosRootPath + "\\Autosaves"))
			{
				DirectoryInfo directoryInfo = (from p in new DirectoryInfo(GameGeneral.ScenariosRootPath + "\\Autosaves").GetDirectories()
					orderby p.LastWriteTime descending
					select p).First();
				text = GameGeneral.ScenariosRootPath + "\\Autosaves\\" + directoryInfo.Name + " \\Autosave.scen";
			}
			if (Operators.CompareString(text, "", true) != 0 && FileExistsNative.FileExistsFast(text))
			{
				Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
				MyProject.Forms.ResumeFromSave.SelectedFilename = text;
				((Control)MyProject.Forms.ResumeFromSave).Show();
			}
			else if (FileExistsNative.FileExistsFast(GameGeneral.ScenariosRootPath + "\\Autosave.scen"))
			{
				Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
				MyProject.Forms.ResumeFromSave.SelectedFilename = GameGeneral.ScenariosRootPath + "\\Autosave.scen";
				((Control)MyProject.Forms.ResumeFromSave).Show();
			}
			else
			{
				DarkMessageBox.ShowError("No autosave file was found at the path " + text, "No autosave found");
			}
		}));
	}

	private void method_7(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
			MyProject.Forms.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadSavedGame;
			((Control)MyProject.Forms.LoadScenario).Show();
		}));
	}

	private void method_8(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
			MyProject.Forms.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
			((Control)MyProject.Forms.LoadScenario).Show();
		}));
	}

	private void method_9(object object_0)
	{
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			((Control)MyProject.Forms.CampaignPlayWindow).Show();
		}));
	}

	[Obsolete]
	public StartGameMenuWindowViewModel()
	{
		StartNewCampaignCommand = new RelayCommand(method_9);
		QuickBattleCommand = new RelayCommand(method_2);
		NewGameCommand = new RelayCommand(method_8);
		LoadGameCommand = new RelayCommand(method_7);
		ResumeGameCommand = new RelayCommand(method_6);
		CreateScenCommand = new RelayCommand(method_5);
		WEGOMultiplayerCommand = new RelayCommand(method_1);
		RTMPHostMultiplayerCommand = new RelayCommand(RTMPHostMultiplayerSubroutine);
		RTMPJoinMultiplayerCommand = new RelayCommand(RTMPJoinMultiplayerSubroutine);
		StartRAMDBCommand = new RelayCommand(method_0);
		LoadScenCommand = new RelayCommand(method_4);
		ExitCommand = new RelayCommand(method_3);
	}

	public StartGameMenuWindowViewModel(StartGameMenuWindow sg)
	{
		StartNewCampaignCommand = new RelayCommand(method_9);
		QuickBattleCommand = new RelayCommand(method_2);
		NewGameCommand = new RelayCommand(method_8);
		LoadGameCommand = new RelayCommand(method_7);
		ResumeGameCommand = new RelayCommand(method_6);
		CreateScenCommand = new RelayCommand(method_5);
		WEGOMultiplayerCommand = new RelayCommand(method_1);
		RTMPHostMultiplayerCommand = new RelayCommand(RTMPHostMultiplayerSubroutine);
		RTMPJoinMultiplayerCommand = new RelayCommand(RTMPJoinMultiplayerSubroutine);
		StartRAMDBCommand = new RelayCommand(method_0);
		LoadScenCommand = new RelayCommand(method_4);
		ExitCommand = new RelayCommand(method_3);
		startGameMenuWindow_0 = sg;
	}

	static StartGameMenuWindowViewModel()
	{
		Class72.smethod_20();
	}
}

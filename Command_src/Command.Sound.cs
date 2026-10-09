using System;
using System.Diagnostics;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class Sound
{
	public static SoundHandler_Music MusicHandler;

	public static SoundHandler_Effects SoundEffectsHandler;

	public static void CreateSoundHandlers()
	{
		try
		{
			MusicHandler = new SoundHandler_Music();
			SoundEffectsHandler = new SoundHandler_Effects();
			SoundEffectsHandler.Volume = SimConfiguration.DefaultGamePreferences.SFXVolume;
			MusicHandler.Volume = SimConfiguration.DefaultGamePreferences.MusicVolume;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200419", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			HandleSoundException(ex2);
			ProjectData.ClearProjectError();
		}
	}

	public static void StartMusic()
	{
		try
		{
			MusicHandler.StartPlayingMusic();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200420", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			HandleSoundException(ex2);
			ProjectData.ClearProjectError();
		}
	}

	public static void HandleSoundException(Exception ex)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		DarkMessageBox.ShowError("There has been a serious error with sound. The error description is: " + ex.Message + " . Sound effects and music will now be disabled. Please contact the Command development team with this information to help them troubleshoot this issue.", "Critical sound problem");
		SimConfiguration.DefaultGamePreferences.GameSounds = false;
		SimConfiguration.DefaultGamePreferences.GameMusic = false;
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
	}

	static Sound()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class SoundHandler_Music
{
	private string string_0;

	private bool bool_0;

	[CompilerGenerated]
	[AccessedThroughProperty("MusicPlayer")]
	private MediaPlayer mediaPlayer_0;

	private int int_0;

	private double double_0;

	public virtual MediaPlayer MusicPlayer
	{
		[CompilerGenerated]
		get
		{
			return mediaPlayer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = [SpecialName] (object sender, EventArgs e) =>
			{
				method_1();
			};
			MediaPlayer val = mediaPlayer_0;
			if (val != null)
			{
				val.MediaEnded -= eventHandler;
			}
			mediaPlayer_0 = value;
			val = mediaPlayer_0;
			if (val != null)
			{
				val.MediaEnded += eventHandler;
			}
		}
	}

	public int Volume
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			double_0 = (double)value / 100.0;
			MusicPlayer.Volume = double_0;
			SimConfiguration.DefaultGamePreferences.MusicVolume = value;
		}
	}

	public SoundHandler_Music()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		string_0 = Application.StartupPath + "\\Sound\\Music\\";
		MusicPlayer = new MediaPlayer();
	}

	public void StartPlayingMusic()
	{
		bool_0 = false;
		if (FileExistsNative.FileExistsFast(string_0 + "Title.mp3"))
		{
			method_0(string_0 + "Title.mp3");
		}
	}

	public void StopPlayingMusic()
	{
		bool_0 = true;
		if (!Information.IsNothing((object)MusicPlayer))
		{
			MusicPlayer.Stop();
		}
	}

	private void method_0(string string_1)
	{
		try
		{
			((DispatcherObject)MusicPlayer).Dispatcher.Invoke((Action)([SpecialName] () =>
			{
				MusicPlayer.Open(new Uri(string_1));
				MusicPlayer.Play();
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200422", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_1()
	{
		if (!bool_0)
		{
			List<string> list = Directory.GetFiles(string_0).ToList();
			if (list.Count != 0)
			{
				Misc.Shuffle(list);
				method_0(list[0]);
			}
		}
	}

	static SoundHandler_Music()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Magic.Samples.DisplaySettings;

public static class DisplayManager
{
	public static DisplaySettings GetCurrentSettings()
	{
		return smethod_0(-1, smethod_1());
	}

	public static void SetDisplaySettings(DisplaySettings set)
	{
		SafeNativeMethods.DEVMODE lpDevMode = smethod_1();
		lpDevMode.dmPelsWidth = (uint)set.Width;
		lpDevMode.dmPelsHeight = (uint)set.Height;
		lpDevMode.dmDisplayOrientation = (uint)set.Orientation;
		lpDevMode.dmBitsPerPel = (uint)set.BitCount;
		lpDevMode.dmDisplayFrequency = (uint)set.Frequency;
		DisplayChangeResult displayChangeResult = (DisplayChangeResult)SafeNativeMethods.ChangeDisplaySettings(ref lpDevMode, 0u);
		string text = null;
		switch (displayChangeResult)
		{
		case DisplayChangeResult.BadDualView:
			text = "The settings change was unsuccessful because system is DualView capable.";
			break;
		case DisplayChangeResult.BadParam:
			text = "An invalid parameter was passed in. This can include an invalid flag or combination of flags.";
			break;
		case DisplayChangeResult.BadFlags:
			text = "An invalid set of flags was passed in.";
			break;
		case DisplayChangeResult.NotUpdated:
			text = "Unable to write settings to the registry.";
			break;
		case DisplayChangeResult.BadMode:
			text = "The graphics mode is not supported.";
			break;
		case DisplayChangeResult.Failed:
			text = "The display driver failed the specified graphics mode.";
			break;
		case DisplayChangeResult.Restart:
			text = "The computer must be restarted in order for the graphics mode to work.";
			break;
		}
		if (text != null)
		{
			throw new InvalidOperationException(text);
		}
	}

	public static IEnumerator<DisplaySettings> GetModesEnumerator()
	{
		SafeNativeMethods.DEVMODE mode = default(SafeNativeMethods.DEVMODE);
		mode.Initialize();
		int idx = 0;
		while (SafeNativeMethods.EnumDisplaySettings(null, idx, ref mode))
		{
			yield return smethod_0(idx++, mode);
		}
	}

	public static void RotateScreen(bool clockwise)
	{
		DisplaySettings currentSettings = GetCurrentSettings();
		int height = currentSettings.Height;
		currentSettings.Height = currentSettings.Width;
		currentSettings.Width = height;
		if (!clockwise)
		{
			currentSettings.Orientation--;
		}
		else
		{
			currentSettings.Orientation++;
		}
		if (currentSettings.Orientation >= Orientation.Default)
		{
			if (currentSettings.Orientation > Orientation.Clockwise270)
			{
				currentSettings.Orientation = Orientation.Default;
			}
		}
		else
		{
			currentSettings.Orientation = Orientation.Clockwise270;
		}
		SetDisplaySettings(currentSettings);
	}

	private static DisplaySettings smethod_0(int int_0, SafeNativeMethods.DEVMODE devmode_0)
	{
		return new DisplaySettings
		{
			Index = int_0,
			Width = (int)devmode_0.dmPelsWidth,
			Height = (int)devmode_0.dmPelsHeight,
			Orientation = (Orientation)devmode_0.dmDisplayOrientation,
			BitCount = (int)devmode_0.dmBitsPerPel,
			Frequency = (int)devmode_0.dmDisplayFrequency
		};
	}

	private static SafeNativeMethods.DEVMODE smethod_1()
	{
		SafeNativeMethods.DEVMODE lpDevMode = default(SafeNativeMethods.DEVMODE);
		lpDevMode.Initialize();
		if (!SafeNativeMethods.EnumDisplaySettings(null, -1, ref lpDevMode))
		{
			throw new InvalidOperationException(smethod_2());
		}
		return lpDevMode;
	}

	private static string smethod_2()
	{
		int lastWin32Error = Marshal.GetLastWin32Error();
		if (SafeNativeMethods.FormatMessage(4864u, 2048u, (uint)lastWin32Error, 0u, out var lpBuffer, 0u, 0u) == 0)
		{
			return "Fatal error.";
		}
		return lpBuffer;
	}

	static DisplayManager()
	{
		Class72.smethod_20();
	}
}

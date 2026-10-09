using System;
using System.Runtime.InteropServices;

namespace CSMaterial;

public class WindowDarkMode
{
	[DllImport("dwmapi.dll")]
	private static extern int DwmSetWindowAttribute(IntPtr intptr_0, int int_0, ref int int_1, int int_2);

	public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
	{
		if (OSVersionInfo.BuildVersion > 17763)
		{
			int int_ = 19;
			if (OSVersionInfo.BuildVersion > 18985)
			{
				int_ = 20;
			}
			int int_2 = (enabled ? 1 : 0);
			return DwmSetWindowAttribute(handle, int_, ref int_2, 4) == 0;
		}
		return false;
	}

	static WindowDarkMode()
	{
		Class72.smethod_20();
	}
}

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Steamworks;

namespace Command;

public sealed class SteamNag
{
	public static void PerformNagChecks()
	{
	}

	private static string smethod_0()
	{
		string path = (Environment.Is64BitOperatingSystem ? Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam", "InstallPath", (object)null)) : Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Valve\\Steam", "InstallPath", (object)null)));
		return Path.Combine(path, "userdata\\" + SteamUser.GetSteamID().GetAccountID().ToString() + "\\config\\localconfig.vdf");
	}

	public static bool IsDirectWriteDisabled()
	{
		RegistryKey val = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
		int result;
		if (val != null)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(val.GetValue("DWriteEnable"));
			if (objectValue != null)
			{
				if (!Operators.ConditionalCompareObjectEqual(objectValue, (object)1, true))
				{
					result = 1;
					goto IL_003e;
				}
				return false;
			}
		}
		result = 1;
		goto IL_003e;
		IL_003e:
		return (byte)result != 0;
	}

	public static bool IsSteamOverlayDisabled()
	{
		if (!SteamUtils.IsOverlayEnabled())
		{
			string key = Conversions.ToString(Licensing.appID_FullBaseVersion.m_AppId);
			VProperty vProperty = VdfConvert.Deserialize(File.ReadAllText(smethod_0()));
			VToken vToken = vProperty.Value["Apps"];
			if (vToken == null)
			{
				vToken = vProperty.Value["apps"];
			}
			VProperty vProperty2 = vToken[key].Children().FirstOrDefault([SpecialName] (VProperty F) => Operators.CompareString(F.Key, "OverlayAppEnable", true) == 0);
			if (vProperty2 != null)
			{
				if (Operators.CompareString(vProperty2.Value.ToString(), "0", true) == 0)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	static SteamNag()
	{
		Class72.smethod_20();
	}
}

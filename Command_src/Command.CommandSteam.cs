using Microsoft.VisualBasic.CompilerServices;
using Steamworks;

namespace Command;

[StandardModule]
public sealed class CommandSteam
{
	public static bool steamOnline;

	private static bool bool_0;

	static CommandSteam()
	{
		Class72.smethod_20();
		bool_0 = false;
	}

	public static void CloseSteamConnection()
	{
		if (steamOnline)
		{
			SteamAPI.Shutdown();
		}
	}

	public static void RunCallbacks()
	{
		if (steamOnline)
		{
			SteamAPI.RunCallbacks();
		}
	}

	public static void OpenSteamConnection()
	{
		if (!bool_0)
		{
			steamOnline = SteamAPI.Init();
			bool_0 = true;
		}
	}

	public static bool CheckModuleLicence(AppId_t theAppID)
	{
		if (!steamOnline && !bool_0)
		{
			OpenSteamConnection();
		}
		int result;
		if (!steamOnline)
		{
			byte[] array = new byte[1025];
			if (SteamUser.GetAuthSessionTicket(array, 1024, out var pcbTicket) != HAuthTicket.Invalid && (ulong)pcbTicket > 0uL)
			{
				SteamUser.BeginAuthSession(array, (int)pcbTicket, SteamUser.GetSteamID());
				if (SteamUser.UserHasLicenseForApp(SteamUser.GetSteamID(), theAppID) == EUserHasLicenseForAppResult.k_EUserHasLicenseResultHasLicense)
				{
					return true;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
		}
		else
		{
			if (SteamApps.BIsSubscribedApp(theAppID))
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool CheckDLCLicence(AppId_t theDLCID)
	{
		if (!steamOnline && !bool_0)
		{
			OpenSteamConnection();
		}
		int result;
		if (steamOnline)
		{
			if (SteamApps.BIsDlcInstalled(theDLCID))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			byte[] array = new byte[1025];
			if (!(SteamUser.GetAuthSessionTicket(array, 1024, out var pcbTicket) != HAuthTicket.Invalid && (ulong)pcbTicket > 0uL))
			{
				result = 0;
			}
			else
			{
				SteamUser.BeginAuthSession(array, (int)pcbTicket, SteamUser.GetSteamID());
				if (SteamUser.UserHasLicenseForApp(SteamUser.GetSteamID(), theDLCID) == EUserHasLicenseForAppResult.k_EUserHasLicenseResultHasLicense)
				{
					return true;
				}
				result = 0;
			}
		}
		return (byte)result != 0;
	}
}

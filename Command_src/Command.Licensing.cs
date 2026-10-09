using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Steamworks;

namespace Command;

[StandardModule]
public sealed class Licensing
{
	internal struct ModuleLicenseRecord
	{
		public string ModuleName;

		public AppId_t SteamID;

		public AppId_t SteamID_CMO;

		public string RegistryKeySuffix;

		public string RegistryKeySuffix_CMO;

		public string DestinationURL_MG;

		public string NoLicenseImage;

		public Color ThemeColor;
	}

	public enum ModuleLicense
	{
		CommandFullVersion,
		NorthernInferno,
		LIVE_OldGrudges,
		LIVE_Brexit,
		LIVE_Spratly,
		LIVE_Don,
		LIVE_Korea,
		ChainsOfWar,
		CommandPE,
		LIVE_Pole,
		ShiftingSands,
		LIVE_BlackGold,
		TheSilentService,
		LIVE_Commonwealth,
		LIVE_Kuril,
		LIVE_KingOfTheBorder,
		DesertStorm,
		LIVE_BrokenShield300,
		LIVE_AegeanInFlames,
		LIVE_SahelSlugfest,
		KashmirFire,
		RedTide,
		Showcase_QueenElizabeth,
		const_23,
		Showcase_FordClass,
		Showcase_DesertFalcon,
		Showcase_Icebreakers,
		FailSafe,
		TidesOfWar
	}

	public static AppId_t appID_FullBaseVersion;

	private static Dictionary<ModuleLicense, ModuleLicenseRecord> dictionary_0;

	private static HashSet<ModuleLicense> hashSet_0;

	public static bool ModuleIsLicensed => hashSet_0.Contains(theModule);

	static Licensing()
	{
		Class72.smethod_20();
		appID_FullBaseVersion = new AppId_t(1076160u);
		dictionary_0 = new Dictionary<ModuleLicense, ModuleLicenseRecord>();
		hashSet_0 = new HashSet<ModuleLicense>();
	}

	public static void Initialize(bool RunningInSteamMode)
	{
		try
		{
			smethod_0();
			foreach (KeyValuePair<ModuleLicense, ModuleLicenseRecord> item in dictionary_0)
			{
				smethod_1(item.Key);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200416", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal static List<ModuleLicenseRecord> GetSelectedLicenseRecords(List<ModuleLicense> theModuleLicenses)
	{
		List<ModuleLicenseRecord> list = new List<ModuleLicenseRecord>();
		foreach (ModuleLicense theModuleLicense in theModuleLicenses)
		{
			list.Add(dictionary_0[theModuleLicense]);
		}
		return list;
	}

	private static void smethod_0()
	{
		ModuleLicenseRecord value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Modern Operations",
			SteamID = appID_FullBaseVersion,
			RegistryKeySuffix = "Command Modern Operations",
			RegistryKeySuffix_CMO = "Command Modern Operations",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-modern-operations",
			NoLicenseImage = "NoLicense_CMO.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.CommandFullVersion, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Professional Edition",
			SteamID = new AppId_t(0u),
			RegistryKeySuffix = "Command Professional Edition",
			DestinationURL_MG = "http://www.warfaresims.com/?page_id=3822",
			NoLicenseImage = "NoLicense_CPE.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.CommandPE, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Northern Inferno",
			SteamID = new AppId_t(397180u),
			SteamID_CMO = new AppId_t(1182291u),
			RegistryKeySuffix = "Command Northern Inferno",
			RegistryKeySuffix_CMO = "CMO Northern Inferno",
			DestinationURL_MG = "http://www.matrixgames.com/products/589/details/Command:.Northern.Inferno.",
			NoLicenseImage = "NoLicense_NI.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.NorthernInferno, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Chains Of War",
			SteamID = new AppId_t(614130u),
			SteamID_CMO = new AppId_t(1182292u),
			RegistryKeySuffix = "Command Chains Of War",
			RegistryKeySuffix_CMO = "CMO Chains Of War",
			DestinationURL_MG = "http://www.matrixgames.com/products/693/details/Command.Chains.of.War",
			NoLicenseImage = "NoLicense_COW.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.ChainsOfWar, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Shifting Sands",
			SteamID = new AppId_t(718710u),
			SteamID_CMO = new AppId_t(1182290u),
			RegistryKeySuffix = "Command Shifting Sands",
			RegistryKeySuffix_CMO = "CMO Shifting Sands",
			DestinationURL_MG = "http://www.matrixgames.com/products/707/details/Command.Shifting.Sands",
			NoLicenseImage = "NoLicense_SS.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.ShiftingSands, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - The Silent Service",
			SteamID = new AppId_t(785930u),
			SteamID_CMO = new AppId_t(1182293u),
			RegistryKeySuffix = "Command The Silent Service",
			RegistryKeySuffix_CMO = "CMO The Silent Service",
			DestinationURL_MG = "http://www.matrixgames.com/products/product.asp?gid=725",
			NoLicenseImage = "NoLicense_TSS.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.TheSilentService, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Desert Storm",
			SteamID = new AppId_t(1036420u),
			SteamID_CMO = new AppId_t(1182294u),
			RegistryKeySuffix = "Command Desert Storm",
			RegistryKeySuffix_CMO = "CMO Desert Storm",
			DestinationURL_MG = "http://www.matrixgames.com/products/product.asp?gid=797",
			NoLicenseImage = "NoLicense_DS.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.DesertStorm, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Kashmir Fire",
			SteamID = new AppId_t(1594140u),
			SteamID_CMO = new AppId_t(1594140u),
			RegistryKeySuffix = "Command Kashmir Fire",
			RegistryKeySuffix_CMO = "CMO Kashmir Fire",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-kashmir-fire",
			NoLicenseImage = "NoLicense_KF.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.KashmirFire, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Red Tide",
			SteamID = new AppId_t(1712070u),
			SteamID_CMO = new AppId_t(1712070u),
			RegistryKeySuffix = "Command Red Tide",
			RegistryKeySuffix_CMO = "CMO Red Tide",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-red-tide",
			NoLicenseImage = "NoLicense_RT.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.RedTide, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Falklands",
			SteamID = new AppId_t(2141010u),
			SteamID_CMO = new AppId_t(2141010u),
			RegistryKeySuffix = "Command Falklands",
			RegistryKeySuffix_CMO = "CMO Falklands",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-modern-operations-falklands",
			NoLicenseImage = "NoLicense_FLK.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.const_23, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - FailSafe",
			SteamID = new AppId_t(2516830u),
			SteamID_CMO = new AppId_t(2516830u),
			RegistryKeySuffix = "Command Fail Safe",
			RegistryKeySuffix_CMO = "CMO Fail Safe",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-modern-operations-failsafe",
			NoLicenseImage = "NoLicense_FailSafe.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.FailSafe, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command - Tides Of War",
			SteamID = new AppId_t(3979120u),
			SteamID_CMO = new AppId_t(3979120u),
			RegistryKeySuffix = "Command Tides of War",
			RegistryKeySuffix_CMO = "CMO Tides of War",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-modern-operations-tides-of-war",
			NoLicenseImage = "NoLicense_TOW.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.TidesOfWar, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #1 - Old Grudges Never Die",
			SteamID = new AppId_t(388020u),
			SteamID_CMO = new AppId_t(1182305u),
			RegistryKeySuffix = "Command LIVE\\Old Grudges",
			RegistryKeySuffix_CMO = "CMO LIVE\\Old Grudges",
			DestinationURL_MG = "http://www.matrixgames.com/products/636/details/Command.Live:.Old.Grudges.Never.Die",
			NoLicenseImage = "NoLicense_LIVE1.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_OldGrudges, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #2 - You Brexit, You Fix It!",
			SteamID = new AppId_t(497611u),
			SteamID_CMO = new AppId_t(1182309u),
			RegistryKeySuffix = "Command LIVE\\Brexit",
			RegistryKeySuffix_CMO = "CMO LIVE\\Brexit",
			DestinationURL_MG = "http://www.matrixgames.com/products/640/details/CommandLive:YouBrexit,YouFixit!",
			NoLicenseImage = "NoLicense_LIVE2.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_Brexit, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #3 - Spratly Spat",
			SteamID = new AppId_t(527370u),
			SteamID_CMO = new AppId_t(1182307u),
			RegistryKeySuffix = "Command LIVE\\Spratly",
			RegistryKeySuffix_CMO = "CMO LIVE\\Spratly",
			DestinationURL_MG = "http://www.matrixgames.com/products/643/details/Command.LIVE:.Spratly.Spat",
			NoLicenseImage = "NoLicense_LIVE3.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.LIVE_Spratly, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #4 - Don of a New Era",
			SteamID = new AppId_t(497610u),
			SteamID_CMO = new AppId_t(1182302u),
			RegistryKeySuffix = "Command LIVE\\Don Era",
			RegistryKeySuffix_CMO = "CMO LIVE\\Don Era",
			DestinationURL_MG = "http://www.matrixgames.com/products/648/details/CommandLive:DonofanewEra",
			NoLicenseImage = "NoLicense_LIVE4.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_Don, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #5 - Korean Missile Crisis",
			SteamID = new AppId_t(584260u),
			SteamID_CMO = new AppId_t(1182303u),
			RegistryKeySuffix = "Command LIVE\\Korea",
			RegistryKeySuffix_CMO = "CMO LIVE\\Korea",
			DestinationURL_MG = "http://www.matrixgames.com/products/681/details/Command.Live:.Korean.Missile.Crisis",
			NoLicenseImage = "NoLicense_LIVE5.jpg",
			ThemeColor = Color.DarkRed
		};
		dictionary_0.Add(ModuleLicense.LIVE_Korea, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #6 - Pole Positions",
			SteamID = new AppId_t(670700u),
			SteamID_CMO = new AppId_t(1182306u),
			RegistryKeySuffix = "Command LIVE\\Pole Positions",
			RegistryKeySuffix_CMO = "CMO LIVE\\Pole Positions",
			DestinationURL_MG = "http://www.matrixgames.com/products/702/details/Command.Live.Pole.Positions",
			NoLicenseImage = "NoLicense_LIVE6.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_Pole, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #7 - Black Gold Blitz",
			SteamID = new AppId_t(729630u),
			SteamID_CMO = new AppId_t(1182300u),
			RegistryKeySuffix = "Command LIVE\\Black Gold Blitz",
			RegistryKeySuffix_CMO = "CMO LIVE\\Black Gold Blitz",
			DestinationURL_MG = "http://www.matrixgames.com/products/product.asp?gid=713",
			NoLicenseImage = "NoLicense_LIVE7.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_BlackGold, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #8 - Commonwealth Collision",
			SteamID = new AppId_t(842960u),
			SteamID_CMO = new AppId_t(1182301u),
			RegistryKeySuffix = "Command LIVE\\Commonwealth Collision",
			RegistryKeySuffix_CMO = "CMO LIVE\\Commonwealth Collision",
			DestinationURL_MG = "http://www.matrixgames.com/products/product.asp?gid=731",
			NoLicenseImage = "NoLicense_LIVE8.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_Commonwealth, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #9 - Kuril Sunrise",
			SteamID = new AppId_t(899280u),
			SteamID_CMO = new AppId_t(1182304u),
			RegistryKeySuffix = "Command LIVE\\Kuril Sunrise",
			RegistryKeySuffix_CMO = "CMO LIVE\\Kuril Sunrise",
			DestinationURL_MG = "http://www.matrixgames.com/products/739/details/Command.Live.Kuril.Sunrise",
			NoLicenseImage = "NoLicense_LIVE9.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_Kuril, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #10 - The King Of The Border",
			SteamID = new AppId_t(1011400u),
			SteamID_CMO = new AppId_t(1182308u),
			RegistryKeySuffix = "Command LIVE\\King Border",
			RegistryKeySuffix_CMO = "CMO LIVE\\King Border",
			DestinationURL_MG = "http://www.matrixgames.com/products/product.asp?gid=794",
			NoLicenseImage = "NoLicense_LIVE10.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_KingOfTheBorder, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #11 - Broken Shield 300",
			SteamID = new AppId_t(1228660u),
			SteamID_CMO = new AppId_t(1228660u),
			RegistryKeySuffix = "Command LIVE\\Broken Shield",
			RegistryKeySuffix_CMO = "CMO LIVE\\Broken Shield",
			DestinationURL_MG = "http://www.matrixgames.com/game/command-live-broken-shield-300",
			NoLicenseImage = "NoLicense_LIVE11.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_BrokenShield300, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #12 - Aegean In Flames",
			SteamID = new AppId_t(1309690u),
			SteamID_CMO = new AppId_t(1309690u),
			RegistryKeySuffix = "Command LIVE\\Aegean In Flames",
			RegistryKeySuffix_CMO = "CMO LIVE\\Aegean In Flames",
			DestinationURL_MG = "http://www.matrixgames.com/game/command-live-aegean-in-flames",
			NoLicenseImage = "NoLicense_LIVE12.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_AegeanInFlames, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command LIVE #13 - Sahel Slugfest",
			SteamID = new AppId_t(1438050u),
			SteamID_CMO = new AppId_t(1438050u),
			RegistryKeySuffix = "Command LIVE\\Sahel Slugfest",
			RegistryKeySuffix_CMO = "CMO LIVE\\Sahel Slugfest",
			DestinationURL_MG = "http://www.matrixgames.com/game/command-live-sahel-slugfest",
			NoLicenseImage = "NoLicense_LIVE13.jpg",
			ThemeColor = Color.LightSkyBlue
		};
		dictionary_0.Add(ModuleLicense.LIVE_SahelSlugfest, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command Showcase #1 - Queen Elizabeth",
			SteamID = new AppId_t(1178900u),
			SteamID_CMO = new AppId_t(1178900u),
			RegistryKeySuffix = "Command Showcase\\Queen Elizabeth",
			RegistryKeySuffix_CMO = "CMO Showcase\\Queen Elizabeth",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-showcase-queen-elizabeth",
			NoLicenseImage = "NoLicense_Showcase1.jpg",
			ThemeColor = Color.Aquamarine
		};
		dictionary_0.Add(ModuleLicense.Showcase_QueenElizabeth, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command Showcase #2 - Ford Class",
			SteamID = new AppId_t(2306370u),
			SteamID_CMO = new AppId_t(2306370u),
			RegistryKeySuffix = "Command Showcase\\Ford Class",
			RegistryKeySuffix_CMO = "CMO Showcase\\Ford Class",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-showcase-ford-class",
			NoLicenseImage = "NoLicense_Showcase2.jpg",
			ThemeColor = Color.Aquamarine
		};
		dictionary_0.Add(ModuleLicense.Showcase_FordClass, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command Showcase #3 - Operation Desert Falcon",
			SteamID = new AppId_t(2516840u),
			SteamID_CMO = new AppId_t(2516840u),
			RegistryKeySuffix = "Command Showcase\\Operation Desert Falcon",
			RegistryKeySuffix_CMO = "CMO Showcase\\Operation Desert Falcon",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-showcase-operation-desert-falcon",
			NoLicenseImage = "NoLicense_Showcase3.jpg",
			ThemeColor = Color.Aquamarine
		};
		dictionary_0.Add(ModuleLicense.Showcase_DesertFalcon, value);
		value = new ModuleLicenseRecord
		{
			ModuleName = "Command Showcase #4 - Icebreakers",
			SteamID = new AppId_t(2676020u),
			SteamID_CMO = new AppId_t(2676020u),
			RegistryKeySuffix = "Command Showcase\\Icebreakers",
			RegistryKeySuffix_CMO = "CMO Showcase\\Icebreakers",
			DestinationURL_MG = "https://www.matrixgames.com/game/command-showcase-icebreakers",
			NoLicenseImage = "NoLicense_Showcase4.jpg",
			ThemeColor = Color.Aquamarine
		};
		dictionary_0.Add(ModuleLicense.Showcase_Icebreakers, value);
	}

	public static void ActivateLicense(ModuleLicense theModule)
	{
		hashSet_0.Add(theModule);
	}

	public static void DeactivateLicense(ModuleLicense theModule)
	{
		hashSet_0.Remove(theModule);
	}

	public static string GetContentTagFromCampaignID(string theCampaignID)
	{
		if (Operators.CompareString(theCampaignID, "6686549e-66a7-45dc-8f7a-1b0099cdae0a", true) != 0)
		{
			if (Operators.CompareString(theCampaignID, "f8691e80-1caf-4a49-a1b7-9305255a9200", true) == 0)
			{
				return "CHAINSOFWAR";
			}
			if (Operators.CompareString(theCampaignID, "f703124e-f438-42ab-a738-4dcbe7d90c86", true) == 0)
			{
				return "SSANDS";
			}
			if (Operators.CompareString(theCampaignID, "1fd76cc8-ab96-4a23-afc1-5beb48200026", true) != 0)
			{
				if (Operators.CompareString(theCampaignID, "437950b8-3f16-4932-b8e6-a2c397e1f758", true) != 0)
				{
					if (Operators.CompareString(theCampaignID, "182d560e-c5d0-4f80-9c39-3350a0670194", true) != 0)
					{
						if (Operators.CompareString(theCampaignID, "ca630266-f861-4c2f-9031-e527cf2d6e41", true) == 0)
						{
							return "REDTIDE";
						}
						if (Operators.CompareString(theCampaignID, "15a5de63-a739-4c36-b86b-bc9fc15bc092", true) == 0)
						{
							return "FALKLANDS82";
						}
						if (Operators.CompareString(theCampaignID, "51462ad7-afcf-4d97-b3d9-456fcfecfb91", true) == 0)
						{
							return "FAILSAFE";
						}
						_ = Debugger.IsAttached;
						return null;
					}
					return "KASHMIRFIRE";
				}
				return "DESERTSTORM";
			}
			return "SILENTSERVICE";
		}
		return "NINFERNO";
	}

	private static void smethod_1(ModuleLicense moduleLicense_0)
	{
		if (Client.RunningInSteamMode)
		{
			if (moduleLicense_0 == ModuleLicense.CommandPE)
			{
				return;
			}
			CommandSteam.OpenSteamConnection();
			if (CommandSteam.steamOnline)
			{
				if (CommandSteam.CheckModuleLicence(dictionary_0[moduleLicense_0].SteamID))
				{
					ActivateLicense(moduleLicense_0);
				}
				else if (CommandSteam.CheckModuleLicence(dictionary_0[moduleLicense_0].SteamID_CMO))
				{
					ActivateLicense(moduleLicense_0);
				}
			}
		}
		if (!Licensing.get_ModuleIsLicensed(moduleLicense_0))
		{
			if (smethod_2(dictionary_0[moduleLicense_0].RegistryKeySuffix))
			{
				ActivateLicense(moduleLicense_0);
			}
			else if (smethod_2(dictionary_0[moduleLicense_0].RegistryKeySuffix_CMO))
			{
				ActivateLicense(moduleLicense_0);
			}
		}
	}

	private static bool smethod_2(string string_0)
	{
		RegistryKey val = (Environment.Is64BitOperatingSystem ? Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Matrix Games\\" + string_0) : Registry.LocalMachine.OpenSubKey("SOFTWARE\\Matrix Games\\" + string_0));
		object objectValue = default(object);
		if (val != null)
		{
			objectValue = RuntimeHelpers.GetObjectValue(val.GetValue("authorized"));
		}
		if (objectValue != null)
		{
			return true;
		}
		return false;
	}

	public static bool IsUserLicensedForThisContent(string theContentTag)
	{
		if (Operators.CompareString(theContentTag, "TUTORIAL", true) == 0)
		{
			return hashSet_0.Count > 0;
		}
		if (Operators.CompareString(theContentTag, "", true) == 0)
		{
			return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion);
		}
		if (Operators.CompareString(theContentTag, "NINFERNO", true) != 0)
		{
			if (Operators.CompareString(theContentTag, "CHAINSOFWAR", true) != 0)
			{
				if (Operators.CompareString(theContentTag, "SSANDS", true) != 0)
				{
					if (Operators.CompareString(theContentTag, "SILENTSERVICE", true) != 0)
					{
						if (Operators.CompareString(theContentTag, "DESERTSTORM", true) != 0)
						{
							if (Operators.CompareString(theContentTag, "KASHMIRFIRE", true) == 0)
							{
								return Licensing.get_ModuleIsLicensed(ModuleLicense.KashmirFire);
							}
							if (Operators.CompareString(theContentTag, "REDTIDE", true) != 0)
							{
								if (Operators.CompareString(theContentTag, "FALKLANDS82", true) == 0)
								{
									return Licensing.get_ModuleIsLicensed(ModuleLicense.const_23);
								}
								if (Operators.CompareString(theContentTag, "FAILSAFE", true) != 0)
								{
									if (Operators.CompareString(theContentTag, "TIDESOFWAR", true) != 0)
									{
										if (Operators.CompareString(theContentTag, "OLDGRUDGES", true) != 0)
										{
											if (Operators.CompareString(theContentTag, "BREXIT", true) != 0)
											{
												if (Operators.CompareString(theContentTag, "CLIVE3", true) == 0)
												{
													return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_Spratly);
												}
												if (Operators.CompareString(theContentTag, "DON", true) == 0)
												{
													return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_Don);
												}
												if (Operators.CompareString(theContentTag, "CLIVE5", true) == 0)
												{
													return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_Korea);
												}
												if (Operators.CompareString(theContentTag, "CLIVE6", true) != 0)
												{
													if (Operators.CompareString(theContentTag, "BLACKGOLD", true) != 0)
													{
														if (Operators.CompareString(theContentTag, "CLIVE8", true) != 0)
														{
															if (Operators.CompareString(theContentTag, "CLIVE9", true) == 0)
															{
																return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_Kuril);
															}
															if (Operators.CompareString(theContentTag, "CLIVE10", true) == 0)
															{
																return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_KingOfTheBorder);
															}
															if (Operators.CompareString(theContentTag, "CLIVE11", true) != 0)
															{
																if (Operators.CompareString(theContentTag, "CLIVE12", true) == 0)
																{
																	return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_AegeanInFlames);
																}
																if (Operators.CompareString(theContentTag, "CLIVE13", true) != 0)
																{
																	if (Operators.CompareString(theContentTag, "CSHOW1", true) == 0)
																	{
																		return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.Showcase_QueenElizabeth);
																	}
																	if (Operators.CompareString(theContentTag, "CSHOW2", true) == 0)
																	{
																		return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.Showcase_FordClass);
																	}
																	if (Operators.CompareString(theContentTag, "CSHOW3", true) != 0)
																	{
																		if (Operators.CompareString(theContentTag, "CSHOW4", true) == 0)
																		{
																			return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.Showcase_Icebreakers);
																		}
																		return false;
																	}
																	return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.Showcase_DesertFalcon);
																}
																return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_SahelSlugfest);
															}
															return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_BrokenShield300);
														}
														return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_Commonwealth);
													}
													return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_BlackGold);
												}
												return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_Pole);
											}
											return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_Brexit);
										}
										return Licensing.get_ModuleIsLicensed(ModuleLicense.CommandFullVersion) && Licensing.get_ModuleIsLicensed(ModuleLicense.LIVE_OldGrudges);
									}
									return Licensing.get_ModuleIsLicensed(ModuleLicense.TidesOfWar);
								}
								return Licensing.get_ModuleIsLicensed(ModuleLicense.FailSafe);
							}
							return Licensing.get_ModuleIsLicensed(ModuleLicense.RedTide);
						}
						return Licensing.get_ModuleIsLicensed(ModuleLicense.DesertStorm);
					}
					return Licensing.get_ModuleIsLicensed(ModuleLicense.TheSilentService);
				}
				return Licensing.get_ModuleIsLicensed(ModuleLicense.ShiftingSands);
			}
			return Licensing.get_ModuleIsLicensed(ModuleLicense.ChainsOfWar);
		}
		return Licensing.get_ModuleIsLicensed(ModuleLicense.NorthernInferno);
	}

	public static bool UserHasLicenseForThisFeature(Scenario.ScenarioFeatureOption theFeature)
	{
		return true;
	}

	public static ModuleLicense ModuleEnablingThisContent(string theContentTag)
	{
		if (Operators.CompareString(theContentTag, "TUTORIAL", true) == 0)
		{
			return ModuleLicense.CommandFullVersion;
		}
		if (Operators.CompareString(theContentTag, "NINFERNO", true) != 0)
		{
			if (Operators.CompareString(theContentTag, "CHAINSOFWAR", true) != 0)
			{
				if (Operators.CompareString(theContentTag, "SSANDS", true) == 0)
				{
					return ModuleLicense.ShiftingSands;
				}
				if (Operators.CompareString(theContentTag, "SILENTSERVICE", true) != 0)
				{
					if (Operators.CompareString(theContentTag, "DESERTSTORM", true) == 0)
					{
						return ModuleLicense.DesertStorm;
					}
					if (Operators.CompareString(theContentTag, "KASHMIRFIRE", true) == 0)
					{
						return ModuleLicense.KashmirFire;
					}
					if (Operators.CompareString(theContentTag, "REDTIDE", true) == 0)
					{
						return ModuleLicense.RedTide;
					}
					if (Operators.CompareString(theContentTag, "FALKLANDS82", true) != 0)
					{
						if (Operators.CompareString(theContentTag, "FAILSAFE", true) == 0)
						{
							return ModuleLicense.FailSafe;
						}
						if (Operators.CompareString(theContentTag, "TIDESOFWAR", true) != 0)
						{
							if (Operators.CompareString(theContentTag, "OLDGRUDGES", true) == 0)
							{
								if (!IsUserLicensedForThisContent(""))
								{
									return ModuleLicense.CommandFullVersion;
								}
								return ModuleLicense.LIVE_OldGrudges;
							}
							if (Operators.CompareString(theContentTag, "BREXIT", true) == 0)
							{
								if (!IsUserLicensedForThisContent(""))
								{
									return ModuleLicense.CommandFullVersion;
								}
								return ModuleLicense.LIVE_Brexit;
							}
							if (Operators.CompareString(theContentTag, "CLIVE3", true) == 0)
							{
								if (IsUserLicensedForThisContent(""))
								{
									return ModuleLicense.LIVE_Spratly;
								}
								return ModuleLicense.CommandFullVersion;
							}
							if (Operators.CompareString(theContentTag, "DON", true) != 0)
							{
								if (Operators.CompareString(theContentTag, "CLIVE5", true) == 0)
								{
									if (!IsUserLicensedForThisContent(""))
									{
										return ModuleLicense.CommandFullVersion;
									}
									return ModuleLicense.LIVE_Korea;
								}
								if (Operators.CompareString(theContentTag, "CLIVE6", true) == 0)
								{
									if (IsUserLicensedForThisContent(""))
									{
										return ModuleLicense.LIVE_Pole;
									}
									return ModuleLicense.CommandFullVersion;
								}
								if (Operators.CompareString(theContentTag, "BLACKGOLD", true) != 0)
								{
									if (Operators.CompareString(theContentTag, "CLIVE8", true) != 0)
									{
										if (Operators.CompareString(theContentTag, "CLIVE9", true) != 0)
										{
											if (Operators.CompareString(theContentTag, "CLIVE10", true) != 0)
											{
												if (Operators.CompareString(theContentTag, "CLIVE11", true) != 0)
												{
													if (Operators.CompareString(theContentTag, "CLIVE12", true) != 0)
													{
														if (Operators.CompareString(theContentTag, "CLIVE13", true) != 0)
														{
															if (Operators.CompareString(theContentTag, "CSHOW1", true) == 0)
															{
																if (IsUserLicensedForThisContent(""))
																{
																	return ModuleLicense.Showcase_QueenElizabeth;
																}
																return ModuleLicense.CommandFullVersion;
															}
															if (Operators.CompareString(theContentTag, "CSHOW2", true) == 0)
															{
																if (!IsUserLicensedForThisContent(""))
																{
																	return ModuleLicense.CommandFullVersion;
																}
																return ModuleLicense.Showcase_FordClass;
															}
															if (Operators.CompareString(theContentTag, "CSHOW3", true) != 0)
															{
																if (Operators.CompareString(theContentTag, "CSHOW4", true) == 0)
																{
																	if (IsUserLicensedForThisContent(""))
																	{
																		return ModuleLicense.Showcase_Icebreakers;
																	}
																	return ModuleLicense.CommandFullVersion;
																}
																int result;
																if (!Debugger.IsAttached)
																{
																	result = 0;
																}
																else
																{
																	Debugger.Break();
																	result = 0;
																}
																return (ModuleLicense)result;
															}
															if (!IsUserLicensedForThisContent(""))
															{
																return ModuleLicense.CommandFullVersion;
															}
															return ModuleLicense.Showcase_DesertFalcon;
														}
														if (IsUserLicensedForThisContent(""))
														{
															return ModuleLicense.LIVE_SahelSlugfest;
														}
														return ModuleLicense.CommandFullVersion;
													}
													if (!IsUserLicensedForThisContent(""))
													{
														return ModuleLicense.CommandFullVersion;
													}
													return ModuleLicense.LIVE_AegeanInFlames;
												}
												if (!IsUserLicensedForThisContent(""))
												{
													return ModuleLicense.CommandFullVersion;
												}
												return ModuleLicense.LIVE_BrokenShield300;
											}
											if (IsUserLicensedForThisContent(""))
											{
												return ModuleLicense.LIVE_KingOfTheBorder;
											}
											return ModuleLicense.CommandFullVersion;
										}
										if (IsUserLicensedForThisContent(""))
										{
											return ModuleLicense.LIVE_Kuril;
										}
										return ModuleLicense.CommandFullVersion;
									}
									if (IsUserLicensedForThisContent(""))
									{
										return ModuleLicense.LIVE_Commonwealth;
									}
									return ModuleLicense.CommandFullVersion;
								}
								if (!IsUserLicensedForThisContent(""))
								{
									return ModuleLicense.CommandFullVersion;
								}
								return ModuleLicense.LIVE_BlackGold;
							}
							if (!IsUserLicensedForThisContent(""))
							{
								return ModuleLicense.CommandFullVersion;
							}
							return ModuleLicense.LIVE_Don;
						}
						return ModuleLicense.TidesOfWar;
					}
					return ModuleLicense.const_23;
				}
				return ModuleLicense.TheSilentService;
			}
			return ModuleLicense.ChainsOfWar;
		}
		return ModuleLicense.NorthernInferno;
	}

	public static List<ModuleLicense> ModulesEnablingThisFeature(Scenario.ScenarioFeatureOption theFeature)
	{
		new List<ModuleLicense>();
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return null;
	}
}

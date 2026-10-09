using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;
using VntNet.PowerSchemeSwitcher;

namespace Command;

[StandardModule]
internal sealed class PowerManagement
{
	private static Guid guid_0;

	public static void SwitchToHighPerformance()
	{
		try
		{
			guid_0 = PowerSchemeHelper.GetPowerActiveScheme();
			Dictionary<Guid, PowerPlanInfo> allPowerSchemas = PowerSchemeHelper.GetAllPowerSchemas();
			Guid key = default(Guid);
			foreach (KeyValuePair<Guid, PowerPlanInfo> item in allPowerSchemas)
			{
				if (Operators.CompareString(item.Value.FriendlyName.ToUpper(), "HIGH PERFORMANCE", true) == 0)
				{
					key = item.Key;
					break;
				}
			}
			foreach (KeyValuePair<Guid, PowerPlanInfo> item2 in allPowerSchemas)
			{
				if (Operators.CompareString(item2.Value.FriendlyName.ToUpper(), "ULTIMATE PERFORMANCE", true) == 0)
				{
					key = item2.Key;
					break;
				}
			}
			if (key != guid_0)
			{
				PowerSchemeHelper.SetPowerScheme(key);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ResetToOriginalSetting()
	{
		try
		{
			if (!(PowerSchemeHelper.GetPowerActiveScheme() == guid_0))
			{
				PowerSchemeHelper.SetPowerScheme(guid_0);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static bool IsSupportedByOS()
	{
		if (Environment.OSVersion.Platform != PlatformID.Win32NT)
		{
			return false;
		}
		if (Environment.OSVersion.Version.Major >= 6)
		{
			return true;
		}
		return false;
	}

	static PowerManagement()
	{
		Class72.smethod_20();
	}
}

using System;

namespace VntNet.PowerSchemeSwitcher;

public sealed class PowerPlanInfo
{
	public string FriendlyName;

	public Guid SchemeGuid;

	public object Tag;

	public bool Set()
	{
		return PowerSchemeHelper.SetPowerScheme(SchemeGuid);
	}

	static PowerPlanInfo()
	{
		Class72.smethod_20();
	}
}

using System;
using System.Collections.Generic;
using System.Management;

namespace baileysoft.Wmi;

internal class WMIReader
{
	public static IList<string> GetPropertyValues(Connection WMIConnection, string SelectQuery, string className)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		ManagementScope getConnectionScope = WMIConnection.GetConnectionScope;
		List<string> list = new List<string>();
		SelectQuery val = new SelectQuery(SelectQuery);
		ManagementObjectSearcher val2 = new ManagementObjectSearcher(getConnectionScope, (ObjectQuery)(object)val);
		try
		{
			ManagementObjectEnumerator enumerator = val2.Get().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ManagementObject val3 = (ManagementObject)enumerator.Current;
					foreach (string setting in XMLConfig.GetSettings(className))
					{
						try
						{
							list.Add(setting + ": " + ((ManagementBaseObject)val3)[setting]);
						}
						catch (SystemException)
						{
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
		}
		catch (ManagementException)
		{
		}
		return list;
	}

	static WMIReader()
	{
		Class72.smethod_20();
	}
}

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace baileysoft.Wmi;

internal class Win32_PhysicalMedia : IWMI
{
	private Connection connection_0;

	public Win32_PhysicalMedia(Connection WMIConnection)
	{
		connection_0 = WMIConnection;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return WMIReader.GetPropertyValues(connection_0, "SELECT * FROM " + value, value);
	}

	static Win32_PhysicalMedia()
	{
		Class72.smethod_20();
	}
}

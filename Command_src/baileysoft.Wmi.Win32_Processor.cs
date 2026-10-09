using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace baileysoft.Wmi;

public sealed class Win32_Processor : IWMI
{
	private Connection connection_0;

	public Win32_Processor(Connection WMIConnection)
	{
		connection_0 = WMIConnection;
	}

	public IList<string> GetPropertyValues()
	{
		string value = Regex.Match(GetType().ToString(), "Win32_.*").Value;
		return WMIReader.GetPropertyValues(connection_0, "SELECT * FROM " + value, value);
	}

	static Win32_Processor()
	{
		Class72.smethod_20();
	}
}

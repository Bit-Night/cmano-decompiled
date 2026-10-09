using System.IO;
using System.Reflection;

namespace Command_Core.Lua;

public sealed class slaxml
{
	public static string slaxml()
	{
		Stream manifestResourceStream = Assembly.GetAssembly(typeof(slaxml)).GetManifestResourceStream("Command_Core.slaxml.lua");
		return new StreamReader(manifestResourceStream).ReadToEnd();
	}

	static slaxml()
	{
		Class72.smethod_20();
	}
}

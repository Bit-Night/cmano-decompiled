using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SimConnect_General
{
	public static ISimConnector[] ActiveSimConnectors;

	public static string SimConnect_ConfigFileName => Path.Combine(GameGeneral.ConfigFolderPath, "SimConnect.ini");

	static SimConnect_General()
	{
		Class72.smethod_20();
		ActiveSimConnectors = new ISimConnector[0];
	}
}

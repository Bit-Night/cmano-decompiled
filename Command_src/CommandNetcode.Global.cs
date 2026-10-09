using System.Diagnostics;

namespace CommandNetcode;

public static class Global
{
	public const int DefaultPortWEGO = 46789;

	public const int DefaultPortRTMP = 9000;

	public const string WEGOPacketType = "WEGO";

	public const string string_0 = "TO_HOST";

	public const string RTMPToTerminalPacketType = "TO_TERMINAL";

	internal static string AppId => "CommandModernAirNavalOperations_v1.10 - Build 1900.20";

	public static string GetPassword()
	{
		return PasswordHash.HashPassword("{LRnVumi|v{2>NqBy^&\\!/.73OCz6XkDO_=F]hXwh='!n,O'>GH~Hlp>V48M.?3n");
	}

	public static string CodeLocation()
	{
		StackFrame stackFrame = new StackFrame(1, needFileInfo: true);
		return "File: " + stackFrame.GetFileName() + ", Line: " + stackFrame.GetFileLineNumber();
	}

	static Global()
	{
		Class72.smethod_20();
	}
}

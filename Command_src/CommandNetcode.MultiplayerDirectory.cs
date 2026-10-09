using System.IO;
using Command_Core;

namespace CommandNetcode;

internal static class MultiplayerDirectory
{
	internal static string GetMultiplayerDirectory()
	{
		string text = Path.Combine(GameGeneral.TopLevelWritablePath, "Multiplayer");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text;
	}

	static MultiplayerDirectory()
	{
		Class72.smethod_20();
	}
}

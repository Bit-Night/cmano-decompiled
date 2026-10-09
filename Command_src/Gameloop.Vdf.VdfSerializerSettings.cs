namespace Gameloop.Vdf;

public sealed class VdfSerializerSettings
{
	public bool UsesEscapeSequences;

	public bool UsesConditionals = true;

	public bool bool_0;

	public bool IsWin32 = true;

	public bool IsWindows = true;

	public bool IsOSX;

	public bool IsLinux;

	public bool IsPosix;

	public static VdfSerializerSettings Default => new VdfSerializerSettings();

	public static VdfSerializerSettings Common => new VdfSerializerSettings
	{
		UsesEscapeSequences = true,
		UsesConditionals = true
	};

	static VdfSerializerSettings()
	{
		Class72.smethod_20();
	}
}

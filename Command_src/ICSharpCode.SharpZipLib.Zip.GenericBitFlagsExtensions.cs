namespace ICSharpCode.SharpZipLib.Zip;

public static class GenericBitFlagsExtensions
{
	public static bool HasAny(this GeneralBitFlags target, GeneralBitFlags flags)
	{
		return (target & flags) != 0;
	}

	public static bool HasAll(this GeneralBitFlags target, GeneralBitFlags flags)
	{
		return (target & flags) == flags;
	}

	static GenericBitFlagsExtensions()
	{
		Class72.smethod_20();
	}
}

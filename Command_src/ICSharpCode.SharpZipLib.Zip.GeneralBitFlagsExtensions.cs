namespace ICSharpCode.SharpZipLib.Zip;

public static class GeneralBitFlagsExtensions
{
	public static bool Includes(this GeneralBitFlags flagData, GeneralBitFlags flag)
	{
		return (flag & flagData) != 0;
	}

	static GeneralBitFlagsExtensions()
	{
		Class72.smethod_20();
	}
}
